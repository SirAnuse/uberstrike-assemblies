using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D4 RID: 212
	[CallbackIdentity(4510)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_CanGoBackAndForward_t
	{
		// Token: 0x040003F1 RID: 1009
		public const int k_iCallback = 4510;

		// Token: 0x040003F2 RID: 1010
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003F3 RID: 1011
		[MarshalAs(UnmanagedType.I1)]
		public bool bCanGoBack;

		// Token: 0x040003F4 RID: 1012
		[MarshalAs(UnmanagedType.I1)]
		public bool bCanGoForward;
	}
}
