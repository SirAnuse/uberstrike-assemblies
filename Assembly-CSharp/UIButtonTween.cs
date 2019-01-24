using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x02000017 RID: 23
[AddComponentMenu("NGUI/Interaction/Button Tween")]
public class UIButtonTween : MonoBehaviour
{
	// Token: 0x0600006B RID: 107 RVA: 0x000026A2 File Offset: 0x000008A2
	private void Start()
	{
		this.mStarted = true;
		if (this.tweenTarget == null)
		{
			this.tweenTarget = base.gameObject;
		}
	}

	// Token: 0x0600006C RID: 108 RVA: 0x000026C8 File Offset: 0x000008C8
	private void OnEnable()
	{
		if (this.mStarted && this.mHighlighted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00016FBC File Offset: 0x000151BC
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

	// Token: 0x0600006E RID: 110 RVA: 0x00017014 File Offset: 0x00015214
	private void OnPress(bool isPressed)
	{
		if (base.enabled && (this.trigger == Trigger.OnPress || (this.trigger == Trigger.OnPressTrue && isPressed) || (this.trigger == Trigger.OnPressFalse && !isPressed)))
		{
			this.Play(isPressed);
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x000026F1 File Offset: 0x000008F1
	private void OnClick()
	{
		if (base.enabled && this.trigger == Trigger.OnClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00002710 File Offset: 0x00000910
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == Trigger.OnDoubleClick)
		{
			this.Play(true);
		}
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00017064 File Offset: 0x00015264
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (this.trigger == Trigger.OnSelect || (this.trigger == Trigger.OnSelectTrue && isSelected) || (this.trigger == Trigger.OnSelectFalse && !isSelected)))
		{
			this.Play(true);
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x000170B8 File Offset: 0x000152B8
	private void OnActivate(bool isActive)
	{
		if (base.enabled && (this.trigger == Trigger.OnActivate || (this.trigger == Trigger.OnActivateTrue && isActive) || (this.trigger == Trigger.OnActivateFalse && !isActive)))
		{
			this.Play(isActive);
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00017108 File Offset: 0x00015308
	private void Update()
	{
		if (this.disableWhenFinished != DisableCondition.DoNotDisable && this.mTweens != null)
		{
			bool flag = true;
			bool flag2 = true;
			int i = 0;
			int num = this.mTweens.Length;
			while (i < num)
			{
				UITweener uitweener = this.mTweens[i];
				if (uitweener.tweenGroup == this.tweenGroup)
				{
					if (uitweener.enabled)
					{
						flag = false;
						break;
					}
					if (uitweener.direction != (Direction)this.disableWhenFinished)
					{
						flag2 = false;
					}
				}
				i++;
			}
			if (flag)
			{
				if (flag2)
				{
					NGUITools.SetActive(this.tweenTarget, false);
				}
				this.mTweens = null;
			}
		}
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000171B4 File Offset: 0x000153B4
	public void Play(bool forward)
	{
		GameObject gameObject = (!(this.tweenTarget == null)) ? this.tweenTarget : base.gameObject;
		if (!NGUITools.GetActive(gameObject))
		{
			if (this.ifDisabledOnPlay != EnableCondition.EnableThenPlay)
			{
				return;
			}
			NGUITools.SetActive(gameObject, true);
		}
		this.mTweens = ((!this.includeChildren) ? gameObject.GetComponents<UITweener>() : gameObject.GetComponentsInChildren<UITweener>());
		if (this.mTweens.Length == 0)
		{
			if (this.disableWhenFinished != DisableCondition.DoNotDisable)
			{
				NGUITools.SetActive(this.tweenTarget, false);
			}
		}
		else
		{
			bool flag = false;
			if (this.playDirection == Direction.Reverse)
			{
				forward = !forward;
			}
			int i = 0;
			int num = this.mTweens.Length;
			while (i < num)
			{
				UITweener uitweener = this.mTweens[i];
				if (uitweener.tweenGroup == this.tweenGroup)
				{
					if (!flag && !NGUITools.GetActive(gameObject))
					{
						flag = true;
						NGUITools.SetActive(gameObject, true);
					}
					if (this.playDirection == Direction.Toggle)
					{
						uitweener.Toggle();
					}
					else
					{
						uitweener.Play(forward);
					}
					if (this.resetOnPlay)
					{
						uitweener.Reset();
					}
					uitweener.onFinished = this.onFinished;
					if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
					{
						uitweener.eventReceiver = this.eventReceiver;
						uitweener.callWhenFinished = this.callWhenFinished;
					}
				}
				i++;
			}
		}
	}

	// Token: 0x04000088 RID: 136
	public GameObject tweenTarget;

	// Token: 0x04000089 RID: 137
	public int tweenGroup;

	// Token: 0x0400008A RID: 138
	public Trigger trigger;

	// Token: 0x0400008B RID: 139
	public Direction playDirection = Direction.Forward;

	// Token: 0x0400008C RID: 140
	public bool resetOnPlay;

	// Token: 0x0400008D RID: 141
	public EnableCondition ifDisabledOnPlay;

	// Token: 0x0400008E RID: 142
	public DisableCondition disableWhenFinished;

	// Token: 0x0400008F RID: 143
	public bool includeChildren;

	// Token: 0x04000090 RID: 144
	public GameObject eventReceiver;

	// Token: 0x04000091 RID: 145
	public string callWhenFinished;

	// Token: 0x04000092 RID: 146
	public UITweener.OnFinished onFinished;

	// Token: 0x04000093 RID: 147
	private UITweener[] mTweens;

	// Token: 0x04000094 RID: 148
	private bool mStarted;

	// Token: 0x04000095 RID: 149
	private bool mHighlighted;
}
