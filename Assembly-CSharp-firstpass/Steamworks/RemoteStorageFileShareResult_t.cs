using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010E RID: 270
	[CallbackIdentity(1307)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageFileShareResult_t
	{
		// Token: 0x040004AF RID: 1199
		public const int k_iCallback = 1307;

		// Token: 0x040004B0 RID: 1200
		public EResult m_eResult;

		// Token: 0x040004B1 RID: 1201
		public UGCHandle_t m_hFile;

		// Token: 0x040004B2 RID: 1202
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_rgchFilename;
	}
}
