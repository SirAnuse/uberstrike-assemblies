using System;
using UnityEngine;

// Token: 0x02000068 RID: 104
[AddComponentMenu("NGUI/Tween/Scale")]
public class TweenScale : UITweener
{
	// Token: 0x17000060 RID: 96
	// (get) Token: 0x060002A8 RID: 680 RVA: 0x00003FF6 File Offset: 0x000021F6
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

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x060002A9 RID: 681 RVA: 0x0000401B File Offset: 0x0000221B
	// (set) Token: 0x060002AA RID: 682 RVA: 0x00004028 File Offset: 0x00002228
	public Vector3 scale
	{
		get
		{
			return this.cachedTransform.localScale;
		}
		set
		{
			this.cachedTransform.localScale = value;
		}
	}

	// Token: 0x060002AB RID: 683 RVA: 0x00021590 File Offset: 0x0001F790
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.cachedTransform.localScale = this.from * (1f - factor) + this.to * factor;
		if (this.updateTable)
		{
			if (this.mTable == null)
			{
				this.mTable = NGUITools.FindInParents<UITable>(base.gameObject);
				if (this.mTable == null)
				{
					this.updateTable = false;
					return;
				}
			}
			this.mTable.repositionNow = true;
		}
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00021620 File Offset: 0x0001F820
	public static TweenScale Begin(GameObject go, float duration, Vector3 scale)
	{
		TweenScale tweenScale = UITweener.Begin<TweenScale>(go, duration);
		tweenScale.from = tweenScale.scale;
		tweenScale.to = scale;
		if (duration <= 0f)
		{
			tweenScale.Sample(1f, true);
			tweenScale.enabled = false;
		}
		return tweenScale;
	}

	// Token: 0x0400023B RID: 571
	public Vector3 from = Vector3.one;

	// Token: 0x0400023C RID: 572
	public Vector3 to = Vector3.one;

	// Token: 0x0400023D RID: 573
	public bool updateTable;

	// Token: 0x0400023E RID: 574
	private Transform mTrans;

	// Token: 0x0400023F RID: 575
	private UITable mTable;
}
