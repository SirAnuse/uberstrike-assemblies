using System;
using UnityEngine;

// Token: 0x02000156 RID: 342
public static class UnityGUI
{
	// Token: 0x06000916 RID: 2326 RVA: 0x00039DF8 File Offset: 0x00037FF8
	public static int Toolbar(Rect position, int selected, GUIContent[] contents, int xCount, GUIStyle style)
	{
		int result = GUI.Toolbar(position, selected, contents, style);
		int controlID = GUIUtility.GetControlID(FocusType.Native, position);
		EventType typeForControl = Event.current.GetTypeForControl(controlID);
		if (typeForControl == EventType.Repaint)
		{
			GUIStyle firstStyle = null;
			GUIStyle midStyle = null;
			GUIStyle lastStyle = null;
			UnityGUI.FindStyles(ref style, out firstStyle, out midStyle, out lastStyle, "left", "mid", "right");
			int num = contents.Length;
			int num2 = num / xCount;
			if (num % xCount != 0)
			{
				num2++;
			}
			float num3 = (float)UnityGUI.CalcTotalHorizSpacing(xCount, style, firstStyle, midStyle, lastStyle);
			float num4 = (float)(Mathf.Max(style.margin.top, style.margin.bottom) * (num2 - 1));
			float elemWidth = (position.width - num3) / (float)xCount;
			float elemHeight = (position.height - num4) / (float)num2;
			Rect[] buttonRects = UnityGUI.CalcMouseRects(position, num, xCount, elemWidth, elemHeight, style, firstStyle, midStyle, lastStyle, false);
			int buttonGridMouseSelection = UnityGUI.GetButtonGridMouseSelection(buttonRects, Event.current.mousePosition, controlID == GUIUtility.hotControl);
			if (buttonGridMouseSelection >= 0)
			{
				GUI.tooltip = contents[buttonGridMouseSelection].tooltip;
			}
		}
		return result;
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x00039F10 File Offset: 0x00038110
	internal static GUIContent[] Temp(string[] texts)
	{
		GUIContent[] array = new GUIContent[texts.Length];
		for (int i = 0; i < texts.Length; i++)
		{
			array[i] = new GUIContent(texts[i]);
		}
		return array;
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x00007AC3 File Offset: 0x00005CC3
	public static int Toolbar(Rect position, int selected, string[] contents, int length, GUIStyle style)
	{
		return UnityGUI.Toolbar(position, selected, UnityGUI.Temp(contents), length, style);
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x00007AD5 File Offset: 0x00005CD5
	public static int Toolbar(Rect position, int selected, GUIContent[] contents, GUIStyle style)
	{
		return UnityGUI.Toolbar(position, selected, contents, contents.Length, style);
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x00039F48 File Offset: 0x00038148
	internal static void FindStyles(ref GUIStyle style, out GUIStyle firstStyle, out GUIStyle midStyle, out GUIStyle lastStyle, string first, string mid, string last)
	{
		if (style == null)
		{
			style = GUI.skin.button;
		}
		string name = style.name;
		midStyle = GUI.skin.FindStyle(name + mid);
		if (midStyle == null)
		{
			midStyle = style;
		}
		firstStyle = GUI.skin.FindStyle(name + first);
		if (firstStyle == null)
		{
			firstStyle = midStyle;
		}
		lastStyle = GUI.skin.FindStyle(name + last);
		if (lastStyle == null)
		{
			lastStyle = midStyle;
		}
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x00039FD0 File Offset: 0x000381D0
	private static Rect[] CalcMouseRects(Rect position, int count, int xCount, float elemWidth, float elemHeight, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle, bool addBorders)
	{
		int num = 0;
		int num2 = 0;
		float num3 = position.xMin;
		float num4 = position.yMin;
		GUIStyle guistyle = style;
		Rect[] array = new Rect[count];
		if (count > 1)
		{
			guistyle = firstStyle;
		}
		for (int i = 0; i < count; i++)
		{
			if (addBorders)
			{
				array[i] = guistyle.margin.Add(new Rect(num3, num4, elemWidth, elemHeight));
			}
			else
			{
				array[i] = new Rect(num3, num4, elemWidth, elemHeight);
			}
			array[i].width = Mathf.Round(array[i].xMax) - Mathf.Round(array[i].x);
			array[i].x = Mathf.Round(array[i].x);
			GUIStyle guistyle2 = midStyle;
			if (i == count - 2)
			{
				guistyle2 = lastStyle;
			}
			num3 = num3 + elemWidth + (float)Mathf.Max(guistyle.margin.right, guistyle2.margin.left);
			num2++;
			if (num2 >= xCount)
			{
				num++;
				num2 = 0;
				num4 = num4 + elemHeight + (float)Mathf.Max(style.margin.top, style.margin.bottom);
				num3 = position.xMin;
			}
		}
		return array;
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x0003A130 File Offset: 0x00038330
	private static int GetButtonGridMouseSelection(Rect[] buttonRects, Vector2 mousePos, bool findNearest)
	{
		for (int i = 0; i < buttonRects.Length; i++)
		{
			if (buttonRects[i].Contains(mousePos))
			{
				return i;
			}
		}
		if (findNearest)
		{
			float num = 1E+07f;
			int result = -1;
			for (int j = 0; j < buttonRects.Length; j++)
			{
				Rect rect = buttonRects[j];
				Vector2 b = new Vector2(Mathf.Clamp(mousePos.x, rect.xMin, rect.xMax), Mathf.Clamp(mousePos.y, rect.yMin, rect.yMax));
				float sqrMagnitude = (mousePos - b).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					result = j;
					num = sqrMagnitude;
				}
			}
			return result;
		}
		return -1;
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x0003A1F8 File Offset: 0x000383F8
	internal static int CalcTotalHorizSpacing(int xCount, GUIStyle style, GUIStyle firstStyle, GUIStyle midStyle, GUIStyle lastStyle)
	{
		if (xCount < 2)
		{
			return 0;
		}
		if (xCount != 2)
		{
			int num = Mathf.Max(midStyle.margin.left, midStyle.margin.right);
			return Mathf.Max(firstStyle.margin.right, midStyle.margin.left) + Mathf.Max(midStyle.margin.right, lastStyle.margin.left) + num * (xCount - 3);
		}
		return Mathf.Max(firstStyle.margin.right, lastStyle.margin.left);
	}
}
