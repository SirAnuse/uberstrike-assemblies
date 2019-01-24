using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200013D RID: 317
	[CallbackIdentity(1105)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardScoresDownloaded_t
	{
		// Token: 0x04000570 RID: 1392
		public const int k_iCallback = 1105;

		// Token: 0x04000571 RID: 1393
		public SteamLeaderboard_t m_hSteamLeaderboard;

		// Token: 0x04000572 RID: 1394
		public SteamLeaderboardEntries_t m_hSteamLeaderboardEntries;

		// Token: 0x04000573 RID: 1395
		public int m_cEntryCount;
	}
}
