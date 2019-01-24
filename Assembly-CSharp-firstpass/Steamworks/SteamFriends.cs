using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x0200019C RID: 412
	public static class SteamFriends
	{
		// Token: 0x0600076F RID: 1903 RVA: 0x00004620 File Offset: 0x00002820
		public static string GetPersonaName()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetPersonaName();
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0000462C File Offset: 0x0000282C
		public static SteamAPICall_t SetPersonaName(string pchPersonaName)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamFriends_SetPersonaName(pchPersonaName);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0000463E File Offset: 0x0000283E
		public static EPersonaState GetPersonaState()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetPersonaState();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0000464A File Offset: 0x0000284A
		public static int GetFriendCount(EFriendFlags iFriendFlags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendCount(iFriendFlags);
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00004657 File Offset: 0x00002857
		public static CSteamID GetFriendByIndex(int iFriend, EFriendFlags iFriendFlags)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamFriends_GetFriendByIndex(iFriend, iFriendFlags);
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0000466A File Offset: 0x0000286A
		public static EFriendRelationship GetFriendRelationship(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendRelationship(steamIDFriend);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00004677 File Offset: 0x00002877
		public static EPersonaState GetFriendPersonaState(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendPersonaState(steamIDFriend);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00004684 File Offset: 0x00002884
		public static string GetFriendPersonaName(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendPersonaName(steamIDFriend);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00004691 File Offset: 0x00002891
		public static bool GetFriendGamePlayed(CSteamID steamIDFriend, out FriendGameInfo_t pFriendGameInfo)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendGamePlayed(steamIDFriend, out pFriendGameInfo);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0000469F File Offset: 0x0000289F
		public static string GetFriendPersonaNameHistory(CSteamID steamIDFriend, int iPersonaName)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendPersonaNameHistory(steamIDFriend, iPersonaName);
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x000046AD File Offset: 0x000028AD
		public static int GetFriendSteamLevel(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendSteamLevel(steamIDFriend);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x000046BA File Offset: 0x000028BA
		public static string GetPlayerNickname(CSteamID steamIDPlayer)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetPlayerNickname(steamIDPlayer);
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x000046C7 File Offset: 0x000028C7
		public static int GetFriendsGroupCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendsGroupCount();
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x000046D3 File Offset: 0x000028D3
		public static FriendsGroupID_t GetFriendsGroupIDByIndex(int iFG)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendsGroupIDByIndex(iFG);
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x000046E0 File Offset: 0x000028E0
		public static string GetFriendsGroupName(FriendsGroupID_t friendsGroupID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendsGroupName(friendsGroupID);
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x000046ED File Offset: 0x000028ED
		public static int GetFriendsGroupMembersCount(FriendsGroupID_t friendsGroupID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendsGroupMembersCount(friendsGroupID);
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x000046FA File Offset: 0x000028FA
		public static void GetFriendsGroupMembersList(FriendsGroupID_t friendsGroupID, CSteamID[] pOutSteamIDMembers, int nMembersCount)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_GetFriendsGroupMembersList(friendsGroupID, pOutSteamIDMembers, nMembersCount);
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x00004709 File Offset: 0x00002909
		public static bool HasFriend(CSteamID steamIDFriend, EFriendFlags iFriendFlags)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_HasFriend(steamIDFriend, iFriendFlags);
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00004717 File Offset: 0x00002917
		public static int GetClanCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetClanCount();
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00004723 File Offset: 0x00002923
		public static CSteamID GetClanByIndex(int iClan)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamFriends_GetClanByIndex(iClan);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00004735 File Offset: 0x00002935
		public static string GetClanName(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetClanName(steamIDClan);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00004742 File Offset: 0x00002942
		public static string GetClanTag(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetClanTag(steamIDClan);
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0000474F File Offset: 0x0000294F
		public static bool GetClanActivityCounts(CSteamID steamIDClan, out int pnOnline, out int pnInGame, out int pnChatting)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetClanActivityCounts(steamIDClan, out pnOnline, out pnInGame, out pnChatting);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0000475F File Offset: 0x0000295F
		public static SteamAPICall_t DownloadClanActivityCounts(CSteamID[] psteamIDClans, int cClansToRequest)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamFriends_DownloadClanActivityCounts(psteamIDClans, cClansToRequest);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00004772 File Offset: 0x00002972
		public static int GetFriendCountFromSource(CSteamID steamIDSource)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendCountFromSource(steamIDSource);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0000477F File Offset: 0x0000297F
		public static CSteamID GetFriendFromSourceByIndex(CSteamID steamIDSource, int iFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamFriends_GetFriendFromSourceByIndex(steamIDSource, iFriend);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00004792 File Offset: 0x00002992
		public static bool IsUserInSource(CSteamID steamIDUser, CSteamID steamIDSource)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_IsUserInSource(steamIDUser, steamIDSource);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x000047A0 File Offset: 0x000029A0
		public static void SetInGameVoiceSpeaking(CSteamID steamIDUser, bool bSpeaking)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_SetInGameVoiceSpeaking(steamIDUser, bSpeaking);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x000047AE File Offset: 0x000029AE
		public static void ActivateGameOverlay(string pchDialog)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_ActivateGameOverlay(pchDialog);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x000047BB File Offset: 0x000029BB
		public static void ActivateGameOverlayToUser(string pchDialog, CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_ActivateGameOverlayToUser(pchDialog, steamID);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x000047C9 File Offset: 0x000029C9
		public static void ActivateGameOverlayToWebPage(string pchURL)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_ActivateGameOverlayToWebPage(pchURL);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x000047D6 File Offset: 0x000029D6
		public static void ActivateGameOverlayToStore(AppId_t nAppID, EOverlayToStoreFlag eFlag)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_ActivateGameOverlayToStore(nAppID, eFlag);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x000047E4 File Offset: 0x000029E4
		public static void SetPlayedWith(CSteamID steamIDUserPlayedWith)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_SetPlayedWith(steamIDUserPlayedWith);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x000047F1 File Offset: 0x000029F1
		public static void ActivateGameOverlayInviteDialog(CSteamID steamIDLobby)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_ActivateGameOverlayInviteDialog(steamIDLobby);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x000047FE File Offset: 0x000029FE
		public static int GetSmallFriendAvatar(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetSmallFriendAvatar(steamIDFriend);
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0000480B File Offset: 0x00002A0B
		public static int GetMediumFriendAvatar(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetMediumFriendAvatar(steamIDFriend);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00004818 File Offset: 0x00002A18
		public static int GetLargeFriendAvatar(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetLargeFriendAvatar(steamIDFriend);
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00004825 File Offset: 0x00002A25
		public static bool RequestUserInformation(CSteamID steamIDUser, bool bRequireNameOnly)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_RequestUserInformation(steamIDUser, bRequireNameOnly);
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00004833 File Offset: 0x00002A33
		public static SteamAPICall_t RequestClanOfficerList(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamFriends_RequestClanOfficerList(steamIDClan);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x00004845 File Offset: 0x00002A45
		public static CSteamID GetClanOwner(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamFriends_GetClanOwner(steamIDClan);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00004857 File Offset: 0x00002A57
		public static int GetClanOfficerCount(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetClanOfficerCount(steamIDClan);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00004864 File Offset: 0x00002A64
		public static CSteamID GetClanOfficerByIndex(CSteamID steamIDClan, int iOfficer)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamFriends_GetClanOfficerByIndex(steamIDClan, iOfficer);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00004877 File Offset: 0x00002A77
		public static uint GetUserRestrictions()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetUserRestrictions();
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00004883 File Offset: 0x00002A83
		public static bool SetRichPresence(string pchKey, string pchValue)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_SetRichPresence(pchKey, pchValue);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00004891 File Offset: 0x00002A91
		public static void ClearRichPresence()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_ClearRichPresence();
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0000489D File Offset: 0x00002A9D
		public static string GetFriendRichPresence(CSteamID steamIDFriend, string pchKey)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendRichPresence(steamIDFriend, pchKey);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x000048AB File Offset: 0x00002AAB
		public static int GetFriendRichPresenceKeyCount(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendRichPresenceKeyCount(steamIDFriend);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x000048B8 File Offset: 0x00002AB8
		public static string GetFriendRichPresenceKeyByIndex(CSteamID steamIDFriend, int iKey)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendRichPresenceKeyByIndex(steamIDFriend, iKey);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x000048C6 File Offset: 0x00002AC6
		public static void RequestFriendRichPresence(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamFriends_RequestFriendRichPresence(steamIDFriend);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x000048D3 File Offset: 0x00002AD3
		public static bool InviteUserToGame(CSteamID steamIDFriend, string pchConnectString)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_InviteUserToGame(steamIDFriend, pchConnectString);
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x000048E1 File Offset: 0x00002AE1
		public static int GetCoplayFriendCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetCoplayFriendCount();
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x000048ED File Offset: 0x00002AED
		public static CSteamID GetCoplayFriend(int iCoplayFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamFriends_GetCoplayFriend(iCoplayFriend);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x000048FF File Offset: 0x00002AFF
		public static int GetFriendCoplayTime(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetFriendCoplayTime(steamIDFriend);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0000490C File Offset: 0x00002B0C
		public static AppId_t GetFriendCoplayGame(CSteamID steamIDFriend)
		{
			InteropHelp.TestIfAvailableClient();
			return (AppId_t)NativeMethods.ISteamFriends_GetFriendCoplayGame(steamIDFriend);
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x0000491E File Offset: 0x00002B1E
		public static SteamAPICall_t JoinClanChatRoom(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamFriends_JoinClanChatRoom(steamIDClan);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00004930 File Offset: 0x00002B30
		public static bool LeaveClanChatRoom(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_LeaveClanChatRoom(steamIDClan);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x0000493D File Offset: 0x00002B3D
		public static int GetClanChatMemberCount(CSteamID steamIDClan)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_GetClanChatMemberCount(steamIDClan);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0000494A File Offset: 0x00002B4A
		public static CSteamID GetChatMemberByIndex(CSteamID steamIDClan, int iUser)
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamFriends_GetChatMemberByIndex(steamIDClan, iUser);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x0000495D File Offset: 0x00002B5D
		public static bool SendClanChatMessage(CSteamID steamIDClanChat, string pchText)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_SendClanChatMessage(steamIDClanChat, pchText);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x0000F808 File Offset: 0x0000DA08
		public static int GetClanChatMessage(CSteamID steamIDClanChat, int iMessage, out string prgchText, int cchTextMax, out EChatEntryType peChatEntryType, out CSteamID psteamidChatter)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cchTextMax);
			int num = NativeMethods.ISteamFriends_GetClanChatMessage(steamIDClanChat, iMessage, intPtr, cchTextMax, out peChatEntryType, out psteamidChatter);
			prgchText = ((num == 0) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0000496B File Offset: 0x00002B6B
		public static bool IsClanChatAdmin(CSteamID steamIDClanChat, CSteamID steamIDUser)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_IsClanChatAdmin(steamIDClanChat, steamIDUser);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00004979 File Offset: 0x00002B79
		public static bool IsClanChatWindowOpenInSteam(CSteamID steamIDClanChat)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_IsClanChatWindowOpenInSteam(steamIDClanChat);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00004986 File Offset: 0x00002B86
		public static bool OpenClanChatWindowInSteam(CSteamID steamIDClanChat)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_OpenClanChatWindowInSteam(steamIDClanChat);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00004993 File Offset: 0x00002B93
		public static bool CloseClanChatWindowInSteam(CSteamID steamIDClanChat)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_CloseClanChatWindowInSteam(steamIDClanChat);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x000049A0 File Offset: 0x00002BA0
		public static bool SetListenForFriendsMessages(bool bInterceptEnabled)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_SetListenForFriendsMessages(bInterceptEnabled);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x000049AD File Offset: 0x00002BAD
		public static bool ReplyToFriendMessage(CSteamID steamIDFriend, string pchMsgToSend)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamFriends_ReplyToFriendMessage(steamIDFriend, pchMsgToSend);
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0000F84C File Offset: 0x0000DA4C
		public static int GetFriendMessage(CSteamID steamIDFriend, int iMessageID, out string pvData, int cubData, out EChatEntryType peChatEntryType)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cubData);
			int num = NativeMethods.ISteamFriends_GetFriendMessage(steamIDFriend, iMessageID, intPtr, cubData, out peChatEntryType);
			pvData = ((num == 0) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return num;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x000049BB File Offset: 0x00002BBB
		public static SteamAPICall_t GetFollowerCount(CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamFriends_GetFollowerCount(steamID);
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x000049CD File Offset: 0x00002BCD
		public static SteamAPICall_t IsFollowing(CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamFriends_IsFollowing(steamID);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x000049DF File Offset: 0x00002BDF
		public static SteamAPICall_t EnumerateFollowingList(uint unStartIndex)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamFriends_EnumerateFollowingList(unStartIndex);
		}
	}
}
