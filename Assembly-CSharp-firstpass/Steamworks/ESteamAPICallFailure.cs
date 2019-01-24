using System;

namespace Steamworks
{
	// Token: 0x02000175 RID: 373
	public enum ESteamAPICallFailure
	{
		// Token: 0x04000777 RID: 1911
		k_ESteamAPICallFailureNone = -1,
		// Token: 0x04000778 RID: 1912
		k_ESteamAPICallFailureSteamGone,
		// Token: 0x04000779 RID: 1913
		k_ESteamAPICallFailureNetworkFailure,
		// Token: 0x0400077A RID: 1914
		k_ESteamAPICallFailureInvalidHandle,
		// Token: 0x0400077B RID: 1915
		k_ESteamAPICallFailureMismatchedCallback
	}
}
