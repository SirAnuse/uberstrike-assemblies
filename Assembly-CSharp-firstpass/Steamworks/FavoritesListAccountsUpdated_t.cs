using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000F5 RID: 245
	[CallbackIdentity(516)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct FavoritesListAccountsUpdated_t
	{
		// Token: 0x04000478 RID: 1144
		public const int k_iCallback = 516;

		// Token: 0x04000479 RID: 1145
		public EResult m_eResult;
	}
}
