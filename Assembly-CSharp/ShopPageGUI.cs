using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020001AE RID: 430
public class ShopPageGUI : PageGUI
{
	// Token: 0x17000312 RID: 786
	// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0000931C File Offset: 0x0000751C
	// (set) Token: 0x06000BD1 RID: 3025 RVA: 0x00009323 File Offset: 0x00007523
	public static ShopPageGUI Instance { get; private set; }

	// Token: 0x06000BD2 RID: 3026 RVA: 0x0004DA7C File Offset: 0x0004BC7C
	private void Awake()
	{
		ShopPageGUI.Instance = this;
		this._itemFilter = new SpecialItemFilter();
		this._firstLogin = true;
		base.IsOnGUIEnabled = true;
		this._searchBar = new SearchBarGUI("SearchInShop");
		this.UpdateShopItems();
		Singleton<InventoryManager>.Instance.OnInventoryUpdated += this.UpdateShopItems;
	}

	// Token: 0x06000BD3 RID: 3027 RVA: 0x0004DAD4 File Offset: 0x0004BCD4
	private void Start()
	{
		this._loadoutAreaSelection.Add(LoadoutArea.Weapons, new GUIContent(ShopIcons.LoadoutTabWeapons, LocalizedStrings.Weapons));
		this._loadoutAreaSelection.Add(LoadoutArea.Gear, new GUIContent(ShopIcons.LoadoutTabGear, LocalizedStrings.Gear));
		this._loadoutAreaSelection.Add(LoadoutArea.QuickItems, new GUIContent(ShopIcons.LoadoutTabItems, LocalizedStrings.Items));
		this._loadoutAreaSelection.OnSelectionChange += this.SelectLoadoutArea;
		this._shopAreaSelection.Add(ShopArea.Inventory, new GUIContent(LocalizedStrings.Inventory, ShopIcons.LabsInventory, LocalizedStrings.Inventory));
		this._shopAreaSelection.Add(ShopArea.Shop, new GUIContent(LocalizedStrings.Shop, ShopIcons.LabsShop, LocalizedStrings.Shop));
		this._shopAreaSelection.Add(ShopArea.Credits, new GUIContent(LocalizedStrings.Credits, ShopIcons.CreditsIcon32x32, LocalizedStrings.Credits));
		this._shopAreaSelection.OnSelectionChange += delegate(ShopArea area)
		{
			this.UpdateItemFilter();
		};
		this._typeSelection.Add(UberstrikeItemType.Special, new GUIContent(ShopIcons.NewItems, LocalizedStrings.NewAndSaleItems));
		this._typeSelection.Add(UberstrikeItemType.Weapon, new GUIContent(ShopIcons.WeaponItems, LocalizedStrings.Weapons));
		this._typeSelection.Add(UberstrikeItemType.Gear, new GUIContent(ShopIcons.GearItems, LocalizedStrings.Gear));
		this._typeSelection.Add(UberstrikeItemType.QuickUse, new GUIContent(ShopIcons.QuickItems, LocalizedStrings.QuickItems));
		this._typeSelection.Add(UberstrikeItemType.Functional, new GUIContent(ShopIcons.FunctionalItems, LocalizedStrings.FunctionalItems));
		this._typeSelection.OnSelectionChange += delegate(UberstrikeItemType itemType)
		{
			this.UpdateItemFilter();
		};
		this._weaponClassSelection.Add(UberstrikeItemClass.WeaponMelee, new GUIContent(ShopIcons.StatsMostWeaponSplatsMelee, LocalizedStrings.MeleeWeapons));
		this._weaponClassSelection.Add(UberstrikeItemClass.WeaponMachinegun, new GUIContent(ShopIcons.StatsMostWeaponSplatsMachinegun, LocalizedStrings.Machineguns));
		this._weaponClassSelection.Add(UberstrikeItemClass.WeaponShotgun, new GUIContent(ShopIcons.StatsMostWeaponSplatsShotgun, LocalizedStrings.Shotguns));
		this._weaponClassSelection.Add(UberstrikeItemClass.WeaponSniperRifle, new GUIContent(ShopIcons.StatsMostWeaponSplatsSniperRifle, LocalizedStrings.SniperRifles));
		this._weaponClassSelection.Add(UberstrikeItemClass.WeaponCannon, new GUIContent(ShopIcons.StatsMostWeaponSplatsCannon, LocalizedStrings.Cannons));
		this._weaponClassSelection.Add(UberstrikeItemClass.WeaponSplattergun, new GUIContent(ShopIcons.StatsMostWeaponSplatsSplattergun, LocalizedStrings.Splatterguns));
		this._weaponClassSelection.Add(UberstrikeItemClass.WeaponLauncher, new GUIContent(ShopIcons.StatsMostWeaponSplatsLauncher, LocalizedStrings.Launchers));
		this._weaponClassSelection.OnSelectionChange += delegate(UberstrikeItemClass itemClass)
		{
			this.UpdateItemFilter();
		};
		this._gearClassSelection.Add(UberstrikeItemClass.GearBoots, new GUIContent(ShopIcons.Boots, LocalizedStrings.Boots));
		this._gearClassSelection.Add(UberstrikeItemClass.GearHead, new GUIContent(ShopIcons.Head, LocalizedStrings.Head));
		this._gearClassSelection.Add(UberstrikeItemClass.GearFace, new GUIContent(ShopIcons.Face, LocalizedStrings.Face));
		this._gearClassSelection.Add(UberstrikeItemClass.GearUpperBody, new GUIContent(ShopIcons.Upperbody, LocalizedStrings.UpperBody));
		this._gearClassSelection.Add(UberstrikeItemClass.GearLowerBody, new GUIContent(ShopIcons.Lowerbody, LocalizedStrings.LowerBody));
		this._gearClassSelection.Add(UberstrikeItemClass.GearGloves, new GUIContent(ShopIcons.Gloves, LocalizedStrings.Gloves));
		this._gearClassSelection.Add(UberstrikeItemClass.GearHolo, new GUIContent(ShopIcons.Holos, LocalizedStrings.Holo));
		this._gearClassSelection.OnSelectionChange += delegate(UberstrikeItemClass itemClass)
		{
			this.UpdateItemFilter();
		};
		if (this._showRenewLoadoutButton)
		{
			foreach (global::LoadoutSlotType loadoutSlotType in LoadoutManager.WeaponSlots)
			{
				InventoryItem item;
				if (Singleton<LoadoutManager>.Instance.TryGetItemInSlot(loadoutSlotType, out item))
				{
					this._renewItem[loadoutSlotType] = !Singleton<InventoryManager>.Instance.IsItemValidForDays(item, 5);
				}
			}
			foreach (global::LoadoutSlotType loadoutSlotType2 in LoadoutManager.GearSlots)
			{
				InventoryItem item2;
				if (Singleton<LoadoutManager>.Instance.TryGetItemInSlot(loadoutSlotType2, out item2))
				{
					this._renewItem[loadoutSlotType2] = !Singleton<InventoryManager>.Instance.IsItemValidForDays(item2, 5);
				}
			}
		}
		if (this._shopAreaSelection.Index == 0)
		{
			this._shopAreaSelection.Select(ShopArea.Shop);
		}
		this._typeSelection.Select(UberstrikeItemType.Special);
		this._gearClassSelection.SetIndex(-1);
		this._weaponClassSelection.SetIndex(-1);
	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x0004DEFC File Offset: 0x0004C0FC
	private void OnEnable()
	{
		global::EventHandler.Global.AddListener<ShopEvents.SelectShopArea>(new Action<ShopEvents.SelectShopArea>(this.OnSelectShopAreaEvent));
		global::EventHandler.Global.AddListener<ShopEvents.SelectLoadoutArea>(new Action<ShopEvents.SelectLoadoutArea>(this.OnSelectLoadoutAreaEvent));
		global::EventHandler.Global.AddListener<ShopEvents.ShopHighlightSlot>(new Action<ShopEvents.ShopHighlightSlot>(this.OnHighlightSlotEvent));
		global::EventHandler.Global.AddListener<ShopEvents.RefreshCurrentItemList>(new Action<ShopEvents.RefreshCurrentItemList>(this.OnRefreshCurrentItemListEvent));
		Singleton<DragAndDrop>.Instance.OnDragBegin += this.OnBeginDrag;
		Singleton<TemporaryLoadoutManager>.Instance.ResetLoadout();
		base.StartCoroutine(this.StartNotifyLoadoutArea());
		if (MouseOrbit.Instance != null)
		{
			MouseOrbit.Instance.MaxX = Screen.width - 590;
		}
		if (base.IsOnGUIEnabled)
		{
			base.StartCoroutine(this.ScrollShopFromRight(0.25f));
		}
		this._searchBar.ClearFilter();
		GameData.Instance.IsShopLoaded.Value = true;
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x0004DFEC File Offset: 0x0004C1EC
	private void OnDisable()
	{
		global::EventHandler.Global.RemoveListener<ShopEvents.SelectShopArea>(new Action<ShopEvents.SelectShopArea>(this.OnSelectShopAreaEvent));
		global::EventHandler.Global.RemoveListener<ShopEvents.SelectLoadoutArea>(new Action<ShopEvents.SelectLoadoutArea>(this.OnSelectLoadoutAreaEvent));
		global::EventHandler.Global.RemoveListener<ShopEvents.RefreshCurrentItemList>(new Action<ShopEvents.RefreshCurrentItemList>(this.OnRefreshCurrentItemListEvent));
		global::EventHandler.Global.RemoveListener<ShopEvents.ShopHighlightSlot>(new Action<ShopEvents.ShopHighlightSlot>(this.OnHighlightSlotEvent));
		Singleton<DragAndDrop>.Instance.OnDragBegin -= this.OnBeginDrag;
		if (MouseOrbit.Instance != null)
		{
			MouseOrbit.Instance.MaxX = Screen.width;
		}
		GameData.Instance.IsShopLoaded.Value = false;
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x0000932B File Offset: 0x0000752B
	private void OnHighlightSlotEvent(ShopEvents.ShopHighlightSlot ev)
	{
		this.HighlightingSlot(ev.SlotType);
	}

	// Token: 0x06000BD7 RID: 3031 RVA: 0x0004E098 File Offset: 0x0004C298
	private void OnSelectShopAreaEvent(ShopEvents.SelectShopArea ev)
	{
		this._shopAreaSelection.Select(ev.ShopArea);
		if (ev.ItemType != (UberstrikeItemType)0)
		{
			this._typeSelection.Select(ev.ItemType);
		}
		if (ev.ItemClass != (UberstrikeItemClass)0)
		{
			switch (ev.ItemType)
			{
			case UberstrikeItemType.Weapon:
				this._weaponClassSelection.Select(ev.ItemClass);
				break;
			case UberstrikeItemType.Gear:
				this._gearClassSelection.Select(ev.ItemClass);
				break;
			}
		}
	}

	// Token: 0x06000BD8 RID: 3032 RVA: 0x00009339 File Offset: 0x00007539
	private void OnSelectLoadoutAreaEvent(ShopEvents.SelectLoadoutArea ev)
	{
		this._loadoutAreaSelection.Select(ev.Area);
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x0004E12C File Offset: 0x0004C32C
	private IEnumerator ScrollShopFromRight(float time)
	{
		float t = 0f;
		while (t < time)
		{
			t += Time.deltaTime;
			this.shopPositionX = Mathf.Lerp(0f, 590f, t / time * (t / time));
			if (MenuPageManager.Instance != null)
			{
				MenuPageManager.Instance.LeftAreaGUIOffset = this.shopPositionX;
			}
			yield return new WaitForEndOfFrame();
		}
		yield break;
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x0004E158 File Offset: 0x0004C358
	private IEnumerator StartNotifyLoadoutArea()
	{
		yield return new WaitForEndOfFrame();
		global::EventHandler.Global.Fire(new ShopEvents.LoadoutAreaChanged
		{
			Area = this._loadoutAreaSelection.Current
		});
		yield break;
	}

	// Token: 0x06000BDB RID: 3035 RVA: 0x0004E174 File Offset: 0x0004C374
	private void OnGUI()
	{
		if (base.IsOnGUIEnabled)
		{
			this.DrawGUI(new Rect((float)Screen.width - this.shopPositionX, (float)GlobalUIRibbon.Instance.Height(), 590f, (float)(Screen.height - GlobalUIRibbon.Instance.Height() + 1)));
		}
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x0004E1C8 File Offset: 0x0004C3C8
	public override void DrawGUI(Rect rect)
	{
		GUI.depth = 11;
		GUI.skin = BlueStonez.Skin;
		if (this._firstLogin)
		{
			this._firstLogin = false;
		}
		this._rectLabs = rect;
		this._rectLabs.width = this._rectLabs.width + 10f;
		GUITools.PushGUIState();
		GUI.enabled = (!PopupSystem.IsAnyPopupOpen && !PanelManager.IsAnyPanelOpen);
		GUI.BeginGroup(this._rectLabs);
		this.DrawLoadout(new Rect(0f, 0f, 190f, this._rectLabs.height));
		this.DrawShop(new Rect(190f, 0f, this._rectLabs.width - 190f - 10f, this._rectLabs.height));
		GUI.EndGroup();
		Singleton<DragAndDrop>.Instance.DrawSlot<ShopPageGUI.ShopDragSlot>(new Rect(0f, 55f, (float)(Screen.width - 580), (float)(Screen.height - 55)), new Action<int, ShopPageGUI.ShopDragSlot>(this.OnDropAvatar));
		Singleton<DragAndDrop>.Instance.DrawSlot<ShopPageGUI.ShopDragSlot>(new Rect((float)Screen.width - this._rectLabs.width + 200f, 55f, this._rectLabs.width - 200f, (float)(Screen.height - 55)), new Action<int, ShopPageGUI.ShopDragSlot>(this.OnDropShop));
		GUITools.PopGUIState();
		if (!PopupSystem.IsAnyPopupOpen && !PanelManager.IsAnyPanelOpen)
		{
			GuiManager.DrawTooltip();
		}
		if (this._highlightedSlotAlpha > 0f)
		{
			this._highlightedSlotAlpha = Mathf.Max(this._highlightedSlotAlpha - Time.deltaTime * 0.5f, 0f);
		}
		if (PlayerDataManager.AccessLevel == MemberAccessLevel.Admin)
		{
			GUI.enabled = !this._isReloadingShop;
			if (GUI.Button(new Rect(this._rectLabs.x + 10f, (float)(Screen.height - 50), 128f, 32f), "Reload Shop", BlueStonez.button_green))
			{
				base.StartCoroutine(this.ReloadShop());
			}
			GUI.enabled = true;
		}
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x0004E3E8 File Offset: 0x0004C5E8
	private IEnumerator ReloadShop()
	{
		this._isReloadingShop = true;
		ProgressPopupDialog _progress = new ProgressPopupDialog("Reload Shop", "I'm reloading the shop, please wait...", null);
		PopupSystem.Show(_progress);
		yield return UnityRuntime.StartRoutine(Singleton<ItemManager>.Instance.StartGetShop());
		PopupSystem.HideMessage(_progress);
		if (!Singleton<ItemManager>.Instance.ValidateItemMall())
		{
			PopupSystem.ShowMessage(LocalizedStrings.ErrorGettingShopData, LocalizedStrings.ErrorGettingShopDataSupport, PopupSystem.AlertType.OK);
		}
		this._isReloadingShop = false;
		yield break;
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x0004E404 File Offset: 0x0004C604
	public void EquipItemFromArea(IUnityItem item, global::LoadoutSlotType slot, ShopArea area)
	{
		if (item != null && !Singleton<LoadoutManager>.Instance.IsItemEquipped(item.View.ID))
		{
			if (Singleton<InventoryManager>.Instance.Contains(item.View.ID))
			{
				Singleton<InventoryManager>.Instance.EquipItemOnSlot(item.View.ID, slot);
			}
			else if (item.View.LevelLock <= PlayerDataManager.PlayerLevel)
			{
				BuyPanelGUI buyPanelGUI = PanelManager.Instance.OpenPanel(PanelType.BuyItem) as BuyPanelGUI;
				if (buyPanelGUI)
				{
					buyPanelGUI.SetItem(item, BuyingLocationType.Shop, BuyingRecommendationType.None, true);
				}
			}
		}
		else
		{
			Debug.LogError("Item is null or already equipped!");
		}
	}

	// Token: 0x06000BDF RID: 3039 RVA: 0x0004E4B4 File Offset: 0x0004C6B4
	public void SelectLoadoutWeapon(global::LoadoutSlotType slot)
	{
		if (Singleton<InventoryManager>.Instance.CurrentWeaponSlot != slot)
		{
			Singleton<InventoryManager>.Instance.CurrentWeaponSlot = slot;
			GameState.Current.Avatar.ShowWeapon(slot);
			InventoryItem inventoryItem;
			if (Singleton<LoadoutManager>.Instance.TryGetItemInSlot(slot, out inventoryItem))
			{
				GameState.Current.Avatar.Decorator.AnimationController.ChangeWeaponType(inventoryItem.Item.View.ItemClass);
			}
			else
			{
				GameState.Current.Avatar.Decorator.AnimationController.ChangeWeaponType((UberstrikeItemClass)0);
			}
		}
	}

	// Token: 0x06000BE0 RID: 3040 RVA: 0x0004E548 File Offset: 0x0004C748
	public void UnequipItem(IUnityItem item)
	{
		global::LoadoutSlotType loadoutSlotType;
		if (item != null && Singleton<LoadoutManager>.Instance.TryGetSlotForItem(item, out loadoutSlotType))
		{
            switch (item.View.ItemType)
			{
			case UberstrikeItemType.Weapon:
				GameState.Current.Avatar.UnassignWeapon(loadoutSlotType);
				GameState.Current.Avatar.Decorator.AnimationController.ChangeWeaponType(0);
				break;
			case UberstrikeItemType.Gear:
				this.ShowUnequipGearFx(item, loadoutSlotType);
				break;
			}
			Singleton<LoadoutManager>.Instance.ResetSlot(loadoutSlotType);
			this.HighlightingSlot(loadoutSlotType);
		}
	}

	// Token: 0x06000BE1 RID: 3041 RVA: 0x0004E5E0 File Offset: 0x0004C7E0
	private void ShowUnequipGearFx(IUnityItem item, global::LoadoutSlotType slot)
	{
		UberstrikeItemClass itemClass = item.View.ItemClass;
		if (itemClass != UberstrikeItemClass.GearFace && itemClass != UberstrikeItemClass.GearHolo)
		{
			IUnityItem unityItem;
			if (Singleton<ItemManager>.Instance.TryGetDefaultItem(item.View.ItemClass, out unityItem))
			{
				Singleton<InventoryManager>.Instance.EquipItemOnSlot(unityItem.View.ID, slot);
			}
		}
		else
		{
			Singleton<TemporaryLoadoutManager>.Instance.ResetLoadout(slot);
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.EquipGear, 0UL, 1f, 1f);
			if (GameState.Current.Avatar != null)
			{
				GameState.Current.Avatar.HideWeapons();
			}
		}
	}

	// Token: 0x06000BE2 RID: 3042 RVA: 0x0004E690 File Offset: 0x0004C890
	private void SetActiveLoadoutActiveSpaces(int slots, float width)
	{
		this._activeLoadoutUsedSpace.Clear();
		for (int i = 0; i < slots; i++)
		{
			this._activeLoadoutUsedSpace.Add(new Rect(0f, (float)(i * 70), width - 5f, 70f));
		}
	}

	// Token: 0x06000BE3 RID: 3043 RVA: 0x0004E6E0 File Offset: 0x0004C8E0
	private void SetActiveLoadoutActiveSpaces(params Rect[] rects)
	{
		this._activeLoadoutUsedSpace.Clear();
		for (int i = 0; i < rects.Length; i++)
		{
			this._activeLoadoutUsedSpace.Add(rects[i]);
		}
	}

	// Token: 0x06000BE4 RID: 3044 RVA: 0x0004E724 File Offset: 0x0004C924
	private bool IsMouseCursorInLoadout(Vector2 pos)
	{
		for (int i = 0; i < this._activeLoadoutUsedSpace.Count; i++)
		{
			if (this._activeLoadoutUsedSpace[i].Contains(pos))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000BE5 RID: 3045 RVA: 0x0004E76C File Offset: 0x0004C96C
	public void HighlightingSlot(global::LoadoutSlotType slot)
	{
		this._highlightedSlot = slot;
		this._highlightedSlotAlpha = 0.5f;
		switch (slot)
		{
		case global::LoadoutSlotType.WeaponMelee:
		case global::LoadoutSlotType.WeaponPrimary:
		case global::LoadoutSlotType.WeaponSecondary:
		case global::LoadoutSlotType.WeaponTertiary:
			this.SelectLoadoutArea(LoadoutArea.Weapons);
			break;
		case global::LoadoutSlotType.QuickUseItem1:
		case global::LoadoutSlotType.QuickUseItem2:
		case global::LoadoutSlotType.QuickUseItem3:
		case global::LoadoutSlotType.FunctionalItem1:
		case global::LoadoutSlotType.FunctionalItem2:
		case global::LoadoutSlotType.FunctionalItem3:
			this.SelectLoadoutArea(LoadoutArea.QuickItems);
			break;
		default:
			this.SelectLoadoutArea(LoadoutArea.Gear);
			break;
		}
	}

	// Token: 0x06000BE6 RID: 3046 RVA: 0x0004E7E8 File Offset: 0x0004C9E8
	public void SelectLoadoutArea(LoadoutArea area)
	{
		switch (area)
		{
		case LoadoutArea.Weapons:
			this.SetActiveLoadoutActiveSpaces(4, 185f);
			break;
		case LoadoutArea.Gear:
		case LoadoutArea.QuickItems:
			this.SetActiveLoadoutActiveSpaces(6, 185f);
			break;
		}
		global::EventHandler.Global.Fire(new ShopEvents.LoadoutAreaChanged
		{
			Area = area
		});
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x0004E848 File Offset: 0x0004CA48
	private void UpdateShopItems()
	{
		this._shopItemGUIList.Clear();
		this._inventoryItemGUIList.Clear();
		foreach (InventoryItem item in Singleton<InventoryManager>.Instance.GetAllItems(false))
		{
			this._inventoryItemGUIList.Add(new InventoryItemGUI(item, BuyingLocationType.Shop));
		}
		this._inventoryItemGUIList.Sort(this._inventoryComparer);
		foreach (IUnityItem item2 in Singleton<ItemManager>.Instance.GetAllShopItems())
		{
			this._shopItemGUIList.Add(new ShopItemGUI(item2, BuyingLocationType.Shop));
		}
		this._shopItemGUIList.Sort(this._shopComparer);
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x00003C87 File Offset: 0x00001E87
	private void OnRefreshCurrentItemListEvent(ShopEvents.RefreshCurrentItemList ev)
	{
	}

	// Token: 0x06000BE9 RID: 3049 RVA: 0x0004E944 File Offset: 0x0004CB44
	private void DrawLoadout(Rect rect)
	{
		this._loadoutArea = rect;
		this._loadoutArea.x = this._loadoutArea.x + this._rectLabs.x;
		this._loadoutArea.y = this._loadoutArea.y + this._rectLabs.y;
		GUI.BeginGroup(rect, string.Empty, BlueStonez.window);
		GUI.Label(new Rect(0f, 0f, rect.width - 2f, 76f), LocalizedStrings.LoadoutCaps, BlueStonez.tab_strip_large);
		int num = UnityGUI.Toolbar(new Rect(4f, 32f, 120f, 44f), this._loadoutAreaSelection.Index, this._loadoutAreaSelection.GuiContent, this._loadoutAreaSelection.Length, BlueStonez.tab_largeicon);
		if (num != this._loadoutAreaSelection.Index)
		{
			this._loadoutAreaSelection.SetIndex(num);
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
		}
		Rect position = new Rect(0f, 76f, rect.width, rect.height - 76f);
		switch (this._loadoutAreaSelection.Current)
		{
		case LoadoutArea.Weapons:
			this.DrawWeaponLoadout(position);
			break;
		case LoadoutArea.Gear:
			this.DrawGearLoadout(position);
			break;
		case LoadoutArea.QuickItems:
			this.DrawQuickItemLoadout(position);
			break;
		}
		GUI.EndGroup();
	}

	// Token: 0x06000BEA RID: 3050 RVA: 0x0004EAC0 File Offset: 0x0004CCC0
	private void DrawShop(Rect labsRect)
	{
		this._shopArea = labsRect;
		this._shopArea.x = this._shopArea.x + this._rectLabs.x;
		this._shopArea.y = this._shopArea.y + this._rectLabs.y;
		bool flag = false;
		if (!Application.isWebPlayer || Application.isEditor)
		{
			flag = true;
		}
		GUI.BeginGroup(labsRect, BlueStonez.window);
		this.DrawShopTabs(labsRect);
		if (this._shopAreaSelection.Current == ShopArea.Inventory || this._shopAreaSelection.Current == ShopArea.Shop)
		{
			this._searchBar.Draw(new Rect((!flag) ? (labsRect.width - 128f) : (labsRect.width - 200f), 8f, 123f, 20f));
		}
		switch (this._shopAreaSelection.Current)
		{
		case ShopArea.Inventory:
			this.DrawItemGUIList<IShopItemGUI>(this._inventoryItemGUIList, labsRect);
			this.DrawSortBar(new Rect(0f, 74f, labsRect.width, 22f), false, true);
			break;
		case ShopArea.Shop:
			this.DrawItemGUIList<IShopItemGUI>(this._shopItemGUIList, labsRect);
			this.DrawShopSubTabs(labsRect, true);
			break;
		case ShopArea.Credits:
			this._creditsGui.Draw(new Rect(0f, 74f, labsRect.width, labsRect.height - 74f));
			break;
		}
		if (flag)
		{
			bool flag2 = PlayerDataManager.IsPlayerLoggedIn && GUITools.SaveClickIn(7f);
			GUI.enabled = (flag2 || (PlayerDataManager.IsPlayerLoggedIn && GUITools.SaveClickIn(7f)));
			if (GUITools.Button(new Rect(labsRect.width - 66f, 7f, 64f, 20f), new GUIContent(LocalizedStrings.Refresh), BlueStonez.buttondark_medium))
			{
				GUITools.Clicked();
				ApplicationDataManager.RefreshWallet();
			}
			GUI.enabled = flag2;
		}
		GUI.EndGroup();
	}

	// Token: 0x06000BEB RID: 3051 RVA: 0x0004ECDC File Offset: 0x0004CEDC
	private void DrawShopTabs(Rect rect)
	{
		rect = new Rect(0f, 0f, rect.width, rect.height);
		GUI.Box(rect, string.Empty, BlueStonez.window);
		GUI.Label(new Rect(0f, 0f, rect.width, 76f), LocalizedStrings.ShopCaps, BlueStonez.tab_strip_large);
		int num = UnityGUI.Toolbar(new Rect(1f, 32f, rect.width - 2f, 44f), this._shopAreaSelection.Index, this._shopAreaSelection.GuiContent, BlueStonez.tab_largeicon);
		if (num != this._shopAreaSelection.Index)
		{
			this._shopAreaSelection.SetIndex(num);
			this._searchBar.ClearFilter();
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
		}
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x0004EDC8 File Offset: 0x0004CFC8
	private void DrawShopSubTabs(Rect position, bool showLevel)
	{
		int num = UnityGUI.Toolbar(new Rect(1f, 74f, position.width - 2f, 44f), this._typeSelection.Index, this._typeSelection.GuiContent, this._typeSelection.Length, BlueStonez.tab_large);
		if (num != this._typeSelection.Index)
		{
			this._typeSelection.SetIndex(num);
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
		}
		if (this._typeSelection.Current == UberstrikeItemType.Weapon)
		{
			this.DrawWeaponClassFilter(new Rect(0f, 114f, position.width, 30f));
			this.DrawSortBar(new Rect(0f, 149f, position.width + 1f, 22f), showLevel, false);
		}
		else if (this._typeSelection.Current == UberstrikeItemType.Gear)
		{
			this.DrawGearClassFilter(new Rect(0f, 114f, position.width, 30f));
			this.DrawSortBar(new Rect(0f, 149f, position.width + 1f, 22f), showLevel, false);
		}
		else
		{
			this.DrawSortBar(new Rect(0f, 118f, position.width, 22f), showLevel, false);
		}
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x0004EF40 File Offset: 0x0004D140
	private void DrawWeaponClassFilter(Rect rect)
	{
		GUI.changed = false;
		Rect position = new Rect(rect.x, rect.y + 5f, rect.width, rect.height);
		int num = UnityGUI.Toolbar(position, this._weaponClassSelection.Index, this._weaponClassSelection.GuiContent, this._weaponClassSelection.Length, BlueStonez.tab_large);
		if (GUI.changed)
		{
			if (num == this._weaponClassSelection.Index)
			{
				this._weaponClassSelection.SetIndex(-1);
			}
			else
			{
				this._weaponClassSelection.SetIndex(num);
			}
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
		}
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x0004EFFC File Offset: 0x0004D1FC
	private void DrawGearClassFilter(Rect rect)
	{
		GUI.changed = false;
		Rect position = new Rect(rect.x, rect.y + 5f, rect.width, rect.height);
		int num = UnityGUI.Toolbar(position, this._gearClassSelection.Index, this._gearClassSelection.GuiContent, this._gearClassSelection.Length, BlueStonez.tab_large);
		if (GUI.changed)
		{
			if (num == this._gearClassSelection.Index)
			{
				this._gearClassSelection.SetIndex(-1);
			}
			else
			{
				this._gearClassSelection.SetIndex(num);
			}
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
		}
	}

	// Token: 0x06000BEF RID: 3055 RVA: 0x0004F0B8 File Offset: 0x0004D2B8
	private void DrawSortBar(Rect sortRect, bool showLevel, bool showExpDay)
	{
		GUI.BeginGroup(sortRect);
		if (!showLevel && showExpDay)
		{
			GUI.Label(new Rect(0f, 0f, sortRect.width - 134f, sortRect.height), new GUIContent(LocalizedStrings.Name), BlueStonez.label_interparkmed_11pt);
			GUI.Label(new Rect(sortRect.width - 136f, 0f, 64f, sortRect.height), new GUIContent(LocalizedStrings.Duration), BlueStonez.label_interparkmed_11pt);
		}
		else if (showLevel && !showExpDay)
		{
			GUI.Label(new Rect(0f, 0f, sortRect.width - 179f, sortRect.height), new GUIContent(LocalizedStrings.Name), BlueStonez.label_interparkmed_11pt);
			GUI.Label(new Rect(sortRect.width - 173f, 0f, 48f, sortRect.height), new GUIContent(LocalizedStrings.Level), BlueStonez.label_interparkmed_11pt);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000BF0 RID: 3056 RVA: 0x0004F1CC File Offset: 0x0004D3CC
	private void DrawItemGUIList<T>(List<T> list, Rect position) where T : IShopItemGUI
	{
		int num = (this._typeSelection.Current != UberstrikeItemType.Weapon && this._typeSelection.Current != UberstrikeItemType.Gear) ? 29 : 58;
		int num2 = -1;
		int num3 = 0;
		int num4 = 60;
		int num5 = (this._shopAreaSelection.Current != ShopArea.Inventory) ? (116 + num) : 109;
		Rect position2 = new Rect(0f, (float)num5, position.width, position.height - (float)(num5 + 1));
		Rect contentRect = new Rect(0f, 0f, position.width - 20f, (float)((list.Count - this._skippedDefaultGearCount) * num4 + 106));
		bool flag = position2.Contains(Event.current.mousePosition) && !PanelManager.IsAnyPanelOpen && !PopupSystem.IsAnyPopupOpen;
		List<string> list2 = new List<string>();
		this._labScroll = GUITools.BeginScrollView(position2, this._labScroll, contentRect, false, false, true);
		int num6 = (contentRect.height <= position2.height) ? 5 : 20;
		this._skippedDefaultGearCount = 0;
		int num7 = -num4;
		for (int i = 0; i < list.Count; i++)
		{
			SearchBarGUI searchBar = this._searchBar;
			T t = list[i];
			if (!searchBar.CheckIfPassFilter(t.Item.Name))
			{
				this._skippedDefaultGearCount++;
			}
			else
			{
				if (this._itemFilter != null)
				{
					IShopItemFilter itemFilter = this._itemFilter;
					T t2 = list[i];
					if (!itemFilter.CanPass(t2.Item))
					{
						this._skippedDefaultGearCount++;
						goto IL_371;
					}
				}
				num7 += num4;
				if ((float)(num7 + num4) >= this._labScroll.y && (float)num7 <= this._labScroll.y + position2.height)
				{
					Rect rect = new Rect(0f, (float)(num7 + ((num2 != -1) ? (num3 - 20) : 0)), position.width - (float)num6, (float)num4);
					Rect rect2 = new Rect(rect.x, rect.y, rect.width - 100f, rect.height);
					T t3 = list[i];
					GUITools.PushGUIState();
					if (!Singleton<InventoryManager>.Instance.Contains(t3.Item.View.ID) && t3.Item.View.LevelLock > PlayerDataManager.PlayerLevel)
					{
						GUI.enabled = false;
					}
					t3.Draw(rect, rect.Contains(Event.current.mousePosition));
					GUITools.PopGUIState();
					list2.Add(t3.Item.View.PrefabName);
					if (flag && rect2.Contains(Event.current.mousePosition) && !Singleton<DragAndDrop>.Instance.IsDragging)
					{
						AutoMonoBehaviour<ItemToolTip>.Instance.SetItem(t3.Item, rect, PopupViewSide.Left, -1, BuyingDurationType.None);
					}
					DragAndDrop instance = Singleton<DragAndDrop>.Instance;
					Rect rect3 = rect;
					ShopPageGUI.ShopDragSlot item = default(ShopPageGUI.ShopDragSlot);
					T t4 = list[i];
					item.Item = t4.Item;
					item.Slot = global::LoadoutSlotType.Shop;
					instance.DrawSlot<ShopPageGUI.ShopDragSlot>(rect3, item, new Action<int, ShopPageGUI.ShopDragSlot>(this.OnDropShop), null, true);
				}
			}
			IL_371:;
		}
		GUITools.EndScrollView();
	}

	// Token: 0x06000BF1 RID: 3057 RVA: 0x0004F564 File Offset: 0x0004D764
	private void UpdateItemFilter()
	{
		ShopArea shopArea = this._shopAreaSelection.Current;
		if (shopArea != ShopArea.Inventory)
		{
			if (shopArea == ShopArea.Shop)
			{
				switch (this._typeSelection.Current)
				{
				case UberstrikeItemType.Weapon:
					if (this._weaponClassSelection.Current == (UberstrikeItemClass)0)
					{
						this._itemFilter = new ItemByTypeFilter(this._typeSelection.Current);
					}
					else
					{
						this._itemFilter = new ItemByClassFilter(this._typeSelection.Current, this._weaponClassSelection.Current);
					}
					break;
				case UberstrikeItemType.Gear:
					if (this._gearClassSelection.Current == (UberstrikeItemClass)0)
					{
						this._itemFilter = new ItemByTypeFilter(this._typeSelection.Current);
					}
					else
					{
						this._itemFilter = new ItemByClassFilter(this._typeSelection.Current, this._gearClassSelection.Current);
					}
					break;
				case UberstrikeItemType.QuickUse:
				case UberstrikeItemType.Functional:
					this._itemFilter = new ItemByTypeFilter(this._typeSelection.Current);
					break;
				case UberstrikeItemType.Special:
					this._itemFilter = new SpecialItemFilter();
					break;
				}
			}
		}
		else
		{
			this._itemFilter = new InventoryItemFilter();
		}
	}

	// Token: 0x06000BF2 RID: 3058 RVA: 0x0004F6A4 File Offset: 0x0004D8A4
	private void DrawWeaponLoadout(Rect position)
	{
		this._loadoutWeaponScroll = GUITools.BeginScrollView(position, this._loadoutWeaponScroll, new Rect(0f, 0f, position.width - 20f, 285f), false, false, true);
		string[] array = new string[]
		{
			LocalizedStrings.Melee,
			LocalizedStrings.PrimaryWeapon,
			LocalizedStrings.SecondaryWeapon,
			LocalizedStrings.TertiaryWeapon
		};
		global::LoadoutSlotType[] array2 = new global::LoadoutSlotType[]
		{
			global::LoadoutSlotType.WeaponMelee,
			global::LoadoutSlotType.WeaponPrimary,
			global::LoadoutSlotType.WeaponSecondary,
			global::LoadoutSlotType.WeaponTertiary
		};
		Rect position2 = default(Rect);
		for (int i = 0; i < array.Length; i++)
		{
			Rect rect = new Rect(0f, (float)(70 * i), position.width - 5f, 70f);
			InventoryItem item = Singleton<InventoryManager>.Instance.GetItem(Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(array2[i]));
			this.DrawLoadoutWeaponItem(array[i], item, rect, array2[i]);
			if (array2[i] == Singleton<InventoryManager>.Instance.CurrentWeaponSlot)
			{
				position2.x = rect.x + 5f;
				position2.y = rect.y;
				position2.width = rect.width - 16f;
				position2.height = rect.height - 10f;
			}
		}
		GUI.color = new Color(1f, 1f, 1f, 0.5f);
		GUI.Box(position2, GUIContent.none, BlueStonez.group_grey81);
		GUI.color = Color.white;
		if (this._showRenewLoadoutButton)
		{
			Rect[] array3 = new Rect[]
			{
				new Rect(0f, 0f, 5f, 70f),
				new Rect(0f, 70f, 5f, 70f),
				new Rect(0f, 140f, 5f, 70f),
				new Rect(0f, 210f, 5f, 70f)
			};
			for (int j = 0; j < LoadoutManager.WeaponSlots.Length; j++)
			{
				global::LoadoutSlotType key = LoadoutManager.WeaponSlots[j];
				this._renewItem[key] = GUI.Toggle(array3[j], this._renewItem[key], (!this._renewItem[key]) ? "<" : ">", BlueStonez.panelquad_toggle);
			}
		}
		GUI.color = Color.white;
		GUITools.EndScrollView();
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x0004F954 File Offset: 0x0004DB54
	private void DrawGearLoadout(Rect position)
	{
		Rect[] array = new Rect[]
		{
			new Rect(0f, 70f, position.width - 5f, 70f),
			new Rect(0f, 140f, position.width - 5f, 70f),
			new Rect(0f, 210f, position.width - 5f, 70f),
			new Rect(0f, 280f, position.width - 5f, 70f),
			new Rect(0f, 350f, position.width - 5f, 70f),
			new Rect(0f, 420f, position.width - 5f, 70f)
		};
		Rect[] array2 = new Rect[]
		{
			new Rect(0f, 0f, 5f, 60f),
			new Rect(0f, 60f, 5f, 70f),
			new Rect(0f, 130f, 5f, 70f),
			new Rect(0f, 200f, 5f, 70f),
			new Rect(0f, 270f, 5f, 70f),
			new Rect(0f, 340f, 5f, 70f)
		};
		this._loadoutGearScroll = GUITools.BeginScrollView(position, this._loadoutGearScroll, new Rect(0f, 0f, position.width - 20f, 490f), false, false, true);
		InventoryItem item = Singleton<InventoryManager>.Instance.GetItem(Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(global::LoadoutSlotType.GearHolo));
		this.DrawLoadoutGearItem(LocalizedStrings.Holo, item, global::LoadoutSlotType.GearHolo, new Rect(0f, 0f, position.width - 5f, 70f), UberstrikeItemClass.GearHolo);
		for (int i = 0; i < LoadoutManager.GearSlots.Length; i++)
		{
			string slotName = LoadoutManager.GearSlotNames[i];
			global::LoadoutSlotType loadoutSlotType = LoadoutManager.GearSlots[i];
			item = Singleton<InventoryManager>.Instance.GetItem(Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(loadoutSlotType));
			this.DrawLoadoutGearItem(slotName, item, loadoutSlotType, array[i], LoadoutManager.GearSlotClasses[i]);
		}
		if (this._showRenewLoadoutButton)
		{
			for (int j = 0; j < LoadoutManager.GearSlots.Length; j++)
			{
				Rect position2 = array2[j];
				global::LoadoutSlotType key = LoadoutManager.GearSlots[j];
				this._renewItem[key] = GUI.Toggle(position2, this._renewItem[key], (!this._renewItem[key]) ? "<" : ">", BlueStonez.panelquad_toggle);
			}
		}
		GUITools.EndScrollView();
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x0004FCC4 File Offset: 0x0004DEC4
	private void DrawQuickItemLoadout(Rect position)
	{
		this._loadoutQuickUseFuncScroll = GUITools.BeginScrollView(position, this._loadoutQuickUseFuncScroll, new Rect(0f, 0f, position.width - 20f, 285f), false, false, true);
		Rect position2 = default(Rect);
		for (int i = 0; i < 3; i++)
		{
			global::LoadoutSlotType loadoutSlotType = global::LoadoutSlotType.QuickUseItem1 + i;
			int itemIdOnSlot = Singleton<LoadoutManager>.Instance.GetItemIdOnSlot(loadoutSlotType);
			InventoryItem item = Singleton<InventoryManager>.Instance.GetItem(itemIdOnSlot);
			this.DrawLoadoutQuickUseItem(LocalizedStrings.QuickItem + " " + (i + 1).ToString(), item, loadoutSlotType, new Rect(0f, (float)(70 * i), position.width - 5f, 70f), AutoMonoBehaviour<InputManager>.Instance.GetKeyAssignmentString(GameInputKey.QuickItem1 + i));
			if (Singleton<InventoryManager>.Instance.CurrentQuickItemSot == loadoutSlotType)
			{
				position2.x = 5f;
				position2.y = (float)(70 * i);
				position2.width = position.width - 16f;
				position2.height = 60f;
			}
		}
		GUI.color = new Color(1f, 1f, 1f, 0.5f);
		GUI.Box(position2, GUIContent.none, BlueStonez.group_grey81);
		GUI.color = Color.white;
		GUI.color = Color.white;
		GUITools.EndScrollView();
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x0004FE24 File Offset: 0x0004E024
	private void DrawLoadoutWeaponItem(string slotName, InventoryItem item, Rect rect, global::LoadoutSlotType slot)
	{
		Rect rect2 = new Rect(rect.x + 5f, rect.y + 5f, rect.width - 10f, rect.height - 10f);
		GUI.BeginGroup(rect2);
		if (item.Item != null)
		{
			item.Item.DrawIcon(new Rect(rect2.width - 60f, 0f, 48f, 48f));
			GUI.Label(new Rect(0f, 5f, rect2.width - 65f, 18f), slotName, BlueStonez.label_interparkmed_18pt_right);
			GUI.Label(new Rect(0f, 30f, rect2.width - 65f, 12f), item.Item.Name, BlueStonez.label_interparkmed_10pt_right);
			GUI.Label(new Rect(0f, rect2.height - 1f, rect2.width, 1f), string.Empty, BlueStonez.horizontal_line_grey95);
		}
		else
		{
			GUI.Label(new Rect(rect2.width - 60f, 0f, 48f, 48f), GUIContent.none, BlueStonez.item_slot_large);
			GUI.Label(new Rect(0f, 5f, rect2.width - 65f, 18f), slotName, BlueStonez.label_interparkmed_18pt_right);
			GUI.Label(new Rect(0f, rect2.height - 1f, rect2.width, 1f), string.Empty, BlueStonez.horizontal_line_grey95);
		}
		GUI.EndGroup();
		if (rect.Contains(Event.current.mousePosition) && !PanelManager.IsAnyPanelOpen && !PopupSystem.IsAnyPopupOpen)
		{
			if (Event.current.type == EventType.MouseDown)
			{
				if (Singleton<InventoryManager>.Instance.CurrentWeaponSlot != slot)
				{
					Singleton<InventoryManager>.Instance.CurrentWeaponSlot = slot;
					GameState.Current.Avatar.ShowWeapon(slot);
				}
			}
			else
			{
				AutoMonoBehaviour<ItemToolTip>.Instance.SetItem(item.Item, rect2, PopupViewSide.Left, item.DaysRemaining, BuyingDurationType.None);
			}
		}
		Color? color = null;
		if (Singleton<DragAndDrop>.Instance.IsDragging && Singleton<DragAndDrop>.Instance.DraggedItem.Item.View.ItemClass == UberstrikeItemClass.WeaponMelee && slot == global::LoadoutSlotType.WeaponMelee)
		{
			color = new Color?(new Color(1f, 1f, 1f, 0.1f));
		}
		else if (Singleton<DragAndDrop>.Instance.IsDragging && Singleton<DragAndDrop>.Instance.DraggedItem.Item.View.ItemClass != UberstrikeItemClass.WeaponMelee && slot != global::LoadoutSlotType.WeaponMelee)
		{
			color = new Color?(new Color(1f, 1f, 1f, 0.1f));
		}
		else if (slot == this._highlightedSlot)
		{
			color = new Color?(new Color(1f, 1f, 1f, this._highlightedSlotAlpha));
		}
		Rect rect3 = new Rect(rect2.x, rect2.y - 5f, rect2.width - 6f, rect2.height);
		Singleton<DragAndDrop>.Instance.DrawSlot<ShopPageGUI.ShopDragSlot>(rect3, new ShopPageGUI.ShopDragSlot
		{
			Item = item.Item,
			Slot = slot
		}, new Action<int, ShopPageGUI.ShopDragSlot>(this.OnDropLoadout), color, false);
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x000501B0 File Offset: 0x0004E3B0
	private void DrawLoadoutGearItem(string slotName, InventoryItem item, global::LoadoutSlotType loadoutSlotType, Rect rect, UberstrikeItemClass itemClass)
	{
		Rect rect2 = new Rect(rect.x + 5f, rect.y + 5f, rect.width - 10f, rect.height - 10f);
		GUI.BeginGroup(rect2);
		if (item.Item != null && !Singleton<ItemManager>.Instance.IsDefaultGearItem(item.Item.View.PrefabName))
		{
			item.Item.DrawIcon(new Rect(rect2.width - 60f, 0f, 48f, 48f));
			GUI.Label(new Rect(0f, 5f, rect2.width - 65f, 18f), slotName, BlueStonez.label_interparkmed_18pt_right);
			GUI.Label(new Rect(0f, 30f, rect2.width - 65f, 12f), item.Item.Name, BlueStonez.label_interparkmed_10pt_right);
		}
		else
		{
			GUI.Label(new Rect(rect2.width - 60f, 0f, 48f, 48f), GUIContent.none, BlueStonez.item_slot_large);
			GUI.Label(new Rect(0f, 5f, rect2.width - 65f, 18f), slotName, BlueStonez.label_interparkmed_18pt_right);
		}
		GUI.Label(new Rect(0f, rect2.height - 5f, rect2.width, 1f), string.Empty, BlueStonez.horizontal_line_grey95);
		GUI.EndGroup();
		if (rect.Contains(Event.current.mousePosition) && !PanelManager.IsAnyPanelOpen && !PopupSystem.IsAnyPopupOpen)
		{
			if (Event.current.type == EventType.MouseDown)
			{
				if (item.Item != null && GameState.Current.Avatar.Decorator && GameState.Current.Avatar.Decorator.AnimationController)
				{
					GameState.Current.Avatar.Decorator.AnimationController.TriggerGearAnimation(item.Item.View.ItemClass);
				}
			}
			else
			{
				AutoMonoBehaviour<ItemToolTip>.Instance.SetItem(item.Item, rect2, PopupViewSide.Left, item.DaysRemaining, BuyingDurationType.None);
			}
		}
		Color? color = null;
		if (Singleton<DragAndDrop>.Instance.IsDragging && Singleton<DragAndDrop>.Instance.DraggedItem.Item.View.ItemClass == itemClass)
		{
			color = new Color?(new Color(1f, 1f, 1f, 0.2f));
		}
		else if (loadoutSlotType == this._highlightedSlot)
		{
			color = new Color?(new Color(1f, 1f, 1f, this._highlightedSlotAlpha));
		}
		Singleton<DragAndDrop>.Instance.DrawSlot<ShopPageGUI.ShopDragSlot>(new Rect(rect2.x, rect2.y - 15f, rect2.width, rect2.height + 11f), new ShopPageGUI.ShopDragSlot
		{
			Item = item.Item,
			Slot = loadoutSlotType
		}, new Action<int, ShopPageGUI.ShopDragSlot>(this.OnDropLoadout), color, false);
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x000504FC File Offset: 0x0004E6FC
	private void DrawLoadoutQuickUseItem(string slotName, InventoryItem itemQuickUse, global::LoadoutSlotType loadoutSlotType, Rect rect, string slotTag)
	{
		Rect rect2 = new Rect(rect.x + 5f, rect.y + 5f, rect.width - 10f, rect.height - 10f);
		GUI.BeginGroup(rect2);
		if (itemQuickUse != null && itemQuickUse.Item != null)
		{
			itemQuickUse.Item.DrawIcon(new Rect(rect2.width - 60f, 0f, 48f, 48f));
			GUI.Label(new Rect(3f, 5f, rect2.width - 65f, 26f), itemQuickUse.Item.Name, BlueStonez.label_interparkbold_13pt_left);
			if (itemQuickUse.AmountRemaining > 0)
			{
				GUI.color = Color.white.SetAlpha(0.5f);
				GUI.Label(new Rect(3f, 34f, rect2.width - 65f, 12f), string.Format("Uses: {0}", itemQuickUse.AmountRemaining), BlueStonez.label_interparkbold_11pt_left);
				GUI.color = Color.white;
			}
			GUI.Label(new Rect(0f, rect2.height - 1f, rect2.width, 1f), string.Empty, BlueStonez.horizontal_line_grey95);
		}
		else
		{
			GUI.Label(new Rect(rect2.width - 60f, 0f, 48f, 48f), GUIContent.none, BlueStonez.item_slot_large);
			GUI.Label(new Rect(0f, 5f, rect2.width - 65f, 18f), slotName, BlueStonez.label_interparkmed_18pt_right);
			GUI.Label(new Rect(0f, rect2.height - 1f, rect2.width, 1f), string.Empty, BlueStonez.horizontal_line_grey95);
		}
		GUI.EndGroup();
		if (rect.Contains(Event.current.mousePosition) && !PanelManager.IsAnyPanelOpen && !PopupSystem.IsAnyPopupOpen)
		{
			if (Event.current.type == EventType.MouseDown)
			{
				Singleton<InventoryManager>.Instance.CurrentQuickItemSot = loadoutSlotType;
			}
			else
			{
				AutoMonoBehaviour<ItemToolTip>.Instance.SetItem(itemQuickUse.Item, rect2, PopupViewSide.Left, -1, BuyingDurationType.None);
			}
		}
		Color? color = null;
		if (Singleton<DragAndDrop>.Instance.IsDragging && Singleton<DragAndDrop>.Instance.DraggedItem.Item.View.ItemType == UberstrikeItemType.QuickUse)
		{
			color = new Color?(new Color(1f, 1f, 1f, 0.1f));
		}
		else if (loadoutSlotType == this._highlightedSlot)
		{
			color = new Color?(new Color(1f, 1f, 1f, this._highlightedSlotAlpha));
		}
		Singleton<DragAndDrop>.Instance.DrawSlot<ShopPageGUI.ShopDragSlot>(new Rect(rect2.x, rect2.y - 5f, rect2.width - 6f, rect2.height), new ShopPageGUI.ShopDragSlot
		{
			Item = itemQuickUse.Item,
			Slot = loadoutSlotType
		}, new Action<int, ShopPageGUI.ShopDragSlot>(this.OnDropLoadout), color, false);
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x0000934C File Offset: 0x0000754C
	private void OnDropAvatar(int slotId, ShopPageGUI.ShopDragSlot item)
	{
		if (item.Slot == global::LoadoutSlotType.Shop)
		{
			this.EquipItemFromArea(item.Item, global::LoadoutSlotType.None, ShopArea.Shop);
		}
		else
		{
			this.UnequipItem(item.Item);
		}
	}

	// Token: 0x06000BF9 RID: 3065 RVA: 0x0000937E File Offset: 0x0000757E
	private void OnDropShop(int slotId, ShopPageGUI.ShopDragSlot item)
	{
		if (item.Slot != global::LoadoutSlotType.Shop)
		{
			this.UnequipItem(item.Item);
		}
	}

	// Token: 0x06000BFA RID: 3066 RVA: 0x0005083C File Offset: 0x0004EA3C
	private void OnDropLoadout(int slotId, ShopPageGUI.ShopDragSlot item)
	{
		Singleton<InventoryManager>.Instance.CurrentWeaponSlot = (global::LoadoutSlotType)slotId;
		if (item.Slot == global::LoadoutSlotType.Shop)
		{
			this.EquipItemFromArea(item.Item, (global::LoadoutSlotType)slotId, ShopArea.Shop);
		}
		else
		{
			switch (slotId)
			{
			case 8:
			case 9:
			case 10:
				if (item.Slot >= global::LoadoutSlotType.WeaponPrimary && item.Slot <= global::LoadoutSlotType.WeaponTertiary)
				{
					this.SwapWeapons(item.Slot, (global::LoadoutSlotType)slotId);
				}
				break;
			case 11:
			case 12:
			case 13:
				this.SwapQuickItems(item.Slot, (global::LoadoutSlotType)slotId);
				break;
			}
		}
	}

	// Token: 0x06000BFB RID: 3067 RVA: 0x000508E0 File Offset: 0x0004EAE0
	private void OnBeginDrag(IDragSlot item)
	{
		if (item != null)
		{
			switch (item.Item.View.ItemType)
			{
			case UberstrikeItemType.Weapon:
			case UberstrikeItemType.WeaponMod:
				this._loadoutAreaSelection.SetIndex(0);
				this.SelectLoadoutArea(LoadoutArea.Weapons);
				break;
			case UberstrikeItemType.Gear:
				this._loadoutAreaSelection.SetIndex(1);
				this.SelectLoadoutArea(LoadoutArea.Gear);
				break;
			case UberstrikeItemType.QuickUse:
			case UberstrikeItemType.Functional:
				this._loadoutAreaSelection.SetIndex(2);
				this.SelectLoadoutArea(LoadoutArea.QuickItems);
				break;
			}
		}
	}

	// Token: 0x06000BFC RID: 3068 RVA: 0x0000939B File Offset: 0x0000759B
	private void SwapQuickItems(global::LoadoutSlotType slot, global::LoadoutSlotType newslot)
	{
		if (Singleton<LoadoutManager>.Instance.SwapLoadoutItems(slot, newslot))
		{
			Singleton<InventoryManager>.Instance.CurrentQuickItemSot = newslot;
			this.HighlightingSlot(newslot);
		}
	}

	// Token: 0x06000BFD RID: 3069 RVA: 0x000093C0 File Offset: 0x000075C0
	private void SwapWeapons(global::LoadoutSlotType slot, global::LoadoutSlotType newslot)
	{
		if (Singleton<LoadoutManager>.Instance.SwapLoadoutItems(slot, newslot))
		{
			Singleton<InventoryManager>.Instance.CurrentWeaponSlot = newslot;
			this.HighlightingSlot(newslot);
		}
	}

	// Token: 0x04000B44 RID: 2884
	private const int SlotHeight = 70;

	// Token: 0x04000B45 RID: 2885
	private const int LoadoutWidth = 190;

	// Token: 0x04000B46 RID: 2886
	private const int ShopWidth = 590;

	// Token: 0x04000B47 RID: 2887
	private CreditBundlesShopGui _creditsGui = new CreditBundlesShopGui();

	// Token: 0x04000B48 RID: 2888
	private ShopSorting.ItemComparer<IShopItemGUI> _inventoryComparer = new ShopSorting.ItemClassComparer();

	// Token: 0x04000B49 RID: 2889
	private ShopSorting.ItemComparer<IShopItemGUI> _shopComparer = new ShopSorting.LevelComparer();

	// Token: 0x04000B4A RID: 2890
	private bool _firstLogin;

	// Token: 0x04000B4B RID: 2891
	private SelectionGroup<ShopArea> _shopAreaSelection = new SelectionGroup<ShopArea>();

	// Token: 0x04000B4C RID: 2892
	private SelectionGroup<LoadoutArea> _loadoutAreaSelection = new SelectionGroup<LoadoutArea>();

	// Token: 0x04000B4D RID: 2893
	private SelectionGroup<UberstrikeItemType> _typeSelection = new SelectionGroup<UberstrikeItemType>();

	// Token: 0x04000B4E RID: 2894
	private SelectionGroup<UberstrikeItemClass> _weaponClassSelection = new SelectionGroup<UberstrikeItemClass>();

	// Token: 0x04000B4F RID: 2895
	private SelectionGroup<UberstrikeItemClass> _gearClassSelection = new SelectionGroup<UberstrikeItemClass>();

	// Token: 0x04000B50 RID: 2896
	private Rect _rectLabs;

	// Token: 0x04000B51 RID: 2897
	private Rect _shopArea;

	// Token: 0x04000B52 RID: 2898
	private Rect _loadoutArea;

	// Token: 0x04000B53 RID: 2899
	private Vector2 _loadoutWeaponScroll;

	// Token: 0x04000B54 RID: 2900
	private Vector2 _loadoutGearScroll;

	// Token: 0x04000B55 RID: 2901
	private Vector2 _loadoutQuickUseFuncScroll;

	// Token: 0x04000B56 RID: 2902
	private Vector2 _labScroll;

	// Token: 0x04000B57 RID: 2903
	private float _highlightedSlotAlpha = 0.2f;

	// Token: 0x04000B58 RID: 2904
	private global::LoadoutSlotType _highlightedSlot = global::LoadoutSlotType.None;

	// Token: 0x04000B59 RID: 2905
	private List<Rect> _activeLoadoutUsedSpace = new List<Rect>();

	// Token: 0x04000B5A RID: 2906
	private Dictionary<global::LoadoutSlotType, bool> _renewItem = new Dictionary<global::LoadoutSlotType, bool>();

	// Token: 0x04000B5B RID: 2907
	private bool _showRenewLoadoutButton;

	// Token: 0x04000B5C RID: 2908
	private int _skippedDefaultGearCount;

	// Token: 0x04000B5D RID: 2909
	private float shopPositionX;

	// Token: 0x04000B5E RID: 2910
	private List<IShopItemGUI> _shopItemGUIList = new List<IShopItemGUI>();

	// Token: 0x04000B5F RID: 2911
	private List<IShopItemGUI> _inventoryItemGUIList = new List<IShopItemGUI>();

	// Token: 0x04000B60 RID: 2912
	private IShopItemFilter _itemFilter;

	// Token: 0x04000B61 RID: 2913
	private SearchBarGUI _searchBar;

	// Token: 0x04000B62 RID: 2914
	private bool _isReloadingShop;

	// Token: 0x020001AF RID: 431
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ShopDragSlot : IDragSlot
	{
		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x000093ED File Offset: 0x000075ED
		public int Id
		{
			get
			{
				return (int)this.Slot;
			}
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x000093F5 File Offset: 0x000075F5
		// (set) Token: 0x06000C04 RID: 3076 RVA: 0x000093FD File Offset: 0x000075FD
		public IUnityItem Item { get; set; }

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x00009406 File Offset: 0x00007606
		// (set) Token: 0x06000C06 RID: 3078 RVA: 0x0000940E File Offset: 0x0000760E
		public global::LoadoutSlotType Slot { get; set; }
	}
}
