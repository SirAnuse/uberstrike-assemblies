using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000028 RID: 40
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Grid")]
public class UIGrid : MonoBehaviour
{
	// Token: 0x060000D4 RID: 212 RVA: 0x00002D13 File Offset: 0x00000F13
	private void Start()
	{
		this.mStarted = true;
		this.Reposition();
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00002D22 File Offset: 0x00000F22
	private void Update()
	{
		if (this.repositionNow)
		{
			this.repositionNow = false;
			this.Reposition();
		}
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00002D3C File Offset: 0x00000F3C
	public static int SortByName(Transform a, Transform b)
	{
		return string.Compare(a.name, b.name);
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x000197D0 File Offset: 0x000179D0
	public void Reposition()
	{
		if (!this.mStarted)
		{
			this.repositionNow = true;
			return;
		}
		Transform transform = base.transform;
		int num = 0;
		int num2 = 0;
		if (this.sorted)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child && (!this.hideInactive || NGUITools.GetActive(child.gameObject)))
				{
					list.Add(child);
				}
			}
			list.Sort(new Comparison<Transform>(UIGrid.SortByName));
			int j = 0;
			int count = list.Count;
			while (j < count)
			{
				Transform transform2 = list[j];
				if (NGUITools.GetActive(transform2.gameObject) || !this.hideInactive)
				{
					float z = transform2.localPosition.z;
					transform2.localPosition = ((this.arrangement != UIGrid.Arrangement.Horizontal) ? new Vector3(this.cellWidth * (float)num2, -this.cellHeight * (float)num, z) : new Vector3(this.cellWidth * (float)num, -this.cellHeight * (float)num2, z));
					if (++num >= this.maxPerLine && this.maxPerLine > 0)
					{
						num = 0;
						num2++;
					}
				}
				j++;
			}
		}
		else
		{
			for (int k = 0; k < transform.childCount; k++)
			{
				Transform child2 = transform.GetChild(k);
				if (NGUITools.GetActive(child2.gameObject) || !this.hideInactive)
				{
					float z2 = child2.localPosition.z;
					child2.localPosition = ((this.arrangement != UIGrid.Arrangement.Horizontal) ? new Vector3(this.cellWidth * (float)num2, -this.cellHeight * (float)num, z2) : new Vector3(this.cellWidth * (float)num, -this.cellHeight * (float)num2, z2));
					if (++num >= this.maxPerLine && this.maxPerLine > 0)
					{
						num = 0;
						num2++;
					}
				}
			}
		}
		UIDraggablePanel uidraggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		if (uidraggablePanel != null)
		{
			uidraggablePanel.UpdateScrollbars(true);
		}
	}

	// Token: 0x040000FF RID: 255
	public UIGrid.Arrangement arrangement;

	// Token: 0x04000100 RID: 256
	public int maxPerLine;

	// Token: 0x04000101 RID: 257
	public float cellWidth = 200f;

	// Token: 0x04000102 RID: 258
	public float cellHeight = 200f;

	// Token: 0x04000103 RID: 259
	public bool repositionNow;

	// Token: 0x04000104 RID: 260
	public bool sorted;

	// Token: 0x04000105 RID: 261
	public bool hideInactive = true;

	// Token: 0x04000106 RID: 262
	private bool mStarted;

	// Token: 0x02000029 RID: 41
	public enum Arrangement
	{
		// Token: 0x04000108 RID: 264
		Horizontal,
		// Token: 0x04000109 RID: 265
		Vertical
	}
}
