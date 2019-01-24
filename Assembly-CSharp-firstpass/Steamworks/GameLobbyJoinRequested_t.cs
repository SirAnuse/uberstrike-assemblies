using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AD RID: 173
	[CallbackIdentity(333)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameLobbyJoinRequested_t
	{
		// Token: 0x04000359 RID: 857
		public const int k_iCallback = 333;

		// Token: 0x0400035A RID: 858
		public CSteamID m_steamIDLobby;

		// Token: 0x0400035B RID: 859
		public CSteamID m_steamIDFriend;
	}
}
