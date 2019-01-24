using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C1 RID: 193
	[CallbackIdentity(206)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSClientAchievementStatus_t
	{
		// Token: 0x0400039D RID: 925
		public const int k_iCallback = 206;

		// Token: 0x0400039E RID: 926
		public ulong m_SteamID;

		// Token: 0x0400039F RID: 927
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_pchAchievement;

		// Token: 0x040003A0 RID: 928
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUnlocked;
	}
}
