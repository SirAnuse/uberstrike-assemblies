using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200003A RID: 58
[AddComponentMenu("NGUI/Interaction/Table")]
[ExecuteInEditMode]
public class UITable : MonoBehaviour
{
	// Token: 0x0600013F RID: 319 RVA: 0x00002D3C File Offset: 0x00000F3C
	public static int SortByName(Transform a, Transform b)
	{
		return string.Compare(a.name, b.name);
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x06000140 RID: 320 RVA: 0x0001BE70 File Offset: 0x0001A070
	public List<Transform> children
	{
		get
		{
			if (this.mChildren.Count == 0)
			{
				Transform transform = base.transform;
				this.mChildren.Clear();
				for (int i = 0; i < transform.childCount; i++)
				{
					Transform child = transform.GetChild(i);
					if (child && child.gameObject && (!this.hideInactive || NGUITools.GetActive(child.gameObject)))
					{
						this.mChildren.Add(child);
					}
				}
				if (this.sorted)
				{
					this.mChildren.Sort(new Comparison<Transform>(UITable.SortByName));
				}
			}
			return this.mChildren;
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x0001BF28 File Offset: 0x0001A128
	private void RepositionVariableSize(List<Transform> children)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = (this.columns <= 0) ? 1 : (children.Count / this.columns + 1);
		int num4 = (this.columns <= 0) ? children.Count : this.columns;
		Bounds[,] array = new Bounds[num3, num4];
		Bounds[] array2 = new Bounds[num4];
		Bounds[] array3 = new Bounds[num3];
		int num5 = 0;
		int num6 = 0;
		int i = 0;
		int count = children.Count;
		while (i < count)
		{
			Transform transform = children[i];
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(transform);
			Vector3 localScale = transform.localScale;
			bounds.min = Vector3.Scale(bounds.min, localScale);
			bounds.max = Vector3.Scale(bounds.max, localScale);
			array[num6, num5] = bounds;
			array2[num5].Encapsulate(bounds);
			array3[num6].Encapsulate(bounds);
			if (++num5 >= this.columns && this.columns > 0)
			{
				num5 = 0;
				num6++;
			}
			i++;
		}
		num5 = 0;
		num6 = 0;
		int j = 0;
		int count2 = children.Count;
		while (j < count2)
		{
			Transform transform2 = children[j];
			Bounds bounds2 = array[num6, num5];
			Bounds bounds3 = array2[num5];
			Bounds bounds4 = array3[num6];
			Vector3 localPosition = transform2.localPosition;
			localPosition.x = num + bounds2.extents.x - bounds2.center.x;
			localPosition.x += bounds2.min.x - bounds3.min.x + this.padding.x;
			if (this.direction == UITable.Direction.Down)
			{
				localPosition.y = -num2 - bounds2.extents.y - bounds2.center.y;
				localPosition.y += (bounds2.max.y - bounds2.min.y - bounds4.max.y + bounds4.min.y) * 0.5f - this.padding.y;
			}
			else
			{
				localPosition.y = num2 + bounds2.extents.y - bounds2.center.y;
				localPosition.y += (bounds2.max.y - bounds2.min.y - bounds4.max.y + bounds4.min.y) * 0.5f - this.padding.y;
			}
			num += bounds3.max.x - bounds3.min.x + this.padding.x * 2f;
			transform2.localPosition = localPosition;
			if (++num5 >= this.columns && this.columns > 0)
			{
				num5 = 0;
				num6++;
				num = 0f;
				num2 += bounds4.size.y + this.padding.y * 2f;
			}
			j++;
		}
	}

	// Token: 0x06000142 RID: 322 RVA: 0x0001C2E0 File Offset: 0x0001A4E0
	public void Reposition()
	{
		if (this.mStarted)
		{
			Transform transform = base.transform;
			this.mChildren.Clear();
			List<Transform> children = this.children;
			if (children.Count > 0)
			{
				this.RepositionVariableSize(children);
			}
			if (this.mDrag != null)
			{
				this.mDrag.UpdateScrollbars(true);
				this.mDrag.RestrictWithinBounds(true);
			}
			else if (this.mPanel != null)
			{
				this.mPanel.ConstrainTargetToBounds(transform, true);
			}
			if (this.onReposition != null)
			{
				this.onReposition();
			}
		}
		else
		{
			this.repositionNow = true;
		}
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00003116 File Offset: 0x00001316
	private void Start()
	{
		this.mStarted = true;
		if (this.keepWithinPanel)
		{
			this.mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
			this.mDrag = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		}
		this.Reposition();
	}

	// Token: 0x06000144 RID: 324 RVA: 0x00003152 File Offset: 0x00001352
	private void LateUpdate()
	{
		if (this.repositionNow)
		{
			this.repositionNow = false;
			this.Reposition();
		}
	}

	// Token: 0x04000162 RID: 354
	public int columns;

	// Token: 0x04000163 RID: 355
	public UITable.Direction direction;

	// Token: 0x04000164 RID: 356
	public Vector2 padding = Vector2.zero;

	// Token: 0x04000165 RID: 357
	public bool sorted;

	// Token: 0x04000166 RID: 358
	public bool hideInactive = true;

	// Token: 0x04000167 RID: 359
	public bool repositionNow;

	// Token: 0x04000168 RID: 360
	public bool keepWithinPanel;

	// Token: 0x04000169 RID: 361
	public UITable.OnReposition onReposition;

	// Token: 0x0400016A RID: 362
	private UIPanel mPanel;

	// Token: 0x0400016B RID: 363
	private UIDraggablePanel mDrag;

	// Token: 0x0400016C RID: 364
	private bool mStarted;

	// Token: 0x0400016D RID: 365
	private List<Transform> mChildren = new List<Transform>();

	// Token: 0x0200003B RID: 59
	public enum Direction
	{
		// Token: 0x0400016F RID: 367
		Down,
		// Token: 0x04000170 RID: 368
		Up
	}

	// Token: 0x0200003C RID: 60
	// (Invoke) Token: 0x06000146 RID: 326
	public delegate void OnReposition();
}
