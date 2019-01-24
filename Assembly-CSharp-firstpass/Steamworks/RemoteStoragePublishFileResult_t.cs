using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010F RID: 271
	[CallbackIdentity(1309)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishFileResult_t
	{
		// Token: 0x040004B3 RID: 1203
		public const int k_iCallback = 1309;

		// Token: 0x040004B4 RID: 1204
		public EResult m_eResult;

		// Token: 0x040004B5 RID: 1205
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040004B6 RID: 1206
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}
}
