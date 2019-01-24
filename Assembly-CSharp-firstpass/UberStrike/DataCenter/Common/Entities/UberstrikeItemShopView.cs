using System;
using System.Collections.Generic;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F5 RID: 501
	public class UberstrikeItemShopView
	{
		// Token: 0x06000D57 RID: 3415 RVA: 0x00011018 File Offset: 0x0000F218
		public UberstrikeItemShopView()
		{
			this.FunctionalItems = new List<UberstrikeItemFunctionalView>();
			this.GearItems = new List<UberstrikeItemGearView>();
			this.QuickUseItems = new List<UberstrikeItemQuickUseView>();
			this.SpecialItems = new List<UberstrikeItemSpecialView>();
			this.WeaponItems = new List<UberstrikeItemWeaponView>();
			this.WeaponModItems = new List<UberstrikeItemWeaponModView>();
		}

		// Token: 0x06000D58 RID: 3416 RVA: 0x00011070 File Offset: 0x0000F270
		public UberstrikeItemShopView(List<UberstrikeItemFunctionalView> functionalItems, List<UberstrikeItemGearView> gearItems, List<UberstrikeItemQuickUseView> quickUseItems, List<UberstrikeItemSpecialView> specialItems, List<UberstrikeItemWeaponView> weaponItems, List<UberstrikeItemWeaponModView> weaponModItems, int discoutPointsSevenDays, int discountPointsThirtyDays, int discountPointsNinetyDays, int discountCreditsSevenDays, int discountCreditsThirtyDays, int discountCreditsNinetyDays)
		{
			this.FunctionalItems = functionalItems;
			this.GearItems = gearItems;
			this.QuickUseItems = quickUseItems;
			this.SpecialItems = specialItems;
			this.WeaponItems = weaponItems;
			this.WeaponModItems = weaponModItems;
			this.DiscountPointsSevenDays = discoutPointsSevenDays;
			this.DiscountPointsThirtyDays = discountPointsThirtyDays;
			this.DiscountPointsNinetyDays = discountPointsNinetyDays;
			this.DiscountCreditsSevenDays = discountCreditsSevenDays;
			this.DiscountCreditsThirtyDays = discountCreditsThirtyDays;
			this.DiscountCreditsNinetyDays = discountCreditsNinetyDays;
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06000D59 RID: 3417 RVA: 0x000095FD File Offset: 0x000077FD
		// (set) Token: 0x06000D5A RID: 3418 RVA: 0x00009605 File Offset: 0x00007805
		public List<UberstrikeItemFunctionalView> FunctionalItems { get; set; }

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06000D5B RID: 3419 RVA: 0x0000960E File Offset: 0x0000780E
		// (set) Token: 0x06000D5C RID: 3420 RVA: 0x00009616 File Offset: 0x00007816
		public List<UberstrikeItemGearView> GearItems { get; set; }

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000D5D RID: 3421 RVA: 0x0000961F File Offset: 0x0000781F
		// (set) Token: 0x06000D5E RID: 3422 RVA: 0x00009627 File Offset: 0x00007827
		public List<UberstrikeItemQuickUseView> QuickUseItems { get; set; }

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000D5F RID: 3423 RVA: 0x00009630 File Offset: 0x00007830
		// (set) Token: 0x06000D60 RID: 3424 RVA: 0x00009638 File Offset: 0x00007838
		public List<UberstrikeItemSpecialView> SpecialItems { get; set; }

		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000D61 RID: 3425 RVA: 0x00009641 File Offset: 0x00007841
		// (set) Token: 0x06000D62 RID: 3426 RVA: 0x00009649 File Offset: 0x00007849
		public List<UberstrikeItemWeaponModView> WeaponModItems { get; set; }

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000D63 RID: 3427 RVA: 0x00009652 File Offset: 0x00007852
		// (set) Token: 0x06000D64 RID: 3428 RVA: 0x0000965A File Offset: 0x0000785A
		public List<UberstrikeItemWeaponView> WeaponItems { get; set; }

		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000D65 RID: 3429 RVA: 0x00009663 File Offset: 0x00007863
		// (set) Token: 0x06000D66 RID: 3430 RVA: 0x0000966B File Offset: 0x0000786B
		public int DiscountPointsSevenDays { get; set; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06000D67 RID: 3431 RVA: 0x00009674 File Offset: 0x00007874
		// (set) Token: 0x06000D68 RID: 3432 RVA: 0x0000967C File Offset: 0x0000787C
		public int DiscountPointsThirtyDays { get; set; }

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06000D69 RID: 3433 RVA: 0x00009685 File Offset: 0x00007885
		// (set) Token: 0x06000D6A RID: 3434 RVA: 0x0000968D File Offset: 0x0000788D
		public int DiscountPointsNinetyDays { get; set; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x00009696 File Offset: 0x00007896
		// (set) Token: 0x06000D6C RID: 3436 RVA: 0x0000969E File Offset: 0x0000789E
		public int DiscountCreditsSevenDays { get; set; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x000096A7 File Offset: 0x000078A7
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x000096AF File Offset: 0x000078AF
		public int DiscountCreditsThirtyDays { get; set; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000D6F RID: 3439 RVA: 0x000096B8 File Offset: 0x000078B8
		// (set) Token: 0x06000D70 RID: 3440 RVA: 0x000096C0 File Offset: 0x000078C0
		public int DiscountCreditsNinetyDays { get; set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x000096C9 File Offset: 0x000078C9
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x000096D1 File Offset: 0x000078D1
		public Dictionary<int, int> ItemsRecommendationPerMap { get; set; }

		// Token: 0x06000D73 RID: 3443 RVA: 0x000110E0 File Offset: 0x0000F2E0
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeItemShopView: ");
			stringBuilder.Append("[FunctionalItems: ");
			if (this.FunctionalItems != null && this.FunctionalItems.Count > 0)
			{
				foreach (UberstrikeItemFunctionalView value in this.FunctionalItems)
				{
					stringBuilder.Append(value);
				}
			}
			stringBuilder.Append("][GearItems: ");
			if (this.GearItems != null && this.GearItems.Count > 0)
			{
				foreach (UberstrikeItemGearView value2 in this.GearItems)
				{
					stringBuilder.Append(value2);
				}
			}
			stringBuilder.Append("][QuickUseItems: ");
			if (this.QuickUseItems != null && this.QuickUseItems.Count > 0)
			{
				foreach (UberstrikeItemQuickUseView value3 in this.QuickUseItems)
				{
					stringBuilder.Append(value3);
				}
			}
			stringBuilder.Append("][SpecialItems: ");
			if (this.SpecialItems != null && this.SpecialItems.Count > 0)
			{
				foreach (UberstrikeItemSpecialView value4 in this.SpecialItems)
				{
					stringBuilder.Append(value4);
				}
			}
			stringBuilder.Append("][WeaponItems: ");
			if (this.WeaponItems != null && this.WeaponItems.Count > 0)
			{
				foreach (UberstrikeItemWeaponView value5 in this.WeaponItems)
				{
					stringBuilder.Append(value5);
				}
			}
			stringBuilder.Append("][WeaponModItems: ");
			if (this.WeaponModItems != null && this.WeaponModItems.Count > 0)
			{
				foreach (UberstrikeItemWeaponModView value6 in this.WeaponModItems)
				{
					stringBuilder.Append(value6);
				}
			}
			stringBuilder.Append("[DiscountPointsSevenDays: ");
			stringBuilder.Append(this.DiscountPointsSevenDays);
			stringBuilder.Append("%][DiscountPointsThirtyDays: ");
			stringBuilder.Append(this.DiscountPointsThirtyDays);
			stringBuilder.Append("%][DiscountPointsNinetyDays: ");
			stringBuilder.Append(this.DiscountPointsNinetyDays);
			stringBuilder.Append("%][DiscountCreditsSevenDays: ");
			stringBuilder.Append(this.DiscountCreditsSevenDays);
			stringBuilder.Append("%][DiscountCreditsThirtyDays: ");
			stringBuilder.Append(this.DiscountCreditsThirtyDays);
			stringBuilder.Append("%][DiscountCreditsNinetyDays: ");
			stringBuilder.Append(this.DiscountCreditsNinetyDays);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
