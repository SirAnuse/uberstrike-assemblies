using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x0200025F RID: 607
public class ShopItemGrid
{
	// Token: 0x060010D2 RID: 4306 RVA: 0x00067564 File Offset: 0x00065764
	public ShopItemGrid(List<BundleItemView> items, int credits = 0, int points = 0)
	{
		this._items = new List<ShopItemView>(items.Count + 2);
		foreach (BundleItemView itemView in items)
		{
			this._items.Add(new ShopItemView(itemView));
		}
		if (credits > 0)
		{
			this._items.Add(new ShopItemView(UberStrikeCurrencyType.Credits, credits));
		}
		if (points > 0)
		{
			this._items.Add(new ShopItemView(UberStrikeCurrencyType.Points, points));
		}
	}

	// Token: 0x060010D3 RID: 4307 RVA: 0x0006761C File Offset: 0x0006581C
	public ShopItemGrid(List<ShopItemView> items, int credits = 0, int points = 0)
	{
		this._items = items;
		if (credits > 0)
		{
			this._items.Add(new ShopItemView(UberStrikeCurrencyType.Credits, credits));
		}
		if (points > 0)
		{
			this._items.Add(new ShopItemView(UberStrikeCurrencyType.Points, points));
		}
	}

	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x060010D4 RID: 4308 RVA: 0x0000BAF9 File Offset: 0x00009CF9
	// (set) Token: 0x060010D5 RID: 4309 RVA: 0x0000BB01 File Offset: 0x00009D01
	public List<bool> HighlightState { get; set; }

	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x060010D6 RID: 4310 RVA: 0x0000BB0A File Offset: 0x00009D0A
	// (set) Token: 0x060010D7 RID: 4311 RVA: 0x0000BB12 File Offset: 0x00009D12
	public bool Show { get; set; }

	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060010D8 RID: 4312 RVA: 0x0000BB1B File Offset: 0x00009D1B
	public List<ShopItemView> Items
	{
		get
		{
			return this._items;
		}
	}

	// Token: 0x060010D9 RID: 4313 RVA: 0x00067674 File Offset: 0x00065874
	public void Draw(Rect rect)
	{
		float num = rect.width / 6f;
		int num2 = this._items.Count / 6 + ((this._items.Count % 6 <= 0) ? 0 : 1);
		List<string> list = new List<string>(this._items.Count);
		this.offset = ((!this.Show) ? Mathf.Lerp(this.offset, (float)(-(float)num2) * num, Time.deltaTime * 5f) : Mathf.Lerp(this.offset, 0f, Time.deltaTime * 5f));
		GUI.BeginGroup(rect);
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				int num3 = i * 6 + j;
				Rect rect2 = new Rect((float)j * num, rect.height - (float)(i + 1) * num - this.offset, num, num);
				if (num3 < this._items.Count)
				{
					if (this.HighlightState != null)
					{
						if (this.HighlightState[num3])
						{
							this.DrawIcon(rect2, this._items[num3].UnityItem, BlueStonez.item_slot_small);
							GUI.color = GUI.color.SetAlpha(GUITools.FastSinusPulse);
							GUI.DrawTexture(rect2, ShopIcons.ItemSlotSelected);
							GUI.color = Color.white;
							if (AutoMonoBehaviour<ItemToolTip>.Instance != null && this.Show && (rect2.Contains(Event.current.mousePosition) || ApplicationDataManager.IsMobile) && this.offset < num)
							{
								AutoMonoBehaviour<ItemToolTip>.Instance.SetItem(this._items[num3].UnityItem, rect2, PopupViewSide.Top, -1, this._items[num3].Duration);
							}
						}
						else
						{
							GUITools.PushGUIState();
							GUI.enabled = false;
							this.DrawIcon(rect2, this._items[num3].UnityItem, BlueStonez.item_slot_alpha);
							GUITools.PopGUIState();
							list.Add(this._items[num3].UnityItem.View.PrefabName);
						}
					}
					else
					{
						this.DrawIcon(rect2, this._items[num3].UnityItem, BlueStonez.item_slot_alpha);
						if (AutoMonoBehaviour<ItemToolTip>.Instance != null && this.Show && rect2.Contains(Event.current.mousePosition) && this.offset < num)
						{
							AutoMonoBehaviour<ItemToolTip>.Instance.SetItem(this._items[num3].UnityItem, rect2, PopupViewSide.Top, -1, this._items[num3].Duration);
						}
					}
				}
				else
				{
					GUITools.PushGUIState();
					GUI.enabled = false;
					GUI.Label(rect2, GUIContent.none, BlueStonez.item_slot_alpha);
					GUITools.PopGUIState();
				}
			}
		}
		GUI.EndGroup();
	}

	// Token: 0x060010DA RID: 4314 RVA: 0x0000BB23 File Offset: 0x00009D23
	private void DrawIcon(Rect position, IUnityItem item, GUIStyle style)
	{
		if (item != null)
		{
			GUI.Label(position, GUIContent.none, style);
			item.DrawIcon(position);
		}
		else
		{
			GUI.Label(position, UberstrikeIconsHelper.White, style);
		}
	}

	// Token: 0x04000E2D RID: 3629
	protected const int MAX_COLUMN = 6;

	// Token: 0x04000E2E RID: 3630
	protected List<ShopItemView> _items;

	// Token: 0x04000E2F RID: 3631
	private float offset = -300f;
}
