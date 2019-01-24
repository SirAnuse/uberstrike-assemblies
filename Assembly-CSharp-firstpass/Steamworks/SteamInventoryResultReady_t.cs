using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E8 RID: 232
	[CallbackIdentity(4700)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamInventoryResultReady_t
	{
		// Token: 0x04000445 RID: 1093
		public const int k_iCallback = 4700;

		// Token: 0x04000446 RID: 1094
		public SteamInventoryResult_t m_handle;

		// Token: 0x04000447 RID: 1095
		public EResult m_result;
	}
}
