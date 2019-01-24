using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class ProjectileWeaponDecorator : BaseWeaponDecorator
{
	// Token: 0x1700068A RID: 1674
	// (get) Token: 0x06001E56 RID: 7766 RVA: 0x000141DF File Offset: 0x000123DF
	public Projectile Missle
	{
		get
		{
			return this._missle;
		}
	}

	// Token: 0x1700068B RID: 1675
	// (get) Token: 0x06001E57 RID: 7767 RVA: 0x000141E7 File Offset: 0x000123E7
	public float MissileTimeOut
	{
		get
		{
			return this._missileTimeOut;
		}
	}

	// Token: 0x1700068C RID: 1676
	// (get) Token: 0x06001E58 RID: 7768 RVA: 0x000141EF File Offset: 0x000123EF
	public AudioClip ExplosionSound
	{
		get
		{
			return this._missleExplosionSound;
		}
	}

	// Token: 0x06001E59 RID: 7769 RVA: 0x000141F7 File Offset: 0x000123F7
	public void ShowExplosionEffect(Vector3 position, Vector3 normal, ParticleConfigurationType explosionEffect)
	{
		this.ShowShootEffect(new RaycastHit[0]);
		Singleton<ExplosionManager>.Instance.ShowExplosionEffect(position, normal, base.tag, explosionEffect);
	}

	// Token: 0x06001E5A RID: 7770 RVA: 0x00014218 File Offset: 0x00012418
	public void SetMissileTimeOut(float timeOut)
	{
		this._missileTimeOut = timeOut;
	}

	// Token: 0x04001A48 RID: 6728
	[SerializeField]
	private Projectile _missle;

	// Token: 0x04001A49 RID: 6729
	[SerializeField]
	private AudioClip _missleExplosionSound;

	// Token: 0x04001A4A RID: 6730
	private float _missileTimeOut;
}
