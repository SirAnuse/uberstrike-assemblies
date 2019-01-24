using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C4 RID: 196
	[CallbackIdentity(208)]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct GSClientGroupStatus_t
	{
		// Token: 0x040003A8 RID: 936
		public const int k_iCallback = 208;

		// Token: 0x040003A9 RID: 937
		public CSteamID m_SteamIDUser;

		// Token: 0x040003AA RID: 938
		public CSteamID m_SteamIDGroup;

		// Token: 0x040003AB RID: 939
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bMember;

		// Token: 0x040003AC RID: 940
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bOfficer;
	}
}
