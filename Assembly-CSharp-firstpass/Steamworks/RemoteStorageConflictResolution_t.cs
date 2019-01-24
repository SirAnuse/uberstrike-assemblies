using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010D RID: 269
	[CallbackIdentity(1306)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageConflictResolution_t
	{
		// Token: 0x040004AC RID: 1196
		public const int k_iCallback = 1306;

		// Token: 0x040004AD RID: 1197
		public AppId_t m_nAppID;

		// Token: 0x040004AE RID: 1198
		public EResult m_eResult;
	}
}
