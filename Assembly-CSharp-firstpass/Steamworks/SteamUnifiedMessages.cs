using System;

namespace Steamworks
{
	// Token: 0x020001AE RID: 430
	public static class SteamUnifiedMessages
	{
		// Token: 0x0600096A RID: 2410 RVA: 0x00006395 File Offset: 0x00004595
		public static ClientUnifiedMessageHandle SendMethod(string pchServiceMethod, byte[] pRequestBuffer, uint unRequestBufferSize, ulong unContext)
		{
			InteropHelp.TestIfAvailableClient();
			return (ClientUnifiedMessageHandle)NativeMethods.ISteamUnifiedMessages_SendMethod(pchServiceMethod, pRequestBuffer, unRequestBufferSize, unContext);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x000063AA File Offset: 0x000045AA
		public static bool GetMethodResponseInfo(ClientUnifiedMessageHandle hHandle, out uint punResponseSize, out EResult peResult)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUnifiedMessages_GetMethodResponseInfo(hHandle, out punResponseSize, out peResult);
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x000063B9 File Offset: 0x000045B9
		public static bool GetMethodResponseData(ClientUnifiedMessageHandle hHandle, byte[] pResponseBuffer, uint unResponseBufferSize, bool bAutoRelease)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUnifiedMessages_GetMethodResponseData(hHandle, pResponseBuffer, unResponseBufferSize, bAutoRelease);
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x000063C9 File Offset: 0x000045C9
		public static bool ReleaseMethod(ClientUnifiedMessageHandle hHandle)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUnifiedMessages_ReleaseMethod(hHandle);
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x000063D6 File Offset: 0x000045D6
		public static bool SendNotification(string pchServiceNotification, byte[] pNotificationBuffer, uint unNotificationBufferSize)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamUnifiedMessages_SendNotification(pchServiceNotification, pNotificationBuffer, unNotificationBufferSize);
		}
	}
}
