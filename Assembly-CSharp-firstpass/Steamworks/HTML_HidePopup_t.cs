using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DD RID: 221
	[CallbackIdentity(4519)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_HidePopup_t
	{
		// Token: 0x0400041B RID: 1051
		public const int k_iCallback = 4519;

		// Token: 0x0400041C RID: 1052
		public HHTMLBrowser unBrowserHandle;
	}
}
