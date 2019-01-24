using System;

namespace Steamworks
{
	// Token: 0x020001A0 RID: 416
	public static class SteamGameServerNetworking
	{
		// Token: 0x06000810 RID: 2064 RVA: 0x00004EF7 File Offset: 0x000030F7
		public static bool SendP2PPacket(CSteamID steamIDRemote, byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_SendP2PPacket(steamIDRemote, pubData, cubData, eP2PSendType, nChannel);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00004F09 File Offset: 0x00003109
		public static bool IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_IsP2PPacketAvailable(out pcubMsgSize, nChannel);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00004F17 File Offset: 0x00003117
		public static bool ReadP2PPacket(byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_ReadP2PPacket(pubDest, cubDest, out pcubMsgSize, out psteamIDRemote, nChannel);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00004F29 File Offset: 0x00003129
		public static bool AcceptP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_AcceptP2PSessionWithUser(steamIDRemote);
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00004F36 File Offset: 0x00003136
		public static bool CloseP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_CloseP2PSessionWithUser(steamIDRemote);
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00004F43 File Offset: 0x00003143
		public static bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_CloseP2PChannelWithUser(steamIDRemote, nChannel);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00004F51 File Offset: 0x00003151
		public static bool GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_GetP2PSessionState(steamIDRemote, out pConnectionState);
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00004F5F File Offset: 0x0000315F
		public static bool AllowP2PPacketRelay(bool bAllow)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_AllowP2PPacketRelay(bAllow);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00004F6C File Offset: 0x0000316C
		public static SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, uint nIP, ushort nPort, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetListenSocket_t)NativeMethods.ISteamGameServerNetworking_CreateListenSocket(nVirtualP2PPort, nIP, nPort, bAllowUseOfPacketRelay);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00004F81 File Offset: 0x00003181
		public static SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetSocket_t)NativeMethods.ISteamGameServerNetworking_CreateP2PConnectionSocket(steamIDTarget, nVirtualPort, nTimeoutSec, bAllowUseOfPacketRelay);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00004F96 File Offset: 0x00003196
		public static SNetSocket_t CreateConnectionSocket(uint nIP, ushort nPort, int nTimeoutSec)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SNetSocket_t)NativeMethods.ISteamGameServerNetworking_CreateConnectionSocket(nIP, nPort, nTimeoutSec);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x00004FAA File Offset: 0x000031AA
		public static bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_DestroySocket(hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00004FB8 File Offset: 0x000031B8
		public static bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_DestroyListenSocket(hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00004FC6 File Offset: 0x000031C6
		public static bool SendDataOnSocket(SNetSocket_t hSocket, IntPtr pubData, uint cubData, bool bReliable)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_SendDataOnSocket(hSocket, pubData, cubData, bReliable);
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00004FD6 File Offset: 0x000031D6
		public static bool IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_IsDataAvailableOnSocket(hSocket, out pcubMsgSize);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00004FE4 File Offset: 0x000031E4
		public static bool RetrieveDataFromSocket(SNetSocket_t hSocket, IntPtr pubDest, uint cubDest, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_RetrieveDataFromSocket(hSocket, pubDest, cubDest, out pcubMsgSize);
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00004FF4 File Offset: 0x000031F4
		public static bool IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_IsDataAvailable(hListenSocket, out pcubMsgSize, out phSocket);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00005003 File Offset: 0x00003203
		public static bool RetrieveData(SNetListenSocket_t hListenSocket, IntPtr pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_RetrieveData(hListenSocket, pubDest, cubDest, out pcubMsgSize, out phSocket);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x00005015 File Offset: 0x00003215
		public static bool GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out uint punIPRemote, out ushort punPortRemote)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_GetSocketInfo(hSocket, out pSteamIDRemote, out peSocketStatus, out punIPRemote, out punPortRemote);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x00005027 File Offset: 0x00003227
		public static bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, out uint pnIP, out ushort pnPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_GetListenSocketInfo(hListenSocket, out pnIP, out pnPort);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00005036 File Offset: 0x00003236
		public static ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_GetSocketConnectionType(hSocket);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00005043 File Offset: 0x00003243
		public static int GetMaxPacketSize(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerNetworking_GetMaxPacketSize(hSocket);
		}
	}
}
