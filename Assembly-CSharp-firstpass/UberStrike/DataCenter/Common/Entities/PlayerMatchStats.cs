using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E8 RID: 488
	[Serializable]
	public class PlayerMatchStats
	{
		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000C75 RID: 3189 RVA: 0x00008EB5 File Offset: 0x000070B5
		// (set) Token: 0x06000C76 RID: 3190 RVA: 0x00008EBD File Offset: 0x000070BD
		public int Cmid { get; set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000C77 RID: 3191 RVA: 0x00008EC6 File Offset: 0x000070C6
		// (set) Token: 0x06000C78 RID: 3192 RVA: 0x00008ECE File Offset: 0x000070CE
		public int Kills { get; set; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00008ED7 File Offset: 0x000070D7
		// (set) Token: 0x06000C7A RID: 3194 RVA: 0x00008EDF File Offset: 0x000070DF
		public int Death { get; set; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x00008EE8 File Offset: 0x000070E8
		// (set) Token: 0x06000C7C RID: 3196 RVA: 0x00008EF0 File Offset: 0x000070F0
		public long Shots { get; set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x00008EF9 File Offset: 0x000070F9
		// (set) Token: 0x06000C7E RID: 3198 RVA: 0x00008F01 File Offset: 0x00007101
		public long Hits { get; set; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x00008F0A File Offset: 0x0000710A
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x00008F12 File Offset: 0x00007112
		public int TimeSpentInGame { get; set; }

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x00008F1B File Offset: 0x0000711B
		// (set) Token: 0x06000C82 RID: 3202 RVA: 0x00008F23 File Offset: 0x00007123
		public int Headshots { get; set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x00008F2C File Offset: 0x0000712C
		// (set) Token: 0x06000C84 RID: 3204 RVA: 0x00008F34 File Offset: 0x00007134
		public int Nutshots { get; set; }

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x00008F3D File Offset: 0x0000713D
		// (set) Token: 0x06000C86 RID: 3206 RVA: 0x00008F45 File Offset: 0x00007145
		public int Smackdowns { get; set; }

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x00008F4E File Offset: 0x0000714E
		// (set) Token: 0x06000C88 RID: 3208 RVA: 0x00008F56 File Offset: 0x00007156
		public bool HasFinishedMatch { get; set; }

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06000C89 RID: 3209 RVA: 0x00008F5F File Offset: 0x0000715F
		// (set) Token: 0x06000C8A RID: 3210 RVA: 0x00008F67 File Offset: 0x00007167
		public bool HasWonMatch { get; set; }

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x00008F70 File Offset: 0x00007170
		// (set) Token: 0x06000C8C RID: 3212 RVA: 0x00008F78 File Offset: 0x00007178
		public PlayerPersonalRecordStatisticsView PersonalRecord { get; set; }

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x00008F81 File Offset: 0x00007181
		// (set) Token: 0x06000C8E RID: 3214 RVA: 0x00008F89 File Offset: 0x00007189
		public PlayerWeaponStatisticsView WeaponStatistics { get; set; }
	}
}
