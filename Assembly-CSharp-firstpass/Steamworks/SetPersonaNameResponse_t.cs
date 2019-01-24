using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000BB RID: 187
	[CallbackIdentity(347)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SetPersonaNameResponse_t
	{
		// Token: 0x0400038C RID: 908
		public const int k_iCallback = 347;

		// Token: 0x0400038D RID: 909
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bSuccess;

		// Token: 0x0400038E RID: 910
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLocalSuccess;

		// Token: 0x0400038F RID: 911
		public EResult m_result;
	}
}
