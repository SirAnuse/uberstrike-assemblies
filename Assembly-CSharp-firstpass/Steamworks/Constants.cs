using System;

namespace Steamworks
{
	// Token: 0x0200014C RID: 332
	public static class Constants
	{
		// Token: 0x0400059D RID: 1437
		public const string STEAMAPPLIST_INTERFACE_VERSION = "STEAMAPPLIST_INTERFACE_VERSION001";

		// Token: 0x0400059E RID: 1438
		public const string STEAMAPPS_INTERFACE_VERSION = "STEAMAPPS_INTERFACE_VERSION007";

		// Token: 0x0400059F RID: 1439
		public const string STEAMAPPTICKET_INTERFACE_VERSION = "STEAMAPPTICKET_INTERFACE_VERSION001";

		// Token: 0x040005A0 RID: 1440
		public const string STEAMCLIENT_INTERFACE_VERSION = "SteamClient017";

		// Token: 0x040005A1 RID: 1441
		public const string STEAMCONTROLLER_INTERFACE_VERSION = "STEAMCONTROLLER_INTERFACE_VERSION";

		// Token: 0x040005A2 RID: 1442
		public const string STEAMFRIENDS_INTERFACE_VERSION = "SteamFriends015";

		// Token: 0x040005A3 RID: 1443
		public const string STEAMGAMECOORDINATOR_INTERFACE_VERSION = "SteamGameCoordinator001";

		// Token: 0x040005A4 RID: 1444
		public const string STEAMGAMESERVER_INTERFACE_VERSION = "SteamGameServer012";

		// Token: 0x040005A5 RID: 1445
		public const string STEAMGAMESERVERSTATS_INTERFACE_VERSION = "SteamGameServerStats001";

		// Token: 0x040005A6 RID: 1446
		public const string STEAMHTMLSURFACE_INTERFACE_VERSION = "STEAMHTMLSURFACE_INTERFACE_VERSION_002";

		// Token: 0x040005A7 RID: 1447
		public const string STEAMHTTP_INTERFACE_VERSION = "STEAMHTTP_INTERFACE_VERSION002";

		// Token: 0x040005A8 RID: 1448
		public const string STEAMINVENTORY_INTERFACE_VERSION = "STEAMINVENTORY_INTERFACE_V001";

		// Token: 0x040005A9 RID: 1449
		public const string STEAMMATCHMAKING_INTERFACE_VERSION = "SteamMatchMaking009";

		// Token: 0x040005AA RID: 1450
		public const string STEAMMATCHMAKINGSERVERS_INTERFACE_VERSION = "SteamMatchMakingServers002";

		// Token: 0x040005AB RID: 1451
		public const string STEAMMUSIC_INTERFACE_VERSION = "STEAMMUSIC_INTERFACE_VERSION001";

		// Token: 0x040005AC RID: 1452
		public const string STEAMMUSICREMOTE_INTERFACE_VERSION = "STEAMMUSICREMOTE_INTERFACE_VERSION001";

		// Token: 0x040005AD RID: 1453
		public const string STEAMNETWORKING_INTERFACE_VERSION = "SteamNetworking005";

		// Token: 0x040005AE RID: 1454
		public const string STEAMREMOTESTORAGE_INTERFACE_VERSION = "STEAMREMOTESTORAGE_INTERFACE_VERSION012";

		// Token: 0x040005AF RID: 1455
		public const string STEAMSCREENSHOTS_INTERFACE_VERSION = "STEAMSCREENSHOTS_INTERFACE_VERSION002";

		// Token: 0x040005B0 RID: 1456
		public const string STEAMUGC_INTERFACE_VERSION = "STEAMUGC_INTERFACE_VERSION003";

		// Token: 0x040005B1 RID: 1457
		public const string STEAMUNIFIEDMESSAGES_INTERFACE_VERSION = "STEAMUNIFIEDMESSAGES_INTERFACE_VERSION001";

		// Token: 0x040005B2 RID: 1458
		public const string STEAMUSER_INTERFACE_VERSION = "SteamUser018";

