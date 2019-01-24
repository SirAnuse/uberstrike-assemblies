using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F1 RID: 241
	[CallbackIdentity(509)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyGameCreated_t
	{
		// Token: 0x0400046A RID: 1130
		public const int k_iCallback = 509;

		// Token: 0x0400046B RID: 1131
		public ulong m_ulSteamIDLobby;

		// Token: 0x0400046C RID: 1132
		public ulong m_ulSteamIDGameServer;

		// Token: 0x0400046D RID: 1133
		public uint m_unIP;

		// Token: 0x0400046E RID: 1134
		public ushort m_usPort;
	}
}
