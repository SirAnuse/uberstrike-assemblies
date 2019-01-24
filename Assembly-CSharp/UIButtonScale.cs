using System;
using UnityEngine;

// Token: 0x02000014 RID: 20
[AddComponentMenu("NGUI/Interaction/Button Scale")]
public class UIButtonScale : MonoBehaviour
{
	// Token: 0x06000061 RID: 97 RVA: 0x00016D70 File Offset: 0x00014F70
	private void Start()
	{
		if (!this.mStarted)
		{
			this.mStarted = true;
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.transform;
			}
			this.mScale = this.tweenTarget.localScale;
		}
	}

	// Token: 0x06000062 RID: 98 RVA: 0x0000261C File Offset: 0x0000081C
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00016DC0 File Offset: 0x00014FC0
	private void OnDisable()
	{
		if (this.mStarted && this.tweenTarget != null)
		{
			TweenScale component = this.tweenTarget.GetComponent<TweenScale>();
			if (component != null)
			{
				component.scale = this.mScale;
				component.enabled = false;
			}
		}
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00016E14 File Offset: 0x00015014
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenScale.Begin(this.tweenTarget.gameObject, this.duration, (!isPressed) ? ((!UICamera.IsHighlighted(base.gameObject)) ? this.mScale : Vector3.Scale(this.mScale, this.hover)) : Vector3.Scale(this.mScale, this.pressed)).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00016EA4 File Offset: 0x000150A4
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenScale.Begin(this.tweenTarget.gameObject, this.duration, (!isOver) ? this.mScale : Vector3.Scale(this.mScale, this.hover)).method = UITweener.Method.EaseInOut;
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x04000077 RID: 119
	public Transform tweenTarget;

	// Token: 0x04000078 RID: 120
	public Vector3 hover = new Vector3(1.1f, 1.1f, 1.1f);

	// Token: 0x04000079 RID: 121
	public Vector3 pressed = new Vector3(1.05f, 1.05f, 1.05f);

	// Token: 0x0400007A RID: 122
	public float duration = 0.2f;

	// Token: 0x0400007B RID: 123
	private Vector3 mScale;

	// Token: 0x0400007C RID: 124
	private bool mStarted;

	// Token: 0x0400007D RID: 125
	private bool mHighlighted;
}
