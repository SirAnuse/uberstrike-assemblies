using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000113 RID: 275
	[CallbackIdentity(1314)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumerateUserSubscribedFilesResult_t
	{
		// Token: 0x040004C2 RID: 1218
		public const int k_iCallback = 1314;

		// Token: 0x040004C3 RID: 1219
		public EResult m_eResult;

		// Token: 0x040004C4 RID: 1220
		public int m_nResultsReturned;

		// Token: 0x040004C5 RID: 1221
		public int m_nTotalResultCount;

		// Token: 0x040004C6 RID: 1222
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;

		// Token: 0x040004C7 RID: 1223
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public uint[] m_rgRTimeSubscribed;
	}
}
