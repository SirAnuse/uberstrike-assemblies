using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000107 RID: 263
	[CallbackIdentity(1203)]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct P2PSessionConnectFail_t
	{
		// Token: 0x04000493 RID: 1171
		public const int k_iCallback = 1203;

		// Token: 0x04000494 RID: 1172
		public CSteamID m_steamIDRemote;

		// Token: 0x04000495 RID: 1173
		public byte m_eP2PSessionError;
	}
}
