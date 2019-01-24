using System;
using System.Collections.Generic;
using UberStrike.Core.Types;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E4 RID: 484
	[Serializable]
	public class MatchStats
	{
		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000C38 RID: 3128 RVA: 0x00008C0A File Offset: 0x00006E0A
		// (set) Token: 0x06000C39 RID: 3129 RVA: 0x00008C12 File Offset: 0x00006E12
		public List<PlayerMatchStats> Players { get; set; }

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000C3A RID: 3130 RVA: 0x00008C1B File Offset: 0x00006E1B
		// (set) Token: 0x06000C3B RID: 3131 RVA: 0x00008C23 File Offset: 0x00006E23
		public int MapId { get; set; }

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x00008C2C File Offset: 0x00006E2C
		// (set) Token: 0x06000C3D RID: 3133 RVA: 0x00008C34 File Offset: 0x00006E34
		public GameModeType GameModeId { get; set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x00008C3D File Offset: 0x00006E3D
		// (set) Token: 0x06000C3F RID: 3135 RVA: 0x00008C45 File Offset: 0x00006E45
		public int TimeLimit { get; set; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x00008C4E File Offset: 0x00006E4E
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x00008C56 File Offset: 0x00006E56
		public int PlayersLimit { get; set; }
	}
}
