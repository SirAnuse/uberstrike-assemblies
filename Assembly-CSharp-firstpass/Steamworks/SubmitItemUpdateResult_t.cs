using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000129 RID: 297
	[CallbackIdentity(3404)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SubmitItemUpdateResult_t
	{
		// Token: 0x04000533 RID: 1331
		public const int k_iCallback = 3404;

		// Token: 0x04000534 RID: 1332
		public EResult m_eResult;

		// Token: 0x04000535 RID: 1333
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	}
}
