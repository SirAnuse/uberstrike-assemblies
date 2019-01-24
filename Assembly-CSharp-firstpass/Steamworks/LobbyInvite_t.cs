using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EC RID: 236
	[CallbackIdentity(503)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyInvite_t
	{
		// Token: 0x04000453 RID: 1107
		public const int k_iCallback = 503;

		// Token: 0x04000454 RID: 1108
		public ulong m_ulSteamIDUser;

		// Token: 0x04000455 RID: 1109
		public ulong m_ulSteamIDLobby;

		// Token: 0x04000456 RID: 1110
		public ulong m_ulGameID;
	}
}
