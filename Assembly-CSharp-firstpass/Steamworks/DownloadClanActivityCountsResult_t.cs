using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B5 RID: 181
	[CallbackIdentity(341)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct DownloadClanActivityCountsResult_t
	{
		// Token: 0x04000377 RID: 887
		public const int k_iCallback = 341;

		// Token: 0x04000378 RID: 888
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSuccess;
	}
}
