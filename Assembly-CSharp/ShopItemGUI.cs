using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020001FB RID: 507
public class ShopItemGUI : BaseItemGUI
{
	// Token: 0x06000E2B RID: 3627 RVA: 0x0000A57F File Offset: 0x0000877F
	public ShopItemGUI(IUnityItem item, BuyingLocationType location) : base(item, location, BuyingRecommendationType.None)
	{
		this._pointsPrice = ShopUtils.GetLowestPrice(item, UberStrikeCurrencyType.Points);
		this._creditsPrice = ShopUtils.GetLowestPrice(item, UberStrikeCurrencyType.Credits);
	}

	// Token: 0x06000E2C RID: 3628 RVA: 0x000610F0 File Offset: 0x0005F2F0
	public override void Draw(Rect rect, bool selected)
	{
		GUI.BeginGroup(rect);
		base.DrawIcon(new Rect(4f, 4f, 48f, 48f));
		base.DrawArmorOverlay();
		base.DrawPromotionalTag();
		base.DrawName(new Rect(63f, 10f, 220f, 20f));
		base.DrawLevelRequirement();
		if (Singleton<LoadoutManager>.Instance.IsItemEquipped(this.Item.View.ID))
		{
			base.DrawUnequipButton(new Rect(rect.width - 52f, 4f, 52f, 52f), LocalizedStrings.Unequip);
		}
		else if (Singleton<InventoryManager>.Instance.Contains(this.Item.View.ID))
		{
			if (this.Item.Equippable)
			{
				base.DrawEquipButton(new Rect(rect.width - 52f, 4f, 52f, 52f), LocalizedStrings.Equip);
			}
			else
			{
				base.DrawBuyButton(new Rect(rect.width - 52f, 4f, 52f, 52f), LocalizedStrings.Buy, ShopArea.Shop);
			}
		}
		else if (PlayerDataManager.PlayerLevel < this.Item.View.LevelLock)
		{
			GUI.color = new Color(1f, 1f, 1f, 0.1f);
			GUI.DrawTexture(new Rect(rect.width - 52f, 4f, 52f, 52f), ShopIcons.BlankItemFrame);
			GUI.color = Color.white;
		}
		else
		{
			if (this.Item.View.ItemType == UberstrikeItemType.Gear && GameState.Current.MatchState.CurrentStateId == GameStateId.None)
			{
				base.DrawTryButton(new Rect(rect.width - 106f, 4f, 52f, 52f));
			}
			base.DrawPrice(new Rect(63f, 30f, 220f, 20f), this._pointsPrice, this._creditsPrice);
			base.DrawBuyButton(new Rect(rect.width - 52f, 4f, 52f, 52f), LocalizedStrings.Buy, ShopArea.Shop);
		}
		base.DrawGrayLine(rect);
		GUI.EndGroup();
	}

	// Token: 0x04000D1D RID: 3357
	private ItemPrice _pointsPrice;

	// Token: 0x04000D1E RID: 3358
	private ItemPrice _creditsPrice;
}
