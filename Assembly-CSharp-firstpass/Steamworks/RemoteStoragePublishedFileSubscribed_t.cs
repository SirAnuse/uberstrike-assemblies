using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011A RID: 282
	[CallbackIdentity(1321)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishedFileSubscribed_t
	{
		// Token: 0x040004FB RID: 1275
		public const int k_iCallback = 1321;

		// Token: 0x040004FC RID: 1276
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040004FD RID: 1277
		public AppId_t m_nAppID;
	}
}
