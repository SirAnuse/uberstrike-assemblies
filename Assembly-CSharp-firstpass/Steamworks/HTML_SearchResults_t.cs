using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000D3 RID: 211
	[CallbackIdentity(4509)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTML_SearchResults_t
	{
		// Token: 0x040003ED RID: 1005
		public const int k_iCallback = 4509;

		// Token: 0x040003EE RID: 1006
		public HHTMLBrowser unBrowserHandle;

		// Token: 0x040003EF RID: 1007
		public uint unResults;

		// Token: 0x040003F0 RID: 1008
		public uint unCurrentMatch;
	}
}
