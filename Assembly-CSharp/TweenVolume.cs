using System;
using UnityEngine;

// Token: 0x0200006A RID: 106
[AddComponentMenu("NGUI/Tween/Volume")]
public class TweenVolume : UITweener
{
	// Token: 0x17000062 RID: 98
	// (get) Token: 0x060002B2 RID: 690 RVA: 0x00021874 File Offset: 0x0001FA74
	public AudioSource audioSource
	{
		get
		{
			if (this.mSource == null)
			{
				this.mSource = base.audio;
				if (this.mSource == null)
				{
					this.mSource = base.GetComponentInChildren<AudioSource>();
					if (this.mSource == null)
					{
						Debug.LogError("TweenVolume needs an AudioSource to work with", this);
						base.enabled = false;
					}
				}
			}
			return this.mSource;
		}
	}

	// Token: 0x17000063 RID: 99
	// (get) Token: 0x060002B3 RID: 691 RVA: 0x00004054 File Offset: 0x00002254
	// (set) Token: 0x060002B4 RID: 692 RVA: 0x00004061 File Offset: 0x00002261
	public float volume
	{
		get
		{
			return this.audioSource.volume;
		}
		set
		{
			this.audioSource.volume = value;
		}
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x0000406F File Offset: 0x0000226F
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.volume = this.from * (1f - factor) + this.to * factor;
		this.mSource.enabled = (this.mSource.volume > 0.01f);
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x000218E4 File Offset: 0x0001FAE4
	public static TweenVolume Begin(GameObject go, float duration, float targetVolume)
	{
		TweenVolume tweenVolume = UITweener.Begin<TweenVolume>(go, duration);
		tweenVolume.from = tweenVolume.volume;
		tweenVolume.to = targetVolume;
		if (duration <= 0f)
		{
			tweenVolume.Sample(1f, true);
			tweenVolume.enabled = false;
		}
		return tweenVolume;
	}

	// Token: 0x04000247 RID: 583
	public float from;

	// Token: 0x04000248 RID: 584
	public float to = 1f;

	// Token: 0x04000249 RID: 585
	private AudioSource mSource;
}
