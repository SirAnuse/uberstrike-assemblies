using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C8 RID: 200
	[CallbackIdentity(1800)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GSStatsReceived_t
	{
		// Token: 0x040003BD RID: 957
		public const int k_iCallback = 1800;

		// Token: 0x040003BE RID: 958
		public EResult m_eResult;

		// Token: 0x040003BF RID: 959
		public CSteamID m_steamIDUser;
	}
}
