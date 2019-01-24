using System;
using UberStrike.Core.Types;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E2 RID: 482
	public class MapUsageView
	{
		// Token: 0x06000C23 RID: 3107 RVA: 0x00008B1E File Offset: 0x00006D1E
		public MapUsageView(DateTime playDate, int mapId, GameModeType gameModeId, int timeLimit, int playerLimit, int playersTotal, int playersCompleted)
		{
			this.PlayDate = playDate;
			this.MapId = mapId;
			this.GameModeId = gameModeId;
			this.TimeLimit = timeLimit;
			this.PlayerLimit = playerLimit;
			this.PlayersTotal = playersTotal;
			this.PlayersCompleted = playersCompleted;
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x00008B5B File Offset: 0x00006D5B
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x00008B63 File Offset: 0x00006D63
		public DateTime PlayDate { get; private set; }

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x00008B6C File Offset: 0x00006D6C
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x00008B74 File Offset: 0x00006D74
		public int MapId { get; private set; }

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00008B7D File Offset: 0x00006D7D
		// (set) Token: 0x06000C29 RID: 3113 RVA: 0x00008B85 File Offset: 0x00006D85
		public GameModeType GameModeId { get; private set; }

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000C2A RID: 3114 RVA: 0x00008B8E File Offset: 0x00006D8E
		// (set) Token: 0x06000C2B RID: 3115 RVA: 0x00008B96 File Offset: 0x00006D96
		public int TimeLimit { get; private set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000C2C RID: 3116 RVA: 0x00008B9F File Offset: 0x00006D9F
		// (set) Token: 0x06000C2D RID: 3117 RVA: 0x00008BA7 File Offset: 0x00006DA7
		public int PlayerLimit { get; private set; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000C2E RID: 3118 RVA: 0x00008BB0 File Offset: 0x00006DB0
		// (set) Token: 0x06000C2F RID: 3119 RVA: 0x00008BB8 File Offset: 0x00006DB8
		public int PlayersTotal { get; private set; }

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000C30 RID: 3120 RVA: 0x00008BC1 File Offset: 0x00006DC1
		// (set) Token: 0x06000C31 RID: 3121 RVA: 0x00008BC9 File Offset: 0x00006DC9
		public int PlayersCompleted { get; private set; }
	}
}
