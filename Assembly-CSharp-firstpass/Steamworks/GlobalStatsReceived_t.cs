using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000144 RID: 324
	[CallbackIdentity(1112)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GlobalStatsReceived_t
	{
		// Token: 0x0400058B RID: 1419
		public const int k_iCallback = 1112;

		// Token: 0x0400058C RID: 1420
		public ulong m_nGameID;

		// Token: 0x0400058D RID: 1421
		public EResult m_eResult;
	}
}
