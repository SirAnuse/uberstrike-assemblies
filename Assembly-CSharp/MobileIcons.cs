using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public static class MobileIcons
{
	// Token: 0x0600065A RID: 1626 RVA: 0x000305D4 File Offset: 0x0002E7D4
	static MobileIcons()
	{
		Texture2DAtlasHolder component;
		try
		{
			component = GameObject.Find("MobileIcons").GetComponent<Texture2DAtlasHolder>();
		}
		catch
		{
			Debug.LogError("Missing instance of the prefab with name: MobileIcons!");
			return;
		}
		MobileIcons.TextureAtlas = component.Atlas;
		MobileIcons.TouchArrowLeft = new Rect(0.1582031f, 0.8828125f, 0.01074219f, 0.015625f);
		MobileIcons.TouchArrowRight = new Rect(0.1582031f, 0.899414063f, 0.01074219f, 0.015625f);
		MobileIcons.TouchChatButton = new Rect(0.1132813f, 0.8828125f, 0.04394531f, 0.0439453162f);
		MobileIcons.TouchCrouchButton = new Rect(0.6962891f, 0.5f, 0.07421875f, 0.0732422f);
		MobileIcons.TouchCrouchButtonActive = new Rect(0.7714844f, 0.5f, 0.07421875f, 0.0732422f);
		MobileIcons.TouchFireButton = new Rect(0f, 0.8828125f, 0.1123047f, 0.111328147f);
		MobileIcons.TouchJumpButton = new Rect(0.5439453f, 0.5f, 0.07617188f, 0.07421875f);
		MobileIcons.TouchKeyboardDpad = new Rect(0f, 0.5f, 0.390625f, 0.204101548f);
		MobileIcons.TouchMenuButton = new Rect(0.1132813f, 0.9277344f, 0.04394531f, 0.0439453162f);
		MobileIcons.TouchMoveInner = new Rect(0.3916016f, 0.8808594f, 0.09082031f, 0.0908203f);
		MobileIcons.TouchMoveOuter = new Rect(0f, 0.7050781f, 0.1767578f, 0.1767578f);
		MobileIcons.TouchScoreboardButton = new Rect(0.3300781f, 0.7050781f, 0.04394531f, 0.0439453162f);
		MobileIcons.TouchSecondFireButton = new Rect(0.6210938f, 0.5f, 0.07421875f, 0.07421875f);
		MobileIcons.TouchWeaponCannon = new Rect(0.1777344f, 0.7050781f, 0.1513672f, 0.0751953f);
		MobileIcons.TouchWeaponHandgun = new Rect(0.1777344f, 0.78125f, 0.1513672f, 0.0751953f);
		MobileIcons.TouchWeaponLauncher = new Rect(0.1777344f, 0.8574219f, 0.1513672f, 0.0751953f);
		MobileIcons.TouchWeaponMachinegun = new Rect(0.3916016f, 0.5f, 0.1513672f, 0.0751953f);
		MobileIcons.TouchWeaponMelee = new Rect(0.3916016f, 0.5761719f, 0.1513672f, 0.0751953f);
		MobileIcons.TouchWeaponShotgun = new Rect(0.3916016f, 0.65234375f, 0.1513672f, 0.0751953f);
		MobileIcons.TouchWeaponSniperrifle = new Rect(0.3916016f, 0.7285156f, 0.1513672f, 0.0751953f);
		MobileIcons.TouchWeaponSplattergun = new Rect(0.3916016f, 0.8046875f, 0.1513672f, 0.0751953f);
		MobileIcons.TouchZoomScrollbar = new Rect(0.5439453f, 0.5751953f, 0.02636719f, 0.186523452f);
	}

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x0600065B RID: 1627 RVA: 0x000061B1 File Offset: 0x000043B1
	// (set) Token: 0x0600065C RID: 1628 RVA: 0x000061B8 File Offset: 0x000043B8
	public static Material TextureAtlas { get; private set; }

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x0600065D RID: 1629 RVA: 0x000061C0 File Offset: 0x000043C0
	// (set) Token: 0x0600065E RID: 1630 RVA: 0x000061C7 File Offset: 0x000043C7
	public static Rect TouchArrowLeft { get; private set; }

	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x0600065F RID: 1631 RVA: 0x000061CF File Offset: 0x000043CF
	// (set) Token: 0x06000660 RID: 1632 RVA: 0x000061D6 File Offset: 0x000043D6
	public static Rect TouchArrowRight { get; private set; }

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x06000661 RID: 1633 RVA: 0x000061DE File Offset: 0x000043DE
	// (set) Token: 0x06000662 RID: 1634 RVA: 0x000061E5 File Offset: 0x000043E5
	public static Rect TouchChatButton { get; private set; }

	// Token: 0x170001CA RID: 458
	// (get) Token: 0x06000663 RID: 1635 RVA: 0x000061ED File Offset: 0x000043ED
	// (set) Token: 0x06000664 RID: 1636 RVA: 0x000061F4 File Offset: 0x000043F4
	public static Rect TouchCrouchButton { get; private set; }

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x06000665 RID: 1637 RVA: 0x000061FC File Offset: 0x000043FC
	// (set) Token: 0x06000666 RID: 1638 RVA: 0x00006203 File Offset: 0x00004403
	public static Rect TouchCrouchButtonActive { get; private set; }

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x06000667 RID: 1639 RVA: 0x0000620B File Offset: 0x0000440B
	// (set) Token: 0x06000668 RID: 1640 RVA: 0x00006212 File Offset: 0x00004412
	public static Rect TouchFireButton { get; private set; }

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x06000669 RID: 1641 RVA: 0x0000621A File Offset: 0x0000441A
	// (set) Token: 0x0600066A RID: 1642 RVA: 0x00006221 File Offset: 0x00004421
	public static Rect TouchJumpButton { get; private set; }

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x0600066B RID: 1643 RVA: 0x00006229 File Offset: 0x00004429
	// (set) Token: 0x0600066C RID: 1644 RVA: 0x00006230 File Offset: 0x00004430
	public static Rect TouchKeyboardDpad { get; private set; }

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x0600066D RID: 1645 RVA: 0x00006238 File Offset: 0x00004438
	// (set) Token: 0x0600066E RID: 1646 RVA: 0x0000623F File Offset: 0x0000443F
	public static Rect TouchMenuButton { get; private set; }

	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x0600066F RID: 1647 RVA: 0x00006247 File Offset: 0x00004447
	// (set) Token: 0x06000670 RID: 1648 RVA: 0x0000624E File Offset: 0x0000444E
	public static Rect TouchMoveInner { get; private set; }

	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x06000671 RID: 1649 RVA: 0x00006256 File Offset: 0x00004456
	// (set) Token: 0x06000672 RID: 1650 RVA: 0x0000625D File Offset: 0x0000445D
	public static Rect TouchMoveOuter { get; private set; }

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x06000673 RID: 1651 RVA: 0x00006265 File Offset: 0x00004465
	// (set) Token: 0x06000674 RID: 1652 RVA: 0x0000626C File Offset: 0x0000446C
	public static Rect TouchScoreboardButton { get; private set; }

	// Token: 0x170001D3 RID: 467
	// (get) Token: 0x06000675 RID: 1653 RVA: 0x00006274 File Offset: 0x00004474
	// (set) Token: 0x06000676 RID: 1654 RVA: 0x0000627B File Offset: 0x0000447B
	public static Rect TouchSecondFireButton { get; private set; }

	// Token: 0x170001D4 RID: 468
	// (get) Token: 0x06000677 RID: 1655 RVA: 0x00006283 File Offset: 0x00004483
	// (set) Token: 0x06000678 RID: 1656 RVA: 0x0000628A File Offset: 0x0000448A
	public static Rect TouchWeaponCannon { get; private set; }

	// Token: 0x170001D5 RID: 469
	// (get) Token: 0x06000679 RID: 1657 RVA: 0x00006292 File Offset: 0x00004492
	// (set) Token: 0x0600067A RID: 1658 RVA: 0x00006299 File Offset: 0x00004499
	public static Rect TouchWeaponHandgun { get; private set; }

	// Token: 0x170001D6 RID: 470
	// (get) Token: 0x0600067B RID: 1659 RVA: 0x000062A1 File Offset: 0x000044A1
	// (set) Token: 0x0600067C RID: 1660 RVA: 0x000062A8 File Offset: 0x000044A8
	public static Rect TouchWeaponLauncher { get; private set; }

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x0600067D RID: 1661 RVA: 0x000062B0 File Offset: 0x000044B0
	// (set) Token: 0x0600067E RID: 1662 RVA: 0x000062B7 File Offset: 0x000044B7
	public static Rect TouchWeaponMachinegun { get; private set; }

	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x0600067F RID: 1663 RVA: 0x000062BF File Offset: 0x000044BF
	// (set) Token: 0x06000680 RID: 1664 RVA: 0x000062C6 File Offset: 0x000044C6
	public static Rect TouchWeaponMelee { get; private set; }

	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x06000681 RID: 1665 RVA: 0x000062CE File Offset: 0x000044CE
	// (set) Token: 0x06000682 RID: 1666 RVA: 0x000062D5 File Offset: 0x000044D5
	public static Rect TouchWeaponShotgun { get; private set; }

	// Token: 0x170001DA RID: 474
	// (get) Token: 0x06000683 RID: 1667 RVA: 0x000062DD File Offset: 0x000044DD
	// (set) Token: 0x06000684 RID: 1668 RVA: 0x000062E4 File Offset: 0x000044E4
	public static Rect TouchWeaponSniperrifle { get; private set; }

	// Token: 0x170001DB RID: 475
	// (get) Token: 0x06000685 RID: 1669 RVA: 0x000062EC File Offset: 0x000044EC
	// (set) Token: 0x06000686 RID: 1670 RVA: 0x000062F3 File Offset: 0x000044F3
	public static Rect TouchWeaponSplattergun { get; private set; }

	// Token: 0x170001DC RID: 476
	// (get) Token: 0x06000687 RID: 1671 RVA: 0x000062FB File Offset: 0x000044FB
	// (set) Token: 0x06000688 RID: 1672 RVA: 0x00006302 File Offset: 0x00004502
	public static Rect TouchZoomScrollbar { get; private set; }
}
