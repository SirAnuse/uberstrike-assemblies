using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000128 RID: 296
	[CallbackIdentity(3403)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct CreateItemResult_t
	{
		// Token: 0x0400052F RID: 1327
		public const int k_iCallback = 3403;

		// Token: 0x04000530 RID: 1328
		public EResult m_eResult;

		// Token: 0x04000531 RID: 1329
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x04000532 RID: 1330
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}
}
