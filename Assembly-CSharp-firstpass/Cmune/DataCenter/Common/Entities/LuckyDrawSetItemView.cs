using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000055 RID: 85
	public class LuckyDrawSetItemView
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000303D File Offset: 0x0000123D
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x00003045 File Offset: 0x00001245
		public int Id { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000304E File Offset: 0x0000124E
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x00003056 File Offset: 0x00001256
		public string Name { get; set; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060001EA RID: 490 RVA: 0x0000305F File Offset: 0x0000125F
		// (set) Token: 0x060001EB RID: 491 RVA: 0x00003067 File Offset: 0x00001267
		public int ItemId { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00003070 File Offset: 0x00001270
		// (set) Token: 0x060001ED RID: 493 RVA: 0x00003078 File Offset: 0x00001278
		public BuyingDurationType DurationType { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00003081 File Offset: 0x00001281
		// (set) Token: 0x060001EF RID: 495 RVA: 0x00003089 File Offset: 0x00001289
		public int Amount { get; set; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00003092 File Offset: 0x00001292
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x0000309A File Offset: 0x0000129A
		public int LuckyDrawSetId { get; set; }
	}
}
