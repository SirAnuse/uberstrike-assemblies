using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000063 RID: 99
	public class MysteryBoxView
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0000387D File Offset: 0x00001A7D
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00003885 File Offset: 0x00001A85
		public int Id { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000388E File Offset: 0x00001A8E
		// (set) Token: 0x060002DB RID: 731 RVA: 0x00003896 File Offset: 0x00001A96
		public string Name { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000389F File Offset: 0x00001A9F
		// (set) Token: 0x060002DD RID: 733 RVA: 0x000038A7 File Offset: 0x00001AA7
		public string Description { get; set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060002DE RID: 734 RVA: 0x000038B0 File Offset: 0x00001AB0
		// (set) Token: 0x060002DF RID: 735 RVA: 0x000038B8 File Offset: 0x00001AB8
		public int Price { get; set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x000038C1 File Offset: 0x00001AC1
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x000038C9 File Offset: 0x00001AC9
		public UberStrikeCurrencyType UberStrikeCurrencyType { get; set; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x000038D2 File Offset: 0x00001AD2
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x000038DA File Offset: 0x00001ADA
		public string IconUrl { get; set; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060002E4 RID: 740 RVA: 0x000038E3 File Offset: 0x00001AE3
		// (set) Token: 0x060002E5 RID: 741 RVA: 0x000038EB File Offset: 0x00001AEB
		public BundleCategoryType Category { get; set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060002E6 RID: 742 RVA: 0x000038F4 File Offset: 0x00001AF4
		// (set) Token: 0x060002E7 RID: 743 RVA: 0x000038FC File Offset: 0x00001AFC
		public bool IsAvailableInShop { get; set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060002E8 RID: 744 RVA: 0x00003905 File Offset: 0x00001B05
		// (set) Token: 0x060002E9 RID: 745 RVA: 0x0000390D File Offset: 0x00001B0D
		public int ItemsAttributed { get; set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060002EA RID: 746 RVA: 0x00003916 File Offset: 0x00001B16
		// (set) Token: 0x060002EB RID: 747 RVA: 0x0000391E File Offset: 0x00001B1E
		public string ImageUrl { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00003927 File Offset: 0x00001B27
		// (set) Token: 0x060002ED RID: 749 RVA: 0x0000392F File Offset: 0x00001B2F
		public bool ExposeItemsToPlayers { get; set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00003938 File Offset: 0x00001B38
		// (set) Token: 0x060002EF RID: 751 RVA: 0x00003940 File Offset: 0x00001B40
		public int PointsAttributed { get; set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00003949 File Offset: 0x00001B49
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x00003951 File Offset: 0x00001B51
		public int PointsAttributedWeight { get; set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x0000395A File Offset: 0x00001B5A
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00003962 File Offset: 0x00001B62
		public int CreditsAttributed { get; set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x0000396B File Offset: 0x00001B6B
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00003973 File Offset: 0x00001B73
		public int CreditsAttributedWeight { get; set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0000397C File Offset: 0x00001B7C
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x00003984 File Offset: 0x00001B84
		public List<MysteryBoxItemView> MysteryBoxItems { get; set; }
	}
}
