using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000115 RID: 277
	[CallbackIdentity(1316)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageUpdatePublishedFileResult_t
	{
		// Token: 0x040004CB RID: 1227
		public const int k_iCallback = 1316;

		// Token: 0x040004CC RID: 1228
		public EResult m_eResult;

		// Token: 0x040004CD RID: 1229
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040004CE RID: 1230
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}
}
