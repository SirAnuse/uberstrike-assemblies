using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class GUIUtils
{
	// Token: 0x060015A6 RID: 5542 RVA: 0x0000E79E File Offset: 0x0000C99E
	public static Color ColorFromInt(int r, int g, int b, int alpha = 255)
	{
		return new Color((float)r / 255f, (float)g / 255f, (float)b / 255f, (float)alpha / 255f);
	}

	// Token: 0x060015A7 RID: 5543 RVA: 0x000795D0 File Offset: 0x000777D0
	public static string ColorToNGuiModifier(Color color)
	{
		int num = (int)(255f * color.r);
		int num2 = (int)(255f * color.g);
		int num3 = (int)(255f * color.b);
		return string.Concat(new string[]
		{
			"[",
			num.ToString("X2"),
			num2.ToString("X2"),
			num3.ToString("X2"),
			"]"
		});
	}

	// Token: 0x04001459 RID: 5209
	public static Color ColorBlack = GUIUtils.ColorFromInt(0, 0, 0, 140);

	// Token: 0x0400145A RID: 5210
	public static Color ColorBlackActive = GUIUtils.ColorFromInt(40, 40, 40, 140);

	// Token: 0x0400145B RID: 5211
	public static Color ColorBlackPressed = GUIUtils.ColorFromInt(0, 0, 0, 70);

	// Token: 0x0400145C RID: 5212
	public static Color ColorRed = GUIUtils.ColorFromInt(255, 60, 48, 255);

	// Token: 0x0400145D RID: 5213
	public static Color ColorRedActive = GUIUtils.ColorFromInt(255, 77, 77, 255);

	// Token: 0x0400145E RID: 5214
	public static Color ColorRedPressed = GUIUtils.ColorFromInt(255, 60, 48, 140);

	// Token: 0x0400145F RID: 5215
	public static Color ColorYellow = GUIUtils.ColorFromInt(247, 148, 29, 255);

	// Token: 0x04001460 RID: 5216
	public static Color ColorYellowActive = GUIUtils.ColorFromInt(255, 202, 42, 255);

	// Token: 0x04001461 RID: 5217
	public static Color ColorYellowPressed = GUIUtils.ColorFromInt(247, 148, 29, 140);

	// Token: 0x04001462 RID: 5218
	public static Color ColorBlue = GUIUtils.ColorFromInt(0, 167, 209, 255);

	// Token: 0x04001463 RID: 5219
	public static Color ColorBlueActive = GUIUtils.ColorFromInt(0, 204, 255, 255);

	// Token: 0x04001464 RID: 5220
	public static Color ColorBluePressed = GUIUtils.ColorFromInt(0, 167, 209, 140);

	// Token: 0x04001465 RID: 5221
	public static Color ColorGreen = GUIUtils.ColorFromInt(0, 180, 97, 255);

	// Token: 0x04001466 RID: 5222
	public static Color ColorGreenActive = GUIUtils.ColorFromInt(0, 207, 110, 255);

	// Token: 0x04001467 RID: 5223
	public static Color ColorGreenPressed = GUIUtils.ColorFromInt(0, 180, 97, 140);
}
