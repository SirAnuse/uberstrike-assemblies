using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000BC RID: 188
	[CallbackIdentity(1701)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GCMessageAvailable_t
	{
		// Token: 0x04000390 RID: 912
		public const int k_iCallback = 1701;

		// Token: 0x04000391 RID: 913
		public uint m_nMessageSize;
	}
}
