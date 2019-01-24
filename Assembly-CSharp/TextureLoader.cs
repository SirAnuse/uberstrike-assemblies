using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000414 RID: 1044
public class TextureLoader : AutoMonoBehaviour<TextureLoader>
{
	// Token: 0x06001D9E RID: 7582 RVA: 0x00093134 File Offset: 0x00091334
	protected override void Start()
	{
		base.Start();
		this.nullHolder.Texture = new Texture2D(1, 1, TextureFormat.RGB24, false);
		for (int i = 0; i < 5; i++)
		{
			base.StartCoroutine(this.WorkerCrt());
		}
	}

	// Token: 0x06001D9F RID: 7583 RVA: 0x0009317C File Offset: 0x0009137C
	private IEnumerator WorkerCrt()
	{
		for (;;)
		{
			while (this.pending.Count == 0)
			{
				yield return 0;
			}
			TextureLoader.Holder item = this.pending[0];
			this.pending.RemoveAt(0);
			WWW www = new WWW(item.Url);
			float start = Time.time;
			while (!www.isDone && Time.time - start <= this.TIMEOUT)
			{
				yield return 0;
			}
			if (www.isDone)
			{
				if (string.IsNullOrEmpty(www.error))
				{
					www.LoadImageIntoTexture(item.Texture);
					item.State = TextureLoader.State.Ok;
				}
				else
				{
					item.State = TextureLoader.State.Error;
					Debug.Log("Failed to download texture " + item.Url + ". " + www.error);
				}
			}
			else
			{
				item.State = TextureLoader.State.Timeout;
				Debug.Log("Failed to download texture " + item.Url + ". Timeout.");
				www.Dispose();
			}
		}
		yield break;
	}

	// Token: 0x06001DA0 RID: 7584 RVA: 0x00013A44 File Offset: 0x00011C44
	public Texture2D LoadImage(string url, Texture2D placeholder = null)
	{
		return this.Load(url, placeholder).Texture;
	}

	// Token: 0x06001DA1 RID: 7585 RVA: 0x00093198 File Offset: 0x00091398
	public TextureLoader.Holder Load(string url, Texture2D placeholder = null)
	{
		if (string.IsNullOrEmpty(url))
		{
			return this.nullHolder;
		}
		TextureLoader.Holder holder = null;
		if (this.cache.TryGetValue(url, out holder))
		{
			return holder;
		}
		holder = new TextureLoader.Holder
		{
			Url = url,
			Texture = ((!(placeholder == null)) ? (UnityEngine.Object.Instantiate(placeholder) as Texture2D) : new Texture2D(1, 1, TextureFormat.RGB24, false))
		};
		this.cache[url] = holder;
		this.pending.Add(holder);
		return holder;
	}

	// Token: 0x06001DA2 RID: 7586 RVA: 0x00013A53 File Offset: 0x00011C53
	public TextureLoader.State GetState(string url)
	{
		return this.cache[url].State;
	}

	// Token: 0x06001DA3 RID: 7587 RVA: 0x00093224 File Offset: 0x00091424
	public TextureLoader.State GetState(Texture2D tex)
	{
		return new List<TextureLoader.Holder>(this.cache.Values).Find((TextureLoader.Holder el) => el.Texture == tex).State;
	}

	// Token: 0x040019D6 RID: 6614
	private readonly float TIMEOUT = 30f;

	// Token: 0x040019D7 RID: 6615
	public Dictionary<string, TextureLoader.Holder> cache = new Dictionary<string, TextureLoader.Holder>();

	// Token: 0x040019D8 RID: 6616
	public List<TextureLoader.Holder> pending = new List<TextureLoader.Holder>();

	// Token: 0x040019D9 RID: 6617
	private TextureLoader.Holder nullHolder = new TextureLoader.Holder
	{
		State = TextureLoader.State.Ok
	};

	// Token: 0x02000415 RID: 1045
	public enum State
	{
		// Token: 0x040019DB RID: 6619
		Downloading,
		// Token: 0x040019DC RID: 6620
		Ok,
		// Token: 0x040019DD RID: 6621
		Error,
		// Token: 0x040019DE RID: 6622
		Timeout
	}

	// Token: 0x02000416 RID: 1046
	public class Holder
	{
		// Token: 0x040019DF RID: 6623
		public string Url;

		// Token: 0x040019E0 RID: 6624
		public Texture2D Texture;

		// Token: 0x040019E1 RID: 6625
		public TextureLoader.State State;
	}
}
