using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DC RID: 220
	[CallbackIdentity(4518)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_ShowPopup_t
	{
		// Token: 0x04000419 RID: 1049
		public const int k_iCallback = 4518;

		// Token: 0x0400041A RID: 1050
		public HHTMLBrowser unBrowserHandle;
	}
}
