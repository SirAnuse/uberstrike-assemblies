using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200004C RID: 76
	public class CreditPackView
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00002954 File Offset: 0x00000B54
		// (set) Token: 0x0600010F RID: 271 RVA: 0x0000295C File Offset: 0x00000B5C
		public int Id { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00002965 File Offset: 0x00000B65
		// (set) Token: 0x06000111 RID: 273 RVA: 0x0000296D File Offset: 0x00000B6D
		public string Name { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00002976 File Offset: 0x00000B76
		// (set) Token: 0x06000113 RID: 275 RVA: 0x0000297E File Offset: 0x00000B7E
		public string ImageUrl { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00002987 File Offset: 0x00000B87
		// (set) Token: 0x06000115 RID: 277 RVA: 0x0000298F File Offset: 0x00000B8F
		public string Description { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00002998 File Offset: 0x00000B98
		// (set) Token: 0x06000117 RID: 279 RVA: 0x000029A0 File Offset: 0x00000BA0
		public int Bonus { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000118 RID: 280 RVA: 0x000029A9 File Offset: 0x00000BA9
		// (set) Token: 0x06000119 RID: 281 RVA: 0x000029B1 File Offset: 0x00000BB1
		public int CmuneCredits { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600011A RID: 282 RVA: 0x000029BA File Offset: 0x00000BBA
		public int TotalCCredits
		{
			get
			{
				return this.Bonus + this.CmuneCredits;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600011B RID: 283 RVA: 0x000029C9 File Offset: 0x00000BC9
		// (set) Token: 0x0600011C RID: 284 RVA: 0x000029D1 File Offset: 0x00000BD1
		public decimal USDPrice { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600011D RID: 285 RVA: 0x000029DA File Offset: 0x00000BDA
		// (set) Token: 0x0600011E RID: 286 RVA: 0x000029E2 File Offset: 0x00000BE2
		public bool OnSale { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600011F RID: 287 RVA: 0x000029EB File Offset: 0x00000BEB
		// (set) Token: 0x06000120 RID: 288 RVA: 0x000029F3 File Offset: 0x00000BF3
		public List<CreditPackItemView> CreditPackItemViews { get; set; }
	}
}
