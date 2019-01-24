using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000DB RID: 219
	[CallbackIdentity(4517)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_ComboNeedsPaint_t
	{
		// Token: 0x04000414 RID: 1044
		public const int k_iCallback = 4517;

		// Token: 0x04000415 RID: 1045
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x04000416 RID: 1046
		public IntPtr pBGRA;

		// Token: 0x04000417 RID: 1047
		public uint unWide;

		// Token: 0x04000418 RID: 1048
		public uint unTall;
	}
}
