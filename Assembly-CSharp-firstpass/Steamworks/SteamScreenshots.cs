using System;

namespace Steamworks
{
	// Token: 0x020001AC RID: 428
	public static class SteamScreenshots
	{
		// Token: 0x06000944 RID: 2372 RVA: 0x00006141 File Offset: 0x00004341
		public static ScreenshotHandle WriteScreenshot(byte[] pubRGB, uint cubRGB, int nWidth, int nHeight)
		{
			InteropHelp.TestIfAvailableClient();
			return (ScreenshotHandle)NativeMethods.ISteamScreenshots_WriteScreenshot(pubRGB, cubRGB, nWidth, nHeight);
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00006156 File Offset: 0x00004356
		public static ScreenshotHandle AddScreenshotToLibrary(string pchFilename, string pchThumbnailFilename, int nWidth, int nHeight)
		{
			InteropHelp.TestIfAvailableClient();
			return (ScreenshotHandle)NativeMethods.ISteamScreenshots_AddScreenshotToLibrary(pchFilename, pchThumbnailFilename, nWidth, nHeight);
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0000616B File Offset: 0x0000436B
		public static void TriggerScreenshot()
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamScreenshots_TriggerScreenshot();
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00006177 File Offset: 0x00004377
		public static void HookScreenshots(bool bHook)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamScreenshots_HookScreenshots(bHook);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00006184 File Offset: 0x00004384
		public static bool SetLocation(ScreenshotHandle hScreenshot, string pchLocation)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamScreenshots_SetLocation(hScreenshot, pchLocation);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00006192 File Offset: 0x00004392
		public static bool TagUser(ScreenshotHandle hScreenshot, CSteamID steamID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamScreenshots_TagUser(hScreenshot, steamID);
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x000061A0 File Offset: 0x000043A0
		public static bool TagPublishedFile(ScreenshotHandle hScreenshot, PublishedFileId_t unPublishedFileID)
		{
			InteropHelp.TestIfAvailableClient();
			return NativeMethods.ISteamScreenshots_TagPublishedFile(hScreenshot, unPublishedFileID);
		}
	}
}
