using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000198 RID: 408
	public static class SteamAppList
	{
		// Token: 0x06000728 RID: 1832 RVA: 0x0000428B File Offset: 0x0000248B
		public static uint GetNumInstalledApps()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamAppList_GetNumInstalledApps();
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x00004297 File Offset: 0x00002497
		public static uint GetInstalledApps(AppId_t[] pvecAppID, uint unMaxAppIDs)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamAppList_GetInstalledApps(pvecAppID, unMaxAppIDs);
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0000F6C8 File Offset: 0x0000D8C8
		public static int GetAppName(AppId_t nAppID, out string pchName, int cchNameMax)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameMax);
			int num = NativeMethods.ISteamAppList_GetAppName(nAppID, intPtr, cchNameMax);
			pchName = ((num == -1) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0000F708 File Offset: 0x0000D908
		public static int GetAppInstallDir(AppId_t nAppID, out string pchDirectory, int cchNameMax)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchNameMax);
			int num = NativeMethods.ISteamAppList_GetAppInstallDir(nAppID, intPtr, cchNameMax);
			pchDirectory = ((num == -1) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x000042A5 File Offset: 0x000024A5
		public static int GetAppBuildId(AppId_t nAppID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamAppList_GetAppBuildId(nAppID);
		}
	}
}
