using System;
using UnityEngine;

// Token: 0x02000431 RID: 1073
public class MuzzleLight : BaseWeaponEffect
{
	// Token: 0x06001E8F RID: 7823 RVA: 0x00014341 File Offset: 0x00012541
	private void Awake()
	{
		this._shootAnimation = base.GetComponent<Animation>();
		if (base.light)
		{
			base.light.intensity = 0f;
		}
	}

	// Token: 0x06001E90 RID: 7824 RVA: 0x0001436F File Offset: 0x0001256F
	public override void OnShoot()
	{
		if (this._shootAnimation)
		{
			this._shootAnimation.Play(PlayMode.StopSameLayer);
		}
	}

	// Token: 0x06001E91 RID: 7825 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001E92 RID: 7826 RVA: 0x0001438E File Offset: 0x0001258E
	public override void Hide()
	{
		if (this._shootAnimation)
		{
			this._shootAnimation.Stop();
		}
	}

	// Token: 0x06001E93 RID: 7827 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x04001A71 RID: 6769
	private Animation _shootAnimation;
}
