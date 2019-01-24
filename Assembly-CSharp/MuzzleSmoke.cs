using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
[RequireComponent(typeof(ParticleRenderer))]
public class MuzzleSmoke : BaseWeaponEffect
{
	// Token: 0x06001E9B RID: 7835 RVA: 0x000143D6 File Offset: 0x000125D6
	private void Awake()
	{
		this._particleEmitter = base.GetComponentInChildren<ParticleEmitter>();
	}

	// Token: 0x06001E9C RID: 7836 RVA: 0x000143E4 File Offset: 0x000125E4
	public override void OnShoot()
	{
		if (this._particleEmitter)
		{
			base.gameObject.SetActive(true);
			this._particleEmitter.Emit();
		}
	}

	// Token: 0x06001E9D RID: 7837 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001E9E RID: 7838 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x06001E9F RID: 7839 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void Hide()
	{
	}

	// Token: 0x04001A73 RID: 6771
	private ParticleEmitter _particleEmitter;
}
