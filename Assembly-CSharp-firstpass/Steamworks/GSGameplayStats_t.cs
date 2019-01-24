using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C3 RID: 195
	[CallbackIdentity(207)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSGameplayStats_t
	{
		// Token: 0x040003A3 RID: 931
		public const int k_iCallback = 207;

		// Token: 0x040003A4 RID: 932
		public EResult m_eResult;

		// Token: 0x040003A5 RID: 933
		public int m_nRank;

		// Token: 0x040003A6 RID: 934
		public uint m_unTotalConnects;

		// Token: 0x040003A7 RID: 935
		public uint m_unTotalMinutesPlayed;
	}
}
