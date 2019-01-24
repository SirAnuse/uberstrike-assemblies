using System;
using UnityEngine;

// Token: 0x020003A2 RID: 930
[RequireComponent(typeof(AudioSource))]
internal class StreamedAudio : MonoBehaviour
{
	// Token: 0x06001B74 RID: 7028 RVA: 0x000122D6 File Offset: 0x000104D6
	private void OnEnable()
	{
		AutoMonoBehaviour<StreamedAudioPlayer>.Instance.PlayMusic(base.audio, this._clipName);
	}

	// Token: 0x06001B75 RID: 7029 RVA: 0x000122EE File Offset: 0x000104EE
	private void OnDisable()
	{
		AutoMonoBehaviour<StreamedAudioPlayer>.Instance.StopMusic(base.audio);
	}

	// Token: 0x0400187B RID: 6267
	[SerializeField]
	private string _clipName;
}
