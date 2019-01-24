using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public static class RectExtentions
{
	// Token: 0x06001C7C RID: 7292 RVA: 0x00012E75 File Offset: 0x00011075
	public static Rect FullExtends(this Rect r)
	{
		return new Rect(0f, 0f, r.width, r.height);
	}

	// Token: 0x06001C7D RID: 7293 RVA: 0x000901D4 File Offset: 0x0008E3D4
	public static Rect Lerp(this Rect r, Rect target, float time)
	{
		return new Rect(Mathf.Lerp(r.x, target.x, time), Mathf.Lerp(r.y, target.y, time), Mathf.Lerp(r.width, target.width, time), Mathf.Lerp(r.height, target.height, time));
	}

	// Token: 0x06001C7E RID: 7294 RVA: 0x00012E94 File Offset: 0x00011094
	public static Rect Expand(this Rect r, int width, int height)
	{
		return new Rect(r.x, r.y, r.width + (float)width, r.height + (float)height);
	}

	// Token: 0x06001C7F RID: 7295 RVA: 0x00012EBD File Offset: 0x000110BD
	public static Rect Contract(this Rect r, int horizontalBorder, int verticalBorder)
	{
		return new Rect(r.x + (float)horizontalBorder, r.y + (float)verticalBorder, r.width - (float)horizontalBorder * 2f, r.height - (float)verticalBorder * 2f);
	}

	// Token: 0x06001C80 RID: 7296 RVA: 0x00012EF8 File Offset: 0x000110F8
	public static Rect OffsetBy(this Rect r, Vector2 offset)
	{
		return new Rect(r.x + offset.x, r.y + offset.y, r.width, r.height);
	}

	// Token: 0x06001C81 RID: 7297 RVA: 0x00012F2B File Offset: 0x0001112B
	public static Rect OffsetBy(this Rect r, float x, float y)
	{
		return new Rect(r.x + x, r.y + y, r.width, r.height);
	}

	// Token: 0x06001C82 RID: 7298 RVA: 0x00090238 File Offset: 0x0008E438
	public static Rect Add(this Rect r1, Rect r2)
	{
		return new Rect(r1.x + r2.x, r1.y + r2.y, r1.width + r2.width, r1.height + r2.height);
	}

	// Token: 0x06001C83 RID: 7299 RVA: 0x00012F52 File Offset: 0x00011152
	public static Rect Center(this Rect r)
	{
		return new Rect(((float)Screen.width - r.width) * 0.5f, ((float)Screen.height - r.height) * 0.5f, r.width, r.height);
	}

	// Token: 0x06001C84 RID: 7300 RVA: 0x00012F8F File Offset: 0x0001118F
	public static Rect Center(this Rect r, float width, float height)
	{
		return new Rect((r.width - width) * 0.5f, (r.height - height) * 0.5f, width, height);
	}

	// Token: 0x06001C85 RID: 7301 RVA: 0x00012FB6 File Offset: 0x000111B6
	public static Rect CenterHorizontally(this Rect r, float y, float width, float height)
	{
		return new Rect((r.width - width) * 0.5f, y, width, height);
	}

	// Token: 0x06001C86 RID: 7302 RVA: 0x00012FCF File Offset: 0x000111CF
	public static Rect CenterVertically(this Rect r, float x, float width, float height)
	{
		return new Rect(x, (r.height - height) * 0.5f, width, height);
	}

	// Token: 0x06001C87 RID: 7303 RVA: 0x00012FE8 File Offset: 0x000111E8
	public static float HalfWidth(this Rect r)
	{
		return r.width * 0.5f;
	}

	// Token: 0x06001C88 RID: 7304 RVA: 0x00012FF7 File Offset: 0x000111F7
	public static float HalfHeight(this Rect r)
	{
		return r.height * 0.5f;
	}

	// Token: 0x06001C89 RID: 7305 RVA: 0x00090288 File Offset: 0x0008E488
	public static bool ContainsTouch(this Rect rect, Vector2 touchPosition)
	{
		Vector2 point = new Vector2(touchPosition.x, (float)Screen.height - touchPosition.y);
		return rect.Contains(point);
	}
}
