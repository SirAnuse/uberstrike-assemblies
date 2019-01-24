using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000100 RID: 256
	[CallbackIdentity(4109)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MusicPlayerWantsShuffled_t
	{
		// Token: 0x04000485 RID: 1157
		public const int k_iCallback = 4109;

		// Token: 0x04000486 RID: 1158
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bShuffled;
	}
}
