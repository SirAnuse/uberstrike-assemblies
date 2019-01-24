using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x020002E9 RID: 745
public static class UserInput
{
	// Token: 0x06001556 RID: 5462 RVA: 0x0000E44F File Offset: 0x0000C64F
	static UserInput()
	{
		UserInput.Reset();
	}

	// Token: 0x06001557 RID: 5463 RVA: 0x0000E474 File Offset: 0x0000C674
	public static void Reset()
	{
		UserInput.Mouse = new Vector2(0f, 0f);
		UserInput.VerticalDirection = Vector3.zero;
		UserInput.HorizontalDirection = Vector3.zero;
	}

	// Token: 0x06001558 RID: 5464 RVA: 0x000780A8 File Offset: 0x000762A8
	public static void UpdateDirections()
	{
		UserInput.ResetDirection();
		if ((byte)(GameState.Current.PlayerData.KeyState & KeyState.Left) != 0)
		{
			UserInput.HorizontalDirection.x = UserInput.HorizontalDirection.x - 127f;
		}
		if ((byte)(GameState.Current.PlayerData.KeyState & KeyState.Right) != 0)
		{
			UserInput.HorizontalDirection.x = UserInput.HorizontalDirection.x + 127f;
		}
		if ((byte)(GameState.Current.PlayerData.KeyState & KeyState.Forward) != 0)
		{
			UserInput.HorizontalDirection.z = UserInput.HorizontalDirection.z + 127f;
		}
		if ((byte)(GameState.Current.PlayerData.KeyState & KeyState.Backward) != 0)
		{
			UserInput.HorizontalDirection.z = UserInput.HorizontalDirection.z - 127f;
		}
		if ((byte)(GameState.Current.PlayerData.KeyState & KeyState.Jump) != 0)
		{
			UserInput.VerticalDirection.y = UserInput.VerticalDirection.y + 127f;
		}
		if ((byte)(GameState.Current.PlayerData.KeyState & KeyState.Crouch) != 0)
		{
			UserInput.VerticalDirection.y = UserInput.VerticalDirection.y - 127f;
		}
		UserInput.HorizontalDirection.Normalize();
		UserInput.VerticalDirection.Normalize();
	}

	// Token: 0x06001559 RID: 5465 RVA: 0x0000E49E File Offset: 0x0000C69E
	public static void ResetDirection()
	{
		UserInput.HorizontalDirection = Vector3.zero;
		UserInput.VerticalDirection = Vector3.zero;
	}

	// Token: 0x0600155A RID: 5466 RVA: 0x000781E0 File Offset: 0x000763E0
	public static KeyState GetkeyState(GameInputKey slot)
	{
		switch (slot)
		{
		case GameInputKey.Forward:
			return KeyState.Forward;
		case GameInputKey.Backward:
			return KeyState.Backward;
		case GameInputKey.Left:
			return KeyState.Left;
		case GameInputKey.Right:
			return KeyState.Right;
		case GameInputKey.Jump:
			return KeyState.Jump;
		case GameInputKey.Crouch:
			return KeyState.Crouch;
		default:
			return KeyState.Still;
		}
	}

	// Token: 0x0600155B RID: 5467 RVA: 0x0000E4B4 File Offset: 0x0000C6B4
	public static void SetRotation(float hAngle = 0f, float vAngle = 0f)
	{
		UserInput.Mouse = new Vector2(hAngle, -vAngle);
		UserInput.UpdateMouse();
		UserInput.UpdateDirections();
	}

	// Token: 0x0600155C RID: 5468 RVA: 0x00078224 File Offset: 0x00076424
	public static void UpdateMouse()
	{
		if (Camera.main != null)
		{
			float num = Mathf.Pow(Camera.main.fieldOfView / ApplicationDataManager.ApplicationOptions.CameraFovMax, 1.1f);
			UserInput.Mouse.x = UserInput.Mouse.x + AutoMonoBehaviour<InputManager>.Instance.RawValue(GameInputKey.HorizontalLook) * ApplicationDataManager.ApplicationOptions.InputXMouseSensitivity * num;
			UserInput.Mouse.x = UserInput.ClampAngle(UserInput.Mouse.x, -360f, 360f);
			int num2 = (!ApplicationDataManager.ApplicationOptions.InputInvertMouse) ? 1 : -1;
			UserInput.Mouse.y = UserInput.Mouse.y + AutoMonoBehaviour<InputManager>.Instance.RawValue(GameInputKey.VerticalLook) * ApplicationDataManager.ApplicationOptions.InputXMouseSensitivity * (float)num2 * num;
			UserInput.Mouse.y = UserInput.ClampAngle(UserInput.Mouse.y, -88f, 88f);
		}
	}

