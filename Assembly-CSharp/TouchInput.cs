using System;
using UnityEngine;

// Token: 0x020003B6 RID: 950
public class TouchInput : AutoMonoBehaviour<TouchInput>
{
	// Token: 0x06001BD8 RID: 7128 RVA: 0x00003C87 File Offset: 0x00001E87
	public void EnablePerformanceChecker()
	{
	}

	// Token: 0x06001BD9 RID: 7129 RVA: 0x00003C87 File Offset: 0x00001E87
	public void DisablePerformanceChecker()
	{
	}

	// Token: 0x040018CF RID: 6351
	public static Property<bool> ShowTouchControls = new Property<bool>(false);

	// Token: 0x040018D0 RID: 6352
	public static Property<bool> OnSecondaryFire = new Property<bool>(false);

	// Token: 0x040018D1 RID: 6353
	public static Property<bool> UseMultiTouch = new Property<bool>(true);

	// Token: 0x040018D2 RID: 6354
	public static Vector2 WishLook;

	// Token: 0x040018D3 RID: 6355
	public static Vector2 WishDirection;

	// Token: 0x040018D4 RID: 6356
	public static bool WishJump;

	// Token: 0x040018D5 RID: 6357
	public static bool WishCrouch;

	// Token: 0x040018D6 RID: 6358
	public static bool IsFiring;

	// Token: 0x040018D7 RID: 6359
	public static bool DisableIdleTimer = false;

	// Token: 0x040018D8 RID: 6360
	public TouchShooter Shooter;
}
