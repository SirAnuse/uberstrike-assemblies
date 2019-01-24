using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CB RID: 203
	[CallbackIdentity(4501)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_BrowserReady_t
	{
		// Token: 0x040003C5 RID: 965
		public const int k_iCallback = 4501;

		// Token: 0x040003C6 RID: 966
		public HHTMLBrowser unBrowserHandle;
	}
}
