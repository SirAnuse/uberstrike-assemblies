using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F0 RID: 240
	[CallbackIdentity(507)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyChatMsg_t
	{
		// Token: 0x04000465 RID: 1125
		public const int k_iCallback = 507;

		// Token: 0x04000466 RID: 1126
		public ulong m_ulSteamIDLobby;

		// Token: 0x04000467 RID: 1127
		public ulong m_ulSteamIDUser;

		// Token: 0x04000468 RID: 1128
		public byte m_eChatEntryType;

		// Token: 0x04000469 RID: 1129
		public uint m_iChatID;
	}
}
