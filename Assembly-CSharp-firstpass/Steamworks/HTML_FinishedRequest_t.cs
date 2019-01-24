using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D0 RID: 208
	[CallbackIdentity(4506)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_FinishedRequest_t
	{
		// Token: 0x040003E3 RID: 995
		public const int k_iCallback = 4506;

		// Token: 0x040003E4 RID: 996
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003E5 RID: 997
		public string pchURL;

		// Token: 0x040003E6 RID: 998
		public string pchPageTitle;
	}
}
