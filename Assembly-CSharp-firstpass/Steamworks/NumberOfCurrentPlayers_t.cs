using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200013F RID: 319
	[CallbackIdentity(1107)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct NumberOfCurrentPlayers_t
	{
		// Token: 0x0400057B RID: 1403
		public const int k_iCallback = 1107;

		// Token: 0x0400057C RID: 1404
		public byte m_bSuccess;

		// Token: 0x0400057D RID: 1405
		public int m_cPlayers;
	}
}
