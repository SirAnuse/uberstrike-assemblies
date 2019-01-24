using System;

namespace Steamworks
{
	// Token: 0x020000A0 RID: 160
	public static class SteamAPI
	{
		// Token: 0x0600042F RID: 1071 RVA: 0x0000410F File Offset: 0x0000230F
		public static bool RestartAppIfNecessary(AppId_t unOwnAppID)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamAPI_RestartAppIfNecessary(unOwnAppID);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000411C File Offset: 0x0000231C
		public static bool InitSafe()
		{
			return SteamAPI.Init();
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00004123 File Offset: 0x00002323
		public static bool Init()
		{
			if (SteamAPI._initialized)
			{
				throw new Exception("Tried to Initialize Steamworks twice in one session!");
			}
			InteropHelp.TestIfPlatformSupported();
			SteamAPI._initialized = NativeMethods.SteamAPI_InitSafe();
			return SteamAPI._initialized;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0000414E File Offset: 0x0000234E
		public static void Shutdown()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamAPI_Shutdown();
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0000415A File Offset: 0x0000235A
		public static void RunCallbacks()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamAPI_RunCallbacks();
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00004166 File Offset: 0x00002366
		public static bool IsSteamRunning()
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamAPI_IsSteamRunning();
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00004172 File Offset: 0x00002372
		public static HSteamUser GetHSteamUserCurrent()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.Steam_GetHSteamUserCurrent();
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00004183 File Offset: 0x00002383
		public static HSteamPipe GetHSteamPipe()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamPipe)NativeMethods.SteamAPI_GetHSteamPipe();
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00004194 File Offset: 0x00002394
		public static HSteamUser GetHSteamUser()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.SteamAPI_GetHSteamUser();
		}

		// Token: 0x04000341 RID: 833
		private static bool _initialized;
	}
}
