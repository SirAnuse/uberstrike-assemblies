using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E0 RID: 224
	[CallbackIdentity(4522)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_SetCursor_t
	{
		// Token: 0x0400042A RID: 1066
		public const int k_iCallback = 4522;

		// Token: 0x0400042B RID: 1067
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x0400042C RID: 1068
		public uint eMouseCursor;
	}
}
