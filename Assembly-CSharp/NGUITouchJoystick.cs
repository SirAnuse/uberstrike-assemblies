using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public class NGUITouchJoystick : MonoBehaviour
{
	// Token: 0x17000535 RID: 1333
	// (set) Token: 0x060015BA RID: 5562 RVA: 0x0000E8BB File Offset: 0x0000CABB
	public Rect TouchBoundary
	{
		set
		{
			this.touchBoundary = value;
			this.boundary = this.touchBoundary;
		}
	}

	// Token: 0x060015BB RID: 5563 RVA: 0x0000E8D0 File Offset: 0x0000CAD0
	private void Awake()
	{
		this.boundary = this.touchBoundary;
	}

	// Token: 0x060015BC RID: 5564 RVA: 0x00079A8C File Offset: 0x00077C8C
	private void Update()
	{
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began && this.boundary.ContainsTouch(touch.position) && this.finger.FingerId == -1)
			{
				this.finger = new TouchFinger
				{
					StartPos = new Vector2(touch.position.x, touch.position.y),
					StartTouchTime = Time.time,
					FingerId = touch.fingerId
				};
				this.joystickBoundary = new Rect(touch.position.x - this.joystickLimits.x / 2f, touch.position.y - this.joystickLimits.y / 2f, this.joystickLimits.x, this.joystickLimits.y);
				Vector3 localPosition = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, UICamera.currentCamera.nearClipPlane));
				localPosition = this.backgroundContainer.transform.parent.InverseTransformPoint(new Vector3(localPosition.x, localPosition.y, 0f));
				this.backgroundContainer.transform.localPosition = localPosition;
				this.movingStick.transform.localPosition = localPosition;
				this.ShowJoystick(true);
			}
			else if (this.finger.FingerId == touch.fingerId)
			{
				if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
				{
					this.joystickPosition.x = Mathf.Clamp(touch.position.x, this.joystickBoundary.x, this.joystickBoundary.x + this.joystickBoundary.width);
					this.joystickPosition.y = Mathf.Clamp(touch.position.y, this.joystickBoundary.y, this.joystickBoundary.y + this.joystickBoundary.height);
					Vector3 position = new Vector3(this.joystickPosition.x, this.joystickPosition.y, 0f);
					position = UICamera.currentCamera.ScreenToWorldPoint(position);
					this.movingStick.transform.localPosition = this.backgroundContainer.transform.parent.InverseTransformPoint(position);
					Vector2 vector = Vector2.zero;
					vector.x = (this.joystickPosition.x - this.finger.StartPos.x) * 2f / this.joystickBoundary.width;
					vector.y = (this.joystickPosition.y - this.finger.StartPos.y) * 2f / this.joystickBoundary.height;
					vector *= ApplicationDataManager.ApplicationOptions.TouchMoveSensitivity;
					if (touch.phase == TouchPhase.Moved && this.OnJoystickMoved != null)
					{
						this.OnJoystickMoved(vector);
					}
				}
				else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
				{
					this.ShowJoystick(false);
					this.boundary = this.touchBoundary;
					if (this.OnJoystickStopped != null)
					{
						this.OnJoystickStopped();
					}
					this.finger.Reset();
				}
			}
		}
	}

	// Token: 0x060015BD RID: 5565 RVA: 0x0000E8DE File Offset: 0x0000CADE
	private void ShowJoystick(bool show)
	{
		this.movingStick.enabled = show;
		NGUITools.SetActiveChildren(this.backgroundContainer, show);
		NGUITools.SetActiveChildren(this.movingStick.gameObject, show);
	}

	// Token: 0x04001477 RID: 5239
	[SerializeField]
	private GameObject backgroundContainer;

	// Token: 0x04001478 RID: 5240
	[SerializeField]
	private UISprite movingStick;

	// Token: 0x04001479 RID: 5241
	[SerializeField]
	private Vector2 joystickLimits = new Vector2(128f, 128f);

	// Token: 0x0400147A RID: 5242
	[SerializeField]
	private Rect touchBoundary = new Rect(0f, 0f, (float)Screen.width, (float)Screen.height);

	// Token: 0x0400147B RID: 5243
	public Action<Vector2> OnJoystickMoved;

	// Token: 0x0400147C RID: 5244
	public Action OnJoystickStopped;

	// Token: 0x0400147D RID: 5245
	private Rect boundary = default(Rect);

	// Token: 0x0400147E RID: 5246
	private Rect joystickBoundary = default(Rect);

	// Token: 0x0400147F RID: 5247
	private TouchFinger finger = new TouchFinger();

	// Token: 0x04001480 RID: 5248
	private Vector2 joystickPosition = Vector2.zero;
}
