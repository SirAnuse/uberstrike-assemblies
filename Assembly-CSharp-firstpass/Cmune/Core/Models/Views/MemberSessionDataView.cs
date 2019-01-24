using System;
using Cmune.DataCenter.Common.Entities;

namespace Cmune.Core.Models.Views
{
	// Token: 0x0200005C RID: 92
	[Serializable]
	public class MemberSessionDataView
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000259 RID: 601 RVA: 0x00003413 File Offset: 0x00001613
		// (set) Token: 0x0600025A RID: 602 RVA: 0x0000341B File Offset: 0x0000161B
		public string AuthToken { get; set; }

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x0600025B RID: 603 RVA: 0x00003424 File Offset: 0x00001624
		// (set) Token: 0x0600025C RID: 604 RVA: 0x0000342C File Offset: 0x0000162C
		public int Cmid { get; set; }

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00003435 File Offset: 0x00001635
		// (set) Token: 0x0600025E RID: 606 RVA: 0x0000343D File Offset: 0x0000163D
		public string Name { get; set; }

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00003446 File Offset: 0x00001646
		// (set) Token: 0x06000260 RID: 608 RVA: 0x0000344E File Offset: 0x0000164E
		public MemberAccessLevel AccessLevel { get; set; }

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00003457 File Offset: 0x00001657
		// (set) Token: 0x06000262 RID: 610 RVA: 0x0000345F File Offset: 0x0000165F
		public int Level { get; set; }

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00003468 File Offset: 0x00001668
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00003470 File Offset: 0x00001670
		public int XP { get; set; }

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00003479 File Offset: 0x00001679
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00003481 File Offset: 0x00001681
		public string ClanTag { get; set; }

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000267 RID: 615 RVA: 0x0000348A File Offset: 0x0000168A
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00003492 File Offset: 0x00001692
		public ChannelType Channel { get; set; }

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000349B File Offset: 0x0000169B
		// (set) Token: 0x0600026A RID: 618 RVA: 0x000034A3 File Offset: 0x000016A3
		public DateTime LoginDate { get; set; }

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600026B RID: 619 RVA: 0x000034AC File Offset: 0x000016AC
		// (set) Token: 0x0600026C RID: 620 RVA: 0x000034B4 File Offset: 0x000016B4
		public bool IsBanned { get; set; }
	}
}
