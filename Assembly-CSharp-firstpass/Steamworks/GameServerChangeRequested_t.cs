using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AC RID: 172
	[CallbackIdentity(332)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameServerChangeRequested_t
	{
		// Token: 0x04000356 RID: 854
		public const int k_iCallback = 332;

		// Token: 0x04000357 RID: 855
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_rgchServer;

		// Token: 0x04000358 RID: 856
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_rgchPassword;
	}
}
