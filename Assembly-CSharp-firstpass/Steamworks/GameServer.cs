using System;

namespace Steamworks
{
	// Token: 0x020000A1 RID: 161
	public static class GameServer
	{
		// Token: 0x06000438 RID: 1080 RVA: 0x000041A5 File Offset: 0x000023A5
		public static bool InitSafe(uint unIP, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string pchVersionString)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamGameServer_InitSafe(unIP, usSteamPort, usGamePort, usQueryPort, eServerMode, pchVersionString);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x000041A5 File Offset: 0x000023A5
		public static bool Init(uint unIP, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, string pchVersionString)
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamGameServer_InitSafe(unIP, usSteamPort, usGamePort, usQueryPort, eServerMode, pchVersionString);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000041B9 File Offset: 0x000023B9
		public static void Shutdown()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_Shutdown();
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000041C5 File Offset: 0x000023C5
		public static void RunCallbacks()
		{
			InteropHelp.TestIfPlatformSupported();
			NativeMethods.SteamGameServer_RunCallbacks();
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000041D1 File Offset: 0x000023D1
		public static bool BSecure()
		{
			InteropHelp.TestIfPlatformSupported();
			return NativeMethods.SteamGameServer_BSecure();
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x000041DD File Offset: 0x000023DD
		public static CSteamID GetSteamID()
		{
			InteropHelp.TestIfPlatformSupported();
			return (CSteamID)NativeMethods.SteamGameServer_GetSteamID();
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000041EE File Offset: 0x000023EE
		public static HSteamPipe GetHSteamPipe()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamPipe)NativeMethods.SteamGameServer_GetHSteamPipe();
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000041FF File Offset: 0x000023FF
		public static HSteamUser GetHSteamUser()
		{
			InteropHelp.TestIfPlatformSupported();
			return (HSteamUser)NativeMethods.SteamGameServer_GetHSteamUser();
		}
	}
}
