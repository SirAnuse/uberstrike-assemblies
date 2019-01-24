using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AA RID: 170
	[CallbackIdentity(304)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct PersonaStateChange_t
	{
		// Token: 0x04000351 RID: 849
		public const int k_iCallback = 304;

		// Token: 0x04000352 RID: 850
		public ulong m_ulSteamID;

		// Token: 0x04000353 RID: 851
		public EPersonaChange m_nChangeFlags;
	}
}
