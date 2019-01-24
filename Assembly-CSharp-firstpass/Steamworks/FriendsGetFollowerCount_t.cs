using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B8 RID: 184
	[CallbackIdentity(344)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FriendsGetFollowerCount_t
	{
		// Token: 0x0400037F RID: 895
		public const int k_iCallback = 344;

		// Token: 0x04000380 RID: 896
		public EResult m_eResult;

		// Token: 0x04000381 RID: 897
		public CSteamID m_steamID;

		// Token: 0x04000382 RID: 898
		public int m_nCount;
	}
}
