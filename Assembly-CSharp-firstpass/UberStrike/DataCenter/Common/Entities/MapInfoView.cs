using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E1 RID: 481
	public class MapInfoView
	{
		// Token: 0x06000C12 RID: 3090 RVA: 0x00008A71 File Offset: 0x00006C71
		public MapInfoView(int mapId, string displayName, string sceneName, string description)
		{
			this.MapId = mapId;
			this.DisplayName = displayName;
			this.SceneName = sceneName;
			this.Description = description;
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000C13 RID: 3091 RVA: 0x00008A96 File Offset: 0x00006C96
		// (set) Token: 0x06000C14 RID: 3092 RVA: 0x00008A9E File Offset: 0x00006C9E
		public int MapId { get; set; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000C15 RID: 3093 RVA: 0x00008AA7 File Offset: 0x00006CA7
		// (set) Token: 0x06000C16 RID: 3094 RVA: 0x00008AAF File Offset: 0x00006CAF
		public string DisplayName { get; set; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000C17 RID: 3095 RVA: 0x00008AB8 File Offset: 0x00006CB8
		// (set) Token: 0x06000C18 RID: 3096 RVA: 0x00008AC0 File Offset: 0x00006CC0
		public string SceneName { get; set; }

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x00008AC9 File Offset: 0x00006CC9
		// (set) Token: 0x06000C1A RID: 3098 RVA: 0x00008AD1 File Offset: 0x00006CD1
		public string Description { get; set; }

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000C1B RID: 3099 RVA: 0x00008ADA File Offset: 0x00006CDA
		// (set) Token: 0x06000C1C RID: 3100 RVA: 0x00008AE2 File Offset: 0x00006CE2
		public bool InUse { get; set; }

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000C1D RID: 3101 RVA: 0x00008AEB File Offset: 0x00006CEB
		// (set) Token: 0x06000C1E RID: 3102 RVA: 0x00008AF3 File Offset: 0x00006CF3
		public int PlayerMax { get; set; }

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000C1F RID: 3103 RVA: 0x00008AFC File Offset: 0x00006CFC
		// (set) Token: 0x06000C20 RID: 3104 RVA: 0x00008B04 File Offset: 0x00006D04
		public int SupportedGameModes { get; set; }

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000C21 RID: 3105 RVA: 0x00008B0D File Offset: 0x00006D0D
		// (set) Token: 0x06000C22 RID: 3106 RVA: 0x00008B15 File Offset: 0x00006D15
		public int SupportedItemClass { get; set; }
	}
}
