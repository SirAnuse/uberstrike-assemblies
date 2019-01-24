using System;
using System.Collections.Generic;
using UberStrike.Core.Types;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000238 RID: 568
	[Serializable]
	public class MapView
	{
		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000F6B RID: 3947 RVA: 0x0000A772 File Offset: 0x00008972
		// (set) Token: 0x06000F6C RID: 3948 RVA: 0x0000A77A File Offset: 0x0000897A
		public int MapId { get; set; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000F6D RID: 3949 RVA: 0x0000A783 File Offset: 0x00008983
		// (set) Token: 0x06000F6E RID: 3950 RVA: 0x0000A78B File Offset: 0x0000898B
		public string DisplayName { get; set; }

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000F6F RID: 3951 RVA: 0x0000A794 File Offset: 0x00008994
		// (set) Token: 0x06000F70 RID: 3952 RVA: 0x0000A79C File Offset: 0x0000899C
		public string Description { get; set; }

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000F71 RID: 3953 RVA: 0x0000A7A5 File Offset: 0x000089A5
		// (set) Token: 0x06000F72 RID: 3954 RVA: 0x0000A7AD File Offset: 0x000089AD
		public string SceneName { get; set; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000F73 RID: 3955 RVA: 0x0000A7B6 File Offset: 0x000089B6
		// (set) Token: 0x06000F74 RID: 3956 RVA: 0x0000A7BE File Offset: 0x000089BE
		public bool IsBlueBox { get; set; }

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000F75 RID: 3957 RVA: 0x0000A7C7 File Offset: 0x000089C7
		// (set) Token: 0x06000F76 RID: 3958 RVA: 0x0000A7CF File Offset: 0x000089CF
		public int RecommendedItemId { get; set; }

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000F77 RID: 3959 RVA: 0x0000A7D8 File Offset: 0x000089D8
		// (set) Token: 0x06000F78 RID: 3960 RVA: 0x0000A7E0 File Offset: 0x000089E0
		public int SupportedGameModes { get; set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000F79 RID: 3961 RVA: 0x0000A7E9 File Offset: 0x000089E9
		// (set) Token: 0x06000F7A RID: 3962 RVA: 0x0000A7F1 File Offset: 0x000089F1
		public int SupportedItemClass { get; set; }

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000F7B RID: 3963 RVA: 0x0000A7FA File Offset: 0x000089FA
		// (set) Token: 0x06000F7C RID: 3964 RVA: 0x0000A802 File Offset: 0x00008A02
		public int MaxPlayers { get; set; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000F7D RID: 3965 RVA: 0x0000A80B File Offset: 0x00008A0B
		// (set) Token: 0x06000F7E RID: 3966 RVA: 0x0000A813 File Offset: 0x00008A13
		public Dictionary<GameModeType, MapSettings> Settings { get; set; }
	}
}
