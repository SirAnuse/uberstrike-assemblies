using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E2 RID: 226
	[CallbackIdentity(4524)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_ShowToolTip_t
	{
		// Token: 0x04000430 RID: 1072
		public const int k_iCallback = 4524;

		// Token: 0x04000431 RID: 1073
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000432 RID: 1074
		public string pchMsg;
	}
}
