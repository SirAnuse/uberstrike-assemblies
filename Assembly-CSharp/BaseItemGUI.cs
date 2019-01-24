using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020001F0 RID: 496
public abstract class BaseItemGUI : IShopItemGUI
{
	// Token: 0x06000DF4 RID: 3572 RVA: 0x000602C4 File Offset: 0x0005E4C4
	public BaseItemGUI(IUnityItem item, BuyingLocationType location, BuyingRecommendationType recommendation)
	{
		this._location = location;
		this._recommendation = recommendation;
		if (item != null)
		{
			this.Item = item;
			if (this.Item.View.ItemType == UberstrikeItemType.Weapon)
			{
				this.DetailGUI = new WeaponItemDetailGUI(item.View as UberStrikeItemWeaponView);
			}
			else if (this.Item.View.ItemClass == UberstrikeItemClass.GearUpperBody || this.Item.View.ItemClass == UberstrikeItemClass.GearLowerBody)
			{
				UberStrikeItemGearView uberStrikeItemGearView = item.View as UberStrikeItemGearView;
				this._armorPoints = uberStrikeItemGearView.ArmorPoints;
				this.DetailGUI = new ArmorItemDetailGUI(uberStrikeItemGearView, ShopIcons.ItemarmorpointsIcon);
			}
			if (this.Item.View != null && !string.IsNullOrEmpty(this.Item.View.Description))
			{
				this._description = this.Item.View.Description;
			}
		}
		else
		{
			this.Item = new BaseItemGUI.NullItem();
			Debug.LogError("BaseItemGUI creation failed because item is NULL");
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x0000A377 File Offset: 0x00008577
	// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x0000A37F File Offset: 0x0000857F
	public IUnityItem Item { get; private set; }

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x0000A388 File Offset: 0x00008588
	// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x0000A390 File Offset: 0x00008590
	protected IBaseItemDetailGUI DetailGUI { get; set; }

	// Token: 0x06000DF9 RID: 3577
	public abstract void Draw(Rect rect, bool selected);

	// Token: 0x06000DFA RID: 3578 RVA: 0x0000A399 File Offset: 0x00008599
	protected void DrawIcon(Rect rect)
	{
		this.Item.DrawIcon(rect);
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x0000A3A7 File Offset: 0x000085A7
	protected void DrawName(Rect rect)
	{
		if (!string.IsNullOrEmpty(this.Item.Name))
		{
			GUI.Label(rect, this.Item.Name, BlueStonez.label_interparkbold_11pt_left_wrap);
		}
	}

	// Token: 0x06000DFC RID: 3580 RVA: 0x000603E0 File Offset: 0x0005E5E0
	protected void DrawHintArrow(Rect rect)
	{
		if (rect.Contains(Event.current.mousePosition))
		{
			GUI.color = new Color(1f, 1f, 1f, 0.1f);
			GUI.Label(new Rect(rect.width / 2f - 16f, rect.yMin, (float)ShopIcons.ArrowBigShop.width, (float)ShopIcons.ArrowBigShop.height), ShopIcons.ArrowBigShop, GUIStyle.none);
			GUI.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	// Token: 0x06000DFD RID: 3581 RVA: 0x00060484 File Offset: 0x0005E684
	protected void DrawArmorOverlay()
	{
		if (this.Item.View.ItemClass == UberstrikeItemClass.GearUpperBody || this.Item.View.ItemClass == UberstrikeItemClass.GearLowerBody)
		{
			if (this._armorPoints > 0)
			{
				GUI.DrawTexture(new Rect(4f, 35f, 16f, 16f), ShopIcons.ItemarmorpointsIcon);
			}
			if (this._armorPoints > 15)
			{
				GUI.DrawTexture(new Rect(8f, 35f, 16f, 16f), ShopIcons.ItemarmorpointsIcon);
			}
			if (this._armorPoints > 30)
			{
				GUI.DrawTexture(new Rect(12f, 35f, 16f, 16f), ShopIcons.ItemarmorpointsIcon);
			}
			if (this._armorPoints > 45)
			{
				GUI.DrawTexture(new Rect(16f, 35f, 16f, 16f), ShopIcons.ItemarmorpointsIcon);
			}
		}
	}

	// Token: 0x06000DFE RID: 3582 RVA: 0x00060580 File Offset: 0x0005E780
	protected void DrawPromotionalTag()
	{
		if (this.Item.View != null)
		{
			switch (this.Item.View.ShopHighlightType)
			{
			case ItemShopHighlightType.Featured:
				GUI.DrawTexture(new Rect(0f, -3f, 32f, 32f), ShopIcons.Sale);
				break;
			case ItemShopHighlightType.Popular:
				GUI.DrawTexture(new Rect(0f, -3f, 32f, 32f), ShopIcons.Hot);
				break;
			case ItemShopHighlightType.New:
				GUI.DrawTexture(new Rect(0f, -3f, 32f, 32f), ShopIcons.New);
				break;
			}
		}
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00060640 File Offset: 0x0005E840
	protected void DrawClassIcon()
	{
		GUI.color = new Color(1f, 1f, 1f, 0.5f);
		if (this.Item.View.ItemType == UberstrikeItemType.Weapon || this.Item.View.ItemType == UberstrikeItemType.Gear)
		{
			GUI.DrawTexture(new Rect(54f, 4f, 24f, 24f), UberstrikeIconsHelper.GetIconForItemClass(this.Item.View.ItemClass));
		}
	}

	// Token: 0x06000E00 RID: 3584 RVA: 0x000606CC File Offset: 0x0005E8CC
	protected void DrawLevelRequirement()
	{
		if (this.Item.View != null)
		{
			GUI.Label(new Rect(240f, 26f, 60f, 24f), string.Format("Lv {0}", this.Item.View.LevelLock.ToString()), BlueStonez.label_interparkbold_11pt_left);
		}
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x00060730 File Offset: 0x0005E930
	protected void DrawPrice(Rect rect, ItemPrice points, ItemPrice credits)
	{
		float num = 0f;
		if (points != null)
		{
			string text = string.Format("{0}", (points.Price != 0) ? points.Price.ToString("N0") : "FREE");
			GUI.DrawTexture(new Rect(rect.x, rect.y, 16f, 16f), ShopUtils.CurrencyIcon(points.Currency));
			GUI.Label(new Rect(rect.x + 20f, rect.y + 3f, rect.width - 20f, 16f), text, BlueStonez.label_interparkmed_11pt_left);
			num += 40f + BlueStonez.label_interparkmed_11pt_left.CalcSize(new GUIContent(text)).x;
		}
		if (credits != null)
		{
			string text2 = string.Format("{0}", (credits.Price != 0) ? credits.Price.ToString("N0") : "FREE");
			if (num > 0f)
			{
				GUI.Label(new Rect(rect.x + num - 10f, rect.y + 3f, 10f, 16f), "/", BlueStonez.label_interparkmed_11pt_left);
			}
			GUI.DrawTexture(new Rect(rect.x + num, rect.y, 16f, 16f), ShopUtils.CurrencyIcon(credits.Currency));
			GUI.Label(new Rect(rect.x + num + 20f, rect.y + 3f, rect.width - 20f, 16f), text2, BlueStonez.label_interparkmed_11pt_left);
		}
	}

	// Token: 0x06000E02 RID: 3586 RVA: 0x000608F4 File Offset: 0x0005EAF4
	protected void DrawEquipButton(Rect rect, string content)
	{
		if ((this.Item.View.ItemType == UberstrikeItemType.Weapon || this.Item.View.ItemType == UberstrikeItemType.Gear || this.Item.View.ItemType == UberstrikeItemType.QuickUse) && GUI.Button(rect, new GUIContent(content), BlueStonez.buttondark_medium) && this.Item != null)
		{
			switch (this.Item.View.ItemType)
			{
			case UberstrikeItemType.Weapon:
				global::EventHandler.Global.Fire(new ShopEvents.SelectLoadoutArea
				{
					Area = LoadoutArea.Weapons
				});
				break;
			case UberstrikeItemType.Gear:
				global::EventHandler.Global.Fire(new ShopEvents.SelectLoadoutArea
				{
					Area = LoadoutArea.Gear
				});
				break;
			case UberstrikeItemType.QuickUse:
				global::EventHandler.Global.Fire(new ShopEvents.SelectLoadoutArea
				{
					Area = LoadoutArea.QuickItems
				});
				break;
			}
			if (!Singleton<InventoryManager>.Instance.EquipItem(this.Item))
			{
				BuyPanelGUI buyPanelGUI = PanelManager.Instance.OpenPanel(PanelType.BuyItem) as BuyPanelGUI;
				if (buyPanelGUI)
				{
					buyPanelGUI.SetItem(this.Item, this._location, this._recommendation, false);
				}
			}
		}
	}

	// Token: 0x06000E03 RID: 3587 RVA: 0x0000A3D4 File Offset: 0x000085D4
	protected void DrawUnequipButton(Rect rect, string content)
	{
		if (GUI.Button(rect, new GUIContent(content), BlueStonez.buttondark_medium) && this.Item != null)
		{
			ShopPageGUI.Instance.UnequipItem(this.Item);
		}
	}

	// Token: 0x06000E04 RID: 3588 RVA: 0x0000A407 File Offset: 0x00008607
	protected void DrawTryButton(Rect position)
	{
		if (GUI.Button(position, new GUIContent(LocalizedStrings.Try), BlueStonez.buttondark_medium))
		{
			Singleton<TemporaryLoadoutManager>.Instance.TryGear(this.Item);
		}
	}

	// Token: 0x06000E05 RID: 3589 RVA: 0x00060A34 File Offset: 0x0005EC34
	protected void DrawBuyButton(Rect position, string text, ShopArea area = ShopArea.Shop)
	{
		GUI.contentColor = ColorScheme.UberStrikeYellow;
		if (GUITools.Button(position, new GUIContent(text), BlueStonez.buttondark_medium))
		{
			BuyPanelGUI buyPanelGUI = PanelManager.Instance.OpenPanel(PanelType.BuyItem) as BuyPanelGUI;
			if (buyPanelGUI)
			{
				buyPanelGUI.SetItem(this.Item, this._location, this._recommendation, false);
			}
		}
		GUI.contentColor = Color.white;
	}

	// Token: 0x06000E06 RID: 3590 RVA: 0x0000A433 File Offset: 0x00008633
	protected void DrawGrayLine(Rect position)
	{
		GUI.Label(new Rect(4f, position.height - 1f, position.width - 4f, 1f), string.Empty, BlueStonez.horizontal_line_grey95);
	}

	// Token: 0x06000E07 RID: 3591 RVA: 0x0000A46D File Offset: 0x0000866D
	protected void DrawDescription(Rect position)
	{
		GUI.Label(position, this._description, BlueStonez.label_itemdescription);
	}

	// Token: 0x06000E08 RID: 3592 RVA: 0x0000A480 File Offset: 0x00008680
	protected void DrawUseButton(Rect position)
	{
		if (GUITools.Button(position, new GUIContent("Use"), BlueStonez.buttondark_medium))
		{
			PanelManager.Instance.OpenPanel(PanelType.NameChange);
		}
	}

	// Token: 0x04000D0E RID: 3342
	protected const int BuyButtonSize = 52;

	// Token: 0x04000D0F RID: 3343
	private int _armorPoints;

	// Token: 0x04000D10 RID: 3344
	private string _description = "No description available.";

	// Token: 0x04000D11 RID: 3345
	private BuyingLocationType _location;

	// Token: 0x04000D12 RID: 3346
	private BuyingRecommendationType _recommendation;

	// Token: 0x020001F1 RID: 497
	private class NullItem : IUnityItem
	{
		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000E0A RID: 3594 RVA: 0x0000A4A9 File Offset: 0x000086A9
		// (set) Token: 0x06000E0B RID: 3595 RVA: 0x0000A4B1 File Offset: 0x000086B1
		public int ItemId { get; set; }

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000E0C RID: 3596 RVA: 0x00003C84 File Offset: 0x00001E84
		public bool Equippable
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00004D4D File Offset: 0x00002F4D
		public bool IsLoaded
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000E0E RID: 3598 RVA: 0x0000A4BA File Offset: 0x000086BA
		public GameObject Prefab
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000E0F RID: 3599 RVA: 0x0000A4BD File Offset: 0x000086BD
		public string Name
		{
			get
			{
				return "Unsupported Item";
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000E10 RID: 3600 RVA: 0x00003C84 File Offset: 0x00001E84
		public UberstrikeItemType ItemType
		{
			get
			{
				return (UberstrikeItemType)0;
			}
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000E11 RID: 3601 RVA: 0x00003C84 File Offset: 0x00001E84
		public UberstrikeItemClass ItemClass
		{
			get
			{
				return (UberstrikeItemClass)0;
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000E12 RID: 3602 RVA: 0x0000A4C4 File Offset: 0x000086C4
		// (set) Token: 0x06000E13 RID: 3603 RVA: 0x0000A4CC File Offset: 0x000086CC
		public BaseUberStrikeItemView View { get; private set; }

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000E14 RID: 3604 RVA: 0x0000A4D5 File Offset: 0x000086D5
		public string PrefabName
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x06000E15 RID: 3605 RVA: 0x00003C87 File Offset: 0x00001E87
		public void Unload()
		{
		}

		// Token: 0x06000E16 RID: 3606 RVA: 0x0000A4BA File Offset: 0x000086BA
		public GameObject Create(Vector3 position, Quaternion rotation)
		{
			return null;
		}

		// Token: 0x06000E17 RID: 3607 RVA: 0x00003C87 File Offset: 0x00001E87
		public void DrawIcon(Rect position)
		{
		}
	}
}
