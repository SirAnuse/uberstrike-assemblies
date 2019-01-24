using System;
using UnityEngine;

// Token: 0x02000018 RID: 24
[AddComponentMenu("NGUI/Interaction/Center On Child")]
public class UICenterOnChild : MonoBehaviour
{
	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000076 RID: 118 RVA: 0x00002744 File Offset: 0x00000944
	public GameObject centeredObject
	{
		get
		{
			return this.mCenteredObject;
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x0000274C File Offset: 0x0000094C
	private void OnEnable()
	{
		this.Recenter();
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00002754 File Offset: 0x00000954
	private void OnDragFinished()
	{
		if (base.enabled)
		{
			this.Recenter();
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x0001732C File Offset: 0x0001552C
	public void Recenter()
	{
		if (this.mDrag == null)
		{
			this.mDrag = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (this.mDrag == null)
			{
				Debug.LogWarning(string.Concat(new object[]
				{
					base.GetType(),
					" requires ",
					typeof(UIDraggablePanel),
					" on a parent object in order to work"
				}), this);
				base.enabled = false;
				return;
			}
			this.mDrag.onDragFinished = new UIDraggablePanel.OnDragFinished(this.OnDragFinished);
			if (this.mDrag.horizontalScrollBar != null)
			{
				this.mDrag.horizontalScrollBar.onDragFinished = new UIScrollBar.OnDragFinished(this.OnDragFinished);
			}
			if (this.mDrag.verticalScrollBar != null)
			{
				this.mDrag.verticalScrollBar.onDragFinished = new UIScrollBar.OnDragFinished(this.OnDragFinished);
			}
		}
		if (this.mDrag.panel == null)
		{
			return;
		}
		Vector4 clipRange = this.mDrag.panel.clipRange;
		Transform cachedTransform = this.mDrag.panel.cachedTransform;
		Vector3 vector = cachedTransform.localPosition;
		vector.x += clipRange.x;
		vector.y += clipRange.y;
		vector = cachedTransform.parent.TransformPoint(vector);
		Vector3 b = vector - this.mDrag.currentMomentum * (this.mDrag.momentumAmount * 0.1f);
		this.mDrag.currentMomentum = Vector3.zero;
		float num = float.MaxValue;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 0;
		int childCount = transform2.childCount;
		while (i < childCount)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - b);
			if (num2 < num && child.gameObject.activeSelf)
			{
				num = num2;
				transform = child;
			}
			i++;
		}
		if (transform != null)
		{
			this.mCenteredObject = transform.gameObject;
			Vector3 a = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 b2 = cachedTransform.InverseTransformPoint(vector);
			Vector3 b3 = a - b2;
			if (this.mDrag.scale.x == 0f)
			{
				b3.x = 0f;
			}
			if (this.mDrag.scale.y == 0f)
			{
				b3.y = 0f;
			}
			if (this.mDrag.scale.z == 0f)
			{
				b3.z = 0f;
			}
			SpringPanel.Begin(this.mDrag.gameObject, cachedTransform.localPosition - b3, this.springStrength).onFinished = this.onFinished;
		}
		else
		{
			this.mCenteredObject = null;
		}
	}

	// Token: 0x04000096 RID: 150
	public float springStrength = 8f;

	// Token: 0x04000097 RID: 151
	public SpringPanel.OnFinished onFinished;

	// Token: 0x04000098 RID: 152
	private UIDraggablePanel mDrag;

	// Token: 0x04000099 RID: 153
	private GameObject mCenteredObject;
}