		// Token: 0x040005B3 RID: 1459
		public const string STEAMUSERSTATS_INTERFACE_VERSION = "STEAMUSERSTATS_INTERFACE_VERSION011";

		// Token: 0x040005B4 RID: 1460
		public const string STEAMUTILS_INTERFACE_VERSION = "SteamUtils007";

		// Token: 0x040005B5 RID: 1461
		public const string STEAMVIDEO_INTERFACE_VERSION = "STEAMVIDEO_INTERFACE_V001";

		// Token: 0x040005B6 RID: 1462
		public const int k_cubAppProofOfPurchaseKeyMax = 64;

		// Token: 0x040005B7 RID: 1463
		public const int k_iSteamUserCallbacks = 100;

		// Token: 0x040005B8 RID: 1464
		public const int k_iSteamGameServerCallbacks = 200;

		// Token: 0x040005B9 RID: 1465
		public const int k_iSteamFriendsCallbacks = 300;

		// Token: 0x040005BA RID: 1466
		public const int k_iSteamBillingCallbacks = 400;

		// Token: 0x040005BB RID: 1467
		public const int k_iSteamMatchmakingCallbacks = 500;

		// Token: 0x040005BC RID: 1468
		public const int k_iSteamContentServerCallbacks = 600;

		// Token: 0x040005BD RID: 1469
		public const int k_iSteamUtilsCallbacks = 700;

		// Token: 0x040005BE RID: 1470
		public const int k_iClientFriendsCallbacks = 800;

		// Token: 0x040005BF RID: 1471
		public const int k_iClientUserCallbacks = 900;

		// Token: 0x040005C0 RID: 1472
		public const int k_iSteamAppsCallbacks = 1000;

		// Token: 0x040005C1 RID: 1473
		public const int k_iSteamUserStatsCallbacks = 1100;

		// Token: 0x040005C2 RID: 1474
		public const int k_iSteamNetworkingCallbacks = 1200;

		// Token: 0x040005C3 RID: 1475
		public const int k_iClientRemoteStorageCallbacks = 1300;

		// Token: 0x040005C4 RID: 1476
		public const int k_iClientDepotBuilderCallbacks = 1400;

		// Token: 0x040005C5 RID: 1477
		public const int k_iSteamGameServerItemsCallbacks = 1500;

		// Token: 0x040005C6 RID: 1478
		public const int k_iClientUtilsCallbacks = 1600;

		// Token: 0x040005C7 RID: 1479
		public const int k_iSteamGameCoordinatorCallbacks = 1700;

		// Token: 0x040005C8 RID: 1480
		public const int k_iSteamGameServerStatsCallbacks = 1800;

		// Token: 0x040005C9 RID: 1481
		public const int k_iSteam2AsyncCallbacks = 1900;

		// Token: 0x040005CA RID: 1482
		public const int k_iSteamGameStatsCallbacks = 2000;

		// Token: 0x040005CB RID: 1483
		public const int k_iClientHTTPCallbacks = 2100;

		// Token: 0x040005CC RID: 1484
		public const int k_iClientScreenshotsCallbacks = 2200;

		// Token: 0x040005CD RID: 1485
		public const int k_iSteamScreenshotsCallbacks = 2300;

		// Token: 0x040005CE RID: 1486
		public const int k_iClientAudioCallbacks = 2400;

		// Token: 0x040005CF RID: 1487
		public const int k_iClientUnifiedMessagesCallbacks = 2500;

		// Token: 0x040005D0 RID: 1488
		public const int k_iSteamStreamLauncherCallbacks = 2600;

		// Token: 0x040005D1 RID: 1489
		public const int k_iClientControllerCallbacks = 2700;

		// Token: 0x040005D2 RID: 1490
		public const int k_iSteamControllerCallbacks = 2800;

		// Token: 0x040005D3 RID: 1491
		public const int k_iClientParentalSettingsCallbacks = 2900;

		// Token: 0x040005D4 RID: 1492
		public const int k_iClientDeviceAuthCallbacks = 3000;

