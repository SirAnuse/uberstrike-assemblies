using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E3 RID: 227
	[CallbackIdentity(4525)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_UpdateToolTip_t
	{
		// Token: 0x04000433 RID: 1075
		public const int k_iCallback = 4525;

		// Token: 0x04000434 RID: 1076
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000435 RID: 1077
		public string pchMsg;
	}
}
