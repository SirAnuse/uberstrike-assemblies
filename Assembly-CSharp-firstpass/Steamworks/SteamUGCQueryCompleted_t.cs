using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000126 RID: 294
	[CallbackIdentity(3401)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamUGCQueryCompleted_t
	{
		// Token: 0x04000526 RID: 1318
		public const int k_iCallback = 3401;

		// Token: 0x04000527 RID: 1319
		public UGCQueryHandle_t m_handle;

		// Token: 0x04000528 RID: 1320
		public EResult m_eResult;

		// Token: 0x04000529 RID: 1321
		public uint m_unNumResultsReturned;

		// Token: 0x0400052A RID: 1322
		public uint m_unTotalMatchingResults;

		// Token: 0x0400052B RID: 1323
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;
	}
}