		// Token: 0x040005D5 RID: 1493
		public const int k_iClientNetworkDeviceManagerCallbacks = 3100;

		// Token: 0x040005D6 RID: 1494
		public const int k_iClientMusicCallbacks = 3200;

		// Token: 0x040005D7 RID: 1495
		public const int k_iClientRemoteClientManagerCallbacks = 3300;

		// Token: 0x040005D8 RID: 1496
		public const int k_iClientUGCCallbacks = 3400;

		// Token: 0x040005D9 RID: 1497
		public const int k_iSteamStreamClientCallbacks = 3500;

		// Token: 0x040005DA RID: 1498
		public const int k_IClientProductBuilderCallbacks = 3600;

		// Token: 0x040005DB RID: 1499
		public const int k_iClientShortcutsCallbacks = 3700;

		// Token: 0x040005DC RID: 1500
		public const int k_iClientRemoteControlManagerCallbacks = 3800;

		// Token: 0x040005DD RID: 1501
		public const int k_iSteamAppListCallbacks = 3900;

		// Token: 0x040005DE RID: 1502
		public const int k_iSteamMusicCallbacks = 4000;

		// Token: 0x040005DF RID: 1503
		public const int k_iSteamMusicRemoteCallbacks = 4100;

		// Token: 0x040005E0 RID: 1504
		public const int k_iClientVRCallbacks = 4200;

		// Token: 0x040005E1 RID: 1505
		public const int k_iClientReservedCallbacks = 4300;

		// Token: 0x040005E2 RID: 1506
		public const int k_iSteamReservedCallbacks = 4400;

		// Token: 0x040005E3 RID: 1507
		public const int k_iSteamHTMLSurfaceCallbacks = 4500;

		// Token: 0x040005E4 RID: 1508
		public const int k_iClientVideoCallbacks = 4600;

		// Token: 0x040005E5 RID: 1509
		public const int k_iClientInventoryCallbacks = 4700;

		// Token: 0x040005E6 RID: 1510
		public const int k_cchMaxFriendsGroupName = 64;

		// Token: 0x040005E7 RID: 1511
		public const int k_cFriendsGroupLimit = 100;

		// Token: 0x040005E8 RID: 1512
		public const int k_cEnumerateFollowersMax = 50;

		// Token: 0x040005E9 RID: 1513
		public const int k_cchPersonaNameMax = 128;

		// Token: 0x040005EA RID: 1514
		public const int k_cwchPersonaNameMax = 32;

		// Token: 0x040005EB RID: 1515
		public const int k_cubChatMetadataMax = 8192;

		// Token: 0x040005EC RID: 1516
		public const int k_cchMaxRichPresenceKeys = 20;

		// Token: 0x040005ED RID: 1517
		public const int k_cchMaxRichPresenceKeyLength = 64;

		// Token: 0x040005EE RID: 1518
		public const int k_cchMaxRichPresenceValueLength = 256;

		// Token: 0x040005EF RID: 1519
		public const int k_unServerFlagNone = 0;

		// Token: 0x040005F0 RID: 1520
		public const int k_unServerFlagActive = 1;

		// Token: 0x040005F1 RID: 1521
		public const int k_unServerFlagSecure = 2;

		// Token: 0x040005F2 RID: 1522
		public const int k_unServerFlagDedicated = 4;

		// Token: 0x040005F3 RID: 1523
		public const int k_unServerFlagLinux = 8;

		// Token: 0x040005F4 RID: 1524
		public const int k_unServerFlagPassworded = 16;

		// Token: 0x040005F5 RID: 1525
		public const int k_unServerFlagPrivate = 32;

		// Token: 0x040005F6 RID: 1526
		public const int k_unFavoriteFlagNone = 0;

		// Token: 0x040005F7 RID: 1527
		public const int k_unFavoriteFlagFavorite = 1;

		// Token: 0x040005F8 RID: 1528
		public const int k_unFavoriteFlagHistory = 2;

		// Token: 0x040005F9 RID: 1529
		public const int k_unMaxCloudFileChunkSize = 104857600;

