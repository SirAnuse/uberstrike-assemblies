using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000040 RID: 64
	[Serializable]
	public class BundleView
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000024DC File Offset: 0x000006DC
		// (set) Token: 0x0600008E RID: 142 RVA: 0x000024E4 File Offset: 0x000006E4
		public int Id { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600008F RID: 143 RVA: 0x000024ED File Offset: 0x000006ED
		// (set) Token: 0x06000090 RID: 144 RVA: 0x000024F5 File Offset: 0x000006F5
		public int ApplicationId { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000091 RID: 145 RVA: 0x000024FE File Offset: 0x000006FE
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00002506 File Offset: 0x00000706
		public string Name { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000093 RID: 147 RVA: 0x0000250F File Offset: 0x0000070F
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00002517 File Offset: 0x00000717
		public string ImageUrl { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002520 File Offset: 0x00000720
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00002528 File Offset: 0x00000728
		public string IconUrl { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002531 File Offset: 0x00000731
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00002539 File Offset: 0x00000739
		public string Description { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00002542 File Offset: 0x00000742
		// (set) Token: 0x0600009A RID: 154 RVA: 0x0000254A File Offset: 0x0000074A
		public bool IsOnSale { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002553 File Offset: 0x00000753
		// (set) Token: 0x0600009C RID: 156 RVA: 0x0000255B File Offset: 0x0000075B
		public bool IsPromoted { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002564 File Offset: 0x00000764
		// (set) Token: 0x0600009E RID: 158 RVA: 0x0000256C File Offset: 0x0000076C
		public decimal USDPrice { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00002575 File Offset: 0x00000775
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x0000257D File Offset: 0x0000077D
		public decimal USDPromoPrice { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00002586 File Offset: 0x00000786
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000258E File Offset: 0x0000078E
		public int Credits { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00002597 File Offset: 0x00000797
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x0000259F File Offset: 0x0000079F
		public int Points { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x000025A8 File Offset: 0x000007A8
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x000025B0 File Offset: 0x000007B0
		public List<BundleItemView> BundleItemViews { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x000025B9 File Offset: 0x000007B9
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x000025C1 File Offset: 0x000007C1
		public BundleCategoryType Category { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x000025CA File Offset: 0x000007CA
		// (set) Token: 0x060000AA RID: 170 RVA: 0x000025D2 File Offset: 0x000007D2
		public List<ChannelType> Availability { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000AB RID: 171 RVA: 0x000025DB File Offset: 0x000007DB
		// (set) Token: 0x060000AC RID: 172 RVA: 0x000025E3 File Offset: 0x000007E3
		public string PromotionTag { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000AD RID: 173 RVA: 0x000025EC File Offset: 0x000007EC
		// (set) Token: 0x060000AE RID: 174 RVA: 0x000025F4 File Offset: 0x000007F4
		public string MacAppStoreUniqueId { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000AF RID: 175 RVA: 0x000025FD File Offset: 0x000007FD
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00002605 File Offset: 0x00000805
		public string IosAppStoreUniqueId { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000260E File Offset: 0x0000080E
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00002616 File Offset: 0x00000816
		public string AndroidStoreUniqueId { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x0000261F File Offset: 0x0000081F
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00002627 File Offset: 0x00000827
		public bool IsDefault { get; set; }
	}
}
