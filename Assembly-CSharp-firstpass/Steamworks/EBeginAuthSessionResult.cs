using System;

namespace Steamworks
{
	// Token: 0x0200017D RID: 381
	public enum EBeginAuthSessionResult
	{
		// Token: 0x04000804 RID: 2052
		k_EBeginAuthSessionResultOK,
		// Token: 0x04000805 RID: 2053
		k_EBeginAuthSessionResultInvalidTicket,
		// Token: 0x04000806 RID: 2054
		k_EBeginAuthSessionResultDuplicateRequest,
		// Token: 0x04000807 RID: 2055
		k_EBeginAuthSessionResultInvalidVersion,
		// Token: 0x04000808 RID: 2056
		k_EBeginAuthSessionResultGameMismatch,
		// Token: 0x04000809 RID: 2057
		k_EBeginAuthSessionResultExpiredTicket
	}
}
