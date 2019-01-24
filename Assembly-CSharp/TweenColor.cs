using System;
using UnityEngine;

// Token: 0x02000063 RID: 99
[AddComponentMenu("NGUI/Tween/Color")]
public class TweenColor : UITweener
{
	// Token: 0x17000057 RID: 87
	// (get) Token: 0x0600028A RID: 650 RVA: 0x000212D8 File Offset: 0x0001F4D8
	// (set) Token: 0x0600028B RID: 651 RVA: 0x00021344 File Offset: 0x0001F544
	public Color color
	{
		get
		{
			if (this.mWidget != null)
			{
				return this.mWidget.color;
			}
			if (this.mLight != null)
			{
				return this.mLight.color;
			}
			if (this.mMat != null)
			{
				return this.mMat.color;
			}
			return Color.black;
		}
		set
		{
			if (this.mWidget != null)
			{
				this.mWidget.color = value;
			}
			if (this.mMat != null)
			{
				this.mMat.color = value;
			}
			if (this.mLight != null)
			{
				this.mLight.color = value;
				this.mLight.enabled = (value.r + value.g + value.b > 0.01f);
			}
		}
	}

	// Token: 0x0600028C RID: 652 RVA: 0x000213D4 File Offset: 0x0001F5D4
	private void Awake()
	{
		this.mWidget = base.GetComponentInChildren<UIWidget>();
		Renderer renderer = base.renderer;
		if (renderer != null)
		{
			this.mMat = renderer.material;
		}
		this.mLight = base.light;
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00003E15 File Offset: 0x00002015
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.color = Color.Lerp(this.from, this.to, factor);
	}

	// Token: 0x0600028E RID: 654 RVA: 0x00021418 File Offset: 0x0001F618
	public static TweenColor Begin(GameObject go, float duration, Color color)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(go, duration);
		tweenColor.from = tweenColor.color;
		tweenColor.to = color;
		if (duration <= 0f)
		{
			tweenColor.Sample(1f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	// Token: 0x04000229 RID: 553
	public Color from = Color.white;

	// Token: 0x0400022A RID: 554
	public Color to = Color.white;

	// Token: 0x0400022B RID: 555
	private Transform mTrans;

	// Token: 0x0400022C RID: 556
	private UIWidget mWidget;

	// Token: 0x0400022D RID: 557
	private Material mMat;

	// Token: 0x0400022E RID: 558
	private Light mLight;
}
