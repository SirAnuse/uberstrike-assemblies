using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000073 RID: 115
	[StructLayout(LayoutKind.Sequential)]
	public class CCallbackBase
	{
		// Token: 0x04000302 RID: 770
		public const byte k_ECallbackFlagsRegistered = 1;

		// Token: 0x04000303 RID: 771
		public const byte k_ECallbackFlagsGameServer = 2;

		// Token: 0x04000304 RID: 772
		public IntPtr m_vfptr;

		// Token: 0x04000305 RID: 773
		public byte m_nCallbackFlags;

		// Token: 0x04000306 RID: 774
		public int m_iCallback;
	}
}
