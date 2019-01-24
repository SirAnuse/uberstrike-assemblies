using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200004B RID: 75
	public class CreditPackItemView
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00002910 File Offset: 0x00000B10
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00002918 File Offset: 0x00000B18
		public int CreditPackId { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00002921 File Offset: 0x00000B21
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00002929 File Offset: 0x00000B29
		public int ItemId { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00002932 File Offset: 0x00000B32
		// (set) Token: 0x0600010A RID: 266 RVA: 0x0000293A File Offset: 0x00000B3A
		public BuyingDurationType Duration { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00002943 File Offset: 0x00000B43
		// (set) Token: 0x0600010C RID: 268 RVA: 0x0000294B File Offset: 0x00000B4B
		public ItemView ItemView { get; set; }
	}
}
