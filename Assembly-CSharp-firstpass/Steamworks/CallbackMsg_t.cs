using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000194 RID: 404
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct CallbackMsg_t
	{
		// Token: 0x040008F1 RID: 2289
		public int m_hSteamUser;

		// Token: 0x040008F2 RID: 2290
		public int m_iCallback;

		// Token: 0x040008F3 RID: 2291
		public IntPtr m_pubParam;

		// Token: 0x040008F4 RID: 2292
		public int m_cubParam;
	}
}
