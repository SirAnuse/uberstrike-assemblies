using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000111 RID: 273
	[CallbackIdentity(1312)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumerateUserPublishedFilesResult_t
	{
		// Token: 0x040004BA RID: 1210
		public const int k_iCallback = 1312;

		// Token: 0x040004BB RID: 1211
		public EResult m_eResult;

		// Token: 0x040004BC RID: 1212
		public int m_nResultsReturned;

		// Token: 0x040004BD RID: 1213
		public int m_nTotalResultCount;

		// Token: 0x040004BE RID: 1214
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;
	}
}
