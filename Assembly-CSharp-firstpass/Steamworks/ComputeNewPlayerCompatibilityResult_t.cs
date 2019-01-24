using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C7 RID: 199
	[CallbackIdentity(211)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ComputeNewPlayerCompatibilityResult_t
	{
		// Token: 0x040003B7 RID: 951
		public const int k_iCallback = 211;

		// Token: 0x040003B8 RID: 952
		public EResult m_eResult;

		// Token: 0x040003B9 RID: 953
		public int m_cPlayersThatDontLikeCandidate;

		// Token: 0x040003BA RID: 954
		public int m_cPlayersThatCandidateDoesntLike;

		// Token: 0x040003BB RID: 955
		public int m_cClanPlayersThatDontLikeCandidate;

		// Token: 0x040003BC RID: 956
		public CSteamID m_SteamIDCandidate;
	}
}
