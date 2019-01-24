using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x0200006C RID: 108
public abstract class UITweener : IgnoreTimeScale
{
	// Token: 0x17000064 RID: 100
	// (get) Token: 0x060002BA RID: 698 RVA: 0x00021B78 File Offset: 0x0001FD78
	public float amountPerDelta
	{
		get
		{
			if (this.mDuration != this.duration)
			{
				this.mDuration = this.duration;
				this.mAmountPerDelta = Mathf.Abs((this.duration <= 0f) ? 1000f : (1f / this.duration));
			}
			return this.mAmountPerDelta;
		}
	}

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060002BB RID: 699 RVA: 0x000040BB File Offset: 0x000022BB
	public float tweenFactor
	{
		get
		{
			return this.mFactor;
		}
	}

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x060002BC RID: 700 RVA: 0x000040C3 File Offset: 0x000022C3
	public Direction direction
	{
		get
		{
			return (this.mAmountPerDelta >= 0f) ? Direction.Forward : Direction.Reverse;
		}
	}

	// Token: 0x060002BD RID: 701 RVA: 0x000040DC File Offset: 0x000022DC
	private void Start()
	{
		this.Update();
	}

	// Token: 0x060002BE RID: 702 RVA: 0x00021BDC File Offset: 0x0001FDDC
	private void Update()
	{
		float num = (!this.ignoreTimeScale) ? Time.deltaTime : base.UpdateRealTimeDelta();
		float num2 = (!this.ignoreTimeScale) ? Time.time : base.realTime;
		if (!this.mStarted)
		{
			this.mStarted = true;
			this.mStartTime = num2 + this.delay;
		}
		if (num2 < this.mStartTime)
		{
			return;
		}
		this.mFactor += this.amountPerDelta * num;
		if (this.style == UITweener.Style.Loop)
		{
			if (this.mFactor > 1f)
			{
				this.mFactor -= Mathf.Floor(this.mFactor);
				if (this.onCycleFinished != null)
				{
					this.onCycleFinished(this);
				}
			}
		}
		else if (this.style == UITweener.Style.PingPong)
		{
			if (this.mFactor > 1f)
			{
				this.mFactor = 1f - (this.mFactor - Mathf.Floor(this.mFactor));
				this.mAmountPerDelta = -this.mAmountPerDelta;
			}
			else if (this.mFactor < 0f)
			{
				this.mFactor = -this.mFactor;
				this.mFactor -= Mathf.Floor(this.mFactor);
				this.mAmountPerDelta = -this.mAmountPerDelta;
				if (this.onCycleFinished != null)
				{
					this.onCycleFinished(this);
				}
			}
		}
		if (this.style == UITweener.Style.Once && (this.mFactor > 1f || this.mFactor < 0f))
		{
			this.mFactor = Mathf.Clamp01(this.mFactor);
			this.Sample(this.mFactor, true);
			if (this.onFinished != null)
			{
				this.onFinished(this);
			}
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
			{
				this.eventReceiver.SendMessage(this.callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
			}
			if ((this.mFactor == 1f && this.mAmountPerDelta > 0f) || (this.mFactor == 0f && this.mAmountPerDelta < 0f))
			{
				base.enabled = false;
			}
		}
		else
		{
			this.Sample(this.mFactor, false);
		}
	}

	// Token: 0x060002BF RID: 703 RVA: 0x000040E4 File Offset: 0x000022E4
	private void OnDisable()
	{
		this.mStarted = false;
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x00021E48 File Offset: 0x00020048
	public void Sample(float factor, bool isFinished)
	{
		float num = Mathf.Clamp01(factor);
		if (this.method == UITweener.Method.EaseIn)
		{
			num = 1f - Mathf.Sin(1.57079637f * (1f - num));
			if (this.steeperCurves)
			{
				num *= num;
			}
		}
		else if (this.method == UITweener.Method.EaseOut)
		{
			num = Mathf.Sin(1.57079637f * num);
			if (this.steeperCurves)
			{
				num = 1f - num;
				num = 1f - num * num;
			}
		}
		else if (this.method == UITweener.Method.EaseInOut)
		{
			num -= Mathf.Sin(num * 6.28318548f) / 6.28318548f;
			if (this.steeperCurves)
			{
				num = num * 2f - 1f;
				float num2 = Mathf.Sign(num);
				num = 1f - Mathf.Abs(num);
				num = 1f - num * num;
				num = num2 * num * 0.5f + 0.5f;
			}
		}
		else if (this.method == UITweener.Method.BounceIn)
		{
			num = this.BounceLogic(num);
		}
		else if (this.method == UITweener.Method.BounceOut)
		{
			num = 1f - this.BounceLogic(1f - num);
		}
		this.OnUpdate((this.animationCurve == null) ? num : this.animationCurve.Evaluate(num), isFinished);
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x00021F9C File Offset: 0x0002019C
	private float BounceLogic(float val)
	{
		if (val < 0.363636f)
		{
			val = 7.5685f * val * val;
		}
		else if (val < 0.727272f)
		{
			val = 7.5625f * (val -= 0.545454f) * val + 0.75f;
		}
		else if (val < 0.90909f)
		{
			val = 7.5625f * (val -= 0.818181f) * val + 0.9375f;
		}
		else
		{
			val = 7.5625f * (val -= 0.9545454f) * val + 0.984375f;
		}
		return val;
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x000040ED File Offset: 0x000022ED
	public void Play(bool forward)
	{
		this.mAmountPerDelta = Mathf.Abs(this.amountPerDelta);
		if (!forward)
		{
			this.mAmountPerDelta = -this.mAmountPerDelta;
		}
		base.enabled = true;
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x0000411A File Offset: 0x0000231A
	public void Reset()
	{
		this.mStarted = false;
		this.mFactor = ((this.mAmountPerDelta >= 0f) ? 0f : 1f);
		this.Sample(this.mFactor, false);
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x00004155 File Offset: 0x00002355
	public void Toggle()
	{
		if (this.mFactor > 0f)
		{
			this.mAmountPerDelta = -this.amountPerDelta;
		}
		else
		{
			this.mAmountPerDelta = Mathf.Abs(this.amountPerDelta);
		}
		base.enabled = true;
	}

	// Token: 0x060002C5 RID: 709
	protected abstract void OnUpdate(float factor, bool isFinished);

	// Token: 0x060002C6 RID: 710 RVA: 0x00022034 File Offset: 0x00020234
	public static T Begin<T>(GameObject go, float duration) where T : UITweener
	{
		T t = go.GetComponent<T>();
		if (t == null)
		{
			t = go.AddComponent<T>();
		}
		t.mStarted = false;
		t.duration = duration;
		t.mFactor = 0f;
		t.mAmountPerDelta = Mathf.Abs(t.mAmountPerDelta);
		t.style = UITweener.Style.Once;
		t.animationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f, 0f, 1f),
			new Keyframe(1f, 1f, 1f, 0f)
		});
		t.eventReceiver = null;
		t.callWhenFinished = null;
		t.onFinished = null;
		t.enabled = true;
		return t;
	}

	// Token: 0x04000250 RID: 592
	public UITweener.OnFinished onFinished;

	// Token: 0x04000251 RID: 593
	public UITweener.OnFinished onCycleFinished;

	// Token: 0x04000252 RID: 594
	public UITweener.Method method;

	// Token: 0x04000253 RID: 595
	public UITweener.Style style;

	// Token: 0x04000254 RID: 596
	public AnimationCurve animationCurve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f, 0f, 1f),
		new Keyframe(1f, 1f, 1f, 0f)
	});

