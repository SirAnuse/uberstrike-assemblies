using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200012B RID: 299
	[CallbackIdentity(2501)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamUnifiedMessagesSendMethodResult_t
	{
		// Token: 0x04000539 RID: 1337
		public const int k_iCallback = 2501;

		// Token: 0x0400053A RID: 1338
		public ClientUnifiedMessageHandle m_hHandle;

		// Token: 0x0400053B RID: 1339
		public ulong m_unContext;

		// Token: 0x0400053C RID: 1340
		public EResult m_eResult;

		// Token: 0x0400053D RID: 1341
		public uint m_unResponseSize;
	}
}
