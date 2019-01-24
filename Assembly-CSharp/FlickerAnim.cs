using System;
using UnityEngine;

// Token: 0x02000231 RID: 561
public class FlickerAnim
{
	// Token: 0x06000F7F RID: 3967 RVA: 0x0000AFFE File Offset: 0x000091FE
	public FlickerAnim(Action<FlickerAnim> onFlickerVisibleChange = null)
	{
		this._isAnimating = false;
		this._onFlickerVisibleChange = onFlickerVisibleChange;
	}

	// Token: 0x1700039E RID: 926
	// (get) Token: 0x06000F80 RID: 3968 RVA: 0x0000B014 File Offset: 0x00009214
	public bool IsAnimating
	{
		get
		{
			return this._isAnimating;
		}
	}

	// Token: 0x1700039F RID: 927
	// (get) Token: 0x06000F81 RID: 3969 RVA: 0x0000B01C File Offset: 0x0000921C
	// (set) Token: 0x06000F82 RID: 3970 RVA: 0x0000B024 File Offset: 0x00009224
	public bool IsFlickerVisible
	{
		get
		{
			return this._isFlickerVisible;
		}
		set
		{
			this._isFlickerVisible = value;
			if (this._onFlickerVisibleChange != null)
			{
				this._onFlickerVisibleChange(this);
			}
		}
	}

	// Token: 0x06000F83 RID: 3971 RVA: 0x0006500C File Offset: 0x0006320C
	public void Update()
	{
		if (this._isAnimating)
		{
			float time = Time.time;
			if (time > this._flickerEndTime)
			{
				this._isAnimating = false;
				this.IsFlickerVisible = true;
			}
			else if (time > this._lastFlickerTime + this._flickerInterval)
			{
				this.IsFlickerVisible = !this._isFlickerVisible;
				this._lastFlickerTime = time;
			}
		}
	}

	// Token: 0x06000F84 RID: 3972 RVA: 0x00065074 File Offset: 0x00063274
	public void Flicker(float time, float flickerInterval = 0.02f)
	{
		if (time <= 0f || flickerInterval >= time)
		{
			return;
		}
		this._isAnimating = true;
		this._flickerInterval = 0.02f;
		this._flickerStartTime = Time.time;
		this._flickerEndTime = this._flickerStartTime + time;
		this._lastFlickerTime = this._flickerStartTime;
	}

	// Token: 0x06000F85 RID: 3973 RVA: 0x0000B044 File Offset: 0x00009244
	public void StopAnim()
	{
		this._isAnimating = false;
	}

	// Token: 0x04000DA2 RID: 3490
	private bool _isAnimating;

	// Token: 0x04000DA3 RID: 3491
	private Action<FlickerAnim> _onFlickerVisibleChange;

	// Token: 0x04000DA4 RID: 3492
	private float _flickerInterval;

	// Token: 0x04000DA5 RID: 3493
	private float _flickerStartTime;

	// Token: 0x04000DA6 RID: 3494
	private float _flickerEndTime;

	// Token: 0x04000DA7 RID: 3495
	private float _lastFlickerTime;

	// Token: 0x04000DA8 RID: 3496
	private bool _isFlickerVisible;
}
