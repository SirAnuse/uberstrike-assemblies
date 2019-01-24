using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000059 RID: 89
	public class LuckyDrawView
	{
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0000324C File Offset: 0x0000144C
		// (set) Token: 0x06000229 RID: 553 RVA: 0x00003254 File Offset: 0x00001454
		public int Id { get; set; }

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600022A RID: 554 RVA: 0x0000325D File Offset: 0x0000145D
		// (set) Token: 0x0600022B RID: 555 RVA: 0x00003265 File Offset: 0x00001465
		public string Name { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600022C RID: 556 RVA: 0x0000326E File Offset: 0x0000146E
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00003276 File Offset: 0x00001476
		public string Description { get; set; }

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600022E RID: 558 RVA: 0x0000327F File Offset: 0x0000147F
		// (set) Token: 0x0600022F RID: 559 RVA: 0x00003287 File Offset: 0x00001487
		public int Price { get; set; }

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00003290 File Offset: 0x00001490
		// (set) Token: 0x06000231 RID: 561 RVA: 0x00003298 File Offset: 0x00001498
		public UberStrikeCurrencyType UberStrikeCurrencyType { get; set; }

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000232 RID: 562 RVA: 0x000032A1 File Offset: 0x000014A1
		// (set) Token: 0x06000233 RID: 563 RVA: 0x000032A9 File Offset: 0x000014A9
		public string IconUrl { get; set; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000234 RID: 564 RVA: 0x000032B2 File Offset: 0x000014B2
		// (set) Token: 0x06000235 RID: 565 RVA: 0x000032BA File Offset: 0x000014BA
		public BundleCategoryType Category { get; set; }

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000236 RID: 566 RVA: 0x000032C3 File Offset: 0x000014C3
		// (set) Token: 0x06000237 RID: 567 RVA: 0x000032CB File Offset: 0x000014CB
		public bool IsAvailableInShop { get; set; }

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000032D4 File Offset: 0x000014D4
		// (set) Token: 0x06000239 RID: 569 RVA: 0x000032DC File Offset: 0x000014DC
		public List<LuckyDrawSetView> LuckyDrawSets { get; set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600023A RID: 570 RVA: 0x000032E5 File Offset: 0x000014E5
		// (set) Token: 0x0600023B RID: 571 RVA: 0x000032ED File Offset: 0x000014ED
		public bool IsEnabled { get; set; }
	}
}
