using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200013E RID: 318
	[CallbackIdentity(1106)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardScoreUploaded_t
	{
		// Token: 0x04000574 RID: 1396
		public const int k_iCallback = 1106;

		// Token: 0x04000575 RID: 1397
		public byte m_bSuccess;

		// Token: 0x04000576 RID: 1398
		public SteamLeaderboard_t m_hSteamLeaderboard;

		// Token: 0x04000577 RID: 1399
		public int m_nScore;

		// Token: 0x04000578 RID: 1400
		public byte m_bScoreChanged;

		// Token: 0x04000579 RID: 1401
		public int m_nGlobalRankNew;

		// Token: 0x0400057A RID: 1402
		public int m_nGlobalRankPrevious;
	}
}
