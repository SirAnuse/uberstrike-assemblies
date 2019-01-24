using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000192 RID: 402
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamParamStringArray_t
	{
		// Token: 0x040008D5 RID: 2261
		public IntPtr m_ppStrings;

		// Token: 0x040008D6 RID: 2262
		public int m_nNumStrings;
	}
}
