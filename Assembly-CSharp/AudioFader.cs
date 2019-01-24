using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200009E RID: 158
public class AudioFader : MonoBehaviour
{
	// Token: 0x06000437 RID: 1079 RVA: 0x0000518C File Offset: 0x0000338C
	private void OnEnable()
	{
		base.StartCoroutine(this.PlayAudio());
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0002D8CC File Offset: 0x0002BACC
	private IEnumerator PlayAudio()
	{
		for (;;)
		{
			yield return new WaitForEndOfFrame();
		}
		yield break;
	}

	// Token: 0x040003CA RID: 970
	public float PlayLength = 5f;

	// Token: 0x040003CB RID: 971
	public float SilentLength = 5f;

	// Token: 0x040003CC RID: 972
	public float FadeInLength = 1f;

	// Token: 0x040003CD RID: 973
	public float FadeOutLength = 1f;
}
