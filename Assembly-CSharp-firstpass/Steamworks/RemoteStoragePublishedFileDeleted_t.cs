using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011C RID: 284
	[CallbackIdentity(1323)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishedFileDeleted_t
	{
		// Token: 0x04000501 RID: 1281
		public const int k_iCallback = 1323;

		// Token: 0x04000502 RID: 1282
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000503 RID: 1283
		public AppId_t m_nAppID;
	}
}
