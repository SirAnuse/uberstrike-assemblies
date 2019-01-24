using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
[AddComponentMenu("Game/UI/Button Key Binding")]
public class UIButtonKeyBinding : MonoBehaviour
{
	// Token: 0x0600003D RID: 61 RVA: 0x0001641C File Offset: 0x0001461C
	private void Update()
	{
		if (!UICamera.inputHasFocus)
		{
			if (this.keyCode == KeyCode.None)
			{
				return;
			}
			if (Input.GetKeyDown(this.keyCode))
			{
				base.SendMessage("OnPress", true, SendMessageOptions.DontRequireReceiver);
			}
			if (Input.GetKeyUp(this.keyCode))
			{
				base.SendMessage("OnPress", false, SendMessageOptions.DontRequireReceiver);
				base.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	// Token: 0x04000048 RID: 72
	public KeyCode keyCode;
}
