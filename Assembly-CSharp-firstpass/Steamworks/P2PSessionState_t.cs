using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000191 RID: 401
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct P2PSessionState_t
	{
		// Token: 0x040008CD RID: 2253
		public byte m_bConnectionActive;

		// Token: 0x040008CE RID: 2254
		public byte m_bConnecting;

		// Token: 0x040008CF RID: 2255
		public byte m_eP2PSessionError;

		// Token: 0x040008D0 RID: 2256
		public byte m_bUsingRelay;

		// Token: 0x040008D1 RID: 2257
		public int m_nBytesQueuedForSend;

		// Token: 0x040008D2 RID: 2258
		public int m_nPacketsQueuedForSend;

		// Token: 0x040008D3 RID: 2259
		public uint m_nRemoteIP;

		// Token: 0x040008D4 RID: 2260
		public ushort m_nRemotePort;
	}
}
