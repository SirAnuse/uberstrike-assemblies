using System;

namespace Steamworks
{
	// Token: 0x0200019B RID: 411
	public static class SteamController
	{
		// Token: 0x06000769 RID: 1897 RVA: 0x000045D1 File Offset: 0x000027D1
		public static bool Init(string pchAbsolutePathToControllerConfigVDF)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_Init(pchAbsolutePathToControllerConfigVDF);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x000045DE File Offset: 0x000027DE
		public static bool Shutdown()
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_Shutdown();
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x000045EA File Offset: 0x000027EA
		public static void RunFrame()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_RunFrame();
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x000045F6 File Offset: 0x000027F6
		public static bool GetControllerState(uint unControllerIndex, out SteamControllerState_t pState)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamController_GetControllerState(unControllerIndex, out pState);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00004604 File Offset: 0x00002804
		public static void TriggerHapticPulse(uint unControllerIndex, ESteamControllerPad eTargetPad, ushort usDurationMicroSec)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_TriggerHapticPulse(unControllerIndex, eTargetPad, usDurationMicroSec);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00004613 File Offset: 0x00002813
		public static void SetOverrideMode(string pchMode)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamController_SetOverrideMode(pchMode);
		}
	}
}
