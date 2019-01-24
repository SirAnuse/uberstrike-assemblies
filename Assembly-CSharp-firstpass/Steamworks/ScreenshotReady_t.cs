using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000124 RID: 292
	[CallbackIdentity(2301)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ScreenshotReady_t
	{
		// Token: 0x04000522 RID: 1314
		public const int k_iCallback = 2301;

		// Token: 0x04000523 RID: 1315
		public ScreenshotHandle m_hLocal;

		// Token: 0x04000524 RID: 1316
		public EResult m_eResult;
	}
}
