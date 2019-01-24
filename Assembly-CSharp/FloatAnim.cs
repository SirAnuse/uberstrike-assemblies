using System;
using UnityEngine;

// Token: 0x02000232 RID: 562
public class FloatAnim
{
	// Token: 0x06000F86 RID: 3974 RVA: 0x0000B04D File Offset: 0x0000924D
	public FloatAnim(FloatAnim.OnValueChange onValueChange = null, float value = 0f)
	{
		this._isAnimating = false;
		this._value = value;
		if (onValueChange != null)
		{
			this._onValueChange = onValueChange;
		}
	}

	// Token: 0x170003A0 RID: 928
	// (get) Token: 0x06000F87 RID: 3975 RVA: 0x0000B070 File Offset: 0x00009270
	// (set) Token: 0x06000F88 RID: 3976 RVA: 0x000650CC File Offset: 0x000632CC
	public float Value
	{
		get
		{
			return this._value;
		}
		set
		{
			float value2 = this._value;
			this._value = value;
			if (this._onValueChange != null)
			{
				this._onValueChange(value2, this._value);
			}
		}
	}

	// Token: 0x170003A1 RID: 929
	// (get) Token: 0x06000F89 RID: 3977 RVA: 0x0000B078 File Offset: 0x00009278
	public bool IsAnimating
	{
		get
		{
			return this._isAnimating;
		}
	}

	// Token: 0x06000F8A RID: 3978 RVA: 0x00065104 File Offset: 0x00063304
	public void Update()
	{
		if (this._isAnimating)
		{
			float num = Time.time - this._animStartTime;
			if (num <= this._animTime)
			{
				float t = Mathf.Clamp01(num * (1f / this._animTime));
				this.Value = Mathf.Lerp(this._animSrc, this._animDest, Mathfx.Ease(t, this._animEaseType));
			}
			else
			{
				this.Value = this._animDest;
				this._isAnimating = false;
			}
		}
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x00065184 File Offset: 0x00063384
	public void AnimTo(float destValue, float time = 0f, EaseType easeType = EaseType.None)
	{
		if (time <= 0f)
		{
			this.Value = destValue;
			return;
		}
		this._isAnimating = true;
		this._animSrc = this.Value;
		this._animDest = destValue;
		this._animTime = time;
		this._animEaseType = easeType;
		this._animStartTime = Time.time;
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x000651D8 File Offset: 0x000633D8
	public void AnimBy(float deltaValue, float time = 0f, EaseType easeType = EaseType.None)
	{
		float destValue = this.Value + deltaValue;
		this.AnimTo(destValue, time, easeType);
	}

	// Token: 0x06000F8D RID: 3981 RVA: 0x0000B080 File Offset: 0x00009280
	public void StopAnim()
	{
		this._isAnimating = false;
	}

	// Token: 0x04000DA9 RID: 3497
	private float _value;

	// Token: 0x04000DAA RID: 3498
	private FloatAnim.OnValueChange _onValueChange;

	// Token: 0x04000DAB RID: 3499
	private bool _isAnimating;

	// Token: 0x04000DAC RID: 3500
	private float _animSrc;

	// Token: 0x04000DAD RID: 3501
	private float _animDest;

	// Token: 0x04000DAE RID: 3502
	private float _animTime;

	// Token: 0x04000DAF RID: 3503
	private float _animStartTime;

	// Token: 0x04000DB0 RID: 3504
	private EaseType _animEaseType;

	// Token: 0x02000233 RID: 563
	// (Invoke) Token: 0x06000F8F RID: 3983
	public delegate void OnValueChange(float oldValue, float newValue);
}
