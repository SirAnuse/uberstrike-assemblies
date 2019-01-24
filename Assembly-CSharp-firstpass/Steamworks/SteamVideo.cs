using System;

namespace Steamworks
{
	// Token: 0x020001B2 RID: 434
	public static class SteamVideo
	{
		// Token: 0x060009CC RID: 2508 RVA: 0x000068F3 File Offset: 0x00004AF3
		public static void GetVideoURL(AppId_t unVideoAppID)
		{
			InteropHelp.TestIfAvailableClient();
			NativeMethods.ISteamVideo_GetVideoURL(unVideoAppID);
		}
	}
}
