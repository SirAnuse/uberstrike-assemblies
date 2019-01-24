using System;
using System.Collections.Generic;

namespace UberStrike.Core.Models
{
	// Token: 0x0200022A RID: 554
	[Serializable]
	public class StatsSummary
	{
		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000EBF RID: 3775 RVA: 0x0000A21D File Offset: 0x0000841D
		// (set) Token: 0x06000EC0 RID: 3776 RVA: 0x0000A225 File Offset: 0x00008425
		public string Name { get; set; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x0000A22E File Offset: 0x0000842E
		// (set) Token: 0x06000EC2 RID: 3778 RVA: 0x0000A236 File Offset: 0x00008436
		public int Kills { get; set; }

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x0000A23F File Offset: 0x0000843F
		// (set) Token: 0x06000EC4 RID: 3780 RVA: 0x0000A247 File Offset: 0x00008447
		public int Deaths { get; set; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000EC5 RID: 3781 RVA: 0x0000A250 File Offset: 0x00008450
		// (set) Token: 0x06000EC6 RID: 3782 RVA: 0x0000A258 File Offset: 0x00008458
		public int Level { get; set; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000EC7 RID: 3783 RVA: 0x0000A261 File Offset: 0x00008461
		// (set) Token: 0x06000EC8 RID: 3784 RVA: 0x0000A269 File Offset: 0x00008469
		public int Cmid { get; set; }

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000EC9 RID: 3785 RVA: 0x0000A272 File Offset: 0x00008472
		// (set) Token: 0x06000ECA RID: 3786 RVA: 0x0000A27A File Offset: 0x0000847A
		public TeamID Team { get; set; }

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000ECB RID: 3787 RVA: 0x0000A283 File Offset: 0x00008483
		// (set) Token: 0x06000ECC RID: 3788 RVA: 0x0000A28B File Offset: 0x0000848B
		public Dictionary<byte, ushort> Achievements { get; set; }
	}
}
