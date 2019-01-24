using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B4 RID: 180
	[CallbackIdentity(340)]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GameConnectedChatLeave_t
	{
		// Token: 0x04000372 RID: 882
		public const int k_iCallback = 340;

		// Token: 0x04000373 RID: 883
		public CSteamID m_steamIDClanChat;

		// Token: 0x04000374 RID: 884
		public CSteamID m_steamIDUser;

		// Token: 0x04000375 RID: 885
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bKicked;

		// Token: 0x04000376 RID: 886
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bDropped;
	}
}
