using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000135 RID: 309
	[CallbackIdentity(154)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct EncryptedAppTicketResponse_t
	{
		// Token: 0x04000557 RID: 1367
		public const int k_iCallback = 154;

		// Token: 0x04000558 RID: 1368
		public EResult m_eResult;
	}
}
