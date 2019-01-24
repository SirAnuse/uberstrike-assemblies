using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000BF RID: 191
	[CallbackIdentity(202)]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GSClientDeny_t
	{
		// Token: 0x04000396 RID: 918
		public const int k_iCallback = 202;

		// Token: 0x04000397 RID: 919
		public CSteamID m_SteamID;

		// Token: 0x04000398 RID: 920
		public EDenyReason m_eDenyReason;

		// Token: 0x04000399 RID: 921
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string m_rgchOptionalText;
	}
}
