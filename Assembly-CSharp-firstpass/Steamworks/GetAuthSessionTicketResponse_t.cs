using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000136 RID: 310
	[CallbackIdentity(163)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GetAuthSessionTicketResponse_t
	{
		// Token: 0x04000559 RID: 1369
		public const int k_iCallback = 163;

		// Token: 0x0400055A RID: 1370
		public HAuthTicket m_hAuthTicket;

		// Token: 0x0400055B RID: 1371
		public EResult m_eResult;
	}
}
