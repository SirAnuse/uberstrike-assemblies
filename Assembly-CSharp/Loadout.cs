using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000369 RID: 873
public class Loadout
{
	// Token: 0x06001875 RID: 6261 RVA: 0x000105CD File Offset: 0x0000E7CD
	public Loadout(Loadout gearLoadout) : this(gearLoadout._items)
	{
	}

	// Token: 0x06001876 RID: 6262 RVA: 0x0008357C File Offset: 0x0008177C
	public Loadout(Dictionary<global::LoadoutSlotType, IUnityItem> items)
	{
		this._items = new Dictionary<global::LoadoutSlotType, IUnityItem>();
		this.OnGearChanged = delegate()
		{
		};
		this.OnWeaponChanged = delegate(global::LoadoutSlotType A_0)
		{
		};
		foreach (KeyValuePair<global::LoadoutSlotType, IUnityItem> keyValuePair in items)
		{
			this.SetSlot(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x06001877 RID: 6263 RVA: 0x00083638 File Offset: 0x00081838
	public Loadout(List<int> gearItemIds, List<int> weaponItemIds)
	{
		this._items = new Dictionary<global::LoadoutSlotType, IUnityItem>();
		this.OnGearChanged = delegate()
		{
		};
		this.OnWeaponChanged = delegate(global::LoadoutSlotType A_0)
		{
		};
		if (gearItemIds.Count < 7 || weaponItemIds.Count < 4)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Invalid parameters: gear count = ",
				gearItemIds.Count,
				" weapon count = ",
				weaponItemIds.Count
			}));
		}
		this.SetSlot(global::LoadoutSlotType.GearHead, gearItemIds[1]);
		this.SetSlot(global::LoadoutSlotType.GearFace, gearItemIds[2]);
		this.SetSlot(global::LoadoutSlotType.GearGloves, gearItemIds[3]);
		this.SetSlot(global::LoadoutSlotType.GearUpperBody, gearItemIds[4]);
		this.SetSlot(global::LoadoutSlotType.GearLowerBody, gearItemIds[5]);
		this.SetSlot(global::LoadoutSlotType.GearBoots, gearItemIds[6]);
		if (gearItemIds[0] > 0)
		{
			this.SetSlot(global::LoadoutSlotType.GearHolo, gearItemIds[0]);
		}
		this.SetSlot(global::LoadoutSlotType.WeaponMelee, weaponItemIds[0]);
		this.SetSlot(global::LoadoutSlotType.WeaponPrimary, weaponItemIds[1]);
		this.SetSlot(global::LoadoutSlotType.WeaponSecondary, weaponItemIds[2]);
		this.SetSlot(global::LoadoutSlotType.WeaponTertiary, weaponItemIds[3]);
	}

	// Token: 0x1400000F RID: 15
	// (add) Token: 0x06001878 RID: 6264 RVA: 0x000105DB File Offset: 0x0000E7DB
	// (remove) Token: 0x06001879 RID: 6265 RVA: 0x000105F4 File Offset: 0x0000E7F4
	public event Action OnGearChanged;

	// Token: 0x14000010 RID: 16
	// (add) Token: 0x0600187A RID: 6266 RVA: 0x0001060D File Offset: 0x0000E80D
	// (remove) Token: 0x0600187B RID: 6267 RVA: 0x00010626 File Offset: 0x0000E826
	public event Action<global::LoadoutSlotType> OnWeaponChanged;

	// Token: 0x170005A3 RID: 1443
	// (get) Token: 0x0600187C RID: 6268 RVA: 0x0001063F File Offset: 0x0000E83F
	public int ItemCount
	{
		get
		{
			return this._items.Count;
		}
	}

	// Token: 0x170005A4 RID: 1444
	// (get) Token: 0x0600187D RID: 6269 RVA: 0x0001064C File Offset: 0x0000E84C
	public static Loadout Empty
	{
		get
		{
			return new Loadout(new Dictionary<global::LoadoutSlotType, IUnityItem>());
		}
	}

	// Token: 0x0600187E RID: 6270 RVA: 0x00010658 File Offset: 0x0000E858
	public bool TryGetItem(global::LoadoutSlotType slot, out IUnityItem item)
	{
		return this._items.TryGetValue(slot, out item);
	}

	// Token: 0x0600187F RID: 6271 RVA: 0x00010667 File Offset: 0x0000E867
	public void SetSlot(global::LoadoutSlotType slot, int itemId)
	{
		this.SetSlot(slot, Singleton<ItemManager>.Instance.GetItemInShop(itemId));
	}

	// Token: 0x06001880 RID: 6272 RVA: 0x0008379C File Offset: 0x0008199C
	public void SetSlot(global::LoadoutSlotType slot, IUnityItem item)
	{
		if (item != null && this.CanGoInSlot(slot, item.View.ItemType))
		{
			this._items[slot] = item;
            switch (slot)
            {
                case global::LoadoutSlotType.GearHead:
                case global::LoadoutSlotType.GearFace:
                case global::LoadoutSlotType.GearGloves:
                case global::LoadoutSlotType.GearUpperBody:
                case global::LoadoutSlotType.GearLowerBody:
                case global::LoadoutSlotType.GearBoots:
                case global::LoadoutSlotType.GearHolo:
                    this.OnGearChanged();
                    break;
                case global::LoadoutSlotType.WeaponMelee:
                case global::LoadoutSlotType.WeaponPrimary:
                case global::LoadoutSlotType.WeaponSecondary:
                case global::LoadoutSlotType.WeaponTertiary:
                    this.OnWeaponChanged(slot);
                    break;
            }
		}
	}

	// Token: 0x06001881 RID: 6273 RVA: 0x00083830 File Offset: 0x00081A30
	public bool CanGoInSlot(global::LoadoutSlotType slot, UberstrikeItemType type)
	{
		switch (type)
		{
		case UberstrikeItemType.Weapon:
			return slot >= global::LoadoutSlotType.WeaponMelee && slot <= global::LoadoutSlotType.WeaponTertiary;
		case UberstrikeItemType.Gear:
			return slot >= global::LoadoutSlotType.GearHead && slot <= global::LoadoutSlotType.GearHolo;
		case UberstrikeItemType.QuickUse:
			return slot >= global::LoadoutSlotType.QuickUseItem1 && slot <= global::LoadoutSlotType.QuickUseItem3;
		case UberstrikeItemType.Functional:
			return slot >= global::LoadoutSlotType.FunctionalItem1 && slot <= global::LoadoutSlotType.FunctionalItem3;
		}
		Debug.LogError("Item attempted to be equipped into a slot that isn't supported.");
		return false;
	}

	// Token: 0x06001882 RID: 6274 RVA: 0x000838B8 File Offset: 0x00081AB8
	public void ClearSlot(global::LoadoutSlotType slot)
	{
		IUnityItem unityItem;
		if (this._items.TryGetValue(slot, out unityItem))
		{
			this._items.Remove(slot);
			this.OnGearChanged();
		}
	}

	// Token: 0x06001883 RID: 6275 RVA: 0x00003C87 File Offset: 0x00001E87
	public void ClearAllSlots()
	{
	}

	// Token: 0x06001884 RID: 6276 RVA: 0x000838F0 File Offset: 0x00081AF0
	public bool Compare(Loadout a)
	{
		bool flag = this.ItemCount == a.ItemCount;
		if (flag)
		{
			foreach (KeyValuePair<global::LoadoutSlotType, IUnityItem> keyValuePair in this._items)
			{
				IUnityItem unityItem;
				if (!a.TryGetItem(keyValuePair.Key, out unityItem))
				{
					return false;
				}
				if (unityItem != keyValuePair.Value)
				{
					return false;
				}
			}
			return flag;
		}
		return flag;
	}

	// Token: 0x06001885 RID: 6277 RVA: 0x00083994 File Offset: 0x00081B94
	public global::LoadoutSlotType GetItemClassSlotType(UberstrikeItemClass itemClass)
	{
		foreach (KeyValuePair<global::LoadoutSlotType, IUnityItem> keyValuePair in this._items)
		{
			if (keyValuePair.Value.View.ItemClass == itemClass)
			{
				return keyValuePair.Key;
			}
		}
		return global::LoadoutSlotType.None;
	}

	// Token: 0x06001886 RID: 6278 RVA: 0x00083A10 File Offset: 0x00081C10
	public global::LoadoutSlotType GetFirstEmptyWeaponSlot()
	{
		if (!this._items.ContainsKey(global::LoadoutSlotType.WeaponPrimary))
		{
			return global::LoadoutSlotType.WeaponPrimary;
		}
		if (!this._items.ContainsKey(global::LoadoutSlotType.WeaponSecondary))
		{
			return global::LoadoutSlotType.WeaponSecondary;
		}
		if (!this._items.ContainsKey(global::LoadoutSlotType.WeaponTertiary))
		{
			return global::LoadoutSlotType.WeaponTertiary;
		}
		return global::LoadoutSlotType.None;
	}

	// Token: 0x06001887 RID: 6279 RVA: 0x00083A5C File Offset: 0x00081C5C
	public bool Contains(string prefabName)
	{
		bool result = false;
		foreach (IUnityItem unityItem in this._items.Values)
		{
			if (unityItem.View.PrefabName.Equals(prefabName))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06001888 RID: 6280 RVA: 0x00083AD4 File Offset: 0x00081CD4
	public bool Contains(int itemId)
	{
		bool result = false;
		foreach (IUnityItem unityItem in this._items.Values)
		{
			if (unityItem.View.ID == itemId)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06001889 RID: 6281 RVA: 0x00083B48 File Offset: 0x00081D48
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<global::LoadoutSlotType, IUnityItem> keyValuePair in this._items)
		{
			stringBuilder.AppendLine(string.Format("{0}: {1}", keyValuePair.Key, keyValuePair.Value.Name));
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600188A RID: 6282 RVA: 0x0001067B File Offset: 0x0000E87B
	public Dictionary<global::LoadoutSlotType, IUnityItem>.Enumerator GetEnumerator()
	{
		return this._items.GetEnumerator();
	}

	// Token: 0x0600188B RID: 6283 RVA: 0x00083BD0 File Offset: 0x00081DD0
	private void OnItemPrefabUpdated(IUnityItem item)
	{
		KeyValuePair<global::LoadoutSlotType, IUnityItem> keyValuePair = this._items.FirstOrDefault((KeyValuePair<global::LoadoutSlotType, IUnityItem> a) => a.Value.View.ID == item.View.ID);
		if (keyValuePair.Value != null)
		{
			global::LoadoutSlotType key = keyValuePair.Key;
			IUnityItem unityItem;
			if (this._items.TryGetValue(key, out unityItem) && unityItem == item)
			{
				switch (item.View.ItemType)
				{
				case UberstrikeItemType.Weapon:
					this.OnWeaponChanged(key);
					break;
				case UberstrikeItemType.Gear:
					this.CheckAllGear();
					break;
				}
			}
		}
		else
		{
			Debug.LogError("OnItemPrefabUpdated failed because slot not found");
		}
	}

	// Token: 0x0600188C RID: 6284 RVA: 0x00083C98 File Offset: 0x00081E98
	private void CheckAllGear()
	{
		IUnityItem unityItem;
		bool flag;
		if (this._items.TryGetValue(global::LoadoutSlotType.GearHolo, out unityItem))
		{
			flag = unityItem.IsLoaded;
		}
		else
		{
			bool flag2 = true;
			foreach (global::LoadoutSlotType key in LoadoutManager.GearSlots)
			{
				if (this._items.TryGetValue(key, out unityItem))
				{
					flag2 &= unityItem.IsLoaded;
				}
			}
			flag = flag2;
		}
		if (flag)
		{
			this.OnGearChanged();
		}
	}

	// Token: 0x0600188D RID: 6285 RVA: 0x00083D20 File Offset: 0x00081F20
	public AvatarGearParts GetAvatarGear()
	{
		bool flag = false;
		AvatarGearParts avatarGearParts = new AvatarGearParts();
		IUnityItem unityItem;
		if (this._items.TryGetValue(global::LoadoutSlotType.GearHolo, out unityItem))
		{
			avatarGearParts.Base = unityItem.Create(Vector3.zero, Quaternion.identity);
		}
		if (!avatarGearParts.Base)
		{
			flag = true;
			avatarGearParts.Base = (UnityEngine.Object.Instantiate(PrefabManager.Instance.DefaultAvatar.gameObject) as GameObject);
		}
		if (flag)
		{
			foreach (global::LoadoutSlotType loadoutSlotType in LoadoutManager.GearSlots)
			{
				if (this._items.TryGetValue(loadoutSlotType, out unityItem))
				{
					GameObject gameObject = unityItem.Create(Vector3.zero, Quaternion.identity);
					if (gameObject)
					{
						avatarGearParts.Parts.Add(gameObject);
					}
				}
				else
				{
					GameObject defaultGearItem = Singleton<ItemManager>.Instance.GetDefaultGearItem(ItemUtil.ItemClassFromSlot(loadoutSlotType));
					if (defaultGearItem)
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate(defaultGearItem) as GameObject;
						if (gameObject2)
						{
							avatarGearParts.Parts.Add(gameObject2);
						}
					}
				}
			}
		}
		return avatarGearParts;
	}

	// Token: 0x0600188E RID: 6286 RVA: 0x00083E44 File Offset: 0x00082044
	public AvatarGearParts GetRagdollGear()
	{
		AvatarGearParts avatarGearParts = new AvatarGearParts();
		try
		{
			IUnityItem unityItem;
			bool flag;
			if (this._items.TryGetValue(global::LoadoutSlotType.GearHolo, out unityItem))
			{
				flag = !unityItem.IsLoaded;
				if (unityItem.Prefab)
				{
					HoloGearItem component = unityItem.Prefab.GetComponent<HoloGearItem>();
					if (component && component.Configuration.Ragdoll)
					{
						avatarGearParts.Base = (UnityEngine.Object.Instantiate(component.Configuration.Ragdoll.gameObject) as GameObject);
					}
					else
					{
						avatarGearParts.Base = (UnityEngine.Object.Instantiate(PrefabManager.Instance.DefaultRagdoll.gameObject) as GameObject);
					}
				}
				else
				{
					avatarGearParts.Base = (UnityEngine.Object.Instantiate(PrefabManager.Instance.DefaultRagdoll.gameObject) as GameObject);
				}
			}
			else
			{
				flag = true;
				avatarGearParts.Base = (UnityEngine.Object.Instantiate(PrefabManager.Instance.DefaultRagdoll.gameObject) as GameObject);
			}
			if (flag)
			{
				foreach (global::LoadoutSlotType loadoutSlotType in LoadoutManager.GearSlots)
				{
					if (this._items.TryGetValue(loadoutSlotType, out unityItem))
					{
						GameObject gameObject = unityItem.Create(Vector3.zero, Quaternion.identity);
						if (gameObject)
						{
							avatarGearParts.Parts.Add(gameObject);
						}
					}
					else if (Singleton<ItemManager>.Instance.TryGetDefaultItem(ItemUtil.ItemClassFromSlot(loadoutSlotType), out unityItem))
					{
						GameObject gameObject2 = unityItem.Create(Vector3.zero, Quaternion.identity);
						if (gameObject2)
						{
							avatarGearParts.Parts.Add(gameObject2);
						}
					}
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return avatarGearParts;
	}

	// Token: 0x0600188F RID: 6287 RVA: 0x00010688 File Offset: 0x0000E888
	internal void UpdateWeaponSlots(List<int> weaponItemIds)
	{
		this.SetSlot(global::LoadoutSlotType.WeaponMelee, weaponItemIds[0]);
		this.SetSlot(global::LoadoutSlotType.WeaponPrimary, weaponItemIds[1]);
		this.SetSlot(global::LoadoutSlotType.WeaponSecondary, weaponItemIds[2]);
		this.SetSlot(global::LoadoutSlotType.WeaponTertiary, weaponItemIds[3]);
	}

	// Token: 0x06001890 RID: 6288 RVA: 0x00084024 File Offset: 0x00082224
	internal void UpdateGearSlots(List<int> gearItemIds)
	{
		this.SetSlot(global::LoadoutSlotType.GearHead, gearItemIds[1]);
		this.SetSlot(global::LoadoutSlotType.GearFace, gearItemIds[2]);
		this.SetSlot(global::LoadoutSlotType.GearGloves, gearItemIds[3]);
		this.SetSlot(global::LoadoutSlotType.GearUpperBody, gearItemIds[4]);
		this.SetSlot(global::LoadoutSlotType.GearLowerBody, gearItemIds[5]);
		this.SetSlot(global::LoadoutSlotType.GearBoots, gearItemIds[6]);
		if (gearItemIds[0] > 0)
		{
			this.SetSlot(global::LoadoutSlotType.GearHolo, gearItemIds[0]);
		}
	}

	// Token: 0x04001709 RID: 5897
	private Dictionary<global::LoadoutSlotType, IUnityItem> _items;
}
