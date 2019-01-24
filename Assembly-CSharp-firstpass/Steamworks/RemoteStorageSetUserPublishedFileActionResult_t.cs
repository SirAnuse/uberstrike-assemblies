using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000120 RID: 288
	[CallbackIdentity(1327)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageSetUserPublishedFileActionResult_t
	{
		// Token: 0x04000510 RID: 1296
		public const int k_iCallback = 1327;

		// Token: 0x04000511 RID: 1297
		public EResult m_eResult;

		// Token: 0x04000512 RID: 1298
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000513 RID: 1299
		public EWorkshopFileAction m_eAction;
	}
}
