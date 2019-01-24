using System;
using UnityEngine;

// Token: 0x02000150 RID: 336
public static class GuiCircle
{
	// Token: 0x060008ED RID: 2285 RVA: 0x00007941 File Offset: 0x00005B41
	public static void DrawArc(Vector2 position, float angle, float radius, Material material)
	{
		GuiCircle.DrawArc(position, 0f, angle, radius, material, GuiCircle.Direction.Clockwise);
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x00039250 File Offset: 0x00037450
	public static void DrawArc(Vector2 position, float startAngle, float fillAngle, float radius, Material material, GuiCircle.Direction dir)
	{
		if (Event.current.type == EventType.Repaint)
		{
			GL.PushMatrix();
			material.SetPass(0);
			GuiCircle.DrawSolidArc(new Vector3(position.x, position.y, 0f), fillAngle, radius, Quaternion.Euler(0f, 0f, startAngle), dir);
			GL.PopMatrix();
		}
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x000392B4 File Offset: 0x000374B4
	private static void DrawSolidArc(Vector3 center, float angle, float radius, Quaternion rot, GuiCircle.Direction dir)
	{
		Vector3 a = rot * Vector3.down;
		int num = (int)Mathf.Clamp(angle * 0.1f, 5f, 30f);
		float num2 = 1f / (float)(num - 1);
		Quaternion rotation = Quaternion.AngleAxis(angle * num2, (dir != GuiCircle.Direction.Clockwise) ? (-GuiCircle.Normal) : GuiCircle.Normal);
		Vector3 vector = a * radius;
		float num3 = 1f / (2f * radius);
		Vector3 b = new Vector3(num3, -num3, num3);
		GL.Begin(4);
		for (int i = 0; i < num - 1; i++)
		{
			Vector3 vector2 = vector;
			vector = rotation * vector;
			GL.TexCoord(GuiCircle.TexShift);
			GL.Vertex(center);
			if (dir == GuiCircle.Direction.Clockwise)
			{
				GL.TexCoord(GuiCircle.TexShift + rot * Vector3.Scale(vector2, b));
				GL.Vertex(center + vector2);
				GL.TexCoord(GuiCircle.TexShift + rot * Vector3.Scale(vector, b));
				GL.Vertex(center + vector);
			}
			else
			{
				GL.TexCoord(GuiCircle.TexShift + rot * Vector3.Scale(vector, b));
				GL.Vertex(center + vector);
				GL.TexCoord(GuiCircle.TexShift + rot * Vector3.Scale(vector2, b));
				GL.Vertex(center + vector2);
			}
		}
		GL.End();
	}

	// Token: 0x060008F0 RID: 2288 RVA: 0x00039434 File Offset: 0x00037634
	public static void DrawArcLine(Vector2 position, float startAngle, float fillAngle, float radius, float width, Material material, GuiCircle.Direction dir)
	{
		if (Event.current.type == EventType.Repaint)
		{
			material.SetPass(0);
			GuiCircle.DrawSolidArc(new Vector3(position.x, position.y, 0f), fillAngle, radius, width, Quaternion.Euler(0f, 0f, startAngle) * Vector3.down, dir);
		}
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x00039498 File Offset: 0x00037698
	private static void DrawSolidArc(Vector3 center, float angle, float radius, float width, Vector3 from, GuiCircle.Direction dir)
	{
		if (radius > 0f)
		{
			int num = (int)Mathf.Clamp(angle * 0.1f, 5f, 30f);
			float num2 = 1f / (float)(num - 1);
			float d = 1f - Mathf.Clamp(width / radius, 0.001f, 1f);
			Quaternion rotation = Quaternion.AngleAxis(angle * num2, (dir != GuiCircle.Direction.Clockwise) ? (-GuiCircle.Normal) : GuiCircle.Normal);
			Vector3 vector = from * radius;
			GL.Begin(7);
			for (int i = 0; i < num - 1; i++)
			{
				Vector3 vector2 = vector;
				vector = rotation * vector;
				if (dir == GuiCircle.Direction.Clockwise)
				{
					GL.Vertex(center + vector2);
					GL.Vertex(center + vector);
					GL.Vertex(center + vector * d);
					GL.Vertex(center + vector2 * d);
				}
				else
				{
					GL.Vertex(center + vector);
					GL.Vertex(center + vector2);
					GL.Vertex(center + vector2 * d);
					GL.Vertex(center + vector * d);
				}
			}
			GL.End();
		}
	}

	// Token: 0x0400092C RID: 2348
	private static Vector3 TexShift = new Vector3(0.5f, 0.5f, 0.5f);

	// Token: 0x0400092D RID: 2349
	private static Vector3 Normal = new Vector3(0f, 0f, 1f);

	// Token: 0x02000151 RID: 337
	public enum Direction
	{
		// Token: 0x0400092F RID: 2351
		Clockwise,
		// Token: 0x04000930 RID: 2352
		CounterClockwise
	}
}
