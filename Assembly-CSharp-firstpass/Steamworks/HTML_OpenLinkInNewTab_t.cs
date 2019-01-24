using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D1 RID: 209
	[CallbackIdentity(4507)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_OpenLinkInNewTab_t
	{
		// Token: 0x040003E7 RID: 999
		public const int k_iCallback = 4507;

		// Token: 0x040003E8 RID: 1000
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003E9 RID: 1001
		public string pchURL;
	}
}
