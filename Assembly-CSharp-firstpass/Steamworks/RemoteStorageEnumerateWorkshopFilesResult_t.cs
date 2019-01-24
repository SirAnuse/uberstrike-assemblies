using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000118 RID: 280
	[CallbackIdentity(1319)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageEnumerateWorkshopFilesResult_t
	{
		// Token: 0x040004EC RID: 1260
		public const int k_iCallback = 1319;

		// Token: 0x040004ED RID: 1261
		public EResult m_eResult;

		// Token: 0x040004EE RID: 1262
		public int m_nResultsReturned;

		// Token: 0x040004EF RID: 1263
		public int m_nTotalResultCount;

		// Token: 0x040004F0 RID: 1264
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public PublishedFileId_t[] m_rgPublishedFileId;

		// Token: 0x040004F1 RID: 1265
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public float[] m_rgScore;

		// Token: 0x040004F2 RID: 1266
		public AppId_t m_nAppId;

		// Token: 0x040004F3 RID: 1267
		public uint m_unStartIndex;
	}
}
