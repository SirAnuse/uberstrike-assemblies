using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000355 RID: 853
[AddComponentMenu("NGUI/CMune Extensions/Horizontal Aligner")]
[ExecuteInEditMode]
public class UIHorizontalAligner : MonoBehaviour
{
	// Token: 0x060017BA RID: 6074 RVA: 0x0000FFAE File Offset: 0x0000E1AE
	public void Reposition()
	{
		this.repositionNow = true;
	}

	// Token: 0x060017BB RID: 6075 RVA: 0x0000FFB7 File Offset: 0x0000E1B7
	private void Start()
	{
		this.mStarted = true;
		this.Reposition();
	}

	// Token: 0x060017BC RID: 6076 RVA: 0x0000FFC6 File Offset: 0x0000E1C6
	private void LateUpdate()
	{
		if (this.repositionNow)
		{
			this.repositionNow = false;
			this.DoReposition();
		}
	}

	// Token: 0x060017BD RID: 6077 RVA: 0x00080A24 File Offset: 0x0007EC24
	private void DoReposition()
	{
		if (!this.mStarted)
		{
			this.repositionNow = true;
			return;
		}
		List<Transform> list = new List<Transform>();
		foreach (object obj in base.transform)
		{
			Transform transform = (Transform)obj;
			if (transform != null && transform.gameObject && (!this.hideInactive || NGUITools.GetActive(transform.gameObject)))
			{
				list.Add(transform);
			}
		}
		if (this.sorted)
		{
			list.Sort((Transform el1, Transform el2) => el1.name.CompareTo(el2.name));
		}
		if (this.direction == UIHorizontalAligner.Direction.RightToLeft)
		{
			list.Reverse();
		}
		float num = 0f;
		foreach (Transform transform2 in list)
		{
			UIWidget component = transform2.GetComponent<UIWidget>();
			if (component != null)
			{
				this.SetPivot(component, this.direction == UIHorizontalAligner.Direction.LeftToRight);
			}
			transform2.localPosition = transform2.localPosition.SetX(num);
			float num2 = NGUIMath.CalculateRelativeWidgetBounds(transform2).size.x * transform2.localScale.x + this.padding;
			if (this.direction == UIHorizontalAligner.Direction.LeftToRight)
			{
				num += num2;
			}
			else
			{
				num -= num2;
			}
		}
	}

	// Token: 0x060017BE RID: 6078 RVA: 0x00080BE8 File Offset: 0x0007EDE8
	private void SetPivot(UIWidget widget, bool leftToRight)
	{
		if (widget.pivot == UIWidget.Pivot.TopLeft || widget.pivot == UIWidget.Pivot.Top || widget.pivot == UIWidget.Pivot.TopRight)
		{
			widget.pivot = ((!leftToRight) ? UIWidget.Pivot.TopRight : UIWidget.Pivot.TopLeft);
		}
		else if (widget.pivot == UIWidget.Pivot.Left || widget.pivot == UIWidget.Pivot.Center || widget.pivot == UIWidget.Pivot.Right)
		{
			widget.pivot = ((!leftToRight) ? UIWidget.Pivot.Right : UIWidget.Pivot.Left);
		}
		else if (widget.pivot == UIWidget.Pivot.BottomLeft || widget.pivot == UIWidget.Pivot.Bottom || widget.pivot == UIWidget.Pivot.BottomRight)
		{
			widget.pivot = ((!leftToRight) ? UIWidget.Pivot.BottomRight : UIWidget.Pivot.BottomLeft);
		}
	}

	// Token: 0x04001699 RID: 5785
	public UIHorizontalAligner.Direction direction;

	// Token: 0x0400169A RID: 5786
	public float padding;

	// Token: 0x0400169B RID: 5787
	public bool sorted = true;

	// Token: 0x0400169C RID: 5788
	public bool hideInactive = true;

	// Token: 0x0400169D RID: 5789
	[SerializeField]
	private bool repositionNow;

	// Token: 0x0400169E RID: 5790
	private bool mStarted;

	// Token: 0x02000356 RID: 854
	public enum Direction
	{
		// Token: 0x040016A1 RID: 5793
		LeftToRight,
		// Token: 0x040016A2 RID: 5794
		RightToLeft
	}
}
