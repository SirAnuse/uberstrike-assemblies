using System;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public static class GameAudio
{
	// Token: 0x060004CD RID: 1229 RVA: 0x0002F690 File Offset: 0x0002D890
	static GameAudio()
	{
		AudioClipConfigurator component;
		try
		{
			component = GameObject.Find("GameAudio").GetComponent<AudioClipConfigurator>();
		}
		catch
		{
			Debug.LogError("Missing instance of the prefab with name: GameAudio!");
			return;
		}
		GameAudio.HomeSceneBackground = component.Assets[0];
		GameAudio.BigSplash = component.Assets[1];
		GameAudio.ImpactCement1 = component.Assets[2];
		GameAudio.ImpactCement2 = component.Assets[3];
		GameAudio.ImpactCement3 = component.Assets[4];
		GameAudio.ImpactCement4 = component.Assets[5];
		GameAudio.ImpactGlass1 = component.Assets[6];
		GameAudio.ImpactGlass2 = component.Assets[7];
		GameAudio.ImpactGlass3 = component.Assets[8];
		GameAudio.ImpactGlass4 = component.Assets[9];
		GameAudio.ImpactGlass5 = component.Assets[10];
		GameAudio.ImpactGrass1 = component.Assets[11];
		GameAudio.ImpactGrass2 = component.Assets[12];
		GameAudio.ImpactGrass3 = component.Assets[13];
		GameAudio.ImpactGrass4 = component.Assets[14];
		GameAudio.ImpactMetal1 = component.Assets[15];
		GameAudio.ImpactMetal2 = component.Assets[16];
		GameAudio.ImpactMetal3 = component.Assets[17];
		GameAudio.ImpactMetal4 = component.Assets[18];
		GameAudio.ImpactMetal5 = component.Assets[19];
		GameAudio.ImpactSand1 = component.Assets[20];
		GameAudio.ImpactSand2 = component.Assets[21];
		GameAudio.ImpactSand3 = component.Assets[22];
		GameAudio.ImpactSand4 = component.Assets[23];
		GameAudio.ImpactSand5 = component.Assets[24];
		GameAudio.ImpactStone1 = component.Assets[25];
		GameAudio.ImpactStone2 = component.Assets[26];
		GameAudio.ImpactStone3 = component.Assets[27];
		GameAudio.ImpactStone4 = component.Assets[28];
		GameAudio.ImpactStone5 = component.Assets[29];
		GameAudio.ImpactWater1 = component.Assets[30];
		GameAudio.ImpactWater2 = component.Assets[31];
		GameAudio.ImpactWater3 = component.Assets[32];
		GameAudio.ImpactWater4 = component.Assets[33];
		GameAudio.ImpactWater5 = component.Assets[34];
		GameAudio.ImpactWood1 = component.Assets[35];
		GameAudio.ImpactWood2 = component.Assets[36];
		GameAudio.ImpactWood3 = component.Assets[37];
		GameAudio.ImpactWood4 = component.Assets[38];
		GameAudio.ImpactWood5 = component.Assets[39];
		GameAudio.MediumSplash = component.Assets[40];
		GameAudio.BlueWins = component.Assets[41];
		GameAudio.CountdownTonal1 = component.Assets[42];
		GameAudio.CountdownTonal2 = component.Assets[43];
		GameAudio.Draw = component.Assets[44];
		GameAudio.Fight = component.Assets[45];
		GameAudio.FocusEnemy = component.Assets[46];
		GameAudio.GameOver = component.Assets[47];
		GameAudio.GetPoints = component.Assets[48];
		GameAudio.GetXP = component.Assets[49];
		GameAudio.LevelUp = component.Assets[50];
		GameAudio.LostLead = component.Assets[51];
		GameAudio.MatchEndingCountdown1 = component.Assets[52];
		GameAudio.MatchEndingCountdown2 = component.Assets[53];
		GameAudio.MatchEndingCountdown3 = component.Assets[54];
		GameAudio.MatchEndingCountdown4 = component.Assets[55];
		GameAudio.MatchEndingCountdown5 = component.Assets[56];
		GameAudio.RedWins = component.Assets[57];
		GameAudio.TakenLead = component.Assets[58];
		GameAudio.TiedLead = component.Assets[59];
		GameAudio.YouWin = component.Assets[60];
		GameAudio.AmmoPickup2D = component.Assets[61];
		GameAudio.ArmorShard2D = component.Assets[62];
		GameAudio.BigHealth2D = component.Assets[63];
		GameAudio.GoldArmor2D = component.Assets[64];
		GameAudio.MediumHealth2D = component.Assets[65];
		GameAudio.MegaHealth2D = component.Assets[66];
		GameAudio.SilverArmor2D = component.Assets[67];
		GameAudio.SmallHealth2D = component.Assets[68];
		GameAudio.WeaponPickup2D = component.Assets[69];
		GameAudio.HealthCriticalHeartbeat = component.Assets[70];
		GameAudio.HealthCriticalNoise = component.Assets[71];
		GameAudio.HealthOver100Decrease = component.Assets[72];
		GameAudio.HealthOver100Increase = component.Assets[73];
		GameAudio.FootStepDirt1 = component.Assets[74];
		GameAudio.FootStepDirt2 = component.Assets[75];
		GameAudio.FootStepDirt3 = component.Assets[76];
		GameAudio.FootStepDirt4 = component.Assets[77];
		GameAudio.FootStepGlass1 = component.Assets[78];
		GameAudio.FootStepGlass2 = component.Assets[79];
		GameAudio.FootStepGlass3 = component.Assets[80];
		GameAudio.FootStepGlass4 = component.Assets[81];
		GameAudio.FootStepGrass1 = component.Assets[82];
		GameAudio.FootStepGrass2 = component.Assets[83];
		GameAudio.FootStepGrass3 = component.Assets[84];
		GameAudio.FootStepGrass4 = component.Assets[85];
		GameAudio.FootStepHeavyMetal1 = component.Assets[86];
		GameAudio.FootStepHeavyMetal2 = component.Assets[87];
		GameAudio.FootStepHeavyMetal3 = component.Assets[88];
		GameAudio.FootStepHeavyMetal4 = component.Assets[89];
		GameAudio.FootStepMetal1 = component.Assets[90];
		GameAudio.FootStepMetal2 = component.Assets[91];
		GameAudio.FootStepMetal3 = component.Assets[92];
		GameAudio.FootStepMetal4 = component.Assets[93];
		GameAudio.FootStepRock1 = component.Assets[94];
		GameAudio.FootStepRock2 = component.Assets[95];
		GameAudio.FootStepRock3 = component.Assets[96];
		GameAudio.FootStepRock4 = component.Assets[97];
		GameAudio.FootStepSand1 = component.Assets[98];
		GameAudio.FootStepSand2 = component.Assets[99];
		GameAudio.FootStepSand3 = component.Assets[100];
		GameAudio.FootStepSand4 = component.Assets[101];
		GameAudio.FootStepSnow1 = component.Assets[102];
		GameAudio.FootStepSnow2 = component.Assets[103];
		GameAudio.FootStepSnow3 = component.Assets[104];
		GameAudio.FootStepSnow4 = component.Assets[105];
		GameAudio.FootStepWater1 = component.Assets[106];
		GameAudio.FootStepWater2 = component.Assets[107];
		GameAudio.FootStepWater3 = component.Assets[108];
		GameAudio.FootStepWood1 = component.Assets[109];
		GameAudio.FootStepWood2 = component.Assets[110];
		GameAudio.FootStepWood3 = component.Assets[111];
		GameAudio.FootStepWood4 = component.Assets[112];
		GameAudio.GotHeadshotKill = component.Assets[113];
		GameAudio.GotNutshotKill = component.Assets[114];
		GameAudio.KilledBySplatbat = component.Assets[115];
		GameAudio.LandingGrunt = component.Assets[116];
		GameAudio.LocalPlayerHitArmorRemaining = component.Assets[117];
		GameAudio.LocalPlayerHitNoArmor = component.Assets[118];
		GameAudio.LocalPlayerHitNoArmorLowHealth = component.Assets[119];
		GameAudio.NormalKill1 = component.Assets[120];
		GameAudio.NormalKill2 = component.Assets[121];
		GameAudio.NormalKill3 = component.Assets[122];
		GameAudio.PlayerJump2D = component.Assets[123];
		GameAudio.QuickItemRecharge = component.Assets[124];
		GameAudio.SwimAboveWater1 = component.Assets[125];
		GameAudio.SwimAboveWater2 = component.Assets[126];
		GameAudio.SwimAboveWater3 = component.Assets[127];
		GameAudio.SwimAboveWater4 = component.Assets[128];
		GameAudio.SwimUnderWater = component.Assets[129];
		GameAudio.AmmoPickup = component.Assets[130];
		GameAudio.ArmorShard = component.Assets[131];
		GameAudio.BigHealth = component.Assets[132];
		GameAudio.GoldArmor = component.Assets[133];
		GameAudio.JumpPad = component.Assets[134];
		GameAudio.JumpPad2D = component.Assets[135];
		GameAudio.MediumHealth = component.Assets[136];
		GameAudio.MegaHealth = component.Assets[137];
		GameAudio.SilverArmor = component.Assets[138];
		GameAudio.SmallHealth = component.Assets[139];
		GameAudio.TargetDamage = component.Assets[140];
		GameAudio.TargetPopup = component.Assets[141];
		GameAudio.WeaponPickup = component.Assets[142];
		GameAudio.ButtonClick = component.Assets[143];
		GameAudio.ClickReady = component.Assets[144];
		GameAudio.ClickUnready = component.Assets[145];
		GameAudio.ClosePanel = component.Assets[146];
		GameAudio.CreateGame = component.Assets[147];
		GameAudio.DoubleKill = component.Assets[148];
		GameAudio.EndOfRound = component.Assets[149];
		GameAudio.EquipGear = component.Assets[150];
		GameAudio.EquipItem = component.Assets[151];
		GameAudio.EquipWeapon = component.Assets[152];
		GameAudio.FBScreenshot = component.Assets[153];
		GameAudio.HeadShot = component.Assets[154];
		GameAudio.JoinServer = component.Assets[155];
		GameAudio.KillLeft1 = component.Assets[156];
		GameAudio.KillLeft2 = component.Assets[157];
		GameAudio.KillLeft3 = component.Assets[158];
		GameAudio.KillLeft4 = component.Assets[159];
		GameAudio.KillLeft5 = component.Assets[160];
		GameAudio.LeaveServer = component.Assets[161];
		GameAudio.MegaKill = component.Assets[162];
		GameAudio.NewMessage = component.Assets[163];
		GameAudio.NewRequest = component.Assets[164];
		GameAudio.NutShot = component.Assets[165];
		GameAudio.Objective = component.Assets[166];
		GameAudio.ObjectiveTick = component.Assets[167];
		GameAudio.OpenPanel = component.Assets[168];
		GameAudio.QuadKill = component.Assets[169];
		GameAudio.RibbonClick = component.Assets[170];
		GameAudio.Smackdown = component.Assets[171];
		GameAudio.SubObjective = component.Assets[172];
		GameAudio.TripleKill = component.Assets[173];
		GameAudio.UberKill = component.Assets[174];
		GameAudio.LauncherBounce1 = component.Assets[175];
		GameAudio.LauncherBounce2 = component.Assets[176];
		GameAudio.OutOfAmmoClick = component.Assets[177];
		GameAudio.SniperScopeIn = component.Assets[178];
		GameAudio.SniperScopeOut = component.Assets[179];
		GameAudio.SniperZoomIn = component.Assets[180];
		GameAudio.SniperZoomOut = component.Assets[181];
		GameAudio.UnderwaterExplosion1 = component.Assets[182];
		GameAudio.UnderwaterExplosion2 = component.Assets[183];
		GameAudio.WeaponSwitch = component.Assets[184];
	}

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x060004CE RID: 1230 RVA: 0x00005626 File Offset: 0x00003826
	// (set) Token: 0x060004CF RID: 1231 RVA: 0x0000562D File Offset: 0x0000382D
	public static AudioClip HomeSceneBackground { get; private set; }

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00005635 File Offset: 0x00003835
	// (set) Token: 0x060004D1 RID: 1233 RVA: 0x0000563C File Offset: 0x0000383C
	public static AudioClip BigSplash { get; private set; }

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x060004D2 RID: 1234 RVA: 0x00005644 File Offset: 0x00003844
	// (set) Token: 0x060004D3 RID: 1235 RVA: 0x0000564B File Offset: 0x0000384B
	public static AudioClip ImpactCement1 { get; private set; }

	// Token: 0x17000104 RID: 260
	// (get) Token: 0x060004D4 RID: 1236 RVA: 0x00005653 File Offset: 0x00003853
	// (set) Token: 0x060004D5 RID: 1237 RVA: 0x0000565A File Offset: 0x0000385A
	public static AudioClip ImpactCement2 { get; private set; }

	// Token: 0x17000105 RID: 261
	// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00005662 File Offset: 0x00003862
	// (set) Token: 0x060004D7 RID: 1239 RVA: 0x00005669 File Offset: 0x00003869
	public static AudioClip ImpactCement3 { get; private set; }

	// Token: 0x17000106 RID: 262
	// (get) Token: 0x060004D8 RID: 1240 RVA: 0x00005671 File Offset: 0x00003871
	// (set) Token: 0x060004D9 RID: 1241 RVA: 0x00005678 File Offset: 0x00003878
	public static AudioClip ImpactCement4 { get; private set; }

	// Token: 0x17000107 RID: 263
	// (get) Token: 0x060004DA RID: 1242 RVA: 0x00005680 File Offset: 0x00003880
	// (set) Token: 0x060004DB RID: 1243 RVA: 0x00005687 File Offset: 0x00003887
	public static AudioClip ImpactGlass1 { get; private set; }

	// Token: 0x17000108 RID: 264
	// (get) Token: 0x060004DC RID: 1244 RVA: 0x0000568F File Offset: 0x0000388F
	// (set) Token: 0x060004DD RID: 1245 RVA: 0x00005696 File Offset: 0x00003896
	public static AudioClip ImpactGlass2 { get; private set; }

	// Token: 0x17000109 RID: 265
	// (get) Token: 0x060004DE RID: 1246 RVA: 0x0000569E File Offset: 0x0000389E
	// (set) Token: 0x060004DF RID: 1247 RVA: 0x000056A5 File Offset: 0x000038A5
	public static AudioClip ImpactGlass3 { get; private set; }

	// Token: 0x1700010A RID: 266
	// (get) Token: 0x060004E0 RID: 1248 RVA: 0x000056AD File Offset: 0x000038AD
	// (set) Token: 0x060004E1 RID: 1249 RVA: 0x000056B4 File Offset: 0x000038B4
	public static AudioClip ImpactGlass4 { get; private set; }

	// Token: 0x1700010B RID: 267
	// (get) Token: 0x060004E2 RID: 1250 RVA: 0x000056BC File Offset: 0x000038BC
	// (set) Token: 0x060004E3 RID: 1251 RVA: 0x000056C3 File Offset: 0x000038C3
	public static AudioClip ImpactGlass5 { get; private set; }

	// Token: 0x1700010C RID: 268
	// (get) Token: 0x060004E4 RID: 1252 RVA: 0x000056CB File Offset: 0x000038CB
	// (set) Token: 0x060004E5 RID: 1253 RVA: 0x000056D2 File Offset: 0x000038D2
	public static AudioClip ImpactGrass1 { get; private set; }

	// Token: 0x1700010D RID: 269
	// (get) Token: 0x060004E6 RID: 1254 RVA: 0x000056DA File Offset: 0x000038DA
	// (set) Token: 0x060004E7 RID: 1255 RVA: 0x000056E1 File Offset: 0x000038E1
	public static AudioClip ImpactGrass2 { get; private set; }

	// Token: 0x1700010E RID: 270
	// (get) Token: 0x060004E8 RID: 1256 RVA: 0x000056E9 File Offset: 0x000038E9
	// (set) Token: 0x060004E9 RID: 1257 RVA: 0x000056F0 File Offset: 0x000038F0
	public static AudioClip ImpactGrass3 { get; private set; }

	// Token: 0x1700010F RID: 271
	// (get) Token: 0x060004EA RID: 1258 RVA: 0x000056F8 File Offset: 0x000038F8
	// (set) Token: 0x060004EB RID: 1259 RVA: 0x000056FF File Offset: 0x000038FF
	public static AudioClip ImpactGrass4 { get; private set; }

	// Token: 0x17000110 RID: 272
	// (get) Token: 0x060004EC RID: 1260 RVA: 0x00005707 File Offset: 0x00003907
	// (set) Token: 0x060004ED RID: 1261 RVA: 0x0000570E File Offset: 0x0000390E
	public static AudioClip ImpactMetal1 { get; private set; }

	// Token: 0x17000111 RID: 273
	// (get) Token: 0x060004EE RID: 1262 RVA: 0x00005716 File Offset: 0x00003916
	// (set) Token: 0x060004EF RID: 1263 RVA: 0x0000571D File Offset: 0x0000391D
	public static AudioClip ImpactMetal2 { get; private set; }

	// Token: 0x17000112 RID: 274
	// (get) Token: 0x060004F0 RID: 1264 RVA: 0x00005725 File Offset: 0x00003925
	// (set) Token: 0x060004F1 RID: 1265 RVA: 0x0000572C File Offset: 0x0000392C
	public static AudioClip ImpactMetal3 { get; private set; }

	// Token: 0x17000113 RID: 275
	// (get) Token: 0x060004F2 RID: 1266 RVA: 0x00005734 File Offset: 0x00003934
	// (set) Token: 0x060004F3 RID: 1267 RVA: 0x0000573B File Offset: 0x0000393B
	public static AudioClip ImpactMetal4 { get; private set; }

	// Token: 0x17000114 RID: 276
	// (get) Token: 0x060004F4 RID: 1268 RVA: 0x00005743 File Offset: 0x00003943
	// (set) Token: 0x060004F5 RID: 1269 RVA: 0x0000574A File Offset: 0x0000394A
	public static AudioClip ImpactMetal5 { get; private set; }

	// Token: 0x17000115 RID: 277
	// (get) Token: 0x060004F6 RID: 1270 RVA: 0x00005752 File Offset: 0x00003952
	// (set) Token: 0x060004F7 RID: 1271 RVA: 0x00005759 File Offset: 0x00003959
	public static AudioClip ImpactSand1 { get; private set; }

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x060004F8 RID: 1272 RVA: 0x00005761 File Offset: 0x00003961
	// (set) Token: 0x060004F9 RID: 1273 RVA: 0x00005768 File Offset: 0x00003968
	public static AudioClip ImpactSand2 { get; private set; }

	// Token: 0x17000117 RID: 279
	// (get) Token: 0x060004FA RID: 1274 RVA: 0x00005770 File Offset: 0x00003970
	// (set) Token: 0x060004FB RID: 1275 RVA: 0x00005777 File Offset: 0x00003977
	public static AudioClip ImpactSand3 { get; private set; }

	// Token: 0x17000118 RID: 280
	// (get) Token: 0x060004FC RID: 1276 RVA: 0x0000577F File Offset: 0x0000397F
	// (set) Token: 0x060004FD RID: 1277 RVA: 0x00005786 File Offset: 0x00003986
	public static AudioClip ImpactSand4 { get; private set; }

	// Token: 0x17000119 RID: 281
	// (get) Token: 0x060004FE RID: 1278 RVA: 0x0000578E File Offset: 0x0000398E
	// (set) Token: 0x060004FF RID: 1279 RVA: 0x00005795 File Offset: 0x00003995
	public static AudioClip ImpactSand5 { get; private set; }

	// Token: 0x1700011A RID: 282
	// (get) Token: 0x06000500 RID: 1280 RVA: 0x0000579D File Offset: 0x0000399D
	// (set) Token: 0x06000501 RID: 1281 RVA: 0x000057A4 File Offset: 0x000039A4
	public static AudioClip ImpactStone1 { get; private set; }

	// Token: 0x1700011B RID: 283
	// (get) Token: 0x06000502 RID: 1282 RVA: 0x000057AC File Offset: 0x000039AC
	// (set) Token: 0x06000503 RID: 1283 RVA: 0x000057B3 File Offset: 0x000039B3
	public static AudioClip ImpactStone2 { get; private set; }

	// Token: 0x1700011C RID: 284
	// (get) Token: 0x06000504 RID: 1284 RVA: 0x000057BB File Offset: 0x000039BB
	// (set) Token: 0x06000505 RID: 1285 RVA: 0x000057C2 File Offset: 0x000039C2
	public static AudioClip ImpactStone3 { get; private set; }

	// Token: 0x1700011D RID: 285
	// (get) Token: 0x06000506 RID: 1286 RVA: 0x000057CA File Offset: 0x000039CA
	// (set) Token: 0x06000507 RID: 1287 RVA: 0x000057D1 File Offset: 0x000039D1
	public static AudioClip ImpactStone4 { get; private set; }

	// Token: 0x1700011E RID: 286
	// (get) Token: 0x06000508 RID: 1288 RVA: 0x000057D9 File Offset: 0x000039D9
	// (set) Token: 0x06000509 RID: 1289 RVA: 0x000057E0 File Offset: 0x000039E0
	public static AudioClip ImpactStone5 { get; private set; }

	// Token: 0x1700011F RID: 287
	// (get) Token: 0x0600050A RID: 1290 RVA: 0x000057E8 File Offset: 0x000039E8
	// (set) Token: 0x0600050B RID: 1291 RVA: 0x000057EF File Offset: 0x000039EF
	public static AudioClip ImpactWater1 { get; private set; }

	// Token: 0x17000120 RID: 288
	// (get) Token: 0x0600050C RID: 1292 RVA: 0x000057F7 File Offset: 0x000039F7
	// (set) Token: 0x0600050D RID: 1293 RVA: 0x000057FE File Offset: 0x000039FE
	public static AudioClip ImpactWater2 { get; private set; }

	// Token: 0x17000121 RID: 289
	// (get) Token: 0x0600050E RID: 1294 RVA: 0x00005806 File Offset: 0x00003A06
	// (set) Token: 0x0600050F RID: 1295 RVA: 0x0000580D File Offset: 0x00003A0D
	public static AudioClip ImpactWater3 { get; private set; }

	// Token: 0x17000122 RID: 290
	// (get) Token: 0x06000510 RID: 1296 RVA: 0x00005815 File Offset: 0x00003A15
	// (set) Token: 0x06000511 RID: 1297 RVA: 0x0000581C File Offset: 0x00003A1C
	public static AudioClip ImpactWater4 { get; private set; }

	// Token: 0x17000123 RID: 291
	// (get) Token: 0x06000512 RID: 1298 RVA: 0x00005824 File Offset: 0x00003A24
	// (set) Token: 0x06000513 RID: 1299 RVA: 0x0000582B File Offset: 0x00003A2B
	public static AudioClip ImpactWater5 { get; private set; }

	// Token: 0x17000124 RID: 292
	// (get) Token: 0x06000514 RID: 1300 RVA: 0x00005833 File Offset: 0x00003A33
	// (set) Token: 0x06000515 RID: 1301 RVA: 0x0000583A File Offset: 0x00003A3A
	public static AudioClip ImpactWood1 { get; private set; }

	// Token: 0x17000125 RID: 293
	// (get) Token: 0x06000516 RID: 1302 RVA: 0x00005842 File Offset: 0x00003A42
	// (set) Token: 0x06000517 RID: 1303 RVA: 0x00005849 File Offset: 0x00003A49
	public static AudioClip ImpactWood2 { get; private set; }

	// Token: 0x17000126 RID: 294
	// (get) Token: 0x06000518 RID: 1304 RVA: 0x00005851 File Offset: 0x00003A51
	// (set) Token: 0x06000519 RID: 1305 RVA: 0x00005858 File Offset: 0x00003A58
	public static AudioClip ImpactWood3 { get; private set; }

	// Token: 0x17000127 RID: 295
	// (get) Token: 0x0600051A RID: 1306 RVA: 0x00005860 File Offset: 0x00003A60
	// (set) Token: 0x0600051B RID: 1307 RVA: 0x00005867 File Offset: 0x00003A67
	public static AudioClip ImpactWood4 { get; private set; }

	// Token: 0x17000128 RID: 296
	// (get) Token: 0x0600051C RID: 1308 RVA: 0x0000586F File Offset: 0x00003A6F
	// (set) Token: 0x0600051D RID: 1309 RVA: 0x00005876 File Offset: 0x00003A76
	public static AudioClip ImpactWood5 { get; private set; }

	// Token: 0x17000129 RID: 297
	// (get) Token: 0x0600051E RID: 1310 RVA: 0x0000587E File Offset: 0x00003A7E
	// (set) Token: 0x0600051F RID: 1311 RVA: 0x00005885 File Offset: 0x00003A85
	public static AudioClip MediumSplash { get; private set; }

	// Token: 0x1700012A RID: 298
	// (get) Token: 0x06000520 RID: 1312 RVA: 0x0000588D File Offset: 0x00003A8D
	// (set) Token: 0x06000521 RID: 1313 RVA: 0x00005894 File Offset: 0x00003A94
	public static AudioClip BlueWins { get; private set; }

	// Token: 0x1700012B RID: 299
	// (get) Token: 0x06000522 RID: 1314 RVA: 0x0000589C File Offset: 0x00003A9C
	// (set) Token: 0x06000523 RID: 1315 RVA: 0x000058A3 File Offset: 0x00003AA3
	public static AudioClip CountdownTonal1 { get; private set; }

	// Token: 0x1700012C RID: 300
	// (get) Token: 0x06000524 RID: 1316 RVA: 0x000058AB File Offset: 0x00003AAB
	// (set) Token: 0x06000525 RID: 1317 RVA: 0x000058B2 File Offset: 0x00003AB2
	public static AudioClip CountdownTonal2 { get; private set; }

	// Token: 0x1700012D RID: 301
	// (get) Token: 0x06000526 RID: 1318 RVA: 0x000058BA File Offset: 0x00003ABA
	// (set) Token: 0x06000527 RID: 1319 RVA: 0x000058C1 File Offset: 0x00003AC1
	public static AudioClip Draw { get; private set; }

	// Token: 0x1700012E RID: 302
	// (get) Token: 0x06000528 RID: 1320 RVA: 0x000058C9 File Offset: 0x00003AC9
	// (set) Token: 0x06000529 RID: 1321 RVA: 0x000058D0 File Offset: 0x00003AD0
	public static AudioClip Fight { get; private set; }

	// Token: 0x1700012F RID: 303
	// (get) Token: 0x0600052A RID: 1322 RVA: 0x000058D8 File Offset: 0x00003AD8
	// (set) Token: 0x0600052B RID: 1323 RVA: 0x000058DF File Offset: 0x00003ADF
	public static AudioClip FocusEnemy { get; private set; }

	// Token: 0x17000130 RID: 304
	// (get) Token: 0x0600052C RID: 1324 RVA: 0x000058E7 File Offset: 0x00003AE7
	// (set) Token: 0x0600052D RID: 1325 RVA: 0x000058EE File Offset: 0x00003AEE
	public static AudioClip GameOver { get; private set; }

	// Token: 0x17000131 RID: 305
	// (get) Token: 0x0600052E RID: 1326 RVA: 0x000058F6 File Offset: 0x00003AF6
	// (set) Token: 0x0600052F RID: 1327 RVA: 0x000058FD File Offset: 0x00003AFD
	public static AudioClip GetPoints { get; private set; }

	// Token: 0x17000132 RID: 306
	// (get) Token: 0x06000530 RID: 1328 RVA: 0x00005905 File Offset: 0x00003B05
	// (set) Token: 0x06000531 RID: 1329 RVA: 0x0000590C File Offset: 0x00003B0C
	public static AudioClip GetXP { get; private set; }

	// Token: 0x17000133 RID: 307
	// (get) Token: 0x06000532 RID: 1330 RVA: 0x00005914 File Offset: 0x00003B14
	// (set) Token: 0x06000533 RID: 1331 RVA: 0x0000591B File Offset: 0x00003B1B
	public static AudioClip LevelUp { get; private set; }

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x06000534 RID: 1332 RVA: 0x00005923 File Offset: 0x00003B23
	// (set) Token: 0x06000535 RID: 1333 RVA: 0x0000592A File Offset: 0x00003B2A
	public static AudioClip LostLead { get; private set; }

	// Token: 0x17000135 RID: 309
	// (get) Token: 0x06000536 RID: 1334 RVA: 0x00005932 File Offset: 0x00003B32
	// (set) Token: 0x06000537 RID: 1335 RVA: 0x00005939 File Offset: 0x00003B39
	public static AudioClip MatchEndingCountdown1 { get; private set; }

	// Token: 0x17000136 RID: 310
	// (get) Token: 0x06000538 RID: 1336 RVA: 0x00005941 File Offset: 0x00003B41
	// (set) Token: 0x06000539 RID: 1337 RVA: 0x00005948 File Offset: 0x00003B48
	public static AudioClip MatchEndingCountdown2 { get; private set; }

	// Token: 0x17000137 RID: 311
	// (get) Token: 0x0600053A RID: 1338 RVA: 0x00005950 File Offset: 0x00003B50
	// (set) Token: 0x0600053B RID: 1339 RVA: 0x00005957 File Offset: 0x00003B57
	public static AudioClip MatchEndingCountdown3 { get; private set; }

	// Token: 0x17000138 RID: 312
	// (get) Token: 0x0600053C RID: 1340 RVA: 0x0000595F File Offset: 0x00003B5F
	// (set) Token: 0x0600053D RID: 1341 RVA: 0x00005966 File Offset: 0x00003B66
	public static AudioClip MatchEndingCountdown4 { get; private set; }

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x0600053E RID: 1342 RVA: 0x0000596E File Offset: 0x00003B6E
	// (set) Token: 0x0600053F RID: 1343 RVA: 0x00005975 File Offset: 0x00003B75
	public static AudioClip MatchEndingCountdown5 { get; private set; }

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x06000540 RID: 1344 RVA: 0x0000597D File Offset: 0x00003B7D
	// (set) Token: 0x06000541 RID: 1345 RVA: 0x00005984 File Offset: 0x00003B84
	public static AudioClip RedWins { get; private set; }

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x06000542 RID: 1346 RVA: 0x0000598C File Offset: 0x00003B8C
	// (set) Token: 0x06000543 RID: 1347 RVA: 0x00005993 File Offset: 0x00003B93
	public static AudioClip TakenLead { get; private set; }

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x06000544 RID: 1348 RVA: 0x0000599B File Offset: 0x00003B9B
	// (set) Token: 0x06000545 RID: 1349 RVA: 0x000059A2 File Offset: 0x00003BA2
	public static AudioClip TiedLead { get; private set; }

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x06000546 RID: 1350 RVA: 0x000059AA File Offset: 0x00003BAA
	// (set) Token: 0x06000547 RID: 1351 RVA: 0x000059B1 File Offset: 0x00003BB1
	public static AudioClip YouWin { get; private set; }

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x06000548 RID: 1352 RVA: 0x000059B9 File Offset: 0x00003BB9
	// (set) Token: 0x06000549 RID: 1353 RVA: 0x000059C0 File Offset: 0x00003BC0
	public static AudioClip AmmoPickup2D { get; private set; }

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x0600054A RID: 1354 RVA: 0x000059C8 File Offset: 0x00003BC8
	// (set) Token: 0x0600054B RID: 1355 RVA: 0x000059CF File Offset: 0x00003BCF
	public static AudioClip ArmorShard2D { get; private set; }

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x0600054C RID: 1356 RVA: 0x000059D7 File Offset: 0x00003BD7
	// (set) Token: 0x0600054D RID: 1357 RVA: 0x000059DE File Offset: 0x00003BDE
	public static AudioClip BigHealth2D { get; private set; }

	// Token: 0x17000141 RID: 321
	// (get) Token: 0x0600054E RID: 1358 RVA: 0x000059E6 File Offset: 0x00003BE6
	// (set) Token: 0x0600054F RID: 1359 RVA: 0x000059ED File Offset: 0x00003BED
	public static AudioClip GoldArmor2D { get; private set; }

	// Token: 0x17000142 RID: 322
	// (get) Token: 0x06000550 RID: 1360 RVA: 0x000059F5 File Offset: 0x00003BF5
	// (set) Token: 0x06000551 RID: 1361 RVA: 0x000059FC File Offset: 0x00003BFC
	public static AudioClip MediumHealth2D { get; private set; }

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x06000552 RID: 1362 RVA: 0x00005A04 File Offset: 0x00003C04
	// (set) Token: 0x06000553 RID: 1363 RVA: 0x00005A0B File Offset: 0x00003C0B
	public static AudioClip MegaHealth2D { get; private set; }

	// Token: 0x17000144 RID: 324
	// (get) Token: 0x06000554 RID: 1364 RVA: 0x00005A13 File Offset: 0x00003C13
	// (set) Token: 0x06000555 RID: 1365 RVA: 0x00005A1A File Offset: 0x00003C1A
	public static AudioClip SilverArmor2D { get; private set; }

	// Token: 0x17000145 RID: 325
	// (get) Token: 0x06000556 RID: 1366 RVA: 0x00005A22 File Offset: 0x00003C22
	// (set) Token: 0x06000557 RID: 1367 RVA: 0x00005A29 File Offset: 0x00003C29
	public static AudioClip SmallHealth2D { get; private set; }

	// Token: 0x17000146 RID: 326
	// (get) Token: 0x06000558 RID: 1368 RVA: 0x00005A31 File Offset: 0x00003C31
	// (set) Token: 0x06000559 RID: 1369 RVA: 0x00005A38 File Offset: 0x00003C38
	public static AudioClip WeaponPickup2D { get; private set; }

	// Token: 0x17000147 RID: 327
	// (get) Token: 0x0600055A RID: 1370 RVA: 0x00005A40 File Offset: 0x00003C40
	// (set) Token: 0x0600055B RID: 1371 RVA: 0x00005A47 File Offset: 0x00003C47
	public static AudioClip HealthCriticalHeartbeat { get; private set; }

	// Token: 0x17000148 RID: 328
	// (get) Token: 0x0600055C RID: 1372 RVA: 0x00005A4F File Offset: 0x00003C4F
	// (set) Token: 0x0600055D RID: 1373 RVA: 0x00005A56 File Offset: 0x00003C56
	public static AudioClip HealthCriticalNoise { get; private set; }

	// Token: 0x17000149 RID: 329
	// (get) Token: 0x0600055E RID: 1374 RVA: 0x00005A5E File Offset: 0x00003C5E
	// (set) Token: 0x0600055F RID: 1375 RVA: 0x00005A65 File Offset: 0x00003C65
	public static AudioClip HealthOver100Decrease { get; private set; }

	// Token: 0x1700014A RID: 330
	// (get) Token: 0x06000560 RID: 1376 RVA: 0x00005A6D File Offset: 0x00003C6D
	// (set) Token: 0x06000561 RID: 1377 RVA: 0x00005A74 File Offset: 0x00003C74
	public static AudioClip HealthOver100Increase { get; private set; }

	// Token: 0x1700014B RID: 331
	// (get) Token: 0x06000562 RID: 1378 RVA: 0x00005A7C File Offset: 0x00003C7C
	// (set) Token: 0x06000563 RID: 1379 RVA: 0x00005A83 File Offset: 0x00003C83
	public static AudioClip FootStepDirt1 { get; private set; }

	// Token: 0x1700014C RID: 332
	// (get) Token: 0x06000564 RID: 1380 RVA: 0x00005A8B File Offset: 0x00003C8B
	// (set) Token: 0x06000565 RID: 1381 RVA: 0x00005A92 File Offset: 0x00003C92
	public static AudioClip FootStepDirt2 { get; private set; }

	// Token: 0x1700014D RID: 333
	// (get) Token: 0x06000566 RID: 1382 RVA: 0x00005A9A File Offset: 0x00003C9A
	// (set) Token: 0x06000567 RID: 1383 RVA: 0x00005AA1 File Offset: 0x00003CA1
	public static AudioClip FootStepDirt3 { get; private set; }

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x06000568 RID: 1384 RVA: 0x00005AA9 File Offset: 0x00003CA9
	// (set) Token: 0x06000569 RID: 1385 RVA: 0x00005AB0 File Offset: 0x00003CB0
	public static AudioClip FootStepDirt4 { get; private set; }

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x0600056A RID: 1386 RVA: 0x00005AB8 File Offset: 0x00003CB8
	// (set) Token: 0x0600056B RID: 1387 RVA: 0x00005ABF File Offset: 0x00003CBF
	public static AudioClip FootStepGlass1 { get; private set; }

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x0600056C RID: 1388 RVA: 0x00005AC7 File Offset: 0x00003CC7
	// (set) Token: 0x0600056D RID: 1389 RVA: 0x00005ACE File Offset: 0x00003CCE
	public static AudioClip FootStepGlass2 { get; private set; }

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x0600056E RID: 1390 RVA: 0x00005AD6 File Offset: 0x00003CD6
	// (set) Token: 0x0600056F RID: 1391 RVA: 0x00005ADD File Offset: 0x00003CDD
	public static AudioClip FootStepGlass3 { get; private set; }

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x06000570 RID: 1392 RVA: 0x00005AE5 File Offset: 0x00003CE5
	// (set) Token: 0x06000571 RID: 1393 RVA: 0x00005AEC File Offset: 0x00003CEC
	public static AudioClip FootStepGlass4 { get; private set; }

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x06000572 RID: 1394 RVA: 0x00005AF4 File Offset: 0x00003CF4
	// (set) Token: 0x06000573 RID: 1395 RVA: 0x00005AFB File Offset: 0x00003CFB
	public static AudioClip FootStepGrass1 { get; private set; }

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x06000574 RID: 1396 RVA: 0x00005B03 File Offset: 0x00003D03
	// (set) Token: 0x06000575 RID: 1397 RVA: 0x00005B0A File Offset: 0x00003D0A
	public static AudioClip FootStepGrass2 { get; private set; }

	// Token: 0x17000155 RID: 341
	// (get) Token: 0x06000576 RID: 1398 RVA: 0x00005B12 File Offset: 0x00003D12
	// (set) Token: 0x06000577 RID: 1399 RVA: 0x00005B19 File Offset: 0x00003D19
	public static AudioClip FootStepGrass3 { get; private set; }

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x06000578 RID: 1400 RVA: 0x00005B21 File Offset: 0x00003D21
	// (set) Token: 0x06000579 RID: 1401 RVA: 0x00005B28 File Offset: 0x00003D28
	public static AudioClip FootStepGrass4 { get; private set; }

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x0600057A RID: 1402 RVA: 0x00005B30 File Offset: 0x00003D30
	// (set) Token: 0x0600057B RID: 1403 RVA: 0x00005B37 File Offset: 0x00003D37
	public static AudioClip FootStepHeavyMetal1 { get; private set; }

	// Token: 0x17000158 RID: 344
	// (get) Token: 0x0600057C RID: 1404 RVA: 0x00005B3F File Offset: 0x00003D3F
	// (set) Token: 0x0600057D RID: 1405 RVA: 0x00005B46 File Offset: 0x00003D46
	public static AudioClip FootStepHeavyMetal2 { get; private set; }

	// Token: 0x17000159 RID: 345
	// (get) Token: 0x0600057E RID: 1406 RVA: 0x00005B4E File Offset: 0x00003D4E
	// (set) Token: 0x0600057F RID: 1407 RVA: 0x00005B55 File Offset: 0x00003D55
	public static AudioClip FootStepHeavyMetal3 { get; private set; }

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x06000580 RID: 1408 RVA: 0x00005B5D File Offset: 0x00003D5D
	// (set) Token: 0x06000581 RID: 1409 RVA: 0x00005B64 File Offset: 0x00003D64
	public static AudioClip FootStepHeavyMetal4 { get; private set; }

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x06000582 RID: 1410 RVA: 0x00005B6C File Offset: 0x00003D6C
	// (set) Token: 0x06000583 RID: 1411 RVA: 0x00005B73 File Offset: 0x00003D73
	public static AudioClip FootStepMetal1 { get; private set; }

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x06000584 RID: 1412 RVA: 0x00005B7B File Offset: 0x00003D7B
	// (set) Token: 0x06000585 RID: 1413 RVA: 0x00005B82 File Offset: 0x00003D82
	public static AudioClip FootStepMetal2 { get; private set; }

	// Token: 0x1700015D RID: 349
	// (get) Token: 0x06000586 RID: 1414 RVA: 0x00005B8A File Offset: 0x00003D8A
	// (set) Token: 0x06000587 RID: 1415 RVA: 0x00005B91 File Offset: 0x00003D91
	public static AudioClip FootStepMetal3 { get; private set; }

	// Token: 0x1700015E RID: 350
	// (get) Token: 0x06000588 RID: 1416 RVA: 0x00005B99 File Offset: 0x00003D99
	// (set) Token: 0x06000589 RID: 1417 RVA: 0x00005BA0 File Offset: 0x00003DA0
	public static AudioClip FootStepMetal4 { get; private set; }

	// Token: 0x1700015F RID: 351
	// (get) Token: 0x0600058A RID: 1418 RVA: 0x00005BA8 File Offset: 0x00003DA8
	// (set) Token: 0x0600058B RID: 1419 RVA: 0x00005BAF File Offset: 0x00003DAF
	public static AudioClip FootStepRock1 { get; private set; }

	// Token: 0x17000160 RID: 352
	// (get) Token: 0x0600058C RID: 1420 RVA: 0x00005BB7 File Offset: 0x00003DB7
	// (set) Token: 0x0600058D RID: 1421 RVA: 0x00005BBE File Offset: 0x00003DBE
	public static AudioClip FootStepRock2 { get; private set; }

	// Token: 0x17000161 RID: 353
	// (get) Token: 0x0600058E RID: 1422 RVA: 0x00005BC6 File Offset: 0x00003DC6
	// (set) Token: 0x0600058F RID: 1423 RVA: 0x00005BCD File Offset: 0x00003DCD
	public static AudioClip FootStepRock3 { get; private set; }

	// Token: 0x17000162 RID: 354
	// (get) Token: 0x06000590 RID: 1424 RVA: 0x00005BD5 File Offset: 0x00003DD5
	// (set) Token: 0x06000591 RID: 1425 RVA: 0x00005BDC File Offset: 0x00003DDC
	public static AudioClip FootStepRock4 { get; private set; }

	// Token: 0x17000163 RID: 355
	// (get) Token: 0x06000592 RID: 1426 RVA: 0x00005BE4 File Offset: 0x00003DE4
	// (set) Token: 0x06000593 RID: 1427 RVA: 0x00005BEB File Offset: 0x00003DEB
	public static AudioClip FootStepSand1 { get; private set; }

	// Token: 0x17000164 RID: 356
	// (get) Token: 0x06000594 RID: 1428 RVA: 0x00005BF3 File Offset: 0x00003DF3
	// (set) Token: 0x06000595 RID: 1429 RVA: 0x00005BFA File Offset: 0x00003DFA
	public static AudioClip FootStepSand2 { get; private set; }

	// Token: 0x17000165 RID: 357
	// (get) Token: 0x06000596 RID: 1430 RVA: 0x00005C02 File Offset: 0x00003E02
	// (set) Token: 0x06000597 RID: 1431 RVA: 0x00005C09 File Offset: 0x00003E09
	public static AudioClip FootStepSand3 { get; private set; }

	// Token: 0x17000166 RID: 358
	// (get) Token: 0x06000598 RID: 1432 RVA: 0x00005C11 File Offset: 0x00003E11
	// (set) Token: 0x06000599 RID: 1433 RVA: 0x00005C18 File Offset: 0x00003E18
	public static AudioClip FootStepSand4 { get; private set; }

	// Token: 0x17000167 RID: 359
	// (get) Token: 0x0600059A RID: 1434 RVA: 0x00005C20 File Offset: 0x00003E20
	// (set) Token: 0x0600059B RID: 1435 RVA: 0x00005C27 File Offset: 0x00003E27
	public static AudioClip FootStepSnow1 { get; private set; }

	// Token: 0x17000168 RID: 360
	// (get) Token: 0x0600059C RID: 1436 RVA: 0x00005C2F File Offset: 0x00003E2F
	// (set) Token: 0x0600059D RID: 1437 RVA: 0x00005C36 File Offset: 0x00003E36
	public static AudioClip FootStepSnow2 { get; private set; }

	// Token: 0x17000169 RID: 361
	// (get) Token: 0x0600059E RID: 1438 RVA: 0x00005C3E File Offset: 0x00003E3E
	// (set) Token: 0x0600059F RID: 1439 RVA: 0x00005C45 File Offset: 0x00003E45
	public static AudioClip FootStepSnow3 { get; private set; }

	// Token: 0x1700016A RID: 362
	// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00005C4D File Offset: 0x00003E4D
	// (set) Token: 0x060005A1 RID: 1441 RVA: 0x00005C54 File Offset: 0x00003E54
	public static AudioClip FootStepSnow4 { get; private set; }

	// Token: 0x1700016B RID: 363
	// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00005C5C File Offset: 0x00003E5C
	// (set) Token: 0x060005A3 RID: 1443 RVA: 0x00005C63 File Offset: 0x00003E63
	public static AudioClip FootStepWater1 { get; private set; }

	// Token: 0x1700016C RID: 364
	// (get) Token: 0x060005A4 RID: 1444 RVA: 0x00005C6B File Offset: 0x00003E6B
	// (set) Token: 0x060005A5 RID: 1445 RVA: 0x00005C72 File Offset: 0x00003E72
	public static AudioClip FootStepWater2 { get; private set; }

	// Token: 0x1700016D RID: 365
	// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00005C7A File Offset: 0x00003E7A
	// (set) Token: 0x060005A7 RID: 1447 RVA: 0x00005C81 File Offset: 0x00003E81
	public static AudioClip FootStepWater3 { get; private set; }

	// Token: 0x1700016E RID: 366
	// (get) Token: 0x060005A8 RID: 1448 RVA: 0x00005C89 File Offset: 0x00003E89
	// (set) Token: 0x060005A9 RID: 1449 RVA: 0x00005C90 File Offset: 0x00003E90
	public static AudioClip FootStepWood1 { get; private set; }

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x060005AA RID: 1450 RVA: 0x00005C98 File Offset: 0x00003E98
	// (set) Token: 0x060005AB RID: 1451 RVA: 0x00005C9F File Offset: 0x00003E9F
	public static AudioClip FootStepWood2 { get; private set; }

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x060005AC RID: 1452 RVA: 0x00005CA7 File Offset: 0x00003EA7
	// (set) Token: 0x060005AD RID: 1453 RVA: 0x00005CAE File Offset: 0x00003EAE
	public static AudioClip FootStepWood3 { get; private set; }

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x060005AE RID: 1454 RVA: 0x00005CB6 File Offset: 0x00003EB6
	// (set) Token: 0x060005AF RID: 1455 RVA: 0x00005CBD File Offset: 0x00003EBD
	public static AudioClip FootStepWood4 { get; private set; }

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x060005B0 RID: 1456 RVA: 0x00005CC5 File Offset: 0x00003EC5
	// (set) Token: 0x060005B1 RID: 1457 RVA: 0x00005CCC File Offset: 0x00003ECC
	public static AudioClip GotHeadshotKill { get; private set; }

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x060005B2 RID: 1458 RVA: 0x00005CD4 File Offset: 0x00003ED4
	// (set) Token: 0x060005B3 RID: 1459 RVA: 0x00005CDB File Offset: 0x00003EDB
	public static AudioClip GotNutshotKill { get; private set; }

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00005CE3 File Offset: 0x00003EE3
	// (set) Token: 0x060005B5 RID: 1461 RVA: 0x00005CEA File Offset: 0x00003EEA
	public static AudioClip KilledBySplatbat { get; private set; }

	// Token: 0x17000175 RID: 373
	// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00005CF2 File Offset: 0x00003EF2
	// (set) Token: 0x060005B7 RID: 1463 RVA: 0x00005CF9 File Offset: 0x00003EF9
	public static AudioClip LandingGrunt { get; private set; }

	// Token: 0x17000176 RID: 374
	// (get) Token: 0x060005B8 RID: 1464 RVA: 0x00005D01 File Offset: 0x00003F01
	// (set) Token: 0x060005B9 RID: 1465 RVA: 0x00005D08 File Offset: 0x00003F08
	public static AudioClip LocalPlayerHitArmorRemaining { get; private set; }

	// Token: 0x17000177 RID: 375
	// (get) Token: 0x060005BA RID: 1466 RVA: 0x00005D10 File Offset: 0x00003F10
	// (set) Token: 0x060005BB RID: 1467 RVA: 0x00005D17 File Offset: 0x00003F17
	public static AudioClip LocalPlayerHitNoArmor { get; private set; }

	// Token: 0x17000178 RID: 376
	// (get) Token: 0x060005BC RID: 1468 RVA: 0x00005D1F File Offset: 0x00003F1F
	// (set) Token: 0x060005BD RID: 1469 RVA: 0x00005D26 File Offset: 0x00003F26
	public static AudioClip LocalPlayerHitNoArmorLowHealth { get; private set; }

	// Token: 0x17000179 RID: 377
	// (get) Token: 0x060005BE RID: 1470 RVA: 0x00005D2E File Offset: 0x00003F2E
	// (set) Token: 0x060005BF RID: 1471 RVA: 0x00005D35 File Offset: 0x00003F35
	public static AudioClip NormalKill1 { get; private set; }

	// Token: 0x1700017A RID: 378
	// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00005D3D File Offset: 0x00003F3D
	// (set) Token: 0x060005C1 RID: 1473 RVA: 0x00005D44 File Offset: 0x00003F44
	public static AudioClip NormalKill2 { get; private set; }

	// Token: 0x1700017B RID: 379
	// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00005D4C File Offset: 0x00003F4C
	// (set) Token: 0x060005C3 RID: 1475 RVA: 0x00005D53 File Offset: 0x00003F53
	public static AudioClip NormalKill3 { get; private set; }

	// Token: 0x1700017C RID: 380
	// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00005D5B File Offset: 0x00003F5B
	// (set) Token: 0x060005C5 RID: 1477 RVA: 0x00005D62 File Offset: 0x00003F62
	public static AudioClip PlayerJump2D { get; private set; }

	// Token: 0x1700017D RID: 381
	// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00005D6A File Offset: 0x00003F6A
	// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00005D71 File Offset: 0x00003F71
	public static AudioClip QuickItemRecharge { get; private set; }

	// Token: 0x1700017E RID: 382
	// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00005D79 File Offset: 0x00003F79
	// (set) Token: 0x060005C9 RID: 1481 RVA: 0x00005D80 File Offset: 0x00003F80
	public static AudioClip SwimAboveWater1 { get; private set; }

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x060005CA RID: 1482 RVA: 0x00005D88 File Offset: 0x00003F88
	// (set) Token: 0x060005CB RID: 1483 RVA: 0x00005D8F File Offset: 0x00003F8F
	public static AudioClip SwimAboveWater2 { get; private set; }

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x060005CC RID: 1484 RVA: 0x00005D97 File Offset: 0x00003F97
	// (set) Token: 0x060005CD RID: 1485 RVA: 0x00005D9E File Offset: 0x00003F9E
	public static AudioClip SwimAboveWater3 { get; private set; }

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x060005CE RID: 1486 RVA: 0x00005DA6 File Offset: 0x00003FA6
	// (set) Token: 0x060005CF RID: 1487 RVA: 0x00005DAD File Offset: 0x00003FAD
	public static AudioClip SwimAboveWater4 { get; private set; }

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00005DB5 File Offset: 0x00003FB5
	// (set) Token: 0x060005D1 RID: 1489 RVA: 0x00005DBC File Offset: 0x00003FBC
	public static AudioClip SwimUnderWater { get; private set; }

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00005DC4 File Offset: 0x00003FC4
	// (set) Token: 0x060005D3 RID: 1491 RVA: 0x00005DCB File Offset: 0x00003FCB
	public static AudioClip AmmoPickup { get; private set; }

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00005DD3 File Offset: 0x00003FD3
	// (set) Token: 0x060005D5 RID: 1493 RVA: 0x00005DDA File Offset: 0x00003FDA
	public static AudioClip ArmorShard { get; private set; }

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00005DE2 File Offset: 0x00003FE2
	// (set) Token: 0x060005D7 RID: 1495 RVA: 0x00005DE9 File Offset: 0x00003FE9
	public static AudioClip BigHealth { get; private set; }

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00005DF1 File Offset: 0x00003FF1
	// (set) Token: 0x060005D9 RID: 1497 RVA: 0x00005DF8 File Offset: 0x00003FF8
	public static AudioClip GoldArmor { get; private set; }

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x060005DA RID: 1498 RVA: 0x00005E00 File Offset: 0x00004000
	// (set) Token: 0x060005DB RID: 1499 RVA: 0x00005E07 File Offset: 0x00004007
	public static AudioClip JumpPad { get; private set; }

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x060005DC RID: 1500 RVA: 0x00005E0F File Offset: 0x0000400F
	// (set) Token: 0x060005DD RID: 1501 RVA: 0x00005E16 File Offset: 0x00004016
	public static AudioClip JumpPad2D { get; private set; }

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x060005DE RID: 1502 RVA: 0x00005E1E File Offset: 0x0000401E
	// (set) Token: 0x060005DF RID: 1503 RVA: 0x00005E25 File Offset: 0x00004025
	public static AudioClip MediumHealth { get; private set; }

	// Token: 0x1700018A RID: 394
	// (get) Token: 0x060005E0 RID: 1504 RVA: 0x00005E2D File Offset: 0x0000402D
	// (set) Token: 0x060005E1 RID: 1505 RVA: 0x00005E34 File Offset: 0x00004034
	public static AudioClip MegaHealth { get; private set; }

	// Token: 0x1700018B RID: 395
	// (get) Token: 0x060005E2 RID: 1506 RVA: 0x00005E3C File Offset: 0x0000403C
	// (set) Token: 0x060005E3 RID: 1507 RVA: 0x00005E43 File Offset: 0x00004043
	public static AudioClip SilverArmor { get; private set; }

	// Token: 0x1700018C RID: 396
	// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00005E4B File Offset: 0x0000404B
	// (set) Token: 0x060005E5 RID: 1509 RVA: 0x00005E52 File Offset: 0x00004052
	public static AudioClip SmallHealth { get; private set; }

	// Token: 0x1700018D RID: 397
	// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00005E5A File Offset: 0x0000405A
	// (set) Token: 0x060005E7 RID: 1511 RVA: 0x00005E61 File Offset: 0x00004061
	public static AudioClip TargetDamage { get; private set; }

	// Token: 0x1700018E RID: 398
	// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00005E69 File Offset: 0x00004069
	// (set) Token: 0x060005E9 RID: 1513 RVA: 0x00005E70 File Offset: 0x00004070
	public static AudioClip TargetPopup { get; private set; }

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x060005EA RID: 1514 RVA: 0x00005E78 File Offset: 0x00004078
	// (set) Token: 0x060005EB RID: 1515 RVA: 0x00005E7F File Offset: 0x0000407F
	public static AudioClip WeaponPickup { get; private set; }

	// Token: 0x17000190 RID: 400
	// (get) Token: 0x060005EC RID: 1516 RVA: 0x00005E87 File Offset: 0x00004087
	// (set) Token: 0x060005ED RID: 1517 RVA: 0x00005E8E File Offset: 0x0000408E
	public static AudioClip ButtonClick { get; private set; }

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x060005EE RID: 1518 RVA: 0x00005E96 File Offset: 0x00004096
	// (set) Token: 0x060005EF RID: 1519 RVA: 0x00005E9D File Offset: 0x0000409D
	public static AudioClip ClickReady { get; private set; }

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00005EA5 File Offset: 0x000040A5
	// (set) Token: 0x060005F1 RID: 1521 RVA: 0x00005EAC File Offset: 0x000040AC
	public static AudioClip ClickUnready { get; private set; }

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00005EB4 File Offset: 0x000040B4
	// (set) Token: 0x060005F3 RID: 1523 RVA: 0x00005EBB File Offset: 0x000040BB
	public static AudioClip ClosePanel { get; private set; }

	// Token: 0x17000194 RID: 404
	// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00005EC3 File Offset: 0x000040C3
	// (set) Token: 0x060005F5 RID: 1525 RVA: 0x00005ECA File Offset: 0x000040CA
	public static AudioClip CreateGame { get; private set; }

	// Token: 0x17000195 RID: 405
	// (get) Token: 0x060005F6 RID: 1526 RVA: 0x00005ED2 File Offset: 0x000040D2
	// (set) Token: 0x060005F7 RID: 1527 RVA: 0x00005ED9 File Offset: 0x000040D9
	public static AudioClip DoubleKill { get; private set; }

	// Token: 0x17000196 RID: 406
	// (get) Token: 0x060005F8 RID: 1528 RVA: 0x00005EE1 File Offset: 0x000040E1
	// (set) Token: 0x060005F9 RID: 1529 RVA: 0x00005EE8 File Offset: 0x000040E8
	public static AudioClip EndOfRound { get; private set; }

	// Token: 0x17000197 RID: 407
	// (get) Token: 0x060005FA RID: 1530 RVA: 0x00005EF0 File Offset: 0x000040F0
	// (set) Token: 0x060005FB RID: 1531 RVA: 0x00005EF7 File Offset: 0x000040F7
	public static AudioClip EquipGear { get; private set; }

	// Token: 0x17000198 RID: 408
	// (get) Token: 0x060005FC RID: 1532 RVA: 0x00005EFF File Offset: 0x000040FF
	// (set) Token: 0x060005FD RID: 1533 RVA: 0x00005F06 File Offset: 0x00004106
	public static AudioClip EquipItem { get; private set; }

	// Token: 0x17000199 RID: 409
	// (get) Token: 0x060005FE RID: 1534 RVA: 0x00005F0E File Offset: 0x0000410E
	// (set) Token: 0x060005FF RID: 1535 RVA: 0x00005F15 File Offset: 0x00004115
	public static AudioClip EquipWeapon { get; private set; }

	// Token: 0x1700019A RID: 410
	// (get) Token: 0x06000600 RID: 1536 RVA: 0x00005F1D File Offset: 0x0000411D
	// (set) Token: 0x06000601 RID: 1537 RVA: 0x00005F24 File Offset: 0x00004124
	public static AudioClip FBScreenshot { get; private set; }

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x06000602 RID: 1538 RVA: 0x00005F2C File Offset: 0x0000412C
	// (set) Token: 0x06000603 RID: 1539 RVA: 0x00005F33 File Offset: 0x00004133
	public static AudioClip HeadShot { get; private set; }

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x06000604 RID: 1540 RVA: 0x00005F3B File Offset: 0x0000413B
	// (set) Token: 0x06000605 RID: 1541 RVA: 0x00005F42 File Offset: 0x00004142
	public static AudioClip JoinServer { get; private set; }

	// Token: 0x1700019D RID: 413
	// (get) Token: 0x06000606 RID: 1542 RVA: 0x00005F4A File Offset: 0x0000414A
	// (set) Token: 0x06000607 RID: 1543 RVA: 0x00005F51 File Offset: 0x00004151
	public static AudioClip KillLeft1 { get; private set; }

	// Token: 0x1700019E RID: 414
	// (get) Token: 0x06000608 RID: 1544 RVA: 0x00005F59 File Offset: 0x00004159
	// (set) Token: 0x06000609 RID: 1545 RVA: 0x00005F60 File Offset: 0x00004160
	public static AudioClip KillLeft2 { get; private set; }

	// Token: 0x1700019F RID: 415
	// (get) Token: 0x0600060A RID: 1546 RVA: 0x00005F68 File Offset: 0x00004168
	// (set) Token: 0x0600060B RID: 1547 RVA: 0x00005F6F File Offset: 0x0000416F
	public static AudioClip KillLeft3 { get; private set; }

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x0600060C RID: 1548 RVA: 0x00005F77 File Offset: 0x00004177
	// (set) Token: 0x0600060D RID: 1549 RVA: 0x00005F7E File Offset: 0x0000417E
	public static AudioClip KillLeft4 { get; private set; }

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x0600060E RID: 1550 RVA: 0x00005F86 File Offset: 0x00004186
	// (set) Token: 0x0600060F RID: 1551 RVA: 0x00005F8D File Offset: 0x0000418D
	public static AudioClip KillLeft5 { get; private set; }

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x06000610 RID: 1552 RVA: 0x00005F95 File Offset: 0x00004195
	// (set) Token: 0x06000611 RID: 1553 RVA: 0x00005F9C File Offset: 0x0000419C
	public static AudioClip LeaveServer { get; private set; }

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x06000612 RID: 1554 RVA: 0x00005FA4 File Offset: 0x000041A4
	// (set) Token: 0x06000613 RID: 1555 RVA: 0x00005FAB File Offset: 0x000041AB
	public static AudioClip MegaKill { get; private set; }

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x06000614 RID: 1556 RVA: 0x00005FB3 File Offset: 0x000041B3
	// (set) Token: 0x06000615 RID: 1557 RVA: 0x00005FBA File Offset: 0x000041BA
	public static AudioClip NewMessage { get; private set; }

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x06000616 RID: 1558 RVA: 0x00005FC2 File Offset: 0x000041C2
	// (set) Token: 0x06000617 RID: 1559 RVA: 0x00005FC9 File Offset: 0x000041C9
	public static AudioClip NewRequest { get; private set; }

	// Token: 0x170001A6 RID: 422
	// (get) Token: 0x06000618 RID: 1560 RVA: 0x00005FD1 File Offset: 0x000041D1
	// (set) Token: 0x06000619 RID: 1561 RVA: 0x00005FD8 File Offset: 0x000041D8
	public static AudioClip NutShot { get; private set; }

	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x0600061A RID: 1562 RVA: 0x00005FE0 File Offset: 0x000041E0
	// (set) Token: 0x0600061B RID: 1563 RVA: 0x00005FE7 File Offset: 0x000041E7
	public static AudioClip Objective { get; private set; }

	// Token: 0x170001A8 RID: 424
	// (get) Token: 0x0600061C RID: 1564 RVA: 0x00005FEF File Offset: 0x000041EF
	// (set) Token: 0x0600061D RID: 1565 RVA: 0x00005FF6 File Offset: 0x000041F6
	public static AudioClip ObjectiveTick { get; private set; }

	// Token: 0x170001A9 RID: 425
	// (get) Token: 0x0600061E RID: 1566 RVA: 0x00005FFE File Offset: 0x000041FE
	// (set) Token: 0x0600061F RID: 1567 RVA: 0x00006005 File Offset: 0x00004205
	public static AudioClip OpenPanel { get; private set; }

	// Token: 0x170001AA RID: 426
	// (get) Token: 0x06000620 RID: 1568 RVA: 0x0000600D File Offset: 0x0000420D
	// (set) Token: 0x06000621 RID: 1569 RVA: 0x00006014 File Offset: 0x00004214
	public static AudioClip QuadKill { get; private set; }

	// Token: 0x170001AB RID: 427
	// (get) Token: 0x06000622 RID: 1570 RVA: 0x0000601C File Offset: 0x0000421C
	// (set) Token: 0x06000623 RID: 1571 RVA: 0x00006023 File Offset: 0x00004223
	public static AudioClip RibbonClick { get; private set; }

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x06000624 RID: 1572 RVA: 0x0000602B File Offset: 0x0000422B
	// (set) Token: 0x06000625 RID: 1573 RVA: 0x00006032 File Offset: 0x00004232
	public static AudioClip Smackdown { get; private set; }

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x06000626 RID: 1574 RVA: 0x0000603A File Offset: 0x0000423A
	// (set) Token: 0x06000627 RID: 1575 RVA: 0x00006041 File Offset: 0x00004241
	public static AudioClip SubObjective { get; private set; }

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06000628 RID: 1576 RVA: 0x00006049 File Offset: 0x00004249
	// (set) Token: 0x06000629 RID: 1577 RVA: 0x00006050 File Offset: 0x00004250
	public static AudioClip TripleKill { get; private set; }

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x0600062A RID: 1578 RVA: 0x00006058 File Offset: 0x00004258
	// (set) Token: 0x0600062B RID: 1579 RVA: 0x0000605F File Offset: 0x0000425F
	public static AudioClip UberKill { get; private set; }

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x0600062C RID: 1580 RVA: 0x00006067 File Offset: 0x00004267
	// (set) Token: 0x0600062D RID: 1581 RVA: 0x0000606E File Offset: 0x0000426E
	public static AudioClip LauncherBounce1 { get; private set; }

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x0600062E RID: 1582 RVA: 0x00006076 File Offset: 0x00004276
	// (set) Token: 0x0600062F RID: 1583 RVA: 0x0000607D File Offset: 0x0000427D
	public static AudioClip LauncherBounce2 { get; private set; }

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x06000630 RID: 1584 RVA: 0x00006085 File Offset: 0x00004285
	// (set) Token: 0x06000631 RID: 1585 RVA: 0x0000608C File Offset: 0x0000428C
	public static AudioClip OutOfAmmoClick { get; private set; }

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06000632 RID: 1586 RVA: 0x00006094 File Offset: 0x00004294
	// (set) Token: 0x06000633 RID: 1587 RVA: 0x0000609B File Offset: 0x0000429B
	public static AudioClip SniperScopeIn { get; private set; }

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06000634 RID: 1588 RVA: 0x000060A3 File Offset: 0x000042A3
	// (set) Token: 0x06000635 RID: 1589 RVA: 0x000060AA File Offset: 0x000042AA
	public static AudioClip SniperScopeOut { get; private set; }

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x06000636 RID: 1590 RVA: 0x000060B2 File Offset: 0x000042B2
	// (set) Token: 0x06000637 RID: 1591 RVA: 0x000060B9 File Offset: 0x000042B9
	public static AudioClip SniperZoomIn { get; private set; }

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x06000638 RID: 1592 RVA: 0x000060C1 File Offset: 0x000042C1
	// (set) Token: 0x06000639 RID: 1593 RVA: 0x000060C8 File Offset: 0x000042C8
	public static AudioClip SniperZoomOut { get; private set; }

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x0600063A RID: 1594 RVA: 0x000060D0 File Offset: 0x000042D0
	// (set) Token: 0x0600063B RID: 1595 RVA: 0x000060D7 File Offset: 0x000042D7
	public static AudioClip UnderwaterExplosion1 { get; private set; }

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x0600063C RID: 1596 RVA: 0x000060DF File Offset: 0x000042DF
	// (set) Token: 0x0600063D RID: 1597 RVA: 0x000060E6 File Offset: 0x000042E6
	public static AudioClip UnderwaterExplosion2 { get; private set; }

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x0600063E RID: 1598 RVA: 0x000060EE File Offset: 0x000042EE
	// (set) Token: 0x0600063F RID: 1599 RVA: 0x000060F5 File Offset: 0x000042F5
	public static AudioClip WeaponSwitch { get; private set; }
}
