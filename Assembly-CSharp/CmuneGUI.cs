using System;
using UnityEngine;

// Token: 0x020000DC RID: 220
public static class CmuneGUI
{
	// Token: 0x060007B6 RID: 1974 RVA: 0x00035344 File Offset: 0x00033544
	public static int HorizontalScrollbar(string title, int value, int min, int max)
	{
		float num = (float)value;
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label(title, new GUILayoutOption[0]);
		GUILayout.Space(10f);
		num = GUILayout.HorizontalScrollbar((float)value, 1f, (float)min, (float)(max + 1), new GUILayoutOption[0]);
		GUILayout.Space(10f);
		GUILayout.Label(string.Format("{0} [{1},{2}]", value, min, max), new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
		return (int)num;
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x000353C8 File Offset: 0x000335C8
	public static float HorizontalScrollbar(string title, float value, int min, int max)
	{
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUILayout.Label(title, new GUILayoutOption[0]);
		GUILayout.Space(10f);
		float result = GUILayout.HorizontalScrollbar(value, 1f, (float)min, (float)(max + 1), new GUILayoutOption[0]);
		GUILayout.Space(10f);
		GUILayout.Label(string.Format("{0} [{1},{2}]", value, min, max), new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
		return result;
	}
}
