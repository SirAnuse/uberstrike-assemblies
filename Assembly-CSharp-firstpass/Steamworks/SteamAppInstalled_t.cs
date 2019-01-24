using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A4 RID: 164
	[CallbackIdentity(3901)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamAppInstalled_t
	{
		// Token: 0x04000343 RID: 835
		public const int k_iCallback = 3901;

		// Token: 0x04000344 RID: 836
		public AppId_t m_nAppID;
	}
}
