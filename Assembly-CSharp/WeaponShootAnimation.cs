using System;
using UnityEngine;

// Token: 0x02000439 RID: 1081
public class WeaponShootAnimation : BaseWeaponEffect
{
	// Token: 0x06001EBC RID: 7868 RVA: 0x00014482 File Offset: 0x00012682
	private void Awake()
	{
		if (this._shootAnimation)
		{
			this._shootAnimation.playAutomatically = false;
		}
	}

	// Token: 0x06001EBD RID: 7869 RVA: 0x000144A0 File Offset: 0x000126A0
	public override void OnShoot()
	{
		if (this._shootAnimation)
		{
			this._shootAnimation.Rewind();
			this._shootAnimation.Play();
		}
	}

	// Token: 0x06001EBE RID: 7870 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001EBF RID: 7871 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x06001EC0 RID: 7872 RVA: 0x00095C20 File Offset: 0x00093E20
	public override void Hide()
	{
		if (this._shootAnimation && this._shootAnimation.clip)
		{
			base.gameObject.SampleAnimation(this._shootAnimation.clip, 0f);
			this._shootAnimation.Stop();
		}
	}

	// Token: 0x04001A7C RID: 6780
	[SerializeField]
	private Animation _shootAnimation;
}
