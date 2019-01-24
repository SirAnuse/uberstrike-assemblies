using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010C RID: 268
	[CallbackIdentity(1305)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageAppSyncStatusCheck_t
	{
		// Token: 0x040004A9 RID: 1193
		public const int k_iCallback = 1305;

		// Token: 0x040004AA RID: 1194
		public AppId_t m_nAppID;

		// Token: 0x040004AB RID: 1195
		public EResult m_eResult;
	}
}
