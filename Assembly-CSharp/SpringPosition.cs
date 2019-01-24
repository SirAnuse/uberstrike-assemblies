using System;
using UnityEngine;

// Token: 0x02000060 RID: 96
[AddComponentMenu("NGUI/Tween/Spring Position")]
public class SpringPosition : IgnoreTimeScale
{
	// Token: 0x0600027C RID: 636 RVA: 0x00003D86 File Offset: 0x00001F86
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x0600027D RID: 637 RVA: 0x00020F84 File Offset: 0x0001F184
	private void Update()
	{
		float deltaTime = (!this.ignoreTimeScale) ? Time.deltaTime : base.UpdateRealTimeDelta();
		if (this.worldSpace)
		{
			if (this.mThreshold == 0f)
			{
				this.mThreshold = (this.target - this.mTrans.position).magnitude * 0.001f;
			}
			this.mTrans.position = NGUIMath.SpringLerp(this.mTrans.position, this.target, this.strength, deltaTime);
			if (this.mThreshold >= (this.target - this.mTrans.position).magnitude)
			{
				this.mTrans.position = this.target;
				if (this.onFinished != null)
				{
					this.onFinished(this);
				}
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
				{
					this.eventReceiver.SendMessage(this.callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
				}
				base.enabled = false;
			}
		}
		else
		{
			if (this.mThreshold == 0f)
			{
				this.mThreshold = (this.target - this.mTrans.localPosition).magnitude * 0.001f;
			}
			this.mTrans.localPosition = NGUIMath.SpringLerp(this.mTrans.localPosition, this.target, this.strength, deltaTime);
			if (this.mThreshold >= (this.target - this.mTrans.localPosition).magnitude)
			{
				this.mTrans.localPosition = this.target;
				if (this.onFinished != null)
				{
					this.onFinished(this);
				}
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
				{
					this.eventReceiver.SendMessage(this.callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
				}
				base.enabled = false;
			}
		}
	}

	// Token: 0x0600027E RID: 638 RVA: 0x0002119C File Offset: 0x0001F39C
	public static SpringPosition Begin(GameObject go, Vector3 pos, float strength)
	{
		SpringPosition springPosition = go.GetComponent<SpringPosition>();
		if (springPosition == null)
		{
			springPosition = go.AddComponent<SpringPosition>();
		}
		springPosition.target = pos;
		springPosition.strength = strength;
		springPosition.onFinished = null;
		if (!springPosition.enabled)
		{
			springPosition.mThreshold = 0f;
			springPosition.enabled = true;
		}
		return springPosition;
	}

	// Token: 0x0400021B RID: 539
	public Vector3 target = Vector3.zero;

	// Token: 0x0400021C RID: 540
	public float strength = 10f;

	// Token: 0x0400021D RID: 541
	public bool worldSpace;

	// Token: 0x0400021E RID: 542
	public bool ignoreTimeScale;

	// Token: 0x0400021F RID: 543
	public GameObject eventReceiver;

	// Token: 0x04000220 RID: 544
	public string callWhenFinished;

	// Token: 0x04000221 RID: 545
	public SpringPosition.OnFinished onFinished;

	// Token: 0x04000222 RID: 546
	private Transform mTrans;

	// Token: 0x04000223 RID: 547
	private float mThreshold;

	// Token: 0x02000061 RID: 97
	// (Invoke) Token: 0x06000280 RID: 640
	public delegate void OnFinished(SpringPosition spring);
}
