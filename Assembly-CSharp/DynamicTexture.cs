using System;
using UnityEngine;

// Token: 0x0200015C RID: 348
public class DynamicTexture
{
	// Token: 0x0600093F RID: 2367 RVA: 0x00007C68 File Offset: 0x00005E68
	public DynamicTexture(string url, bool loadNow = false)
	{
		this.url = url;
		if (loadNow)
		{
			this.holder = AutoMonoBehaviour<TextureLoader>.Instance.Load(url, null);
		}
	}

	// Token: 0x17000298 RID: 664
	// (get) Token: 0x06000940 RID: 2368 RVA: 0x00007C8F File Offset: 0x00005E8F
	public float Aspect
	{
		get
		{
			return (this.holder == null) ? 1f : ((float)this.holder.Texture.height / (float)this.holder.Texture.width);
		}
	}

	// Token: 0x17000299 RID: 665
	// (get) Token: 0x06000941 RID: 2369 RVA: 0x00007CC9 File Offset: 0x00005EC9
	public string Url
	{
		get
		{
			return this.url;
		}
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x0003AB20 File Offset: 0x00038D20
	public void Draw(Rect rect, bool forceAlpha = false)
	{
		if (this.holder == null)
		{
			this.holder = AutoMonoBehaviour<TextureLoader>.Instance.Load(this.url, null);
		}
		if (this.holder.State == TextureLoader.State.Ok)
		{
			if (forceAlpha)
			{
				GUI.DrawTexture(rect, this.holder.Texture);
			}
			else
			{
				Color color = GUI.color;
				this.alpha = Mathf.Lerp(this.alpha, 1f, Time.deltaTime);
				GUI.color = new Color(1f, 1f, 1f, (!GUI.enabled) ? Mathf.Min(this.alpha, 0.5f) : this.alpha);
				GUI.DrawTexture(rect, this.holder.Texture);
				GUI.color = color;
			}
		}
		else if (this.holder.State == TextureLoader.State.Downloading)
		{
			WaitingTexture.Draw(rect.center, 0);
		}
		else
		{
			GUI.Label(rect, "N/A", BlueStonez.label_interparkbold_13pt);
		}
	}

	// Token: 0x0400097A RID: 2426
	private float alpha;

	// Token: 0x0400097B RID: 2427
	private string url;

	// Token: 0x0400097C RID: 2428
	private TextureLoader.Holder holder;
}
