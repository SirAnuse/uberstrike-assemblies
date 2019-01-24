using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
[AddComponentMenu("NGUI/Internal/Ignore TimeScale Behaviour")]
public class IgnoreTimeScale : MonoBehaviour
{
	// Token: 0x17000033 RID: 51
	// (get) Token: 0x06000191 RID: 401 RVA: 0x00003358 File Offset: 0x00001558
	public float realTime
	{
		get
		{
			return this.mRt;
		}
	}

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x06000192 RID: 402 RVA: 0x00003360 File Offset: 0x00001560
	public float realTimeDelta
	{
		get
		{
			return this.mTimeDelta;
		}
	}

	// Token: 0x06000193 RID: 403 RVA: 0x00003368 File Offset: 0x00001568
	protected virtual void OnEnable()
	{
		this.mTimeStarted = true;
		this.mTimeDelta = 0f;
		this.mTimeStart = Time.realtimeSinceStartup;
	}

	// Token: 0x06000194 RID: 404 RVA: 0x0001D370 File Offset: 0x0001B570
	protected float UpdateRealTimeDelta()
	{
		this.mRt = Time.realtimeSinceStartup;
		if (this.mTimeStarted)
		{
			float b = this.mRt - this.mTimeStart;
			this.mActual += Mathf.Max(0f, b);
			this.mTimeDelta = 0.001f * Mathf.Round(this.mActual * 1000f);
			this.mActual -= this.mTimeDelta;
			if (this.mTimeDelta > 1f)
			{
				this.mTimeDelta = 1f;
			}
			this.mTimeStart = this.mRt;
		}
		else
		{
			this.mTimeStarted = true;
			this.mTimeStart = this.mRt;
			this.mTimeDelta = 0f;
		}
		return this.mTimeDelta;
	}

	// Token: 0x040001B6 RID: 438
	private float mRt;

	// Token: 0x040001B7 RID: 439
	private float mTimeStart;

	// Token: 0x040001B8 RID: 440
	private float mTimeDelta;

	// Token: 0x040001B9 RID: 441
	private float mActual;

	// Token: 0x040001BA RID: 442
	private bool mTimeStarted;
}
