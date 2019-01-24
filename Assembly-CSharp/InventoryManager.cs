using System;
using System.Collections;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020002C5 RID: 709
public class InventoryManager : Singleton<InventoryManager>
{
	// Token: 0x060013DE RID: 5086 RVA: 0x00072CE0 File Offset: 0x00070EE0
	private InventoryManager()
	{
		this._inventoryItems = new Dictionary<int, InventoryItem>();
		this.OnInventoryUpdated = (Action)Delegate.Combine(this.OnInventoryUpdated, new Action(delegate()
		{
		}));
	}

	// Token: 0x1400000D RID: 13
	// (add) Token: 0x060013E0 RID: 5088 RVA: 0x0000D7E2 File Offset: 0x0000B9E2
	// (remove) Token: 0x060013E1 RID: 5089 RVA: 0x0000D7FB File Offset: 0x0000B9FB
	public event Action OnInventoryUpdated;

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x060013E2 RID: 5090 RVA: 0x0000D814 File Offset: 0x0000BA14
	public IEnumerable<InventoryItem> InventoryItems
	{
		get
		{
			return this._inventoryItems.Values;
		}
	}

	// Token: 0x060013E3 RID: 5091 RVA: 0x00072D48 File Offset: 0x00070F48
	public IEnumerator StartUpdateInventoryAndEquipNewItem(IUnityItem item, bool equipNow = false)
	{
		if (item != null)
		{
			IPopupDialog popupDialog = PopupSystem.ShowMessage(LocalizedStrings.UpdatingInventory, LocalizedStrings.WereUpdatingYourInventoryPleaseWait, PopupSystem.AlertType.None);
			yield return UnityRuntime.StartRoutine(Singleton<ItemManager>.Instance.StartGetInventory(false));
			PopupSystem.HideMessage(popupDialog);
			if (equipNow)
			{
				this.EquipItem(item);
			}
			else if (GameState.Current.HasJoinedGame && GameState.Current.IsInGame)
			{
				this.EquipItem(item);
			}
			else if (item.View.ItemProperties.ContainsKey(ItemPropertyType.PointsBoost) || item.View.ItemProperties.ContainsKey(ItemPropertyType.XpBoost))
			{
				InventoryItem invItem = this.GetItem(item.View.ID);
				PopupSystem.ShowItem(item, "\nYou just bought the boost item!\nThis item is activated and expires in " + invItem.DaysRemaining + " days");
			}
			else
			{
				PopupSystem.ShowItem(item, string.Empty);
			}
			yield return UnityRuntime.StartRoutine(Singleton<PlayerDataManager>.Instance.StartGetMember());
		}
		yield break;
	}

	// Token: 0x060013E4 RID: 5092 RVA: 0x00072D80 File Offset: 0x00070F80
	public bool EquipItem(IUnityItem item)
	{
		global::LoadoutSlotType slotType = global::LoadoutSlotType.None;
		InventoryItem inventoryItem;
		if (this.TryGetInventoryItem(item.View.ID, out inventoryItem) && inventoryItem.IsValid && inventoryItem.Item.View.ItemType == UberstrikeItemType.Weapon && GameState.Current.Map != null)
		{
			slotType = InventoryManager.FindBestSlotToEquipWeapon(item);
		}
		return this.EquipItemOnSlot(item.View.ID, slotType);
	}

	// Token: 0x060013E5 RID: 5093 RVA: 0x00072DF8 File Offset: 0x00070FF8
	public static global::LoadoutSlotType FindBestSlotToEquipWeapon(IUnityItem weapon)
	{
		UberstrikeItemClass itemClass = weapon.View.ItemClass;
		if (itemClass == UberstrikeItemClass.WeaponMelee)
		{
			return global::LoadoutSlotType.WeaponMelee;
		}
		global::LoadoutSlotType itemClassSlotType = Singleton<LoadoutManager>.Instance.Loadout.GetItemClassSlotType(itemClass);
		if (itemClassSlotType != global::LoadoutSlotType.None)
		{
			return itemClassSlotType;
		}
		global::LoadoutSlotType firstEmptyWeaponSlot = Singleton<LoadoutManager>.Instance.Loadout.GetFirstEmptyWeaponSlot();
		if (firstEmptyWeaponSlot != global::LoadoutSlotType.None)
		{
			return firstEmptyWeaponSlot;
		}
		return global::LoadoutSlotType.WeaponPrimary;
	}

