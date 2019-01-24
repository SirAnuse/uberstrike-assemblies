using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000A4 RID: 164
public class MusicFader
{
	// Token: 0x06000452 RID: 1106 RVA: 0x000052A5 File Offset: 0x000034A5
	public MusicFader(AudioSource audio)
	{
		this._audioSource = audio;
	}

	// Token: 0x170000D1 RID: 209
	// (get) Token: 0x06000453 RID: 1107 RVA: 0x000052B4 File Offset: 0x000034B4
	public AudioSource Source
	{
		get
		{
			return this._audioSource;
		}
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x000052BC File Offset: 0x000034BC
	public void FadeIn(float volume)
	{
		this._targetVolume = volume;
		if (!this._isFading)
		{
			if (!this._audioSource.isPlaying)
			{
				this._audioSource.Play();
			}
			UnityRuntime.StartRoutine(this.StartFading());
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x000052F7 File Offset: 0x000034F7
	public void FadeOut()
	{
		this._targetVolume = 0f;
		if (!this._isFading)
		{
			UnityRuntime.StartRoutine(this.StartFading());
		}
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0002DB90 File Offset: 0x0002BD90
	private IEnumerator StartFading()
	{
		this._isFading = true;
		while (Mathf.Abs(this._audioSource.volume - this._targetVolume) > 0.05f)
		{
			this._audioSource.volume = Mathf.Lerp(this._audioSource.volume, this._targetVolume, Time.deltaTime * 3f);
			yield return new WaitForEndOfFrame();
		}
		if (this._targetVolume == 0f)
		{
			this._audioSource.volume = 0f;
			this._audioSource.Stop();
		}
		this._isFading = false;
		yield break;
	}

	// Token: 0x040003DC RID: 988
	private bool _isFading;

	// Token: 0x040003DD RID: 989
	private float _targetVolume;

	// Token: 0x040003DE RID: 990
	private AudioSource _audioSource;
}
