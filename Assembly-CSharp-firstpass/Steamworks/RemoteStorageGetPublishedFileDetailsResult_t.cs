using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000117 RID: 279
	[CallbackIdentity(1318)]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct RemoteStorageGetPublishedFileDetailsResult_t
	{
		// Token: 0x040004D6 RID: 1238
		public const int k_iCallback = 1318;

		// Token: 0x040004D7 RID: 1239
		public EResult m_eResult;

		// Token: 0x040004D8 RID: 1240
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040004D9 RID: 1241
		public AppId_t m_nCreatorAppID;

		// Token: 0x040004DA RID: 1242
		public AppId_t m_nConsumerAppID;

		// Token: 0x040004DB RID: 1243
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
		public string m_rgchTitle;

		// Token: 0x040004DC RID: 1244
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8000)]
		public string m_rgchDescription;

		// Token: 0x040004DD RID: 1245
		public UGCHandle_t m_hFile;

		// Token: 0x040004DE RID: 1246
		public UGCHandle_t m_hPreviewFile;

		// Token: 0x040004DF RID: 1247
		public ulong m_ulSteamIDOwner;

		// Token: 0x040004E0 RID: 1248
		public uint m_rtimeCreated;

		// Token: 0x040004E1 RID: 1249
		public uint m_rtimeUpdated;

		// Token: 0x040004E2 RID: 1250
		public ERemoteStoragePublishedFileVisibility m_eVisibility;

		// Token: 0x040004E3 RID: 1251
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;

		// Token: 0x040004E4 RID: 1252
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)]
		public string m_rgchTags;

		// Token: 0x040004E5 RID: 1253
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bTagsTruncated;

		// Token: 0x040004E6 RID: 1254
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_pchFileName;

		// Token: 0x040004E7 RID: 1255
		public int m_nFileSize;

		// Token: 0x040004E8 RID: 1256
		public int m_nPreviewFileSize;

		// Token: 0x040004E9 RID: 1257
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchURL;

		// Token: 0x040004EA RID: 1258
		public EWorkshopFileType m_eFileType;

		// Token: 0x040004EB RID: 1259
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAcceptedForUse;
	}
}
