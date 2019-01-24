using System;
using UnityEngine;

// Token: 0x02000013 RID: 19
[AddComponentMenu("NGUI/Interaction/Button Rotation")]
public class UIButtonRotation : MonoBehaviour
{
	// Token: 0x0600005B RID: 91 RVA: 0x00016B6C File Offset: 0x00014D6C
	private void Start()
	{
		if (!this.mStarted)
		{
			this.mStarted = true;
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.transform;
			}
			this.mRot = this.tweenTarget.localRotation;
		}
	}

	// Token: 0x0600005C RID: 92 RVA: 0x000025F3 File Offset: 0x000007F3
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00016BBC File Offset: 0x00014DBC
	private void OnDisable()
	{
		if (this.mStarted && this.tweenTarget != null)
		{
			TweenRotation component = this.tweenTarget.GetComponent<TweenRotation>();
			if (component != null)
			{
				component.rotation = this.mRot;
				component.enabled = false;
			}
		}
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00016C10 File Offset: 0x00014E10
	private void OnPress(bool isPressed)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenRotation.Begin(this.tweenTarget.gameObject, this.duration, (!isPressed) ? ((!UICamera.IsHighlighted(base.gameObject)) ? this.mRot : (this.mRot * Quaternion.Euler(this.hover))) : (this.mRot * Quaternion.Euler(this.pressed))).method = UITweener.Method.EaseInOut;
		}
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00016CA8 File Offset: 0x00014EA8
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (!this.mStarted)
			{
				this.Start();
			}
			TweenRotation.Begin(this.tweenTarget.gameObject, this.duration, (!isOver) ? this.mRot : (this.mRot * Quaternion.Euler(this.hover))).method = UITweener.Method.EaseInOut;
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x04000070 RID: 112
	public Transform tweenTarget;

	// Token: 0x04000071 RID: 113
	public Vector3 hover = Vector3.zero;

	// Token: 0x04000072 RID: 114
	public Vector3 pressed = Vector3.zero;

	// Token: 0x04000073 RID: 115
	public float duration = 0.2f;

	// Token: 0x04000074 RID: 116
	private Quaternion mRot;

	// Token: 0x04000075 RID: 117
	private bool mStarted;

	// Token: 0x04000076 RID: 118
	private bool mHighlighted;
}
