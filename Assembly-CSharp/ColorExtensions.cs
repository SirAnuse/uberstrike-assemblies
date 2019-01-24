using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public static class ColorExtensions
{
	// Token: 0x06001C74 RID: 7284 RVA: 0x00012DFF File Offset: 0x00010FFF
	public static Color SetAlpha(this Color color, float alpha)
	{
		return new Color(color.r, color.g, color.b, alpha);
	}

	// Token: 0x06001C75 RID: 7285 RVA: 0x00012E1C File Offset: 0x0001101C
	public static Color SetAlphaInt(this Color color, int alpha)
	{
		return new Color(color.r, color.g, color.b, (float)alpha / 255f);
	}

	// Token: 0x06001C76 RID: 7286 RVA: 0x00012DFF File Offset: 0x00010FFF
	public static Color MultiplyAlpha(this Color color, float alpha)
	{
		return new Color(color.r, color.g, color.b, alpha);
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x00012E40 File Offset: 0x00011040
	public static Color SetIntensity(this Color color, float intensity, float alpha)
	{
		return new Color(color.r * intensity, color.g * intensity, color.b * intensity, alpha);
	}
}