	// Token: 0x0600155D RID: 5469 RVA: 0x0000E4CD File Offset: 0x0000C6CD
	public static bool IsPressed(KeyState k)
	{
		return (byte)(GameState.Current.PlayerData.KeyState & k) != 0;
	}

	// Token: 0x17000519 RID: 1305
	// (get) Token: 0x0600155E RID: 5470 RVA: 0x00078314 File Offset: 0x00076514
	public static bool IsWalking
	{
		get
		{
			return (byte)(GameState.Current.PlayerData.KeyState & KeyState.Walking) != 0 && (byte)(GameState.Current.PlayerData.KeyState ^ KeyState.Horizontal) != 0 && (byte)(GameState.Current.PlayerData.KeyState ^ KeyState.Vertical) != 0;
		}
	}

	// Token: 0x1700051A RID: 1306
	// (get) Token: 0x0600155F RID: 5471 RVA: 0x0000E4E7 File Offset: 0x0000C6E7
	public static bool IsMouseLooking
	{
		get
		{
			return AutoMonoBehaviour<InputManager>.Instance.RawValue(GameInputKey.HorizontalLook) != 0f || AutoMonoBehaviour<InputManager>.Instance.RawValue(GameInputKey.VerticalLook) != 0f;
		}
	}

	// Token: 0x1700051B RID: 1307
	// (get) Token: 0x06001560 RID: 5472 RVA: 0x0000E516 File Offset: 0x0000C716
	public static bool IsMovingVertically
	{
		get
		{
			return (byte)(GameState.Current.PlayerData.KeyState & (KeyState.Jump | KeyState.Crouch)) != 0;
		}
	}

	// Token: 0x1700051C RID: 1308
	// (get) Token: 0x06001561 RID: 5473 RVA: 0x0000E531 File Offset: 0x0000C731
	public static bool IsMovingUp
	{
		get
		{
			return (byte)(GameState.Current.PlayerData.KeyState & KeyState.Jump) != 0;
		}
	}

	// Token: 0x1700051D RID: 1309
	// (get) Token: 0x06001562 RID: 5474 RVA: 0x0000E54C File Offset: 0x0000C74C
	public static bool IsMovingDown
	{
		get
		{
			return (byte)(GameState.Current.PlayerData.KeyState & KeyState.Crouch) != 0;
		}
	}

	// Token: 0x1700051E RID: 1310
	// (get) Token: 0x06001563 RID: 5475 RVA: 0x0000E567 File Offset: 0x0000C767
	public static Quaternion Rotation
	{
		get
		{
			return Quaternion.AngleAxis(UserInput.Mouse.x, Vector3.up) * Quaternion.AngleAxis(UserInput.Mouse.y, Vector3.left);
		}
	}

	// Token: 0x1700051F RID: 1311
	// (get) Token: 0x06001564 RID: 5476 RVA: 0x0000E596 File Offset: 0x0000C796
	public static Quaternion HorizontalRotation
	{
		get
		{
			return Quaternion.AngleAxis(UserInput.Mouse.x, Vector3.up);
		}
	}

	// Token: 0x17000520 RID: 1312
	// (get) Token: 0x06001565 RID: 5477 RVA: 0x0000E5AC File Offset: 0x0000C7AC
	public static Quaternion VerticalRotation
	{
		get
		{
			return Quaternion.AngleAxis(UserInput.Mouse.y, Vector3.left);
		}
	}

	// Token: 0x06001566 RID: 5478 RVA: 0x00006CED File Offset: 0x00004EED
	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x04001408 RID: 5128
	public static float ZoomSpeed = 1f;

	// Token: 0x04001409 RID: 5129
	public static Vector2 TouchLookSensitivity = new Vector2(1f, 0.5f);

	// Token: 0x0400140A RID: 5130
	public static Vector2 Mouse;

	// Token: 0x0400140B RID: 5131
	public static Vector3 VerticalDirection;

	// Token: 0x0400140C RID: 5132
	public static Vector3 HorizontalDirection;
}
