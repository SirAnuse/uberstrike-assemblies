using System;

namespace Steamworks
{
	// Token: 0x020001AA RID: 426
	public static class SteamNetworking
	{
		// Token: 0x060008FA RID: 2298 RVA: 0x00005C8A File Offset: 0x00003E8A
		public static bool SendP2PPacket(CSteamID steamIDRemote, byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_SendP2PPacket(steamIDRemote, pubData, cubData, eP2PSendType, nChannel);
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00005C9C File Offset: 0x00003E9C
		public static bool IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_IsP2PPacketAvailable(out pcubMsgSize, nChannel);
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00005CAA File Offset: 0x00003EAA
		public static bool ReadP2PPacket(byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel = 0)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_ReadP2PPacket(pubDest, cubDest, out pcubMsgSize, out psteamIDRemote, nChannel);
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00005CBC File Offset: 0x00003EBC
		public static bool AcceptP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_AcceptP2PSessionWithUser(steamIDRemote);
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00005CC9 File Offset: 0x00003EC9
		public static bool CloseP2PSessionWithUser(CSteamID steamIDRemote)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_CloseP2PSessionWithUser(steamIDRemote);
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00005CD6 File Offset: 0x00003ED6
		public static bool CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_CloseP2PChannelWithUser(steamIDRemote, nChannel);
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00005CE4 File Offset: 0x00003EE4
		public static bool GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetP2PSessionState(steamIDRemote, out pConnectionState);
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00005CF2 File Offset: 0x00003EF2
		public static bool AllowP2PPacketRelay(bool bAllow)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_AllowP2PPacketRelay(bAllow);
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00005CFF File Offset: 0x00003EFF
		public static SNetListenSocket_t CreateListenSocket(int nVirtualP2PPort, uint nIP, ushort nPort, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableClient();
			return (SNetListenSocket_t)NativeMethods.ISteamNetworking_CreateListenSocket(nVirtualP2PPort, nIP, nPort, bAllowUseOfPacketRelay);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00005D14 File Offset: 0x00003F14
		public static SNetSocket_t CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, bool bAllowUseOfPacketRelay)
		{
			InteropHelp.TestIfAvailableClient();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateP2PConnectionSocket(steamIDTarget, nVirtualPort, nTimeoutSec, bAllowUseOfPacketRelay);
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00005D29 File Offset: 0x00003F29
		public static SNetSocket_t CreateConnectionSocket(uint nIP, ushort nPort, int nTimeoutSec)
		{
			InteropHelp.TestIfAvailableClient();
			return (SNetSocket_t)NativeMethods.ISteamNetworking_CreateConnectionSocket(nIP, nPort, nTimeoutSec);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00005D3D File Offset: 0x00003F3D
		public static bool DestroySocket(SNetSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_DestroySocket(hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x00005D4B File Offset: 0x00003F4B
		public static bool DestroyListenSocket(SNetListenSocket_t hSocket, bool bNotifyRemoteEnd)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_DestroyListenSocket(hSocket, bNotifyRemoteEnd);
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00005D59 File Offset: 0x00003F59
		public static bool SendDataOnSocket(SNetSocket_t hSocket, IntPtr pubData, uint cubData, bool bReliable)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_SendDataOnSocket(hSocket, pubData, cubData, bReliable);
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00005D69 File Offset: 0x00003F69
		public static bool IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_IsDataAvailableOnSocket(hSocket, out pcubMsgSize);
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00005D77 File Offset: 0x00003F77
		public static bool RetrieveDataFromSocket(SNetSocket_t hSocket, IntPtr pubDest, uint cubDest, out uint pcubMsgSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_RetrieveDataFromSocket(hSocket, pubDest, cubDest, out pcubMsgSize);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00005D87 File Offset: 0x00003F87
		public static bool IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_IsDataAvailable(hListenSocket, out pcubMsgSize, out phSocket);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00005D96 File Offset: 0x00003F96
		public static bool RetrieveData(SNetListenSocket_t hListenSocket, IntPtr pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_RetrieveData(hListenSocket, pubDest, cubDest, out pcubMsgSize, out phSocket);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00005DA8 File Offset: 0x00003FA8
		public static bool GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out uint punIPRemote, out ushort punPortRemote)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetSocketInfo(hSocket, out pSteamIDRemote, out peSocketStatus, out punIPRemote, out punPortRemote);
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00005DBA File Offset: 0x00003FBA
		public static bool GetListenSocketInfo(SNetListenSocket_t hListenSocket, out uint pnIP, out ushort pnPort)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetListenSocketInfo(hListenSocket, out pnIP, out pnPort);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00005DC9 File Offset: 0x00003FC9
		public static ESNetSocketConnectionType GetSocketConnectionType(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetSocketConnectionType(hSocket);
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00005DD6 File Offset: 0x00003FD6
		public static int GetMaxPacketSize(SNetSocket_t hSocket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamNetworking_GetMaxPacketSize(hSocket);
		}
	}
}
