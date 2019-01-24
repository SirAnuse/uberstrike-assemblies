using System;
using System.Globalization;
using UnityEngine;

// Token: 0x020003C5 RID: 965
public static class ColorConverter
{
	// Token: 0x06001C2F RID: 7215 RVA: 0x0008F5B8 File Offset: 0x0008D7B8
	public static float GetHue(Color c)
	{
		float num;
		if (c.r == 0f)
		{
			num = 2f;
			num += ((c.b >= 1f) ? (2f - c.g) : c.b);
		}
		else if (c.g == 0f)
		{
			num = 4f;
			num += ((c.r >= 1f) ? (2f - c.b) : c.r);
		}
		else
		{
			num = 0f;
			num += ((c.g >= 1f) ? (2f - c.r) : c.g);
		}
		return num;
	}

	// Token: 0x06001C30 RID: 7216 RVA: 0x0008F694 File Offset: 0x0008D894
	public static Color GetColor(float hue)
	{
		hue %= 6f;
		Color white = Color.white;
		if (hue < 1f)
		{
			white = new Color(1f, hue, 0f);
		}
		else if (hue < 2f)
		{
			white = new Color(2f - hue, 1f, 0f);
		}
		else if (hue < 3f)
		{
			white = new Color(0f, 1f, hue - 2f);
		}
		else if (hue < 4f)
		{
			white = new Color(0f, 4f - hue, 1f);
		}
		else if (hue < 5f)
		{
			white = new Color(hue - 4f, 0f, 1f);
		}
		else
		{
			white = new Color(1f, 0f, 6f - hue);
		}
		return white;
	}

	// Token: 0x06001C31 RID: 7217 RVA: 0x0008F78C File Offset: 0x0008D98C
	public static Color HexToColor(string hexString)
	{
		int num;
		try
		{
			num = int.Parse(hexString.Substring(0, 2), NumberStyles.HexNumber);
		}
		catch
		{
			num = 255;
		}
		int num2;
		try
		{
			num2 = int.Parse(hexString.Substring(2, 2), NumberStyles.HexNumber);
		}
		catch
		{
			num2 = 255;
		}
		int num3;
		try
		{
			num3 = int.Parse(hexString.Substring(4, 2), NumberStyles.HexNumber);
		}
		catch
		{
			num3 = 255;
		}
		return new Color((float)num / 255f, (float)num2 / 255f, (float)num3 / 255f);
	}

	// Token: 0x06001C32 RID: 7218 RVA: 0x0008F84C File Offset: 0x0008DA4C
	public static string ColorToHex(Color color)
	{
		string str = ((int)(color.r * 255f)).ToString("X2");
		string str2 = ((int)(color.g * 255f)).ToString("X2");
		string str3 = ((int)(color.b * 255f)).ToString("X2");
		return str + str2 + str3;
	}

	// Token: 0x06001C33 RID: 7219 RVA: 0x00012B9D File Offset: 0x00010D9D
	public static Color RgbToColor(float r, float g, float b)
	{
		return new Color(r / 255f, g / 255f, b / 255f);
	}

	// Token: 0x06001C34 RID: 7220 RVA: 0x00012BB9 File Offset: 0x00010DB9
	public static Color RgbaToColor(float r, float g, float b, float a)
	{
		return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
	}
}
