using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020001B4 RID: 436
public static class ShopUtils
{
	// Token: 0x06000C1D RID: 3101 RVA: 0x00050C0C File Offset: 0x0004EE0C
	public static ItemPrice GetLowestPrice(IUnityItem item, UberStrikeCurrencyType currency = UberStrikeCurrencyType.None)
	{
		ItemPrice itemPrice = null;
		if (item != null && item.View != null && item.View.Prices != null)
		{
			foreach (ItemPrice itemPrice2 in item.View.Prices)
			{
				if ((currency == UberStrikeCurrencyType.None || itemPrice2.Currency == currency) && (itemPrice == null || itemPrice.Price > itemPrice2.Price))
				{
					itemPrice = itemPrice2;
				}
			}
		}
		return itemPrice;
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x00050CB0 File Offset: 0x0004EEB0
	public static string PrintDuration(BuyingDurationType duration)
	{
		switch (duration)
		{
		case BuyingDurationType.OneDay:
			return " 1 " + LocalizedStrings.Day;
		case BuyingDurationType.SevenDays:
			return " 1 " + LocalizedStrings.Week;
		case BuyingDurationType.ThirtyDays:
			return " 1 " + LocalizedStrings.Month;
		case BuyingDurationType.NinetyDays:
			return " " + LocalizedStrings.ThreeMonths;
		case BuyingDurationType.Permanent:
			return " " + LocalizedStrings.Permanent;
		default:
			return string.Empty;
		}
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x00050D38 File Offset: 0x0004EF38
	public static Texture2D CurrencyIcon(UberStrikeCurrencyType currency)
	{
		if (currency == UberStrikeCurrencyType.Credits)
		{
			return ShopIcons.IconCredits20x20;
		}
		if (currency != UberStrikeCurrencyType.Points)
		{
			return null;
		}
		return ShopIcons.IconPoints20x20;
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x00009468 File Offset: 0x00007668
	public static bool IsMeleeWeapon(IUnityItem view)
	{
		return view != null && view.View != null && view.View.ItemClass == UberstrikeItemClass.WeaponMelee;
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x00050D68 File Offset: 0x0004EF68
	public static bool IsInstantHitWeapon(IUnityItem view)
	{
		return view != null && view.View != null && (view.View.ItemClass == UberstrikeItemClass.WeaponMachinegun || view.View.ItemClass == UberstrikeItemClass.WeaponShotgun || view.View.ItemClass == UberstrikeItemClass.WeaponSniperRifle);
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x00050DBC File Offset: 0x0004EFBC
	public static bool IsProjectileWeapon(IUnityItem view)
	{
		return view != null && view.View != null && (view.View.ItemClass == UberstrikeItemClass.WeaponCannon || view.View.ItemClass == UberstrikeItemClass.WeaponLauncher || view.View.ItemClass == UberstrikeItemClass.WeaponSplattergun);
	}

	// Token: 0x020001B5 RID: 437
	public class PriceComparer<T> : IComparer<KeyValuePair<T, ItemPrice>>
	{
		// Token: 0x06000C24 RID: 3108 RVA: 0x00050E10 File Offset: 0x0004F010
		public int Compare(KeyValuePair<T, ItemPrice> x, KeyValuePair<T, ItemPrice> y)
		{
			int value = x.Value.Price + ((x.Value.Currency != UberStrikeCurrencyType.Credits) ? 0 : 1000000);
			return (y.Value.Price + ((y.Value.Currency != UberStrikeCurrencyType.Credits) ? 0 : 1000000)).CompareTo(value);
		}
	}

	// Token: 0x020001B6 RID: 438
	private class DescendedComparer : IComparer<int>
	{
		// Token: 0x06000C26 RID: 3110 RVA: 0x0000948B File Offset: 0x0000768B
		public int Compare(int x, int y)
		{
			return y - x;
		}
	}
}
