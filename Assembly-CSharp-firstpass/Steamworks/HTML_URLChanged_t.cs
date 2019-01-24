using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CF RID: 207
	[CallbackIdentity(4505)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_URLChanged_t
	{
		// Token: 0x040003DC RID: 988
		public const int k_iCallback = 4505;

		// Token: 0x040003DD RID: 989
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003DE RID: 990
		public string pchURL;

		// Token: 0x040003DF RID: 991
		public string pchPostData;

		// Token: 0x040003E0 RID: 992
		[MarshalAs(UnmanagedType.I1)]
		public bool bIsRedirect;

		// Token: 0x040003E1 RID: 993
		public string pchPageTitle;

		// Token: 0x040003E2 RID: 994
		[MarshalAs(UnmanagedType.I1)]
		public bool bNewNavigation;
	}
}
