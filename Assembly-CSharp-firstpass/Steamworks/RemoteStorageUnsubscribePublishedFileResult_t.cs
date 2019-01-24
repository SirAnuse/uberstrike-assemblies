using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000114 RID: 276
	[CallbackIdentity(1315)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageUnsubscribePublishedFileResult_t
	{
		// Token: 0x040004C8 RID: 1224
		public const int k_iCallback = 1315;

		// Token: 0x040004C9 RID: 1225
		public EResult m_eResult;

		// Token: 0x040004CA RID: 1226
		public PublishedFileId_t m_nPublishedFileId;
	}
}
