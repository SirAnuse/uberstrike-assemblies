using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DF RID: 223
	[CallbackIdentity(4521)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_NewWindow_t
	{
		// Token: 0x04000423 RID: 1059
		public const int k_iCallback = 4521;

		// Token: 0x04000424 RID: 1060
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000425 RID: 1061
		public string pchURL;

		// Token: 0x04000426 RID: 1062
		public uint unX;

		// Token: 0x04000427 RID: 1063
		public uint unY;

		// Token: 0x04000428 RID: 1064
		public uint unWide;

		// Token: 0x04000429 RID: 1065
		public uint unTall;
	}
}
