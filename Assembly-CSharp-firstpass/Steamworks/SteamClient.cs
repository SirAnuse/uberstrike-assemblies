using System;

namespace Steamworks
{
	// Token: 0x0200019A RID: 410
	public static class SteamClient
	{
		// Token: 0x06000745 RID: 1861 RVA: 0x000043C2 File Offset: 0x000025C2
		public static HSteamPipe CreateSteamPipe()
		{
			InteropHelp.TestIfAvailableClient();
			return (HSteamPipe)NativeMethods.ISteamClient_CreateSteamPipe();
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x000043D3 File Offset: 0x000025D3
		public static bool BReleaseSteamPipe(HSteamPipe hSteamPipe)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_BReleaseSteamPipe(hSteamPipe);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x000043E0 File Offset: 0x000025E0
		public static HSteamUser ConnectToGlobalUser(HSteamPipe hSteamPipe)
		{
			InteropHelp.TestIfAvailableClient();
			return (HSteamUser)NativeMethods.ISteamClient_ConnectToGlobalUser(hSteamPipe);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x000043F2 File Offset: 0x000025F2
		public static HSteamUser CreateLocalUser(out HSteamPipe phSteamPipe, EAccountType eAccountType)
		{
			InteropHelp.TestIfAvailableClient();
			return (HSteamUser)NativeMethods.ISteamClient_CreateLocalUser(out phSteamPipe, eAccountType);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00004405 File Offset: 0x00002605
		public static void ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_ReleaseUser(hSteamPipe, hUser);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x00004413 File Offset: 0x00002613
		public static IntPtr GetISteamUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUser(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00004422 File Offset: 0x00002622
		public static IntPtr GetISteamGameServer(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamGameServer(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00004431 File Offset: 0x00002631
		public static void SetLocalIPBinding(uint unIP, ushort usPort)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_SetLocalIPBinding(unIP, usPort);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0000443F File Offset: 0x0000263F
		public static IntPtr GetISteamFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamFriends(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0000444E File Offset: 0x0000264E
		public static IntPtr GetISteamUtils(HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUtils(hSteamPipe, pchVersion);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0000445C File Offset: 0x0000265C
		public static IntPtr GetISteamMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamMatchmaking(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0000446B File Offset: 0x0000266B
		public static IntPtr GetISteamMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamMatchmakingServers(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x0000447A File Offset: 0x0000267A
		public static IntPtr GetISteamGenericInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamGenericInterface(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00004489 File Offset: 0x00002689
		public static IntPtr GetISteamUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUserStats(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00004498 File Offset: 0x00002698
		public static IntPtr GetISteamGameServerStats(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamGameServerStats(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x000044A7 File Offset: 0x000026A7
		public static IntPtr GetISteamApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamApps(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x000044B6 File Offset: 0x000026B6
		public static IntPtr GetISteamNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamNetworking(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x000044C5 File Offset: 0x000026C5
		public static IntPtr GetISteamRemoteStorage(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamRemoteStorage(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x000044D4 File Offset: 0x000026D4
		public static IntPtr GetISteamScreenshots(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamScreenshots(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x000044E3 File Offset: 0x000026E3
		public static void RunFrame()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_RunFrame();
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x000044EF File Offset: 0x000026EF
		public static uint GetIPCCallCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetIPCCallCount();
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x000044FB File Offset: 0x000026FB
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_SetWarningMessageHook(pFunction);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00004508 File Offset: 0x00002708
		public static bool BShutdownIfAllPipesClosed()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_BShutdownIfAllPipesClosed();
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00004514 File Offset: 0x00002714
		public static IntPtr GetISteamHTTP(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamHTTP(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00004523 File Offset: 0x00002723
		public static IntPtr GetISteamUnifiedMessages(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUnifiedMessages(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00004532 File Offset: 0x00002732
		public static IntPtr GetISteamController(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamController(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x00004541 File Offset: 0x00002741
		public static IntPtr GetISteamUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamUGC(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00004550 File Offset: 0x00002750
		public static IntPtr GetISteamAppList(HSteamUser hSteamUser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamAppList(hSteamUser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0000455F File Offset: 0x0000275F
		public static IntPtr GetISteamMusic(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamMusic(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0000456E File Offset: 0x0000276E
		public static IntPtr GetISteamMusicRemote(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamMusicRemote(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x0000457D File Offset: 0x0000277D
		public static IntPtr GetISteamHTMLSurface(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamHTMLSurface(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x0000458C File Offset: 0x0000278C
		public static void Set_SteamAPI_CPostAPIResultInProcess(SteamAPI_PostAPIResultInProcess_t func)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_Set_SteamAPI_CPostAPIResultInProcess(func);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00004599 File Offset: 0x00002799
		public static void Remove_SteamAPI_CPostAPIResultInProcess(SteamAPI_PostAPIResultInProcess_t func)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_Remove_SteamAPI_CPostAPIResultInProcess(func);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x000045A6 File Offset: 0x000027A6
		public static void Set_SteamAPI_CCheckCallbackRegisteredInProcess(SteamAPI_CheckCallbackRegistered_t func)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamClient_Set_SteamAPI_CCheckCallbackRegisteredInProcess(func);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x000045B3 File Offset: 0x000027B3
		public static IntPtr GetISteamInventory(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamInventory(hSteamuser, hSteamPipe, pchVersion);
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x000045C2 File Offset: 0x000027C2
		public static IntPtr GetISteamVideo(HSteamUser hSteamuser, HSteamPipe hSteamPipe, string pchVersion)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamClient_GetISteamVideo(hSteamuser, hSteamPipe, pchVersion);
		}
	}
}
