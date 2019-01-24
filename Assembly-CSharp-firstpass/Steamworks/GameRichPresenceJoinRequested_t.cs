using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B1 RID: 177
	[CallbackIdentity(337)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameRichPresenceJoinRequested_t
	{
		// Token: 0x04000368 RID: 872
		public const int k_iCallback = 337;

		// Token: 0x04000369 RID: 873
		public CSteamID m_steamIDFriend;

		// Token: 0x0400036A RID: 874
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchConnect;
	}
}
