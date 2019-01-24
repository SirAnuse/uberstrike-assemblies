using System;
using UnityEngine;

// Token: 0x0200030F RID: 783
public class HUDMobileButtons : MonoBehaviour
{
	// Token: 0x060015F9 RID: 5625 RVA: 0x0007AC84 File Offset: 0x00078E84
	private void Start()
	{
		this.simpleInputButton.gameObject.SetActive(false);
		this.multitouchButton.gameObject.SetActive(false);
		GameData.Instance.PlayerState.AddEventAndFire(delegate(PlayerStateId el)
		{
			bool flag = el == PlayerStateId.Paused;
			this.simpleInputButton.gameObject.SetActive(flag && TouchInput.UseMultiTouch);
			this.multitouchButton.gameObject.SetActive(flag && !TouchInput.UseMultiTouch);
		}, this);
		TouchInput.UseMultiTouch.AddEvent(delegate(bool el)
		{
			this.simpleInputButton.gameObject.SetActive(el);
			this.multitouchButton.gameObject.SetActive(!el);
		}, this);
		this.simpleInputButton.OnRelease = delegate()
		{
			ApplicationDataManager.ApplicationOptions.UseMultiTouch = false;
			ApplicationDataManager.ApplicationOptions.SaveApplicationOptions();
		};
		this.multitouchButton.OnRelease = delegate()
		{
			ApplicationDataManager.ApplicationOptions.UseMultiTouch = true;
			ApplicationDataManager.ApplicationOptions.SaveApplicationOptions();
		};
	}

	// Token: 0x040014BB RID: 5307
	[SerializeField]
	private UIButton simpleInputButton;

	// Token: 0x040014BC RID: 5308
	[SerializeField]
	private UIButton multitouchButton;
}
