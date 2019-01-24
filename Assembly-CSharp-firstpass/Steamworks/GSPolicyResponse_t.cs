using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C2 RID: 194
	[CallbackIdentity(115)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSPolicyResponse_t
	{
		// Token: 0x040003A1 RID: 929
		public const int k_iCallback = 115;

		// Token: 0x040003A2 RID: 930
		public byte m_bSecure;
	}
}
