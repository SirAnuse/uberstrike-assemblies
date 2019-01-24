using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000116 RID: 278
	[CallbackIdentity(1317)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageDownloadUGCResult_t
	{
		// Token: 0x040004CF RID: 1231
		public const int k_iCallback = 1317;

		// Token: 0x040004D0 RID: 1232
		public EResult m_eResult;

		// Token: 0x040004D1 RID: 1233
		public UGCHandle_t m_hFile;

		// Token: 0x040004D2 RID: 1234
		public AppId_t m_nAppID;

		// Token: 0x040004D3 RID: 1235
		public int m_nSizeInBytes;

		// Token: 0x040004D4 RID: 1236
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_pchFileName;

		// Token: 0x040004D5 RID: 1237
		public ulong m_ulSteamIDOwner;
	}
}
