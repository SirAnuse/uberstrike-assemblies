using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A8 RID: 168
	[CallbackIdentity(1013)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct AppProofOfPurchaseKeyResponse_t
	{
		// Token: 0x0400034C RID: 844
		public const int k_iCallback = 1013;

		// Token: 0x0400034D RID: 845
		public EResult m_eResult;

		// Token: 0x0400034E RID: 846
		public uint m_nAppID;

		// Token: 0x0400034F RID: 847
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string m_rgchKey;
	}
}
