using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000ED RID: 237
	[CallbackIdentity(504)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyEnter_t
	{
		// Token: 0x04000457 RID: 1111
		public const int k_iCallback = 504;

		// Token: 0x04000458 RID: 1112
		public ulong m_ulSteamIDLobby;

		// Token: 0x04000459 RID: 1113
		public uint m_rgfChatPermissions;

		// Token: 0x0400045A RID: 1114
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLocked;

		// Token: 0x0400045B RID: 1115
		public uint m_EChatRoomEnterResponse;
	}
}
