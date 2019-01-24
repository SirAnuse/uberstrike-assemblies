using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200012E RID: 302
	[CallbackIdentity(103)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamServersDisconnected_t
	{
		// Token: 0x04000541 RID: 1345
		public const int k_iCallback = 103;

		// Token: 0x04000542 RID: 1346
		public EResult m_eResult;
	}
}
