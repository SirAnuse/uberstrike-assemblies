using System;
using UnityEngine;

// Token: 0x0200013E RID: 318
public class ParticleConfigurationPerWeapon : MonoBehaviour
{
	// Token: 0x17000278 RID: 632
	// (get) Token: 0x06000888 RID: 2184 RVA: 0x000074DE File Offset: 0x000056DE
	public WeaponImpactEffectConfiguration WeaponImpactEffectConfiguration
	{
		get
		{
			return this._weaponImpactEffectConfiguration;
		}
	}

	// Token: 0x040008A6 RID: 2214
	[SerializeField]
	private WeaponImpactEffectConfiguration _weaponImpactEffectConfiguration;
}
