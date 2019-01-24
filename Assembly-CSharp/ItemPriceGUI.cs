using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x02000168 RID: 360
public abstract class ItemPriceGUI
{
	// Token: 0x060009A2 RID: 2466 RVA: 0x0003CEC0 File Offset: 0x0003B0C0
	public ItemPriceGUI(int levelLock, Action<ItemPrice> onPriceSelected)
	{
		if (levelLock > PlayerDataManager.PlayerLevel)
		{
			this._levelLocked = true;
			this._tooltip = string.Format("Not so fast, squirt!\n\nYou need to be Level {0} to buy this item using points.\n\nGet fragging!", levelLock);
		}
		this._onPriceSelected = delegate(ItemPrice price)
		{
			this._selectedPrice = price;
		};
		this._onPriceSelected = (Action<ItemPrice>)Delegate.Combine(this._onPriceSelected, onPriceSelected);
	}

	// Token: 0x170002AF RID: 687
	// (get) Token: 0x060009A3 RID: 2467 RVA: 0x000080AF File Offset: 0x000062AF
	// (set) Token: 0x060009A4 RID: 2468 RVA: 0x000080B7 File Offset: 0x000062B7
	public int Height { get; protected set; }

	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x060009A5 RID: 2469 RVA: 0x000080C0 File Offset: 0x000062C0
	public ItemPrice SelectedPriceOption
	{
		get
		{
			return this._selectedPrice;
		}
	}

	// Token: 0x060009A6 RID: 2470
	public abstract void Draw(Rect rect);

	// Token: 0x060009A7 RID: 2471 RVA: 0x0003CF30 File Offset: 0x0003B130
	protected int DrawPrice(ItemPrice price, float width, int y)
	{
		string text = (price.Price <= 0) ? " FREE" : string.Format(" {0:N0}", price.Price);
		Texture image = (price.Currency != UberStrikeCurrencyType.Points) ? ShopIcons.IconCredits20x20 : ShopIcons.IconPoints20x20;
		GUIContent content = new GUIContent(text, image);
		GUI.Label(new Rect(width, (float)y, width, 20f), content, BlueStonez.label_itemdescription);
		if (price.Price > 0 && price.Discount > 0)
		{
			string text2 = string.Format(LocalizedStrings.DiscountPercentOff, price.Discount);
			GUI.color = ColorScheme.UberStrikeYellow;
			GUI.Label(new Rect(width + 80f, (float)(y + 5), width, 20f), text2, BlueStonez.label_itemdescription);
			GUI.color = Color.white;
		}
		return y += 24;
	}

	// Token: 0x040009C5 RID: 2501
	protected bool _levelLocked;

	// Token: 0x040009C6 RID: 2502
	protected string _tooltip = string.Empty;

	// Token: 0x040009C7 RID: 2503
	protected ItemPrice _selectedPrice;

	// Token: 0x040009C8 RID: 2504
	protected Action<ItemPrice> _onPriceSelected;
}
