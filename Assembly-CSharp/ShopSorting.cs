using System;
using System.Collections.Generic;
using UberStrike.Core.Types;

// Token: 0x020001FC RID: 508
public static class ShopSorting
{
	// Token: 0x06000E2D RID: 3629 RVA: 0x0006135C File Offset: 0x0005F55C
	private static int CompareDuration(InventoryItem a, InventoryItem b, bool ascending)
	{
		if (a.IsPermanent && b.IsPermanent)
		{
			return ShopSorting.CompareName(a.Item, b.Item, ascending);
		}
		if (a.IsPermanent)
		{
			return (!ascending) ? -1 : 1;
		}
		if (b.IsPermanent)
		{
			return (!ascending) ? 1 : -1;
		}
		if (a.DaysRemaining > b.DaysRemaining)
		{
			return (!ascending) ? -1 : 1;
		}
		if (a.DaysRemaining < b.DaysRemaining)
		{
			return (!ascending) ? 1 : -1;
		}
		return ShopSorting.CompareName(a.Item, b.Item, ascending);
	}

	// Token: 0x06000E2E RID: 3630 RVA: 0x00061414 File Offset: 0x0005F614
	private static int CompareLevel(IUnityItem a, IUnityItem b, bool ascending)
	{
		if (a.View.LevelLock < b.View.LevelLock)
		{
			return (!ascending) ? 1 : -1;
		}
		if (a.View.LevelLock > b.View.LevelLock)
		{
			return (!ascending) ? -1 : 1;
		}
		return ShopSorting.CompareName(a, b, ascending);
	}

	// Token: 0x06000E2F RID: 3631 RVA: 0x0006147C File Offset: 0x0005F67C
	private static int CompareClass(IUnityItem a, IUnityItem b, bool ascending)
	{
		int num = (!ascending) ? -1 : 1;
		int num2 = (a.View.ItemType != UberstrikeItemType.Weapon) ? 100 : 10;
		int num3 = (b.View.ItemType != UberstrikeItemType.Weapon) ? 100 : 10;
		switch (a.View.ItemClass)
		{
		case UberstrikeItemClass.WeaponMelee:
			num2 += 7;
			break;
		case UberstrikeItemClass.WeaponMachinegun:
			num2 = num2;
			break;
		case UberstrikeItemClass.WeaponShotgun:
			num2 += 4;
			break;
		case UberstrikeItemClass.WeaponSniperRifle:
			num2 += 2;
			break;
		case UberstrikeItemClass.WeaponCannon:
			num2++;
			break;
		case UberstrikeItemClass.WeaponSplattergun:
			num2 += 5;
			break;
		case UberstrikeItemClass.WeaponLauncher:
			num2 += 3;
			break;
		case UberstrikeItemClass.GearBoots:
			num2 += 4;
			break;
		case UberstrikeItemClass.GearHead:
			num2 = num2;
			break;
		case UberstrikeItemClass.GearFace:
			num2++;
			break;
		case UberstrikeItemClass.GearUpperBody:
			num2 += 2;
			break;
		case UberstrikeItemClass.GearLowerBody:
			num2 += 3;
			break;
		case UberstrikeItemClass.GearGloves:
			num2 += 5;
			break;
		case UberstrikeItemClass.GearHolo:
			num2 += 6;
			break;
		}
		switch (b.View.ItemClass)
		{
		case UberstrikeItemClass.WeaponMelee:
			num3 += 7;
			break;
		case UberstrikeItemClass.WeaponMachinegun:
			num3 = num3;
			break;
		case UberstrikeItemClass.WeaponShotgun:
			num3 += 4;
			break;
		case UberstrikeItemClass.WeaponSniperRifle:
			num3 += 2;
			break;
		case UberstrikeItemClass.WeaponCannon:
			num3++;
			break;
		case UberstrikeItemClass.WeaponSplattergun:
			num3 += 5;
			break;
		case UberstrikeItemClass.WeaponLauncher:
			num3 += 3;
			break;
		case UberstrikeItemClass.GearBoots:
			num3 += 4;
			break;
		case UberstrikeItemClass.GearHead:
			num3 = num3;
			break;
		case UberstrikeItemClass.GearFace:
			num3++;
			break;
		case UberstrikeItemClass.GearUpperBody:
			num3 += 2;
			break;
		case UberstrikeItemClass.GearLowerBody:
			num3 += 3;
			break;
		case UberstrikeItemClass.GearGloves:
			num3 += 5;
			break;
		case UberstrikeItemClass.GearHolo:
			num3 += 6;
			break;
		}
		if (num2 == num3)
		{
			return 0;
		}
		return (num2 <= num3) ? (num * -1) : num;
	}

