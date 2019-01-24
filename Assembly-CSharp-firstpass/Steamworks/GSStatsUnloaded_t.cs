using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CA RID: 202
	[CallbackIdentity(1108)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSStatsUnloaded_t
	{
		// Token: 0x040003C3 RID: 963
		public const int k_iCallback = 1108;

		// Token: 0x040003C4 RID: 964
		public CSteamID m_steamIDUser;
	}
}
