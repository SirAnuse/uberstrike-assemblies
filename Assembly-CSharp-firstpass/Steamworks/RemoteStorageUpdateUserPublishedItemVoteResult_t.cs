using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011D RID: 285
	[CallbackIdentity(1324)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageUpdateUserPublishedItemVoteResult_t
	{
		// Token: 0x04000504 RID: 1284
		public const int k_iCallback = 1324;

		// Token: 0x04000505 RID: 1285
		public EResult m_eResult;

		// Token: 0x04000506 RID: 1286
		public PublishedFileId_t m_nPublishedFileId;
	}
}
