using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B3 RID: 179
	[CallbackIdentity(339)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameConnectedChatJoin_t
	{
		// Token: 0x0400036F RID: 879
		public const int k_iCallback = 339;

		// Token: 0x04000370 RID: 880
		public CSteamID m_steamIDClanChat;

		// Token: 0x04000371 RID: 881
		public CSteamID m_steamIDUser;
	}
}
