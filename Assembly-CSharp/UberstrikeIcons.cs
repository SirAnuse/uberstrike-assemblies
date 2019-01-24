using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public static class UberstrikeIcons
{
	// Token: 0x060006FE RID: 1790 RVA: 0x000316B0 File Offset: 0x0002F8B0
	static UberstrikeIcons()
	{
		Texture2DConfigurator component;
		try
		{
			component = GameObject.Find("UberstrikeIcons").GetComponent<Texture2DConfigurator>();
		}
		catch
		{
			Debug.LogError("Missing instance of the prefab with name: UberstrikeIcons!");
			return;
		}
		UberstrikeIcons.Waiting = component.Assets[0];
		UberstrikeIcons.IconXP20x20 = component.Assets[1];
		UberstrikeIcons.BlueLevel32 = component.Assets[2];
		UberstrikeIcons.LevelUpPopup = component.Assets[3];
		UberstrikeIcons.FacebookCreditsIcon = component.Assets[4];
		UberstrikeIcons.LevelMastered = component.Assets[5];
		UberstrikeIcons.FBScreenshotWatermark = component.Assets[6];
		UberstrikeIcons.Time20x20 = component.Assets[7];
	}

	// Token: 0x17000215 RID: 533
	// (get) Token: 0x060006FF RID: 1791 RVA: 0x00006652 File Offset: 0x00004852
	// (set) Token: 0x06000700 RID: 1792 RVA: 0x00006659 File Offset: 0x00004859
	public static Texture2D Waiting { get; private set; }

	// Token: 0x17000216 RID: 534
	// (get) Token: 0x06000701 RID: 1793 RVA: 0x00006661 File Offset: 0x00004861
	// (set) Token: 0x06000702 RID: 1794 RVA: 0x00006668 File Offset: 0x00004868
	public static Texture2D IconXP20x20 { get; private set; }

	// Token: 0x17000217 RID: 535
	// (get) Token: 0x06000703 RID: 1795 RVA: 0x00006670 File Offset: 0x00004870
	// (set) Token: 0x06000704 RID: 1796 RVA: 0x00006677 File Offset: 0x00004877
	public static Texture2D BlueLevel32 { get; private set; }

	// Token: 0x17000218 RID: 536
	// (get) Token: 0x06000705 RID: 1797 RVA: 0x0000667F File Offset: 0x0000487F
	// (set) Token: 0x06000706 RID: 1798 RVA: 0x00006686 File Offset: 0x00004886
	public static Texture2D LevelUpPopup { get; private set; }

	// Token: 0x17000219 RID: 537
	// (get) Token: 0x06000707 RID: 1799 RVA: 0x0000668E File Offset: 0x0000488E
	// (set) Token: 0x06000708 RID: 1800 RVA: 0x00006695 File Offset: 0x00004895
	public static Texture2D FacebookCreditsIcon { get; private set; }

	// Token: 0x1700021A RID: 538
	// (get) Token: 0x06000709 RID: 1801 RVA: 0x0000669D File Offset: 0x0000489D
	// (set) Token: 0x0600070A RID: 1802 RVA: 0x000066A4 File Offset: 0x000048A4
	public static Texture2D LevelMastered { get; private set; }

	// Token: 0x1700021B RID: 539
	// (get) Token: 0x0600070B RID: 1803 RVA: 0x000066AC File Offset: 0x000048AC
	// (set) Token: 0x0600070C RID: 1804 RVA: 0x000066B3 File Offset: 0x000048B3
	public static Texture2D FBScreenshotWatermark { get; private set; }

	// Token: 0x1700021C RID: 540
	// (get) Token: 0x0600070D RID: 1805 RVA: 0x000066BB File Offset: 0x000048BB
	// (set) Token: 0x0600070E RID: 1806 RVA: 0x000066C2 File Offset: 0x000048C2
	public static Texture2D Time20x20 { get; private set; }
}
