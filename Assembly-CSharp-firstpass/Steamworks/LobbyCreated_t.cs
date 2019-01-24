using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F4 RID: 244
	[CallbackIdentity(513)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyCreated_t
	{
		// Token: 0x04000475 RID: 1141
		public const int k_iCallback = 513;

		// Token: 0x04000476 RID: 1142
		public EResult m_eResult;

		// Token: 0x04000477 RID: 1143
		public ulong m_ulSteamIDLobby;
	}
}