	// Token: 0x060013E6 RID: 5094 RVA: 0x0000D821 File Offset: 0x0000BA21
	public void UnequipWeaponSlot(global::LoadoutSlotType slotType)
	{
		Singleton<LoadoutManager>.Instance.ResetSlot(slotType);
		GameState.Current.Avatar.UnassignWeapon(slotType);
	}

	// Token: 0x060013E7 RID: 5095 RVA: 0x00072E50 File Offset: 0x00071050
	public bool EquipItemOnSlot(int itemId, global::LoadoutSlotType slotType)
	{
		InventoryItem inventoryItem;
		if (this.TryGetInventoryItem(itemId, out inventoryItem) && inventoryItem.IsValid)
		{
			if (Singleton<LoadoutManager>.Instance.IsItemEquipped(itemId))
			{
				global::LoadoutSlotType loadoutSlotType;
				if (Singleton<LoadoutManager>.Instance.TryGetSlotForItem(inventoryItem.Item, out loadoutSlotType))
				{
					global::EventHandler.Global.Fire(new ShopEvents.ShopHighlightSlot
					{
						SlotType = loadoutSlotType
					});
					Singleton<TemporaryLoadoutManager>.Instance.ResetLoadout(loadoutSlotType);
				}
			}
			else
			{
				this.HighlightItem(itemId, false);
				switch (inventoryItem.Item.View.ItemType)
				{
				case UberstrikeItemType.Weapon:
					if (inventoryItem.Item.View.ItemClass == UberstrikeItemClass.WeaponMelee)
					{
						slotType = global::LoadoutSlotType.WeaponMelee;
						Singleton<LoadoutManager>.Instance.RemoveDuplicateWeaponClass(inventoryItem);
						Singleton<LoadoutManager>.Instance.SetLoadoutItem(slotType, inventoryItem.Item);
						Singleton<LoadoutManager>.Instance.EquipWeapon(slotType, inventoryItem.Item);
						AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.WeaponSwitch, 0UL);
					}
					else
					{
						if (slotType == global::LoadoutSlotType.None || slotType == global::LoadoutSlotType.WeaponMelee)
						{
							slotType = this.GetNextFreeWeaponSlot();
						}
						global::LoadoutSlotType loadoutSlotType2 = slotType;
						if (Singleton<LoadoutManager>.Instance.RemoveDuplicateWeaponClass(inventoryItem, ref loadoutSlotType2) && slotType != loadoutSlotType2)
						{
							Singleton<LoadoutManager>.Instance.SwapLoadoutItems(slotType, loadoutSlotType2);
						}
						Singleton<LoadoutManager>.Instance.SetLoadoutItem(slotType, inventoryItem.Item);
						Singleton<LoadoutManager>.Instance.EquipWeapon(slotType, inventoryItem.Item);
						AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.EquipWeapon, 0UL);
					}
					goto IL_2B6;
				case UberstrikeItemType.Gear:
					slotType = ItemUtil.SlotFromItemClass(inventoryItem.Item.View.ItemClass);
					Singleton<LoadoutManager>.Instance.SetLoadoutItem(slotType, inventoryItem.Item);
					AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.EquipGear, 0UL);
					if (GameState.Current.Avatar != null)
					{
						GameState.Current.Avatar.HideWeapons();
					}
					GameState.Current.Avatar.Decorator.AnimationController.TriggerGearAnimation(inventoryItem.Item.View.ItemClass);
					goto IL_2B6;
				case UberstrikeItemType.QuickUse:
					this.EquipQuickItemOnSlot(inventoryItem, slotType);
					goto IL_2B6;
				case UberstrikeItemType.Functional:
					if (inventoryItem.Item.Equippable)
					{
						if (slotType == global::LoadoutSlotType.None)
						{
							slotType = this.GetNextFreeFunctionalSlot();
						}
						global::LoadoutSlotType loadoutSlotType3 = slotType;
						if (Singleton<LoadoutManager>.Instance.RemoveDuplicateFunctionalItemClass(inventoryItem, ref loadoutSlotType3) && slotType != loadoutSlotType3)
						{
							Singleton<LoadoutManager>.Instance.SwapLoadoutItems(slotType, loadoutSlotType3);
						}
						Singleton<LoadoutManager>.Instance.SetLoadoutItem(slotType, inventoryItem.Item);
						AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.EquipItem, 0UL);
					}
					goto IL_2B6;
				}
				AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.EquipItem, 0UL);
				Debug.LogError("Equip item of type: " + inventoryItem.Item.View.ItemType);
				IL_2B6:
				Singleton<TemporaryLoadoutManager>.Instance.SetLoadoutItem(slotType, inventoryItem.Item);
				global::EventHandler.Global.Fire(new ShopEvents.ShopHighlightSlot
				{
					SlotType = slotType
				});
			}
			return true;
		}
		return false;
	}

	// Token: 0x060013E8 RID: 5096 RVA: 0x00073144 File Offset: 0x00071344
	private void EquipQuickItemOnSlot(InventoryItem item, global::LoadoutSlotType slotType)
	{
		if (slotType < global::LoadoutSlotType.QuickUseItem1 || slotType > global::LoadoutSlotType.QuickUseItem3)
		{
			slotType = this.GetNextFreeQuickItemSlot();
		}
		global::LoadoutSlotType loadoutSlotType = slotType;
		if (slotType != loadoutSlotType && Singleton<LoadoutManager>.Instance.RemoveDuplicateQuickItemClass(item.Item.View as UberStrikeItemQuickView, ref loadoutSlotType))
		{
			Singleton<LoadoutManager>.Instance.SwapLoadoutItems(slotType, loadoutSlotType);
		}
		AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.EquipItem, 0UL);
		Singleton<LoadoutManager>.Instance.SetLoadoutItem(slotType, item.Item);
	}

	// Token: 0x060013E9 RID: 5097 RVA: 0x000731C4 File Offset: 0x000713C4
	private global::LoadoutSlotType GetNextFreeWeaponSlot()
	{
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.WeaponPrimary))
		{
			return global::LoadoutSlotType.WeaponPrimary;
		}
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.WeaponSecondary))
		{
			return global::LoadoutSlotType.WeaponSecondary;
		}
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.WeaponTertiary))
		{
			return global::LoadoutSlotType.WeaponTertiary;
		}
		if (this.CurrentWeaponSlot == global::LoadoutSlotType.WeaponPrimary || this.CurrentWeaponSlot == global::LoadoutSlotType.WeaponSecondary || this.CurrentWeaponSlot == global::LoadoutSlotType.WeaponTertiary)
		{
			return this.CurrentWeaponSlot;
		}
		return global::LoadoutSlotType.WeaponPrimary;
	}

	// Token: 0x060013EA RID: 5098 RVA: 0x0007323C File Offset: 0x0007143C
	private global::LoadoutSlotType GetNextFreeFunctionalSlot()
	{
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.FunctionalItem1))
		{
			return global::LoadoutSlotType.FunctionalItem1;
		}
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.FunctionalItem2))
		{
			return global::LoadoutSlotType.FunctionalItem2;
		}
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.FunctionalItem3))
		{
			return global::LoadoutSlotType.FunctionalItem3;
		}
		switch (this.CurrentFunctionalSlot)
		{
		case global::LoadoutSlotType.FunctionalItem1:
			return global::LoadoutSlotType.FunctionalItem2;
		case global::LoadoutSlotType.FunctionalItem2:
			return global::LoadoutSlotType.FunctionalItem3;
		case global::LoadoutSlotType.FunctionalItem3:
			return global::LoadoutSlotType.FunctionalItem1;
		default:
			return this.CurrentFunctionalSlot;
		}
	}

	// Token: 0x060013EB RID: 5099 RVA: 0x000732B8 File Offset: 0x000714B8
	private global::LoadoutSlotType GetNextFreeQuickItemSlot()
	{
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.QuickUseItem1))
		{
			return global::LoadoutSlotType.QuickUseItem1;
		}
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.QuickUseItem2))
		{
			return global::LoadoutSlotType.QuickUseItem2;
		}
		if (!Singleton<LoadoutManager>.Instance.HasLoadoutItem(global::LoadoutSlotType.QuickUseItem3))
		{
			return global::LoadoutSlotType.QuickUseItem3;
		}
		switch (this.CurrentQuickItemSot)
		{
		case global::LoadoutSlotType.QuickUseItem1:
			return global::LoadoutSlotType.QuickUseItem2;
		case global::LoadoutSlotType.QuickUseItem2:
			return global::LoadoutSlotType.QuickUseItem3;
		case global::LoadoutSlotType.QuickUseItem3:
			return global::LoadoutSlotType.QuickUseItem1;
		default:
			return this.CurrentQuickItemSot;
		}
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x00073334 File Offset: 0x00071534
	public static global::LoadoutSlotType GetSlotTypeForGear(IUnityItem gearItem)
	{
		if (gearItem != null)
		{
			switch (gearItem.View.ItemClass)
			{
			case UberstrikeItemClass.GearBoots:
				return global::LoadoutSlotType.GearBoots;
			case UberstrikeItemClass.GearHead:
				return global::LoadoutSlotType.GearHead;
			case UberstrikeItemClass.GearFace:
				return global::LoadoutSlotType.GearFace;
			case UberstrikeItemClass.GearUpperBody:
				return global::LoadoutSlotType.GearUpperBody;
			case UberstrikeItemClass.GearLowerBody:
				return global::LoadoutSlotType.GearLowerBody;
			case UberstrikeItemClass.GearGloves:
				return global::LoadoutSlotType.GearGloves;
			case UberstrikeItemClass.GearHolo:
				return global::LoadoutSlotType.GearHolo;
			}
			return global::LoadoutSlotType.None;
		}
		return global::LoadoutSlotType.None;
	}

	// Token: 0x060013ED RID: 5101 RVA: 0x000733A4 File Offset: 0x000715A4
	public List<InventoryItem> GetAllItems(bool ignoreEquippedItems)
	{
		List<InventoryItem> list = new List<InventoryItem>();
		foreach (InventoryItem inventoryItem in this._inventoryItems.Values)
		{
			bool flag = inventoryItem.DaysRemaining <= 0 && inventoryItem.Item.View.Prices != null && inventoryItem.Item.View.Prices.Count > 0;
			if (inventoryItem.DaysRemaining > 0 || inventoryItem.IsPermanent || flag)
			{
				if (ignoreEquippedItems)
				{
					if (!Singleton<LoadoutManager>.Instance.IsItemEquipped(inventoryItem.Item.View.ID))
					{
						list.Add(inventoryItem);
					}
				}
				else
				{
					list.Add(inventoryItem);
				}
			}
		}
		return list;
	}

	// Token: 0x060013EE RID: 5102 RVA: 0x00073498 File Offset: 0x00071698
	public int GetGearItem(int itemID, UberstrikeItemClass itemClass)
	{
		InventoryItem inventoryItem;
		if (this._inventoryItems.TryGetValue(itemID, out inventoryItem) && inventoryItem != null && inventoryItem.Item.View.ItemType == UberstrikeItemType.Gear)
		{
			return inventoryItem.Item.View.ID;
		}
		IUnityItem unityItem;
		if (Singleton<ItemManager>.Instance.TryGetDefaultItem(itemClass, out unityItem))
		{
			return unityItem.View.ID;
		}
		return 0;
	}

	// Token: 0x060013EF RID: 5103 RVA: 0x00073504 File Offset: 0x00071704
	public InventoryItem GetItem(int itemID)
	{
		InventoryItem inventoryItem;
		if (this._inventoryItems.TryGetValue(itemID, out inventoryItem) && inventoryItem != null)
		{
			return inventoryItem;
		}
		return InventoryManager.EmptyItem;
	}

	// Token: 0x060013F0 RID: 5104 RVA: 0x00073534 File Offset: 0x00071734
	public InventoryItem GetWeaponItem(int itemId)
	{
		InventoryItem inventoryItem;
		if (this._inventoryItems.TryGetValue(itemId, out inventoryItem) && inventoryItem != null && inventoryItem.Item.View.ItemType == UberstrikeItemType.Weapon)
		{
			return inventoryItem;
		}
		return InventoryManager.EmptyItem;
	}

	// Token: 0x060013F1 RID: 5105 RVA: 0x0000D83E File Offset: 0x0000BA3E
	public bool TryGetInventoryItem(int itemID, out InventoryItem item)
	{
		return this._inventoryItems.TryGetValue(itemID, out item) && item != null && item.Item != null;
	}

	// Token: 0x060013F2 RID: 5106 RVA: 0x0000D869 File Offset: 0x0000BA69
	public bool HasClanLicense()
	{
		return this.Contains(1234);
	}

	// Token: 0x060013F3 RID: 5107 RVA: 0x0000D876 File Offset: 0x0000BA76
	public bool IsItemValidForDays(InventoryItem item, int days)
	{
		return item != null && (item.DaysRemaining > days || item.IsPermanent);
	}

	// Token: 0x060013F4 RID: 5108 RVA: 0x00073578 File Offset: 0x00071778
	public bool Contains(int itemId)
	{
		InventoryItem item;
		return this._inventoryItems.TryGetValue(itemId, out item) && this.IsItemValidForDays(item, 0);
	}

	// Token: 0x060013F5 RID: 5109 RVA: 0x000735A4 File Offset: 0x000717A4
	public void UpdateInventoryItems(List<ItemInventoryView> inventory)
	{
		if (Singleton<ItemManager>.Instance.ShopItemCount == 0)
		{
			Debug.LogWarning("Stopped updating inventory because shop is empty!");
			return;
		}
		HashSet<int> hashSet = new HashSet<int>(this._inventoryItems.Keys);
		this._inventoryItems.Clear();
		foreach (ItemInventoryView itemInventoryView in inventory)
		{
			IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(itemInventoryView.ItemId);
			if (itemInShop != null && itemInShop.View.ID == itemInventoryView.ItemId)
			{
				IDictionary<int, InventoryItem> inventoryItems = this._inventoryItems;
				int id = itemInShop.View.ID;
				InventoryItem inventoryItem = new InventoryItem(itemInShop);
				inventoryItem.IsPermanent = (itemInventoryView.ExpirationDate == null);
				inventoryItem.AmountRemaining = itemInventoryView.AmountRemaining;
				InventoryItem inventoryItem2 = inventoryItem;
				DateTime? expirationDate = itemInventoryView.ExpirationDate;
				inventoryItem2.ExpirationDate = new DateTime?((expirationDate == null) ? DateTime.MinValue : expirationDate.Value);
				inventoryItem.IsHighlighted = (hashSet.Count > 0 && !hashSet.Contains(itemInShop.View.ID));
				inventoryItems[id] = inventoryItem;
			}
			else
			{
				Debug.LogWarning(string.Concat(new object[]
				{
					"Inventory Item not found: ",
					itemInventoryView.ItemId,
					" ",
					itemInShop == null
				}));
			}
		}
		this.OnInventoryUpdated();
	}

	// Token: 0x060013F6 RID: 5110 RVA: 0x0007374C File Offset: 0x0007194C
	internal void HighlightItem(int itemId, bool isHighlighted)
	{
		InventoryItem inventoryItem;
		if (this._inventoryItems.TryGetValue(itemId, out inventoryItem) && inventoryItem != null)
		{
			inventoryItem.IsHighlighted = isHighlighted;
		}
	}

	// Token: 0x060013F7 RID: 5111 RVA: 0x0007377C File Offset: 0x0007197C
	public void EnableAllItems()
	{
		Debug.Log("PopulateCompleteInventory");
		this._inventoryItems.Clear();
		foreach (IUnityItem unityItem in Singleton<ItemManager>.Instance.ShopItems)
		{
			this._inventoryItems.Add(unityItem.View.ID, new InventoryItem(unityItem)
			{
				IsPermanent = true,
				AmountRemaining = 0,
				ExpirationDate = new DateTime?(DateTime.MaxValue)
			});
		}
	}

	// Token: 0x0400135E RID: 4958
	private IDictionary<int, InventoryItem> _inventoryItems;

	// Token: 0x0400135F RID: 4959
	public global::LoadoutSlotType CurrentWeaponSlot = global::LoadoutSlotType.WeaponPrimary;

	// Token: 0x04001360 RID: 4960
	public global::LoadoutSlotType CurrentQuickItemSot = global::LoadoutSlotType.QuickUseItem1;

	// Token: 0x04001361 RID: 4961
	public global::LoadoutSlotType CurrentFunctionalSlot = global::LoadoutSlotType.FunctionalItem1;

	// Token: 0x04001362 RID: 4962
	private static readonly InventoryItem EmptyItem = new InventoryItem(null);
}
