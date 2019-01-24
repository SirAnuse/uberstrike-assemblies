using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x02000169 RID: 361
public class PackItemPriceGUI : ItemPriceGUI
{
	// Token: 0x060009A9 RID: 2473 RVA: 0x0003D010 File Offset: 0x0003B210
	public PackItemPriceGUI(IUnityItem item, Action<ItemPrice> onPriceSelected) : base(item.View.LevelLock, onPriceSelected)
	{
		this._prices = new List<ItemPrice>(item.View.Prices);
		if (this._prices.Count > 1)
		{
			this._onPriceSelected(this._prices[1]);
		}
		else
		{
			this._onPriceSelected(this._prices[0]);
		}
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x0003D08C File Offset: 0x0003B28C
	public override void Draw(Rect rect)
	{
		GUI.BeginGroup(rect);
		int num = 30;
		GUI.Label(new Rect(0f, 0f, rect.width, 16f), "Purchase Options", BlueStonez.label_interparkbold_16pt_left);
		foreach (ItemPrice itemPrice in this._prices)
		{
			GUIContent guicontent = new GUIContent(itemPrice.Amount + " Uses");
			if (this._levelLocked && itemPrice.Currency == UberStrikeCurrencyType.Points)
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
		base.Height = num;
		GUI.EndGroup();
	}

	// Token: 0x040009CA RID: 2506
	private List<ItemPrice> _prices;
}
