using System;
using UnityEngine;

// Token: 0x0200041D RID: 1053
public static class WaitingTexture
{
	// Token: 0x06001DC8 RID: 7624 RVA: 0x000939D8 File Offset: 0x00091BD8
	public static void Draw(Vector2 position, int size = 0)
	{
		if (size <= 0)
		{
			size = 32;
		}
		else
		{
			size = Mathf.Clamp(size, 1, 32);
		}
		GUIUtility.RotateAroundPivot((float)WaitingTexture.Angle, position);
		GUI.DrawTexture(new Rect(position.x - (float)size * 0.5f, position.y - (float)size * 0.5f, (float)size, (float)size), UberstrikeIcons.Waiting);
		GUI.matrix = Matrix4x4.identity;
	}

	// Token: 0x17000672 RID: 1650
	// (get) Token: 0x06001DC9 RID: 7625 RVA: 0x00013C4D File Offset: 0x00011E4D
	public static int Angle
	{
		get
		{
			return Mathf.RoundToInt(Time.time * 10f) * 30;
		}
	}
}
