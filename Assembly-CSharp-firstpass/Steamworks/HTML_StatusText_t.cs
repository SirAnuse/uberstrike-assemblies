using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E1 RID: 225
	[CallbackIdentity(4523)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_StatusText_t
	{
		// Token: 0x0400042D RID: 1069
		public const int k_iCallback = 4523;

		// Token: 0x0400042E RID: 1070
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x0400042F RID: 1071
		public string pchMsg;
	}
}
