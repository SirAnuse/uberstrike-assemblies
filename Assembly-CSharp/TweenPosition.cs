using System;
using UnityEngine;

// Token: 0x02000066 RID: 102
[AddComponentMenu("NGUI/Tween/Position")]
public class TweenPosition : UITweener
{
	// Token: 0x1700005C RID: 92
	// (get) Token: 0x0600029C RID: 668 RVA: 0x00003EFF File Offset: 0x000020FF
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

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x0600029D RID: 669 RVA: 0x00003F24 File Offset: 0x00002124
	// (set) Token: 0x0600029E RID: 670 RVA: 0x00003F31 File Offset: 0x00002131
	public Vector3 position
	{
		get
		{
			return this.cachedTransform.localPosition;
		}
		set
		{
			this.cachedTransform.localPosition = value;
		}
	}

	// Token: 0x0600029F RID: 671 RVA: 0x00003F3F File Offset: 0x0000213F
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.cachedTransform.localPosition = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x000214F0 File Offset: 0x0001F6F0
	public static TweenPosition Begin(GameObject go, float duration, Vector3 pos)
	{
		TweenPosition tweenPosition = UITweener.Begin<TweenPosition>(go, duration);
		tweenPosition.from = tweenPosition.position;
		tweenPosition.to = pos;
		if (duration <= 0f)
		{
			tweenPosition.Sample(1f, true);
			tweenPosition.enabled = false;
		}
		return tweenPosition;
	}

	// Token: 0x04000235 RID: 565
	public Vector3 from;

	// Token: 0x04000236 RID: 566
	public Vector3 to;

	// Token: 0x04000237 RID: 567
	private Transform mTrans;
}
