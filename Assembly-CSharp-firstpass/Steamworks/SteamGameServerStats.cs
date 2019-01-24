using System;

namespace Steamworks
{
	// Token: 0x020001A1 RID: 417
	public static class SteamGameServerStats
	{
		// Token: 0x06000826 RID: 2086 RVA: 0x00005050 File Offset: 0x00003250
		public static SteamAPICall_t RequestUserStats(CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServerStats_RequestUserStats(steamIDUser);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00005062 File Offset: 0x00003262
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out int pData)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerStats_GetUserStat(steamIDUser, pchName, out pData);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x00005071 File Offset: 0x00003271
		public static bool GetUserStat(CSteamID steamIDUser, string pchName, out float pData)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerStats_GetUserStat_(steamIDUser, pchName, out pData);
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00005080 File Offset: 0x00003280
		public static bool GetUserAchievement(CSteamID steamIDUser, string pchName, out bool pbAchieved)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerStats_GetUserAchievement(steamIDUser, pchName, out pbAchieved);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0000508F File Offset: 0x0000328F
		public static bool SetUserStat(CSteamID steamIDUser, string pchName, int nData)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerStats_SetUserStat(steamIDUser, pchName, nData);
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0000509E File Offset: 0x0000329E
		public static bool SetUserStat(CSteamID steamIDUser, string pchName, float fData)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerStats_SetUserStat_(steamIDUser, pchName, fData);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x000050AD File Offset: 0x000032AD
		public static bool UpdateUserAvgRateStat(CSteamID steamIDUser, string pchName, float flCountThisSession, double dSessionLength)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerStats_UpdateUserAvgRateStat(steamIDUser, pchName, flCountThisSession, dSessionLength);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x000050BD File Offset: 0x000032BD
		public static bool SetUserAchievement(CSteamID steamIDUser, string pchName)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerStats_SetUserAchievement(steamIDUser, pchName);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x000050CB File Offset: 0x000032CB
		public static bool ClearUserAchievement(CSteamID steamIDUser, string pchName)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerStats_ClearUserAchievement(steamIDUser, pchName);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x000050D9 File Offset: 0x000032D9
		public static SteamAPICall_t StoreUserStats(CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServerStats_StoreUserStats(steamIDUser);
		}
	}
}
