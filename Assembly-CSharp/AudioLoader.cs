using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003BA RID: 954
public class AudioLoader : Singleton<AudioLoader>
{
	// Token: 0x06001BF9 RID: 7161 RVA: 0x00012966 File Offset: 0x00010B66
	private AudioLoader()
	{
		this.cachedAudioClips = new Dictionary<string, AudioClip>();
	}

	// Token: 0x17000635 RID: 1589
	// (get) Token: 0x06001BFA RID: 7162 RVA: 0x00012979 File Offset: 0x00010B79
	public IEnumerable<KeyValuePair<string, AudioClip>> AllClips
	{
		get
		{
			return this.cachedAudioClips;
		}
	}

	// Token: 0x06001BFB RID: 7163 RVA: 0x00012981 File Offset: 0x00010B81
	public AudioClip Get(string name)
	{
		if (!this.cachedAudioClips.ContainsKey(name))
		{
			Debug.LogWarning("AudioClip was not found : " + name);
		}
		return this.cachedAudioClips[name];
	}

	// Token: 0x040018FA RID: 6394
	private Dictionary<string, AudioClip> cachedAudioClips;
}
