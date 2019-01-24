using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200013B RID: 315
	[CallbackIdentity(1103)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserAchievementStored_t
	{
		// Token: 0x04000567 RID: 1383
		public const int k_iCallback = 1103;

		// Token: 0x04000568 RID: 1384
		public ulong m_nGameID;

		// Token: 0x04000569 RID: 1385
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bGroupAchievement;

		// Token: 0x0400056A RID: 1386
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_rgchAchievementName;

		// Token: 0x0400056B RID: 1387
		public uint m_nCurProgress;

		// Token: 0x0400056C RID: 1388
		public uint m_nMaxProgress;
	}
}
