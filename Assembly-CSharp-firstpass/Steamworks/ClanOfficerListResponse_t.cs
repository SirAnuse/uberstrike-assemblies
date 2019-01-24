using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AF RID: 175
	[CallbackIdentity(335)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ClanOfficerListResponse_t
	{
		// Token: 0x04000361 RID: 865
		public const int k_iCallback = 335;

		// Token: 0x04000362 RID: 866
		public CSteamID m_steamIDClan;

		// Token: 0x04000363 RID: 867
		public int m_cOfficers;

		// Token: 0x04000364 RID: 868
		public byte m_bSuccess;
	}
}
