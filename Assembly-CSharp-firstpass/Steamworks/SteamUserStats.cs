using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001B0 RID: 432
	public static class SteamUserStats
	{
		// Token: 0x06000988 RID: 2440 RVA: 0x0000653F File Offset: 0x0000473F
		public static bool RequestCurrentStats()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_RequestCurrentStats();
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0000654B File Offset: 0x0000474B
		public static bool GetStat(string pchName, out int pData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetStat(pchName, out pData);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00006559 File Offset: 0x00004759
		public static bool GetStat(string pchName, out float pData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetStat_(pchName, out pData);
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00006567 File Offset: 0x00004767
		public static bool SetStat(string pchName, int nData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_SetStat(pchName, nData);
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00006575 File Offset: 0x00004775
		public static bool SetStat(string pchName, float fData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_SetStat_(pchName, fData);
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00006583 File Offset: 0x00004783
		public static bool UpdateAvgRateStat(string pchName, float flCountThisSession, double dSessionLength)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_UpdateAvgRateStat(pchName, flCountThisSession, dSessionLength);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00006592 File Offset: 0x00004792
		public static bool GetAchievement(string pchName, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetAchievement(pchName, out pbAchieved);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x000065A0 File Offset: 0x000047A0
		public static bool SetAchievement(string pchName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_SetAchievement(pchName);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x000065AD File Offset: 0x000047AD
		public static bool ClearAchievement(string pchName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_ClearAchievement(pchName);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x000065BA File Offset: 0x000047BA
		public static bool GetAchievementAndUnlockTime(string pchName, out bool pbAchieved, out uint punUnlockTime)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetAchievementAndUnlockTime(pchName, out pbAchieved, out punUnlockTime);
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x000065C9 File Offset: 0x000047C9
		public static bool StoreStats()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_StoreStats();
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x000065D5 File Offset: 0x000047D5
		public static int GetAchievementIcon(string pchName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetAchievementIcon(pchName);
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x000065E2 File Offset: 0x000047E2
		public static string GetAchievementDisplayAttribute(string pchName, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetAchievementDisplayAttribute(pchName, pchKey);
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x000065F0 File Offset: 0x000047F0
		public static bool IndicateAchievementProgress(string pchName, uint nCurProgress, uint nMaxProgress)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_IndicateAchievementProgress(pchName, nCurProgress, nMaxProgress);
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x000065FF File Offset: 0x000047FF
		public static uint GetNumAchievements()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetNumAchievements();
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0000660B File Offset: 0x0000480B
		public static string GetAchievementName(uint iAchievement)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetAchievementName(iAchievement);
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00006618 File Offset: 0x00004818
		public static SteamAPICall_t RequestUserStats(CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestUserStats(steamIDUser);
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0000662A File Offset: 0x0000482A
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out int pData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetUserStat(steamIDUser, pchName, out pData);
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00006639 File Offset: 0x00004839
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out float pData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetUserStat_(steamIDUser, pchName, out pData);
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00006648 File Offset: 0x00004848
		public static bool GetUserAchievement(CSteamID steamIDUser, string pchName, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetUserAchievement(steamIDUser, pchName, out pbAchieved);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00006657 File Offset: 0x00004857
		public static bool GetUserAchievementAndUnlockTime(CSteamID steamIDUser, string pchName, out bool pbAchieved, out uint punUnlockTime)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetUserAchievementAndUnlockTime(steamIDUser, pchName, out pbAchieved, out punUnlockTime);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x00006667 File Offset: 0x00004867
		public static bool ResetAllStats(bool bAchievementsToo)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_ResetAllStats(bAchievementsToo);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x00006674 File Offset: 0x00004874
		public static SteamAPICall_t FindOrCreateLeaderboard(string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_FindOrCreateLeaderboard(pchLeaderboardName, eLeaderboardSortMethod, eLeaderboardDisplayType);
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x00006688 File Offset: 0x00004888
		public static SteamAPICall_t FindLeaderboard(string pchLeaderboardName)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_FindLeaderboard(pchLeaderboardName);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0000669A File Offset: 0x0000489A
		public static string GetLeaderboardName(SteamLeaderboard_t hSteamLeaderboard)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardName(hSteamLeaderboard);
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x000066A7 File Offset: 0x000048A7
		public static int GetLeaderboardEntryCount(SteamLeaderboard_t hSteamLeaderboard)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardEntryCount(hSteamLeaderboard);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x000066B4 File Offset: 0x000048B4
		public static ELeaderboardSortMethod GetLeaderboardSortMethod(SteamLeaderboard_t hSteamLeaderboard)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardSortMethod(hSteamLeaderboard);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x000066C1 File Offset: 0x000048C1
		public static ELeaderboardDisplayType GetLeaderboardDisplayType(SteamLeaderboard_t hSteamLeaderboard)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetLeaderboardDisplayType(hSteamLeaderboard);
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x000066CE File Offset: 0x000048CE
		public static SteamAPICall_t DownloadLeaderboardEntries(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_DownloadLeaderboardEntries(hSteamLeaderboard, eLeaderboardDataRequest, nRangeStart, nRangeEnd);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x000066E3 File Offset: 0x000048E3
		public static SteamAPICall_t DownloadLeaderboardEntriesForUsers(SteamLeaderboard_t hSteamLeaderboard, CSteamID[] prgUsers, int cUsers)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_DownloadLeaderboardEntriesForUsers(hSteamLeaderboard, prgUsers, cUsers);
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x000066F7 File Offset: 0x000048F7
		public static bool GetDownloadedLeaderboardEntry(SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, out LeaderboardEntry_t pLeaderboardEntry, int[] pDetails, int cDetailsMax)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetDownloadedLeaderboardEntry(hSteamLeaderboardEntries, index, out pLeaderboardEntry, pDetails, cDetailsMax);
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x00006709 File Offset: 0x00004909
		public static SteamAPICall_t UploadLeaderboardScore(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, int[] pScoreDetails, int cScoreDetailsCount)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_UploadLeaderboardScore(hSteamLeaderboard, eLeaderboardUploadScoreMethod, nScore, pScoreDetails, cScoreDetailsCount);
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x00006720 File Offset: 0x00004920
		public static SteamAPICall_t AttachLeaderboardUGC(SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_AttachLeaderboardUGC(hSteamLeaderboard, hUGC);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x00006733 File Offset: 0x00004933
		public static SteamAPICall_t GetNumberOfCurrentPlayers()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_GetNumberOfCurrentPlayers();
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00006744 File Offset: 0x00004944
		public static SteamAPICall_t RequestGlobalAchievementPercentages()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestGlobalAchievementPercentages();
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0000FAB8 File Offset: 0x0000DCB8
		public static int GetMostAchievedAchievementInfo(out string pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)unNameBufLen);
			int num = NativeMethods.ISteamUserStats_GetMostAchievedAchievementInfo(intPtr, unNameBufLen, out pflPercent, out pbAchieved);
			pchName = ((num == 0) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0000FAF8 File Offset: 0x0000DCF8
		public static int GetNextMostAchievedAchievementInfo(int iIteratorPrevious, out string pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)unNameBufLen);
			int num = NativeMethods.ISteamUserStats_GetNextMostAchievedAchievementInfo(iIteratorPrevious, intPtr, unNameBufLen, out pflPercent, out pbAchieved);
			pchName = ((num == 0) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x00006755 File Offset: 0x00004955
		public static bool GetAchievementAchievedPercent(string pchName, out float pflPercent)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetAchievementAchievedPercent(pchName, out pflPercent);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00006763 File Offset: 0x00004963
		public static SteamAPICall_t RequestGlobalStats(int nHistoryDays)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUserStats_RequestGlobalStats(nHistoryDays);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x00006775 File Offset: 0x00004975
		public static bool GetGlobalStat(string pchStatName, out long pData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetGlobalStat(pchStatName, out pData);
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x00006783 File Offset: 0x00004983
		public static bool GetGlobalStat(string pchStatName, out double pData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetGlobalStat_(pchStatName, out pData);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x00006791 File Offset: 0x00004991
		public static int GetGlobalStatHistory(string pchStatName, long[] pData, uint cubData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetGlobalStatHistory(pchStatName, pData, cubData);
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x000067A0 File Offset: 0x000049A0
		public static int GetGlobalStatHistory(string pchStatName, double[] pData, uint cubData)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUserStats_GetGlobalStatHistory_(pchStatName, pData, cubData);
		}
	}
}
