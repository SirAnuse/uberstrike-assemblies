using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200011E RID: 286
	[CallbackIdentity(1325)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageUserVoteDetails_t
	{
		// Token: 0x04000507 RID: 1287
		public const int k_iCallback = 1325;

		// Token: 0x04000508 RID: 1288
		public EResult m_eResult;

		// Token: 0x04000509 RID: 1289
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x0400050A RID: 1290
		public EWorkshopVote m_eVote;
	}
}
