using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200004A RID: 74
[AddComponentMenu("NGUI/Internal/Localization")]
public class Localization : MonoBehaviour
{
	// Token: 0x17000035 RID: 53
	// (get) Token: 0x06000196 RID: 406 RVA: 0x000033A5 File Offset: 0x000015A5
	public static bool isActive
	{
		get
		{
			return Localization.mInstance != null;
		}
	}

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x06000197 RID: 407 RVA: 0x0001D43C File Offset: 0x0001B63C
	public static Localization instance
	{
		get
		{
			if (Localization.mInstance == null)
			{
				Localization.mInstance = (UnityEngine.Object.FindObjectOfType(typeof(Localization)) as Localization);
				if (Localization.mInstance == null)
				{
					GameObject gameObject = new GameObject("_Localization");
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
					Localization.mInstance = gameObject.AddComponent<Localization>();
				}
			}
			return Localization.mInstance;
		}
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x06000198 RID: 408 RVA: 0x000033B2 File Offset: 0x000015B2
	// (set) Token: 0x06000199 RID: 409 RVA: 0x0001D4A4 File Offset: 0x0001B6A4
	public string currentLanguage
	{
		get
		{
			return this.mLanguage;
		}
		set
		{
			if (this.mLanguage != value)
			{
				this.startingLanguage = value;
				if (!string.IsNullOrEmpty(value))
				{
					if (this.languages != null)
					{
						int i = 0;
						int num = this.languages.Length;
						while (i < num)
						{
							TextAsset textAsset = this.languages[i];
							if (textAsset != null && textAsset.name == value)
							{
								this.Load(textAsset);
								return;
							}
							i++;
						}
					}
					TextAsset textAsset2 = Resources.Load(value, typeof(TextAsset)) as TextAsset;
					if (textAsset2 != null)
					{
						this.Load(textAsset2);
						return;
					}
				}
				this.mDictionary.Clear();
				PlayerPrefs.DeleteKey("Language");
			}
		}
	}

	// Token: 0x0600019A RID: 410 RVA: 0x0001D568 File Offset: 0x0001B768
	private void Awake()
	{
		if (Localization.mInstance == null)
		{
			Localization.mInstance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			this.currentLanguage = PlayerPrefs.GetString("Language", this.startingLanguage);
			if (string.IsNullOrEmpty(this.mLanguage) && this.languages != null && this.languages.Length > 0)
			{
				this.currentLanguage = this.languages[0].name;
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600019B RID: 411 RVA: 0x000033BA File Offset: 0x000015BA
	private void OnEnable()
	{
		if (Localization.mInstance == null)
		{
			Localization.mInstance = this;
		}
	}

	// Token: 0x0600019C RID: 412 RVA: 0x000033D2 File Offset: 0x000015D2
	private void OnDestroy()
	{
		if (Localization.mInstance == this)
		{
			Localization.mInstance = null;
		}
	}

	// Token: 0x0600019D RID: 413 RVA: 0x0001D5F8 File Offset: 0x0001B7F8
	private void Load(TextAsset asset)
	{
		this.mLanguage = asset.name;
		PlayerPrefs.SetString("Language", this.mLanguage);
		ByteReader byteReader = new ByteReader(asset);
		this.mDictionary = byteReader.ReadDictionary();
		UIRoot.Broadcast("OnLocalize", this);
	}

	// Token: 0x0600019E RID: 414 RVA: 0x0001D640 File Offset: 0x0001B840
	public string Get(string key)
	{
		string text;
		return (!this.mDictionary.TryGetValue(key, out text)) ? key : text;
	}

	// Token: 0x0600019F RID: 415 RVA: 0x000033EA File Offset: 0x000015EA
	public static string Localize(string key)
	{
		return (!(Localization.instance != null)) ? key : Localization.instance.Get(key);
	}

	// Token: 0x040001BB RID: 443
	private static Localization mInstance;

	// Token: 0x040001BC RID: 444
	public string startingLanguage = "English";

	// Token: 0x040001BD RID: 445
	public TextAsset[] languages;

	// Token: 0x040001BE RID: 446
	private Dictionary<string, string> mDictionary = new Dictionary<string, string>();

	// Token: 0x040001BF RID: 447
	private string mLanguage;
}
