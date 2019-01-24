using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B2 RID: 178
	[CallbackIdentity(338)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GameConnectedClanChatMsg_t
	{
		// Token: 0x0400036B RID: 875
		public const int k_iCallback = 338;

		// Token: 0x0400036C RID: 876
		public CSteamID m_steamIDClanChat;

		// Token: 0x0400036D RID: 877
		public CSteamID m_steamIDUser;

		// Token: 0x0400036E RID: 878
		public int m_iMessageID;
	}
}
