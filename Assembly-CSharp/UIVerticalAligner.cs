using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200035A RID: 858
[AddComponentMenu("NGUI/CMune Extensions/Vertical Aligner")]
[ExecuteInEditMode]
public class UIVerticalAligner : MonoBehaviour
{
	// Token: 0x060017CD RID: 6093 RVA: 0x00010081 File Offset: 0x0000E281
	public void Reposition()
	{
		this.repositionNow = true;
	}

	// Token: 0x060017CE RID: 6094 RVA: 0x0001008A File Offset: 0x0000E28A
	private void Start()
	{
		this.mStarted = true;
		this.Reposition();
	}

	// Token: 0x060017CF RID: 6095 RVA: 0x00010099 File Offset: 0x0000E299
	private void LateUpdate()
	{
		if (this.repositionNow)
		{
			this.repositionNow = false;
			this.DoReposition();
		}
	}

	// Token: 0x060017D0 RID: 6096 RVA: 0x000810BC File Offset: 0x0007F2BC
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
		if (this.direction == UIVerticalAligner.Direction.BottomToTop)
		{
			list.Reverse();
		}
		float num = 0f;
		foreach (Transform transform2 in list)
		{
			UIWidget component = transform2.GetComponent<UIWidget>();
			if (component != null)
			{
				this.SetPivot(component, this.direction == UIVerticalAligner.Direction.TopToBottom);
			}
			transform2.localPosition = transform2.localPosition.SetY(num);
			float num2 = NGUIMath.CalculateRelativeWidgetBounds(transform2).size.y * transform2.localScale.y + this.padding;
			if (this.direction == UIVerticalAligner.Direction.TopToBottom)
			{
				num -= num2;
			}
			else
			{
				num += num2;
			}
		}
	}

	// Token: 0x060017D1 RID: 6097 RVA: 0x00081280 File Offset: 0x0007F480
	private void SetPivot(UIWidget widget, bool topToBottom)
	{
		if (widget.pivot == UIWidget.Pivot.TopLeft || widget.pivot == UIWidget.Pivot.Left || widget.pivot == UIWidget.Pivot.BottomLeft)
		{
			widget.pivot = ((!topToBottom) ? UIWidget.Pivot.BottomLeft : UIWidget.Pivot.TopLeft);
		}
		else if (widget.pivot == UIWidget.Pivot.Top || widget.pivot == UIWidget.Pivot.Center || widget.pivot == UIWidget.Pivot.Bottom)
		{
			widget.pivot = ((!topToBottom) ? UIWidget.Pivot.Right : UIWidget.Pivot.Left);
		}
		else if (widget.pivot == UIWidget.Pivot.TopRight || widget.pivot == UIWidget.Pivot.Right || widget.pivot == UIWidget.Pivot.BottomRight)
		{
			widget.pivot = ((!topToBottom) ? UIWidget.Pivot.BottomRight : UIWidget.Pivot.TopRight);
		}
	}

	// Token: 0x040016AF RID: 5807
	public UIVerticalAligner.Direction direction;

	// Token: 0x040016B0 RID: 5808
	public float padding;

	// Token: 0x040016B1 RID: 5809
	public bool sorted = true;

	// Token: 0x040016B2 RID: 5810
	public bool hideInactive = true;

	// Token: 0x040016B3 RID: 5811
	[SerializeField]
	private bool repositionNow;

	// Token: 0x040016B4 RID: 5812
	private bool mStarted;

	// Token: 0x0200035B RID: 859
	public enum Direction
	{
		// Token: 0x040016B7 RID: 5815
		TopToBottom,
		// Token: 0x040016B8 RID: 5816
		BottomToTop
	}
}
