using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x02000012 RID: 18
[AddComponentMenu("NGUI/Interaction/Button Play Animation")]
public class UIButtonPlayAnimation : MonoBehaviour
{
	// Token: 0x06000051 RID: 81 RVA: 0x00002558 File Offset: 0x00000758
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002561 File Offset: 0x00000761
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00016914 File Offset: 0x00014B14
	private void OnHover(bool isOver)
	{
		if (base.enabled)
		{
			if (this.trigger == Trigger.OnHover || (this.trigger == Trigger.OnHoverTrue && isOver) || (this.trigger == Trigger.OnHoverFalse && !isOver))
			{
				this.Play(isOver);
			}
			this.mHighlighted = isOver;
		}
	}

	// Token: 0x06000054 RID: 84 RVA: 0x0001696C File Offset: 0x00014B6C
	private void OnPress(bool isPressed)
	{
		if (base.enabled && (this.trigger == Trigger.OnPress || (this.trigger == Trigger.OnPressTrue && isPressed) || (this.trigger == Trigger.OnPressFalse && !isPressed)))
		{
			this.Play(isPressed);
		}
	}

	// Token: 0x06000055 RID: 85 RVA: 0x0000258A File Offset: 0x0000078A
	private void OnClick()
	{
		if (base.enabled && this.trigger == Trigger.OnClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06000056 RID: 86 RVA: 0x000025A9 File Offset: 0x000007A9
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == Trigger.OnDoubleClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06000057 RID: 87 RVA: 0x000169BC File Offset: 0x00014BBC
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (this.trigger == Trigger.OnSelect || (this.trigger == Trigger.OnSelectTrue && isSelected) || (this.trigger == Trigger.OnSelectFalse && !isSelected)))
		{
			this.Play(true);
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00016A10 File Offset: 0x00014C10
	private void OnActivate(bool isActive)
	{
		if (base.enabled && (this.trigger == Trigger.OnActivate || (this.trigger == Trigger.OnActivateTrue && isActive) || (this.trigger == Trigger.OnActivateFalse && !isActive)))
		{
			this.Play(isActive);
		}
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00016A60 File Offset: 0x00014C60
	private void Play(bool forward)
	{
		if (this.target == null)
		{
			this.target = base.GetComponentInChildren<Animation>();
		}
		if (this.target != null)
		{
			if (this.clearSelection && UICamera.selectedObject == base.gameObject)
			{
				UICamera.selectedObject = null;
			}
			int num = (int)(-(int)this.playDirection);
			Direction direction = (Direction)((!forward) ? num : ((int)this.playDirection));
			ActiveAnimation activeAnimation = ActiveAnimation.Play(this.target, this.clipName, direction, this.ifDisabledOnPlay, this.disableWhenFinished);
			if (activeAnimation == null)
			{
				return;
			}
			if (this.resetOnPlay)
			{
				activeAnimation.Reset();
			}
			activeAnimation.onFinished = this.onFinished;
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
			{
				activeAnimation.eventReceiver = this.eventReceiver;
				activeAnimation.callWhenFinished = this.callWhenFinished;
			}
			else
			{
				activeAnimation.eventReceiver = null;
			}
		}
	}

	// Token: 0x04000063 RID: 99
	public Animation target;

	// Token: 0x04000064 RID: 100
	public string clipName;

	// Token: 0x04000065 RID: 101
	public Trigger trigger;

	// Token: 0x04000066 RID: 102
	public Direction playDirection = Direction.Forward;

	// Token: 0x04000067 RID: 103
	public bool resetOnPlay;

	// Token: 0x04000068 RID: 104
	public bool clearSelection;

	// Token: 0x04000069 RID: 105
	public EnableCondition ifDisabledOnPlay;

	// Token: 0x0400006A RID: 106
	public DisableCondition disableWhenFinished;

	// Token: 0x0400006B RID: 107
	public GameObject eventReceiver;

	// Token: 0x0400006C RID: 108
	public string callWhenFinished;

	// Token: 0x0400006D RID: 109
	public ActiveAnimation.OnFinished onFinished;

	// Token: 0x0400006E RID: 110
	private bool mStarted;

	// Token: 0x0400006F RID: 111
	private bool mHighlighted;
}
