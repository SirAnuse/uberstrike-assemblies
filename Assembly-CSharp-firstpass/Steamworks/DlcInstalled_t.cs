using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A6 RID: 166
	[CallbackIdentity(1005)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct DlcInstalled_t
	{
		// Token: 0x04000347 RID: 839
		public const int k_iCallback = 1005;

		// Token: 0x04000348 RID: 840
		public AppId_t m_nAppID;
	}
}
