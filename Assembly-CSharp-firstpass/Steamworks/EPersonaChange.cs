using System;

namespace Steamworks
{
	// Token: 0x02000154 RID: 340
	[Flags]
	public enum EPersonaChange
	{
		// Token: 0x04000675 RID: 1653
		k_EPersonaChangeName = 1,
		// Token: 0x04000676 RID: 1654
		k_EPersonaChangeStatus = 2,
		// Token: 0x04000677 RID: 1655
		k_EPersonaChangeComeOnline = 4,
		// Token: 0x04000678 RID: 1656
		k_EPersonaChangeGoneOffline = 8,
		// Token: 0x04000679 RID: 1657
		k_EPersonaChangeGamePlayed = 16,
		// Token: 0x0400067A RID: 1658
		k_EPersonaChangeGameServer = 32,
		// Token: 0x0400067B RID: 1659
		k_EPersonaChangeAvatar = 64,
		// Token: 0x0400067C RID: 1660
		k_EPersonaChangeJoinedSource = 128,
		// Token: 0x0400067D RID: 1661
		k_EPersonaChangeLeftSource = 256,
		// Token: 0x0400067E RID: 1662
		k_EPersonaChangeRelationshipChanged = 512,
		// Token: 0x0400067F RID: 1663
		k_EPersonaChangeNameFirstSet = 1024,
		// Token: 0x04000680 RID: 1664
		k_EPersonaChangeFacebookInfo = 2048,
		// Token: 0x04000681 RID: 1665
		k_EPersonaChangeNickname = 4096,
		// Token: 0x04000682 RID: 1666
		k_EPersonaChangeSteamLevel = 8192
	}
}
