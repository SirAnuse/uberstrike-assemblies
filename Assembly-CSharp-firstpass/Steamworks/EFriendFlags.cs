using System;

namespace Steamworks
{
	// Token: 0x02000151 RID: 337
	[Flags]
	public enum EFriendFlags
	{
		// Token: 0x0400065B RID: 1627
		k_EFriendFlagNone = 0,
		// Token: 0x0400065C RID: 1628
		k_EFriendFlagBlocked = 1,
		// Token: 0x0400065D RID: 1629
		k_EFriendFlagFriendshipRequested = 2,
		// Token: 0x0400065E RID: 1630
		k_EFriendFlagImmediate = 4,
		// Token: 0x0400065F RID: 1631
		k_EFriendFlagClanMember = 8,
		// Token: 0x04000660 RID: 1632
		k_EFriendFlagOnGameServer = 16,
		// Token: 0x04000661 RID: 1633
		k_EFriendFlagRequestingFriendship = 128,
		// Token: 0x04000662 RID: 1634
		k_EFriendFlagRequestingInfo = 256,
		// Token: 0x04000663 RID: 1635
		k_EFriendFlagIgnored = 512,
		// Token: 0x04000664 RID: 1636
		k_EFriendFlagIgnoredFriend = 1024,
		// Token: 0x04000665 RID: 1637
		k_EFriendFlagSuggested = 2048,
		// Token: 0x04000666 RID: 1638
		k_EFriendFlagAll = 65535
	}
}
