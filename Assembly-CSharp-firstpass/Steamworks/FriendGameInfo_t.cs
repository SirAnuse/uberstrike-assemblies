using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200018E RID: 398
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct FriendGameInfo_t
	{
		// Token: 0x040008C2 RID: 2242
		public CGameID m_gameID;

		// Token: 0x040008C3 RID: 2243
		public uint m_unGameIP;

		// Token: 0x040008C4 RID: 2244
		public ushort m_usGamePort;

		// Token: 0x040008C5 RID: 2245
		public ushort m_usQueryPort;

		// Token: 0x040008C6 RID: 2246
		public CSteamID m_steamIDLobby;
	}
}
