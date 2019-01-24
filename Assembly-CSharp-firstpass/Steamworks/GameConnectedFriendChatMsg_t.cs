using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B7 RID: 183
	[CallbackIdentity(343)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GameConnectedFriendChatMsg_t
	{
		// Token: 0x0400037C RID: 892
		public const int k_iCallback = 343;

		// Token: 0x0400037D RID: 893
		public CSteamID m_steamIDUser;

		// Token: 0x0400037E RID: 894
		public int m_iMessageID;
	}
}
