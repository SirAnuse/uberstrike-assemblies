using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000347 RID: 839
public class GUIPageBase : MonoBehaviour
{
	// Token: 0x06001760 RID: 5984 RVA: 0x0007FF48 File Offset: 0x0007E148
	public IEnumerator AnimateAlpha(float to, float duration, params UIButton[] buttons)
	{
		yield return base.StartCoroutine(this.AnimateAlpha(to, duration, Array.ConvertAll<UIButton, UIPanel>(buttons, (UIButton el) => el.GetComponent<UIPanel>())));
		yield break;
	}

	// Token: 0x06001761 RID: 5985 RVA: 0x0007FF90 File Offset: 0x0007E190
	public IEnumerator AnimateAlpha(float to, float duration, params UIEventReceiver[] buttons)
	{
		yield return base.StartCoroutine(this.AnimateAlpha(to, duration, Array.ConvertAll<UIEventReceiver, UIPanel>(buttons, (UIEventReceiver el) => el.GetComponent<UIPanel>())));
		yield break;
	}

	// Token: 0x06001762 RID: 5986 RVA: 0x0007FFD8 File Offset: 0x0007E1D8
	public IEnumerator AnimateAlpha(float to, float duration, params GameObject[] objects)
	{
		yield return base.StartCoroutine(this.AnimateAlpha(to, duration, Array.ConvertAll<GameObject, UIPanel>(objects, (GameObject el) => el.GetComponent<UIPanel>())));
		yield break;
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x00080020 File Offset: 0x0007E220
	public IEnumerator AnimateAlpha(float to, float duration, params UIPanel[] buttons)
	{
		TweenAlpha[] tweens = Array.ConvertAll<UIPanel, TweenAlpha>(buttons, (UIPanel el) => TweenAlpha.Begin(el.gameObject, duration, to));
		foreach (TweenAlpha el2 in tweens)
		{
			while (el2.enabled)
			{
				yield return 0;
			}
		}
		yield break;
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x0000FD28 File Offset: 0x0000DF28
	public void Dismiss(Action onFinished)
	{
		base.StopAllCoroutines();
		base.StartCoroutine(this.DismissCrt(onFinished));
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x00080060 File Offset: 0x0007E260
	private IEnumerator DismissCrt(Action onFinished)
	{
		yield return base.StartCoroutine(this.OnDismiss());
		if (onFinished != null)
		{
			onFinished();
		}
		yield break;
	}

	// Token: 0x06001766 RID: 5990 RVA: 0x0008008C File Offset: 0x0007E28C
	protected virtual IEnumerator OnDismiss()
	{
		yield return 0;
		yield break;
	}

	// Token: 0x06001767 RID: 5991 RVA: 0x0000FD3E File Offset: 0x0000DF3E
	public void BringIn()
	{
		base.StopAllCoroutines();
		base.StartCoroutine(this.OnBringIn());
	}

	// Token: 0x06001768 RID: 5992 RVA: 0x000800A0 File Offset: 0x0007E2A0
	protected virtual IEnumerator OnBringIn()
	{
		yield return 0;
		yield break;
	}

	// Token: 0x0400163B RID: 5691
	[SerializeField]
	public float dismissDuration = 0.2f;

	// Token: 0x0400163C RID: 5692
	[SerializeField]
	public float bringInDuration = 0.8f;
}
