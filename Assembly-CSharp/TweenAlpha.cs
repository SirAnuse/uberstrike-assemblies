using System;
using UnityEngine;

// Token: 0x02000062 RID: 98
[AddComponentMenu("NGUI/Tween/Alpha")]
public class TweenAlpha : UITweener
{
	// Token: 0x17000056 RID: 86
	// (get) Token: 0x06000284 RID: 644 RVA: 0x000211F8 File Offset: 0x0001F3F8
	// (set) Token: 0x06000285 RID: 645 RVA: 0x00021244 File Offset: 0x0001F444
	public float alpha
	{
		get
		{
			if (this.mWidget != null)
			{
				return this.mWidget.alpha;
			}
			if (this.mPanel != null)
			{
				return this.mPanel.alpha;
			}
			return 0f;
		}
		set
		{
			if (this.mWidget != null)
			{
				this.mWidget.alpha = value;
			}
			else if (this.mPanel != null)
			{
				this.mPanel.alpha = value;
			}
		}
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00003DB2 File Offset: 0x00001FB2
	private void Awake()
	{
		this.mPanel = base.GetComponent<UIPanel>();
		if (this.mPanel == null)
		{
			this.mWidget = base.GetComponentInChildren<UIWidget>();
		}
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00003DDD File Offset: 0x00001FDD
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.alpha = Mathf.Lerp(this.from, this.to, factor);
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00021290 File Offset: 0x0001F490
	public static TweenAlpha Begin(GameObject go, float duration, float alpha)
	{
		TweenAlpha tweenAlpha = UITweener.Begin<TweenAlpha>(go, duration);
		tweenAlpha.from = tweenAlpha.alpha;
		tweenAlpha.to = alpha;
		if (duration <= 0f)
		{
			tweenAlpha.Sample(1f, true);
			tweenAlpha.enabled = false;
		}
		return tweenAlpha;
	}

	// Token: 0x04000224 RID: 548
	public float from = 1f;

	// Token: 0x04000225 RID: 549
	public float to = 1f;

	// Token: 0x04000226 RID: 550
	private Transform mTrans;

	// Token: 0x04000227 RID: 551
	private UIWidget mWidget;

	// Token: 0x04000228 RID: 552
	private UIPanel mPanel;
}
