using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A7 RID: 167
	[CallbackIdentity(1008)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RegisterActivationCodeResponse_t
	{
		// Token: 0x04000349 RID: 841
		public const int k_iCallback = 1008;

		// Token: 0x0400034A RID: 842
		public ERegisterActivationCodeResult m_eResult;

		// Token: 0x0400034B RID: 843
		public uint m_unPackageRegistered;
	}
}
