using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A5 RID: 165
	[CallbackIdentity(3902)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamAppUninstalled_t
	{
		// Token: 0x04000345 RID: 837
		public const int k_iCallback = 3902;

		// Token: 0x04000346 RID: 838
		public AppId_t m_nAppID;
	}
}
