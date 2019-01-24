using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UberStrike.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x020002CE RID: 718
public class LoadoutManager : Singleton<LoadoutManager>
{
	// Token: 0x0600142A RID: 5162 RVA: 0x000741BC File Offset: 0x000723BC
	private LoadoutManager()
	{
		Dictionary<global::LoadoutSlotType, IUnityItem> dictionary = new Dictionary<global::LoadoutSlotType, IUnityItem>();
		global::LoadoutSlotType[] array = new global::LoadoutSlotType[]
		{
			global::LoadoutSlotType.GearHead,
			global::LoadoutSlotType.GearGloves,
			global::LoadoutSlotType.GearUpperBody,
			global::LoadoutSlotType.GearLowerBody,
			global::LoadoutSlotType.GearBoots
		};
		int[] array2 = new int[]
		{
			1084,
			1086,
			1087,
			1088,
			1089
		};
		for (int i = 0; i < array.Length; i++)
		{
			IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(array2[i]);
			if (itemInShop != null)
			{
				dictionary.Add(array[i], itemInShop);
			}
		}
		this.Loadout = new Loadout(dictionary);
	}

	// Token: 0x170004CF RID: 1231
	// (get) Token: 0x0600142C RID: 5164 RVA: 0x0000D9BA File Offset: 0x0000BBBA
	// (set) Token: 0x0600142D RID: 5165 RVA: 0x0000D9C2 File Offset: 0x0000BBC2
	public Loadout Loadout { get; private set; }

	// Token: 0x0600142E RID: 5166 RVA: 0x00074308 File Offset: 0x00072508
	public void EquipWeapon(global::LoadoutSlotType weaponSlot, IUnityItem itemWeapon)
	{
		if (itemWeapon != null)
		{
			GameObject gameObject = itemWeapon.Create(Vector3.zero, Quaternion.identity);
			if (gameObject)
			{
				BaseWeaponDecorator component = gameObject.GetComponent<BaseWeaponDecorator>();
				component.EnableShootAnimation = false;
				GameState.Current.Avatar.AssignWeapon(weaponSlot, component, itemWeapon);
				GameState.Current.Avatar.ShowWeapon(weaponSlot);
			}
			else
			{
				GameState.Current.Avatar.UnassignWeapon(weaponSlot);
			}
		}
		else
		{
			GameState.Current.Avatar.UnassignWeapon(weaponSlot);
		}
	}

