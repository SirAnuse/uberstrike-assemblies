using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011B RID: 283
	[CallbackIdentity(1322)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishedFileUnsubscribed_t
	{
		// Token: 0x040004FE RID: 1278
		public const int k_iCallback = 1322;

		// Token: 0x040004FF RID: 1279
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000500 RID: 1280
		public AppId_t m_nAppID;
	}
}
