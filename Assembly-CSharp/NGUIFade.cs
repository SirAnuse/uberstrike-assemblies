using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000352 RID: 850
public class NGUIFade : MonoBehaviour
{
	// Token: 0x060017A4 RID: 6052 RVA: 0x0000FE44 File Offset: 0x0000E044
	public static void FadeIn(Action onFinished = null, bool immediate = false)
	{
		NGUIFade.Fade(1f, onFinished, immediate);
	}

	// Token: 0x060017A5 RID: 6053 RVA: 0x0000FE52 File Offset: 0x0000E052
	public static void FadeOut(Action onFinished = null, bool immediate = false)
	{
		NGUIFade.Fade(0f, onFinished, immediate);
	}

	// Token: 0x060017A6 RID: 6054 RVA: 0x00080770 File Offset: 0x0007E970
	public static void Fade(float targetAlpha, Action onFinished = null, bool immediate = false)
	{
		if (NGUIFade.instance == null)
		{
			UICamera.eventHandler.gameObject.AddComponent<NGUIFade>();
		}
		NGUIFade.instance.StopAllCoroutines();
		NGUIFade.instance.StartCoroutine(NGUIFade.instance.Animate(immediate, targetAlpha, onFinished));
	}

	// Token: 0x060017A7 RID: 6055 RVA: 0x0000FE60 File Offset: 0x0000E060
	private void Awake()
	{
		NGUIFade.instance = this;
	}

	// Token: 0x060017A8 RID: 6056 RVA: 0x0000FE68 File Offset: 0x0000E068
	private void OnDestroy()
	{
		NGUIFade.instance = null;
	}

	// Token: 0x060017A9 RID: 6057 RVA: 0x000807C0 File Offset: 0x0007E9C0
	private IEnumerator Animate(bool immediate, float targetAlpha, Action onFinished)
	{
		UICamera uiCamera = null;
		Transform tr = base.transform;
		while (uiCamera == null && tr != null)
		{
			uiCamera = tr.GetComponent<UICamera>();
			tr = tr.parent;
		}
		uiCamera.enabled = false;
		if (this.sprite != null)
		{
			if (this.sprite.alpha == 1f && base.transform.localScale == Vector3.one)
			{
				this.sprite.alpha = 0f;
			}
			base.transform.localScale = new Vector3(10000f, 10000f, 1f);
			if (!immediate)
			{
				while (this.sprite.alpha != targetAlpha)
				{
					this.sprite.alpha = Mathf.MoveTowards(this.sprite.alpha, targetAlpha, Time.deltaTime * this.fadeSpeed);
					yield return 0;
				}
			}
			else
			{
				this.sprite.alpha = targetAlpha;
			}
			if (targetAlpha == 0f)
			{
				base.transform.localScale = Vector3.one;
			}
		}
		uiCamera.enabled = (targetAlpha == 1f);
		if (onFinished != null)
		{
			onFinished();
		}
		yield break;
	}

	// Token: 0x04001682 RID: 5762
	[SerializeField]
	private UISprite sprite;

	// Token: 0x04001683 RID: 5763
	[SerializeField]
	private float fadeSpeed = 1f;

	// Token: 0x04001684 RID: 5764
	private static NGUIFade instance;
}
