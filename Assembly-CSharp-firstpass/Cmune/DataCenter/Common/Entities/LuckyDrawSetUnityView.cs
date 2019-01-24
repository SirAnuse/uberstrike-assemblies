using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000056 RID: 86
	[Serializable]
	public class LuckyDrawSetUnityView
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x000030A3 File Offset: 0x000012A3
		// (set) Token: 0x060001F4 RID: 500 RVA: 0x000030AB File Offset: 0x000012AB
		public int Id { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x000030B4 File Offset: 0x000012B4
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x000030BC File Offset: 0x000012BC
		public int SetWeight { get; set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x000030C5 File Offset: 0x000012C5
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x000030CD File Offset: 0x000012CD
		public int CreditsAttributed { get; set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x000030D6 File Offset: 0x000012D6
		// (set) Token: 0x060001FA RID: 506 RVA: 0x000030DE File Offset: 0x000012DE
		public int PointsAttributed { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060001FB RID: 507 RVA: 0x000030E7 File Offset: 0x000012E7
		// (set) Token: 0x060001FC RID: 508 RVA: 0x000030EF File Offset: 0x000012EF
		public string ImageUrl { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060001FD RID: 509 RVA: 0x000030F8 File Offset: 0x000012F8
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00003100 File Offset: 0x00001300
		public bool ExposeItemsToPlayers { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00003109 File Offset: 0x00001309
		// (set) Token: 0x06000200 RID: 512 RVA: 0x00003111 File Offset: 0x00001311
		public int LuckyDrawId { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000201 RID: 513 RVA: 0x0000311A File Offset: 0x0000131A
		// (set) Token: 0x06000202 RID: 514 RVA: 0x00003122 File Offset: 0x00001322
		public List<BundleItemView> LuckyDrawSetItems { get; set; }
	}
}
