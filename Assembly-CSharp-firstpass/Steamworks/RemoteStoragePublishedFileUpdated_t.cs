using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000123 RID: 291
	[CallbackIdentity(1330)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishedFileUpdated_t
	{
		// Token: 0x0400051E RID: 1310
		public const int k_iCallback = 1330;

		// Token: 0x0400051F RID: 1311
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000520 RID: 1312
		public AppId_t m_nAppID;

		// Token: 0x04000521 RID: 1313
		public UGCHandle_t m_hFile;
	}
}
