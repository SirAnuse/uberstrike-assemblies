using System;
using System.Collections.Generic;

namespace UberStrike.Core.Models
{
	// Token: 0x02000217 RID: 535
	[Serializable]
	public class EndOfMatchData
	{
		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000DE6 RID: 3558 RVA: 0x00009A52 File Offset: 0x00007C52
		// (set) Token: 0x06000DE7 RID: 3559 RVA: 0x00009A5A File Offset: 0x00007C5A
		public List<StatsSummary> MostValuablePlayers { get; set; }

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x00009A63 File Offset: 0x00007C63
		// (set) Token: 0x06000DE9 RID: 3561 RVA: 0x00009A6B File Offset: 0x00007C6B
		public int MostEffecientWeaponId { get; set; }

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000DEA RID: 3562 RVA: 0x00009A74 File Offset: 0x00007C74
		// (set) Token: 0x06000DEB RID: 3563 RVA: 0x00009A7C File Offset: 0x00007C7C
		public StatsCollection PlayerStatsTotal { get; set; }

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000DEC RID: 3564 RVA: 0x00009A85 File Offset: 0x00007C85
		// (set) Token: 0x06000DED RID: 3565 RVA: 0x00009A8D File Offset: 0x00007C8D
		public StatsCollection PlayerStatsBestPerLife { get; set; }

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000DEE RID: 3566 RVA: 0x00009A96 File Offset: 0x00007C96
		// (set) Token: 0x06000DEF RID: 3567 RVA: 0x00009A9E File Offset: 0x00007C9E
		public Dictionary<byte, ushort> PlayerXpEarned { get; set; }

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000DF0 RID: 3568 RVA: 0x00009AA7 File Offset: 0x00007CA7
		// (set) Token: 0x06000DF1 RID: 3569 RVA: 0x00009AAF File Offset: 0x00007CAF
		public int TimeInGameMinutes { get; set; }

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000DF2 RID: 3570 RVA: 0x00009AB8 File Offset: 0x00007CB8
		// (set) Token: 0x06000DF3 RID: 3571 RVA: 0x00009AC0 File Offset: 0x00007CC0
		public bool HasWonMatch { get; set; }

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000DF4 RID: 3572 RVA: 0x00009AC9 File Offset: 0x00007CC9
		// (set) Token: 0x06000DF5 RID: 3573 RVA: 0x00009AD1 File Offset: 0x00007CD1
		public string MatchGuid { get; set; }
	}
}
