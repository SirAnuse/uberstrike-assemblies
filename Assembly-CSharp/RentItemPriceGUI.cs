using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x0200016A RID: 362
public class RentItemPriceGUI : ItemPriceGUI
{
	// Token: 0x060009AB RID: 2475 RVA: 0x0003D1C8 File Offset: 0x0003B3C8
	public RentItemPriceGUI(IUnityItem item, Action<ItemPrice> onPriceSelected) : base(item.View.LevelLock, onPriceSelected)
	{
		this._prices = new List<ItemPrice>(item.View.Prices);
		if (this._prices.Count > 0)
		{
			this._onPriceSelected(this._prices[this._prices.Count - 1]);
		}
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x0003D234 File Offset: 0x0003B434
	public override void Draw(Rect rect)
	{
		GUI.BeginGroup(rect);
		int num = 30;
		if (this._prices.Exists((ItemPrice p) => p.Duration != BuyingDurationType.Permanent))
		{
			GUI.Label(new Rect(0f, 0f, rect.width, 16f), "Limited Use", BlueStonez.label_interparkbold_16pt_left);
			foreach (ItemPrice itemPrice in this._prices)
			{
				if (itemPrice.Duration != BuyingDurationType.Permanent)
				{
					GUIContent guicontent = new GUIContent(ShopUtils.PrintDuration(itemPrice.Duration));
					if (itemPrice.Currency == UberStrikeCurrencyType.Points && this._levelLocked)
					{
						GUI.enabled = false;
						guicontent.tooltip = this._tooltip;
					}
					if (GUI.Toggle(new Rect(0f, (float)num, rect.width, 20f), this._selectedPrice == itemPrice, guicontent, BlueStonez.toggle) && itemPrice != this._selectedPrice)
					{
						this._onPriceSelected(itemPrice);
					}
					num = base.DrawPrice(itemPrice, rect.width * 0.5f, num);
					GUI.enabled = true;
				}
			}
			num += 20;
		}
		if (this._prices.Exists((ItemPrice p) => p.Duration == BuyingDurationType.Permanent))
		{
			GUI.Label(new Rect(0f, (float)num, rect.width, 16f), "Unlimited Use", BlueStonez.label_interparkbold_16pt_left);
			num += 30;
			foreach (ItemPrice itemPrice2 in this._prices)
			{
				if (itemPrice2.Duration == BuyingDurationType.Permanent)
				{
					string empty = string.Empty;
					if (GUI.Toggle(new Rect(0f, (float)num, rect.width, 20f), this._selectedPrice == itemPrice2, new GUIContent(LocalizedStrings.Permanent, empty), BlueStonez.toggle) && itemPrice2 != this._selectedPrice)
					{
						this._onPriceSelected(itemPrice2);
					}
					num = base.DrawPrice(itemPrice2, rect.width * 0.5f, num);
				}
			}
		}
		base.Height = num;
		GUI.EndGroup();
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x0003D4D0 File Offset: 0x0003B6D0
	private string GetRentDuration(BuyingDurationType duration)
	{
		string result = string.Empty;
		if (duration != BuyingDurationType.OneDay)
		{
			if (duration == BuyingDurationType.SevenDays)
			{
				result = LocalizedStrings.SevenDays;
			}
		}
		else
		{
			result = LocalizedStrings.OneDay;
		}
		return result;
	}

	// Token: 0x040009CB RID: 2507
	private List<ItemPrice> _prices;
}
