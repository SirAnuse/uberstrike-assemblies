using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E4 RID: 228
	[CallbackIdentity(4526)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_HideToolTip_t
	{
		// Token: 0x04000436 RID: 1078
		public const int k_iCallback = 4526;

		// Token: 0x04000437 RID: 1079
		public HHTMLBrowser unBrowserHandle;
	}
}