		// Token: 0x040005FA RID: 1530
		public const int k_cchPublishedDocumentTitleMax = 129;

		// Token: 0x040005FB RID: 1531
		public const int k_cchPublishedDocumentDescriptionMax = 8000;

		// Token: 0x040005FC RID: 1532
		public const int k_cchPublishedDocumentChangeDescriptionMax = 8000;

		// Token: 0x040005FD RID: 1533
		public const int k_unEnumeratePublishedFilesMaxResults = 50;

		// Token: 0x040005FE RID: 1534
		public const int k_cchTagListMax = 1025;

		// Token: 0x040005FF RID: 1535
		public const int k_cchFilenameMax = 260;

		// Token: 0x04000600 RID: 1536
		public const int k_cchPublishedFileURLMax = 256;

		// Token: 0x04000601 RID: 1537
		public const int k_nScreenshotMaxTaggedUsers = 32;

		// Token: 0x04000602 RID: 1538
		public const int k_nScreenshotMaxTaggedPublishedFiles = 32;

		// Token: 0x04000603 RID: 1539
		public const int k_cubUFSTagTypeMax = 255;

		// Token: 0x04000604 RID: 1540
		public const int k_cubUFSTagValueMax = 255;

		// Token: 0x04000605 RID: 1541
		public const int k_ScreenshotThumbWidth = 200;

		// Token: 0x04000606 RID: 1542
		public const int kNumUGCResultsPerPage = 50;

		// Token: 0x04000607 RID: 1543
		public const int k_cchStatNameMax = 128;

		// Token: 0x04000608 RID: 1544
		public const int k_cchLeaderboardNameMax = 128;

		// Token: 0x04000609 RID: 1545
		public const int k_cLeaderboardDetailsMax = 64;

		// Token: 0x0400060A RID: 1546
		public const int k_cbMaxGameServerGameDir = 32;

		// Token: 0x0400060B RID: 1547
		public const int k_cbMaxGameServerMapName = 32;

		// Token: 0x0400060C RID: 1548
		public const int k_cbMaxGameServerGameDescription = 64;

		// Token: 0x0400060D RID: 1549
		public const int k_cbMaxGameServerName = 64;

		// Token: 0x0400060E RID: 1550
		public const int k_cbMaxGameServerTags = 128;

		// Token: 0x0400060F RID: 1551
		public const int k_cbMaxGameServerGameData = 2048;

		// Token: 0x04000610 RID: 1552
		public const int k_unSteamAccountIDMask = -1;

		// Token: 0x04000611 RID: 1553
		public const int k_unSteamAccountInstanceMask = 1048575;

		// Token: 0x04000612 RID: 1554
		public const int k_unSteamUserDesktopInstance = 1;

		// Token: 0x04000613 RID: 1555
		public const int k_unSteamUserConsoleInstance = 2;

		// Token: 0x04000614 RID: 1556
		public const int k_unSteamUserWebInstance = 4;

		// Token: 0x04000615 RID: 1557
		public const int k_cchGameExtraInfoMax = 64;

		// Token: 0x04000616 RID: 1558
		public const int k_nSteamEncryptedAppTicketSymmetricKeyLen = 32;

		// Token: 0x04000617 RID: 1559
		public const int k_cubSaltSize = 8;

		// Token: 0x04000618 RID: 1560
		public const ulong k_GIDNil = 18446744073709551615UL;

		// Token: 0x04000619 RID: 1561
		public const ulong k_TxnIDNil = 18446744073709551615UL;

		// Token: 0x0400061A RID: 1562
		public const ulong k_TxnIDUnknown = 0UL;

		// Token: 0x0400061B RID: 1563
		public const uint k_uPackageIdFreeSub = 0u;

		// Token: 0x0400061C RID: 1564
		public const uint k_uPackageIdInvalid = 4294967295u;

		// Token: 0x0400061D RID: 1565
		public const ulong k_ulAssetClassIdInvalid = 0UL;