	// Token: 0x06000E30 RID: 3632 RVA: 0x0000A5A4 File Offset: 0x000087A4
	private static int CompareName(IUnityItem a, IUnityItem b, bool ascending)
	{
		if (ascending)
		{
			return string.Compare(a.View.Name, b.View.Name);
		}
		return string.Compare(b.View.Name, a.View.Name);
	}

	// Token: 0x020001FD RID: 509
	public abstract class ItemComparer<T> : IComparer<T>
	{
		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000E32 RID: 3634 RVA: 0x0000A5E3 File Offset: 0x000087E3
		// (set) Token: 0x06000E33 RID: 3635 RVA: 0x0000A5EB File Offset: 0x000087EB
		public bool Ascending { get; protected set; }

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000E34 RID: 3636 RVA: 0x0000A5F4 File Offset: 0x000087F4
		// (set) Token: 0x06000E35 RID: 3637 RVA: 0x0000A5FC File Offset: 0x000087FC
		public ShopSortedColumns Column { get; set; }

		// Token: 0x06000E36 RID: 3638 RVA: 0x0000A605 File Offset: 0x00008805
		public void SwitchOrder()
		{
			this.Ascending = !this.Ascending;
		}

		// Token: 0x06000E37 RID: 3639
		public abstract int Compare(T a, T b);
	}

	// Token: 0x020001FE RID: 510
	public class LevelComparer : ShopSorting.ItemComparer<IShopItemGUI>
	{
		// Token: 0x06000E38 RID: 3640 RVA: 0x0000A616 File Offset: 0x00008816
		public LevelComparer()
		{
			base.Column = ShopSortedColumns.Level;
			base.Ascending = true;
		}

		// Token: 0x06000E39 RID: 3641 RVA: 0x0000A62C File Offset: 0x0000882C
		public override int Compare(IShopItemGUI a, IShopItemGUI b)
		{
			return ShopSorting.CompareLevel(a.Item, b.Item, base.Ascending);
		}
	}

	// Token: 0x020001FF RID: 511
	public class ItemClassComparer : ShopSorting.ItemComparer<IShopItemGUI>
	{
		// Token: 0x06000E3A RID: 3642 RVA: 0x0000A645 File Offset: 0x00008845
		public ItemClassComparer()
		{
			base.Column = ShopSortedColumns.Duration;
			base.Ascending = false;
		}

		// Token: 0x06000E3B RID: 3643 RVA: 0x000616C4 File Offset: 0x0005F8C4
		public override int Compare(IShopItemGUI a, IShopItemGUI b)
		{
			if (a.Item.View.ItemClass == b.Item.View.ItemClass)
			{
				InventoryItemGUI inventoryItemGUI = a as InventoryItemGUI;
				InventoryItemGUI inventoryItemGUI2 = b as InventoryItemGUI;
				return ShopSorting.CompareDuration(inventoryItemGUI.InventoryItem, inventoryItemGUI2.InventoryItem, base.Ascending);
			}
			return (!base.Ascending) ? b.Item.View.ItemClass.CompareTo(a.Item.View.ItemClass) : a.Item.View.ItemClass.CompareTo(b.Item.View.ItemClass);
		}
	}
}
