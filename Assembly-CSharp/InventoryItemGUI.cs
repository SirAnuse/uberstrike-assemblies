using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020001F4 RID: 500
public class InventoryItemGUI : BaseItemGUI
{
	// Token: 0x06000E1B RID: 3611 RVA: 0x0000A4DC File Offset: 0x000086DC
	public InventoryItemGUI(InventoryItem item, BuyingLocationType location) : base(item.Item, location, BuyingRecommendationType.None)
	{
		this.InventoryItem = item;
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x06000E1C RID: 3612 RVA: 0x0000A4F3 File Offset: 0x000086F3
	// (set) Token: 0x06000E1D RID: 3613 RVA: 0x0000A4FB File Offset: 0x000086FB
	public InventoryItem InventoryItem { get; private set; }

	// Token: 0x06000E1E RID: 3614 RVA: 0x00060AA4 File Offset: 0x0005ECA4
	public override void Draw(Rect rect, bool selected)
	{
		this.DrawHighlightedBackground(rect);
		GUI.BeginGroup(rect);
		base.DrawIcon(new Rect(4f, 4f, 48f, 48f));
		base.DrawName(new Rect(63f, 10f, 220f, 20f));
		this.DrawDaysRemaining(new Rect(63f, 30f, 220f, 20f));
		if (this.Item.View.ID == 1294)
		{
			base.DrawUseButton(new Rect(rect.width - 50f, 7f, 46f, 46f));
		}
		else if (this.Item.Equippable && (this.InventoryItem.IsPermanent || this.InventoryItem.DaysRemaining > 0))
		{
			base.DrawEquipButton(new Rect(rect.width - 50f, 7f, 46f, 46f), LocalizedStrings.Equip);
		}
		else if (this.Item.View.IsForSale)
		{
			if (!this.InventoryItem.IsPermanent)
			{
				base.DrawBuyButton(new Rect(rect.width - 50f, 7f, 46f, 46f), LocalizedStrings.Renew, ShopArea.Inventory);
			}
			else if (this.InventoryItem.AmountRemaining >= 0)
			{
				base.DrawBuyButton(new Rect(rect.width - 50f, 7f, 46f, 46f), LocalizedStrings.Buy, ShopArea.Inventory);
			}
		}
		base.DrawGrayLine(rect);
		if (selected)
		{
			GUI.color = new Color(1f, 1f, 1f, 0.5f);
			if (this.Item.View.ItemType == UberstrikeItemType.Weapon)
			{
				GUI.Label(new Rect(12f, 60f, 32f, 32f), UberstrikeIconsHelper.GetIconForItemClass(this.Item.View.ItemClass), GUIStyle.none);
			}
			else if (this.Item.View.ItemType == UberstrikeItemType.Gear)
			{
				GUI.Label(new Rect(12f, 60f, 32f, 32f), UberstrikeIconsHelper.GetIconForItemClass(this.Item.View.ItemClass), GUIStyle.none);
			}
			GUI.color = Color.white;
			base.DrawDescription(new Rect(55f, 60f, 255f, 52f));
			if (base.DetailGUI != null)
			{
				base.DetailGUI.Draw();
			}
		}
		GUI.EndGroup();
	}

	// Token: 0x06000E1F RID: 3615 RVA: 0x00060D68 File Offset: 0x0005EF68
	public void DrawHighlightedBackground(Rect rect)
	{
		if (this.InventoryItem.IsHighlighted)
		{
			GUI.color = ColorConverter.RgbaToColor(255f, 255f, 255f, 20f * GUITools.FastSinusPulse);
			GUI.DrawTexture(rect, UberstrikeIconsHelper.White);
			GUI.color = Color.white;
		}
	}

	// Token: 0x06000E20 RID: 3616 RVA: 0x00060DC0 File Offset: 0x0005EFC0
	public void DrawDaysRemaining(Rect rect)
	{
		bool flag = true;
		Color color = Color.white;
		string text = string.Empty;
		if (this.InventoryItem.AmountRemaining >= 0)
		{
			if (this.InventoryItem.AmountRemaining == 1)
			{
				text = this.InventoryItem.AmountRemaining + " use remaining";
			}
			else
			{
				text = this.InventoryItem.AmountRemaining + " uses remaining";
			}
			flag = false;
		}
		else if (this.InventoryItem.IsPermanent)
		{
			text = LocalizedStrings.Permanent;
		}
		else if (this.InventoryItem.DaysRemaining > 1 && this.InventoryItem.DaysRemaining < 5)
		{
			color = ColorScheme.UberStrikeYellow;
			text = string.Format("{0} {1}{2}", this.InventoryItem.DaysRemaining.ToString(), LocalizedStrings.Day, (this.InventoryItem.DaysRemaining != 1) ? "s" : string.Empty);
		}
		else if (this.InventoryItem.DaysRemaining == 1)
		{
			color = ColorScheme.UberStrikeYellow;
			text = LocalizedStrings.LastDay;
		}
		else if (this.InventoryItem.DaysRemaining <= 0)
		{
			color = ColorScheme.UberStrikeRed;
			text = LocalizedStrings.Expired;
		}
		else
		{
			text = string.Format("{0} {1}{2}", this.InventoryItem.DaysRemaining.ToString(), LocalizedStrings.Day, (this.InventoryItem.DaysRemaining != 1) ? "s" : string.Empty);
		}
		if (flag)
		{
			GUI.DrawTexture(new Rect(rect.x, rect.y, 16f, 16f), ShopIcons.ItemexpirationIcon);
		}
		GUI.color = color;
		GUI.Label(new Rect(rect.x + (float)((!flag) ? 0 : 20), rect.y + 3f, rect.width - 20f, 16f), text, BlueStonez.label_interparkmed_11pt_left);
		GUI.color = Color.white;
	}
}
