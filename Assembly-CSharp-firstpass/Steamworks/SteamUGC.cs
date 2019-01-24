using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001AD RID: 429
	public static class SteamUGC
	{
		// Token: 0x0600094B RID: 2379 RVA: 0x000061AE File Offset: 0x000043AE
		public static UGCQueryHandle_t CreateQueryUserUGCRequest(AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCQueryHandle_t)NativeMethods.ISteamUGC_CreateQueryUserUGCRequest(unAccountID, eListType, eMatchingUGCType, eSortOrder, nCreatorAppID, nConsumerAppID, unPage);
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x000061C9 File Offset: 0x000043C9
		public static UGCQueryHandle_t CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCQueryHandle_t)NativeMethods.ISteamUGC_CreateQueryAllUGCRequest(eQueryType, eMatchingeMatchingUGCTypeFileType, nCreatorAppID, nConsumerAppID, unPage);
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x000061E0 File Offset: 0x000043E0
		public static SteamAPICall_t SendQueryUGCRequest(UGCQueryHandle_t handle)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SendQueryUGCRequest(handle);
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x000061F2 File Offset: 0x000043F2
		public static bool GetQueryUGCResult(UGCQueryHandle_t handle, uint index, out SteamUGCDetails_t pDetails)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetQueryUGCResult(handle, index, out pDetails);
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00006201 File Offset: 0x00004401
		public static bool ReleaseQueryUGCRequest(UGCQueryHandle_t handle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_ReleaseQueryUGCRequest(handle);
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x0000620E File Offset: 0x0000440E
		public static bool AddRequiredTag(UGCQueryHandle_t handle, string pTagName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_AddRequiredTag(handle, pTagName);
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0000621C File Offset: 0x0000441C
		public static bool AddExcludedTag(UGCQueryHandle_t handle, string pTagName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_AddExcludedTag(handle, pTagName);
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0000622A File Offset: 0x0000442A
		public static bool SetReturnLongDescription(UGCQueryHandle_t handle, bool bReturnLongDescription)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnLongDescription(handle, bReturnLongDescription);
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00006238 File Offset: 0x00004438
		public static bool SetReturnTotalOnly(UGCQueryHandle_t handle, bool bReturnTotalOnly)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetReturnTotalOnly(handle, bReturnTotalOnly);
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00006246 File Offset: 0x00004446
		public static bool SetAllowCachedResponse(UGCQueryHandle_t handle, uint unMaxAgeSeconds)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetAllowCachedResponse(handle, unMaxAgeSeconds);
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x00006254 File Offset: 0x00004454
		public static bool SetCloudFileNameFilter(UGCQueryHandle_t handle, string pMatchCloudFileName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetCloudFileNameFilter(handle, pMatchCloudFileName);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00006262 File Offset: 0x00004462
		public static bool SetMatchAnyTag(UGCQueryHandle_t handle, bool bMatchAnyTag)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetMatchAnyTag(handle, bMatchAnyTag);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00006270 File Offset: 0x00004470
		public static bool SetSearchText(UGCQueryHandle_t handle, string pSearchText)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetSearchText(handle, pSearchText);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x0000627E File Offset: 0x0000447E
		public static bool SetRankedByTrendDays(UGCQueryHandle_t handle, uint unDays)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetRankedByTrendDays(handle, unDays);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0000628C File Offset: 0x0000448C
		public static SteamAPICall_t RequestUGCDetails(PublishedFileId_t nPublishedFileID, uint unMaxAgeSeconds)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_RequestUGCDetails(nPublishedFileID, unMaxAgeSeconds);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0000629F File Offset: 0x0000449F
		public static SteamAPICall_t CreateItem(AppId_t nConsumerAppId, EWorkshopFileType eFileType)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_CreateItem(nConsumerAppId, eFileType);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x000062B2 File Offset: 0x000044B2
		public static UGCUpdateHandle_t StartItemUpdate(AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (UGCUpdateHandle_t)NativeMethods.ISteamUGC_StartItemUpdate(nConsumerAppId, nPublishedFileID);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x000062C5 File Offset: 0x000044C5
		public static bool SetItemTitle(UGCUpdateHandle_t handle, string pchTitle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemTitle(handle, pchTitle);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x000062D3 File Offset: 0x000044D3
		public static bool SetItemDescription(UGCUpdateHandle_t handle, string pchDescription)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemDescription(handle, pchDescription);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x000062E1 File Offset: 0x000044E1
		public static bool SetItemVisibility(UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemVisibility(handle, eVisibility);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x000062EF File Offset: 0x000044EF
		public static bool SetItemTags(UGCUpdateHandle_t updateHandle, IList<string> pTags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemTags(updateHandle, new InteropHelp.SteamParamStringArray(pTags));
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00006307 File Offset: 0x00004507
		public static bool SetItemContent(UGCUpdateHandle_t handle, string pszContentFolder)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemContent(handle, pszContentFolder);
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00006315 File Offset: 0x00004515
		public static bool SetItemPreview(UGCUpdateHandle_t handle, string pszPreviewFile)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_SetItemPreview(handle, pszPreviewFile);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00006323 File Offset: 0x00004523
		public static SteamAPICall_t SubmitItemUpdate(UGCUpdateHandle_t handle, string pchChangeNote)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SubmitItemUpdate(handle, pchChangeNote);
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x00006336 File Offset: 0x00004536
		public static EItemUpdateStatus GetItemUpdateProgress(UGCUpdateHandle_t handle, out ulong punBytesProcessed, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetItemUpdateProgress(handle, out punBytesProcessed, out punBytesTotal);
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x00006345 File Offset: 0x00004545
		public static SteamAPICall_t SubscribeItem(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_SubscribeItem(nPublishedFileID);
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x00006357 File Offset: 0x00004557
		public static SteamAPICall_t UnsubscribeItem(PublishedFileId_t nPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUGC_UnsubscribeItem(nPublishedFileID);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x00006369 File Offset: 0x00004569
		public static uint GetNumSubscribedItems()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetNumSubscribedItems();
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00006375 File Offset: 0x00004575
		public static uint GetSubscribedItems(PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetSubscribedItems(pvecPublishedFileID, cMaxEntries);
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0000FA14 File Offset: 0x0000DC14
		public static bool GetItemInstallInfo(PublishedFileId_t nPublishedFileID, out ulong punSizeOnDisk, out string pchFolder, uint cchFolderSize, out bool pbLegacyItem)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchFolderSize);
			bool flag = NativeMethods.ISteamUGC_GetItemInstallInfo(nPublishedFileID, out punSizeOnDisk, intPtr, cchFolderSize, out pbLegacyItem);
			pchFolder = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00006383 File Offset: 0x00004583
		public static bool GetItemUpdateInfo(PublishedFileId_t nPublishedFileID, out bool pbNeedsUpdate, out bool pbIsDownloading, out ulong punBytesDownloaded, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUGC_GetItemUpdateInfo(nPublishedFileID, out pbNeedsUpdate, out pbIsDownloading, out punBytesDownloaded, out punBytesTotal);
		}
	}
}
