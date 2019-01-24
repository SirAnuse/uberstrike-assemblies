using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C9 RID: 201
	[CallbackIdentity(1801)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GSStatsStored_t
	{
		// Token: 0x040003C0 RID: 960
		public const int k_iCallback = 1801;

		// Token: 0x040003C1 RID: 961
		public EResult m_eResult;

		// Token: 0x040003C2 RID: 962
		public CSteamID m_steamIDUser;
	}
}
