using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000147 RID: 327
	[CallbackIdentity(703)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamAPICallCompleted_t
	{
		// Token: 0x04000591 RID: 1425
		public const int k_iCallback = 703;

		// Token: 0x04000592 RID: 1426
		public SteamAPICall_t m_hAsyncCall;
	}
}
