using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Internal/Spring Panel")]
public class SpringPanel : IgnoreTimeScale
{
	// Token: 0x060001F9 RID: 505 RVA: 0x000036F3 File Offset: 0x000018F3
	private void Start()
	{
		this.mPanel = base.GetComponent<UIPanel>();
		this.mDrag = base.GetComponent<UIDraggablePanel>();
		this.mTrans = base.transform;
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0001F730 File Offset: 0x0001D930
	private void Update()
	{
		float deltaTime = base.UpdateRealTimeDelta();
		if (this.mThreshold == 0f)
		{
			this.mThreshold = (this.target - this.mTrans.localPosition).magnitude * 0.005f;
		}
		bool flag = false;
		Vector3 localPosition = this.mTrans.localPosition;
		Vector3 vector = NGUIMath.SpringLerp(this.mTrans.localPosition, this.target, this.strength, deltaTime);
		if (this.mThreshold >= Vector3.Magnitude(vector - this.target))
		{
			vector = this.target;
			base.enabled = false;
			flag = true;
		}
		this.mTrans.localPosition = vector;
		Vector3 vector2 = vector - localPosition;
		Vector4 clipRange = this.mPanel.clipRange;
		clipRange.x -= vector2.x;
		clipRange.y -= vector2.y;
		this.mPanel.clipRange = clipRange;
		if (this.mDrag != null)
		{
			this.mDrag.UpdateScrollbars(false);
		}
		if (flag && this.onFinished != null)
		{
			this.onFinished();
		}
	}

	// Token: 0x060001FB RID: 507 RVA: 0x0001F86C File Offset: 0x0001DA6C
	public static SpringPanel Begin(GameObject go, Vector3 pos, float strength)
	{
		SpringPanel springPanel = go.GetComponent<SpringPanel>();
		if (springPanel == null)
		{
			springPanel = go.AddComponent<SpringPanel>();
		}
		springPanel.target = pos;
		springPanel.strength = strength;
		springPanel.onFinished = null;
		if (!springPanel.enabled)
		{
			springPanel.mThreshold = 0f;
			springPanel.enabled = true;
		}
		return springPanel;
	}

	// Token: 0x040001C7 RID: 455
	public Vector3 target = Vector3.zero;

	// Token: 0x040001C8 RID: 456
	public float strength = 10f;

	// Token: 0x040001C9 RID: 457
	public SpringPanel.OnFinished onFinished;

	// Token: 0x040001CA RID: 458
	private UIPanel mPanel;

	// Token: 0x040001CB RID: 459
	private Transform mTrans;

	// Token: 0x040001CC RID: 460
	private float mThreshold;

	// Token: 0x040001CD RID: 461
	private UIDraggablePanel mDrag;

	// Token: 0x0200004F RID: 79
	// (Invoke) Token: 0x060001FD RID: 509
	public delegate void OnFinished();
}
