using System;
using UnityEngine;

// Token: 0x020000C0 RID: 192
public class CameraRectController : AutoMonoBehaviour<CameraRectController>
{
	// Token: 0x06000726 RID: 1830 RVA: 0x00031EE0 File Offset: 0x000300E0
	private void LateUpdate()
	{
		if ((float)Screen.width != this.screenSize.x || (float)Screen.height != this.screenSize.y)
		{
			this.screenSize.x = (float)Screen.width;
			this.screenSize.y = (float)Screen.height;
			global::EventHandler.Global.Fire(new GlobalEvents.ScreenResolutionChanged());
		}
		if (GameState.Current.Map != null && GameState.Current.Map.Camera != null && GameState.Current.Map.Camera.pixelWidth != this.lastWidth)
		{
			this.lastWidth = GameState.Current.Map.Camera.pixelWidth;
			global::EventHandler.Global.Fire(new GlobalEvents.CameraWidthChanged());
		}
	}

	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06000727 RID: 1831 RVA: 0x00031FC4 File Offset: 0x000301C4
	public float PixelWidth
	{
		get
		{
			if (GameState.Current.Map != null && GameState.Current.Map.Camera != null)
			{
				return GameState.Current.Map.Camera.pixelWidth;
			}
			return (float)Screen.width;
		}
	}

	// Token: 0x17000220 RID: 544
	// (get) Token: 0x06000728 RID: 1832 RVA: 0x000067CA File Offset: 0x000049CA
	public float NormalizedWidth
	{
		get
		{
			return this.PixelWidth / (float)Screen.width;
		}
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x000067D9 File Offset: 0x000049D9
	public void SetAbsoluteWidth(float width)
	{
		this.SetNormalizedWidth(width / (float)Screen.width);
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x0003201C File Offset: 0x0003021C
	public void SetNormalizedWidth(float width)
	{
		width = Mathf.Clamp(width, 0f, 1f);
		if (GameState.Current.Map != null && GameState.Current.Map.Camera != null && this.lastWidth != width)
		{
			GameState.Current.Map.Camera.rect = new Rect(0f, 0f, width, 1f);
		}
	}

	// Token: 0x04000628 RID: 1576
	private float lastWidth = 1f;

	// Token: 0x04000629 RID: 1577
	private Vector2 screenSize;
}
