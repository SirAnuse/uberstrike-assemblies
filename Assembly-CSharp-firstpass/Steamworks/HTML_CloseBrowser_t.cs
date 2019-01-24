using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CE RID: 206
	[CallbackIdentity(4504)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_CloseBrowser_t
	{
		// Token: 0x040003DA RID: 986
		public const int k_iCallback = 4504;

		// Token: 0x040003DB RID: 987
		public HHTMLBrowser unBrowserHandle;
	}
}