	// Token: 0x04000255 RID: 597
	public bool ignoreTimeScale = true;

	// Token: 0x04000256 RID: 598
	public float delay;

	// Token: 0x04000257 RID: 599
	public float duration = 1f;

	// Token: 0x04000258 RID: 600
	public bool steeperCurves;

	// Token: 0x04000259 RID: 601
	public int tweenGroup;

	// Token: 0x0400025A RID: 602
	public GameObject eventReceiver;

	// Token: 0x0400025B RID: 603
	public string callWhenFinished;

	// Token: 0x0400025C RID: 604
	private bool mStarted;

	// Token: 0x0400025D RID: 605
	private float mStartTime;

	// Token: 0x0400025E RID: 606
	private float mDuration;

	// Token: 0x0400025F RID: 607
	private float mAmountPerDelta = 1f;

	// Token: 0x04000260 RID: 608
	private float mFactor;

	// Token: 0x0200006D RID: 109
	public enum Method
	{
		// Token: 0x04000262 RID: 610
		Linear,
		// Token: 0x04000263 RID: 611
		EaseIn,
		// Token: 0x04000264 RID: 612
		EaseOut,
		// Token: 0x04000265 RID: 613
		EaseInOut,
		// Token: 0x04000266 RID: 614
		BounceIn,
		// Token: 0x04000267 RID: 615
		BounceOut
	}

	// Token: 0x0200006E RID: 110
	public enum Style
	{
		// Token: 0x04000269 RID: 617
		Once,
		// Token: 0x0400026A RID: 618
		Loop,
		// Token: 0x0400026B RID: 619
		PingPong
	}

	// Token: 0x0200006F RID: 111
	// (Invoke) Token: 0x060002C8 RID: 712
	public delegate void OnFinished(UITweener tween);
}
