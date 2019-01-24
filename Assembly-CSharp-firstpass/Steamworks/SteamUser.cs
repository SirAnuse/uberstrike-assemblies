using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001AF RID: 431
	public static class SteamUser
	{
		// Token: 0x0600096F RID: 2415 RVA: 0x000063E5 File Offset: 0x000045E5
		public static HSteamUser GetHSteamUser()
		{
			InteropHelp.TestIfAvailableClient();
			return (HSteamUser)NativeMethods.ISteamUser_GetHSteamUser();
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x000063F6 File Offset: 0x000045F6
		public static bool BLoggedOn()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BLoggedOn();
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x00006402 File Offset: 0x00004602
		public static CSteamID GetSteamID()
		{
			InteropHelp.TestIfAvailableClient();
			return (CSteamID)NativeMethods.ISteamUser_GetSteamID();
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x00006413 File Offset: 0x00004613
		public static int InitiateGameConnection(byte[] pAuthBlob, int cbMaxAuthBlob, CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer, bool bSecure)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_InitiateGameConnection(pAuthBlob, cbMaxAuthBlob, steamIDGameServer, unIPServer, usPortServer, bSecure);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00006427 File Offset: 0x00004627
		public static void TerminateGameConnection(uint unIPServer, ushort usPortServer)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_TerminateGameConnection(unIPServer, usPortServer);
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x00006435 File Offset: 0x00004635
		public static void TrackAppUsageEvent(CGameID gameID, int eAppUsageEvent, string pchExtraInfo = "")
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_TrackAppUsageEvent(gameID, eAppUsageEvent, pchExtraInfo);
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x0000FA54 File Offset: 0x0000DC54
		public static bool GetUserDataFolder(out string pchBuffer, int cubBuffer)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal(cubBuffer);
			bool flag = NativeMethods.ISteamUser_GetUserDataFolder(intPtr, cubBuffer);
			pchBuffer = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00006444 File Offset: 0x00004644
		public static void StartVoiceRecording()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_StartVoiceRecording();
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00006450 File Offset: 0x00004650
		public static void StopVoiceRecording()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_StopVoiceRecording();
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x0000645C File Offset: 0x0000465C
		public static EVoiceResult GetAvailableVoice(out uint pcbCompressed, out uint pcbUncompressed, uint nUncompressedVoiceDesiredSampleRate)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetAvailableVoice(out pcbCompressed, out pcbUncompressed, nUncompressedVoiceDesiredSampleRate);
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x0000FA90 File Offset: 0x0000DC90
		public static EVoiceResult GetVoice(bool bWantCompressed, byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten, bool bWantUncompressed, byte[] pUncompressedDestBuffer, uint cbUncompressedDestBufferSize, out uint nUncompressBytesWritten, uint nUncompressedVoiceDesiredSampleRate)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetVoice(bWantCompressed, pDestBuffer, cbDestBufferSize, out nBytesWritten, bWantUncompressed, pUncompressedDestBuffer, cbUncompressedDestBufferSize, out nUncompressBytesWritten, nUncompressedVoiceDesiredSampleRate);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x0000646B File Offset: 0x0000466B
		public static EVoiceResult DecompressVoice(byte[] pCompressed, uint cbCompressed, byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten, uint nDesiredSampleRate)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_DecompressVoice(pCompressed, cbCompressed, pDestBuffer, cbDestBufferSize, out nBytesWritten, nDesiredSampleRate);
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0000647F File Offset: 0x0000467F
		public static uint GetVoiceOptimalSampleRate()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetVoiceOptimalSampleRate();
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0000648B File Offset: 0x0000468B
		public static HAuthTicket GetAuthSessionTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket)
		{
			InteropHelp.TestIfAvailableClient();
			return (HAuthTicket)NativeMethods.ISteamUser_GetAuthSessionTicket(pTicket, cbMaxTicket, out pcbTicket);
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0000649F File Offset: 0x0000469F
		public static EBeginAuthSessionResult BeginAuthSession(byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BeginAuthSession(pAuthTicket, cbAuthTicket, steamID);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x000064AE File Offset: 0x000046AE
		public static void EndAuthSession(CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_EndAuthSession(steamID);
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x000064BB File Offset: 0x000046BB
		public static void CancelAuthTicket(HAuthTicket hAuthTicket)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_CancelAuthTicket(hAuthTicket);
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x000064C8 File Offset: 0x000046C8
		public static EUserHasLicenseForAppResult UserHasLicenseForApp(CSteamID steamID, AppId_t appID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_UserHasLicenseForApp(steamID, appID);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x000064D6 File Offset: 0x000046D6
		public static bool BIsBehindNAT()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_BIsBehindNAT();
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x000064E2 File Offset: 0x000046E2
		public static void AdvertiseGame(CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUser_AdvertiseGame(steamIDGameServer, unIPServer, usPortServer);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x000064F1 File Offset: 0x000046F1
		public static SteamAPICall_t RequestEncryptedAppTicket(byte[] pDataToInclude, int cbDataToInclude)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUser_RequestEncryptedAppTicket(pDataToInclude, cbDataToInclude);
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x00006504 File Offset: 0x00004704
		public static bool GetEncryptedAppTicket(byte[] pTicket, int cbMaxTicket, out uint pcbTicket)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetEncryptedAppTicket(pTicket, cbMaxTicket, out pcbTicket);
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00006513 File Offset: 0x00004713
		public static int GetGameBadgeLevel(int nSeries, bool bFoil)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetGameBadgeLevel(nSeries, bFoil);
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00006521 File Offset: 0x00004721
		public static int GetPlayerSteamLevel()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUser_GetPlayerSteamLevel();
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0000652D File Offset: 0x0000472D
		public static SteamAPICall_t RequestStoreAuthURL(string pchRedirectURL)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUser_RequestStoreAuthURL(pchRedirectURL);
		}
	}
}
