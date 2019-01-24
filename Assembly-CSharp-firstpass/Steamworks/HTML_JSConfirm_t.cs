using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D9 RID: 217
	[CallbackIdentity(4515)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_JSConfirm_t
	{
		// Token: 0x0400040D RID: 1037
		public const int k_iCallback = 4515;

		// Token: 0x0400040E RID: 1038
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x0400040F RID: 1039
		public string pchMessage;
	}
}
