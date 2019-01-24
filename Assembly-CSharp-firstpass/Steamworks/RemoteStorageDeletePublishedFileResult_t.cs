using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000110 RID: 272
	[CallbackIdentity(1311)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageDeletePublishedFileResult_t
	{
		// Token: 0x040004B7 RID: 1207
		public const int k_iCallback = 1311;

		// Token: 0x040004B8 RID: 1208
		public EResult m_eResult;

		// Token: 0x040004B9 RID: 1209
		public PublishedFileId_t m_nPublishedFileId;
	}
}
