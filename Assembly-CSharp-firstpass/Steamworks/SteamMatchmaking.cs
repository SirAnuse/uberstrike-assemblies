using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001A6 RID: 422
	public static class SteamMatchmaking
	{
		// Token: 0x0600089A RID: 2202 RVA: 0x000056B6 File Offset: 0x000038B6
		public static int GetFavoriteGameCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetFavoriteGameCount();
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x000056C2 File Offset: 0x000038C2
		public static bool GetFavoriteGame(int iGame, out AppId_t pnAppID, out uint pnIP, out ushort pnConnPort, out ushort pnQueryPort, out uint punFlags, out uint pRTime32LastPlayedOnServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetFavoriteGame(iGame, out pnAppID, out pnIP, out pnConnPort, out pnQueryPort, out punFlags, out pRTime32LastPlayedOnServer);
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x000056D8 File Offset: 0x000038D8
		public static int AddFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_AddFavoriteGame(nAppID, nIP, nConnPort, nQueryPort, unFlags, rTime32LastPlayedOnServer);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000056EC File Offset: 0x000038EC
		public static bool RemoveFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_RemoveFavoriteGame(nAppID, nIP, nConnPort, nQueryPort, unFlags);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x000056FE File Offset: 0x000038FE
		public static SteamAPICall_t RequestLobbyList()
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_RequestLobbyList();
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0000570F File Offset: 0x0000390F
		public static void AddRequestLobbyListStringFilter(string pchKeyToMatch, string pchValueToMatch, ELobbyComparison eComparisonType)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListStringFilter(pchKeyToMatch, pchValueToMatch, eComparisonType);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0000571E File Offset: 0x0000391E
		public static void AddRequestLobbyListNumericalFilter(string pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListNumericalFilter(pchKeyToMatch, nValueToMatch, eComparisonType);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0000572D File Offset: 0x0000392D
		public static void AddRequestLobbyListNearValueFilter(string pchKeyToMatch, int nValueToBeCloseTo)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListNearValueFilter(pchKeyToMatch, nValueToBeCloseTo);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0000573B File Offset: 0x0000393B
		public static void AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable(nSlotsAvailable);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00005748 File Offset: 0x00003948
		public static void AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter eLobbyDistanceFilter)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListDistanceFilter(eLobbyDistanceFilter);
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00005755 File Offset: 0x00003955
		public static void AddRequestLobbyListResultCountFilter(int cMaxResults)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListResultCountFilter(cMaxResults);
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00005762 File Offset: 0x00003962
		public static void AddRequestLobbyListCompatibleMembersFilter(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter(steamIDLobby);
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0000576F File Offset: 0x0000396F
		public static CSteamID GetLobbyByIndex(int iLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyByIndex(iLobby);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00005781 File Offset: 0x00003981
		public static SteamAPICall_t CreateLobby(ELobbyType eLobbyType, int cMaxMembers)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_CreateLobby(eLobbyType, cMaxMembers);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00005794 File Offset: 0x00003994
		public static SteamAPICall_t JoinLobby(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamMatchmaking_JoinLobby(steamIDLobby);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x000057A6 File Offset: 0x000039A6
		public static void LeaveLobby(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_LeaveLobby(steamIDLobby);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x000057B3 File Offset: 0x000039B3
		public static bool InviteUserToLobby(CSteamID steamIDLobby, CSteamID steamIDInvitee)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_InviteUserToLobby(steamIDLobby, steamIDInvitee);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x000057C1 File Offset: 0x000039C1
		public static int GetNumLobbyMembers(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetNumLobbyMembers(steamIDLobby);
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x000057CE File Offset: 0x000039CE
		public static CSteamID GetLobbyMemberByIndex(CSteamID steamIDLobby, int iMember)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyMemberByIndex(steamIDLobby, iMember);
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x000057E1 File Offset: 0x000039E1
		public static string GetLobbyData(CSteamID steamIDLobby, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyData(steamIDLobby, pchKey);
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x000057EF File Offset: 0x000039EF
		public static bool SetLobbyData(CSteamID steamIDLobby, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyData(steamIDLobby, pchKey, pchValue);
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x000057FE File Offset: 0x000039FE
		public static int GetLobbyDataCount(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyDataCount(steamIDLobby);
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x0000F948 File Offset: 0x0000DB48
		public static bool GetLobbyDataByIndex(CSteamID steamIDLobby, int iLobbyData, out string pchKey, int cchKeyBufferSize, out string pchValue, int cchValueBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchKeyBufferSize);
			IntPtr intPtr2 = Marshal.AllocHGlobal(cchValueBufferSize);
			bool flag = NativeMethods.ISteamMatchmaking_GetLobbyDataByIndex(steamIDLobby, iLobbyData, intPtr, cchKeyBufferSize, intPtr2, cchValueBufferSize);
			pchKey = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			pchValue = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr2));
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			return flag;
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x0000580B File Offset: 0x00003A0B
		public static bool DeleteLobbyData(CSteamID steamIDLobby, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_DeleteLobbyData(steamIDLobby, pchKey);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00005819 File Offset: 0x00003A19
		public static string GetLobbyMemberData(CSteamID steamIDLobby, CSteamID steamIDUser, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyMemberData(steamIDLobby, steamIDUser, pchKey);
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00005828 File Offset: 0x00003A28
		public static void SetLobbyMemberData(CSteamID steamIDLobby, string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_SetLobbyMemberData(steamIDLobby, pchKey, pchValue);
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00005837 File Offset: 0x00003A37
		public static bool SendLobbyChatMsg(CSteamID steamIDLobby, byte[] pvMsgBody, int cubMsgBody)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SendLobbyChatMsg(steamIDLobby, pvMsgBody, cubMsgBody);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00005846 File Offset: 0x00003A46
		public static int GetLobbyChatEntry(CSteamID steamIDLobby, int iChatID, out CSteamID pSteamIDUser, byte[] pvData, int cubData, out EChatEntryType peChatEntryType)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyChatEntry(steamIDLobby, iChatID, out pSteamIDUser, pvData, cubData, out peChatEntryType);
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x0000585A File Offset: 0x00003A5A
		public static bool RequestLobbyData(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_RequestLobbyData(steamIDLobby);
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00005867 File Offset: 0x00003A67
		public static void SetLobbyGameServer(CSteamID steamIDLobby, uint unGameServerIP, ushort unGameServerPort, CSteamID steamIDGameServer)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamMatchmaking_SetLobbyGameServer(steamIDLobby, unGameServerIP, unGameServerPort, steamIDGameServer);
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00005877 File Offset: 0x00003A77
		public static bool GetLobbyGameServer(CSteamID steamIDLobby, out uint punGameServerIP, out ushort punGameServerPort, out CSteamID psteamIDGameServer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyGameServer(steamIDLobby, out punGameServerIP, out punGameServerPort, out psteamIDGameServer);
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00005887 File Offset: 0x00003A87
		public static bool SetLobbyMemberLimit(CSteamID steamIDLobby, int cMaxMembers)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyMemberLimit(steamIDLobby, cMaxMembers);
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00005895 File Offset: 0x00003A95
		public static int GetLobbyMemberLimit(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_GetLobbyMemberLimit(steamIDLobby);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x000058A2 File Offset: 0x00003AA2
		public static bool SetLobbyType(CSteamID steamIDLobby, ELobbyType eLobbyType)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyType(steamIDLobby, eLobbyType);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x000058B0 File Offset: 0x00003AB0
		public static bool SetLobbyJoinable(CSteamID steamIDLobby, bool bLobbyJoinable)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyJoinable(steamIDLobby, bLobbyJoinable);
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x000058BE File Offset: 0x00003ABE
		public static CSteamID GetLobbyOwner(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamMatchmaking_GetLobbyOwner(steamIDLobby);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x000058D0 File Offset: 0x00003AD0
		public static bool SetLobbyOwner(CSteamID steamIDLobby, CSteamID steamIDNewOwner)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLobbyOwner(steamIDLobby, steamIDNewOwner);
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x000058DE File Offset: 0x00003ADE
		public static bool SetLinkedLobby(CSteamID steamIDLobby, CSteamID steamIDLobbyDependent)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamMatchmaking_SetLinkedLobby(steamIDLobby, steamIDLobbyDependent);
		}
	}
}
