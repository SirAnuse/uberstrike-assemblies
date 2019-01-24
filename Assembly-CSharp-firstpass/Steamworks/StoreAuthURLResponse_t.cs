using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000138 RID: 312
	[CallbackIdentity(165)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct StoreAuthURLResponse_t
	{
		// Token: 0x0400055E RID: 1374
		public const int k_iCallback = 165;

		// Token: 0x0400055F RID: 1375
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
		public string m_szURL;
	}
}
