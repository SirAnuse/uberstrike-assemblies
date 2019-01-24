using System;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000239 RID: 569
	[Serializable]
	public class MatchPointsView
	{
		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000F80 RID: 3968 RVA: 0x0000A81C File Offset: 0x00008A1C
		// (set) Token: 0x06000F81 RID: 3969 RVA: 0x0000A824 File Offset: 0x00008A24
		public int WinnerPointsBase { get; set; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000F82 RID: 3970 RVA: 0x0000A82D File Offset: 0x00008A2D
		// (set) Token: 0x06000F83 RID: 3971 RVA: 0x0000A835 File Offset: 0x00008A35
		public int LoserPointsBase { get; set; }

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0000A83E File Offset: 0x00008A3E
		// (set) Token: 0x06000F85 RID: 3973 RVA: 0x0000A846 File Offset: 0x00008A46
		public int WinnerPointsPerMinute { get; set; }

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x0000A84F File Offset: 0x00008A4F
		// (set) Token: 0x06000F87 RID: 3975 RVA: 0x0000A857 File Offset: 0x00008A57
		public int LoserPointsPerMinute { get; set; }

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x0000A860 File Offset: 0x00008A60
		// (set) Token: 0x06000F89 RID: 3977 RVA: 0x0000A868 File Offset: 0x00008A68
		public int MaxTimeInGame { get; set; }
	}
}
