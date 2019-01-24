using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020001C7 RID: 455
public class BuyPanelGUI : PanelGuiBase
{
	// Token: 0x06000C8F RID: 3215 RVA: 0x0005494C File Offset: 0x00052B4C
	private void OnGUI()
	{
		GUI.skin = BlueStonez.Skin;
		GUI.depth = 3;
		this.Height = 100 + this._price.Height + 100;
		this.DrawUnityItem(new Rect((float)((Screen.width - 300) / 2), (float)((Screen.height - this.Height) / 2), 300f, (float)this.Height));
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000C90 RID: 3216 RVA: 0x000549BC File Offset: 0x00052BBC
	private void DrawUnityItem(Rect rect)
	{
		GUI.BeginGroup(rect, GUIContent.none, BlueStonez.window_standard_grey38);
		int num = 20;
		if (ApplicationDataManager.Channel == ChannelType.Android || ApplicationDataManager.Channel == ChannelType.IPad || ApplicationDataManager.Channel == ChannelType.IPhone)
		{
			num = 45;
		}
		if (GUI.Button(new Rect(rect.width - (float)num, 0f, (float)num, (float)num), "X", BlueStonez.friends_hidden_button))
		{
			this.Hide();
		}
		this.DrawTitle(new Rect(10f, 10f, rect.width - 20f, 100f));
		Rect rect2 = new Rect(30f, 110f, rect.width - 60f, rect.height - 100f);
		this.DrawPrice(rect2);
		this.DrawBuyButton(new Rect(0f, rect.height - 90f, rect.width, 90f));
		GUI.EndGroup();
		if (Event.current.type == EventType.MouseDown && !rect.Contains(Event.current.mousePosition))
		{
			this.Hide();
			Event.current.Use();
		}
	}

	// Token: 0x06000C91 RID: 3217 RVA: 0x00054AF0 File Offset: 0x00052CF0
	private void DrawTitle(Rect rect)
	{
		GUI.BeginGroup(rect);
		this._item.DrawIcon(new Rect(0f, 0f, 48f, 48f));
		float width = rect.width - 48f - 20f - 32f;
		GUI.Label(new Rect(58f, 0f, width, 48f), this._item.Name, BlueStonez.label_interparkmed_18pt_left_wrap);
		if (this._item.View.LevelLock > PlayerDataManager.PlayerLevel)
		{
			GUI.color = new Color(1f, 1f, 1f, 0.5f);
			int num = 0;
			if (ApplicationDataManager.Channel == ChannelType.Android || ApplicationDataManager.Channel == ChannelType.IPad || ApplicationDataManager.Channel == ChannelType.IPhone)
			{
				num = 25;
			}
			GUI.Label(new Rect(rect.width - 10f - 32f - (float)num, 8f, 32f, 32f), ShopIcons.BlankItemFrame);
			GUI.Label(new Rect(rect.width - 10f - 31f - (float)num, 16f, 24f, 24f), this._item.View.LevelLock.ToString(), BlueStonez.label_interparkmed_11pt);
			GUI.color = Color.white;
		}
		GUI.Label(new Rect(0f, 58f, rect.width, rect.height - 48f - 10f), this._item.View.Description, BlueStonez.label_itemdescription);
		GUI.EndGroup();
	}

	// Token: 0x06000C92 RID: 3218 RVA: 0x00009769 File Offset: 0x00007969
	private void DrawPrice(Rect rect)
	{
		this._price.Draw(rect);
	}

	// Token: 0x06000C93 RID: 3219 RVA: 0x00054CA0 File Offset: 0x00052EA0
	private void DrawBuyButton(Rect rect)
	{
		GUI.BeginGroup(rect);
		Rect position = new Rect((rect.width - 120f) / 2f, (rect.height - 30f) / 2f, 120f, 30f);
		GUITools.PushGUIState();
		GUI.enabled = (!BuyPanelGUI._isBuyingItem && this._price.SelectedPriceOption != null);
		if (GUI.Button(position, GUIContent.none, BlueStonez.buttongold_large) && !BuyPanelGUI._isBuyingItem)
		{
			BuyPanelGUI._isBuyingItem = true;
			BuyPanelGUI.BuyItem(this._item, this._price.SelectedPriceOption, this._buyingLocation, this._buyingRecommendation, this._autoEquip);
		}
		GUITools.PopGUIState();
		Rect position2 = new Rect((rect.width - 120f) / 2f, (rect.height - 20f) / 2f, 120f, 20f);
		GUI.Label(position2, new GUIContent(this._priceTag, this._priceIcon), BlueStonez.label_interparkbold_13pt_black);
		GUI.EndGroup();
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x00054DBC File Offset: 0x00052FBC
	private void OnPriceOptionSelected(ItemPrice price)
	{
		this._priceTag = ((price.Price != 0) ? string.Format("{0:N0}", price.Price) : "FREE");
		this._priceIcon = ((price.Currency != UberStrikeCurrencyType.Points) ? ShopIcons.IconCredits20x20 : ShopIcons.IconPoints20x20);
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x00054E1C File Offset: 0x0005301C
	public static void BuyItem(IUnityItem item, ItemPrice price, BuyingLocationType buyingLocation = BuyingLocationType.Shop, BuyingRecommendationType recommendation = BuyingRecommendationType.Manual, bool autoEquip = false)
	{
		if (item.View.IsConsumable)
		{
			int id = item.View.ID;
			ShopWebServiceClient.BuyPack(id, PlayerDataManager.AuthToken, price.PackType, price.Currency, item.View.ItemType, buyingLocation, recommendation, delegate(int result)
			{
				BuyPanelGUI.HandleBuyItem(item, (BuyItemResult)result, autoEquip);
			}, delegate(Exception ex)
			{
				BuyPanelGUI._isBuyingItem = false;
				PanelManager.Instance.ClosePanel(PanelType.BuyItem);
			});
		}
		else
		{
			int id2 = item.View.ID;
			ShopWebServiceClient.BuyItem(id2, PlayerDataManager.AuthToken, price.Currency, price.Duration, item.View.ItemType, buyingLocation, recommendation, delegate(int result)
			{
				BuyPanelGUI.HandleBuyItem(item, (BuyItemResult)result, autoEquip);
			}, delegate(Exception ex)
			{
				BuyPanelGUI._isBuyingItem = false;
				PanelManager.Instance.ClosePanel(PanelType.BuyItem);
			});
		}
	}

	// Token: 0x06000C96 RID: 3222 RVA: 0x00054F20 File Offset: 0x00053120
	private static void HandleBuyItem(IUnityItem item, BuyItemResult result, bool autoEquip)
	{
		BuyPanelGUI._isBuyingItem = false;
		switch (result)
		{
		case BuyItemResult.OK:
			UnityRuntime.StartRoutine(Singleton<InventoryManager>.Instance.StartUpdateInventoryAndEquipNewItem(item, autoEquip));
			break;
		case BuyItemResult.DisableInShop:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.ThisItemCannotBeRented, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		default:
			if (result != BuyItemResult.InvalidLevel)
			{
				PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.DataError, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			}
			else
			{
				PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.YourLevelIsTooLowToBuyThisItem, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			}
			break;
		case BuyItemResult.DisableForRent:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.ThisItemCannotBeRented, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.DisableForPermanent:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.ThisItemCannotBePurchasedPermanently, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.DurationDisabled:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.ThisItemCannotBePurchasedForDuration, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.PackDisabled:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.ThisPackIsDisabled, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.IsNotForSale:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.ThisItemIsNotForSale, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.NotEnoughCurrency:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.YouDontHaveEnoughPointsOrCreditsToPurchaseThisItem, PopupSystem.AlertType.OKCancel, new Action(BuyPanelGUI.HandleWebServiceError), LocalizedStrings.OkCaps, new Action(ApplicationDataManager.OpenBuyCredits), "GET CREDITS");
			break;
		case BuyItemResult.InvalidMember:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.AccountIsInvalid, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.InvalidExpirationDate:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, string.Format(LocalizedStrings.YouCannotPurchaseThisItemForMoreThanNDays, item.View.MaxDurationDays), PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.AlreadyInInventory:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.YouAlreadyOwnThisItem, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.InvalidAmount:
		{
			int maxOwnableAmount = (item.View as UberStrikeItemQuickView).MaxOwnableAmount;
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, string.Format(LocalizedStrings.TheAmountYouTriedToPurchaseIsInvalid, maxOwnableAmount), PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		}
		case BuyItemResult.NoStockRemaining:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.ThisItemIsOutOfStock, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		case BuyItemResult.InvalidData:
			PopupSystem.ShowMessage(LocalizedStrings.ProblemBuyingItem, LocalizedStrings.InvalidData, PopupSystem.AlertType.OK, new Action(BuyPanelGUI.HandleWebServiceError));
			break;
		}
		PanelManager.Instance.ClosePanel(PanelType.BuyItem);
	}

	// Token: 0x06000C97 RID: 3223 RVA: 0x00003C87 File Offset: 0x00001E87
	private static void HandleWebServiceError()
	{
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x000551E0 File Offset: 0x000533E0
	public void SetItem(IUnityItem item, BuyingLocationType location, BuyingRecommendationType recommendation, bool autoEquip = false)
	{
		this._autoEquip = autoEquip;
		this._item = item;
		this._buyingLocation = location;
		this._buyingRecommendation = recommendation;
		BuyPanelGUI._isBuyingItem = false;
		if (item != null && item.View.Prices.Count > 0)
		{
			if (item.View.IsConsumable)
			{
				this._price = new PackItemPriceGUI(item, new Action<ItemPrice>(this.OnPriceOptionSelected));
			}
			else
			{
				this._price = new RentItemPriceGUI(item, new Action<ItemPrice>(this.OnPriceOptionSelected));
			}
		}
		else
		{
			Debug.LogError("Item is null or not for sale");
		}
	}

	// Token: 0x04000BDB RID: 3035
	private const int WIDTH = 300;

	// Token: 0x04000BDC RID: 3036
	private const int BORDER = 10;

	// Token: 0x04000BDD RID: 3037
	private const int TITLE_HEIGHT = 100;

	// Token: 0x04000BDE RID: 3038
	private int Height;

	// Token: 0x04000BDF RID: 3039
	private IUnityItem _item;

	// Token: 0x04000BE0 RID: 3040
	private ItemPriceGUI _price;

	// Token: 0x04000BE1 RID: 3041
	private bool _autoEquip;

	// Token: 0x04000BE2 RID: 3042
	private static bool _isBuyingItem;

	// Token: 0x04000BE3 RID: 3043
	private Texture _priceIcon;

	// Token: 0x04000BE4 RID: 3044
	private string _priceTag;

	// Token: 0x04000BE5 RID: 3045
	private BuyingLocationType _buyingLocation;

	// Token: 0x04000BE6 RID: 3046
	private BuyingRecommendationType _buyingRecommendation;
}
