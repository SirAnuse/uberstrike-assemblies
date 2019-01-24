using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000193 RID: 403
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SteamUGCDetails_t
	{
		// Token: 0x040008D7 RID: 2263
		public PublishedFileId_t m_nPublishedFileId;

		// Token: 0x040008D8 RID: 2264
		public EResult m_eResult;

		// Token: 0x040008D9 RID: 2265
		public EWorkshopFileType m_eFileType;

		// Token: 0x040008DA RID: 2266
		public AppId_t m_nCreatorAppID;

		// Token: 0x040008DB RID: 2267
		public AppId_t m_nConsumerAppID;

		// Token: 0x040008DC RID: 2268
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
		public string m_rgchTitle;

		// Token: 0x040008DD RID: 2269
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8000)]
		public string m_rgchDescription;

		// Token: 0x040008DE RID: 2270
		public ulong m_ulSteamIDOwner;

		// Token: 0x040008DF RID: 2271
		public uint m_rtimeCreated;

		// Token: 0x040008E0 RID: 2272
		public uint m_rtimeUpdated;

		// Token: 0x040008E1 RID: 2273
		public uint m_rtimeAddedToUserList;

		// Token: 0x040008E2 RID: 2274
		public ERemoteStoragePublishedFileVisibility m_eVisibility;

		// Token: 0x040008E3 RID: 2275
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;

		// Token: 0x040008E4 RID: 2276
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAcceptedForUse;

		// Token: 0x040008E5 RID: 2277
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bTagsTruncated;

		// Token: 0x040008E6 RID: 2278
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)]
		public string m_rgchTags;

		// Token: 0x040008E7 RID: 2279
		public UGCHandle_t m_hFile;

		// Token: 0x040008E8 RID: 2280
		public UGCHandle_t m_hPreviewFile;

		// Token: 0x040008E9 RID: 2281
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_pchFileName;

		// Token: 0x040008EA RID: 2282
		public int m_nFileSize;

		// Token: 0x040008EB RID: 2283
		public int m_nPreviewFileSize;

		// Token: 0x040008EC RID: 2284
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchURL;

		// Token: 0x040008ED RID: 2285
		public uint m_unVotesUp;

		// Token: 0x040008EE RID: 2286
		public uint m_unVotesDown;

		// Token: 0x040008EF RID: 2287
		public float m_flScore;

		// Token: 0x040008F0 RID: 2288
		public uint m_unNumChildren;
	}
}
