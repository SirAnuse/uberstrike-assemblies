using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B9 RID: 185
	[CallbackIdentity(345)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FriendsIsFollowing_t
	{
		// Token: 0x04000383 RID: 899
		public const int k_iCallback = 345;

		// Token: 0x04000384 RID: 900
		public EResult m_eResult;

		// Token: 0x04000385 RID: 901
		public CSteamID m_steamID;

		// Token: 0x04000386 RID: 902
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bIsFollowing;
	}
}
