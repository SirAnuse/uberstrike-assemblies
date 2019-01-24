using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
[AddComponentMenu("NGUI/Interaction/Checkbox Controlled Component")]
public class UICheckboxControlledComponent : MonoBehaviour
{
	// Token: 0x06000086 RID: 134 RVA: 0x000178E0 File Offset: 0x00015AE0
	private void Start()
	{
		UICheckbox component = base.GetComponent<UICheckbox>();
		if (component != null)
		{
			this.mUsingDelegates = true;
			UICheckbox uicheckbox = component;
			uicheckbox.onStateChange = (UICheckbox.OnStateChange)Delegate.Combine(uicheckbox.onStateChange, new UICheckbox.OnStateChange(this.OnActivateDelegate));
		}
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000027E2 File Offset: 0x000009E2
	private void OnActivateDelegate(bool isActive)
	{
		if (base.enabled && this.target != null)
		{
			this.target.enabled = ((!this.inverse) ? isActive : (!isActive));
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00002820 File Offset: 0x00000A20
	private void OnActivate(bool isActive)
	{
		if (!this.mUsingDelegates)
		{
			this.OnActivateDelegate(isActive);
		}
	}

	// Token: 0x040000A8 RID: 168
	public MonoBehaviour target;

	// Token: 0x040000A9 RID: 169
	public bool inverse;

	// Token: 0x040000AA RID: 170
	private bool mUsingDelegates;
}
