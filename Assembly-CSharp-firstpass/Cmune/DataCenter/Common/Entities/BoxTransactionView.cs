using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200003D RID: 61
	public class BoxTransactionView
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000066 RID: 102 RVA: 0x0000239B File Offset: 0x0000059B
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000023A3 File Offset: 0x000005A3
		public int Id { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000023AC File Offset: 0x000005AC
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000023B4 File Offset: 0x000005B4
		public BoxType BoxType { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000023BD File Offset: 0x000005BD
		// (set) Token: 0x0600006B RID: 107 RVA: 0x000023C5 File Offset: 0x000005C5
		public BundleCategoryType Category { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600006C RID: 108 RVA: 0x000023CE File Offset: 0x000005CE
		// (set) Token: 0x0600006D RID: 109 RVA: 0x000023D6 File Offset: 0x000005D6
		public int BoxId { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000023DF File Offset: 0x000005DF
		// (set) Token: 0x0600006F RID: 111 RVA: 0x000023E7 File Offset: 0x000005E7
		public int Cmid { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000023F0 File Offset: 0x000005F0
		// (set) Token: 0x06000071 RID: 113 RVA: 0x000023F8 File Offset: 0x000005F8
		public DateTime TransactionDate { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002401 File Offset: 0x00000601
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00002409 File Offset: 0x00000609
		public bool IsAdmin { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00002412 File Offset: 0x00000612
		// (set) Token: 0x06000075 RID: 117 RVA: 0x0000241A File Offset: 0x0000061A
		public int CreditPrice { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00002423 File Offset: 0x00000623
		// (set) Token: 0x06000077 RID: 119 RVA: 0x0000242B File Offset: 0x0000062B
		public int PointPrice { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002434 File Offset: 0x00000634
		// (set) Token: 0x06000079 RID: 121 RVA: 0x0000243C File Offset: 0x0000063C
		public int TotalCreditsAttributed { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00002445 File Offset: 0x00000645
		// (set) Token: 0x0600007B RID: 123 RVA: 0x0000244D File Offset: 0x0000064D
		public int TotalPointsAttributed { get; set; }
	}
}
