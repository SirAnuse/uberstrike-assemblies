using System;
using UnityEngine;

// Token: 0x02000067 RID: 103
[AddComponentMenu("NGUI/Tween/Rotation")]
public class TweenRotation : UITweener
{
	// Token: 0x1700005E RID: 94
	// (get) Token: 0x060002A2 RID: 674 RVA: 0x00003F6F File Offset: 0x0000216F
	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x060002A3 RID: 675 RVA: 0x00003F94 File Offset: 0x00002194
	// (set) Token: 0x060002A4 RID: 676 RVA: 0x00003FA1 File Offset: 0x000021A1
	public Quaternion rotation
	{
		get
		{
			return this.cachedTransform.localRotation;
		}
		set
		{
			this.cachedTransform.localRotation = value;
		}
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x00003FAF File Offset: 0x000021AF
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.cachedTransform.localRotation = Quaternion.Slerp(Quaternion.Euler(this.from), Quaternion.Euler(this.to), factor);
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00021538 File Offset: 0x0001F738
	public static TweenRotation Begin(GameObject go, float duration, Quaternion rot)
	{
		TweenRotation tweenRotation = UITweener.Begin<TweenRotation>(go, duration);
		tweenRotation.from = tweenRotation.rotation.eulerAngles;
		tweenRotation.to = rot.eulerAngles;
		if (duration <= 0f)
		{
			tweenRotation.Sample(1f, true);
			tweenRotation.enabled = false;
		}
		return tweenRotation;
	}

	// Token: 0x04000238 RID: 568
	public Vector3 from;

	// Token: 0x04000239 RID: 569
	public Vector3 to;

	// Token: 0x0400023A RID: 570
	private Transform mTrans;
}
