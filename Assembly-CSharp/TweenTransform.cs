using System;
using UnityEngine;

// Token: 0x02000069 RID: 105
[AddComponentMenu("NGUI/Tween/Transform")]
public class TweenTransform : UITweener
{
	// Token: 0x060002AE RID: 686 RVA: 0x00021668 File Offset: 0x0001F868
	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (this.to != null)
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
				this.mPos = this.mTrans.position;
				this.mRot = this.mTrans.rotation;
				this.mScale = this.mTrans.localScale;
			}
			if (this.from != null)
			{
				this.mTrans.position = this.from.position * (1f - factor) + this.to.position * factor;
				this.mTrans.localScale = this.from.localScale * (1f - factor) + this.to.localScale * factor;
				this.mTrans.rotation = Quaternion.Slerp(this.from.rotation, this.to.rotation, factor);
			}
			else
			{
				this.mTrans.position = this.mPos * (1f - factor) + this.to.position * factor;
				this.mTrans.localScale = this.mScale * (1f - factor) + this.to.localScale * factor;
				this.mTrans.rotation = Quaternion.Slerp(this.mRot, this.to.rotation, factor);
			}
			if (this.parentWhenFinished && isFinished)
			{
				this.mTrans.parent = this.to;
			}
		}
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00004036 File Offset: 0x00002236
	public static TweenTransform Begin(GameObject go, float duration, Transform to)
	{
		return TweenTransform.Begin(go, duration, null, to);
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00021830 File Offset: 0x0001FA30
	public static TweenTransform Begin(GameObject go, float duration, Transform from, Transform to)
	{
		TweenTransform tweenTransform = UITweener.Begin<TweenTransform>(go, duration);
		tweenTransform.from = from;
		tweenTransform.to = to;
		if (duration <= 0f)
		{
			tweenTransform.Sample(1f, true);
			tweenTransform.enabled = false;
		}
		return tweenTransform;
	}

	// Token: 0x04000240 RID: 576
	public Transform from;

	// Token: 0x04000241 RID: 577
	public Transform to;

	// Token: 0x04000242 RID: 578
	public bool parentWhenFinished;

	// Token: 0x04000243 RID: 579
	private Transform mTrans;

	// Token: 0x04000244 RID: 580
	private Vector3 mPos;

	// Token: 0x04000245 RID: 581
	private Quaternion mRot;

	// Token: 0x04000246 RID: 582
	private Vector3 mScale;
}
