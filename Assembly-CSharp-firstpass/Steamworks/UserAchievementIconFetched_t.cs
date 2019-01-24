using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000141 RID: 321
	[CallbackIdentity(1109)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserAchievementIconFetched_t
	{
		// Token: 0x04000580 RID: 1408
		public const int k_iCallback = 1109;

		// Token: 0x04000581 RID: 1409
		public CGameID m_nGameID;

		// Token: 0x04000582 RID: 1410
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_rgchAchievementName;

		// Token: 0x04000583 RID: 1411
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAchieved;

		// Token: 0x04000584 RID: 1412
		public int m_nIconHandle;
	}
}
