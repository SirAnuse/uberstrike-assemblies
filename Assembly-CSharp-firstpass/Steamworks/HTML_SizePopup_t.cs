using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DE RID: 222
	[CallbackIdentity(4520)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_SizePopup_t
	{
		// Token: 0x0400041D RID: 1053
		public const int k_iCallback = 4520;

		// Token: 0x0400041E RID: 1054
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x0400041F RID: 1055
		public uint unX;

		// Token: 0x04000420 RID: 1056
		public uint unY;

		// Token: 0x04000421 RID: 1057
		public uint unWide;

		// Token: 0x04000422 RID: 1058
		public uint unTall;
	}
}
