using System;
using System.Collections.Generic;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000244 RID: 580
	[Serializable]
	public class UberStrikeItemShopClientView
	{
		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x0000AAF7 File Offset: 0x00008CF7
		// (set) Token: 0x06000FE3 RID: 4067 RVA: 0x0000AAFF File Offset: 0x00008CFF
		public List<UberStrikeItemFunctionalView> FunctionalItems { get; set; }

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x0000AB08 File Offset: 0x00008D08
		// (set) Token: 0x06000FE5 RID: 4069 RVA: 0x0000AB10 File Offset: 0x00008D10
		public List<UberStrikeItemGearView> GearItems { get; set; }

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x0000AB19 File Offset: 0x00008D19
		// (set) Token: 0x06000FE7 RID: 4071 RVA: 0x0000AB21 File Offset: 0x00008D21
		public List<UberStrikeItemQuickView> QuickItems { get; set; }

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000FE8 RID: 4072 RVA: 0x0000AB2A File Offset: 0x00008D2A
		// (set) Token: 0x06000FE9 RID: 4073 RVA: 0x0000AB32 File Offset: 0x00008D32
		public List<UberStrikeItemWeaponView> WeaponItems { get; set; }
	}
}
