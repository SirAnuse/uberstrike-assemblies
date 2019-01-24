using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000112 RID: 274
	[CallbackIdentity(1313)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageSubscribePublishedFileResult_t
	{
		// Token: 0x040004BF RID: 1215
		public const int k_iCallback = 1313;

		// Token: 0x040004C0 RID: 1216
		public EResult m_eResult;

		// Token: 0x040004C1 RID: 1217
		public PublishedFileId_t m_nPublishedFileId;
	}
}
