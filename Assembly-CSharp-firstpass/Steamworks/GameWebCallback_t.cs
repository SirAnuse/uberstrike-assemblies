using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000137 RID: 311
	[CallbackIdentity(164)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GameWebCallback_t
	{
		// Token: 0x0400055C RID: 1372
		public const int k_iCallback = 164;

		// Token: 0x0400055D RID: 1373
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_szURL;
	}
}
