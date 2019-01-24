using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public static class GlobalUiIcons
{
	// Token: 0x06000640 RID: 1600 RVA: 0x00030474 File Offset: 0x0002E674
	static GlobalUiIcons()
	{
		Texture2DConfigurator component;
		try
		{
			component = GameObject.Find("GlobalUiIcons").GetComponent<Texture2DConfigurator>();
		}
		catch
		{
			Debug.LogError("Missing instance of the prefab with name: GlobalUiIcons!");
			return;
		}
		GlobalUiIcons.QuadpanelButtonFullscreen = component.Assets[0];
		GlobalUiIcons.QuadpanelButtonNormalize = component.Assets[1];
		GlobalUiIcons.QuadpanelButtonModerate = component.Assets[2];
		GlobalUiIcons.QuadpanelButtonSoundoff = component.Assets[3];
		GlobalUiIcons.QuadpanelButtonSoundon = component.Assets[4];
		GlobalUiIcons.QuadpanelButtonReportplayer = component.Assets[5];
		GlobalUiIcons.QuadpanelButtonOptions = component.Assets[6];
		GlobalUiIcons.QuadpanelButtonHelp = component.Assets[7];
		GlobalUiIcons.NewInboxMessage = component.Assets[8];
		GlobalUiIcons.QuadpanelButtonLogout = component.Assets[9];
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x06000641 RID: 1601 RVA: 0x000060FD File Offset: 0x000042FD
	// (set) Token: 0x06000642 RID: 1602 RVA: 0x00006104 File Offset: 0x00004304
	public static Texture2D QuadpanelButtonFullscreen { get; private set; }

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x06000643 RID: 1603 RVA: 0x0000610C File Offset: 0x0000430C
	// (set) Token: 0x06000644 RID: 1604 RVA: 0x00006113 File Offset: 0x00004313
	public static Texture2D QuadpanelButtonNormalize { get; private set; }

	// Token: 0x170001BC RID: 444
	// (get) Token: 0x06000645 RID: 1605 RVA: 0x0000611B File Offset: 0x0000431B
	// (set) Token: 0x06000646 RID: 1606 RVA: 0x00006122 File Offset: 0x00004322
	public static Texture2D QuadpanelButtonModerate { get; private set; }

	// Token: 0x170001BD RID: 445
	// (get) Token: 0x06000647 RID: 1607 RVA: 0x0000612A File Offset: 0x0000432A
	// (set) Token: 0x06000648 RID: 1608 RVA: 0x00006131 File Offset: 0x00004331
	public static Texture2D QuadpanelButtonSoundoff { get; private set; }

	// Token: 0x170001BE RID: 446
	// (get) Token: 0x06000649 RID: 1609 RVA: 0x00006139 File Offset: 0x00004339
	// (set) Token: 0x0600064A RID: 1610 RVA: 0x00006140 File Offset: 0x00004340
	public static Texture2D QuadpanelButtonSoundon { get; private set; }

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x0600064B RID: 1611 RVA: 0x00006148 File Offset: 0x00004348
	// (set) Token: 0x0600064C RID: 1612 RVA: 0x0000614F File Offset: 0x0000434F
	public static Texture2D QuadpanelButtonReportplayer { get; private set; }

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x0600064D RID: 1613 RVA: 0x00006157 File Offset: 0x00004357
	// (set) Token: 0x0600064E RID: 1614 RVA: 0x0000615E File Offset: 0x0000435E
	public static Texture2D QuadpanelButtonOptions { get; private set; }

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x0600064F RID: 1615 RVA: 0x00006166 File Offset: 0x00004366
	// (set) Token: 0x06000650 RID: 1616 RVA: 0x0000616D File Offset: 0x0000436D
	public static Texture2D QuadpanelButtonHelp { get; private set; }

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x06000651 RID: 1617 RVA: 0x00006175 File Offset: 0x00004375
	// (set) Token: 0x06000652 RID: 1618 RVA: 0x0000617C File Offset: 0x0000437C
	public static Texture2D NewInboxMessage { get; private set; }

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06000653 RID: 1619 RVA: 0x00006184 File Offset: 0x00004384
	// (set) Token: 0x06000654 RID: 1620 RVA: 0x0000618B File Offset: 0x0000438B
	public static Texture2D QuadpanelButtonLogout { get; private set; }
}
