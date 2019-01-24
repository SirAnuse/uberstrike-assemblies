using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200013C RID: 316
	[CallbackIdentity(1104)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardFindResult_t
	{
		// Token: 0x0400056D RID: 1389
		public const int k_iCallback = 1104;

		// Token: 0x0400056E RID: 1390
		public SteamLeaderboard_t m_hSteamLeaderboard;

		// Token: 0x0400056F RID: 1391
		public byte m_bLeaderboardFound;
	}
}
