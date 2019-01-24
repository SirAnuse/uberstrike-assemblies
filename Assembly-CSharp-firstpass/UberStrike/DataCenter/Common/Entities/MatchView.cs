using System;
using System.Collections.Generic;
using UberStrike.Core.Types;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E5 RID: 485
	[Serializable]
	public class MatchView
	{
		// Token: 0x06000C42 RID: 3138 RVA: 0x00002050 File Offset: 0x00000250
		public MatchView()
		{
		}

		// Token: 0x06000C43 RID: 3139 RVA: 0x00008C5F File Offset: 0x00006E5F
		public MatchView(List<PlayerStatisticsView> playersCompleted, List<PlayerStatisticsView> playersNonCompleted, int mapId, GameModeType gameModeId, int timeLimit, int playersLimit)
		{
			this.PlayersCompleted = playersCompleted;
			this.PlayersNonCompleted = playersNonCompleted;
			this.MapId = mapId;
			this.GameModeId = gameModeId;
			this.TimeLimit = timeLimit;
			this.PlayersLimit = playersLimit;
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00008C94 File Offset: 0x00006E94
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00008C9C File Offset: 0x00006E9C
		public List<PlayerStatisticsView> PlayersCompleted { get; set; }

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x00008CA5 File Offset: 0x00006EA5
		// (set) Token: 0x06000C47 RID: 3143 RVA: 0x00008CAD File Offset: 0x00006EAD
		public List<PlayerStatisticsView> PlayersNonCompleted { get; set; }

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x00008CB6 File Offset: 0x00006EB6
		// (set) Token: 0x06000C49 RID: 3145 RVA: 0x00008CBE File Offset: 0x00006EBE
		public int MapId { get; set; }

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000C4A RID: 3146 RVA: 0x00008CC7 File Offset: 0x00006EC7
		// (set) Token: 0x06000C4B RID: 3147 RVA: 0x00008CCF File Offset: 0x00006ECF
		public GameModeType GameModeId { get; set; }

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000C4C RID: 3148 RVA: 0x00008CD8 File Offset: 0x00006ED8
		// (set) Token: 0x06000C4D RID: 3149 RVA: 0x00008CE0 File Offset: 0x00006EE0
		public int TimeLimit { get; set; }

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x00008CE9 File Offset: 0x00006EE9
		// (set) Token: 0x06000C4F RID: 3151 RVA: 0x00008CF1 File Offset: 0x00006EF1
		public int PlayersLimit { get; set; }
	}
}
