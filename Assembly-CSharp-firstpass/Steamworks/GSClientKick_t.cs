using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C0 RID: 192
	[CallbackIdentity(203)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GSClientKick_t
	{
		// Token: 0x0400039A RID: 922
		public const int k_iCallback = 203;

		// Token: 0x0400039B RID: 923
		public CSteamID m_SteamID;

		// Token: 0x0400039C RID: 924
		public EDenyReason m_eDenyReason;
	}
}
