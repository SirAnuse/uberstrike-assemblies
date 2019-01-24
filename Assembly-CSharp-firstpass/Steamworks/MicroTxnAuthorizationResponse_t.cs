using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000134 RID: 308
	[CallbackIdentity(152)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MicroTxnAuthorizationResponse_t
	{
		// Token: 0x04000553 RID: 1363
		public const int k_iCallback = 152;

		// Token: 0x04000554 RID: 1364
		public uint m_unAppID;

		// Token: 0x04000555 RID: 1365
		public ulong m_ulOrderID;

		// Token: 0x04000556 RID: 1366
		public byte m_bAuthorized;
	}
}
