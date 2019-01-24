using System;

namespace Steamworks
{
	// Token: 0x0200019D RID: 413
	public static class SteamGameServer
	{
		// Token: 0x060007B5 RID: 1973 RVA: 0x000049F1 File Offset: 0x00002BF1
		public static bool InitGameServer(uint unIP, ushort usGamePort, ushort usQueryPort, uint unFlags, AppId_t nGameAppId, string pchVersionString)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_InitGameServer(unIP, usGamePort, usQueryPort, unFlags, nGameAppId, pchVersionString);
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x00004A05 File Offset: 0x00002C05
		public static void SetProduct(string pszProduct)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetProduct(pszProduct);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00004A12 File Offset: 0x00002C12
		public static void SetGameDescription(string pszGameDescription)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetGameDescription(pszGameDescription);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00004A1F File Offset: 0x00002C1F
		public static void SetModDir(string pszModDir)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetModDir(pszModDir);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00004A2C File Offset: 0x00002C2C
		public static void SetDedicatedServer(bool bDedicated)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetDedicatedServer(bDedicated);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x00004A39 File Offset: 0x00002C39
		public static void LogOn(string pszToken)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_LogOn(pszToken);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x00004A46 File Offset: 0x00002C46
		public static void LogOnAnonymous()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_LogOnAnonymous();
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00004A52 File Offset: 0x00002C52
		public static void LogOff()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_LogOff();
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00004A5E File Offset: 0x00002C5E
		public static bool BLoggedOn()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_BLoggedOn();
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x00004A6A File Offset: 0x00002C6A
		public static bool BSecure()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_BSecure();
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00004A76 File Offset: 0x00002C76
		public static CSteamID GetSteamID()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (CSteamID)NativeMethods.ISteamGameServer_GetSteamID();
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00004A87 File Offset: 0x00002C87
		public static bool WasRestartRequested()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_WasRestartRequested();
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00004A93 File Offset: 0x00002C93
		public static void SetMaxPlayerCount(int cPlayersMax)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetMaxPlayerCount(cPlayersMax);
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00004AA0 File Offset: 0x00002CA0
		public static void SetBotPlayerCount(int cBotplayers)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetBotPlayerCount(cBotplayers);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00004AAD File Offset: 0x00002CAD
		public static void SetServerName(string pszServerName)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetServerName(pszServerName);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00004ABA File Offset: 0x00002CBA
		public static void SetMapName(string pszMapName)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetMapName(pszMapName);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00004AC7 File Offset: 0x00002CC7
		public static void SetPasswordProtected(bool bPasswordProtected)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetPasswordProtected(bPasswordProtected);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00004AD4 File Offset: 0x00002CD4
		public static void SetSpectatorPort(ushort unSpectatorPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetSpectatorPort(unSpectatorPort);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00004AE1 File Offset: 0x00002CE1
		public static void SetSpectatorServerName(string pszSpectatorServerName)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetSpectatorServerName(pszSpectatorServerName);
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x00004AEE File Offset: 0x00002CEE
		public static void ClearAllKeyValues()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_ClearAllKeyValues();
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00004AFA File Offset: 0x00002CFA
		public static void SetKeyValue(string pKey, string pValue)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetKeyValue(pKey, pValue);
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x00004B08 File Offset: 0x00002D08
		public static void SetGameTags(string pchGameTags)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetGameTags(pchGameTags);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x00004B15 File Offset: 0x00002D15
		public static void SetGameData(string pchGameData)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetGameData(pchGameData);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00004B22 File Offset: 0x00002D22
		public static void SetRegion(string pszRegion)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetRegion(pszRegion);
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00004B2F File Offset: 0x00002D2F
		public static bool SendUserConnectAndAuthenticate(uint unIPClient, byte[] pvAuthBlob, uint cubAuthBlobSize, out CSteamID pSteamIDUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_SendUserConnectAndAuthenticate(unIPClient, pvAuthBlob, cubAuthBlobSize, out pSteamIDUser);
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x00004B3F File Offset: 0x00002D3F
		public static CSteamID CreateUnauthenticatedUserConnection()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (CSteamID)NativeMethods.ISteamGameServer_CreateUnauthenticatedUserConnection();
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00004B50 File Offset: 0x00002D50
		public static void SendUserDisconnect(CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SendUserDisconnect(steamIDUser);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00004B5D File Offset: 0x00002D5D
		public static bool BUpdateUserData(CSteamID steamIDUser, string pchPlayerName, uint uScore)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_BUpdateUserData(steamIDUser, pchPlayerName, uScore);
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x00004B6C File Offset: 0x00002D6C
		public static HAuthTicket GetAuthSessionTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (HAuthTicket)NativeMethods.ISteamGameServer_GetAuthSessionTicket(pTicket, cbMaxTicket, out pcbTicket);
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x00004B80 File Offset: 0x00002D80
		public static EBeginAuthSessionResult BeginAuthSession(byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_BeginAuthSession(pAuthTicket, cbAuthTicket, steamID);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x00004B8F File Offset: 0x00002D8F
		public static void EndAuthSession(CSteamID steamID)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_EndAuthSession(steamID);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x00004B9C File Offset: 0x00002D9C
		public static void CancelAuthTicket(HAuthTicket hAuthTicket)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_CancelAuthTicket(hAuthTicket);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x00004BA9 File Offset: 0x00002DA9
		public static EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamID steamID, AppId_t appID)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_UserHasLicenseForApp(steamID, appID);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x00004BB7 File Offset: 0x00002DB7
		public static bool RequestUserGroupStatus(CSteamID steamIDUser, CSteamID steamIDGroup)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_RequestUserGroupStatus(steamIDUser, steamIDGroup);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00004BC5 File Offset: 0x00002DC5
		public static void GetGameplayStats()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_GetGameplayStats();
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00004BD1 File Offset: 0x00002DD1
		public static SteamAPICall_t GetServerReputation()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_GetServerReputation();
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00004BE2 File Offset: 0x00002DE2
		public static uint GetPublicIP()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_GetPublicIP();
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x00004BEE File Offset: 0x00002DEE
		public static bool HandleIncomingPacket(byte[] pData, int cbData, uint srcIP, ushort srcPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_HandleIncomingPacket(pData, cbData, srcIP, srcPort);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00004BFE File Offset: 0x00002DFE
		public static int GetNextOutgoingPacket(byte[] pOut, int cbMaxOut, out uint pNetAdr, out ushort pPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServer_GetNextOutgoingPacket(pOut, cbMaxOut, out pNetAdr, out pPort);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x00004C0E File Offset: 0x00002E0E
		public static void EnableHeartbeats(bool bActive)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_EnableHeartbeats(bActive);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x00004C1B File Offset: 0x00002E1B
		public static void SetHeartbeatInterval(int iHeartbeatInterval)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_SetHeartbeatInterval(iHeartbeatInterval);
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00004C28 File Offset: 0x00002E28
		public static void ForceHeartbeat()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServer_ForceHeartbeat();
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x00004C34 File Offset: 0x00002E34
		public static SteamAPICall_t AssociateWithClan(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_AssociateWithClan(steamIDClan);
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00004C46 File Offset: 0x00002E46
		public static SteamAPICall_t ComputeNewPlayerCompatibility(CSteamID steamIDNewPlayer)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServer_ComputeNewPlayerCompatibility(steamIDNewPlayer);
		}
	}
}
