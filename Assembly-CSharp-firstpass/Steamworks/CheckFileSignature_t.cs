using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000149 RID: 329
	[CallbackIdentity(705)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct CheckFileSignature_t
	{
		// Token: 0x04000594 RID: 1428
		public const int k_iCallback = 705;

		// Token: 0x04000595 RID: 1429
		public ECheckFileSignature m_eCheckFileSignature;
	}
}
