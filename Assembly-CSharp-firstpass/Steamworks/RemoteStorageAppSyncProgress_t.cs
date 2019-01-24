using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200010B RID: 267
	[CallbackIdentity(1303)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageAppSyncProgress_t
	{
		// Token: 0x040004A3 RID: 1187
		public const int k_iCallback = 1303;

		// Token: 0x040004A4 RID: 1188
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_rgchCurrentFile;

		// Token: 0x040004A5 RID: 1189
		public AppId_t m_nAppID;

		// Token: 0x040004A6 RID: 1190
		public uint m_uBytesTransferredThisChunk;

		// Token: 0x040004A7 RID: 1191
		public double m_dAppPercentComplete;

		// Token: 0x040004A8 RID: 1192
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUploading;
	}
}
