using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EF RID: 239
	[CallbackIdentity(506)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyChatUpdate_t
	{
		// Token: 0x04000460 RID: 1120
		public const int k_iCallback = 506;

		// Token: 0x04000461 RID: 1121
		public ulong m_ulSteamIDLobby;

		// Token: 0x04000462 RID: 1122
		public ulong m_ulSteamIDUserChanged;

		// Token: 0x04000463 RID: 1123
		public ulong m_ulSteamIDMakingChange;

		// Token: 0x04000464 RID: 1124
		public uint m_rgfChatMemberStateChange;
	}
}
