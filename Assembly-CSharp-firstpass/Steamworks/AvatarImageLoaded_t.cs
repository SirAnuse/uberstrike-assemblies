using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AE RID: 174
	[CallbackIdentity(334)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct AvatarImageLoaded_t
	{
		// Token: 0x0400035C RID: 860
		public const int k_iCallback = 334;

		// Token: 0x0400035D RID: 861
		public CSteamID m_steamID;

		// Token: 0x0400035E RID: 862
		public int m_iImage;

		// Token: 0x0400035F RID: 863
		public int m_iWide;

		// Token: 0x04000360 RID: 864
		public int m_iTall;
	}
}
