using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000BA RID: 186
	[CallbackIdentity(346)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct FriendsEnumerateFollowingList_t
	{
		// Token: 0x04000387 RID: 903
		public const int k_iCallback = 346;

		// Token: 0x04000388 RID: 904
		public EResult m_eResult;

		// Token: 0x04000389 RID: 905
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public CSteamID[] m_rgSteamID;

		// Token: 0x0400038A RID: 906
		public int m_nResultsReturned;

		// Token: 0x0400038B RID: 907
		public int m_nTotalResultCount;
	}
}
