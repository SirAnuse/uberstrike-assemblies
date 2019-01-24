using System;
using UnityEngine;

// Token: 0x02000166 RID: 358
public static class GuiManager
{
	// Token: 0x0600098A RID: 2442 RVA: 0x0003C064 File Offset: 0x0003A264
	public static void DrawTooltip()
	{
		if (!string.IsNullOrEmpty(GUI.tooltip))
		{
			Matrix4x4 matrix = GUI.matrix;
			GUI.matrix = Matrix4x4.identity;
			Vector2 vector = BlueStonez.tooltip.CalcSize(new GUIContent(GUI.tooltip));
			Rect position = new Rect(Mathf.Clamp(Event.current.mousePosition.x, 14f, (float)Screen.width - (vector.x + 14f)), Event.current.mousePosition.y + 24f, vector.x, vector.y + 16f);
			if (position.yMax > (float)Screen.height)
			{
				position.x += 30f;
				position.y += (float)Screen.height - position.yMax;
			}
			if (position.xMax > (float)Screen.width)
			{
				position.x += (float)Screen.width - position.xMax;
			}
			GUI.Label(position, GUI.tooltip, BlueStonez.tooltip);
			GUI.matrix = matrix;
		}
	}
}
