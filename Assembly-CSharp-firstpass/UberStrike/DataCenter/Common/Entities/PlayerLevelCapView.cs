using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001E7 RID: 487
	[Serializable]
	public class PlayerLevelCapView
	{
		// Token: 0x06000C6A RID: 3178 RVA: 0x00002050 File Offset: 0x00000250
		public PlayerLevelCapView()
		{
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x00008E5B File Offset: 0x0000705B
		public PlayerLevelCapView(int level, int xpRequired)
		{
			this.Level = level;
			this.XPRequired = xpRequired;
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x00008E71 File Offset: 0x00007071
		public PlayerLevelCapView(int playerLevelCapId, int level, int xpRequired) : this(level, xpRequired)
		{
			this.PlayerLevelCapId = playerLevelCapId;
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000C6D RID: 3181 RVA: 0x00008E82 File Offset: 0x00007082
		// (set) Token: 0x06000C6E RID: 3182 RVA: 0x00008E8A File Offset: 0x0000708A
		public int PlayerLevelCapId { get; set; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x00008E93 File Offset: 0x00007093
		// (set) Token: 0x06000C70 RID: 3184 RVA: 0x00008E9B File Offset: 0x0000709B
		public int Level { get; set; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000C71 RID: 3185 RVA: 0x00008EA4 File Offset: 0x000070A4
		// (set) Token: 0x06000C72 RID: 3186 RVA: 0x00008EAC File Offset: 0x000070AC
		public int XPRequired { get; set; }

		// Token: 0x06000C73 RID: 3187 RVA: 0x000104E8 File Offset: 0x0000E6E8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[PlayerLevelCapView: ");
			stringBuilder.Append("[PlayerLevelCapId: ");
			stringBuilder.Append(this.PlayerLevelCapId);
			stringBuilder.Append("][Level: ");
			stringBuilder.Append(this.Level);
			stringBuilder.Append("][XPRequired: ");
			stringBuilder.Append(this.XPRequired);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
