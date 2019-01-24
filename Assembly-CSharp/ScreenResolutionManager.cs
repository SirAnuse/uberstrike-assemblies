using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002DE RID: 734
public static class ScreenResolutionManager
{
	// Token: 0x06001504 RID: 5380 RVA: 0x00076DE0 File Offset: 0x00074FE0
	static ScreenResolutionManager()
	{
		foreach (Resolution item in Screen.resolutions)
		{
			if (item.width > 800)
			{
				ScreenResolutionManager.resolutions.Add(item);
			}
		}
		if (ScreenResolutionManager.resolutions.Count == 0)
		{
			ScreenResolutionManager.resolutions.Add(Screen.currentResolution);
		}
	}

	// Token: 0x1700050A RID: 1290
	// (get) Token: 0x06001505 RID: 5381 RVA: 0x0000E18F File Offset: 0x0000C38F
	private static bool IsHighestResolution
	{
		get
		{
			return ScreenResolutionManager.CurrentResolutionIndex == ScreenResolutionManager.resolutions.Count - 1;
		}
	}

	// Token: 0x1700050B RID: 1291
	// (get) Token: 0x06001506 RID: 5382 RVA: 0x0000E1A4 File Offset: 0x0000C3A4
	public static List<Resolution> Resolutions
	{
		get
		{
			return ScreenResolutionManager.resolutions;
		}
	}

	// Token: 0x1700050C RID: 1292
	// (get) Token: 0x06001507 RID: 5383 RVA: 0x0000E1AB File Offset: 0x0000C3AB
	public static int InitialResolutionIndex
	{
		get
		{
			return ScreenResolutionManager.resolutions.Count - 1;
		}
	}

	// Token: 0x1700050D RID: 1293
	// (get) Token: 0x06001508 RID: 5384 RVA: 0x0000E1B9 File Offset: 0x0000C3B9
	public static int CurrentResolutionIndex
	{
		get
		{
			return ScreenResolutionManager.resolutions.FindIndex((Resolution r) => r.width == Screen.width && r.height == Screen.height);
		}
	}

	// Token: 0x1700050E RID: 1294
	// (get) Token: 0x06001509 RID: 5385 RVA: 0x00007E15 File Offset: 0x00006015
	// (set) Token: 0x0600150A RID: 5386 RVA: 0x00076E58 File Offset: 0x00075058
	public static bool IsFullScreen
	{
		get
		{
			return Screen.fullScreen;
		}
		set
		{
			if (!Application.isWebPlayer && !value && ScreenResolutionManager.IsHighestResolution)
			{
				ScreenResolutionManager.SetTwoMinusMaxResolution();
			}
			else
			{
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, value);
			}
			ApplicationDataManager.ApplicationOptions.IsFullscreen = value;
			ApplicationDataManager.ApplicationOptions.SaveApplicationOptions();
		}
	}

	// Token: 0x0600150B RID: 5387 RVA: 0x00076EC0 File Offset: 0x000750C0
	public static void SetResolution(int index, bool fullscreen)
	{
		int num = ScreenResolutionManager.resolutions.Count - 1;
		int num2 = Mathf.Clamp(index, 0, num);
		if (!Application.isWebPlayer && num2 == num && !fullscreen)
		{
			fullscreen = true;
		}
		if (num2 >= 0 && num2 < ScreenResolutionManager.resolutions.Count)
		{
			Screen.SetResolution(ScreenResolutionManager.resolutions[num2].width, ScreenResolutionManager.resolutions[num2].height, fullscreen);
			ApplicationDataManager.ApplicationOptions.ScreenResolution = num2;
		}
	}

	// Token: 0x0600150C RID: 5388 RVA: 0x00076F4C File Offset: 0x0007514C
	public static void SetTwoMinusMaxResolution()
	{
		if (Application.isWebPlayer)
		{
			Debug.LogError("SetOneMinusMaxResolution() should only be called from the desktop client");
			return;
		}
		if (ScreenResolutionManager.resolutions.Count > 2)
		{
			Vector2 vector = new Vector2((float)ScreenResolutionManager.resolutions[ScreenResolutionManager.resolutions.Count - 3].width, (float)ScreenResolutionManager.resolutions[ScreenResolutionManager.resolutions.Count - 3].height);
			Screen.SetResolution((int)vector.x, (int)vector.y, false);
		}
		else if (ScreenResolutionManager.resolutions.Count == 2)
		{
			Vector2 vector2 = new Vector2((float)ScreenResolutionManager.resolutions[1].width, (float)ScreenResolutionManager.resolutions[1].height);
			Screen.SetResolution((int)vector2.x, (int)vector2.y, false);
		}
		else if (ScreenResolutionManager.resolutions.Count == 1)
		{
			Vector2 vector3 = new Vector2((float)ScreenResolutionManager.resolutions[0].width, (float)ScreenResolutionManager.resolutions[0].height);
			Screen.SetResolution((int)vector3.x, (int)vector3.y, false);
		}
		else
		{
			Debug.LogError("ScreenResolutionManager: Screen.resolutions does not contain any supported resolutions.");
		}
	}

	// Token: 0x0600150D RID: 5389 RVA: 0x000770A4 File Offset: 0x000752A4
	public static void SetFullScreenMaxResolution()
	{
		if (ScreenResolutionManager.resolutions.Count == 0)
		{
			Debug.LogError("SetFullScreenMaxResolution: No suitable resolution available in the Resolutions array.");
			return;
		}
		int num = ScreenResolutionManager.resolutions.Count - 1;
		Vector2 vector = new Vector2((float)ScreenResolutionManager.resolutions[num].width, (float)ScreenResolutionManager.resolutions[num].height);
		if (!Screen.fullScreen)
		{
			Screen.SetResolution((int)vector.x, (int)vector.y, true);
			ApplicationDataManager.ApplicationOptions.ScreenResolution = num;
		}
	}

	// Token: 0x0600150E RID: 5390 RVA: 0x0000E1E2 File Offset: 0x0000C3E2
	public static void DecreaseResolution()
	{
		ScreenResolutionManager.SetResolution(ScreenResolutionManager.CurrentResolutionIndex - 1, Screen.fullScreen);
	}

	// Token: 0x0600150F RID: 5391 RVA: 0x0000E1F5 File Offset: 0x0000C3F5
	public static void IncreaseResolution()
	{
		ScreenResolutionManager.SetResolution(ScreenResolutionManager.CurrentResolutionIndex + 1, Screen.fullScreen);
	}

	// Token: 0x040013D9 RID: 5081
	private static List<Resolution> resolutions = new List<Resolution>();
}
