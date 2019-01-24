using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CD RID: 205
	[CallbackIdentity(4503)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_StartRequest_t
	{
		// Token: 0x040003D4 RID: 980
		public const int k_iCallback = 4503;

		// Token: 0x040003D5 RID: 981
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003D6 RID: 982
		public string pchURL;

		// Token: 0x040003D7 RID: 983
		public string pchTarget;

		// Token: 0x040003D8 RID: 984
		public string pchPostData;

		// Token: 0x040003D9 RID: 985
		[MarshalAs(UnmanagedType.I1)]
		public bool bIsRedirect;
	}
}
