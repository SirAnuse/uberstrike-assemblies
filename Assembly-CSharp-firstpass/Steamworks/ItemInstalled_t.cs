using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200012A RID: 298
	[CallbackIdentity(3405)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct ItemInstalled_t
	{
		// Token: 0x04000536 RID: 1334
		public const int k_iCallback = 3405;

		// Token: 0x04000537 RID: 1335
		public AppId_t m_unAppID;

		// Token: 0x04000538 RID: 1336
		public PublishedFileId_t m_nPublishedFileId;
	}
}
