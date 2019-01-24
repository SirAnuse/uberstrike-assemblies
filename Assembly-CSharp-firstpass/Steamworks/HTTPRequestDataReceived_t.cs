using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000E7 RID: 231
	[CallbackIdentity(2103)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct HTTPRequestDataReceived_t
	{
		// Token: 0x04000440 RID: 1088
		public const int k_iCallback = 2103;

		// Token: 0x04000441 RID: 1089
		public HTTPRequestHandle m_hRequest;

		// Token: 0x04000442 RID: 1090
		public ulong m_ulContextValue;

		// Token: 0x04000443 RID: 1091
		public uint m_cOffset;

		// Token: 0x04000444 RID: 1092
		public uint m_cBytesReceived;
	}
}
