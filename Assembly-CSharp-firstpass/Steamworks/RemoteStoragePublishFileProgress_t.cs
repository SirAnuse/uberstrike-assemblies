using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000122 RID: 290
	[CallbackIdentity(1329)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStoragePublishFileProgress_t
	{
		// Token: 0x0400051B RID: 1307
		public const int k_iCallback = 1329;

		// Token: 0x0400051C RID: 1308
		public double m_dPercentFile;

		// Token: 0x0400051D RID: 1309
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bPreview;
	}
}
