using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E5 RID: 229
	[CallbackIdentity(2101)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTTPRequestCompleted_t
	{
		// Token: 0x04000438 RID: 1080
		public const int k_iCallback = 2101;

		// Token: 0x04000439 RID: 1081
		public HTTPRequestHandle m_hRequest;

		// Token: 0x0400043A RID: 1082
		public ulong m_ulContextValue;

		// Token: 0x0400043B RID: 1083
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bRequestSuccessful;

		// Token: 0x0400043C RID: 1084
		public EHTTPStatusCode m_eStatusCode;
	}
}
