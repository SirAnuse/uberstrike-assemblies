using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200013A RID: 314
	[CallbackIdentity(1102)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct UserStatsStored_t
	{
		// Token: 0x04000564 RID: 1380
		public const int k_iCallback = 1102;

		// Token: 0x04000565 RID: 1381
		public ulong m_nGameID;

		// Token: 0x04000566 RID: 1382
		public EResult m_eResult;
	}
}
