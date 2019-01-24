using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000EB RID: 235
	[CallbackIdentity(502)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct FavoritesListChanged_t
	{
		// Token: 0x0400044B RID: 1099
		public const int k_iCallback = 502;

		// Token: 0x0400044C RID: 1100
		public uint m_nIP;

		// Token: 0x0400044D RID: 1101
		public uint m_nQueryPort;

		// Token: 0x0400044E RID: 1102
		public uint m_nConnPort;

		// Token: 0x0400044F RID: 1103
		public uint m_nAppID;

		// Token: 0x04000450 RID: 1104
		public uint m_nFlags;

		// Token: 0x04000451 RID: 1105
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAdd;

		// Token: 0x04000452 RID: 1106
		public AccountID_t m_unAccountId;
	}
}
