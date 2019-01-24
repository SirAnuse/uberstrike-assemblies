using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000142 RID: 322
	[CallbackIdentity(1110)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GlobalAchievementPercentagesReady_t
	{
		// Token: 0x04000585 RID: 1413
		public const int k_iCallback = 1110;

		// Token: 0x04000586 RID: 1414
		public ulong m_nGameID;

		// Token: 0x04000587 RID: 1415
		public EResult m_eResult;
	}
}
