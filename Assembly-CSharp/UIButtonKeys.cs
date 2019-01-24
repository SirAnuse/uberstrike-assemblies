using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
[RequireComponent(typeof(Collider))]
[AddComponentMenu("NGUI/Interaction/Button Keys")]
public class UIButtonKeys : MonoBehaviour
{
	// Token: 0x0600003F RID: 63 RVA: 0x000023A4 File Offset: 0x000005A4
	private void Start()
	{
		if (this.startsSelected && (UICamera.selectedObject == null || !NGUITools.GetActive(UICamera.selectedObject)))
		{
			UICamera.selectedObject = base.gameObject;
		}
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00016490 File Offset: 0x00014690
	private void OnKey(KeyCode key)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			switch (key)
			{
			case KeyCode.UpArrow:
				if (this.selectOnUp != null)
				{
					UICamera.selectedObject = this.selectOnUp.gameObject;
				}
				break;
			case KeyCode.DownArrow:
				if (this.selectOnDown != null)
				{
					UICamera.selectedObject = this.selectOnDown.gameObject;
				}
				break;
			case KeyCode.RightArrow:
				if (this.selectOnRight != null)
				{
					UICamera.selectedObject = this.selectOnRight.gameObject;
				}
				break;
			case KeyCode.LeftArrow:
				if (this.selectOnLeft != null)
				{
					UICamera.selectedObject = this.selectOnLeft.gameObject;
				}
				break;
			default:
				if (key == KeyCode.Tab)
				{
					if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
					{
						if (this.selectOnLeft != null)
						{
							UICamera.selectedObject = this.selectOnLeft.gameObject;
						}
						else if (this.selectOnUp != null)
						{
							UICamera.selectedObject = this.selectOnUp.gameObject;
						}
						else if (this.selectOnDown != null)
						{
							UICamera.selectedObject = this.selectOnDown.gameObject;
						}
						else if (this.selectOnRight != null)
						{
							UICamera.selectedObject = this.selectOnRight.gameObject;
						}
					}
					else if (this.selectOnRight != null)
					{
						UICamera.selectedObject = this.selectOnRight.gameObject;
					}
					else if (this.selectOnDown != null)
					{
						UICamera.selectedObject = this.selectOnDown.gameObject;
					}
					else if (this.selectOnUp != null)
					{
						UICamera.selectedObject = this.selectOnUp.gameObject;
					}
					else if (this.selectOnLeft != null)
					{
						UICamera.selectedObject = this.selectOnLeft.gameObject;
					}
				}
				break;
			}
		}
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000023DB File Offset: 0x000005DB
	private void OnClick()
	{
		if (base.enabled && this.selectOnClick != null)
		{
			UICamera.selectedObject = this.selectOnClick.gameObject;
		}
	}

	// Token: 0x04000049 RID: 73
	public bool startsSelected;

	// Token: 0x0400004A RID: 74
	public UIButtonKeys selectOnClick;

	// Token: 0x0400004B RID: 75
	public UIButtonKeys selectOnUp;

	// Token: 0x0400004C RID: 76
	public UIButtonKeys selectOnDown;

	// Token: 0x0400004D RID: 77
	public UIButtonKeys selectOnLeft;

	// Token: 0x0400004E RID: 78
	public UIButtonKeys selectOnRight;
}
