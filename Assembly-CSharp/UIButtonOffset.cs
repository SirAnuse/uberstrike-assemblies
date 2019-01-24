using System;
using UnityEngine;

// Token: 0x02000011 RID: 17
[AddComponentMenu("NGUI/Interaction/Button Offset")]
public class UIButtonOffset : MonoBehaviour
{
	// Token: 0x0600004B RID: 75 RVA: 0x00016770 File Offset: 0x00014970
	private void Start()
	{
		if (!this.mStarted)
		{
			this.mStarted = true;
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.transform;
			}
			this.mPos = this.tweenTarget.localPosition;
		}
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00002520 File Offset: 0x00000720
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x000167C0 File Offset: 0x000149C0
	private void OnDisable()
	{
		if (this.mStarted && this.tweenTarget != null)
		{
			TweenPosition component = this.tweenTarget.GetComponent<TweenPosition>();
			if (component != null)
			{
				component.position = this.mPos;
				component.enabled = false;
			}
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00016814 File Offset: 0x00014A14
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, (!isPressed) ? ((!UICamera.IsHighlighted(base.gameObject)) ? this.mPos : (this.mPos + this.hover)) : (this.mPos + this.pressed)).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x0600004F RID: 79 RVA: 0x000168A4 File Offset: 0x00014AA4
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenPosition.Begin(this.tweenTarget.gameObject, this.duration, (!isOver) ? this.mPos : (this.mPos + this.hover)).method = UITweener.Method.EaseInOut;
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x0400005C RID: 92
	public Transform tweenTarget;

	// Token: 0x0400005D RID: 93
	public Vector3 hover = Vector3.zero;

	// Token: 0x0400005E RID: 94
	public Vector3 pressed = new Vector3(2f, -2f);

	// Token: 0x0400005F RID: 95
	public float duration = 0.2f;

	// Token: 0x04000060 RID: 96
	private Vector3 mPos;

	// Token: 0x04000061 RID: 97
	private bool mStarted;

	// Token: 0x04000062 RID: 98
	private bool mHighlighted;
}
