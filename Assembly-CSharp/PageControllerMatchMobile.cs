using System;
using UnityEngine;

// Token: 0x0200031E RID: 798
public class PageControllerMatchMobile : PageControllerBase
{
	// Token: 0x06001650 RID: 5712 RVA: 0x0000F0A1 File Offset: 0x0000D2A1
	private void Start()
	{
		GameData.Instance.PlayerState.AddEventAndFire(delegate(PlayerStateId el)
		{
			PageControllerMatch.HandleSharedViews(el, this.healthBar, this.ammoBar, this.armorBar, this.hudReticleController, this.hudStatusPanel, this.itemPickup);
			bool flag = el == PlayerStateId.Playing;
			bool flag2 = el == PlayerStateId.PrepareForMatch;
			this.hudMobileWeaponSelector.gameObject.SetActive(flag || flag2);
			this.hudMobileQuickItems.SetActive(flag || flag2);
			this.weaponFeedback.SetActive(flag || flag2);
		}, this);
		TouchInput.OnSecondaryFire.AddEvent(delegate(bool el)
		{
			this.hudMobileWeaponSelector.Show(!el);
			this.hudMobileQuickItems.SetActive(!el);
		}, this);
	}

	// Token: 0x04001520 RID: 5408
	[SerializeField]
	private GameObject healthBar;

	// Token: 0x04001521 RID: 5409
	[SerializeField]
	private GameObject ammoBar;

	// Token: 0x04001522 RID: 5410
	[SerializeField]
	private GameObject armorBar;

	// Token: 0x04001523 RID: 5411
	[SerializeField]
	private GameObject hudReticleController;

	// Token: 0x04001524 RID: 5412
	[SerializeField]
	private GameObject hudStatusPanel;

	// Token: 0x04001525 RID: 5413
	[SerializeField]
	private HUDMobileWeaponSelector hudMobileWeaponSelector;

	// Token: 0x04001526 RID: 5414
	[SerializeField]
	private GameObject hudMobileChatEventStream;

	// Token: 0x04001527 RID: 5415
	[SerializeField]
	private GameObject hudMobileQuickItems;

	// Token: 0x04001528 RID: 5416
	[SerializeField]
	private GameObject weaponFeedback;

	// Token: 0x04001529 RID: 5417
	[SerializeField]
	private GameObject itemPickup;
}
