using System;
using System.Collections.Generic;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020001E3 RID: 483
public class ItemListPopupDialog : BasePopupDialog
{
	// Token: 0x06000D99 RID: 3481 RVA: 0x0000A02D File Offset: 0x0000822D
	private ItemListPopupDialog()
	{
		this._cancelCaption = LocalizedStrings.OkCaps;
		this._alertType = PopupSystem.AlertType.Cancel;
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x0005EE44 File Offset: 0x0005D044
	public ItemListPopupDialog(string title, string text, List<IUnityItem> items, Action callbackOk = null) : this()
	{
		this.Title = title;
		this.Text = text;
		this._size.y = 320f;
		this._items = new List<IUnityItem>(items);
		foreach (IUnityItem unityItem in this._items)
		{
			if (unityItem != null)
			{
				Singleton<InventoryManager>.Instance.HighlightItem(unityItem.View.ID, true);
			}
		}
		if (items.Count > 1)
		{
			this._callbackOk = callbackOk;
			this._alertType = PopupSystem.AlertType.OK;
			this._actionType = PopupSystem.ActionType.Positive;
			this._okCaption = LocalizedStrings.OkCaps;
		}
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x0005EF10 File Offset: 0x0005D110
	public ItemListPopupDialog(IUnityItem item, string customMessage = "") : this()
	{
		this.Title = LocalizedStrings.NewItem;
		this._customMessage = customMessage;
		if (item != null)
		{
			this._items = new List<IUnityItem>
			{
				item
			};
			foreach (IUnityItem unityItem in this._items)
			{
				if (unityItem != null)
				{
					Singleton<InventoryManager>.Instance.HighlightItem(unityItem.View.ID, true);
				}
			}
			if (item.View.ItemType == UberstrikeItemType.Gear || item.View.ItemType == UberstrikeItemType.Weapon || item.View.ItemType == UberstrikeItemType.QuickUse)
			{
				this._alertType = PopupSystem.AlertType.OKCancel;
				this._actionType = PopupSystem.ActionType.Positive;
				this._okCaption = LocalizedStrings.Equip;
				this._cancelCaption = LocalizedStrings.NotNow;
				this._callbackOk = delegate()
				{
					IUnityItem unityItem2 = this._items[0];
					if (unityItem2 != null)
					{
						Singleton<InventoryManager>.Instance.EquipItem(unityItem2);
					}
				};
				this._callbackCancel = delegate()
				{
				};
			}
		}
		else
		{
			this._items = new List<IUnityItem>();
		}
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x0005F050 File Offset: 0x0005D250
	protected override void DrawPopupWindow()
	{
		if (this._items.Count == 0)
		{
			GUI.Label(new Rect(17f, 115f, this._size.x - 34f, 20f), "There are no items", BlueStonez.label_interparkbold_13pt);
		}
		else if (this._items.Count == 1)
		{
			if (this._items[0] != null)
			{
				this._items[0].DrawIcon(new Rect(this._size.x * 0.5f - 32f, 55f, 64f, 64f));
				GUI.Label(new Rect(17f, 115f, this._size.x - 34f, 20f), this._items[0].Name, BlueStonez.label_interparkbold_13pt);
				if (this._items[0].View != null)
				{
					string text = this._items[0].View.Description + this._customMessage;
					if (string.IsNullOrEmpty(text))
					{
						text = "No description available.";
					}
					GUI.Label(new Rect(17f, 140f, this._size.x - 34f, 40f), text, BlueStonez.label_interparkmed_11pt);
				}
			}
		}
		else if (this._items.Count <= 4)
		{
			this.DrawItemsInColumns(2);
		}
		else if (this._items.Count <= 6)
		{
			this.DrawItemsInColumns(3);
		}
		else if (this._items.Count <= 8)
		{
			this.DrawItemsInColumns(4);
		}
		else
		{
			GUI.Label(new Rect(17f, 150f, this._size.x - 34f, 20f), this.Text, BlueStonez.label_interparkbold_13pt);
		}
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x0005F250 File Offset: 0x0005D450
	private void DrawItemsInColumns(int columns)
	{
		int num = 0;
		int num2 = 0;
		float num3 = this._size.x * 0.5f - (float)(64 * columns) / 2f - (float)(15 * (columns - 1)) / 2f;
		foreach (IUnityItem unityItem in this._items)
		{
			if (unityItem != null)
			{
				unityItem.DrawIcon(new Rect(num3 + (float)(num % columns * 79), (float)(55 + num2 * 70), 48f, 48f));
				GUI.Label(new Rect(num3 + (float)(num % columns * 79) - 7f, (float)(110 + num2 * 70), 79f, 20f), unityItem.Name, BlueStonez.label_interparkmed_11pt);
			}
			num++;
			num2 = num / columns;
		}
		GUI.Label(new Rect(17f, 220f, this._size.x - 34f, 40f), this.Text, BlueStonez.label_interparkmed_11pt);
	}

	// Token: 0x04000CD8 RID: 3288
	private List<IUnityItem> _items;

	// Token: 0x04000CD9 RID: 3289
	private string _customMessage = string.Empty;
}
