using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000CC RID: 204
	[CallbackIdentity(4502)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_NeedsPaint_t
	{
		// Token: 0x040003C7 RID: 967
		public const int k_iCallback = 4502;

		// Token: 0x040003C8 RID: 968
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003C9 RID: 969
		public IntPtr pBGRA;

		// Token: 0x040003CA RID: 970
		public uint unWide;

		// Token: 0x040003CB RID: 971
		public uint unTall;

		// Token: 0x040003CC RID: 972
		public uint unUpdateX;

		// Token: 0x040003CD RID: 973
		public uint unUpdateY;

		// Token: 0x040003CE RID: 974
		public uint unUpdateWide;

		// Token: 0x040003CF RID: 975
		public uint unUpdateTall;

		// Token: 0x040003D0 RID: 976
		public uint unScrollX;

		// Token: 0x040003D1 RID: 977
		public uint unScrollY;

		// Token: 0x040003D2 RID: 978
		public float flPageScale;

		// Token: 0x040003D3 RID: 979
		public uint unPageSerial;
	}
}
