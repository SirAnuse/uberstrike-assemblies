using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000A0 RID: 160
public class AudioIntervalPlayer : MonoBehaviour
{
	// Token: 0x06000440 RID: 1088 RVA: 0x0002D934 File Offset: 0x0002BB34
	private IEnumerator Start()
	{
		base.audio.loop = false;
		for (;;)
		{
			base.audio.Play();
			if (this.waitForClipLength && base.audio.clip != null)
			{
				yield return new WaitForSeconds(base.audio.clip.length);
			}
			yield return new WaitForSeconds(this.waitTime);
		}
		yield break;
	}

	// Token: 0x040003D0 RID: 976
	[SerializeField]
	private float waitTime = 30f;

	// Token: 0x040003D1 RID: 977
	[SerializeField]
	private bool waitForClipLength;
}
