using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D5 RID: 213
	[CallbackIdentity(4511)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_HorizontalScroll_t
	{
		// Token: 0x040003F5 RID: 1013
		public const int k_iCallback = 4511;

		// Token: 0x040003F6 RID: 1014
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003F7 RID: 1015
		public uint unScrollMax;

		// Token: 0x040003F8 RID: 1016
		public uint unScrollCurrent;

		// Token: 0x040003F9 RID: 1017
		public float flPageScale;

		// Token: 0x040003FA RID: 1018
		[MarshalAs(UnmanagedType.I1)]
		public bool bVisible;

		// Token: 0x040003FB RID: 1019
		public uint unPageSize;
	}
}
