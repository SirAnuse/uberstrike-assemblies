using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000106 RID: 262
	[CallbackIdentity(1202)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct P2PSessionRequest_t
	{
		// Token: 0x04000491 RID: 1169
		public const int k_iCallback = 1202;

		// Token: 0x04000492 RID: 1170
		public CSteamID m_steamIDRemote;
	}
}
