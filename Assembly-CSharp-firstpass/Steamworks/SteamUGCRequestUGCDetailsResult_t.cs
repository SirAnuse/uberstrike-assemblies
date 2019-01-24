using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000127 RID: 295
	[CallbackIdentity(3402)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamUGCRequestUGCDetailsResult_t
	{
		// Token: 0x0400052C RID: 1324
		public const int k_iCallback = 3402;

		// Token: 0x0400052D RID: 1325
		public SteamUGCDetails_t m_details;

		// Token: 0x0400052E RID: 1326
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;
	}
}
