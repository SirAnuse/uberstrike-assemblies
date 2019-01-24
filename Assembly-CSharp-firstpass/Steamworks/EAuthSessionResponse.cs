using System;

namespace Steamworks
{
	// Token: 0x0200017E RID: 382
	public enum EAuthSessionResponse
	{
		// Token: 0x0400080B RID: 2059
		k_EAuthSessionResponseOK,
		// Token: 0x0400080C RID: 2060
		k_EAuthSessionResponseUserNotConnectedToSteam,
		// Token: 0x0400080D RID: 2061
		k_EAuthSessionResponseNoLicenseOrExpired,
		// Token: 0x0400080E RID: 2062
		k_EAuthSessionResponseVACBanned,
		// Token: 0x0400080F RID: 2063
		k_EAuthSessionResponseLoggedInElseWhere,
		// Token: 0x04000810 RID: 2064
		k_EAuthSessionResponseVACCheckTimedOut,
		// Token: 0x04000811 RID: 2065
		k_EAuthSessionResponseAuthTicketCanceled,
		// Token: 0x04000812 RID: 2066
		k_EAuthSessionResponseAuthTicketInvalidAlreadyUsed,
		// Token: 0x04000813 RID: 2067
		k_EAuthSessionResponseAuthTicketInvalid,
		// Token: 0x04000814 RID: 2068
		k_EAuthSessionResponsePublisherIssuedBan
	}
}
