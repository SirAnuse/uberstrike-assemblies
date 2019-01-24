using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EE RID: 238
	[CallbackIdentity(505)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyDataUpdate_t
	{
		// Token: 0x0400045C RID: 1116
		public const int k_iCallback = 505;

		// Token: 0x0400045D RID: 1117
		public ulong m_ulSteamIDLobby;

		// Token: 0x0400045E RID: 1118
		public ulong m_ulSteamIDMember;

		// Token: 0x0400045F RID: 1119
		public byte m_bSuccess;
	}
}
