using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AB RID: 171
	[CallbackIdentity(331)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameOverlayActivated_t
	{
		// Token: 0x04000354 RID: 852
		public const int k_iCallback = 331;

		// Token: 0x04000355 RID: 853
		public byte m_bActive;
	}
}
