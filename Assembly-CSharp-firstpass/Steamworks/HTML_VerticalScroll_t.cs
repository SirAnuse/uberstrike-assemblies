using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D6 RID: 214
	[CallbackIdentity(4512)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_VerticalScroll_t
	{
		// Token: 0x040003FC RID: 1020
		public const int k_iCallback = 4512;

		// Token: 0x040003FD RID: 1021
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003FE RID: 1022
		public uint unScrollMax;

		// Token: 0x040003FF RID: 1023
		public uint unScrollCurrent;

		// Token: 0x04000400 RID: 1024
		public float flPageScale;

		// Token: 0x04000401 RID: 1025
		[MarshalAs(UnmanagedType.I1)]
		public bool bVisible;

		// Token: 0x04000402 RID: 1026
		public uint unPageSize;
	}
}
