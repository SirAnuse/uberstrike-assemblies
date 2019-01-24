using System;
using UberStrike.Core.Types;

// Token: 0x020002E3 RID: 739
public class TemporaryLoadoutManager : Singleton<TemporaryLoadoutManager>
{
	// Token: 0x06001532 RID: 5426 RVA: 0x0000E332 File Offset: 0x0000C532
	private TemporaryLoadoutManager()
	{
	}

	// Token: 0x06001533 RID: 5427 RVA: 0x00077AC4 File Offset: 0x00075CC4
	public void SetLoadoutItem(global::LoadoutSlotType slot, IUnityItem item)
	{
		if (item != null)
		{
			IUnityItem unityItem;
			if (GameState.Current.Avatar.Loadout.TryGetItem(slot, out unityItem) && unityItem != item && !Singleton<InventoryManager>.Instance.Contains(unityItem.View.ID) && unityItem.View.ItemType != UberstrikeItemType.QuickUse)
			{
				unityItem.Unload();
			}
			GameState.Current.Avatar.Loadout.SetSlot(slot, item);
		}
	}

	// Token: 0x17000516 RID: 1302
	// (get) Token: 0x06001534 RID: 5428 RVA: 0x0000E33A File Offset: 0x0000C53A
	public bool IsGearLoadoutModified
	{
		get
		{
			return !Singleton<LoadoutManager>.Instance.Loadout.Compare(GameState.Current.Avatar.Loadout);
		}
	}

	// Token: 0x06001535 RID: 5429 RVA: 0x00077B44 File Offset: 0x00075D44
	public bool IsGearLoadoutModifiedOnSlot(global::LoadoutSlotType slot)
	{
		IUnityItem unityItem;
		return GameState.Current.Avatar.Loadout.TryGetItem(slot, out unityItem) && unityItem != Singleton<LoadoutManager>.Instance.GetItemOnSlot(slot);
	}

	// Token: 0x06001536 RID: 5430 RVA: 0x0000E35D File Offset: 0x0000C55D
	public void ResetLoadout(global::LoadoutSlotType slot)
	{
		GameState.Current.Avatar.Loadout.ClearSlot(slot);
	}

	// Token: 0x06001537 RID: 5431 RVA: 0x00077B84 File Offset: 0x00075D84
	public void ResetLoadout()
	{
		if (!Singleton<LoadoutManager>.Instance.Loadout.Compare(GameState.Current.Avatar.Loadout))
		{
			GameState.Current.Avatar.Loadout.ClearAllSlots();
			GameState.Current.Avatar.SetLoadout(new Loadout(Singleton<LoadoutManager>.Instance.Loadout));
		}
	}

	// Token: 0x06001538 RID: 5432 RVA: 0x00077BE8 File Offset: 0x00075DE8
	public void TryGear(IUnityItem item)
	{
		if (item.View.ItemType == UberstrikeItemType.Gear)
		{
			if (item.View.ItemClass == UberstrikeItemClass.GearHolo)
			{
				this.SetLoadoutItem(global::LoadoutSlotType.GearHolo, item);
			}
			else
			{
				this.SetLoadoutItem(InventoryManager.GetSlotTypeForGear(item), item);
			}
			GameState.Current.Avatar.Decorator.AnimationController.TriggerGearAnimation(item.View.ItemClass);
			switch (item.View.ItemType)
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
		}
	}
}
