using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000133 RID: 307
	[CallbackIdentity(143)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct ValidateAuthTicketResponse_t
	{
		// Token: 0x0400054F RID: 1359
		public const int k_iCallback = 143;

		// Token: 0x04000550 RID: 1360
		public CSteamID m_SteamID;

		// Token: 0x04000551 RID: 1361
		public EAuthSessionResponse m_eAuthSessionResponse;

		// Token: 0x04000552 RID: 1362
		public CSteamID m_OwnerSteamID;
	}
}
