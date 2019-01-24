﻿using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x0200003D RID: 61
[AddComponentMenu("NGUI/Internal/Active Animation")]
[RequireComponent(typeof(Animation))]
public class ActiveAnimation : IgnoreTimeScale
{
	// Token: 0x17000020 RID: 32
	// (get) Token: 0x0600014A RID: 330 RVA: 0x0001C394 File Offset: 0x0001A594
	public bool isPlaying
	{
		get
		{
			if (this.mAnim == null)
			{
				return false;
			}
			foreach (object obj in this.mAnim)
			{
				AnimationState animationState = (AnimationState)obj;
				if (this.mAnim.IsPlaying(animationState.name))
				{
					if (this.mLastDirection == Direction.Forward)
					{
						if (animationState.time < animationState.length)
						{
							return true;
						}
					}
					else
					{
						if (this.mLastDirection != Direction.Reverse)
						{
							return true;
						}
						if (animationState.time > 0f)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}

	// Token: 0x0600014B RID: 331 RVA: 0x0001C47C File Offset: 0x0001A67C
	public void Reset()
	{
		if (this.mAnim != null)
		{
			foreach (object obj in this.mAnim)
			{
				AnimationState animationState = (AnimationState)obj;
				if (this.mLastDirection == Direction.Reverse)
				{
					animationState.time = animationState.length;
				}
				else if (this.mLastDirection == Direction.Forward)
				{
					animationState.time = 0f;
				}
			}
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0001C520 File Offset: 0x0001A720
	private void Update()
	{
		float num = base.UpdateRealTimeDelta();
		if (num == 0f)
		{
			return;
		}
		if (this.mAnim != null)
		{
			bool flag = false;
			foreach (object obj in this.mAnim)
			{
				AnimationState animationState = (AnimationState)obj;
				if (this.mAnim.IsPlaying(animationState.name))
				{
					float num2 = animationState.speed * num;
					animationState.time += num2;
					if (num2 < 0f)
					{
						if (animationState.time > 0f)
						{
							flag = true;
						}
						else
						{
							animationState.time = 0f;
						}
					}
					else if (animationState.time < animationState.length)
					{
						flag = true;
					}
					else
					{
						animationState.time = animationState.length;
					}
				}
			}
			this.mAnim.Sample();
			if (flag)
			{
				return;
			}
			base.enabled = false;
			if (this.mNotify)
			{
				this.mNotify = false;
				if (this.onFinished != null)
				{
					this.onFinished(this);
				}
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
				{
					this.eventReceiver.SendMessage(this.callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
				}
				if (this.mDisableDirection != Direction.Toggle && this.mLastDirection == this.mDisableDirection)
				{
					NGUITools.SetActive(base.gameObject, false);
				}
			}
		}
		else
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0001C6DC File Offset: 0x0001A8DC
	private void Play(string clipName, Direction playDirection)
	{
		if (this.mAnim != null)
		{
			base.enabled = true;
			this.mAnim.enabled = false;
			if (playDirection == Direction.Toggle)
			{
				playDirection = ((this.mLastDirection == Direction.Forward) ? Direction.Reverse : Direction.Forward);
			}
			bool flag = string.IsNullOrEmpty(clipName);
			if (flag)
			{
				if (!this.mAnim.isPlaying)
				{
					this.mAnim.Play();
				}
			}
			else if (!this.mAnim.IsPlaying(clipName))
			{
				this.mAnim.Play(clipName);
			}
			foreach (object obj in this.mAnim)
			{
				AnimationState animationState = (AnimationState)obj;
				if (string.IsNullOrEmpty(clipName) || animationState.name == clipName)
				{
					float num = Mathf.Abs(animationState.speed);
					animationState.speed = num * (float)playDirection;
					if (playDirection == Direction.Reverse && animationState.time == 0f)
					{
						animationState.time = animationState.length;
					}
					else if (playDirection == Direction.Forward && animationState.time == animationState.length)
					{
						animationState.time = 0f;
					}
				}
			}
			this.mLastDirection = playDirection;
			this.mNotify = true;
			this.mAnim.Sample();
		}
	}

	// Token: 0x0600014E RID: 334 RVA: 0x0001C85C File Offset: 0x0001AA5C
	public static ActiveAnimation Play(Animation anim, string clipName, Direction playDirection, EnableCondition enableBeforePlay, DisableCondition disableCondition)
	{
		if (!NGUITools.GetActive(anim.gameObject))
		{
			if (enableBeforePlay != EnableCondition.EnableThenPlay)
			{
				return null;
			}
			NGUITools.SetActive(anim.gameObject, true);
			UIPanel[] componentsInChildren = anim.gameObject.GetComponentsInChildren<UIPanel>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				componentsInChildren[i].Refresh();
				i++;
			}
		}
		ActiveAnimation activeAnimation = anim.GetComponent<ActiveAnimation>();
		if (activeAnimation == null)
		{
			activeAnimation = anim.gameObject.AddComponent<ActiveAnimation>();
		}
		activeAnimation.mAnim = anim;
		activeAnimation.mDisableDirection = (Direction)disableCondition;
		activeAnimation.eventReceiver = null;
		activeAnimation.callWhenFinished = null;
		activeAnimation.onFinished = null;
		activeAnimation.Play(clipName, playDirection);
		return activeAnimation;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x0000316C File Offset: 0x0000136C
	public static ActiveAnimation Play(Animation anim, string clipName, Direction playDirection)
	{
		return ActiveAnimation.Play(anim, clipName, playDirection, EnableCondition.DoNothing, DisableCondition.DoNotDisable);
	}

	// Token: 0x06000150 RID: 336 RVA: 0x00003178 File Offset: 0x00001378
	public static ActiveAnimation Play(Animation anim, Direction playDirection)
	{
		return ActiveAnimation.Play(anim, null, playDirection, EnableCondition.DoNothing, DisableCondition.DoNotDisable);
	}

	// Token: 0x04000171 RID: 369
	public ActiveAnimation.OnFinished onFinished;

	// Token: 0x04000172 RID: 370
	public GameObject eventReceiver;

	// Token: 0x04000173 RID: 371
	public string callWhenFinished;

	// Token: 0x04000174 RID: 372
	private Animation mAnim;

	// Token: 0x04000175 RID: 373
	private Direction mLastDirection;

	// Token: 0x04000176 RID: 374
	private Direction mDisableDirection;

	// Token: 0x04000177 RID: 375
	private bool mNotify;

	// Token: 0x0200003E RID: 62
	// (Invoke) Token: 0x06000152 RID: 338
	public delegate void OnFinished(ActiveAnimation anim);
}
