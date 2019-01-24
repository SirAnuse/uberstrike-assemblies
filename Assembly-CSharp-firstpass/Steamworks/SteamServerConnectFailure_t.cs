using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200012D RID: 301
	[CallbackIdentity(102)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamServerConnectFailure_t
	{
		// Token: 0x0400053F RID: 1343
		public const int k_iCallback = 102;

		// Token: 0x04000540 RID: 1344
		public EResult m_eResult;
	}
}
