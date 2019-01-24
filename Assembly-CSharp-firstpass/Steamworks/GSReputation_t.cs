using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000C5 RID: 197
	[CallbackIdentity(209)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GSReputation_t
	{
		// Token: 0x040003AD RID: 941
		public const int k_iCallback = 209;

		// Token: 0x040003AE RID: 942
		public EResult m_eResult;

		// Token: 0x040003AF RID: 943
		public uint m_unReputationScore;

		// Token: 0x040003B0 RID: 944
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;

		// Token: 0x040003B1 RID: 945
		public uint m_unBannedIP;

		// Token: 0x040003B2 RID: 946
		public ushort m_usBannedPort;

		// Token: 0x040003B3 RID: 947
		public ulong m_ulBannedGameID;

		// Token: 0x040003B4 RID: 948
		public uint m_unBanExpires;
	}
}
