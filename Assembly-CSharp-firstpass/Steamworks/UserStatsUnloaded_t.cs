using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000140 RID: 320
	[CallbackIdentity(1108)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserStatsUnloaded_t
	{
		// Token: 0x0400057E RID: 1406
		public const int k_iCallback = 1108;

		// Token: 0x0400057F RID: 1407
		public CSteamID m_steamIDUser;
	}
}
