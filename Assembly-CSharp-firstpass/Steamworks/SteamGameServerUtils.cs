using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001A2 RID: 418
	public static class SteamGameServerUtils
	{
		// Token: 0x06000830 RID: 2096 RVA: 0x000050EB File Offset: 0x000032EB
		public static uint GetSecondsSinceAppActive()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetSecondsSinceAppActive();
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x000050F7 File Offset: 0x000032F7
		public static uint GetSecondsSinceComputerActive()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetSecondsSinceComputerActive();
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x00005103 File Offset: 0x00003303
		public static EUniverse GetConnectedUniverse()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetConnectedUniverse();
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0000510F File Offset: 0x0000330F
		public static uint GetServerRealTime()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetServerRealTime();
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0000511B File Offset: 0x0000331B
		public static string GetIPCountry()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetIPCountry();
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x00005127 File Offset: 0x00003327
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetImageSize(iImage, out pnWidth, out pnHeight);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00005136 File Offset: 0x00003336
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetImageRGBA(iImage, pubDest, nDestBufferSize);
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x00005145 File Offset: 0x00003345
		public static bool GetCSERIPPort(out uint unIP, out ushort usPort)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetCSERIPPort(out unIP, out usPort);
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x00005153 File Offset: 0x00003353
		public static byte GetCurrentBatteryPower()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetCurrentBatteryPower();
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0000515F File Offset: 0x0000335F
		public static AppId_t GetAppID()
		{
			InteropHelp.TestIfAvailableGameServer();
			return (AppId_t)NativeMethods.ISteamGameServerUtils_GetAppID();
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x00005170 File Offset: 0x00003370
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServerUtils_SetOverlayNotificationPosition(eNotificationPosition);
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0000517D File Offset: 0x0000337D
		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_IsAPICallCompleted(hSteamAPICall, out pbFailed);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0000518B File Offset: 0x0000338B
		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetAPICallFailureReason(hSteamAPICall);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00005198 File Offset: 0x00003398
		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetAPICallResult(hSteamAPICall, pCallback, cubCallback, iCallbackExpected, out pbFailed);
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x000051AA File Offset: 0x000033AA
		public static void RunFrame()
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServerUtils_RunFrame();
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x000051B6 File Offset: 0x000033B6
		public static uint GetIPCCallCount()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetIPCCallCount();
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x000051C2 File Offset: 0x000033C2
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction)
		{
			InteropHelp.TestIfAvailableGameServer();
			NativeMethods.ISteamGameServerUtils_SetWarningMessageHook(pFunction);
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x000051CF File Offset: 0x000033CF
		public static bool IsOverlayEnabled()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_IsOverlayEnabled();
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x000051DB File Offset: 0x000033DB
		public static bool BOverlayNeedsPresent()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_BOverlayNeedsPresent();
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x000051E7 File Offset: 0x000033E7
		public static SteamAPICall_t CheckFileSignature(string szFileName)
		{
			InteropHelp.TestIfAvailableGameServer();
			return (SteamAPICall_t)NativeMethods.ISteamGameServerUtils_CheckFileSignature(szFileName);
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x000051F9 File Offset: 0x000033F9
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText)
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_ShowGamepadTextInput(eInputMode, eLineInputMode, pchDescription, unCharMax, pchExistingText);
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0000520B File Offset: 0x0000340B
		public static uint GetEnteredGamepadTextLength()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetEnteredGamepadTextLength();
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0000F8CC File Offset: 0x0000DACC
		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText)
		{
			InteropHelp.TestIfAvailableGameServer();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchText);
			bool flag = NativeMethods.ISteamGameServerUtils_GetEnteredGamepadTextInput(intPtr, cchText);
			pchText = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00005217 File Offset: 0x00003417
		public static string GetSteamUILanguage()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_GetSteamUILanguage();
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x00005223 File Offset: 0x00003423
		public static bool IsSteamRunningInVR()
		{
			InteropHelp.TestIfAvailableGameServer();
			return NativeMethods.ISteamGameServerUtils_IsSteamRunningInVR();
		}
	}
}
