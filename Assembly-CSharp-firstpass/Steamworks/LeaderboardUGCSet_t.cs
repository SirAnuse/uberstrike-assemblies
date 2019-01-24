using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000143 RID: 323
	[CallbackIdentity(1111)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardUGCSet_t
	{
		// Token: 0x04000588 RID: 1416
		public const int k_iCallback = 1111;

		// Token: 0x04000589 RID: 1417
		public EResult m_eResult;

		// Token: 0x0400058A RID: 1418
		public SteamLeaderboard_t m_hSteamLeaderboard;
	}
}
