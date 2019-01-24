using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000139 RID: 313
	[CallbackIdentity(1101)]
	[StructLayout(LayoutKind.Explicit, Pack = 8)]
	public struct UserStatsReceived_t
	{
		// Token: 0x04000560 RID: 1376
		public const int k_iCallback = 1101;

		// Token: 0x04000561 RID: 1377
		[FieldOffset(0)]
		public ulong m_nGameID;

		// Token: 0x04000562 RID: 1378
		[FieldOffset(8)]
		public EResult m_eResult;

		// Token: 0x04000563 RID: 1379
		[FieldOffset(12)]
		public CSteamID m_steamIDUser;
	}
}
