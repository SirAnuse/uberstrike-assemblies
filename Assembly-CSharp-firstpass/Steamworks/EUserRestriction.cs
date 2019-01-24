using System;

namespace Steamworks
{
	// Token: 0x02000152 RID: 338
	public enum EUserRestriction
	{
		// Token: 0x04000668 RID: 1640
		k_nUserRestrictionNone,
		// Token: 0x04000669 RID: 1641
		k_nUserRestrictionUnknown,
		// Token: 0x0400066A RID: 1642
		k_nUserRestrictionAnyChat,
		// Token: 0x0400066B RID: 1643
		k_nUserRestrictionVoiceChat = 4,
		// Token: 0x0400066C RID: 1644
		k_nUserRestrictionGroupChat = 8,
		// Token: 0x0400066D RID: 1645
		k_nUserRestrictionRating = 16,
		// Token: 0x0400066E RID: 1646
		k_nUserRestrictionGameInvites = 32,
		// Token: 0x0400066F RID: 1647
		k_nUserRestrictionTrading = 64
	}
}
