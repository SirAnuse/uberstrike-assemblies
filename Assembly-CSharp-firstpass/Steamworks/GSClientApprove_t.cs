using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000BE RID: 190
	[CallbackIdentity(201)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSClientApprove_t
	{
		// Token: 0x04000393 RID: 915
		public const int k_iCallback = 201;

		// Token: 0x04000394 RID: 916
		public CSteamID m_SteamID;

		// Token: 0x04000395 RID: 917
		public CSteamID m_OwnerSteamID;
	}
}
