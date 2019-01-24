using System;
using System.Collections.Generic;

namespace Steamworks
{
	// Token: 0x020001AB RID: 427
	public static class SteamRemoteStorage
	{
		// Token: 0x06000910 RID: 2320 RVA: 0x00005DE3 File Offset: 0x00003FE3
		public static bool FileWrite(string pchFile, byte[] pvData, int cubData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileWrite(pchFile, pvData, cubData);
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x00005DF2 File Offset: 0x00003FF2
		public static int FileRead(string pchFile, byte[] pvData, int cubDataToRead)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileRead(pchFile, pvData, cubDataToRead);
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00005E01 File Offset: 0x00004001
		public static bool FileForget(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileForget(pchFile);
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00005E0E File Offset: 0x0000400E
		public static bool FileDelete(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileDelete(pchFile);
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00005E1B File Offset: 0x0000401B
		public static SteamAPICall_t FileShare(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_FileShare(pchFile);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00005E2D File Offset: 0x0000402D
		public static bool SetSyncPlatforms(string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_SetSyncPlatforms(pchFile, eRemoteStoragePlatform);
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00005E3B File Offset: 0x0000403B
		public static UGCFileWriteStreamHandle_t FileWriteStreamOpen(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCFileWriteStreamHandle_t)NativeMethods.ISteamRemoteStorage_FileWriteStreamOpen(pchFile);
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00005E4D File Offset: 0x0000404D
		public static bool FileWriteStreamWriteChunk(UGCFileWriteStreamHandle_t writeHandle, byte[] pvData, int cubData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileWriteStreamWriteChunk(writeHandle, pvData, cubData);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00005E5C File Offset: 0x0000405C
		public static bool FileWriteStreamClose(UGCFileWriteStreamHandle_t writeHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileWriteStreamClose(writeHandle);
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00005E69 File Offset: 0x00004069
		public static bool FileWriteStreamCancel(UGCFileWriteStreamHandle_t writeHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileWriteStreamCancel(writeHandle);
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00005E76 File Offset: 0x00004076
		public static bool FileExists(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FileExists(pchFile);
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00005E83 File Offset: 0x00004083
		public static bool FilePersisted(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_FilePersisted(pchFile);
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00005E90 File Offset: 0x00004090
		public static int GetFileSize(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetFileSize(pchFile);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00005E9D File Offset: 0x0000409D
		public static long GetFileTimestamp(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetFileTimestamp(pchFile);
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x00005EAA File Offset: 0x000040AA
		public static ERemoteStoragePlatform GetSyncPlatforms(string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetSyncPlatforms(pchFile);
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00005EB7 File Offset: 0x000040B7
		public static int GetFileCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetFileCount();
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00005EC3 File Offset: 0x000040C3
		public static string GetFileNameAndSize(int iFile, out int pnFileSizeInBytes)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetFileNameAndSize(iFile, out pnFileSizeInBytes);
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00005ED1 File Offset: 0x000040D1
		public static bool GetQuota(out int pnTotalBytes, out int puAvailableBytes)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetQuota(out pnTotalBytes, out puAvailableBytes);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00005EDF File Offset: 0x000040DF
		public static bool IsCloudEnabledForAccount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_IsCloudEnabledForAccount();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00005EEB File Offset: 0x000040EB
		public static bool IsCloudEnabledForApp()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_IsCloudEnabledForApp();
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00005EF7 File Offset: 0x000040F7
		public static void SetCloudEnabledForApp(bool bEnabled)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamRemoteStorage_SetCloudEnabledForApp(bEnabled);
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x00005F04 File Offset: 0x00004104
		public static SteamAPICall_t UGCDownload(UGCHandle_t hContent, uint unPriority)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_UGCDownload(hContent, unPriority);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00005F17 File Offset: 0x00004117
		public static bool GetUGCDownloadProgress(UGCHandle_t hContent, out int pnBytesDownloaded, out int pnBytesExpected)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetUGCDownloadProgress(hContent, out pnBytesDownloaded, out pnBytesExpected);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x0000F9AC File Offset: 0x0000DBAC
		public static bool GetUGCDetails(UGCHandle_t hContent, out AppId_t pnAppID, out string ppchName, out int pnFileSizeInBytes, out CSteamID pSteamIDOwner)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr nativeUtf;
			bool flag = NativeMethods.ISteamRemoteStorage_GetUGCDetails(hContent, out pnAppID, out nativeUtf, out pnFileSizeInBytes, out pSteamIDOwner);
			ppchName = ((!flag) ? null : InteropHelp.PtrToStringUTF8(nativeUtf));
			return flag;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00005F26 File Offset: 0x00004126
		public static int UGCRead(UGCHandle_t hContent, byte[] pvData, int cubDataToRead, uint cOffset, EUGCReadAction eAction)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UGCRead(hContent, pvData, cubDataToRead, cOffset, eAction);
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00005F38 File Offset: 0x00004138
		public static int GetCachedUGCCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_GetCachedUGCCount();
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00005F44 File Offset: 0x00004144
		public static UGCHandle_t GetCachedUGCHandle(int iCachedContent)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCHandle_t)NativeMethods.ISteamRemoteStorage_GetCachedUGCHandle(iCachedContent);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00005F56 File Offset: 0x00004156
		public static SteamAPICall_t PublishWorkshopFile(string pchFile, string pchPreviewFile, AppId_t nConsumerAppId, string pchTitle, string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, IList<string> pTags, EWorkshopFileType eWorkshopFileType)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_PublishWorkshopFile(pchFile, pchPreviewFile, nConsumerAppId, pchTitle, pchDescription, eVisibility, new InteropHelp.SteamParamStringArray(pTags), eWorkshopFileType);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x00005F7D File Offset: 0x0000417D
		public static PublishedFileUpdateHandle_t CreatePublishedFileUpdateRequest(PublishedFileId_t unPublishedFileId)
		{
			InteropHelp.TestIfAvailableClient();
			return (PublishedFileUpdateHandle_t)NativeMethods.ISteamRemoteStorage_CreatePublishedFileUpdateRequest(unPublishedFileId);
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00005F8F File Offset: 0x0000418F
		public static bool UpdatePublishedFileFile(PublishedFileUpdateHandle_t updateHandle, string pchFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileFile(updateHandle, pchFile);
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00005F9D File Offset: 0x0000419D
		public static bool UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle_t updateHandle, string pchPreviewFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFilePreviewFile(updateHandle, pchPreviewFile);
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00005FAB File Offset: 0x000041AB
		public static bool UpdatePublishedFileTitle(PublishedFileUpdateHandle_t updateHandle, string pchTitle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileTitle(updateHandle, pchTitle);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00005FB9 File Offset: 0x000041B9
		public static bool UpdatePublishedFileDescription(PublishedFileUpdateHandle_t updateHandle, string pchDescription)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileDescription(updateHandle, pchDescription);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00005FC7 File Offset: 0x000041C7
		public static bool UpdatePublishedFileVisibility(PublishedFileUpdateHandle_t updateHandle, ERemoteStoragePublishedFileVisibility eVisibility)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileVisibility(updateHandle, eVisibility);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00005FD5 File Offset: 0x000041D5
		public static bool UpdatePublishedFileTags(PublishedFileUpdateHandle_t updateHandle, IList<string> pTags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileTags(updateHandle, new InteropHelp.SteamParamStringArray(pTags));
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00005FED File Offset: 0x000041ED
		public static SteamAPICall_t CommitPublishedFileUpdate(PublishedFileUpdateHandle_t updateHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_CommitPublishedFileUpdate(updateHandle);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00005FFF File Offset: 0x000041FF
		public static SteamAPICall_t GetPublishedFileDetails(PublishedFileId_t unPublishedFileId, uint unMaxSecondsOld)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_GetPublishedFileDetails(unPublishedFileId, unMaxSecondsOld);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00006012 File Offset: 0x00004212
		public static SteamAPICall_t DeletePublishedFile(PublishedFileId_t unPublishedFileId)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_DeletePublishedFile(unPublishedFileId);
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00006024 File Offset: 0x00004224
		public static SteamAPICall_t EnumerateUserPublishedFiles(uint unStartIndex)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_EnumerateUserPublishedFiles(unStartIndex);
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00006036 File Offset: 0x00004236
		public static SteamAPICall_t SubscribePublishedFile(PublishedFileId_t unPublishedFileId)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_SubscribePublishedFile(unPublishedFileId);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x00006048 File Offset: 0x00004248
		public static SteamAPICall_t EnumerateUserSubscribedFiles(uint unStartIndex)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_EnumerateUserSubscribedFiles(unStartIndex);
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0000605A File Offset: 0x0000425A
		public static SteamAPICall_t UnsubscribePublishedFile(PublishedFileId_t unPublishedFileId)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_UnsubscribePublishedFile(unPublishedFileId);
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0000606C File Offset: 0x0000426C
		public static bool UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle_t updateHandle, string pchChangeDescription)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamRemoteStorage_UpdatePublishedFileSetChangeDescription(updateHandle, pchChangeDescription);
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0000607A File Offset: 0x0000427A
		public static SteamAPICall_t GetPublishedItemVoteDetails(PublishedFileId_t unPublishedFileId)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_GetPublishedItemVoteDetails(unPublishedFileId);
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0000608C File Offset: 0x0000428C
		public static SteamAPICall_t UpdateUserPublishedItemVote(PublishedFileId_t unPublishedFileId, bool bVoteUp)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_UpdateUserPublishedItemVote(unPublishedFileId, bVoteUp);
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x0000609F File Offset: 0x0000429F
		public static SteamAPICall_t GetUserPublishedItemVoteDetails(PublishedFileId_t unPublishedFileId)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_GetUserPublishedItemVoteDetails(unPublishedFileId);
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x000060B1 File Offset: 0x000042B1
		public static SteamAPICall_t EnumerateUserSharedWorkshopFiles(CSteamID steamId, uint unStartIndex, IList<string> pRequiredTags, IList<string> pExcludedTags)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_EnumerateUserSharedWorkshopFiles(steamId, unStartIndex, new InteropHelp.SteamParamStringArray(pRequiredTags), new InteropHelp.SteamParamStringArray(pExcludedTags));
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x0000F9E0 File Offset: 0x0000DBE0
		public static SteamAPICall_t PublishVideo(EWorkshopVideoProvider eVideoProvider, string pchVideoAccount, string pchVideoIdentifier, string pchPreviewFile, AppId_t nConsumerAppId, string pchTitle, string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, IList<string> pTags)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_PublishVideo(eVideoProvider, pchVideoAccount, pchVideoIdentifier, pchPreviewFile, nConsumerAppId, pchTitle, pchDescription, eVisibility, new InteropHelp.SteamParamStringArray(pTags));
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x000060DA File Offset: 0x000042DA
		public static SteamAPICall_t SetUserPublishedFileAction(PublishedFileId_t unPublishedFileId, EWorkshopFileAction eAction)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_SetUserPublishedFileAction(unPublishedFileId, eAction);
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x000060ED File Offset: 0x000042ED
		public static SteamAPICall_t EnumeratePublishedFilesByUserAction(EWorkshopFileAction eAction, uint unStartIndex)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_EnumeratePublishedFilesByUserAction(eAction, unStartIndex);
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00006100 File Offset: 0x00004300
		public static SteamAPICall_t EnumeratePublishedWorkshopFiles(EWorkshopEnumerationType eEnumerationType, uint unStartIndex, uint unCount, uint unDays, IList<string> pTags, IList<string> pUserTags)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_EnumeratePublishedWorkshopFiles(eEnumerationType, unStartIndex, unCount, unDays, new InteropHelp.SteamParamStringArray(pTags), new InteropHelp.SteamParamStringArray(pUserTags));
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0000612D File Offset: 0x0000432D
		public static SteamAPICall_t UGCDownloadToLocation(UGCHandle_t hContent, string pchLocation, uint unPriority)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamRemoteStorage_UGCDownloadToLocation(hContent, pchLocation, unPriority);
		}
	}
}
