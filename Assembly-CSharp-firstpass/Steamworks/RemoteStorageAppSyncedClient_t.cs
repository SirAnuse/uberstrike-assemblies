using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000109 RID: 265
	[CallbackIdentity(1301)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageAppSyncedClient_t
	{
		// Token: 0x0400049B RID: 1179
		public const int k_iCallback = 1301;

		// Token: 0x0400049C RID: 1180
		public AppId_t m_nAppID;

		// Token: 0x0400049D RID: 1181
		public EResult m_eResult;

		// Token: 0x0400049E RID: 1182
		public int m_unNumDownloads;
	}
}
