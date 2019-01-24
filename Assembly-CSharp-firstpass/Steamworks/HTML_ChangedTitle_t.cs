using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D2 RID: 210
	[CallbackIdentity(4508)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_ChangedTitle_t
	{
		// Token: 0x040003EA RID: 1002
		public const int k_iCallback = 4508;

		// Token: 0x040003EB RID: 1003
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003EC RID: 1004
		public string pchTitle;
	}
}
