using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
[Serializable]
public class SoundEffect
{
	// Token: 0x060015C4 RID: 5572 RVA: 0x0000E98B File Offset: 0x0000CB8B
	public SoundEffect(AudioClip clip, float volume = 1f, float pitch = 1f)
	{
		this.Clip = clip;
		this.Volume = volume;
		this.Pitch = pitch;
	}

	// Token: 0x0400148A RID: 5258
	public AudioClip Clip;

	// Token: 0x0400148B RID: 5259
	public float Volume = 1f;

	// Token: 0x0400148C RID: 5260
	public float Pitch = 1f;
}
