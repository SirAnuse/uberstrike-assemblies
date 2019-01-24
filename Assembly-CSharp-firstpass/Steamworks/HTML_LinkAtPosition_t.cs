using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D7 RID: 215
	[CallbackIdentity(4513)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_LinkAtPosition_t
	{
		// Token: 0x04000403 RID: 1027
		public const int k_iCallback = 4513;

		// Token: 0x04000404 RID: 1028
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000405 RID: 1029
		public uint x;

		// Token: 0x04000406 RID: 1030
		public uint y;

		// Token: 0x04000407 RID: 1031
		public string pchURL;

		// Token: 0x04000408 RID: 1032
		[MarshalAs(UnmanagedType.I1)]
		public bool bInput;

		// Token: 0x04000409 RID: 1033
		[MarshalAs(UnmanagedType.I1)]
		public bool bLiveLink;
	}
}
