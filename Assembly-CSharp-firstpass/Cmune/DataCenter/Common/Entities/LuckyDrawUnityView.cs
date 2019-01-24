using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000058 RID: 88
	[Serializable]
	public class LuckyDrawUnityView
	{
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000215 RID: 533 RVA: 0x000031B3 File Offset: 0x000013B3
		// (set) Token: 0x06000216 RID: 534 RVA: 0x000031BB File Offset: 0x000013BB
		public int Id { get; set; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000217 RID: 535 RVA: 0x000031C4 File Offset: 0x000013C4
		// (set) Token: 0x06000218 RID: 536 RVA: 0x000031CC File Offset: 0x000013CC
		public string Name { get; set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000219 RID: 537 RVA: 0x000031D5 File Offset: 0x000013D5
		// (set) Token: 0x0600021A RID: 538 RVA: 0x000031DD File Offset: 0x000013DD
		public string Description { get; set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600021B RID: 539 RVA: 0x000031E6 File Offset: 0x000013E6
		// (set) Token: 0x0600021C RID: 540 RVA: 0x000031EE File Offset: 0x000013EE
		public int Price { get; set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600021D RID: 541 RVA: 0x000031F7 File Offset: 0x000013F7
		// (set) Token: 0x0600021E RID: 542 RVA: 0x000031FF File Offset: 0x000013FF
		public UberStrikeCurrencyType UberStrikeCurrencyType { get; set; }

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00003208 File Offset: 0x00001408
		// (set) Token: 0x06000220 RID: 544 RVA: 0x00003210 File Offset: 0x00001410
		public string IconUrl { get; set; }

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00003219 File Offset: 0x00001419
		// (set) Token: 0x06000222 RID: 546 RVA: 0x00003221 File Offset: 0x00001421
		public BundleCategoryType Category { get; set; }

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000322A File Offset: 0x0000142A
		// (set) Token: 0x06000224 RID: 548 RVA: 0x00003232 File Offset: 0x00001432
		public bool IsAvailableInShop { get; set; }

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000225 RID: 549 RVA: 0x0000323B File Offset: 0x0000143B
		// (set) Token: 0x06000226 RID: 550 RVA: 0x00003243 File Offset: 0x00001443
		public List<LuckyDrawSetUnityView> LuckyDrawSets { get; set; }
	}
}
