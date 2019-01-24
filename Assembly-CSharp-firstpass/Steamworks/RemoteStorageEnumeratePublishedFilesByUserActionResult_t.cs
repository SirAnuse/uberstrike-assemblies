using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000121 RID: 289
	[CallbackIdentity(1328)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumeratePublishedFilesByUserActionResult_t
	{
		// Token: 0x04000514 RID: 1300
		public const int k_iCallback = 1328;

		// Token: 0x04000515 RID: 1301
		public EResult m_eResult;

		// Token: 0x04000516 RID: 1302
		public EWorkshopFileAction m_eAction;

		// Token: 0x04000517 RID: 1303
		public int m_nResultsReturned;

		// Token: 0x04000518 RID: 1304
		public int m_nTotalResultCount;

		// Token: 0x04000519 RID: 1305
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;

		// Token: 0x0400051A RID: 1306
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public uint[] m_rgRTimeUpdated;
	}
}
