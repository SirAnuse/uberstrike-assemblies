using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011F RID: 287
	[CallbackIdentity(1326)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumerateUserSharedWorkshopFilesResult_t
	{
		// Token: 0x0400050B RID: 1291
		public const int k_iCallback = 1326;

		// Token: 0x0400050C RID: 1292
		public EResult m_eResult;

		// Token: 0x0400050D RID: 1293
		public int m_nResultsReturned;

		// Token: 0x0400050E RID: 1294
		public int m_nTotalResultCount;

		// Token: 0x0400050F RID: 1295
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;
	}
}
