using System;
using UnityEngine;

// Token: 0x020000B5 RID: 181
public static class PopupSkin
{
	// Token: 0x0600068A RID: 1674 RVA: 0x000309BC File Offset: 0x0002EBBC
	public static void Initialize(GUISkin skin)
	{
		PopupSkin.Skin = skin;
		PopupSkin.box = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("box"));
		PopupSkin.label = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("label"));
		PopupSkin.textField = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("textField"));
		PopupSkin.textArea = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("textArea"));
		PopupSkin.button = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("button"));
		PopupSkin.toggle = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("toggle"));
		PopupSkin.window = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("window"));
		PopupSkin.horizontalSlider = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("horizontalSlider"));
		PopupSkin.horizontalSliderThumb = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("horizontalSliderThumb"));
		PopupSkin.verticalSlider = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("verticalSlider"));
		PopupSkin.verticalSliderThumb = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("verticalSliderThumb"));
		PopupSkin.horizontalScrollbar = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("horizontalScrollbar"));
		PopupSkin.horizontalScrollbarThumb = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("horizontalScrollbarThumb"));
		PopupSkin.horizontalScrollbarLeftButton = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("horizontalScrollbarLeftButton"));
		PopupSkin.horizontalScrollbarRightButton = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("horizontalScrollbarRightButton"));
		PopupSkin.verticalScrollbar = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("verticalScrollbar"));
		PopupSkin.verticalScrollbarThumb = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("verticalScrollbarThumb"));
		PopupSkin.verticalScrollbarUpButton = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("verticalScrollbarUpButton"));
		PopupSkin.verticalScrollbarDownButton = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("verticalScrollbarDownButton"));
		PopupSkin.scrollView = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("scrollView"));
		PopupSkin.title = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("title"));
		PopupSkin.button_green = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("button_green"));
		PopupSkin.button_red = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("button_red"));
		PopupSkin.label_loading = LocalizationHelper.GetLocalizedStyle(PopupSkin.Skin.GetStyle("label_loading"));
	}

	// Token: 0x170001DD RID: 477
	// (get) Token: 0x0600068B RID: 1675 RVA: 0x0000630A File Offset: 0x0000450A
	// (set) Token: 0x0600068C RID: 1676 RVA: 0x00006311 File Offset: 0x00004511
	public static GUISkin Skin { get; private set; }

	// Token: 0x04000581 RID: 1409
	public static GUIStyle box = GUIStyle.none;

	// Token: 0x04000582 RID: 1410
	public static GUIStyle label = GUIStyle.none;

	// Token: 0x04000583 RID: 1411
	public static GUIStyle textField = GUIStyle.none;

	// Token: 0x04000584 RID: 1412
	public static GUIStyle textArea = GUIStyle.none;

	// Token: 0x04000585 RID: 1413
	public static GUIStyle button = GUIStyle.none;

	// Token: 0x04000586 RID: 1414
	public static GUIStyle toggle = GUIStyle.none;

	// Token: 0x04000587 RID: 1415
	public static GUIStyle window = GUIStyle.none;

	// Token: 0x04000588 RID: 1416
	public static GUIStyle horizontalSlider = GUIStyle.none;

	// Token: 0x04000589 RID: 1417
	public static GUIStyle horizontalSliderThumb = GUIStyle.none;

	// Token: 0x0400058A RID: 1418
	public static GUIStyle verticalSlider = GUIStyle.none;

	// Token: 0x0400058B RID: 1419
	public static GUIStyle verticalSliderThumb = GUIStyle.none;

	// Token: 0x0400058C RID: 1420
	public static GUIStyle horizontalScrollbar = GUIStyle.none;

	// Token: 0x0400058D RID: 1421
	public static GUIStyle horizontalScrollbarThumb = GUIStyle.none;

	// Token: 0x0400058E RID: 1422
	public static GUIStyle horizontalScrollbarLeftButton = GUIStyle.none;

	// Token: 0x0400058F RID: 1423
	public static GUIStyle horizontalScrollbarRightButton = GUIStyle.none;

	// Token: 0x04000590 RID: 1424
	public static GUIStyle verticalScrollbar = GUIStyle.none;

	// Token: 0x04000591 RID: 1425
	public static GUIStyle verticalScrollbarThumb = GUIStyle.none;

	// Token: 0x04000592 RID: 1426
	public static GUIStyle verticalScrollbarUpButton = GUIStyle.none;

	// Token: 0x04000593 RID: 1427
	public static GUIStyle verticalScrollbarDownButton = GUIStyle.none;

	// Token: 0x04000594 RID: 1428
	public static GUIStyle scrollView = GUIStyle.none;

	// Token: 0x04000595 RID: 1429
	public static GUIStyle title = GUIStyle.none;

	// Token: 0x04000596 RID: 1430
	public static GUIStyle button_green = GUIStyle.none;

	// Token: 0x04000597 RID: 1431
	public static GUIStyle button_red = GUIStyle.none;

	// Token: 0x04000598 RID: 1432
	public static GUIStyle label_loading = GUIStyle.none;
}
