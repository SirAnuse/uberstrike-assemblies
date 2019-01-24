using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000108 RID: 264
	[CallbackIdentity(1201)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct SocketStatusCallback_t
	{
		// Token: 0x04000496 RID: 1174
		public const int k_iCallback = 1201;

		// Token: 0x04000497 RID: 1175
		public SNetSocket_t m_hSocket;

		// Token: 0x04000498 RID: 1176
		public SNetListenSocket_t m_hListenSocket;

		// Token: 0x04000499 RID: 1177
		public CSteamID m_steamIDRemote;

		// Token: 0x0400049A RID: 1178
		public int m_eSNetSocketState;
	}
}
