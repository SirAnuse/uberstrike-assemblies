using System;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public static class ShopIcons
{
	// Token: 0x0600068D RID: 1677 RVA: 0x00030C28 File Offset: 0x0002EE28
	static ShopIcons()
	{
		Texture2DConfigurator component = GameObject.Find("ShopIcons").GetComponent<Texture2DConfigurator>();
		if (component == null)
		{
			throw new Exception("Missing instance of the prefab with name: ShopIcons!");
		}
		ShopIcons.StatsMostWeaponSplatsMelee = component.Assets[0];
		ShopIcons.StatsMostWeaponSplatsHandgun = component.Assets[1];
		ShopIcons.StatsMostWeaponSplatsMachinegun = component.Assets[2];
		ShopIcons.StatsMostWeaponSplatsShotgun = component.Assets[3];
		ShopIcons.StatsMostWeaponSplatsSniperRifle = component.Assets[4];
		ShopIcons.StatsMostWeaponSplatsCannon = component.Assets[5];
		ShopIcons.StatsMostWeaponSplatsSplattergun = component.Assets[6];
		ShopIcons.StatsMostWeaponSplatsLauncher = component.Assets[7];
		ShopIcons.Boots = component.Assets[8];
		ShopIcons.Head = component.Assets[9];
		ShopIcons.Face = component.Assets[10];
		ShopIcons.Upperbody = component.Assets[11];
		ShopIcons.Lowerbody = component.Assets[12];
		ShopIcons.Gloves = component.Assets[13];
		ShopIcons.Holos = component.Assets[14];
		ShopIcons.RecentItems = component.Assets[15];
		ShopIcons.FunctionalItems = component.Assets[16];
		ShopIcons.WeaponItems = component.Assets[17];
		ShopIcons.GearItems = component.Assets[18];
		ShopIcons.QuickItems = component.Assets[19];
		ShopIcons.NewItems = component.Assets[20];
		ShopIcons.LoadoutTabWeapons = component.Assets[21];
		ShopIcons.LoadoutTabGear = component.Assets[22];
		ShopIcons.LoadoutTabItems = component.Assets[23];
		ShopIcons.LabsInventory = component.Assets[24];
		ShopIcons.LabsShop = component.Assets[25];
		ShopIcons.LabsUndergroundIcon = component.Assets[26];
		ShopIcons.BundleIcon32x32 = component.Assets[27];
		ShopIcons.IconLottery = component.Assets[28];
		ShopIcons.CreditsIcon32x32 = component.Assets[29];
		ShopIcons.CreditsIcon48x48 = component.Assets[30];
		ShopIcons.CreditsIcon75x75 = component.Assets[31];
		ShopIcons.Points48x48 = component.Assets[32];
		ShopIcons.IconPoints20x20 = component.Assets[33];
		ShopIcons.IconCredits20x20 = component.Assets[34];
		ShopIcons.Stats1Kills20x20 = component.Assets[35];
		ShopIcons.Stats2Smackdowns20x20 = component.Assets[36];
		ShopIcons.Stats3Headshots20x20 = component.Assets[37];
		ShopIcons.Stats4Nutshots20x20 = component.Assets[38];
		ShopIcons.Stats5Damage20x20 = component.Assets[39];
		ShopIcons.Stats6Deaths20x20 = component.Assets[40];
		ShopIcons.Stats7Kdr20x20 = component.Assets[41];
		ShopIcons.Stats8Suicides20x20 = component.Assets[42];
		ShopIcons.New = component.Assets[43];
		ShopIcons.Hot = component.Assets[44];
		ShopIcons.Sale = component.Assets[45];
		ShopIcons.BlankItemFrame = component.Assets[46];
		ShopIcons.CheckMark = component.Assets[47];
		ShopIcons.ItemexpirationIcon = component.Assets[48];
		ShopIcons.ItemarmorpointsIcon = component.Assets[49];
		ShopIcons.ArrowBigShop = component.Assets[50];
		ShopIcons.ArrowSmallDownWhite = component.Assets[51];
		ShopIcons.ArrowSmallUpWhite = component.Assets[52];
		ShopIcons.ItemSlotSelected = component.Assets[53];
	}

	// Token: 0x170001DE RID: 478
	// (get) Token: 0x0600068E RID: 1678 RVA: 0x00006319 File Offset: 0x00004519
	// (set) Token: 0x0600068F RID: 1679 RVA: 0x00006320 File Offset: 0x00004520
	public static Texture2D StatsMostWeaponSplatsMelee { get; private set; }

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x06000690 RID: 1680 RVA: 0x00006328 File Offset: 0x00004528
	// (set) Token: 0x06000691 RID: 1681 RVA: 0x0000632F File Offset: 0x0000452F
	public static Texture2D StatsMostWeaponSplatsHandgun { get; private set; }

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x06000692 RID: 1682 RVA: 0x00006337 File Offset: 0x00004537
	// (set) Token: 0x06000693 RID: 1683 RVA: 0x0000633E File Offset: 0x0000453E
	public static Texture2D StatsMostWeaponSplatsMachinegun { get; private set; }

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x06000694 RID: 1684 RVA: 0x00006346 File Offset: 0x00004546
	// (set) Token: 0x06000695 RID: 1685 RVA: 0x0000634D File Offset: 0x0000454D
	public static Texture2D StatsMostWeaponSplatsShotgun { get; private set; }

	// Token: 0x170001E2 RID: 482
	// (get) Token: 0x06000696 RID: 1686 RVA: 0x00006355 File Offset: 0x00004555
	// (set) Token: 0x06000697 RID: 1687 RVA: 0x0000635C File Offset: 0x0000455C
	public static Texture2D StatsMostWeaponSplatsSniperRifle { get; private set; }

	// Token: 0x170001E3 RID: 483
	// (get) Token: 0x06000698 RID: 1688 RVA: 0x00006364 File Offset: 0x00004564
	// (set) Token: 0x06000699 RID: 1689 RVA: 0x0000636B File Offset: 0x0000456B
	public static Texture2D StatsMostWeaponSplatsCannon { get; private set; }

	// Token: 0x170001E4 RID: 484
	// (get) Token: 0x0600069A RID: 1690 RVA: 0x00006373 File Offset: 0x00004573
	// (set) Token: 0x0600069B RID: 1691 RVA: 0x0000637A File Offset: 0x0000457A
	public static Texture2D StatsMostWeaponSplatsSplattergun { get; private set; }

	// Token: 0x170001E5 RID: 485
	// (get) Token: 0x0600069C RID: 1692 RVA: 0x00006382 File Offset: 0x00004582
	// (set) Token: 0x0600069D RID: 1693 RVA: 0x00006389 File Offset: 0x00004589
	public static Texture2D StatsMostWeaponSplatsLauncher { get; private set; }

	// Token: 0x170001E6 RID: 486
	// (get) Token: 0x0600069E RID: 1694 RVA: 0x00006391 File Offset: 0x00004591
	// (set) Token: 0x0600069F RID: 1695 RVA: 0x00006398 File Offset: 0x00004598
	public static Texture2D Boots { get; private set; }

	// Token: 0x170001E7 RID: 487
	// (get) Token: 0x060006A0 RID: 1696 RVA: 0x000063A0 File Offset: 0x000045A0
	// (set) Token: 0x060006A1 RID: 1697 RVA: 0x000063A7 File Offset: 0x000045A7
	public static Texture2D Head { get; private set; }

	// Token: 0x170001E8 RID: 488
	// (get) Token: 0x060006A2 RID: 1698 RVA: 0x000063AF File Offset: 0x000045AF
	// (set) Token: 0x060006A3 RID: 1699 RVA: 0x000063B6 File Offset: 0x000045B6
	public static Texture2D Face { get; private set; }

	// Token: 0x170001E9 RID: 489
	// (get) Token: 0x060006A4 RID: 1700 RVA: 0x000063BE File Offset: 0x000045BE
	// (set) Token: 0x060006A5 RID: 1701 RVA: 0x000063C5 File Offset: 0x000045C5
	public static Texture2D Upperbody { get; private set; }

	// Token: 0x170001EA RID: 490
	// (get) Token: 0x060006A6 RID: 1702 RVA: 0x000063CD File Offset: 0x000045CD
	// (set) Token: 0x060006A7 RID: 1703 RVA: 0x000063D4 File Offset: 0x000045D4
	public static Texture2D Lowerbody { get; private set; }

	// Token: 0x170001EB RID: 491
	// (get) Token: 0x060006A8 RID: 1704 RVA: 0x000063DC File Offset: 0x000045DC
	// (set) Token: 0x060006A9 RID: 1705 RVA: 0x000063E3 File Offset: 0x000045E3
	public static Texture2D Gloves { get; private set; }

	// Token: 0x170001EC RID: 492
	// (get) Token: 0x060006AA RID: 1706 RVA: 0x000063EB File Offset: 0x000045EB
	// (set) Token: 0x060006AB RID: 1707 RVA: 0x000063F2 File Offset: 0x000045F2
	public static Texture2D Holos { get; private set; }

	// Token: 0x170001ED RID: 493
	// (get) Token: 0x060006AC RID: 1708 RVA: 0x000063FA File Offset: 0x000045FA
	// (set) Token: 0x060006AD RID: 1709 RVA: 0x00006401 File Offset: 0x00004601
	public static Texture2D RecentItems { get; private set; }

	// Token: 0x170001EE RID: 494
	// (get) Token: 0x060006AE RID: 1710 RVA: 0x00006409 File Offset: 0x00004609
	// (set) Token: 0x060006AF RID: 1711 RVA: 0x00006410 File Offset: 0x00004610
	public static Texture2D FunctionalItems { get; private set; }

	// Token: 0x170001EF RID: 495
	// (get) Token: 0x060006B0 RID: 1712 RVA: 0x00006418 File Offset: 0x00004618
	// (set) Token: 0x060006B1 RID: 1713 RVA: 0x0000641F File Offset: 0x0000461F
	public static Texture2D WeaponItems { get; private set; }

	// Token: 0x170001F0 RID: 496
	// (get) Token: 0x060006B2 RID: 1714 RVA: 0x00006427 File Offset: 0x00004627
	// (set) Token: 0x060006B3 RID: 1715 RVA: 0x0000642E File Offset: 0x0000462E
	public static Texture2D GearItems { get; private set; }

	// Token: 0x170001F1 RID: 497
	// (get) Token: 0x060006B4 RID: 1716 RVA: 0x00006436 File Offset: 0x00004636
	// (set) Token: 0x060006B5 RID: 1717 RVA: 0x0000643D File Offset: 0x0000463D
	public static Texture2D QuickItems { get; private set; }

	// Token: 0x170001F2 RID: 498
	// (get) Token: 0x060006B6 RID: 1718 RVA: 0x00006445 File Offset: 0x00004645
	// (set) Token: 0x060006B7 RID: 1719 RVA: 0x0000644C File Offset: 0x0000464C
	public static Texture2D NewItems { get; private set; }

	// Token: 0x170001F3 RID: 499
	// (get) Token: 0x060006B8 RID: 1720 RVA: 0x00006454 File Offset: 0x00004654
	// (set) Token: 0x060006B9 RID: 1721 RVA: 0x0000645B File Offset: 0x0000465B
	public static Texture2D LoadoutTabWeapons { get; private set; }

	// Token: 0x170001F4 RID: 500
	// (get) Token: 0x060006BA RID: 1722 RVA: 0x00006463 File Offset: 0x00004663
	// (set) Token: 0x060006BB RID: 1723 RVA: 0x0000646A File Offset: 0x0000466A
	public static Texture2D LoadoutTabGear { get; private set; }

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x060006BC RID: 1724 RVA: 0x00006472 File Offset: 0x00004672
	// (set) Token: 0x060006BD RID: 1725 RVA: 0x00006479 File Offset: 0x00004679
	public static Texture2D LoadoutTabItems { get; private set; }

	// Token: 0x170001F6 RID: 502
	// (get) Token: 0x060006BE RID: 1726 RVA: 0x00006481 File Offset: 0x00004681
	// (set) Token: 0x060006BF RID: 1727 RVA: 0x00006488 File Offset: 0x00004688
	public static Texture2D LabsInventory { get; private set; }

	// Token: 0x170001F7 RID: 503
	// (get) Token: 0x060006C0 RID: 1728 RVA: 0x00006490 File Offset: 0x00004690
	// (set) Token: 0x060006C1 RID: 1729 RVA: 0x00006497 File Offset: 0x00004697
	public static Texture2D LabsShop { get; private set; }

	// Token: 0x170001F8 RID: 504
	// (get) Token: 0x060006C2 RID: 1730 RVA: 0x0000649F File Offset: 0x0000469F
	// (set) Token: 0x060006C3 RID: 1731 RVA: 0x000064A6 File Offset: 0x000046A6
	public static Texture2D LabsUndergroundIcon { get; private set; }

	// Token: 0x170001F9 RID: 505
	// (get) Token: 0x060006C4 RID: 1732 RVA: 0x000064AE File Offset: 0x000046AE
	// (set) Token: 0x060006C5 RID: 1733 RVA: 0x000064B5 File Offset: 0x000046B5
	public static Texture2D BundleIcon32x32 { get; private set; }

	// Token: 0x170001FA RID: 506
	// (get) Token: 0x060006C6 RID: 1734 RVA: 0x000064BD File Offset: 0x000046BD
	// (set) Token: 0x060006C7 RID: 1735 RVA: 0x000064C4 File Offset: 0x000046C4
	public static Texture2D IconLottery { get; private set; }

	// Token: 0x170001FB RID: 507
	// (get) Token: 0x060006C8 RID: 1736 RVA: 0x000064CC File Offset: 0x000046CC
	// (set) Token: 0x060006C9 RID: 1737 RVA: 0x000064D3 File Offset: 0x000046D3
	public static Texture2D CreditsIcon32x32 { get; private set; }

	// Token: 0x170001FC RID: 508
	// (get) Token: 0x060006CA RID: 1738 RVA: 0x000064DB File Offset: 0x000046DB
	// (set) Token: 0x060006CB RID: 1739 RVA: 0x000064E2 File Offset: 0x000046E2
	public static Texture2D CreditsIcon48x48 { get; private set; }

	// Token: 0x170001FD RID: 509
	// (get) Token: 0x060006CC RID: 1740 RVA: 0x000064EA File Offset: 0x000046EA
	// (set) Token: 0x060006CD RID: 1741 RVA: 0x000064F1 File Offset: 0x000046F1
	public static Texture2D CreditsIcon75x75 { get; private set; }

	// Token: 0x170001FE RID: 510
	// (get) Token: 0x060006CE RID: 1742 RVA: 0x000064F9 File Offset: 0x000046F9
	// (set) Token: 0x060006CF RID: 1743 RVA: 0x00006500 File Offset: 0x00004700
	public static Texture2D Points48x48 { get; private set; }

	// Token: 0x170001FF RID: 511
	// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00006508 File Offset: 0x00004708
	// (set) Token: 0x060006D1 RID: 1745 RVA: 0x0000650F File Offset: 0x0000470F
	public static Texture2D IconPoints20x20 { get; private set; }

	// Token: 0x17000200 RID: 512
	// (get) Token: 0x060006D2 RID: 1746 RVA: 0x00006517 File Offset: 0x00004717
	// (set) Token: 0x060006D3 RID: 1747 RVA: 0x0000651E File Offset: 0x0000471E
	public static Texture2D IconCredits20x20 { get; private set; }

	// Token: 0x17000201 RID: 513
	// (get) Token: 0x060006D4 RID: 1748 RVA: 0x00006526 File Offset: 0x00004726
	// (set) Token: 0x060006D5 RID: 1749 RVA: 0x0000652D File Offset: 0x0000472D
	public static Texture2D Stats1Kills20x20 { get; private set; }

	// Token: 0x17000202 RID: 514
	// (get) Token: 0x060006D6 RID: 1750 RVA: 0x00006535 File Offset: 0x00004735
	// (set) Token: 0x060006D7 RID: 1751 RVA: 0x0000653C File Offset: 0x0000473C
	public static Texture2D Stats2Smackdowns20x20 { get; private set; }

	// Token: 0x17000203 RID: 515
	// (get) Token: 0x060006D8 RID: 1752 RVA: 0x00006544 File Offset: 0x00004744
	// (set) Token: 0x060006D9 RID: 1753 RVA: 0x0000654B File Offset: 0x0000474B
	public static Texture2D Stats3Headshots20x20 { get; private set; }

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x060006DA RID: 1754 RVA: 0x00006553 File Offset: 0x00004753
	// (set) Token: 0x060006DB RID: 1755 RVA: 0x0000655A File Offset: 0x0000475A
	public static Texture2D Stats4Nutshots20x20 { get; private set; }

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x060006DC RID: 1756 RVA: 0x00006562 File Offset: 0x00004762
	// (set) Token: 0x060006DD RID: 1757 RVA: 0x00006569 File Offset: 0x00004769
	public static Texture2D Stats5Damage20x20 { get; private set; }

	// Token: 0x17000206 RID: 518
	// (get) Token: 0x060006DE RID: 1758 RVA: 0x00006571 File Offset: 0x00004771
	// (set) Token: 0x060006DF RID: 1759 RVA: 0x00006578 File Offset: 0x00004778
	public static Texture2D Stats6Deaths20x20 { get; private set; }

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x060006E0 RID: 1760 RVA: 0x00006580 File Offset: 0x00004780
	// (set) Token: 0x060006E1 RID: 1761 RVA: 0x00006587 File Offset: 0x00004787
	public static Texture2D Stats7Kdr20x20 { get; private set; }

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x060006E2 RID: 1762 RVA: 0x0000658F File Offset: 0x0000478F
	// (set) Token: 0x060006E3 RID: 1763 RVA: 0x00006596 File Offset: 0x00004796
	public static Texture2D Stats8Suicides20x20 { get; private set; }

	// Token: 0x17000209 RID: 521
	// (get) Token: 0x060006E4 RID: 1764 RVA: 0x0000659E File Offset: 0x0000479E
	// (set) Token: 0x060006E5 RID: 1765 RVA: 0x000065A5 File Offset: 0x000047A5
	public static Texture2D New { get; private set; }

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x060006E6 RID: 1766 RVA: 0x000065AD File Offset: 0x000047AD
	// (set) Token: 0x060006E7 RID: 1767 RVA: 0x000065B4 File Offset: 0x000047B4
	public static Texture2D Hot { get; private set; }

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x060006E8 RID: 1768 RVA: 0x000065BC File Offset: 0x000047BC
	// (set) Token: 0x060006E9 RID: 1769 RVA: 0x000065C3 File Offset: 0x000047C3
	public static Texture2D Sale { get; private set; }

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x060006EA RID: 1770 RVA: 0x000065CB File Offset: 0x000047CB
	// (set) Token: 0x060006EB RID: 1771 RVA: 0x000065D2 File Offset: 0x000047D2
	public static Texture2D BlankItemFrame { get; private set; }

	// Token: 0x1700020D RID: 525
	// (get) Token: 0x060006EC RID: 1772 RVA: 0x000065DA File Offset: 0x000047DA
	// (set) Token: 0x060006ED RID: 1773 RVA: 0x000065E1 File Offset: 0x000047E1
	public static Texture2D CheckMark { get; private set; }

	// Token: 0x1700020E RID: 526
	// (get) Token: 0x060006EE RID: 1774 RVA: 0x000065E9 File Offset: 0x000047E9
	// (set) Token: 0x060006EF RID: 1775 RVA: 0x000065F0 File Offset: 0x000047F0
	public static Texture2D ItemexpirationIcon { get; private set; }

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x060006F0 RID: 1776 RVA: 0x000065F8 File Offset: 0x000047F8
	// (set) Token: 0x060006F1 RID: 1777 RVA: 0x000065FF File Offset: 0x000047FF
	public static Texture2D ItemarmorpointsIcon { get; private set; }

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x060006F2 RID: 1778 RVA: 0x00006607 File Offset: 0x00004807
	// (set) Token: 0x060006F3 RID: 1779 RVA: 0x0000660E File Offset: 0x0000480E
	public static Texture2D ArrowBigShop { get; private set; }

	// Token: 0x17000211 RID: 529
	// (get) Token: 0x060006F4 RID: 1780 RVA: 0x00006616 File Offset: 0x00004816
	// (set) Token: 0x060006F5 RID: 1781 RVA: 0x0000661D File Offset: 0x0000481D
	public static Texture2D ArrowSmallDownWhite { get; private set; }

	// Token: 0x17000212 RID: 530
	// (get) Token: 0x060006F6 RID: 1782 RVA: 0x00006625 File Offset: 0x00004825
	// (set) Token: 0x060006F7 RID: 1783 RVA: 0x0000662C File Offset: 0x0000482C
	public static Texture2D ArrowSmallUpWhite { get; private set; }

	// Token: 0x17000213 RID: 531
	// (get) Token: 0x060006F8 RID: 1784 RVA: 0x00006634 File Offset: 0x00004834
	// (set) Token: 0x060006F9 RID: 1785 RVA: 0x0000663B File Offset: 0x0000483B
	public static Texture2D ItemSlotSelected { get; private set; }
}
