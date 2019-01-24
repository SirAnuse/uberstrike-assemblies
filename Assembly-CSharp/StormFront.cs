using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public static class StormFront
{
	// Token: 0x060006FB RID: 1787 RVA: 0x00031204 File Offset: 0x0002F404
	public static void Initialize(GUISkin skin)
	{
		StormFront.Skin = skin;
		StormFront.box = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("box"));
		StormFront.label = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("label"));
		StormFront.textField = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("textField"));
		StormFront.textArea = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("textArea"));
		StormFront.button = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("button"));
		StormFront.toggle = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("toggle"));
		StormFront.window = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("window"));
		StormFront.horizontalSlider = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("horizontalSlider"));
		StormFront.horizontalSliderThumb = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("horizontalSliderThumb"));
		StormFront.verticalSlider = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("verticalSlider"));
		StormFront.verticalSliderThumb = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("verticalSliderThumb"));
		StormFront.horizontalScrollbar = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("horizontalScrollbar"));
		StormFront.horizontalScrollbarThumb = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("horizontalScrollbarThumb"));
		StormFront.horizontalScrollbarLeftButton = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("horizontalScrollbarLeftButton"));
		StormFront.horizontalScrollbarRightButton = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("horizontalScrollbarRightButton"));
		StormFront.verticalScrollbar = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("verticalScrollbar"));
		StormFront.verticalScrollbarThumb = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("verticalScrollbarThumb"));
		StormFront.verticalScrollbarUpButton = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("verticalScrollbarUpButton"));
		StormFront.verticalScrollbarDownButton = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("verticalScrollbarDownButton"));
		StormFront.scrollView = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("scrollView"));
		StormFront.BlueBox = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("BlueBox"));
		StormFront.RedBox = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("RedBox"));
		StormFront.BluePanelBox = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("BluePanelBox"));
		StormFront.GrayPanelBox = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("GrayPanelBox"));
		StormFront.GrayPanelBlankBox = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("GrayPanelBlankBox"));
		StormFront.RedPanelBox = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("RedPanelBox"));
		StormFront.ButtonRed = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonRed"));
		StormFront.ButtonBlue = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonBlue"));
		StormFront.ButtonGray = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonGray"));
		StormFront.ButtonJoinBlue = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonJoinBlue"));
		StormFront.ButtonJoinRed = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonJoinRed"));
		StormFront.ButtonJoinGray = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonJoinGray"));
		StormFront.ButtonSpectator = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonSpectator"));
		StormFront.ButtonLoadout = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonLoadout"));
		StormFront.ButtonLoadoutRed = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonLoadoutRed"));
		StormFront.InGameChatBlue = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("InGameChatBlue"));
		StormFront.InGameChatRed = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("InGameChatRed"));
		StormFront.DotBlue = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("DotBlue"));
		StormFront.DotRed = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("DotRed"));
		StormFront.DotGray = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("DotGray"));
		StormFront.ButtonCam = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ButtonCam"));
		StormFront.Interpark32Center = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("Interpark32Center"));
		StormFront.Interpark16Left = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("Interpark16Left"));
		StormFront.ProgressBackground = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ProgressBackground"));
		StormFront.ProgressForeground = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ProgressForeground"));
		StormFront.ProgressThumb = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("ProgressThumb"));
		StormFront.MenuTile = LocalizationHelper.GetLocalizedStyle(StormFront.Skin.GetStyle("MenuTile"));
	}

	// Token: 0x17000214 RID: 532
	// (get) Token: 0x060006FC RID: 1788 RVA: 0x00006643 File Offset: 0x00004843
	// (set) Token: 0x060006FD RID: 1789 RVA: 0x0000664A File Offset: 0x0000484A
	public static GUISkin Skin { get; private set; }

	// Token: 0x040005D0 RID: 1488
	public static GUIStyle box = GUIStyle.none;

	// Token: 0x040005D1 RID: 1489
	public static GUIStyle label = GUIStyle.none;

	// Token: 0x040005D2 RID: 1490
	public static GUIStyle textField = GUIStyle.none;

	// Token: 0x040005D3 RID: 1491
	public static GUIStyle textArea = GUIStyle.none;

	// Token: 0x040005D4 RID: 1492
	public static GUIStyle button = GUIStyle.none;

	// Token: 0x040005D5 RID: 1493
	public static GUIStyle toggle = GUIStyle.none;

	// Token: 0x040005D6 RID: 1494
	public static GUIStyle window = GUIStyle.none;

	// Token: 0x040005D7 RID: 1495
	public static GUIStyle horizontalSlider = GUIStyle.none;

	// Token: 0x040005D8 RID: 1496
	public static GUIStyle horizontalSliderThumb = GUIStyle.none;

	// Token: 0x040005D9 RID: 1497
	public static GUIStyle verticalSlider = GUIStyle.none;

	// Token: 0x040005DA RID: 1498
	public static GUIStyle verticalSliderThumb = GUIStyle.none;

	// Token: 0x040005DB RID: 1499
	public static GUIStyle horizontalScrollbar = GUIStyle.none;

	// Token: 0x040005DC RID: 1500
	public static GUIStyle horizontalScrollbarThumb = GUIStyle.none;

	// Token: 0x040005DD RID: 1501
	public static GUIStyle horizontalScrollbarLeftButton = GUIStyle.none;

	// Token: 0x040005DE RID: 1502
	public static GUIStyle horizontalScrollbarRightButton = GUIStyle.none;

	// Token: 0x040005DF RID: 1503
	public static GUIStyle verticalScrollbar = GUIStyle.none;

	// Token: 0x040005E0 RID: 1504
	public static GUIStyle verticalScrollbarThumb = GUIStyle.none;

	// Token: 0x040005E1 RID: 1505
	public static GUIStyle verticalScrollbarUpButton = GUIStyle.none;

	// Token: 0x040005E2 RID: 1506
	public static GUIStyle verticalScrollbarDownButton = GUIStyle.none;

	// Token: 0x040005E3 RID: 1507
	public static GUIStyle scrollView = GUIStyle.none;

	// Token: 0x040005E4 RID: 1508
	public static GUIStyle BlueBox = GUIStyle.none;

	// Token: 0x040005E5 RID: 1509
	public static GUIStyle RedBox = GUIStyle.none;

	// Token: 0x040005E6 RID: 1510
	public static GUIStyle BluePanelBox = GUIStyle.none;

	// Token: 0x040005E7 RID: 1511
	public static GUIStyle GrayPanelBox = GUIStyle.none;

	// Token: 0x040005E8 RID: 1512
	public static GUIStyle GrayPanelBlankBox = GUIStyle.none;

	// Token: 0x040005E9 RID: 1513
	public static GUIStyle RedPanelBox = GUIStyle.none;

	// Token: 0x040005EA RID: 1514
	public static GUIStyle ButtonRed = GUIStyle.none;

	// Token: 0x040005EB RID: 1515
	public static GUIStyle ButtonBlue = GUIStyle.none;

	// Token: 0x040005EC RID: 1516
	public static GUIStyle ButtonGray = GUIStyle.none;

	// Token: 0x040005ED RID: 1517
	public static GUIStyle ButtonJoinBlue = GUIStyle.none;

	// Token: 0x040005EE RID: 1518
	public static GUIStyle ButtonJoinRed = GUIStyle.none;

	// Token: 0x040005EF RID: 1519
	public static GUIStyle ButtonJoinGray = GUIStyle.none;

	// Token: 0x040005F0 RID: 1520
	public static GUIStyle ButtonSpectator = GUIStyle.none;

	// Token: 0x040005F1 RID: 1521
	public static GUIStyle ButtonLoadout = GUIStyle.none;

	// Token: 0x040005F2 RID: 1522
	public static GUIStyle ButtonLoadoutRed = GUIStyle.none;

	// Token: 0x040005F3 RID: 1523
	public static GUIStyle InGameChatBlue = GUIStyle.none;

	// Token: 0x040005F4 RID: 1524
	public static GUIStyle InGameChatRed = GUIStyle.none;

	// Token: 0x040005F5 RID: 1525
	public static GUIStyle DotBlue = GUIStyle.none;

	// Token: 0x040005F6 RID: 1526
	public static GUIStyle DotRed = GUIStyle.none;

	// Token: 0x040005F7 RID: 1527
	public static GUIStyle DotGray = GUIStyle.none;

	// Token: 0x040005F8 RID: 1528
	public static GUIStyle ButtonCam = GUIStyle.none;

	// Token: 0x040005F9 RID: 1529
	public static GUIStyle Interpark32Center = GUIStyle.none;

	// Token: 0x040005FA RID: 1530
	public static GUIStyle Interpark16Left = GUIStyle.none;

	// Token: 0x040005FB RID: 1531
	public static GUIStyle ProgressBackground = GUIStyle.none;

	// Token: 0x040005FC RID: 1532
	public static GUIStyle ProgressForeground = GUIStyle.none;

	// Token: 0x040005FD RID: 1533
	public static GUIStyle ProgressThumb = GUIStyle.none;

	// Token: 0x040005FE RID: 1534
	public static GUIStyle MenuTile = GUIStyle.none;
}
