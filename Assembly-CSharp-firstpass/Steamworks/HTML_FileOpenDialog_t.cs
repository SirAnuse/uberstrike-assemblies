using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DA RID: 218
	[CallbackIdentity(4516)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_FileOpenDialog_t
	{
		// Token: 0x04000410 RID: 1040
		public const int k_iCallback = 4516;

		// Token: 0x04000411 RID: 1041
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000412 RID: 1042
		public string pchTitle;

		// Token: 0x04000413 RID: 1043
		public string pchInitialFile;
	}
}
