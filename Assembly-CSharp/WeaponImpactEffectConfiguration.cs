using System;

// Token: 0x02000141 RID: 321
[Serializable]
public class WeaponImpactEffectConfiguration
{
	// Token: 0x040008B4 RID: 2228
	public ExplosionParameterSet ExplosionParameterSet;

	// Token: 0x040008B5 RID: 2229
	public FireParticleConfiguration FireParticleConfigurationForInstantHit;

	// Token: 0x040008B6 RID: 2230
	public TrailParticleConfiguration TrailParticleConfigurationForInstantHit;

	// Token: 0x040008B7 RID: 2231
	public SurfaceParameters SurfaceParameterSet;

	// Token: 0x040008B8 RID: 2232
	public MoveTrailrendererObject TrailrendererTrailPrefab;

	// Token: 0x040008B9 RID: 2233
	public bool UseTrailrendererForTrail;
}
