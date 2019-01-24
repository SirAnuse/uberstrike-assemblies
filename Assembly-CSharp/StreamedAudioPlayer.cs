using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000A8 RID: 168
public class StreamedAudioPlayer : AutoMonoBehaviour<StreamedAudioPlayer>
{
	// Token: 0x06000466 RID: 1126 RVA: 0x0000533D File Offset: 0x0000353D
	public void PlayMusic(AudioSource source, string clipName)
	{
		if (!string.IsNullOrEmpty(clipName))
		{
			base.StartCoroutine(this.PlayMusic(source, Singleton<AudioLoader>.Instance.Get(clipName)));
		}
		else
		{
			this.StopMusic(source);
		}
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x0000536F File Offset: 0x0000356F
	public void StopMusic(AudioSource source)
	{
		StreamedAudioPlayer._playCounter++;
		source.Stop();
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x0002DE38 File Offset: 0x0002C038
	private IEnumerator PlayMusic(AudioSource source, AudioClip clip)
	{
		int id = ++StreamedAudioPlayer._playCounter;
		bool isStreamed = !clip || !clip.isReadyToPlay;
		while (clip && !clip.isReadyToPlay)
		{
			yield return new WaitForEndOfFrame();
		}
		if (isStreamed)
		{
			yield return new WaitForSeconds(1f);
		}
		if (clip != null)
		{
			source.clip = clip;
			source.Play();
		}
		while (id == StreamedAudioPlayer._playCounter)
		{
			while (source.isPlaying && id == StreamedAudioPlayer._playCounter)
			{
				yield return new WaitForEndOfFrame();
			}
			if (id == StreamedAudioPlayer._playCounter)
			{
				source.Play();
				yield return new WaitForEndOfFrame();
			}
			else
			{
				source.Stop();
			}
		}
		yield break;
	}

	// Token: 0x040003E4 RID: 996
	private static int _playCounter;
}