	// Token: 0x0600142F RID: 5167 RVA: 0x00074394 File Offset: 0x00072594
	public void UpdateLoadout(LoadoutView view)
	{
		if (view.Head == 0)
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearHead, Singleton<ItemManager>.Instance.GetItemInShop(1084));
		}
		else
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearHead, Singleton<ItemManager>.Instance.GetItemInShop(view.Head));
		}
		if (view.Gloves == 0)
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearGloves, Singleton<ItemManager>.Instance.GetItemInShop(1086));
		}
		else
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearGloves, Singleton<ItemManager>.Instance.GetItemInShop(view.Gloves));
		}
		if (view.UpperBody == 0)
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearUpperBody, Singleton<ItemManager>.Instance.GetItemInShop(1087));
		}
		else
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearUpperBody, Singleton<ItemManager>.Instance.GetItemInShop(view.UpperBody));
		}
		if (view.LowerBody == 0)
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearLowerBody, Singleton<ItemManager>.Instance.GetItemInShop(1088));
		}
		else
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearLowerBody, Singleton<ItemManager>.Instance.GetItemInShop(view.LowerBody));
		}
		if (view.Boots == 0)
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearBoots, Singleton<ItemManager>.Instance.GetItemInShop(1089));
		}
		else
		{
			this.Loadout.SetSlot(global::LoadoutSlotType.GearBoots, Singleton<ItemManager>.Instance.GetItemInShop(view.Boots));
		}
		this.Loadout.SetSlot(global::LoadoutSlotType.GearFace, Singleton<ItemManager>.Instance.GetItemInShop(view.Face));
		this.Loadout.SetSlot(global::LoadoutSlotType.GearHolo, Singleton<ItemManager>.Instance.GetItemInShop(view.Webbing));
		this.Loadout.SetSlot(global::LoadoutSlotType.WeaponMelee, Singleton<ItemManager>.Instance.GetItemInShop(view.MeleeWeapon));
		this.Loadout.SetSlot(global::LoadoutSlotType.WeaponPrimary, Singleton<ItemManager>.Instance.GetItemInShop(view.Weapon1));
		this.Loadout.SetSlot(global::LoadoutSlotType.WeaponSecondary, Singleton<ItemManager>.Instance.GetItemInShop(view.Weapon2));
		this.Loadout.SetSlot(global::LoadoutSlotType.WeaponTertiary, Singleton<ItemManager>.Instance.GetItemInShop(view.Weapon3));
		this.Loadout.SetSlot(global::LoadoutSlotType.QuickUseItem1, Singleton<ItemManager>.Instance.GetItemInShop(view.QuickItem1));
		this.Loadout.SetSlot(global::LoadoutSlotType.QuickUseItem2, Singleton<ItemManager>.Instance.GetItemInShop(view.QuickItem2));
		this.Loadout.SetSlot(global::LoadoutSlotType.QuickUseItem3, Singleton<ItemManager>.Instance.GetItemInShop(view.QuickItem3));
		this.Loadout.SetSlot(global::LoadoutSlotType.FunctionalItem1, Singleton<ItemManager>.Instance.GetItemInShop(view.FunctionalItem1));
		this.Loadout.SetSlot(global::LoadoutSlotType.FunctionalItem2, Singleton<ItemManager>.Instance.GetItemInShop(view.FunctionalItem2));
		this.Loadout.SetSlot(global::LoadoutSlotType.FunctionalItem3, Singleton<ItemManager>.Instance.GetItemInShop(view.FunctionalItem3));
		this.UpdateArmor();
	}

	// Token: 0x06001430 RID: 5168 RVA: 0x00074664 File Offset: 0x00072864
	public bool RemoveDuplicateWeaponClass(InventoryItem baseItem)
	{
		global::LoadoutSlotType loadoutSlotType = global::LoadoutSlotType.None;
		return this.RemoveDuplicateWeaponClass(baseItem, ref loadoutSlotType);
	}

	// Token: 0x06001431 RID: 5169 RVA: 0x00074680 File Offset: 0x00072880
	public bool RemoveDuplicateWeaponClass(InventoryItem baseItem, ref global::LoadoutSlotType updatedSlot)
	{
		bool result = false;
		if (baseItem != null && baseItem.Item.View.ItemType == UberstrikeItemType.Weapon)
		{
			foreach (global::LoadoutSlotType loadoutSlotType in LoadoutManager.WeaponSlots)
			{
				InventoryItem inventoryItem;
				if (this.TryGetItemInSlot(loadoutSlotType, out inventoryItem) && inventoryItem.Item.View.ItemClass == baseItem.Item.View.ItemClass && inventoryItem.Item.View.ID != baseItem.Item.View.ID)
				{
					GameState.Current.Avatar.UnassignWeapon(loadoutSlotType);
					this.ResetSlot(loadoutSlotType);
					updatedSlot = loadoutSlotType;
					result = true;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06001432 RID: 5170 RVA: 0x00074748 File Offset: 0x00072948
	public bool RemoveDuplicateQuickItemClass(UberStrikeItemQuickView view, ref global::LoadoutSlotType lastRemovedSlot)
	{
		bool result = false;
		if (view.ItemType == UberstrikeItemType.QuickUse)
		{
			global::LoadoutSlotType[] array = new global::LoadoutSlotType[]
			{
				global::LoadoutSlotType.QuickUseItem1,
				global::LoadoutSlotType.QuickUseItem2,
				global::LoadoutSlotType.QuickUseItem3
			};
			foreach (global::LoadoutSlotType loadoutSlotType in array)
			{
				InventoryItem inventoryItem;
				if (this.TryGetItemInSlot(loadoutSlotType, out inventoryItem))
				{
					UberStrikeItemQuickView uberStrikeItemQuickView = inventoryItem.Item as UberStrikeItemQuickView;
					if (inventoryItem.Item.View.ItemType == UberstrikeItemType.QuickUse && uberStrikeItemQuickView.BehaviourType == view.BehaviourType)
					{
						this.ResetSlot(loadoutSlotType);
						result = true;
						lastRemovedSlot = loadoutSlotType;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06001433 RID: 5171 RVA: 0x000747EC File Offset: 0x000729EC
	public bool RemoveDuplicateFunctionalItemClass(InventoryItem inventoryItem, ref global::LoadoutSlotType lastRemovedSlot)
	{
		bool result = false;
		if (inventoryItem != null && inventoryItem.Item.View.ItemType == UberstrikeItemType.Functional)
		{
			global::LoadoutSlotType[] array = new global::LoadoutSlotType[]
			{
				global::LoadoutSlotType.FunctionalItem1,
				global::LoadoutSlotType.FunctionalItem2,
				global::LoadoutSlotType.FunctionalItem3
			};
			foreach (global::LoadoutSlotType loadoutSlotType in array)
			{
				if (this.HasLoadoutItem(loadoutSlotType) && this.GetItemOnSlot(loadoutSlotType).View.ItemClass == inventoryItem.Item.View.ItemClass)
				{
					this.ResetSlot(loadoutSlotType);
					result = true;
					lastRemovedSlot = loadoutSlotType;
				}
			}
		}
		return result;
	}

	// Token: 0x06001434 RID: 5172 RVA: 0x0007488C File Offset: 0x00072A8C
	public void SwitchItemInSlot(global::LoadoutSlotType slot1, global::LoadoutSlotType slot2)
	{
		IUnityItem item;
		bool flag = this.Loadout.TryGetItem(slot1, out item);
		IUnityItem item2;
		bool flag2 = this.Loadout.TryGetItem(slot2, out item2);
		if (flag)
		{
			if (flag2)
			{
				this.Loadout.SetSlot(slot1, item2);
				this.Loadout.SetSlot(slot2, item);
			}
			else
			{
				this.Loadout.SetSlot(slot2, item);
				this.Loadout.ClearSlot(slot1);
			}
		}
		else if (flag2)
		{
			this.Loadout.SetSlot(slot1, item2);
			this.Loadout.ClearSlot(slot2);
		}
	}

	// Token: 0x06001435 RID: 5173 RVA: 0x0000D9CB File Offset: 0x0000BBCB
	public bool IsWeaponSlotType(global::LoadoutSlotType slot)
	{
		return slot >= global::LoadoutSlotType.WeaponMelee && slot <= global::LoadoutSlotType.WeaponTertiary;
	}

	// Token: 0x06001436 RID: 5174 RVA: 0x0000D9DF File Offset: 0x0000BBDF
	public bool IsQuickItemSlotType(global::LoadoutSlotType slot)
	{
		return slot >= global::LoadoutSlotType.QuickUseItem1 && slot <= global::LoadoutSlotType.QuickUseItem3;
	}

	// Token: 0x06001437 RID: 5175 RVA: 0x0000D9F4 File Offset: 0x0000BBF4
	public bool IsFunctionalItemSlotType(global::LoadoutSlotType slot)
	{
		return slot >= global::LoadoutSlotType.FunctionalItem1 && slot <= global::LoadoutSlotType.FunctionalItem3;
	}

	// Token: 0x06001438 RID: 5176 RVA: 0x00074920 File Offset: 0x00072B20
	public bool SwapLoadoutItems(global::LoadoutSlotType slotA, global::LoadoutSlotType slotB)
	{
		bool result = false;
		if (slotA != slotB)
		{
			if (this.IsWeaponSlotType(slotA) && this.IsWeaponSlotType(slotB))
			{
				InventoryItem inventoryItem = null;
				InventoryItem inventoryItem2 = null;
				this.TryGetItemInSlot(slotA, out inventoryItem);
				this.TryGetItemInSlot(slotB, out inventoryItem2);
				if (inventoryItem != null || inventoryItem2 != null)
				{
					IUnityItem item2;
					if (inventoryItem2 != null)
					{
						IUnityItem item = inventoryItem2.Item;
						item2 = item;
					}
					else
					{
						item2 = null;
					}
					this.SetLoadoutItem(slotA, item2);
					IUnityItem item3;
					if (inventoryItem != null)
					{
						IUnityItem item = inventoryItem.Item;
						item3 = item;
					}
					else
					{
						item3 = null;
					}
					this.SetLoadoutItem(slotB, item3);
					IUnityItem itemWeapon;
					if (inventoryItem2 != null)
					{
						IUnityItem item = inventoryItem2.Item;
						itemWeapon = item;
					}
					else
					{
						itemWeapon = null;
					}
					this.EquipWeapon(slotA, itemWeapon);
					IUnityItem itemWeapon2;
					if (inventoryItem != null)
					{
						IUnityItem item = inventoryItem.Item;
						itemWeapon2 = item;
					}
					else
					{
						itemWeapon2 = null;
					}
					this.EquipWeapon(slotB, itemWeapon2);
					result = true;
				}
			}
			else if ((this.IsQuickItemSlotType(slotA) && this.IsQuickItemSlotType(slotB)) || (this.IsFunctionalItemSlotType(slotA) && this.IsFunctionalItemSlotType(slotB)))
			{
				InventoryItem inventoryItem3 = null;
				InventoryItem inventoryItem4 = null;
				this.TryGetItemInSlot(slotA, out inventoryItem3);
				this.TryGetItemInSlot(slotB, out inventoryItem4);
				if (inventoryItem3 != null || inventoryItem4 != null)
				{
					IUnityItem item4;
					if (inventoryItem4 != null)
					{
						IUnityItem item = inventoryItem4.Item;
						item4 = item;
					}
					else
					{
						item4 = null;
					}
					this.SetLoadoutItem(slotA, item4);
					IUnityItem item5;
					if (inventoryItem3 != null)
					{
						IUnityItem item = inventoryItem3.Item;
						item5 = item;
					}
					else
					{
						item5 = null;
					}
					this.SetLoadoutItem(slotB, item5);
					result = true;
				}
			}
		}
		return result;
	}

	// Token: 0x06001439 RID: 5177 RVA: 0x00074A84 File Offset: 0x00072C84
	public void SetLoadoutItem(global::LoadoutSlotType loadoutSlotType, IUnityItem item)
	{
		if (item == null)
		{
			this.ResetSlot(loadoutSlotType);
		}
		else
		{
			InventoryItem inventoryItem;
			if (Singleton<InventoryManager>.Instance.TryGetInventoryItem(item.View.ID, out inventoryItem) && inventoryItem.IsValid)
			{
				if (item.View.ItemType == UberstrikeItemType.Weapon)
				{
					this.RemoveDuplicateWeaponClass(inventoryItem);
				}
				this.Loadout.SetSlot(loadoutSlotType, item);
			}
			else if (item.View != null)
			{
				BuyPanelGUI buyPanelGUI = PanelManager.Instance.OpenPanel(PanelType.BuyItem) as BuyPanelGUI;
				if (buyPanelGUI)
				{
					buyPanelGUI.SetItem(item, BuyingLocationType.Shop, BuyingRecommendationType.None, false);
				}
			}
			UnityRuntime.StartRoutine(Singleton<PlayerDataManager>.Instance.StartSetLoadout());
			this.UpdateArmor();
		}
	}

	// Token: 0x0600143A RID: 5178 RVA: 0x0000DA09 File Offset: 0x0000BC09
	public void ResetSlot(global::LoadoutSlotType loadoutSlotType)
	{
		this.Loadout.ClearSlot(loadoutSlotType);
		UnityRuntime.StartRoutine(Singleton<PlayerDataManager>.Instance.StartSetLoadout());
		this.UpdateArmor();
	}

	// Token: 0x0600143B RID: 5179 RVA: 0x00074B40 File Offset: 0x00072D40
	public void GetArmorValues(out int armorPoints)
	{
		armorPoints = 0;
		InventoryItem inventoryItem;
		if (this.TryGetItemInSlot(global::LoadoutSlotType.GearLowerBody, out inventoryItem) && inventoryItem.Item.View.ItemType == UberstrikeItemType.Gear)
		{
			UberStrikeItemGearView uberStrikeItemGearView = inventoryItem.Item.View as UberStrikeItemGearView;
			armorPoints += uberStrikeItemGearView.ArmorPoints;
		}
		if (this.TryGetItemInSlot(global::LoadoutSlotType.GearUpperBody, out inventoryItem) && inventoryItem.Item.View.ItemType == UberstrikeItemType.Gear)
		{
			UberStrikeItemGearView uberStrikeItemGearView2 = inventoryItem.Item.View as UberStrikeItemGearView;
			armorPoints += uberStrikeItemGearView2.ArmorPoints;
		}
		if (this.TryGetItemInSlot(global::LoadoutSlotType.GearHolo, out inventoryItem) && inventoryItem.Item.View.ItemType == UberstrikeItemType.Gear)
		{
			UberStrikeItemGearView uberStrikeItemGearView3 = inventoryItem.Item.View as UberStrikeItemGearView;
			armorPoints += uberStrikeItemGearView3.ArmorPoints;
		}
	}

	// Token: 0x0600143C RID: 5180 RVA: 0x00074C10 File Offset: 0x00072E10
	public bool HasLoadoutItem(global::LoadoutSlotType loadoutSlotType)
	{
		IUnityItem unityItem;
		return this.Loadout.TryGetItem(loadoutSlotType, out unityItem);
	}

	// Token: 0x0600143D RID: 5181 RVA: 0x00074C2C File Offset: 0x00072E2C
	public int GetItemIdOnSlot(global::LoadoutSlotType loadoutSlotType)
	{
		int result = 0;
		IUnityItem unityItem;
		if (this.Loadout.TryGetItem(loadoutSlotType, out unityItem))
		{
			result = unityItem.View.ID;
		}
		return result;
	}

	// Token: 0x0600143E RID: 5182 RVA: 0x00074C5C File Offset: 0x00072E5C
	public IUnityItem GetItemOnSlot(global::LoadoutSlotType loadoutSlotType)
	{
		IUnityItem result = null;
		this.Loadout.TryGetItem(loadoutSlotType, out result);
		return result;
	}

	// Token: 0x0600143F RID: 5183 RVA: 0x0000DA2D File Offset: 0x0000BC2D
	public bool IsItemEquipped(int itemId)
	{
		return this.Loadout.Contains(itemId);
	}

	// Token: 0x06001440 RID: 5184 RVA: 0x00074C7C File Offset: 0x00072E7C
	public bool HasItemInSlot(global::LoadoutSlotType slot)
	{
		InventoryItem inventoryItem;
		return this.TryGetItemInSlot(slot, out inventoryItem);
	}

	// Token: 0x06001441 RID: 5185 RVA: 0x00074C94 File Offset: 0x00072E94
	public bool TryGetItemInSlot(global::LoadoutSlotType slot, out InventoryItem item)
	{
		item = null;
		IUnityItem unityItem;
		return this.Loadout.TryGetItem(slot, out unityItem) && Singleton<InventoryManager>.Instance.TryGetInventoryItem(unityItem.View.ID, out item);
	}

	// Token: 0x06001442 RID: 5186 RVA: 0x00074CD0 File Offset: 0x00072ED0
	public bool TryGetSlotForItem(IUnityItem item, out global::LoadoutSlotType slot)
	{
		slot = global::LoadoutSlotType.None;
		foreach (KeyValuePair<global::LoadoutSlotType, IUnityItem> keyValuePair in this.Loadout)
		{
			if (keyValuePair.Value == item)
			{
				Dictionary<global::LoadoutSlotType, IUnityItem>.Enumerator enumerator = new Dictionary<global::LoadoutSlotType, IUnityItem>.Enumerator();
				KeyValuePair<global::LoadoutSlotType, IUnityItem> keyValuePair2 = enumerator.Current;
				slot = keyValuePair2.Key;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001443 RID: 5187 RVA: 0x0000DA3B File Offset: 0x0000BC3B
	public bool ValidateLoadout()
	{
		return this.Loadout.ItemCount > 0;
	}

	// Token: 0x06001444 RID: 5188 RVA: 0x00074D28 File Offset: 0x00072F28
	public void UpdateArmor()
	{
		int value;
		this.GetArmorValues(out value);
		GameState.Current.PlayerData.ArmorCarried.Value = value;
	}

	// Token: 0x06001445 RID: 5189 RVA: 0x00074D54 File Offset: 0x00072F54
	public List<int> GetWeapons()
	{
		return new List<int>
		{
			this.GetItemIdOnSlot(global::LoadoutSlotType.WeaponMelee),
			this.GetItemIdOnSlot(global::LoadoutSlotType.WeaponPrimary),
			this.GetItemIdOnSlot(global::LoadoutSlotType.WeaponSecondary),
			this.GetItemIdOnSlot(global::LoadoutSlotType.WeaponTertiary)
		};
	}

	// Token: 0x06001446 RID: 5190 RVA: 0x00074DA0 File Offset: 0x00072FA0
	public List<int> GetGear()
	{
		return new List<int>
		{
			this.GetItemIdOnSlot(global::LoadoutSlotType.GearHead),
			this.GetItemIdOnSlot(global::LoadoutSlotType.GearFace),
			this.GetItemIdOnSlot(global::LoadoutSlotType.GearGloves),
			this.GetItemIdOnSlot(global::LoadoutSlotType.GearUpperBody),
			this.GetItemIdOnSlot(global::LoadoutSlotType.GearLowerBody),
			this.GetItemIdOnSlot(global::LoadoutSlotType.GearBoots),
			this.GetItemIdOnSlot(global::LoadoutSlotType.GearHolo)
		};
	}

	// Token: 0x06001447 RID: 5191 RVA: 0x00074E10 File Offset: 0x00073010
	public List<int> GetQuickItems()
	{
		return new List<int>
		{
			this.GetItemIdOnSlot(global::LoadoutSlotType.QuickUseItem1),
			this.GetItemIdOnSlot(global::LoadoutSlotType.QuickUseItem2),
			this.GetItemIdOnSlot(global::LoadoutSlotType.QuickUseItem3)
		};
	}

	// Token: 0x04001384 RID: 4996
	public static readonly global::LoadoutSlotType[] QuickSlots = new global::LoadoutSlotType[]
	{
		global::LoadoutSlotType.QuickUseItem1,
		global::LoadoutSlotType.QuickUseItem2,
		global::LoadoutSlotType.QuickUseItem3
	};

	// Token: 0x04001385 RID: 4997
	public static readonly global::LoadoutSlotType[] WeaponSlots = new global::LoadoutSlotType[]
	{
		global::LoadoutSlotType.WeaponMelee,
		global::LoadoutSlotType.WeaponPrimary,
		global::LoadoutSlotType.WeaponSecondary,
		global::LoadoutSlotType.WeaponTertiary
	};

	// Token: 0x04001386 RID: 4998
	public static readonly global::LoadoutSlotType[] GearSlots = new global::LoadoutSlotType[]
	{
		global::LoadoutSlotType.GearHead,
		global::LoadoutSlotType.GearFace,
		global::LoadoutSlotType.GearGloves,
		global::LoadoutSlotType.GearUpperBody,
		global::LoadoutSlotType.GearLowerBody,
		global::LoadoutSlotType.GearBoots
	};

	// Token: 0x04001387 RID: 4999
	public static readonly UberstrikeItemClass[] GearSlotClasses = new UberstrikeItemClass[]
	{
		UberstrikeItemClass.GearHead,
		UberstrikeItemClass.GearFace,
		UberstrikeItemClass.GearGloves,
		UberstrikeItemClass.GearUpperBody,
		UberstrikeItemClass.GearLowerBody,
		UberstrikeItemClass.GearBoots
	};

	// Token: 0x04001388 RID: 5000
	public static readonly string[] GearSlotNames = new string[]
	{
		LocalizedStrings.Head,
		LocalizedStrings.Face,
		LocalizedStrings.Gloves,
		LocalizedStrings.UpperBody,
		LocalizedStrings.LowerBody,
		LocalizedStrings.Boots
	};
}
