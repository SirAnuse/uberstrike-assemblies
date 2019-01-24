using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020002C7 RID: 711
public class ItemManager : Singleton<ItemManager>
{
	// Token: 0x060013FF RID: 5119 RVA: 0x000739C0 File Offset: 0x00071BC0
	private ItemManager()
	{
		this._shopItemsById = new Dictionary<int, IUnityItem>();
		this._defaultGearPrefabNames = new Dictionary<UberstrikeItemClass, string>
		{
			{
				UberstrikeItemClass.GearHead,
				"LutzDefaultGearHead"
			},
			{
				UberstrikeItemClass.GearGloves,
				"LutzDefaultGearGloves"
			},
			{
				UberstrikeItemClass.GearUpperBody,
				"LutzDefaultGearUpperBody"
			},
			{
				UberstrikeItemClass.GearLowerBody,
				"LutzDefaultGearLowerBody"
			},
			{
				UberstrikeItemClass.GearBoots,
				"LutzDefaultGearBoots"
			}
		};
		this._defaultWeaponPrefabNames = new Dictionary<UberstrikeItemClass, string>
		{
			{
				UberstrikeItemClass.WeaponMelee,
				"TheSplatbat"
			},
			{
				UberstrikeItemClass.WeaponMachinegun,
				"MachineGun"
			},
			{
				UberstrikeItemClass.WeaponSplattergun,
				"SplatterGun"
			},
			{
				UberstrikeItemClass.WeaponCannon,
				"Cannon"
			},
			{
				UberstrikeItemClass.WeaponSniperRifle,
				"SniperRifle"
			},
			{
				UberstrikeItemClass.WeaponLauncher,
				"Launcher"
			},
			{
				UberstrikeItemClass.WeaponShotgun,
				"ShotGun"
			}
		};
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06001400 RID: 5120 RVA: 0x0000D8A7 File Offset: 0x0000BAA7
	public IEnumerable<IUnityItem> ShopItems
	{
		get
		{
			return this._shopItemsById.Values;
		}
	}

	// Token: 0x170004CA RID: 1226
	// (get) Token: 0x06001401 RID: 5121 RVA: 0x0000D8B4 File Offset: 0x0000BAB4
	public int ShopItemCount
	{
		get
		{
			return this._shopItemsById.Count;
		}
	}

	// Token: 0x06001402 RID: 5122 RVA: 0x00073A90 File Offset: 0x00071C90
	private void UpdateShopItems(UberStrikeItemShopClientView shopView)
	{
		List<BaseUberStrikeItemView> list = new List<BaseUberStrikeItemView>(shopView.GearItems.ToArray());
		list.AddRange(shopView.WeaponItems.ToArray());
		list.AddRange(shopView.QuickItems.ToArray());
		foreach (BaseUberStrikeItemView baseUberStrikeItemView in list)
		{
			if (!string.IsNullOrEmpty(baseUberStrikeItemView.PrefabName))
			{
				this._shopItemsById[baseUberStrikeItemView.ID] = new ProxyItem(baseUberStrikeItemView);
			}
			else
			{
				Debug.LogWarning(string.Concat(new object[]
				{
					"PrefabName is empty: ",
					baseUberStrikeItemView.Name,
					" ",
					baseUberStrikeItemView.ID
				}));
			}
		}
		foreach (UberStrikeItemFunctionalView uberStrikeItemFunctionalView in shopView.FunctionalItems)
		{
			this._shopItemsById[uberStrikeItemFunctionalView.ID] = new FunctionalItem(uberStrikeItemFunctionalView);
		}
	}

	// Token: 0x06001403 RID: 5123 RVA: 0x00073BD0 File Offset: 0x00071DD0
	public bool AddDefaultItem(BaseUberStrikeItemView itemView)
	{
		if (itemView != null)
		{
			if (itemView.ItemClass == UberstrikeItemClass.FunctionalGeneral)
			{
				IUnityItem unityItem;
				if (this._shopItemsById.TryGetValue(itemView.ID, out unityItem))
				{
					ItemConfigurationUtil.CopyProperties<BaseUberStrikeItemView>(unityItem.View, itemView);
				}
			}
			else if (string.IsNullOrEmpty(itemView.PrefabName))
			{
				Debug.LogWarning("Missing PrefabName for item: " + itemView.Name);
			}
			else
			{
				Debug.LogError(string.Concat(new string[]
				{
					"Missing UnityItem for: '",
					itemView.Name,
					"' with PrefabName: '",
					itemView.PrefabName,
					"'"
				}));
			}
		}
		return false;
	}

	// Token: 0x06001404 RID: 5124 RVA: 0x00073C80 File Offset: 0x00071E80
	public bool TryGetDefaultItem(UberstrikeItemClass itemClass, out IUnityItem item)
	{
		string prefabName;
		if (this._defaultGearPrefabNames.TryGetValue(itemClass, out prefabName) || this._defaultWeaponPrefabNames.TryGetValue(itemClass, out prefabName))
		{
			item = this._shopItemsById.Values.FirstOrDefault((IUnityItem i) => i.View.PrefabName == prefabName);
			return item != null;
		}
		item = null;
		return false;
	}

	// Token: 0x06001405 RID: 5125 RVA: 0x0000D8C1 File Offset: 0x0000BAC1
	public bool IsDefaultGearItem(string prefabName)
	{
		return this._defaultGearPrefabNames.ContainsValue(prefabName);
	}

	// Token: 0x06001406 RID: 5126 RVA: 0x00073CEC File Offset: 0x00071EEC
	public GameObject GetDefaultGearItem(UberstrikeItemClass itemClass)
	{
		string defaultGearPrefabName = string.Empty;
		switch (itemClass)
		{
		case UberstrikeItemClass.GearBoots:
			defaultGearPrefabName = "LutzDefaultGearBoots";
			break;
		case UberstrikeItemClass.GearHead:
			defaultGearPrefabName = "LutzDefaultGearHead";
			break;
		case UberstrikeItemClass.GearFace:
			defaultGearPrefabName = "LutzDefaultGearFace";
			break;
		case UberstrikeItemClass.GearUpperBody:
			defaultGearPrefabName = "LutzDefaultGearUpperBody";
			break;
		case UberstrikeItemClass.GearLowerBody:
			defaultGearPrefabName = "LutzDefaultGearLowerBody";
			break;
		case UberstrikeItemClass.GearGloves:
			defaultGearPrefabName = "LutzDefaultGearGloves";
			break;
		}
		GearItem gearItem = UnityItemConfiguration.Instance.UnityItemsDefaultGears.Find((GearItem item) => item.name.Equals(defaultGearPrefabName));
		return (!(gearItem != null)) ? null : gearItem.gameObject;
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x00073DC8 File Offset: 0x00071FC8
	public GameObject GetDefaultWeaponItem(UberstrikeItemClass itemClass)
	{
		string defaultWeaponPrefabName = string.Empty;
		switch (itemClass)
		{
		case UberstrikeItemClass.WeaponMelee:
			defaultWeaponPrefabName = "TheSplatbat";
			break;
		case UberstrikeItemClass.WeaponMachinegun:
			defaultWeaponPrefabName = "MachineGun";
			break;
		case UberstrikeItemClass.WeaponShotgun:
			defaultWeaponPrefabName = "ShotGun";
			break;
		case UberstrikeItemClass.WeaponSniperRifle:
			defaultWeaponPrefabName = "SniperRifle";
			break;
		case UberstrikeItemClass.WeaponCannon:
			defaultWeaponPrefabName = "Cannon";
			break;
		case UberstrikeItemClass.WeaponSplattergun:
			defaultWeaponPrefabName = "SplatterGun";
			break;
		case UberstrikeItemClass.WeaponLauncher:
			defaultWeaponPrefabName = "Launcher";
			break;
		}
		WeaponItem weaponItem = UnityItemConfiguration.Instance.UnityItemsDefaultWeapons.Find((WeaponItem item) => item.name.Equals(defaultWeaponPrefabName));
		return (!(weaponItem != null)) ? null : weaponItem.gameObject;
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x00073EBC File Offset: 0x000720BC
	public List<IUnityItem> GetShopItems(UberstrikeItemType itemType, BuyingMarketType marketType)
	{
		List<IUnityItem> allShopItems = this.GetAllShopItems();
		allShopItems.RemoveAll((IUnityItem item) => item.View.ItemType != itemType);
		return allShopItems;
	}

	// Token: 0x06001409 RID: 5129 RVA: 0x00073EF4 File Offset: 0x000720F4
	public List<IUnityItem> GetAllShopItems()
	{
		List<IUnityItem> list = new List<IUnityItem>(this._shopItemsById.Values);
		list.RemoveAll((IUnityItem item) => !item.View.IsForSale);
		return list;
	}

	// Token: 0x0600140A RID: 5130 RVA: 0x0000D8CF File Offset: 0x0000BACF
	public IUnityItem GetItemInShop(int itemId)
	{
		if (this._shopItemsById.ContainsKey(itemId))
		{
			return this._shopItemsById[itemId];
		}
		return null;
	}

	// Token: 0x0600140B RID: 5131 RVA: 0x0000D8F0 File Offset: 0x0000BAF0
	public bool ValidateItemMall()
	{
		return this._shopItemsById.Count > 0;
	}

	// Token: 0x0600140C RID: 5132 RVA: 0x00073F38 File Offset: 0x00072138
	public IEnumerator StartGetShop()
	{
		yield return ShopWebServiceClient.GetShop(delegate(UberStrikeItemShopClientView shop)
		{
			if (shop != null)
			{
				this.UpdateShopItems(shop);
				WeaponConfigurationHelper.UpdateWeaponStatistics(shop);
			}
			else
			{
				Debug.LogError("ShopWebServiceClient.GetShop returned with NULL");
			}
		}, delegate(Exception ex)
		{
            Debug.LogError(ex);
		});
		yield break;
	}

	// Token: 0x0600140D RID: 5133 RVA: 0x00073F54 File Offset: 0x00072154
	public IEnumerator StartGetInventory(bool showProgress)
	{
		if (this._shopItemsById.Count == 0)
		{
			PopupSystem.ShowMessage("Error Getting Shop Data", "The shop is empty, perhaps there\nwas an error getting the Shop data?", PopupSystem.AlertType.OK, null);
			yield break;
		}
		List<ItemInventoryView> inventoryView = new List<ItemInventoryView>();
		if (showProgress)
		{
			IPopupDialog popupDialog = PopupSystem.ShowMessage(LocalizedStrings.UpdatingInventory, LocalizedStrings.WereUpdatingYourInventoryPleaseWait, PopupSystem.AlertType.None);
			yield return UserWebServiceClient.GetInventory(PlayerDataManager.AuthToken, delegate(List<ItemInventoryView> view)
			{
				inventoryView = view;
			}, delegate(Exception ex)
			{
			});
			PopupSystem.HideMessage(popupDialog);
		}
		else
		{
			yield return UserWebServiceClient.GetInventory(PlayerDataManager.AuthToken, delegate(List<ItemInventoryView> view)
			{
				inventoryView = view;
			}, delegate(Exception ex)
			{
			});
		}
		List<string> prefabs = new List<string>();
		inventoryView.ForEach(delegate(ItemInventoryView view)
		{
			IUnityItem unityItem;
			if (this._shopItemsById.TryGetValue(view.ItemId, out unityItem) && unityItem.View.ItemType != UberstrikeItemType.Functional)
			{
				prefabs.Add(unityItem.View.PrefabName);
			}
			prefabs.Reverse();
		});
		Singleton<InventoryManager>.Instance.UpdateInventoryItems(inventoryView);
		yield break;
	}

	// Token: 0x0400136E RID: 4974
	private Dictionary<UberstrikeItemClass, string> _defaultGearPrefabNames;

	// Token: 0x0400136F RID: 4975
	private Dictionary<UberstrikeItemClass, string> _defaultWeaponPrefabNames;

	// Token: 0x04001370 RID: 4976
	private Dictionary<int, IUnityItem> _shopItemsById;
}
