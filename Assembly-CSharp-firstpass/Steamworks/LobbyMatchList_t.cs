using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F2 RID: 242
	[CallbackIdentity(510)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct LobbyMatchList_t
	{
		// Token: 0x0400046F RID: 1135
		public const int k_iCallback = 510;

		// Token: 0x04000470 RID: 1136
		public uint m_nLobbiesMatching;
	}
}
