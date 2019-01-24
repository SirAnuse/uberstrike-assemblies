using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C6 RID: 198
	[CallbackIdentity(210)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct AssociateWithClanResult_t
	{
		// Token: 0x040003B5 RID: 949
		public const int k_iCallback = 210;

		// Token: 0x040003B6 RID: 950
		public EResult m_eResult;
	}
}
