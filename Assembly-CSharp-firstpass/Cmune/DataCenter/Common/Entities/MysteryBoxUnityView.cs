using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000062 RID: 98
	[Serializable]
	public class MysteryBoxUnityView
	{
		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000376D File Offset: 0x0000196D
		// (set) Token: 0x060002B8 RID: 696 RVA: 0x00003775 File Offset: 0x00001975
		public int Id { get; set; }

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000377E File Offset: 0x0000197E
		// (set) Token: 0x060002BA RID: 698 RVA: 0x00003786 File Offset: 0x00001986
		public string Name { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0000378F File Offset: 0x0000198F
		// (set) Token: 0x060002BC RID: 700 RVA: 0x00003797 File Offset: 0x00001997
		public string Description { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060002BD RID: 701 RVA: 0x000037A0 File Offset: 0x000019A0
		// (set) Token: 0x060002BE RID: 702 RVA: 0x000037A8 File Offset: 0x000019A8
		public int Price { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060002BF RID: 703 RVA: 0x000037B1 File Offset: 0x000019B1
		// (set) Token: 0x060002C0 RID: 704 RVA: 0x000037B9 File Offset: 0x000019B9
		public UberStrikeCurrencyType UberStrikeCurrencyType { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x000037C2 File Offset: 0x000019C2
		// (set) Token: 0x060002C2 RID: 706 RVA: 0x000037CA File Offset: 0x000019CA
		public string IconUrl { get; set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x000037D3 File Offset: 0x000019D3
		// (set) Token: 0x060002C4 RID: 708 RVA: 0x000037DB File Offset: 0x000019DB
		public BundleCategoryType Category { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x000037E4 File Offset: 0x000019E4
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x000037EC File Offset: 0x000019EC
		public bool IsAvailableInShop { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x000037F5 File Offset: 0x000019F5
		// (set) Token: 0x060002C8 RID: 712 RVA: 0x000037FD File Offset: 0x000019FD
		public int ItemsAttributed { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060002C9 RID: 713 RVA: 0x00003806 File Offset: 0x00001A06
		// (set) Token: 0x060002CA RID: 714 RVA: 0x0000380E File Offset: 0x00001A0E
		public string ImageUrl { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060002CB RID: 715 RVA: 0x00003817 File Offset: 0x00001A17
		// (set) Token: 0x060002CC RID: 716 RVA: 0x0000381F File Offset: 0x00001A1F
		public bool ExposeItemsToPlayers { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060002CD RID: 717 RVA: 0x00003828 File Offset: 0x00001A28
		// (set) Token: 0x060002CE RID: 718 RVA: 0x00003830 File Offset: 0x00001A30
		public int PointsAttributed { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060002CF RID: 719 RVA: 0x00003839 File Offset: 0x00001A39
		// (set) Token: 0x060002D0 RID: 720 RVA: 0x00003841 File Offset: 0x00001A41
		public int PointsAttributedWeight { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x0000384A File Offset: 0x00001A4A
		// (set) Token: 0x060002D2 RID: 722 RVA: 0x00003852 File Offset: 0x00001A52
		public int CreditsAttributed { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060002D3 RID: 723 RVA: 0x0000385B File Offset: 0x00001A5B
		// (set) Token: 0x060002D4 RID: 724 RVA: 0x00003863 File Offset: 0x00001A63
		public int CreditsAttributedWeight { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x0000386C File Offset: 0x00001A6C
		// (set) Token: 0x060002D6 RID: 726 RVA: 0x00003874 File Offset: 0x00001A74
		public List<BundleItemView> MysteryBoxItems { get; set; }
	}
}
