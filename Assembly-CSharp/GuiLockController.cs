using System;
using UnityEngine;

// Token: 0x02000152 RID: 338
public class GuiLockController : AutoMonoBehaviour<GuiLockController>
{
	// Token: 0x060008F3 RID: 2291 RVA: 0x0000795A File Offset: 0x00005B5A
	private void Awake()
	{
		base.enabled = false;
		GuiLockController.Alpha = 0.6f;
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x0000796D File Offset: 0x00005B6D
	public static void LockApplication()
	{
		GuiLockController.IsApplicationLocked = true;
		GuiLockController.LockingDepth = GuiDepth.Popup;
		AutoMonoBehaviour<GuiLockController>.Instance.enabled = true;
		GuiLockController.EnableNguiControls(false);
	}

	// Token: 0x17000287 RID: 647
	// (get) Token: 0x060008F5 RID: 2293 RVA: 0x0000798C File Offset: 0x00005B8C
	// (set) Token: 0x060008F6 RID: 2294 RVA: 0x00007993 File Offset: 0x00005B93
	public static bool IsApplicationLocked { get; private set; }

	// Token: 0x17000288 RID: 648
	// (get) Token: 0x060008F7 RID: 2295 RVA: 0x0000799B File Offset: 0x00005B9B
	// (set) Token: 0x060008F8 RID: 2296 RVA: 0x000079A2 File Offset: 0x00005BA2
	public static float Alpha { get; private set; }

	// Token: 0x17000289 RID: 649
	// (get) Token: 0x060008F9 RID: 2297 RVA: 0x000079AA File Offset: 0x00005BAA
	// (set) Token: 0x060008FA RID: 2298 RVA: 0x000079B1 File Offset: 0x00005BB1
	public static GuiDepth LockingDepth { get; private set; }

	// Token: 0x1700028A RID: 650
	// (get) Token: 0x060008FB RID: 2299 RVA: 0x000079B9 File Offset: 0x00005BB9
	// (set) Token: 0x060008FC RID: 2300 RVA: 0x000079C0 File Offset: 0x00005BC0
	public static bool IsEnabled { get; private set; }

	// Token: 0x060008FD RID: 2301 RVA: 0x000079C8 File Offset: 0x00005BC8
	public static bool IsLocked(params GuiDepth[] levels)
	{
		if (GuiLockController.IsEnabled)
		{
			return Array.Exists<GuiDepth>(levels, (GuiDepth l) => l == GuiLockController.LockingDepth);
		}
		return false;
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x000395D8 File Offset: 0x000377D8
	public static void EnableLock(GuiDepth depth)
	{
		if (GuiLockController.IsApplicationLocked)
		{
			return;
		}
		if (!GuiLockController.IsEnabled || GuiLockController.LockingDepth > depth)
		{
			GuiLockController.LockingDepth = depth;
			GuiLockController.IsEnabled = true;
			AutoMonoBehaviour<GuiLockController>.Instance.enabled = GuiLockController.IsEnabled;
			GuiLockController.EnableNguiControls(false);
		}
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000079F9 File Offset: 0x00005BF9
	public static void ReleaseLock(GuiDepth depth)
	{
		if (GuiLockController.IsApplicationLocked)
		{
			return;
		}
		if (GuiLockController.IsEnabled && GuiLockController.LockingDepth == depth)
		{
			GuiLockController.IsEnabled = false;
			AutoMonoBehaviour<GuiLockController>.Instance.enabled = GuiLockController.IsEnabled;
			GuiLockController.EnableNguiControls(true);
		}
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x00039628 File Offset: 0x00037828
	private static void EnableNguiControls(bool enable)
	{
		if (UICamera.eventHandler)
		{
			if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
			{
				UICamera.eventHandler.useTouch = enable;
			}
			else if (Application.platform == RuntimePlatform.PS3 || Application.platform == RuntimePlatform.XBOX360)
			{
				UICamera.eventHandler.useController = enable;
			}
			else
			{
				UICamera.eventHandler.useMouse = enable;
				UICamera.eventHandler.useKeyboard = enable;
			}
		}
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x000396AC File Offset: 0x000378AC
	private void OnGUI()
	{
		GUI.depth = (int)(GuiLockController.LockingDepth + 1);
		if (Event.current.type == EventType.MouseDown || Event.current.type == EventType.MouseUp)
		{
			Event.current.Use();
		}
		GUI.color = new Color(1f, 1f, 1f, GuiLockController.Alpha);
		GUI.Button(new Rect(0f, 0f, (float)(Screen.width + 5), (float)(Screen.height + 5)), string.Empty, BlueStonez.box_grey31);
		GUI.color = Color.white;
	}
}
