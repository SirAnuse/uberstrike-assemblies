using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000199 RID: 409
	public static class SteamApps
	{
		// Token: 0x0600072D RID: 1837 RVA: 0x000042B2 File Offset: 0x000024B2
		public static bool BIsSubscribed()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsSubscribed();
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x000042BE File Offset: 0x000024BE
		public static bool BIsLowViolence()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsLowViolence();
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x000042CA File Offset: 0x000024CA
		public static bool BIsCybercafe()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsCybercafe();
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x000042D6 File Offset: 0x000024D6
		public static bool BIsVACBanned()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsVACBanned();
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x000042E2 File Offset: 0x000024E2
		public static string GetCurrentGameLanguage()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetCurrentGameLanguage();
		}

		// Token: 0x06000732 RID: 1842 RVA: 0x000042EE File Offset: 0x000024EE
		public static string GetAvailableGameLanguages()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetAvailableGameLanguages();
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x000042FA File Offset: 0x000024FA
		public static bool BIsSubscribedApp(AppId_t appID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsSubscribedApp(appID);
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x00004307 File Offset: 0x00002507
		public static bool BIsDlcInstalled(AppId_t appID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsDlcInstalled(appID);
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x00004314 File Offset: 0x00002514
		public static uint GetEarliestPurchaseUnixTime(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetEarliestPurchaseUnixTime(nAppID);
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x00004321 File Offset: 0x00002521
		public static bool BIsSubscribedFromFreeWeekend()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsSubscribedFromFreeWeekend();
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0000432D File Offset: 0x0000252D
		public static int GetDLCCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetDLCCount();
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0000F748 File Offset: 0x0000D948
		public static bool BGetDLCDataByIndex(int iDLC, out AppId_t pAppID, out bool pbAvailable, out string pchName, int cchNameBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameBufferSize);
			bool flag = NativeMethods.ISteamApps_BGetDLCDataByIndex(iDLC, out pAppID, out pbAvailable, intPtr, cchNameBufferSize);
			pchName = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00004339 File Offset: 0x00002539
		public static void InstallDLC(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamApps_InstallDLC(nAppID);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x00004346 File Offset: 0x00002546
		public static void UninstallDLC(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamApps_UninstallDLC(nAppID);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00004353 File Offset: 0x00002553
		public static void RequestAppProofOfPurchaseKey(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamApps_RequestAppProofOfPurchaseKey(nAppID);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0000F78C File Offset: 0x0000D98C
		public static bool GetCurrentBetaName(out string pchName, int cchNameBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameBufferSize);
			bool flag = NativeMethods.ISteamApps_GetCurrentBetaName(intPtr, cchNameBufferSize);
			pchName = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00004360 File Offset: 0x00002560
		public static bool MarkContentCorrupt(bool bMissingFilesOnly)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_MarkContentCorrupt(bMissingFilesOnly);
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0000436D File Offset: 0x0000256D
		public static uint GetInstalledDepots(AppId_t appID, DepotId_t[] pvecDepots, uint cMaxDepots)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetInstalledDepots(appID, pvecDepots, cMaxDepots);
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0000F7C8 File Offset: 0x0000D9C8
		public static uint GetAppInstallDir(AppId_t appID, out string pchFolder, uint cchFolderBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchFolderBufferSize);
			uint num = NativeMethods.ISteamApps_GetAppInstallDir(appID, intPtr, cchFolderBufferSize);
			pchFolder = ((num == 0u) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0000437C File Offset: 0x0000257C
		public static bool BIsAppInstalled(AppId_t appID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_BIsAppInstalled(appID);
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00004389 File Offset: 0x00002589
		public static CSteamID GetAppOwner()
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamApps_GetAppOwner();
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0000439A File Offset: 0x0000259A
		public static string GetLaunchQueryParam(string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetLaunchQueryParam(pchKey);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x000043A7 File Offset: 0x000025A7
		public static bool GetDlcDownloadProgress(AppId_t nAppID, out ulong punBytesDownloaded, out ulong punBytesTotal)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetDlcDownloadProgress(nAppID, out punBytesDownloaded, out punBytesTotal);
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000043B6 File Offset: 0x000025B6
		public static int GetAppBuildId()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamApps_GetAppBuildId();
		}
	}
}
