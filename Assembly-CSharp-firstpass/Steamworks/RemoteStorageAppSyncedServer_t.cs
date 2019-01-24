using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010A RID: 266
	[CallbackIdentity(1302)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageAppSyncedServer_t
	{
		// Token: 0x0400049F RID: 1183
		public const int k_iCallback = 1302;

		// Token: 0x040004A0 RID: 1184
		public AppId_t m_nAppID;

		// Token: 0x040004A1 RID: 1185
		public EResult m_eResult;

		// Token: 0x040004A2 RID: 1186
		public int m_unNumUploads;
	}
}
