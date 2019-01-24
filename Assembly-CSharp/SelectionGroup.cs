using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003F8 RID: 1016
public class SelectionGroup<T> where T : IComparable
{
	// Token: 0x06001D41 RID: 7489 RVA: 0x0001377C File Offset: 0x0001197C
	public SelectionGroup()
	{
		this.GuiContent = new GUIContent[0];
	}

	// Token: 0x14000025 RID: 37
	// (add) Token: 0x06001D42 RID: 7490 RVA: 0x0001379B File Offset: 0x0001199B
	// (remove) Token: 0x06001D43 RID: 7491 RVA: 0x000137B4 File Offset: 0x000119B4
	public event Action<T> OnSelectionChange;

	// Token: 0x17000667 RID: 1639
	// (get) Token: 0x06001D44 RID: 7492 RVA: 0x000137CD File Offset: 0x000119CD
	// (set) Token: 0x06001D45 RID: 7493 RVA: 0x000137D5 File Offset: 0x000119D5
	public int Index { get; private set; }

	// Token: 0x17000668 RID: 1640
	// (get) Token: 0x06001D46 RID: 7494 RVA: 0x000137DE File Offset: 0x000119DE
	// (set) Token: 0x06001D47 RID: 7495 RVA: 0x000137E6 File Offset: 0x000119E6
	public T Current { get; private set; }

	// Token: 0x17000669 RID: 1641
	// (get) Token: 0x06001D48 RID: 7496 RVA: 0x000137EF File Offset: 0x000119EF
	public int Length
	{
		get
		{
			return this._data.Count;
		}
	}

	// Token: 0x1700066A RID: 1642
	// (get) Token: 0x06001D49 RID: 7497 RVA: 0x000137FC File Offset: 0x000119FC
	// (set) Token: 0x06001D4A RID: 7498 RVA: 0x00013804 File Offset: 0x00011A04
	public GUIContent[] GuiContent { get; private set; }

	// Token: 0x1700066B RID: 1643
	// (get) Token: 0x06001D4B RID: 7499 RVA: 0x0001380D File Offset: 0x00011A0D
	// (set) Token: 0x06001D4C RID: 7500 RVA: 0x00013815 File Offset: 0x00011A15
	public T[] Items { get; private set; }

	// Token: 0x06001D4D RID: 7501 RVA: 0x00091D50 File Offset: 0x0008FF50
	public void SetIndex(int index)
	{
		this.Index = index;
		if (index >= 0 && index < this._data.Count)
		{
			this.Current = this._data[index].Item;
		}
		else
		{
			this.Current = default(T);
		}
		if (this.OnSelectionChange != null)
		{
			this.OnSelectionChange(this.Current);
		}
	}

	// Token: 0x06001D4E RID: 7502 RVA: 0x00091DC4 File Offset: 0x0008FFC4
	public void Select(T item)
	{
		this.Index = this._data.FindIndex((SelectionGroup<T>.Pair i) => i.Item.CompareTo(item) == 0);
		this.Current = item;
		if (this.OnSelectionChange != null)
		{
			this.OnSelectionChange(this.Current);
		}
	}

	// Token: 0x06001D4F RID: 7503 RVA: 0x00091E24 File Offset: 0x00090024
	public void Add(T item, GUIContent content)
	{
		this._data.Add(new SelectionGroup<T>.Pair
		{
			Item = item,
			Content = content
		});
		this.GuiContent = this._data.ConvertAll<GUIContent>((SelectionGroup<T>.Pair p) => p.Content).ToArray();
		this.Items = this._data.ConvertAll<T>((SelectionGroup<T>.Pair p) => p.Item).ToArray();
	}

	// Token: 0x040019C1 RID: 6593
	private List<SelectionGroup<T>.Pair> _data = new List<SelectionGroup<T>.Pair>();

	// Token: 0x020003F9 RID: 1017
	private class Pair
	{
		// Token: 0x040019C9 RID: 6601
		public T Item;

		// Token: 0x040019CA RID: 6602
		public GUIContent Content;
	}
}
