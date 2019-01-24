using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class MuzzleParticleSystem : BaseWeaponEffect
{
	// Token: 0x06001E95 RID: 7829 RVA: 0x000143AB File Offset: 0x000125AB
	private void Awake()
	{
		this._particleSystem = base.GetComponent<ParticleSystem>();
	}

	// Token: 0x06001E96 RID: 7830 RVA: 0x000143B9 File Offset: 0x000125B9
	public override void OnShoot()
	{
		if (this._particleSystem)
		{
			this._particleSystem.Play();
		}
	}

	// Token: 0x06001E97 RID: 7831 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnPostShoot()
	{
	}

	// Token: 0x06001E98 RID: 7832 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void Hide()
	{
	}

	// Token: 0x06001E99 RID: 7833 RVA: 0x00003C87 File Offset: 0x00001E87
	public override void OnHits(RaycastHit[] hits)
	{
	}

	// Token: 0x04001A72 RID: 6770
	private ParticleSystem _particleSystem;
}