		// Token: 0x0400061E RID: 1566
		public const uint k_uPhysicalItemIdInvalid = 0u;

		// Token: 0x0400061F RID: 1567
		public const uint k_uCellIDInvalid = 4294967295u;

		// Token: 0x04000620 RID: 1568
		public const uint k_uPartnerIdInvalid = 0u;

		// Token: 0x04000621 RID: 1569
		public const short MASTERSERVERUPDATERPORT_USEGAMESOCKETSHARE = -1;

		// Token: 0x04000622 RID: 1570
		public const byte INVALID_HTTPREQUEST_HANDLE = 0;

		// Token: 0x04000623 RID: 1571
		public const byte k_nMaxLobbyKeyLength = 255;

		// Token: 0x04000624 RID: 1572
		public const int k_SteamMusicNameMaxLength = 255;

		// Token: 0x04000625 RID: 1573
		public const int k_SteamMusicPNGMaxLength = 65535;

		// Token: 0x04000626 RID: 1574
		public const int QUERY_PORT_NOT_INITIALIZED = 65535;

		// Token: 0x04000627 RID: 1575
		public const int QUERY_PORT_ERROR = 65534;

		// Token: 0x04000628 RID: 1576
		public const ulong STEAM_RIGHT_TRIGGER_MASK = 1UL;

		// Token: 0x04000629 RID: 1577
		public const ulong STEAM_LEFT_TRIGGER_MASK = 2UL;

		// Token: 0x0400062A RID: 1578
		public const ulong STEAM_RIGHT_BUMPER_MASK = 4UL;

		// Token: 0x0400062B RID: 1579
		public const ulong STEAM_LEFT_BUMPER_MASK = 8UL;

		// Token: 0x0400062C RID: 1580
		public const ulong STEAM_BUTTON_0_MASK = 16UL;

		// Token: 0x0400062D RID: 1581
		public const ulong STEAM_BUTTON_1_MASK = 32UL;

		// Token: 0x0400062E RID: 1582
		public const ulong STEAM_BUTTON_2_MASK = 64UL;

		// Token: 0x0400062F RID: 1583
		public const ulong STEAM_BUTTON_3_MASK = 128UL;

		// Token: 0x04000630 RID: 1584
		public const ulong STEAM_TOUCH_0_MASK = 256UL;

		// Token: 0x04000631 RID: 1585
		public const ulong STEAM_TOUCH_1_MASK = 512UL;

		// Token: 0x04000632 RID: 1586
		public const ulong STEAM_TOUCH_2_MASK = 1024UL;

		// Token: 0x04000633 RID: 1587
		public const ulong STEAM_TOUCH_3_MASK = 2048UL;

		// Token: 0x04000634 RID: 1588
		public const ulong STEAM_BUTTON_MENU_MASK = 4096UL;

		// Token: 0x04000635 RID: 1589
		public const ulong STEAM_BUTTON_STEAM_MASK = 8192UL;

		// Token: 0x04000636 RID: 1590
		public const ulong STEAM_BUTTON_ESCAPE_MASK = 16384UL;

		// Token: 0x04000637 RID: 1591
		public const ulong STEAM_BUTTON_BACK_LEFT_MASK = 32768UL;

		// Token: 0x04000638 RID: 1592
		public const ulong STEAM_BUTTON_BACK_RIGHT_MASK = 65536UL;

		// Token: 0x04000639 RID: 1593
		public const ulong STEAM_BUTTON_LEFTPAD_CLICKED_MASK = 131072UL;

		// Token: 0x0400063A RID: 1594
		public const ulong STEAM_BUTTON_RIGHTPAD_CLICKED_MASK = 262144UL;

		// Token: 0x0400063B RID: 1595
		public const ulong STEAM_LEFTPAD_FINGERDOWN_MASK = 524288UL;

		// Token: 0x0400063C RID: 1596
		public const ulong STEAM_RIGHTPAD_FINGERDOWN_MASK = 1048576UL;

		// Token: 0x0400063D RID: 1597
		public const byte MAX_STEAM_CONTROLLERS = 8;
	}
}
