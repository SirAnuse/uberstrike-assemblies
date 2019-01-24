using System;
using UnityEngine;

// Token: 0x020000A3 RID: 163
public class BackgroundMusicPlayer : AutoMonoBehaviour<BackgroundMusicPlayer>
{
	// Token: 0x0600044D RID: 1101 RVA: 0x0002DAB4 File Offset: 0x0002BCB4
	private void Awake()
	{
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.volume = 0f;
		audioSource.loop = true;
		AudioSource audioSource2 = base.gameObject.AddComponent<AudioSource>();
		audioSource2.volume = 0f;
		audioSource2.loop = true;
		this.musicFaderA = new MusicFader(audioSource);
		this.musicFaderB = new MusicFader(audioSource2);
	}

	// Token: 0x170000CF RID: 207
	// (set) Token: 0x0600044E RID: 1102 RVA: 0x00005267 File Offset: 0x00003467
	public float Volume
	{
		set
		{
			this.Current.Source.volume = value;
		}
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x0002DB18 File Offset: 0x0002BD18
	public void Play(AudioClip clip)
	{
		if (this.Current.Source.clip != clip)
		{
			this.Current.FadeOut();
			this.toggle = !this.toggle;
			this.Current.Source.clip = clip;
			this.Current.FadeIn(SfxManager.MusicAudioVolume);
		}
		else
		{
			this.Current.FadeIn(SfxManager.MusicAudioVolume);
		}
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0000527A File Offset: 0x0000347A
	public void Stop()
	{
		this.Current.FadeOut();
	}

	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x06000451 RID: 1105 RVA: 0x00005287 File Offset: 0x00003487
	private MusicFader Current
	{
		get
		{
			return (!this.toggle) ? this.musicFaderB : this.musicFaderA;
		}
	}

	// Token: 0x040003D9 RID: 985
	private MusicFader musicFaderA;

	// Token: 0x040003DA RID: 986
	private MusicFader musicFaderB;

	// Token: 0x040003DB RID: 987
	private bool toggle;
}
