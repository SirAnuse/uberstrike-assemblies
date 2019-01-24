using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B0 RID: 176
	[CallbackIdentity(336)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FriendRichPresenceUpdate_t
	{
		// Token: 0x04000365 RID: 869
		public const int k_iCallback = 336;

		// Token: 0x04000366 RID: 870
		public CSteamID m_steamIDFriend;

		// Token: 0x04000367 RID: 871
		public AppId_t m_nAppID;
	}
}
