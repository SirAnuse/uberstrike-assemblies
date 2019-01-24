using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E6 RID: 230
	[CallbackIdentity(2102)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTTPRequestHeadersReceived_t
	{
		// Token: 0x0400043D RID: 1085
		public const int k_iCallback = 2102;

		// Token: 0x0400043E RID: 1086
		public HTTPRequestHandle m_hRequest;

		// Token: 0x0400043F RID: 1087
		public ulong m_ulContextValue;
	}
}
