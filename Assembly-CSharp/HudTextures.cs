using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public static class HudTextures
{
	// Token: 0x06000655 RID: 1621 RVA: 0x00030568 File Offset: 0x0002E768
	static HudTextures()
	{
		Texture2DConfigurator component;
		try
		{
			component = GameObject.Find("HudTextures").GetComponent<Texture2DConfigurator>();
		}
		catch
		{
			Debug.LogError("Missing instance of the prefab with name: HudTextures!");
			return;
		}
		HudTextures.WhiteBlur128 = component.Assets[0];
		HudTextures.DamageFeedbackMark = component.Assets[1];
	}

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06000656 RID: 1622 RVA: 0x00006193 File Offset: 0x00004393
	// (set) Token: 0x06000657 RID: 1623 RVA: 0x0000619A File Offset: 0x0000439A
	public static Texture2D WhiteBlur128 { get; private set; }

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x06000658 RID: 1624 RVA: 0x000061A2 File Offset: 0x000043A2
	// (set) Token: 0x06000659 RID: 1625 RVA: 0x000061A9 File Offset: 0x000043A9
	public static Texture2D DamageFeedbackMark { get; private set; }
}
