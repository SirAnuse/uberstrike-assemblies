using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020001B1 RID: 433
	public static class SteamUtils
	{
		// Token: 0x060009B3 RID: 2483 RVA: 0x000067AF File Offset: 0x000049AF
		public static uint GetSecondsSinceAppActive()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSecondsSinceAppActive();
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x000067BB File Offset: 0x000049BB
		public static uint GetSecondsSinceComputerActive()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSecondsSinceComputerActive();
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x000067C7 File Offset: 0x000049C7
		public static EUniverse GetConnectedUniverse()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetConnectedUniverse();
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x000067D3 File Offset: 0x000049D3
		public static uint GetServerRealTime()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetServerRealTime();
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x000067DF File Offset: 0x000049DF
		public static string GetIPCountry()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetIPCountry();
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x000067EB File Offset: 0x000049EB
		public static bool GetImageSize(int iImage, out uint pnWidth, out uint pnHeight)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetImageSize(iImage, out pnWidth, out pnHeight);
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x000067FA File Offset: 0x000049FA
		public static bool GetImageRGBA(int iImage, byte[] pubDest, int nDestBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetImageRGBA(iImage, pubDest, nDestBufferSize);
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x00006809 File Offset: 0x00004A09
		public static bool GetCSERIPPort(out uint unIP, out ushort usPort)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetCSERIPPort(out unIP, out usPort);
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x00006817 File Offset: 0x00004A17
		public static byte GetCurrentBatteryPower()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetCurrentBatteryPower();
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00006823 File Offset: 0x00004A23
		public static AppId_t GetAppID()
		{
			InteropHelp.TestIfAvailableClient();
			return (AppId_t)NativeMethods.ISteamUtils_GetAppID();
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00006834 File Offset: 0x00004A34
		public static void SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetOverlayNotificationPosition(eNotificationPosition);
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00006841 File Offset: 0x00004A41
		public static bool IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsAPICallCompleted(hSteamAPICall, out pbFailed);
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0000684F File Offset: 0x00004A4F
		public static ESteamAPICallFailure GetAPICallFailureReason(SteamAPICall_t hSteamAPICall)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetAPICallFailureReason(hSteamAPICall);
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0000685C File Offset: 0x00004A5C
		public static bool GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetAPICallResult(hSteamAPICall, pCallback, cubCallback, iCallbackExpected, out pbFailed);
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0000686E File Offset: 0x00004A6E
		public static void RunFrame()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_RunFrame();
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0000687A File Offset: 0x00004A7A
		public static uint GetIPCCallCount()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetIPCCallCount();
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00006886 File Offset: 0x00004A86
		public static void SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamUtils_SetWarningMessageHook(pFunction);
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x00006893 File Offset: 0x00004A93
		public static bool IsOverlayEnabled()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsOverlayEnabled();
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0000689F File Offset: 0x00004A9F
		public static bool BOverlayNeedsPresent()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_BOverlayNeedsPresent();
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x000068AB File Offset: 0x00004AAB
		public static SteamAPICall_t CheckFileSignature(string szFileName)
		{
			InteropHelp.TestIfAvailableClient();
			return (SteamAPICall_t)NativeMethods.ISteamUtils_CheckFileSignature(szFileName);
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x000068BD File Offset: 0x00004ABD
		public static bool ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, string pchDescription, uint unCharMax, string pchExistingText)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_ShowGamepadTextInput(eInputMode, eLineInputMode, pchDescription, unCharMax, pchExistingText);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x000068CF File Offset: 0x00004ACF
		public static uint GetEnteredGamepadTextLength()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetEnteredGamepadTextLength();
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0000FB38 File Offset: 0x0000DD38
		public static bool GetEnteredGamepadTextInput(out string pchText, uint cchText)
		{
			InteropHelp.TestIfAvailableClient();
			IntPtr intPtr = Marshal.AllocHGlobal((int)cchText);
			bool flag = NativeMethods.ISteamUtils_GetEnteredGamepadTextInput(intPtr, cchText);
			pchText = ((!flag) ? null : InteropHelp.PtrToStringUTF8(intPtr));
			Marshal.FreeHGlobal(intPtr);
			return flag;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x000068DB File Offset: 0x00004ADB
		public static string GetSteamUILanguage()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_GetSteamUILanguage();
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x000068E7 File Offset: 0x00004AE7
		public static bool IsSteamRunningInVR()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUtils_IsSteamRunningInVR();
		}
	}
}
