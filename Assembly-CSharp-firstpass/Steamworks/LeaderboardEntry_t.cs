using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000195 RID: 405
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LeaderboardEntry_t
	{
		// Token: 0x040008F5 RID: 2293
		public CSteamID m_steamIDUser;

		// Token: 0x040008F6 RID: 2294
		public int m_nGlobalRank;

		// Token: 0x040008F7 RID: 2295
		public int m_nScore;

		// Token: 0x040008F8 RID: 2296
		public int m_cDetails;

		// Token: 0x040008F9 RID: 2297
		public UGCHandle_t m_hUGC;
	}
}
