﻿using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000119 RID: 281
	[CallbackIdentity(1320)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageGetPublishedItemVoteDetailsResult_t
	{
		// Token: 0x040004F4 RID: 1268
		public const int k_iCallback = 1320;

		// Token: 0x040004F5 RID: 1269
		public EResult m_eResult;

		// Token: 0x040004F6 RID: 1270
		public PublishedFileId_t m_unPublishedFileId;

		// Token: 0x040004F7 RID: 1271
		public int m_nVotesFor;

		// Token: 0x040004F8 RID: 1272
		public int m_nVotesAgainst;

		// Token: 0x040004F9 RID: 1273
		public int m_nReports;

		// Token: 0x040004FA RID: 1274
		public float m_fScore;
	}
}
