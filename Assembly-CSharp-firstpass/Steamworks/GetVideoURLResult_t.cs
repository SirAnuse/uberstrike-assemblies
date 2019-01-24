using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200014B RID: 331
	[CallbackIdentity(4611)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct GetVideoURLResult_t
	{
		// Token: 0x04000599 RID: 1433
		public const int k_iCallback = 4611;

		// Token: 0x0400059A RID: 1434
		public EResult m_eResult;

		// Token: 0x0400059B RID: 1435
		public AppId_t m_unVideoAppID;

		// Token: 0x0400059C RID: 1436
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchURL;
	}
}
