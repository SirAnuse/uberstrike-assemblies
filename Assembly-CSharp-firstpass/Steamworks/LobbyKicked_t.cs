using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F3 RID: 243
	[CallbackIdentity(512)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyKicked_t
	{
		// Token: 0x04000471 RID: 1137
		public const int k_iCallback = 512;

		// Token: 0x04000472 RID: 1138
		public ulong m_ulSteamIDLobby;

		// Token: 0x04000473 RID: 1139
		public ulong m_ulSteamIDAdmin;

		// Token: 0x04000474 RID: 1140
		public byte m_bKickedDueToDisconnect;
	}
}
