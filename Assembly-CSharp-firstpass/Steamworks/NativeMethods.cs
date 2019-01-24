using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000A3 RID: 163
	internal static class NativeMethods
	{
		// Token: 0x06000448 RID: 1096
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Shutdown")]
		public static extern void SteamAPI_Shutdown();

		// Token: 0x06000449 RID: 1097
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "IsSteamRunning")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SteamAPI_IsSteamRunning();

		// Token: 0x0600044A RID: 1098
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RestartAppIfNecessary")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SteamAPI_RestartAppIfNecessary(AppId_t unOwnAppID);

		// Token: 0x0600044B RID: 1099
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "WriteMiniDump")]
		public static extern void SteamAPI_WriteMiniDump(uint uStructuredExceptionCode, IntPtr pvExceptionInfo, uint uBuildID);

		// Token: 0x0600044C RID: 1100
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetMiniDumpComment")]
		public static extern void SteamAPI_SetMiniDumpComment([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchMsg);

		// Token: 0x0600044D RID: 1101
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamClient_")]
		public static extern IntPtr SteamClient();

		// Token: 0x0600044E RID: 1102
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "InitSafe")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SteamAPI_InitSafe();

		// Token: 0x0600044F RID: 1103
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RunCallbacks")]
		public static extern void SteamAPI_RunCallbacks();

		// Token: 0x06000450 RID: 1104
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RegisterCallback")]
		public static extern void SteamAPI_RegisterCallback(IntPtr pCallback, int iCallback);

		// Token: 0x06000451 RID: 1105
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "UnregisterCallback")]
		public static extern void SteamAPI_UnregisterCallback(IntPtr pCallback);

		// Token: 0x06000452 RID: 1106
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "RegisterCallResult")]
		public static extern void SteamAPI_RegisterCallResult(IntPtr pCallback, ulong hAPICall);

		// Token: 0x06000453 RID: 1107
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "UnregisterCallResult")]
		public static extern void SteamAPI_UnregisterCallResult(IntPtr pCallback, ulong hAPICall);

		// Token: 0x06000454 RID: 1108
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Steam_RunCallbacks_")]
		public static extern void Steam_RunCallbacks(HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.I1)] bool bGameServerCallbacks);

		// Token: 0x06000455 RID: 1109
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Steam_RegisterInterfaceFuncs_")]
		public static extern void Steam_RegisterInterfaceFuncs(IntPtr hModule);

		// Token: 0x06000456 RID: 1110
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "Steam_GetHSteamUserCurrent_")]
		public static extern int Steam_GetHSteamUserCurrent();

		// Token: 0x06000457 RID: 1111
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetSteamInstallPath")]
		public static extern int SteamAPI_GetSteamInstallPath();

		// Token: 0x06000458 RID: 1112
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHSteamPipe_")]
		public static extern int SteamAPI_GetHSteamPipe();

		// Token: 0x06000459 RID: 1113
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetTryCatchCallbacks")]
		public static extern void SteamAPI_SetTryCatchCallbacks([MarshalAs(UnmanagedType.I1)] bool bTryCatchCallbacks);

		// Token: 0x0600045A RID: 1114
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetHSteamUser_")]
		public static extern int SteamAPI_GetHSteamUser();

		// Token: 0x0600045B RID: 1115
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "UseBreakpadCrashHandler")]
		public static extern void SteamAPI_UseBreakpadCrashHandler([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDate, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchTime, [MarshalAs(UnmanagedType.I1)] bool bFullMemoryDumps, IntPtr pvContext, IntPtr m_pfnPreMinidumpCallback);

		// Token: 0x0600045C RID: 1116
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamUser();

		// Token: 0x0600045D RID: 1117
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamFriends();

		// Token: 0x0600045E RID: 1118
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamUtils();

		// Token: 0x0600045F RID: 1119
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamMatchmaking();

		// Token: 0x06000460 RID: 1120
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamUserStats();

		// Token: 0x06000461 RID: 1121
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamApps();

		// Token: 0x06000462 RID: 1122
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamNetworking();

		// Token: 0x06000463 RID: 1123
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamMatchmakingServers();

		// Token: 0x06000464 RID: 1124
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamRemoteStorage();

		// Token: 0x06000465 RID: 1125
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamScreenshots();

		// Token: 0x06000466 RID: 1126
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamHTTP();

		// Token: 0x06000467 RID: 1127
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamUnifiedMessages();

		// Token: 0x06000468 RID: 1128
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamController();

		// Token: 0x06000469 RID: 1129
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamUGC();

		// Token: 0x0600046A RID: 1130
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamAppList();

		// Token: 0x0600046B RID: 1131
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamMusic();

		// Token: 0x0600046C RID: 1132
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamMusicRemote();

		// Token: 0x0600046D RID: 1133
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GameServer_InitSafe")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SteamGameServer_InitSafe(uint unIP, ushort usSteamPort, ushort usGamePort, ushort usQueryPort, EServerMode eServerMode, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersionString);

		// Token: 0x0600046E RID: 1134
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GameServer_Shutdown")]
		public static extern void SteamGameServer_Shutdown();

		// Token: 0x0600046F RID: 1135
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GameServer_RunCallbacks")]
		public static extern void SteamGameServer_RunCallbacks();

		// Token: 0x06000470 RID: 1136
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GameServer_BSecure")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool SteamGameServer_BSecure();

		// Token: 0x06000471 RID: 1137
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GameServer_GetSteamID")]
		public static extern ulong SteamGameServer_GetSteamID();

		// Token: 0x06000472 RID: 1138
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GameServer_GetHSteamPipe")]
		public static extern int SteamGameServer_GetHSteamPipe();

		// Token: 0x06000473 RID: 1139
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GameServer_GetHSteamUser")]
		public static extern int SteamGameServer_GetHSteamUser();

		// Token: 0x06000474 RID: 1140
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamClientGameServer();

		// Token: 0x06000475 RID: 1141
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamGameServer();

		// Token: 0x06000476 RID: 1142
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamGameServerUtils();

		// Token: 0x06000477 RID: 1143
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamGameServerNetworking();

		// Token: 0x06000478 RID: 1144
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamGameServerStats();

		// Token: 0x06000479 RID: 1145
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SteamGameServerHTTP();

		// Token: 0x0600047A RID: 1146
		[DllImport("sdkencryptedappticket", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamEncryptedAppTicket_BDecryptTicket")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool BDecryptTicket([In] [Out] byte[] rgubTicketEncrypted, uint cubTicketEncrypted, [In] [Out] byte[] rgubTicketDecrypted, ref uint pcubTicketDecrypted, [MarshalAs(UnmanagedType.LPArray, SizeConst = 32)] byte[] rgubKey, int cubKey);

		// Token: 0x0600047B RID: 1147
		[DllImport("sdkencryptedappticket", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamEncryptedAppTicket_BIsTicketForApp")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool BIsTicketForApp([In] [Out] byte[] rgubTicketDecrypted, uint cubTicketDecrypted, AppId_t nAppID);

		// Token: 0x0600047C RID: 1148
		[DllImport("sdkencryptedappticket", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamEncryptedAppTicket_GetTicketIssueTime")]
		public static extern uint GetTicketIssueTime([In] [Out] byte[] rgubTicketDecrypted, uint cubTicketDecrypted);

		// Token: 0x0600047D RID: 1149
		[DllImport("sdkencryptedappticket", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamEncryptedAppTicket_GetTicketSteamID")]
		public static extern void GetTicketSteamID([In] [Out] byte[] rgubTicketDecrypted, uint cubTicketDecrypted, out CSteamID psteamID);

		// Token: 0x0600047E RID: 1150
		[DllImport("sdkencryptedappticket", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamEncryptedAppTicket_GetTicketAppID")]
		public static extern uint GetTicketAppID([In] [Out] byte[] rgubTicketDecrypted, uint cubTicketDecrypted);

		// Token: 0x0600047F RID: 1151
		[DllImport("sdkencryptedappticket", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamEncryptedAppTicket_BUserOwnsAppInTicket")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool BUserOwnsAppInTicket([In] [Out] byte[] rgubTicketDecrypted, uint cubTicketDecrypted, AppId_t nAppID);

		// Token: 0x06000480 RID: 1152
		[DllImport("sdkencryptedappticket", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamEncryptedAppTicket_BUserIsVacBanned")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool BUserIsVacBanned([In] [Out] byte[] rgubTicketDecrypted, uint cubTicketDecrypted);

		// Token: 0x06000481 RID: 1153
		[DllImport("sdkencryptedappticket", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SteamEncryptedAppTicket_GetUserVariableData")]
		public static extern IntPtr GetUserVariableData([In] [Out] byte[] rgubTicketDecrypted, uint cubTicketDecrypted, out uint pcubUserData);

		// Token: 0x06000482 RID: 1154
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamAppList_GetNumInstalledApps();

		// Token: 0x06000483 RID: 1155
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamAppList_GetInstalledApps([In] [Out] AppId_t[] pvecAppID, uint unMaxAppIDs);

		// Token: 0x06000484 RID: 1156
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamAppList_GetAppName(AppId_t nAppID, IntPtr pchName, int cchNameMax);

		// Token: 0x06000485 RID: 1157
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamAppList_GetAppInstallDir(AppId_t nAppID, IntPtr pchDirectory, int cchNameMax);

		// Token: 0x06000486 RID: 1158
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamAppList_GetAppBuildId(AppId_t nAppID);

		// Token: 0x06000487 RID: 1159
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BIsSubscribed();

		// Token: 0x06000488 RID: 1160
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BIsLowViolence();

		// Token: 0x06000489 RID: 1161
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BIsCybercafe();

		// Token: 0x0600048A RID: 1162
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BIsVACBanned();

		// Token: 0x0600048B RID: 1163
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamApps_GetCurrentGameLanguage();

		// Token: 0x0600048C RID: 1164
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamApps_GetAvailableGameLanguages();

		// Token: 0x0600048D RID: 1165
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BIsSubscribedApp(AppId_t appID);

		// Token: 0x0600048E RID: 1166
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BIsDlcInstalled(AppId_t appID);

		// Token: 0x0600048F RID: 1167
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamApps_GetEarliestPurchaseUnixTime(AppId_t nAppID);

		// Token: 0x06000490 RID: 1168
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BIsSubscribedFromFreeWeekend();

		// Token: 0x06000491 RID: 1169
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamApps_GetDLCCount();

		// Token: 0x06000492 RID: 1170
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BGetDLCDataByIndex(int iDLC, out AppId_t pAppID, out bool pbAvailable, IntPtr pchName, int cchNameBufferSize);

		// Token: 0x06000493 RID: 1171
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamApps_InstallDLC(AppId_t nAppID);

		// Token: 0x06000494 RID: 1172
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamApps_UninstallDLC(AppId_t nAppID);

		// Token: 0x06000495 RID: 1173
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamApps_RequestAppProofOfPurchaseKey(AppId_t nAppID);

		// Token: 0x06000496 RID: 1174
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_GetCurrentBetaName(IntPtr pchName, int cchNameBufferSize);

		// Token: 0x06000497 RID: 1175
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_MarkContentCorrupt([MarshalAs(UnmanagedType.I1)] bool bMissingFilesOnly);

		// Token: 0x06000498 RID: 1176
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamApps_GetInstalledDepots(AppId_t appID, [In] [Out] DepotId_t[] pvecDepots, uint cMaxDepots);

		// Token: 0x06000499 RID: 1177
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamApps_GetAppInstallDir(AppId_t appID, IntPtr pchFolder, uint cchFolderBufferSize);

		// Token: 0x0600049A RID: 1178
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_BIsAppInstalled(AppId_t appID);

		// Token: 0x0600049B RID: 1179
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamApps_GetAppOwner();

		// Token: 0x0600049C RID: 1180
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamApps_GetLaunchQueryParam([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey);

		// Token: 0x0600049D RID: 1181
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamApps_GetDlcDownloadProgress(AppId_t nAppID, out ulong punBytesDownloaded, out ulong punBytesTotal);

		// Token: 0x0600049E RID: 1182
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamApps_GetAppBuildId();

		// Token: 0x0600049F RID: 1183
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamClient_CreateSteamPipe();

		// Token: 0x060004A0 RID: 1184
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamClient_BReleaseSteamPipe(HSteamPipe hSteamPipe);

		// Token: 0x060004A1 RID: 1185
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamClient_ConnectToGlobalUser(HSteamPipe hSteamPipe);

		// Token: 0x060004A2 RID: 1186
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamClient_CreateLocalUser(out HSteamPipe phSteamPipe, EAccountType eAccountType);

		// Token: 0x060004A3 RID: 1187
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamClient_ReleaseUser(HSteamPipe hSteamPipe, HSteamUser hUser);

		// Token: 0x060004A4 RID: 1188
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamUser(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004A5 RID: 1189
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamGameServer(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004A6 RID: 1190
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamClient_SetLocalIPBinding(uint unIP, ushort usPort);

		// Token: 0x060004A7 RID: 1191
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamFriends(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004A8 RID: 1192
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamUtils(HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004A9 RID: 1193
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamMatchmaking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004AA RID: 1194
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamMatchmakingServers(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004AB RID: 1195
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamGenericInterface(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004AC RID: 1196
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamUserStats(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004AD RID: 1197
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamGameServerStats(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004AE RID: 1198
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamApps(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004AF RID: 1199
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamNetworking(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004B0 RID: 1200
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamRemoteStorage(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004B1 RID: 1201
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamScreenshots(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004B2 RID: 1202
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamClient_RunFrame();

		// Token: 0x060004B3 RID: 1203
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamClient_GetIPCCallCount();

		// Token: 0x060004B4 RID: 1204
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamClient_SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction);

		// Token: 0x060004B5 RID: 1205
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamClient_BShutdownIfAllPipesClosed();

		// Token: 0x060004B6 RID: 1206
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamHTTP(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004B7 RID: 1207
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamUnifiedMessages(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004B8 RID: 1208
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamController(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004B9 RID: 1209
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamUGC(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004BA RID: 1210
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamAppList(HSteamUser hSteamUser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004BB RID: 1211
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamMusic(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004BC RID: 1212
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamMusicRemote(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004BD RID: 1213
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamHTMLSurface(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004BE RID: 1214
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamClient_Set_SteamAPI_CPostAPIResultInProcess(SteamAPI_PostAPIResultInProcess_t func);

		// Token: 0x060004BF RID: 1215
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamClient_Remove_SteamAPI_CPostAPIResultInProcess(SteamAPI_PostAPIResultInProcess_t func);

		// Token: 0x060004C0 RID: 1216
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamClient_Set_SteamAPI_CCheckCallbackRegisteredInProcess(SteamAPI_CheckCallbackRegistered_t func);

		// Token: 0x060004C1 RID: 1217
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamInventory(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004C2 RID: 1218
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamClient_GetISteamVideo(HSteamUser hSteamuser, HSteamPipe hSteamPipe, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersion);

		// Token: 0x060004C3 RID: 1219
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamController_Init([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchAbsolutePathToControllerConfigVDF);

		// Token: 0x060004C4 RID: 1220
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamController_Shutdown();

		// Token: 0x060004C5 RID: 1221
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamController_RunFrame();

		// Token: 0x060004C6 RID: 1222
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamController_GetControllerState(uint unControllerIndex, out SteamControllerState_t pState);

		// Token: 0x060004C7 RID: 1223
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamController_TriggerHapticPulse(uint unControllerIndex, ESteamControllerPad eTargetPad, ushort usDurationMicroSec);

		// Token: 0x060004C8 RID: 1224
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamController_SetOverrideMode([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchMode);

		// Token: 0x060004C9 RID: 1225
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetPersonaName();

		// Token: 0x060004CA RID: 1226
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_SetPersonaName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPersonaName);

		// Token: 0x060004CB RID: 1227
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EPersonaState ISteamFriends_GetPersonaState();

		// Token: 0x060004CC RID: 1228
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetFriendCount(EFriendFlags iFriendFlags);

		// Token: 0x060004CD RID: 1229
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_GetFriendByIndex(int iFriend, EFriendFlags iFriendFlags);

		// Token: 0x060004CE RID: 1230
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EFriendRelationship ISteamFriends_GetFriendRelationship(CSteamID steamIDFriend);

		// Token: 0x060004CF RID: 1231
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EPersonaState ISteamFriends_GetFriendPersonaState(CSteamID steamIDFriend);

		// Token: 0x060004D0 RID: 1232
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetFriendPersonaName(CSteamID steamIDFriend);

		// Token: 0x060004D1 RID: 1233
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_GetFriendGamePlayed(CSteamID steamIDFriend, out FriendGameInfo_t pFriendGameInfo);

		// Token: 0x060004D2 RID: 1234
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetFriendPersonaNameHistory(CSteamID steamIDFriend, int iPersonaName);

		// Token: 0x060004D3 RID: 1235
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetFriendSteamLevel(CSteamID steamIDFriend);

		// Token: 0x060004D4 RID: 1236
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetPlayerNickname(CSteamID steamIDPlayer);

		// Token: 0x060004D5 RID: 1237
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetFriendsGroupCount();

		// Token: 0x060004D6 RID: 1238
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern FriendsGroupID_t ISteamFriends_GetFriendsGroupIDByIndex(int iFG);

		// Token: 0x060004D7 RID: 1239
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetFriendsGroupName(FriendsGroupID_t friendsGroupID);

		// Token: 0x060004D8 RID: 1240
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetFriendsGroupMembersCount(FriendsGroupID_t friendsGroupID);

		// Token: 0x060004D9 RID: 1241
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_GetFriendsGroupMembersList(FriendsGroupID_t friendsGroupID, [In] [Out] CSteamID[] pOutSteamIDMembers, int nMembersCount);

		// Token: 0x060004DA RID: 1242
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_HasFriend(CSteamID steamIDFriend, EFriendFlags iFriendFlags);

		// Token: 0x060004DB RID: 1243
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetClanCount();

		// Token: 0x060004DC RID: 1244
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_GetClanByIndex(int iClan);

		// Token: 0x060004DD RID: 1245
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetClanName(CSteamID steamIDClan);

		// Token: 0x060004DE RID: 1246
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetClanTag(CSteamID steamIDClan);

		// Token: 0x060004DF RID: 1247
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_GetClanActivityCounts(CSteamID steamIDClan, out int pnOnline, out int pnInGame, out int pnChatting);

		// Token: 0x060004E0 RID: 1248
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_DownloadClanActivityCounts([In] [Out] CSteamID[] psteamIDClans, int cClansToRequest);

		// Token: 0x060004E1 RID: 1249
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetFriendCountFromSource(CSteamID steamIDSource);

		// Token: 0x060004E2 RID: 1250
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_GetFriendFromSourceByIndex(CSteamID steamIDSource, int iFriend);

		// Token: 0x060004E3 RID: 1251
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_IsUserInSource(CSteamID steamIDUser, CSteamID steamIDSource);

		// Token: 0x060004E4 RID: 1252
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_SetInGameVoiceSpeaking(CSteamID steamIDUser, [MarshalAs(UnmanagedType.I1)] bool bSpeaking);

		// Token: 0x060004E5 RID: 1253
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_ActivateGameOverlay([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDialog);

		// Token: 0x060004E6 RID: 1254
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_ActivateGameOverlayToUser([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDialog, CSteamID steamID);

		// Token: 0x060004E7 RID: 1255
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_ActivateGameOverlayToWebPage([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchURL);

		// Token: 0x060004E8 RID: 1256
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_ActivateGameOverlayToStore(AppId_t nAppID, EOverlayToStoreFlag eFlag);

		// Token: 0x060004E9 RID: 1257
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_SetPlayedWith(CSteamID steamIDUserPlayedWith);

		// Token: 0x060004EA RID: 1258
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_ActivateGameOverlayInviteDialog(CSteamID steamIDLobby);

		// Token: 0x060004EB RID: 1259
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetSmallFriendAvatar(CSteamID steamIDFriend);

		// Token: 0x060004EC RID: 1260
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetMediumFriendAvatar(CSteamID steamIDFriend);

		// Token: 0x060004ED RID: 1261
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetLargeFriendAvatar(CSteamID steamIDFriend);

		// Token: 0x060004EE RID: 1262
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_RequestUserInformation(CSteamID steamIDUser, [MarshalAs(UnmanagedType.I1)] bool bRequireNameOnly);

		// Token: 0x060004EF RID: 1263
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_RequestClanOfficerList(CSteamID steamIDClan);

		// Token: 0x060004F0 RID: 1264
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_GetClanOwner(CSteamID steamIDClan);

		// Token: 0x060004F1 RID: 1265
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetClanOfficerCount(CSteamID steamIDClan);

		// Token: 0x060004F2 RID: 1266
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_GetClanOfficerByIndex(CSteamID steamIDClan, int iOfficer);

		// Token: 0x060004F3 RID: 1267
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamFriends_GetUserRestrictions();

		// Token: 0x060004F4 RID: 1268
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_SetRichPresence([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchValue);

		// Token: 0x060004F5 RID: 1269
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_ClearRichPresence();

		// Token: 0x060004F6 RID: 1270
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetFriendRichPresence(CSteamID steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey);

		// Token: 0x060004F7 RID: 1271
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetFriendRichPresenceKeyCount(CSteamID steamIDFriend);

		// Token: 0x060004F8 RID: 1272
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamFriends_GetFriendRichPresenceKeyByIndex(CSteamID steamIDFriend, int iKey);

		// Token: 0x060004F9 RID: 1273
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamFriends_RequestFriendRichPresence(CSteamID steamIDFriend);

		// Token: 0x060004FA RID: 1274
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_InviteUserToGame(CSteamID steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchConnectString);

		// Token: 0x060004FB RID: 1275
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetCoplayFriendCount();

		// Token: 0x060004FC RID: 1276
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_GetCoplayFriend(int iCoplayFriend);

		// Token: 0x060004FD RID: 1277
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetFriendCoplayTime(CSteamID steamIDFriend);

		// Token: 0x060004FE RID: 1278
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamFriends_GetFriendCoplayGame(CSteamID steamIDFriend);

		// Token: 0x060004FF RID: 1279
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_JoinClanChatRoom(CSteamID steamIDClan);

		// Token: 0x06000500 RID: 1280
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_LeaveClanChatRoom(CSteamID steamIDClan);

		// Token: 0x06000501 RID: 1281
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetClanChatMemberCount(CSteamID steamIDClan);

		// Token: 0x06000502 RID: 1282
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_GetChatMemberByIndex(CSteamID steamIDClan, int iUser);

		// Token: 0x06000503 RID: 1283
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_SendClanChatMessage(CSteamID steamIDClanChat, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchText);

		// Token: 0x06000504 RID: 1284
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetClanChatMessage(CSteamID steamIDClanChat, int iMessage, IntPtr prgchText, int cchTextMax, out EChatEntryType peChatEntryType, out CSteamID psteamidChatter);

		// Token: 0x06000505 RID: 1285
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_IsClanChatAdmin(CSteamID steamIDClanChat, CSteamID steamIDUser);

		// Token: 0x06000506 RID: 1286
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_IsClanChatWindowOpenInSteam(CSteamID steamIDClanChat);

		// Token: 0x06000507 RID: 1287
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_OpenClanChatWindowInSteam(CSteamID steamIDClanChat);

		// Token: 0x06000508 RID: 1288
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_CloseClanChatWindowInSteam(CSteamID steamIDClanChat);

		// Token: 0x06000509 RID: 1289
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_SetListenForFriendsMessages([MarshalAs(UnmanagedType.I1)] bool bInterceptEnabled);

		// Token: 0x0600050A RID: 1290
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamFriends_ReplyToFriendMessage(CSteamID steamIDFriend, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchMsgToSend);

		// Token: 0x0600050B RID: 1291
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamFriends_GetFriendMessage(CSteamID steamIDFriend, int iMessageID, IntPtr pvData, int cubData, out EChatEntryType peChatEntryType);

		// Token: 0x0600050C RID: 1292
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_GetFollowerCount(CSteamID steamID);

		// Token: 0x0600050D RID: 1293
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_IsFollowing(CSteamID steamID);

		// Token: 0x0600050E RID: 1294
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamFriends_EnumerateFollowingList(uint unStartIndex);

		// Token: 0x0600050F RID: 1295
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServer_InitGameServer(uint unIP, ushort usGamePort, ushort usQueryPort, uint unFlags, AppId_t nGameAppId, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVersionString);

		// Token: 0x06000510 RID: 1296
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetProduct([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszProduct);

		// Token: 0x06000511 RID: 1297
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetGameDescription([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszGameDescription);

		// Token: 0x06000512 RID: 1298
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetModDir([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszModDir);

		// Token: 0x06000513 RID: 1299
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetDedicatedServer([MarshalAs(UnmanagedType.I1)] bool bDedicated);

		// Token: 0x06000514 RID: 1300
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_LogOn([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszToken);

		// Token: 0x06000515 RID: 1301
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_LogOnAnonymous();

		// Token: 0x06000516 RID: 1302
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_LogOff();

		// Token: 0x06000517 RID: 1303
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServer_BLoggedOn();

		// Token: 0x06000518 RID: 1304
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServer_BSecure();

		// Token: 0x06000519 RID: 1305
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamGameServer_GetSteamID();

		// Token: 0x0600051A RID: 1306
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServer_WasRestartRequested();

		// Token: 0x0600051B RID: 1307
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetMaxPlayerCount(int cPlayersMax);

		// Token: 0x0600051C RID: 1308
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetBotPlayerCount(int cBotplayers);

		// Token: 0x0600051D RID: 1309
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetServerName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszServerName);

		// Token: 0x0600051E RID: 1310
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetMapName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszMapName);

		// Token: 0x0600051F RID: 1311
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetPasswordProtected([MarshalAs(UnmanagedType.I1)] bool bPasswordProtected);

		// Token: 0x06000520 RID: 1312
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetSpectatorPort(ushort unSpectatorPort);

		// Token: 0x06000521 RID: 1313
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetSpectatorServerName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszSpectatorServerName);

		// Token: 0x06000522 RID: 1314
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_ClearAllKeyValues();

		// Token: 0x06000523 RID: 1315
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetKeyValue([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pValue);

		// Token: 0x06000524 RID: 1316
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetGameTags([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchGameTags);

		// Token: 0x06000525 RID: 1317
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetGameData([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchGameData);

		// Token: 0x06000526 RID: 1318
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetRegion([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszRegion);

		// Token: 0x06000527 RID: 1319
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServer_SendUserConnectAndAuthenticate(uint unIPClient, [In] [Out] byte[] pvAuthBlob, uint cubAuthBlobSize, out CSteamID pSteamIDUser);

		// Token: 0x06000528 RID: 1320
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamGameServer_CreateUnauthenticatedUserConnection();

		// Token: 0x06000529 RID: 1321
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SendUserDisconnect(CSteamID steamIDUser);

		// Token: 0x0600052A RID: 1322
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServer_BUpdateUserData(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPlayerName, uint uScore);

		// Token: 0x0600052B RID: 1323
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServer_GetAuthSessionTicket([In] [Out] byte[] pTicket, int cbMaxTicket, out uint pcbTicket);

		// Token: 0x0600052C RID: 1324
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EBeginAuthSessionResult ISteamGameServer_BeginAuthSession([In] [Out] byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID);

		// Token: 0x0600052D RID: 1325
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_EndAuthSession(CSteamID steamID);

		// Token: 0x0600052E RID: 1326
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_CancelAuthTicket(HAuthTicket hAuthTicket);

		// Token: 0x0600052F RID: 1327
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EUserHasLicenseForAppResult ISteamGameServer_UserHasLicenseForApp(CSteamID steamID, AppId_t appID);

		// Token: 0x06000530 RID: 1328
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServer_RequestUserGroupStatus(CSteamID steamIDUser, CSteamID steamIDGroup);

		// Token: 0x06000531 RID: 1329
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_GetGameplayStats();

		// Token: 0x06000532 RID: 1330
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamGameServer_GetServerReputation();

		// Token: 0x06000533 RID: 1331
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServer_GetPublicIP();

		// Token: 0x06000534 RID: 1332
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServer_HandleIncomingPacket([In] [Out] byte[] pData, int cbData, uint srcIP, ushort srcPort);

		// Token: 0x06000535 RID: 1333
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamGameServer_GetNextOutgoingPacket([In] [Out] byte[] pOut, int cbMaxOut, out uint pNetAdr, out ushort pPort);

		// Token: 0x06000536 RID: 1334
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_EnableHeartbeats([MarshalAs(UnmanagedType.I1)] bool bActive);

		// Token: 0x06000537 RID: 1335
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_SetHeartbeatInterval(int iHeartbeatInterval);

		// Token: 0x06000538 RID: 1336
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServer_ForceHeartbeat();

		// Token: 0x06000539 RID: 1337
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamGameServer_AssociateWithClan(CSteamID steamIDClan);

		// Token: 0x0600053A RID: 1338
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamGameServer_ComputeNewPlayerCompatibility(CSteamID steamIDNewPlayer);

		// Token: 0x0600053B RID: 1339
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern HTTPRequestHandle ISteamGameServerHTTP_CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchAbsoluteURL);

		// Token: 0x0600053C RID: 1340
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue);

		// Token: 0x0600053D RID: 1341
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds);

		// Token: 0x0600053E RID: 1342
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHeaderName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHeaderValue);

		// Token: 0x0600053F RID: 1343
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchParamName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchParamValue);

		// Token: 0x06000540 RID: 1344
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SendHTTPRequest(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle);

		// Token: 0x06000541 RID: 1345
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle);

		// Token: 0x06000542 RID: 1346
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_DeferHTTPRequest(HTTPRequestHandle hRequest);

		// Token: 0x06000543 RID: 1347
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_PrioritizeHTTPRequest(HTTPRequestHandle hRequest);

		// Token: 0x06000544 RID: 1348
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHeaderName, out uint unResponseHeaderSize);

		// Token: 0x06000545 RID: 1349
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHeaderName, [In] [Out] byte[] pHeaderValueBuffer, uint unBufferSize);

		// Token: 0x06000546 RID: 1350
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_GetHTTPResponseBodySize(HTTPRequestHandle hRequest, out uint unBodySize);

		// Token: 0x06000547 RID: 1351
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_GetHTTPResponseBodyData(HTTPRequestHandle hRequest, [In] [Out] byte[] pBodyDataBuffer, uint unBufferSize);

		// Token: 0x06000548 RID: 1352
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, [In] [Out] byte[] pBodyDataBuffer, uint unBufferSize);

		// Token: 0x06000549 RID: 1353
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_ReleaseHTTPRequest(HTTPRequestHandle hRequest);

		// Token: 0x0600054A RID: 1354
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, out float pflPercentOut);

		// Token: 0x0600054B RID: 1355
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchContentType, [In] [Out] byte[] pubBody, uint unBodyLen);

		// Token: 0x0600054C RID: 1356
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern HTTPCookieContainerHandle ISteamGameServerHTTP_CreateCookieContainer([MarshalAs(UnmanagedType.I1)] bool bAllowResponsesToModify);

		// Token: 0x0600054D RID: 1357
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer);

		// Token: 0x0600054E RID: 1358
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetCookie(HTTPCookieContainerHandle hCookieContainer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHost, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchUrl, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchCookie);

		// Token: 0x0600054F RID: 1359
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer);

		// Token: 0x06000550 RID: 1360
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchUserAgentInfo);

		// Token: 0x06000551 RID: 1361
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.I1)] bool bRequireVerifiedCertificate);

		// Token: 0x06000552 RID: 1362
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds);

		// Token: 0x06000553 RID: 1363
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerHTTP_GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, out bool pbWasTimedOut);

		// Token: 0x06000554 RID: 1364
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EResult ISteamGameServerInventory_GetResultStatus(SteamInventoryResult_t resultHandle);

		// Token: 0x06000555 RID: 1365
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_GetResultItems(SteamInventoryResult_t resultHandle, [In] [Out] SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize);

		// Token: 0x06000556 RID: 1366
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerInventory_GetResultTimestamp(SteamInventoryResult_t resultHandle);

		// Token: 0x06000557 RID: 1367
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected);

		// Token: 0x06000558 RID: 1368
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServerInventory_DestroyResult(SteamInventoryResult_t resultHandle);

		// Token: 0x06000559 RID: 1369
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_GetAllItems(out SteamInventoryResult_t pResultHandle);

		// Token: 0x0600055A RID: 1370
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_GetItemsByID(out SteamInventoryResult_t pResultHandle, [In] [Out] SteamItemInstanceID_t[] pInstanceIDs, uint unCountInstanceIDs);

		// Token: 0x0600055B RID: 1371
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_SerializeResult(SteamInventoryResult_t resultHandle, [In] [Out] byte[] pOutBuffer, out uint punOutBufferSize);

		// Token: 0x0600055C RID: 1372
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_DeserializeResult(out SteamInventoryResult_t pOutResultHandle, [In] [Out] byte[] pBuffer, uint unBufferSize, [MarshalAs(UnmanagedType.I1)] bool bRESERVED_MUST_BE_FALSE = false);

		// Token: 0x0600055D RID: 1373
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_GenerateItems(out SteamInventoryResult_t pResultHandle, [In] [Out] SteamItemDef_t[] pArrayItemDefs, [In] [Out] uint[] punArrayQuantity, uint unArrayLength);

		// Token: 0x0600055E RID: 1374
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_GrantPromoItems(out SteamInventoryResult_t pResultHandle);

		// Token: 0x0600055F RID: 1375
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_AddPromoItem(out SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef);

		// Token: 0x06000560 RID: 1376
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_AddPromoItems(out SteamInventoryResult_t pResultHandle, [In] [Out] SteamItemDef_t[] pArrayItemDefs, uint unArrayLength);

		// Token: 0x06000561 RID: 1377
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_ConsumeItem(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity);

		// Token: 0x06000562 RID: 1378
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_ExchangeItems(out SteamInventoryResult_t pResultHandle, [In] [Out] SteamItemDef_t[] pArrayGenerate, [In] [Out] uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, [In] [Out] SteamItemInstanceID_t[] pArrayDestroy, [In] [Out] uint[] punArrayDestroyQuantity, uint unArrayDestroyLength);

		// Token: 0x06000563 RID: 1379
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_TransferItemQuantity(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest);

		// Token: 0x06000564 RID: 1380
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServerInventory_SendItemDropHeartbeat();

		// Token: 0x06000565 RID: 1381
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_TriggerItemDrop(out SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition);

		// Token: 0x06000566 RID: 1382
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_TradeItems(out SteamInventoryResult_t pResultHandle, CSteamID steamIDTradePartner, [In] [Out] SteamItemInstanceID_t[] pArrayGive, [In] [Out] uint[] pArrayGiveQuantity, uint nArrayGiveLength, [In] [Out] SteamItemInstanceID_t[] pArrayGet, [In] [Out] uint[] pArrayGetQuantity, uint nArrayGetLength);

		// Token: 0x06000567 RID: 1383
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_LoadItemDefinitions();

		// Token: 0x06000568 RID: 1384
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_GetItemDefinitionIDs([In] [Out] SteamItemDef_t[] pItemDefIDs, out uint punItemDefIDsArraySize);

		// Token: 0x06000569 RID: 1385
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerInventory_GetItemDefinitionProperty(SteamItemDef_t iDefinition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPropertyName, IntPtr pchValueBuffer, ref uint punValueBufferSize);

		// Token: 0x0600056A RID: 1386
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_SendP2PPacket(CSteamID steamIDRemote, [In] [Out] byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel);

		// Token: 0x0600056B RID: 1387
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0);

		// Token: 0x0600056C RID: 1388
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_ReadP2PPacket([In] [Out] byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel);

		// Token: 0x0600056D RID: 1389
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_AcceptP2PSessionWithUser(CSteamID steamIDRemote);

		// Token: 0x0600056E RID: 1390
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_CloseP2PSessionWithUser(CSteamID steamIDRemote);

		// Token: 0x0600056F RID: 1391
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel);

		// Token: 0x06000570 RID: 1392
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState);

		// Token: 0x06000571 RID: 1393
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_AllowP2PPacketRelay([MarshalAs(UnmanagedType.I1)] bool bAllow);

		// Token: 0x06000572 RID: 1394
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerNetworking_CreateListenSocket(int nVirtualP2PPort, uint nIP, ushort nPort, [MarshalAs(UnmanagedType.I1)] bool bAllowUseOfPacketRelay);

		// Token: 0x06000573 RID: 1395
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerNetworking_CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, [MarshalAs(UnmanagedType.I1)] bool bAllowUseOfPacketRelay);

		// Token: 0x06000574 RID: 1396
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerNetworking_CreateConnectionSocket(uint nIP, ushort nPort, int nTimeoutSec);

		// Token: 0x06000575 RID: 1397
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_DestroySocket(SNetSocket_t hSocket, [MarshalAs(UnmanagedType.I1)] bool bNotifyRemoteEnd);

		// Token: 0x06000576 RID: 1398
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_DestroyListenSocket(SNetListenSocket_t hSocket, [MarshalAs(UnmanagedType.I1)] bool bNotifyRemoteEnd);

		// Token: 0x06000577 RID: 1399
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_SendDataOnSocket(SNetSocket_t hSocket, IntPtr pubData, uint cubData, [MarshalAs(UnmanagedType.I1)] bool bReliable);

		// Token: 0x06000578 RID: 1400
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize);

		// Token: 0x06000579 RID: 1401
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_RetrieveDataFromSocket(SNetSocket_t hSocket, IntPtr pubDest, uint cubDest, out uint pcubMsgSize);

		// Token: 0x0600057A RID: 1402
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket);

		// Token: 0x0600057B RID: 1403
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_RetrieveData(SNetListenSocket_t hListenSocket, IntPtr pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket);

		// Token: 0x0600057C RID: 1404
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out uint punIPRemote, out ushort punPortRemote);

		// Token: 0x0600057D RID: 1405
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerNetworking_GetListenSocketInfo(SNetListenSocket_t hListenSocket, out uint pnIP, out ushort pnPort);

		// Token: 0x0600057E RID: 1406
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ESNetSocketConnectionType ISteamGameServerNetworking_GetSocketConnectionType(SNetSocket_t hSocket);

		// Token: 0x0600057F RID: 1407
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamGameServerNetworking_GetMaxPacketSize(SNetSocket_t hSocket);

		// Token: 0x06000580 RID: 1408
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamGameServerStats_RequestUserStats(CSteamID steamIDUser);

		// Token: 0x06000581 RID: 1409
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerStats_GetUserStat(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out int pData);

		// Token: 0x06000582 RID: 1410
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerStats_GetUserStat_(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out float pData);

		// Token: 0x06000583 RID: 1411
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerStats_GetUserAchievement(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out bool pbAchieved);

		// Token: 0x06000584 RID: 1412
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerStats_SetUserStat(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, int nData);

		// Token: 0x06000585 RID: 1413
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerStats_SetUserStat_(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, float fData);

		// Token: 0x06000586 RID: 1414
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerStats_UpdateUserAvgRateStat(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, float flCountThisSession, double dSessionLength);

		// Token: 0x06000587 RID: 1415
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerStats_SetUserAchievement(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName);

		// Token: 0x06000588 RID: 1416
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerStats_ClearUserAchievement(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName);

		// Token: 0x06000589 RID: 1417
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamGameServerStats_StoreUserStats(CSteamID steamIDUser);

		// Token: 0x0600058A RID: 1418
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerUtils_GetSecondsSinceAppActive();

		// Token: 0x0600058B RID: 1419
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerUtils_GetSecondsSinceComputerActive();

		// Token: 0x0600058C RID: 1420
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EUniverse ISteamGameServerUtils_GetConnectedUniverse();

		// Token: 0x0600058D RID: 1421
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerUtils_GetServerRealTime();

		// Token: 0x0600058E RID: 1422
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamGameServerUtils_GetIPCountry();

		// Token: 0x0600058F RID: 1423
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_GetImageSize(int iImage, out uint pnWidth, out uint pnHeight);

		// Token: 0x06000590 RID: 1424
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_GetImageRGBA(int iImage, [In] [Out] byte[] pubDest, int nDestBufferSize);

		// Token: 0x06000591 RID: 1425
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_GetCSERIPPort(out uint unIP, out ushort usPort);

		// Token: 0x06000592 RID: 1426
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte ISteamGameServerUtils_GetCurrentBatteryPower();

		// Token: 0x06000593 RID: 1427
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerUtils_GetAppID();

		// Token: 0x06000594 RID: 1428
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServerUtils_SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition);

		// Token: 0x06000595 RID: 1429
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed);

		// Token: 0x06000596 RID: 1430
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ESteamAPICallFailure ISteamGameServerUtils_GetAPICallFailureReason(SteamAPICall_t hSteamAPICall);

		// Token: 0x06000597 RID: 1431
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed);

		// Token: 0x06000598 RID: 1432
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServerUtils_RunFrame();

		// Token: 0x06000599 RID: 1433
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerUtils_GetIPCCallCount();

		// Token: 0x0600059A RID: 1434
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamGameServerUtils_SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction);

		// Token: 0x0600059B RID: 1435
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_IsOverlayEnabled();

		// Token: 0x0600059C RID: 1436
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_BOverlayNeedsPresent();

		// Token: 0x0600059D RID: 1437
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamGameServerUtils_CheckFileSignature([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string szFileName);

		// Token: 0x0600059E RID: 1438
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDescription, uint unCharMax, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchExistingText);

		// Token: 0x0600059F RID: 1439
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamGameServerUtils_GetEnteredGamepadTextLength();

		// Token: 0x060005A0 RID: 1440
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_GetEnteredGamepadTextInput(IntPtr pchText, uint cchText);

		// Token: 0x060005A1 RID: 1441
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamGameServerUtils_GetSteamUILanguage();

		// Token: 0x060005A2 RID: 1442
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamGameServerUtils_IsSteamRunningInVR();

		// Token: 0x060005A3 RID: 1443
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTMLSurface_Init();

		// Token: 0x060005A4 RID: 1444
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTMLSurface_Shutdown();

		// Token: 0x060005A5 RID: 1445
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamHTMLSurface_CreateBrowser([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchUserAgent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchUserCSS);

		// Token: 0x060005A6 RID: 1446
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_RemoveBrowser(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005A7 RID: 1447
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_LoadURL(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchURL, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPostData);

		// Token: 0x060005A8 RID: 1448
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_SetSize(HHTMLBrowser unBrowserHandle, uint unWidth, uint unHeight);

		// Token: 0x060005A9 RID: 1449
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_StopLoad(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005AA RID: 1450
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_Reload(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005AB RID: 1451
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_GoBack(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005AC RID: 1452
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_GoForward(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005AD RID: 1453
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_AddHeader(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchValue);

		// Token: 0x060005AE RID: 1454
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_ExecuteJavascript(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchScript);

		// Token: 0x060005AF RID: 1455
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_MouseUp(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton);

		// Token: 0x060005B0 RID: 1456
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_MouseDown(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton);

		// Token: 0x060005B1 RID: 1457
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_MouseDoubleClick(HHTMLBrowser unBrowserHandle, EHTMLMouseButton eMouseButton);

		// Token: 0x060005B2 RID: 1458
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_MouseMove(HHTMLBrowser unBrowserHandle, int x, int y);

		// Token: 0x060005B3 RID: 1459
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_MouseWheel(HHTMLBrowser unBrowserHandle, int nDelta);

		// Token: 0x060005B4 RID: 1460
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_KeyDown(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers);

		// Token: 0x060005B5 RID: 1461
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_KeyUp(HHTMLBrowser unBrowserHandle, uint nNativeKeyCode, EHTMLKeyModifiers eHTMLKeyModifiers);

		// Token: 0x060005B6 RID: 1462
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_KeyChar(HHTMLBrowser unBrowserHandle, uint cUnicodeChar, EHTMLKeyModifiers eHTMLKeyModifiers);

		// Token: 0x060005B7 RID: 1463
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_SetHorizontalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll);

		// Token: 0x060005B8 RID: 1464
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_SetVerticalScroll(HHTMLBrowser unBrowserHandle, uint nAbsolutePixelScroll);

		// Token: 0x060005B9 RID: 1465
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_SetKeyFocus(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.I1)] bool bHasKeyFocus);

		// Token: 0x060005BA RID: 1466
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_ViewSource(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005BB RID: 1467
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_CopyToClipboard(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005BC RID: 1468
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_PasteFromClipboard(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005BD RID: 1469
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_Find(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchSearchStr, [MarshalAs(UnmanagedType.I1)] bool bCurrentlyInFind, [MarshalAs(UnmanagedType.I1)] bool bReverse);

		// Token: 0x060005BE RID: 1470
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_StopFind(HHTMLBrowser unBrowserHandle);

		// Token: 0x060005BF RID: 1471
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_GetLinkAtPosition(HHTMLBrowser unBrowserHandle, int x, int y);

		// Token: 0x060005C0 RID: 1472
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_SetCookie([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHostname, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchValue, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPath = "/", uint nExpires = 0u, bool bSecure = false, bool bHTTPOnly = false);

		// Token: 0x060005C1 RID: 1473
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_SetPageScaleFactor(HHTMLBrowser unBrowserHandle, float flZoom, int nPointX, int nPointY);

		// Token: 0x060005C2 RID: 1474
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_AllowStartRequest(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.I1)] bool bAllowed);

		// Token: 0x060005C3 RID: 1475
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_JSDialogResponse(HHTMLBrowser unBrowserHandle, [MarshalAs(UnmanagedType.I1)] bool bResult);

		// Token: 0x060005C4 RID: 1476
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamHTMLSurface_FileLoadDialogResponse(HHTMLBrowser unBrowserHandle, IntPtr pchSelectedFiles);

		// Token: 0x060005C5 RID: 1477
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern HTTPRequestHandle ISteamHTTP_CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchAbsoluteURL);

		// Token: 0x060005C6 RID: 1478
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestContextValue(HTTPRequestHandle hRequest, ulong ulContextValue);

		// Token: 0x060005C7 RID: 1479
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint unTimeoutSeconds);

		// Token: 0x060005C8 RID: 1480
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHeaderName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHeaderValue);

		// Token: 0x060005C9 RID: 1481
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchParamName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchParamValue);

		// Token: 0x060005CA RID: 1482
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SendHTTPRequest(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle);

		// Token: 0x060005CB RID: 1483
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, out SteamAPICall_t pCallHandle);

		// Token: 0x060005CC RID: 1484
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_DeferHTTPRequest(HTTPRequestHandle hRequest);

		// Token: 0x060005CD RID: 1485
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_PrioritizeHTTPRequest(HTTPRequestHandle hRequest);

		// Token: 0x060005CE RID: 1486
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHeaderName, out uint unResponseHeaderSize);

		// Token: 0x060005CF RID: 1487
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHeaderName, [In] [Out] byte[] pHeaderValueBuffer, uint unBufferSize);

		// Token: 0x060005D0 RID: 1488
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_GetHTTPResponseBodySize(HTTPRequestHandle hRequest, out uint unBodySize);

		// Token: 0x060005D1 RID: 1489
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_GetHTTPResponseBodyData(HTTPRequestHandle hRequest, [In] [Out] byte[] pBodyDataBuffer, uint unBufferSize);

		// Token: 0x060005D2 RID: 1490
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint cOffset, [In] [Out] byte[] pBodyDataBuffer, uint unBufferSize);

		// Token: 0x060005D3 RID: 1491
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_ReleaseHTTPRequest(HTTPRequestHandle hRequest);

		// Token: 0x060005D4 RID: 1492
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, out float pflPercentOut);

		// Token: 0x060005D5 RID: 1493
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchContentType, [In] [Out] byte[] pubBody, uint unBodyLen);

		// Token: 0x060005D6 RID: 1494
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern HTTPCookieContainerHandle ISteamHTTP_CreateCookieContainer([MarshalAs(UnmanagedType.I1)] bool bAllowResponsesToModify);

		// Token: 0x060005D7 RID: 1495
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer);

		// Token: 0x060005D8 RID: 1496
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetCookie(HTTPCookieContainerHandle hCookieContainer, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchHost, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchUrl, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchCookie);

		// Token: 0x060005D9 RID: 1497
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer);

		// Token: 0x060005DA RID: 1498
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchUserAgentInfo);

		// Token: 0x060005DB RID: 1499
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, [MarshalAs(UnmanagedType.I1)] bool bRequireVerifiedCertificate);

		// Token: 0x060005DC RID: 1500
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint unMilliseconds);

		// Token: 0x060005DD RID: 1501
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamHTTP_GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, out bool pbWasTimedOut);

		// Token: 0x060005DE RID: 1502
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EResult ISteamInventory_GetResultStatus(SteamInventoryResult_t resultHandle);

		// Token: 0x060005DF RID: 1503
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_GetResultItems(SteamInventoryResult_t resultHandle, [In] [Out] SteamItemDetails_t[] pOutItemsArray, ref uint punOutItemsArraySize);

		// Token: 0x060005E0 RID: 1504
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamInventory_GetResultTimestamp(SteamInventoryResult_t resultHandle);

		// Token: 0x060005E1 RID: 1505
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_CheckResultSteamID(SteamInventoryResult_t resultHandle, CSteamID steamIDExpected);

		// Token: 0x060005E2 RID: 1506
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamInventory_DestroyResult(SteamInventoryResult_t resultHandle);

		// Token: 0x060005E3 RID: 1507
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_GetAllItems(out SteamInventoryResult_t pResultHandle);

		// Token: 0x060005E4 RID: 1508
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_GetItemsByID(out SteamInventoryResult_t pResultHandle, [In] [Out] SteamItemInstanceID_t[] pInstanceIDs, uint unCountInstanceIDs);

		// Token: 0x060005E5 RID: 1509
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_SerializeResult(SteamInventoryResult_t resultHandle, [In] [Out] byte[] pOutBuffer, out uint punOutBufferSize);

		// Token: 0x060005E6 RID: 1510
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_DeserializeResult(out SteamInventoryResult_t pOutResultHandle, [In] [Out] byte[] pBuffer, uint unBufferSize, [MarshalAs(UnmanagedType.I1)] bool bRESERVED_MUST_BE_FALSE = false);

		// Token: 0x060005E7 RID: 1511
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_GenerateItems(out SteamInventoryResult_t pResultHandle, [In] [Out] SteamItemDef_t[] pArrayItemDefs, [In] [Out] uint[] punArrayQuantity, uint unArrayLength);

		// Token: 0x060005E8 RID: 1512
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_GrantPromoItems(out SteamInventoryResult_t pResultHandle);

		// Token: 0x060005E9 RID: 1513
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_AddPromoItem(out SteamInventoryResult_t pResultHandle, SteamItemDef_t itemDef);

		// Token: 0x060005EA RID: 1514
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_AddPromoItems(out SteamInventoryResult_t pResultHandle, [In] [Out] SteamItemDef_t[] pArrayItemDefs, uint unArrayLength);

		// Token: 0x060005EB RID: 1515
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_ConsumeItem(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemConsume, uint unQuantity);

		// Token: 0x060005EC RID: 1516
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_ExchangeItems(out SteamInventoryResult_t pResultHandle, [In] [Out] SteamItemDef_t[] pArrayGenerate, [In] [Out] uint[] punArrayGenerateQuantity, uint unArrayGenerateLength, [In] [Out] SteamItemInstanceID_t[] pArrayDestroy, [In] [Out] uint[] punArrayDestroyQuantity, uint unArrayDestroyLength);

		// Token: 0x060005ED RID: 1517
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_TransferItemQuantity(out SteamInventoryResult_t pResultHandle, SteamItemInstanceID_t itemIdSource, uint unQuantity, SteamItemInstanceID_t itemIdDest);

		// Token: 0x060005EE RID: 1518
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamInventory_SendItemDropHeartbeat();

		// Token: 0x060005EF RID: 1519
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_TriggerItemDrop(out SteamInventoryResult_t pResultHandle, SteamItemDef_t dropListDefinition);

		// Token: 0x060005F0 RID: 1520
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_TradeItems(out SteamInventoryResult_t pResultHandle, CSteamID steamIDTradePartner, [In] [Out] SteamItemInstanceID_t[] pArrayGive, [In] [Out] uint[] pArrayGiveQuantity, uint nArrayGiveLength, [In] [Out] SteamItemInstanceID_t[] pArrayGet, [In] [Out] uint[] pArrayGetQuantity, uint nArrayGetLength);

		// Token: 0x060005F1 RID: 1521
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_LoadItemDefinitions();

		// Token: 0x060005F2 RID: 1522
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_GetItemDefinitionIDs([In] [Out] SteamItemDef_t[] pItemDefIDs, out uint punItemDefIDsArraySize);

		// Token: 0x060005F3 RID: 1523
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamInventory_GetItemDefinitionProperty(SteamItemDef_t iDefinition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPropertyName, IntPtr pchValueBuffer, ref uint punValueBufferSize);

		// Token: 0x060005F4 RID: 1524
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmaking_GetFavoriteGameCount();

		// Token: 0x060005F5 RID: 1525
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_GetFavoriteGame(int iGame, out AppId_t pnAppID, out uint pnIP, out ushort pnConnPort, out ushort pnQueryPort, out uint punFlags, out uint pRTime32LastPlayedOnServer);

		// Token: 0x060005F6 RID: 1526
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmaking_AddFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags, uint rTime32LastPlayedOnServer);

		// Token: 0x060005F7 RID: 1527
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_RemoveFavoriteGame(AppId_t nAppID, uint nIP, ushort nConnPort, ushort nQueryPort, uint unFlags);

		// Token: 0x060005F8 RID: 1528
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamMatchmaking_RequestLobbyList();

		// Token: 0x060005F9 RID: 1529
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_AddRequestLobbyListStringFilter([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKeyToMatch, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchValueToMatch, ELobbyComparison eComparisonType);

		// Token: 0x060005FA RID: 1530
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_AddRequestLobbyListNumericalFilter([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKeyToMatch, int nValueToMatch, ELobbyComparison eComparisonType);

		// Token: 0x060005FB RID: 1531
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_AddRequestLobbyListNearValueFilter([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKeyToMatch, int nValueToBeCloseTo);

		// Token: 0x060005FC RID: 1532
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable(int nSlotsAvailable);

		// Token: 0x060005FD RID: 1533
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter eLobbyDistanceFilter);

		// Token: 0x060005FE RID: 1534
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_AddRequestLobbyListResultCountFilter(int cMaxResults);

		// Token: 0x060005FF RID: 1535
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter(CSteamID steamIDLobby);

		// Token: 0x06000600 RID: 1536
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamMatchmaking_GetLobbyByIndex(int iLobby);

		// Token: 0x06000601 RID: 1537
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamMatchmaking_CreateLobby(ELobbyType eLobbyType, int cMaxMembers);

		// Token: 0x06000602 RID: 1538
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamMatchmaking_JoinLobby(CSteamID steamIDLobby);

		// Token: 0x06000603 RID: 1539
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_LeaveLobby(CSteamID steamIDLobby);

		// Token: 0x06000604 RID: 1540
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_InviteUserToLobby(CSteamID steamIDLobby, CSteamID steamIDInvitee);

		// Token: 0x06000605 RID: 1541
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmaking_GetNumLobbyMembers(CSteamID steamIDLobby);

		// Token: 0x06000606 RID: 1542
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamMatchmaking_GetLobbyMemberByIndex(CSteamID steamIDLobby, int iMember);

		// Token: 0x06000607 RID: 1543
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamMatchmaking_GetLobbyData(CSteamID steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey);

		// Token: 0x06000608 RID: 1544
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_SetLobbyData(CSteamID steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchValue);

		// Token: 0x06000609 RID: 1545
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmaking_GetLobbyDataCount(CSteamID steamIDLobby);

		// Token: 0x0600060A RID: 1546
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_GetLobbyDataByIndex(CSteamID steamIDLobby, int iLobbyData, IntPtr pchKey, int cchKeyBufferSize, IntPtr pchValue, int cchValueBufferSize);

		// Token: 0x0600060B RID: 1547
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_DeleteLobbyData(CSteamID steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey);

		// Token: 0x0600060C RID: 1548
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamMatchmaking_GetLobbyMemberData(CSteamID steamIDLobby, CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey);

		// Token: 0x0600060D RID: 1549
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_SetLobbyMemberData(CSteamID steamIDLobby, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchValue);

		// Token: 0x0600060E RID: 1550
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_SendLobbyChatMsg(CSteamID steamIDLobby, [In] [Out] byte[] pvMsgBody, int cubMsgBody);

		// Token: 0x0600060F RID: 1551
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmaking_GetLobbyChatEntry(CSteamID steamIDLobby, int iChatID, out CSteamID pSteamIDUser, [In] [Out] byte[] pvData, int cubData, out EChatEntryType peChatEntryType);

		// Token: 0x06000610 RID: 1552
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_RequestLobbyData(CSteamID steamIDLobby);

		// Token: 0x06000611 RID: 1553
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmaking_SetLobbyGameServer(CSteamID steamIDLobby, uint unGameServerIP, ushort unGameServerPort, CSteamID steamIDGameServer);

		// Token: 0x06000612 RID: 1554
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_GetLobbyGameServer(CSteamID steamIDLobby, out uint punGameServerIP, out ushort punGameServerPort, out CSteamID psteamIDGameServer);

		// Token: 0x06000613 RID: 1555
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_SetLobbyMemberLimit(CSteamID steamIDLobby, int cMaxMembers);

		// Token: 0x06000614 RID: 1556
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmaking_GetLobbyMemberLimit(CSteamID steamIDLobby);

		// Token: 0x06000615 RID: 1557
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_SetLobbyType(CSteamID steamIDLobby, ELobbyType eLobbyType);

		// Token: 0x06000616 RID: 1558
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_SetLobbyJoinable(CSteamID steamIDLobby, [MarshalAs(UnmanagedType.I1)] bool bLobbyJoinable);

		// Token: 0x06000617 RID: 1559
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamMatchmaking_GetLobbyOwner(CSteamID steamIDLobby);

		// Token: 0x06000618 RID: 1560
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_SetLobbyOwner(CSteamID steamIDLobby, CSteamID steamIDNewOwner);

		// Token: 0x06000619 RID: 1561
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmaking_SetLinkedLobby(CSteamID steamIDLobby, CSteamID steamIDLobbyDependent);

		// Token: 0x0600061A RID: 1562
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamMatchmakingServers_RequestInternetServerList(AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x0600061B RID: 1563
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamMatchmakingServers_RequestLANServerList(AppId_t iApp, IntPtr pRequestServersResponse);

		// Token: 0x0600061C RID: 1564
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamMatchmakingServers_RequestFriendsServerList(AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x0600061D RID: 1565
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamMatchmakingServers_RequestFavoritesServerList(AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x0600061E RID: 1566
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamMatchmakingServers_RequestHistoryServerList(AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x0600061F RID: 1567
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamMatchmakingServers_RequestSpectatorServerList(AppId_t iApp, IntPtr ppchFilters, uint nFilters, IntPtr pRequestServersResponse);

		// Token: 0x06000620 RID: 1568
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmakingServers_ReleaseRequest(HServerListRequest hServerListRequest);

		// Token: 0x06000621 RID: 1569
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr ISteamMatchmakingServers_GetServerDetails(HServerListRequest hRequest, int iServer);

		// Token: 0x06000622 RID: 1570
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmakingServers_CancelQuery(HServerListRequest hRequest);

		// Token: 0x06000623 RID: 1571
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmakingServers_RefreshQuery(HServerListRequest hRequest);

		// Token: 0x06000624 RID: 1572
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMatchmakingServers_IsRefreshing(HServerListRequest hRequest);

		// Token: 0x06000625 RID: 1573
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmakingServers_GetServerCount(HServerListRequest hRequest);

		// Token: 0x06000626 RID: 1574
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmakingServers_RefreshServer(HServerListRequest hRequest, int iServer);

		// Token: 0x06000627 RID: 1575
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmakingServers_PingServer(uint unIP, ushort usPort, IntPtr pRequestServersResponse);

		// Token: 0x06000628 RID: 1576
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmakingServers_PlayerDetails(uint unIP, ushort usPort, IntPtr pRequestServersResponse);

		// Token: 0x06000629 RID: 1577
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamMatchmakingServers_ServerRules(uint unIP, ushort usPort, IntPtr pRequestServersResponse);

		// Token: 0x0600062A RID: 1578
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMatchmakingServers_CancelServerQuery(HServerQuery hServerQuery);

		// Token: 0x0600062B RID: 1579
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusic_BIsEnabled();

		// Token: 0x0600062C RID: 1580
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusic_BIsPlaying();

		// Token: 0x0600062D RID: 1581
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern AudioPlayback_Status ISteamMusic_GetPlaybackStatus();

		// Token: 0x0600062E RID: 1582
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMusic_Play();

		// Token: 0x0600062F RID: 1583
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMusic_Pause();

		// Token: 0x06000630 RID: 1584
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMusic_PlayPrevious();

		// Token: 0x06000631 RID: 1585
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMusic_PlayNext();

		// Token: 0x06000632 RID: 1586
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamMusic_SetVolume(float flVolume);

		// Token: 0x06000633 RID: 1587
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern float ISteamMusic_GetVolume();

		// Token: 0x06000634 RID: 1588
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_RegisterSteamMusicRemote([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName);

		// Token: 0x06000635 RID: 1589
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_DeregisterSteamMusicRemote();

		// Token: 0x06000636 RID: 1590
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_BIsCurrentMusicRemote();

		// Token: 0x06000637 RID: 1591
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_BActivationSuccess([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x06000638 RID: 1592
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_SetDisplayName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDisplayName);

		// Token: 0x06000639 RID: 1593
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_SetPNGIcon_64x64([In] [Out] byte[] pvBuffer, uint cbBufferLength);

		// Token: 0x0600063A RID: 1594
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_EnablePlayPrevious([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x0600063B RID: 1595
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_EnablePlayNext([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x0600063C RID: 1596
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_EnableShuffled([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x0600063D RID: 1597
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_EnableLooped([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x0600063E RID: 1598
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_EnableQueue([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x0600063F RID: 1599
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_EnablePlaylists([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x06000640 RID: 1600
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_UpdatePlaybackStatus(AudioPlayback_Status nStatus);

		// Token: 0x06000641 RID: 1601
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_UpdateShuffled([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x06000642 RID: 1602
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_UpdateLooped([MarshalAs(UnmanagedType.I1)] bool bValue);

		// Token: 0x06000643 RID: 1603
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_UpdateVolume(float flValue);

		// Token: 0x06000644 RID: 1604
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_CurrentEntryWillChange();

		// Token: 0x06000645 RID: 1605
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_CurrentEntryIsAvailable([MarshalAs(UnmanagedType.I1)] bool bAvailable);

		// Token: 0x06000646 RID: 1606
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_UpdateCurrentEntryText([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchText);

		// Token: 0x06000647 RID: 1607
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds(int nValue);

		// Token: 0x06000648 RID: 1608
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_UpdateCurrentEntryCoverArt([In] [Out] byte[] pvBuffer, uint cbBufferLength);

		// Token: 0x06000649 RID: 1609
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_CurrentEntryDidChange();

		// Token: 0x0600064A RID: 1610
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_QueueWillChange();

		// Token: 0x0600064B RID: 1611
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_ResetQueueEntries();

		// Token: 0x0600064C RID: 1612
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_SetQueueEntry(int nID, int nPosition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchEntryText);

		// Token: 0x0600064D RID: 1613
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_SetCurrentQueueEntry(int nID);

		// Token: 0x0600064E RID: 1614
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_QueueDidChange();

		// Token: 0x0600064F RID: 1615
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_PlaylistWillChange();

		// Token: 0x06000650 RID: 1616
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_ResetPlaylistEntries();

		// Token: 0x06000651 RID: 1617
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_SetPlaylistEntry(int nID, int nPosition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchEntryText);

		// Token: 0x06000652 RID: 1618
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_SetCurrentPlaylistEntry(int nID);

		// Token: 0x06000653 RID: 1619
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamMusicRemote_PlaylistDidChange();

		// Token: 0x06000654 RID: 1620
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_SendP2PPacket(CSteamID steamIDRemote, [In] [Out] byte[] pubData, uint cubData, EP2PSend eP2PSendType, int nChannel);

		// Token: 0x06000655 RID: 1621
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_IsP2PPacketAvailable(out uint pcubMsgSize, int nChannel = 0);

		// Token: 0x06000656 RID: 1622
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_ReadP2PPacket([In] [Out] byte[] pubDest, uint cubDest, out uint pcubMsgSize, out CSteamID psteamIDRemote, int nChannel);

		// Token: 0x06000657 RID: 1623
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_AcceptP2PSessionWithUser(CSteamID steamIDRemote);

		// Token: 0x06000658 RID: 1624
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_CloseP2PSessionWithUser(CSteamID steamIDRemote);

		// Token: 0x06000659 RID: 1625
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_CloseP2PChannelWithUser(CSteamID steamIDRemote, int nChannel);

		// Token: 0x0600065A RID: 1626
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_GetP2PSessionState(CSteamID steamIDRemote, out P2PSessionState_t pConnectionState);

		// Token: 0x0600065B RID: 1627
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_AllowP2PPacketRelay([MarshalAs(UnmanagedType.I1)] bool bAllow);

		// Token: 0x0600065C RID: 1628
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamNetworking_CreateListenSocket(int nVirtualP2PPort, uint nIP, ushort nPort, [MarshalAs(UnmanagedType.I1)] bool bAllowUseOfPacketRelay);

		// Token: 0x0600065D RID: 1629
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamNetworking_CreateP2PConnectionSocket(CSteamID steamIDTarget, int nVirtualPort, int nTimeoutSec, [MarshalAs(UnmanagedType.I1)] bool bAllowUseOfPacketRelay);

		// Token: 0x0600065E RID: 1630
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamNetworking_CreateConnectionSocket(uint nIP, ushort nPort, int nTimeoutSec);

		// Token: 0x0600065F RID: 1631
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_DestroySocket(SNetSocket_t hSocket, [MarshalAs(UnmanagedType.I1)] bool bNotifyRemoteEnd);

		// Token: 0x06000660 RID: 1632
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_DestroyListenSocket(SNetListenSocket_t hSocket, [MarshalAs(UnmanagedType.I1)] bool bNotifyRemoteEnd);

		// Token: 0x06000661 RID: 1633
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_SendDataOnSocket(SNetSocket_t hSocket, IntPtr pubData, uint cubData, [MarshalAs(UnmanagedType.I1)] bool bReliable);

		// Token: 0x06000662 RID: 1634
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_IsDataAvailableOnSocket(SNetSocket_t hSocket, out uint pcubMsgSize);

		// Token: 0x06000663 RID: 1635
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_RetrieveDataFromSocket(SNetSocket_t hSocket, IntPtr pubDest, uint cubDest, out uint pcubMsgSize);

		// Token: 0x06000664 RID: 1636
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_IsDataAvailable(SNetListenSocket_t hListenSocket, out uint pcubMsgSize, out SNetSocket_t phSocket);

		// Token: 0x06000665 RID: 1637
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_RetrieveData(SNetListenSocket_t hListenSocket, IntPtr pubDest, uint cubDest, out uint pcubMsgSize, out SNetSocket_t phSocket);

		// Token: 0x06000666 RID: 1638
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_GetSocketInfo(SNetSocket_t hSocket, out CSteamID pSteamIDRemote, out int peSocketStatus, out uint punIPRemote, out ushort punPortRemote);

		// Token: 0x06000667 RID: 1639
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamNetworking_GetListenSocketInfo(SNetListenSocket_t hListenSocket, out uint pnIP, out ushort pnPort);

		// Token: 0x06000668 RID: 1640
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ESNetSocketConnectionType ISteamNetworking_GetSocketConnectionType(SNetSocket_t hSocket);

		// Token: 0x06000669 RID: 1641
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamNetworking_GetMaxPacketSize(SNetSocket_t hSocket);

		// Token: 0x0600066A RID: 1642
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_FileWrite([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile, [In] [Out] byte[] pvData, int cubData);

		// Token: 0x0600066B RID: 1643
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamRemoteStorage_FileRead([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile, [In] [Out] byte[] pvData, int cubDataToRead);

		// Token: 0x0600066C RID: 1644
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_FileForget([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x0600066D RID: 1645
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_FileDelete([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x0600066E RID: 1646
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_FileShare([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x0600066F RID: 1647
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_SetSyncPlatforms([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform);

		// Token: 0x06000670 RID: 1648
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_FileWriteStreamOpen([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x06000671 RID: 1649
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_FileWriteStreamWriteChunk(UGCFileWriteStreamHandle_t writeHandle, [In] [Out] byte[] pvData, int cubData);

		// Token: 0x06000672 RID: 1650
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_FileWriteStreamClose(UGCFileWriteStreamHandle_t writeHandle);

		// Token: 0x06000673 RID: 1651
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_FileWriteStreamCancel(UGCFileWriteStreamHandle_t writeHandle);

		// Token: 0x06000674 RID: 1652
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_FileExists([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x06000675 RID: 1653
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_FilePersisted([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x06000676 RID: 1654
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamRemoteStorage_GetFileSize([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x06000677 RID: 1655
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern long ISteamRemoteStorage_GetFileTimestamp([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x06000678 RID: 1656
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ERemoteStoragePlatform ISteamRemoteStorage_GetSyncPlatforms([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x06000679 RID: 1657
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamRemoteStorage_GetFileCount();

		// Token: 0x0600067A RID: 1658
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamRemoteStorage_GetFileNameAndSize(int iFile, out int pnFileSizeInBytes);

		// Token: 0x0600067B RID: 1659
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_GetQuota(out int pnTotalBytes, out int puAvailableBytes);

		// Token: 0x0600067C RID: 1660
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_IsCloudEnabledForAccount();

		// Token: 0x0600067D RID: 1661
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_IsCloudEnabledForApp();

		// Token: 0x0600067E RID: 1662
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamRemoteStorage_SetCloudEnabledForApp([MarshalAs(UnmanagedType.I1)] bool bEnabled);

		// Token: 0x0600067F RID: 1663
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_UGCDownload(UGCHandle_t hContent, uint unPriority);

		// Token: 0x06000680 RID: 1664
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_GetUGCDownloadProgress(UGCHandle_t hContent, out int pnBytesDownloaded, out int pnBytesExpected);

		// Token: 0x06000681 RID: 1665
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_GetUGCDetails(UGCHandle_t hContent, out AppId_t pnAppID, out IntPtr ppchName, out int pnFileSizeInBytes, out CSteamID pSteamIDOwner);

		// Token: 0x06000682 RID: 1666
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamRemoteStorage_UGCRead(UGCHandle_t hContent, [In] [Out] byte[] pvData, int cubDataToRead, uint cOffset, EUGCReadAction eAction);

		// Token: 0x06000683 RID: 1667
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamRemoteStorage_GetCachedUGCCount();

		// Token: 0x06000684 RID: 1668
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_GetCachedUGCHandle(int iCachedContent);

		// Token: 0x06000685 RID: 1669
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_PublishWorkshopFile([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPreviewFile, AppId_t nConsumerAppId, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchTitle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, IntPtr pTags, EWorkshopFileType eWorkshopFileType);

		// Token: 0x06000686 RID: 1670
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_CreatePublishedFileUpdateRequest(PublishedFileId_t unPublishedFileId);

		// Token: 0x06000687 RID: 1671
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_UpdatePublishedFileFile(PublishedFileUpdateHandle_t updateHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFile);

		// Token: 0x06000688 RID: 1672
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle_t updateHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPreviewFile);

		// Token: 0x06000689 RID: 1673
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_UpdatePublishedFileTitle(PublishedFileUpdateHandle_t updateHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchTitle);

		// Token: 0x0600068A RID: 1674
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_UpdatePublishedFileDescription(PublishedFileUpdateHandle_t updateHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDescription);

		// Token: 0x0600068B RID: 1675
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_UpdatePublishedFileVisibility(PublishedFileUpdateHandle_t updateHandle, ERemoteStoragePublishedFileVisibility eVisibility);

		// Token: 0x0600068C RID: 1676
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_UpdatePublishedFileTags(PublishedFileUpdateHandle_t updateHandle, IntPtr pTags);

		// Token: 0x0600068D RID: 1677
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_CommitPublishedFileUpdate(PublishedFileUpdateHandle_t updateHandle);

		// Token: 0x0600068E RID: 1678
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_GetPublishedFileDetails(PublishedFileId_t unPublishedFileId, uint unMaxSecondsOld);

		// Token: 0x0600068F RID: 1679
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_DeletePublishedFile(PublishedFileId_t unPublishedFileId);

		// Token: 0x06000690 RID: 1680
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_EnumerateUserPublishedFiles(uint unStartIndex);

		// Token: 0x06000691 RID: 1681
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_SubscribePublishedFile(PublishedFileId_t unPublishedFileId);

		// Token: 0x06000692 RID: 1682
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_EnumerateUserSubscribedFiles(uint unStartIndex);

		// Token: 0x06000693 RID: 1683
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_UnsubscribePublishedFile(PublishedFileId_t unPublishedFileId);

		// Token: 0x06000694 RID: 1684
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamRemoteStorage_UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle_t updateHandle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchChangeDescription);

		// Token: 0x06000695 RID: 1685
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_GetPublishedItemVoteDetails(PublishedFileId_t unPublishedFileId);

		// Token: 0x06000696 RID: 1686
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_UpdateUserPublishedItemVote(PublishedFileId_t unPublishedFileId, [MarshalAs(UnmanagedType.I1)] bool bVoteUp);

		// Token: 0x06000697 RID: 1687
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_GetUserPublishedItemVoteDetails(PublishedFileId_t unPublishedFileId);

		// Token: 0x06000698 RID: 1688
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_EnumerateUserSharedWorkshopFiles(CSteamID steamId, uint unStartIndex, IntPtr pRequiredTags, IntPtr pExcludedTags);

		// Token: 0x06000699 RID: 1689
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_PublishVideo(EWorkshopVideoProvider eVideoProvider, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVideoAccount, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchVideoIdentifier, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchPreviewFile, AppId_t nConsumerAppId, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchTitle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDescription, ERemoteStoragePublishedFileVisibility eVisibility, IntPtr pTags);

		// Token: 0x0600069A RID: 1690
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_SetUserPublishedFileAction(PublishedFileId_t unPublishedFileId, EWorkshopFileAction eAction);

		// Token: 0x0600069B RID: 1691
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_EnumeratePublishedFilesByUserAction(EWorkshopFileAction eAction, uint unStartIndex);

		// Token: 0x0600069C RID: 1692
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_EnumeratePublishedWorkshopFiles(EWorkshopEnumerationType eEnumerationType, uint unStartIndex, uint unCount, uint unDays, IntPtr pTags, IntPtr pUserTags);

		// Token: 0x0600069D RID: 1693
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamRemoteStorage_UGCDownloadToLocation(UGCHandle_t hContent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchLocation, uint unPriority);

		// Token: 0x0600069E RID: 1694
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamScreenshots_WriteScreenshot([In] [Out] byte[] pubRGB, uint cubRGB, int nWidth, int nHeight);

		// Token: 0x0600069F RID: 1695
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamScreenshots_AddScreenshotToLibrary([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchFilename, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchThumbnailFilename, int nWidth, int nHeight);

		// Token: 0x060006A0 RID: 1696
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamScreenshots_TriggerScreenshot();

		// Token: 0x060006A1 RID: 1697
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamScreenshots_HookScreenshots([MarshalAs(UnmanagedType.I1)] bool bHook);

		// Token: 0x060006A2 RID: 1698
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamScreenshots_SetLocation(ScreenshotHandle hScreenshot, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchLocation);

		// Token: 0x060006A3 RID: 1699
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamScreenshots_TagUser(ScreenshotHandle hScreenshot, CSteamID steamID);

		// Token: 0x060006A4 RID: 1700
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamScreenshots_TagPublishedFile(ScreenshotHandle hScreenshot, PublishedFileId_t unPublishedFileID);

		// Token: 0x060006A5 RID: 1701
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_CreateQueryUserUGCRequest(AccountID_t unAccountID, EUserUGCList eListType, EUGCMatchingUGCType eMatchingUGCType, EUserUGCListSortOrder eSortOrder, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage);

		// Token: 0x060006A6 RID: 1702
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_CreateQueryAllUGCRequest(EUGCQuery eQueryType, EUGCMatchingUGCType eMatchingeMatchingUGCTypeFileType, AppId_t nCreatorAppID, AppId_t nConsumerAppID, uint unPage);

		// Token: 0x060006A7 RID: 1703
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_SendQueryUGCRequest(UGCQueryHandle_t handle);

		// Token: 0x060006A8 RID: 1704
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_GetQueryUGCResult(UGCQueryHandle_t handle, uint index, out SteamUGCDetails_t pDetails);

		// Token: 0x060006A9 RID: 1705
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_ReleaseQueryUGCRequest(UGCQueryHandle_t handle);

		// Token: 0x060006AA RID: 1706
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_AddRequiredTag(UGCQueryHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pTagName);

		// Token: 0x060006AB RID: 1707
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_AddExcludedTag(UGCQueryHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pTagName);

		// Token: 0x060006AC RID: 1708
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetReturnLongDescription(UGCQueryHandle_t handle, [MarshalAs(UnmanagedType.I1)] bool bReturnLongDescription);

		// Token: 0x060006AD RID: 1709
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetReturnTotalOnly(UGCQueryHandle_t handle, [MarshalAs(UnmanagedType.I1)] bool bReturnTotalOnly);

		// Token: 0x060006AE RID: 1710
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetAllowCachedResponse(UGCQueryHandle_t handle, uint unMaxAgeSeconds);

		// Token: 0x060006AF RID: 1711
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetCloudFileNameFilter(UGCQueryHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pMatchCloudFileName);

		// Token: 0x060006B0 RID: 1712
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetMatchAnyTag(UGCQueryHandle_t handle, [MarshalAs(UnmanagedType.I1)] bool bMatchAnyTag);

		// Token: 0x060006B1 RID: 1713
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetSearchText(UGCQueryHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pSearchText);

		// Token: 0x060006B2 RID: 1714
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetRankedByTrendDays(UGCQueryHandle_t handle, uint unDays);

		// Token: 0x060006B3 RID: 1715
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_RequestUGCDetails(PublishedFileId_t nPublishedFileID, uint unMaxAgeSeconds);

		// Token: 0x060006B4 RID: 1716
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_CreateItem(AppId_t nConsumerAppId, EWorkshopFileType eFileType);

		// Token: 0x060006B5 RID: 1717
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_StartItemUpdate(AppId_t nConsumerAppId, PublishedFileId_t nPublishedFileID);

		// Token: 0x060006B6 RID: 1718
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetItemTitle(UGCUpdateHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchTitle);

		// Token: 0x060006B7 RID: 1719
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetItemDescription(UGCUpdateHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDescription);

		// Token: 0x060006B8 RID: 1720
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetItemVisibility(UGCUpdateHandle_t handle, ERemoteStoragePublishedFileVisibility eVisibility);

		// Token: 0x060006B9 RID: 1721
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetItemTags(UGCUpdateHandle_t updateHandle, IntPtr pTags);

		// Token: 0x060006BA RID: 1722
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetItemContent(UGCUpdateHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszContentFolder);

		// Token: 0x060006BB RID: 1723
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_SetItemPreview(UGCUpdateHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pszPreviewFile);

		// Token: 0x060006BC RID: 1724
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_SubmitItemUpdate(UGCUpdateHandle_t handle, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchChangeNote);

		// Token: 0x060006BD RID: 1725
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EItemUpdateStatus ISteamUGC_GetItemUpdateProgress(UGCUpdateHandle_t handle, out ulong punBytesProcessed, out ulong punBytesTotal);

		// Token: 0x060006BE RID: 1726
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_SubscribeItem(PublishedFileId_t nPublishedFileID);

		// Token: 0x060006BF RID: 1727
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUGC_UnsubscribeItem(PublishedFileId_t nPublishedFileID);

		// Token: 0x060006C0 RID: 1728
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUGC_GetNumSubscribedItems();

		// Token: 0x060006C1 RID: 1729
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUGC_GetSubscribedItems([In] [Out] PublishedFileId_t[] pvecPublishedFileID, uint cMaxEntries);

		// Token: 0x060006C2 RID: 1730
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_GetItemInstallInfo(PublishedFileId_t nPublishedFileID, out ulong punSizeOnDisk, IntPtr pchFolder, uint cchFolderSize, out bool pbLegacyItem);

		// Token: 0x060006C3 RID: 1731
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUGC_GetItemUpdateInfo(PublishedFileId_t nPublishedFileID, out bool pbNeedsUpdate, out bool pbIsDownloading, out ulong punBytesDownloaded, out ulong punBytesTotal);

		// Token: 0x060006C4 RID: 1732
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUnifiedMessages_SendMethod([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchServiceMethod, [In] [Out] byte[] pRequestBuffer, uint unRequestBufferSize, ulong unContext);

		// Token: 0x060006C5 RID: 1733
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUnifiedMessages_GetMethodResponseInfo(ClientUnifiedMessageHandle hHandle, out uint punResponseSize, out EResult peResult);

		// Token: 0x060006C6 RID: 1734
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUnifiedMessages_GetMethodResponseData(ClientUnifiedMessageHandle hHandle, [In] [Out] byte[] pResponseBuffer, uint unResponseBufferSize, [MarshalAs(UnmanagedType.I1)] bool bAutoRelease);

		// Token: 0x060006C7 RID: 1735
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUnifiedMessages_ReleaseMethod(ClientUnifiedMessageHandle hHandle);

		// Token: 0x060006C8 RID: 1736
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUnifiedMessages_SendNotification([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchServiceNotification, [In] [Out] byte[] pNotificationBuffer, uint unNotificationBufferSize);

		// Token: 0x060006C9 RID: 1737
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUser_GetHSteamUser();

		// Token: 0x060006CA RID: 1738
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUser_BLoggedOn();

		// Token: 0x060006CB RID: 1739
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUser_GetSteamID();

		// Token: 0x060006CC RID: 1740
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUser_InitiateGameConnection([In] [Out] byte[] pAuthBlob, int cbMaxAuthBlob, CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer, [MarshalAs(UnmanagedType.I1)] bool bSecure);

		// Token: 0x060006CD RID: 1741
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUser_TerminateGameConnection(uint unIPServer, ushort usPortServer);

		// Token: 0x060006CE RID: 1742
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUser_TrackAppUsageEvent(CGameID gameID, int eAppUsageEvent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchExtraInfo);

		// Token: 0x060006CF RID: 1743
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUser_GetUserDataFolder(IntPtr pchBuffer, int cubBuffer);

		// Token: 0x060006D0 RID: 1744
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUser_StartVoiceRecording();

		// Token: 0x060006D1 RID: 1745
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUser_StopVoiceRecording();

		// Token: 0x060006D2 RID: 1746
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EVoiceResult ISteamUser_GetAvailableVoice(out uint pcbCompressed, out uint pcbUncompressed, uint nUncompressedVoiceDesiredSampleRate);

		// Token: 0x060006D3 RID: 1747
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EVoiceResult ISteamUser_GetVoice([MarshalAs(UnmanagedType.I1)] bool bWantCompressed, [In] [Out] byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten, [MarshalAs(UnmanagedType.I1)] bool bWantUncompressed, [In] [Out] byte[] pUncompressedDestBuffer, uint cbUncompressedDestBufferSize, out uint nUncompressBytesWritten, uint nUncompressedVoiceDesiredSampleRate);

		// Token: 0x060006D4 RID: 1748
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EVoiceResult ISteamUser_DecompressVoice([In] [Out] byte[] pCompressed, uint cbCompressed, [In] [Out] byte[] pDestBuffer, uint cbDestBufferSize, out uint nBytesWritten, uint nDesiredSampleRate);

		// Token: 0x060006D5 RID: 1749
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUser_GetVoiceOptimalSampleRate();

		// Token: 0x060006D6 RID: 1750
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUser_GetAuthSessionTicket([In] [Out] byte[] pTicket, int cbMaxTicket, out uint pcbTicket);

		// Token: 0x060006D7 RID: 1751
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EBeginAuthSessionResult ISteamUser_BeginAuthSession([In] [Out] byte[] pAuthTicket, int cbAuthTicket, CSteamID steamID);

		// Token: 0x060006D8 RID: 1752
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUser_EndAuthSession(CSteamID steamID);

		// Token: 0x060006D9 RID: 1753
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUser_CancelAuthTicket(HAuthTicket hAuthTicket);

		// Token: 0x060006DA RID: 1754
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EUserHasLicenseForAppResult ISteamUser_UserHasLicenseForApp(CSteamID steamID, AppId_t appID);

		// Token: 0x060006DB RID: 1755
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUser_BIsBehindNAT();

		// Token: 0x060006DC RID: 1756
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUser_AdvertiseGame(CSteamID steamIDGameServer, uint unIPServer, ushort usPortServer);

		// Token: 0x060006DD RID: 1757
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUser_RequestEncryptedAppTicket([In] [Out] byte[] pDataToInclude, int cbDataToInclude);

		// Token: 0x060006DE RID: 1758
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUser_GetEncryptedAppTicket([In] [Out] byte[] pTicket, int cbMaxTicket, out uint pcbTicket);

		// Token: 0x060006DF RID: 1759
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUser_GetGameBadgeLevel(int nSeries, [MarshalAs(UnmanagedType.I1)] bool bFoil);

		// Token: 0x060006E0 RID: 1760
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUser_GetPlayerSteamLevel();

		// Token: 0x060006E1 RID: 1761
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUser_RequestStoreAuthURL([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchRedirectURL);

		// Token: 0x060006E2 RID: 1762
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_RequestCurrentStats();

		// Token: 0x060006E3 RID: 1763
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out int pData);

		// Token: 0x060006E4 RID: 1764
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetStat_([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out float pData);

		// Token: 0x060006E5 RID: 1765
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_SetStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, int nData);

		// Token: 0x060006E6 RID: 1766
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_SetStat_([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, float fData);

		// Token: 0x060006E7 RID: 1767
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_UpdateAvgRateStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, float flCountThisSession, double dSessionLength);

		// Token: 0x060006E8 RID: 1768
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetAchievement([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out bool pbAchieved);

		// Token: 0x060006E9 RID: 1769
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_SetAchievement([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName);

		// Token: 0x060006EA RID: 1770
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_ClearAchievement([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName);

		// Token: 0x060006EB RID: 1771
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetAchievementAndUnlockTime([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out bool pbAchieved, out uint punUnlockTime);

		// Token: 0x060006EC RID: 1772
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_StoreStats();

		// Token: 0x060006ED RID: 1773
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUserStats_GetAchievementIcon([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName);

		// Token: 0x060006EE RID: 1774
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamUserStats_GetAchievementDisplayAttribute([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchKey);

		// Token: 0x060006EF RID: 1775
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_IndicateAchievementProgress([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, uint nCurProgress, uint nMaxProgress);

		// Token: 0x060006F0 RID: 1776
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUserStats_GetNumAchievements();

		// Token: 0x060006F1 RID: 1777
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamUserStats_GetAchievementName(uint iAchievement);

		// Token: 0x060006F2 RID: 1778
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_RequestUserStats(CSteamID steamIDUser);

		// Token: 0x060006F3 RID: 1779
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetUserStat(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out int pData);

		// Token: 0x060006F4 RID: 1780
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetUserStat_(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out float pData);

		// Token: 0x060006F5 RID: 1781
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetUserAchievement(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out bool pbAchieved);

		// Token: 0x060006F6 RID: 1782
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetUserAchievementAndUnlockTime(CSteamID steamIDUser, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out bool pbAchieved, out uint punUnlockTime);

		// Token: 0x060006F7 RID: 1783
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_ResetAllStats([MarshalAs(UnmanagedType.I1)] bool bAchievementsToo);

		// Token: 0x060006F8 RID: 1784
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_FindOrCreateLeaderboard([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchLeaderboardName, ELeaderboardSortMethod eLeaderboardSortMethod, ELeaderboardDisplayType eLeaderboardDisplayType);

		// Token: 0x060006F9 RID: 1785
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_FindLeaderboard([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchLeaderboardName);

		// Token: 0x060006FA RID: 1786
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamUserStats_GetLeaderboardName(SteamLeaderboard_t hSteamLeaderboard);

		// Token: 0x060006FB RID: 1787
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUserStats_GetLeaderboardEntryCount(SteamLeaderboard_t hSteamLeaderboard);

		// Token: 0x060006FC RID: 1788
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ELeaderboardSortMethod ISteamUserStats_GetLeaderboardSortMethod(SteamLeaderboard_t hSteamLeaderboard);

		// Token: 0x060006FD RID: 1789
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ELeaderboardDisplayType ISteamUserStats_GetLeaderboardDisplayType(SteamLeaderboard_t hSteamLeaderboard);

		// Token: 0x060006FE RID: 1790
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_DownloadLeaderboardEntries(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardDataRequest eLeaderboardDataRequest, int nRangeStart, int nRangeEnd);

		// Token: 0x060006FF RID: 1791
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_DownloadLeaderboardEntriesForUsers(SteamLeaderboard_t hSteamLeaderboard, [In] [Out] CSteamID[] prgUsers, int cUsers);

		// Token: 0x06000700 RID: 1792
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetDownloadedLeaderboardEntry(SteamLeaderboardEntries_t hSteamLeaderboardEntries, int index, out LeaderboardEntry_t pLeaderboardEntry, [In] [Out] int[] pDetails, int cDetailsMax);

		// Token: 0x06000701 RID: 1793
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_UploadLeaderboardScore(SteamLeaderboard_t hSteamLeaderboard, ELeaderboardUploadScoreMethod eLeaderboardUploadScoreMethod, int nScore, [In] [Out] int[] pScoreDetails, int cScoreDetailsCount);

		// Token: 0x06000702 RID: 1794
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_AttachLeaderboardUGC(SteamLeaderboard_t hSteamLeaderboard, UGCHandle_t hUGC);

		// Token: 0x06000703 RID: 1795
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_GetNumberOfCurrentPlayers();

		// Token: 0x06000704 RID: 1796
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_RequestGlobalAchievementPercentages();

		// Token: 0x06000705 RID: 1797
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUserStats_GetMostAchievedAchievementInfo(IntPtr pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved);

		// Token: 0x06000706 RID: 1798
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUserStats_GetNextMostAchievedAchievementInfo(int iIteratorPrevious, IntPtr pchName, uint unNameBufLen, out float pflPercent, out bool pbAchieved);

		// Token: 0x06000707 RID: 1799
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetAchievementAchievedPercent([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchName, out float pflPercent);

		// Token: 0x06000708 RID: 1800
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUserStats_RequestGlobalStats(int nHistoryDays);

		// Token: 0x06000709 RID: 1801
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetGlobalStat([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchStatName, out long pData);

		// Token: 0x0600070A RID: 1802
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUserStats_GetGlobalStat_([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchStatName, out double pData);

		// Token: 0x0600070B RID: 1803
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUserStats_GetGlobalStatHistory([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchStatName, [In] [Out] long[] pData, uint cubData);

		// Token: 0x0600070C RID: 1804
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern int ISteamUserStats_GetGlobalStatHistory_([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchStatName, [In] [Out] double[] pData, uint cubData);

		// Token: 0x0600070D RID: 1805
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUtils_GetSecondsSinceAppActive();

		// Token: 0x0600070E RID: 1806
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUtils_GetSecondsSinceComputerActive();

		// Token: 0x0600070F RID: 1807
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern EUniverse ISteamUtils_GetConnectedUniverse();

		// Token: 0x06000710 RID: 1808
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUtils_GetServerRealTime();

		// Token: 0x06000711 RID: 1809
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamUtils_GetIPCountry();

		// Token: 0x06000712 RID: 1810
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_GetImageSize(int iImage, out uint pnWidth, out uint pnHeight);

		// Token: 0x06000713 RID: 1811
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_GetImageRGBA(int iImage, [In] [Out] byte[] pubDest, int nDestBufferSize);

		// Token: 0x06000714 RID: 1812
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_GetCSERIPPort(out uint unIP, out ushort usPort);

		// Token: 0x06000715 RID: 1813
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern byte ISteamUtils_GetCurrentBatteryPower();

		// Token: 0x06000716 RID: 1814
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUtils_GetAppID();

		// Token: 0x06000717 RID: 1815
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUtils_SetOverlayNotificationPosition(ENotificationPosition eNotificationPosition);

		// Token: 0x06000718 RID: 1816
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_IsAPICallCompleted(SteamAPICall_t hSteamAPICall, out bool pbFailed);

		// Token: 0x06000719 RID: 1817
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ESteamAPICallFailure ISteamUtils_GetAPICallFailureReason(SteamAPICall_t hSteamAPICall);

		// Token: 0x0600071A RID: 1818
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_GetAPICallResult(SteamAPICall_t hSteamAPICall, IntPtr pCallback, int cubCallback, int iCallbackExpected, out bool pbFailed);

		// Token: 0x0600071B RID: 1819
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUtils_RunFrame();

		// Token: 0x0600071C RID: 1820
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUtils_GetIPCCallCount();

		// Token: 0x0600071D RID: 1821
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamUtils_SetWarningMessageHook(SteamAPIWarningMessageHook_t pFunction);

		// Token: 0x0600071E RID: 1822
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_IsOverlayEnabled();

		// Token: 0x0600071F RID: 1823
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_BOverlayNeedsPresent();

		// Token: 0x06000720 RID: 1824
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern ulong ISteamUtils_CheckFileSignature([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string szFileName);

		// Token: 0x06000721 RID: 1825
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_ShowGamepadTextInput(EGamepadTextInputMode eInputMode, EGamepadTextInputLineMode eLineInputMode, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchDescription, uint unCharMax, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler))] string pchExistingText);

		// Token: 0x06000722 RID: 1826
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint ISteamUtils_GetEnteredGamepadTextLength();

		// Token: 0x06000723 RID: 1827
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_GetEnteredGamepadTextInput(IntPtr pchText, uint cchText);

		// Token: 0x06000724 RID: 1828
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8Marshaler), MarshalCookie = "DoNotFree")]
		public static extern string ISteamUtils_GetSteamUILanguage();

		// Token: 0x06000725 RID: 1829
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool ISteamUtils_IsSteamRunningInVR();

		// Token: 0x06000726 RID: 1830
		[DllImport("CSteamworks", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ISteamVideo_GetVideoURL(AppId_t unVideoAppID);

		// Token: 0x04000342 RID: 834
		internal const string NativeLibraryName = "CSteamworks";
	}
}
