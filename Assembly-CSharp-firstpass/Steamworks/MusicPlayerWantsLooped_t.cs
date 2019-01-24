using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000101 RID: 257
	[CallbackIdentity(4110)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerWantsLooped_t
	{
		// Token: 0x04000487 RID: 1159
		public const int k_iCallback = 4110;

		// Token: 0x04000488 RID: 1160
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bLooped;
	}
}
