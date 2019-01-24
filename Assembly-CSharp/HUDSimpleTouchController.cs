using System;
using UnityEngine;

// Token: 0x0200031A RID: 794
public class HUDSimpleTouchController : MonoBehaviour
{
	// Token: 0x06001639 RID: 5689 RVA: 0x0007BE54 File Offset: 0x0007A054
	private void Start()
	{
		NGUITouchJoystick nguitouchJoystick = this.joystick;
		float left = 0f;
		float top = (float)(Screen.height / 2);
		Rect rect = new Rect(0f, 0f, (float)Screen.width * 0.4f, (float)Screen.height);
		nguitouchJoystick.TouchBoundary = new Rect(left, top, rect.width, (float)(Screen.height / 2));
		this.joystick.OnJoystickMoved = delegate(Vector2 el)
		{
			TouchInput.WishDirection = el;
		};
		this.joystick.OnJoystickStopped = delegate()
		{
			TouchInput.WishDirection = Vector2.zero;
		};
		this.jumpButton.OnPressed = delegate(bool el)
		{
			TouchInput.WishJump = el;
		};
		this.fireButton.OnPressed = delegate(bool el)
		{
			global::EventHandler.Global.Fire(new GlobalEvents.InputChanged(GameInputKey.PrimaryFire, (float)((!el) ? 0 : 1)));
		};
	}

	// Token: 0x04001505 RID: 5381
	[SerializeField]
	private UIEventReceiver jumpButton;

	// Token: 0x04001506 RID: 5382
	[SerializeField]
	private UIEventReceiver fireButton;

	// Token: 0x04001507 RID: 5383
	[SerializeField]
	private NGUITouchJoystick joystick;
}
