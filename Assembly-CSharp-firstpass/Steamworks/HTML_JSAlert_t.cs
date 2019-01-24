using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D8 RID: 216
	[CallbackIdentity(4514)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_JSAlert_t
	{
		// Token: 0x0400040A RID: 1034
		public const int k_iCallback = 4514;

		// Token: 0x0400040B RID: 1035
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x0400040C RID: 1036
		public string pchMessage;
	}
}
