using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200013F RID: 319
public class ParticleEffectController : MonoBehaviour
{
	// Token: 0x17000279 RID: 633
	// (get) Token: 0x0600088B RID: 2187 RVA: 0x000074F2 File Offset: 0x000056F2
	// (set) Token: 0x0600088C RID: 2188 RVA: 0x000074F9 File Offset: 0x000056F9
	public static ParticleEffectController Instance { get; private set; }

	// Token: 0x1700027A RID: 634
	// (get) Token: 0x0600088D RID: 2189 RVA: 0x00007501 File Offset: 0x00005701
	public static bool Exists
	{
		get
		{
			return ParticleEffectController.Instance != null;
		}
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x00037660 File Offset: 0x00035860
	private void Awake()
	{
		ParticleEffectController.Instance = this;
		this._explosionParticleSystem = new ExplosionController();
		this._allConfigurations = new Dictionary<ParticleConfigurationType, ParticleConfigurationPerWeapon>();
		foreach (ParticleEffectController.ParticleConfiguration particleConfiguration in this._allWeaponData)
		{
			this._allConfigurations[particleConfiguration.Type] = particleConfiguration.Configuration;
		}
		Singleton<ExplosionManager>.Instance.HeatWavePrefab = this._heatWavePrefab;
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x0000750E File Offset: 0x0000570E
	public static void ShowJumpEffect(Vector3 pos, Vector2 normal)
	{
		if (ParticleEffectController.Instance)
		{
			ParticleEffectController.Instance._jumpEffect.transform.position = pos;
			ParticleEffectController.Instance._jumpEffect.Emit(5);
		}
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x00007544 File Offset: 0x00005744
	public static void ShowPickUpEffect(Vector3 pos, int count)
	{
		if (ParticleEffectController.Instance)
		{
			ParticleEffectController.Instance._pickupParticleEmitter.transform.position = pos;
			ParticleEffectController.Instance._pickupParticleEmitter.Emit(count);
		}
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x000376D0 File Offset: 0x000358D0
	public static void ShowHeatwaveEffect(Vector3 pos)
	{
		if (ParticleEffectController.Instance && ParticleEffectController.Instance._heatWave && !ApplicationDataManager.IsMobile)
		{
			ParticleEffectController.Instance._heatWave.Emit(pos, Vector3.zero, 1f, 1f, Color.white);
		}
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x00037730 File Offset: 0x00035930
	public static void ShowHitEffect(ParticleConfigurationType effectType, SurfaceEffectType surface, Vector3 direction, Vector3 hitPoint, Vector3 hitNormal, Vector3 muzzlePosition, float distance, ref MoveTrailrendererObject trailRenderer, Transform parent)
	{
		ParticleEffectController.ShowHitEffect(effectType, surface, direction, hitPoint, hitNormal, muzzlePosition, distance, ref trailRenderer, parent, 0);
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x00037754 File Offset: 0x00035954
	public static void ShowHitEffect(ParticleConfigurationType effectType, SurfaceEffectType surface, Vector3 direction, Vector3 hitPoint, Vector3 hitNormal, Vector3 muzzlePosition, float distance, ref MoveTrailrendererObject trailRenderer, Transform parent, int damage)
	{
		if (ParticleEffectController.Exists)
		{
			ParticleConfigurationPerWeapon particleConfigurationPerWeapon = ParticleEffectController.Instance._allConfigurations[effectType];
			if (particleConfigurationPerWeapon != null)
			{
				ParticleEffectController.ShowTrailEffect(particleConfigurationPerWeapon, trailRenderer, parent, hitPoint, muzzlePosition, distance, direction);
				switch (surface)
				{
				case SurfaceEffectType.Default:
					if (ParticleEffectController.CheckVisibility(hitPoint))
					{
						ParticleEmissionSystem.FireParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.FireParticleConfigurationForInstantHit);
					}
					break;
				case SurfaceEffectType.WoodEffect:
					if (ParticleEffectController.CheckVisibility(hitPoint))
					{
						ParticleEmissionSystem.HitMaterialParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.WoodEffect);
						ParticleEmissionSystem.FireParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.FireParticleConfigurationForInstantHit);
					}
					break;
				case SurfaceEffectType.WaterEffect:
					if (ParticleEffectController.CheckVisibility(hitPoint))
					{
						ParticleEmissionSystem.WaterCircleParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.WaterCircleEffect);
					}
					break;
				case SurfaceEffectType.StoneEffect:
					if (ParticleEffectController.CheckVisibility(hitPoint))
					{
						ParticleEmissionSystem.HitMaterialParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.StoneEffect);
						ParticleEmissionSystem.FireParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.FireParticleConfigurationForInstantHit);
					}
					break;
				case SurfaceEffectType.MetalEffect:
					if (ParticleEffectController.CheckVisibility(hitPoint))
					{
						ParticleEmissionSystem.HitMaterialParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.MetalEffect);
						ParticleEmissionSystem.FireParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.FireParticleConfigurationForInstantHit);
					}
					break;
				case SurfaceEffectType.GrassEffect:
					if (ParticleEffectController.CheckVisibility(hitPoint))
					{
						ParticleEmissionSystem.HitMaterialParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.GrassEffect);
						ParticleEmissionSystem.FireParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.FireParticleConfigurationForInstantHit);
					}
					break;
				case SurfaceEffectType.SandEffect:
					if (ParticleEffectController.CheckVisibility(hitPoint))
					{
						ParticleEmissionSystem.HitMaterialParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.SandEffect);
						ParticleEmissionSystem.FireParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.FireParticleConfigurationForInstantHit);
					}
					break;
				case SurfaceEffectType.Splat:
					if (ParticleEffectController.CheckVisibility(hitPoint))
					{
						ParticleEmissionSystem.HitMaterialRotatingParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.Splat);
					}
					break;
				}
			}
		}
		else
		{
			Debug.LogError("ParticleEffectController is not attached to a gameobject in scene!");
		}
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x00037978 File Offset: 0x00035B78
	private static void ShowTrailEffect(ParticleConfigurationPerWeapon effect, MoveTrailrendererObject trailRenderer, Transform parent, Vector3 hitPoint, Vector3 muzzlePosition, float distance, Vector3 direction)
	{
		if (effect.WeaponImpactEffectConfiguration.UseTrailrendererForTrail)
		{
			if (effect.WeaponImpactEffectConfiguration.TrailrendererTrailPrefab != null)
			{
				if (trailRenderer == null)
				{
					trailRenderer = (UnityEngine.Object.Instantiate(effect.WeaponImpactEffectConfiguration.TrailrendererTrailPrefab, muzzlePosition, Quaternion.identity) as MoveTrailrendererObject);
					trailRenderer.gameObject.transform.parent = parent;
				}
				trailRenderer.MoveTrail(hitPoint, muzzlePosition, distance);
			}
		}
		else
		{
			ParticleEmissionSystem.TrailParticles(hitPoint, direction, effect.WeaponImpactEffectConfiguration.TrailParticleConfigurationForInstantHit, muzzlePosition, distance);
		}
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x00037A10 File Offset: 0x00035C10
	public static void ShowExplosionEffect(ParticleConfigurationType effectType, SurfaceEffectType surface, Vector3 hitPoint, Vector3 hitNormal)
	{
		if (ParticleEffectController.Exists && ParticleEffectController.CheckVisibility(hitPoint))
		{
			ParticleConfigurationPerWeapon particleConfigurationPerWeapon = ParticleEffectController.Instance._allConfigurations[effectType];
			bool flag = false;
			if (particleConfigurationPerWeapon != null)
			{
				switch (surface)
				{
				case SurfaceEffectType.WoodEffect:
					ParticleEmissionSystem.HitMateriaHalfSphericParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.WoodEffect);
					break;
				case SurfaceEffectType.WaterEffect:
					ParticleEmissionSystem.WaterCircleParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.WaterCircleEffect);
					ParticleEmissionSystem.WaterSplashParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.WaterExtraSplashEffect);
					break;
				case SurfaceEffectType.StoneEffect:
					ParticleEmissionSystem.HitMateriaHalfSphericParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.StoneEffect);
					break;
				case SurfaceEffectType.MetalEffect:
					ParticleEmissionSystem.HitMateriaHalfSphericParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.MetalEffect);
					break;
				case SurfaceEffectType.GrassEffect:
					ParticleEmissionSystem.HitMateriaHalfSphericParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.GrassEffect);
					break;
				case SurfaceEffectType.SandEffect:
					ParticleEmissionSystem.HitMateriaHalfSphericParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.SandEffect);
					break;
				case SurfaceEffectType.Splat:
					ParticleEmissionSystem.HitMateriaFullSphericParticles(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.Splat);
					break;
				}
				bool flag2 = QualitySettings.GetQualityLevel() > 0;
				if (flag2)
				{
					ParticleEffectController.Instance._explosionParticleSystem.EmitDust(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.ExplosionParameterSet.DustParameters);
					ParticleEffectController.Instance._explosionParticleSystem.EmitSmoke(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.ExplosionParameterSet.SmokeParameters);
				}
				if (flag2 || flag)
				{
					ParticleEffectController.Instance._explosionParticleSystem.EmitTrail(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.ExplosionParameterSet.TrailParameters);
				}
				ParticleEffectController.Instance._explosionParticleSystem.EmitBlast(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.ExplosionParameterSet.BlastParameters);
				ParticleEffectController.Instance._explosionParticleSystem.EmitRing(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.ExplosionParameterSet.RingParameters);
				ParticleEffectController.Instance._explosionParticleSystem.EmitSpark(hitPoint, hitNormal, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.ExplosionParameterSet.SparkParameters);
			}
		}
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x00037C48 File Offset: 0x00035E48
	private static void WaterRipplesEffect(ParticleConfigurationPerWeapon effect, Vector3 hitPoint, Vector3 direction, Vector3 muzzlePosition, float distance)
	{
		float d = Math.Abs(muzzlePosition.y) * distance / (Math.Abs(hitPoint.y) + Math.Abs(muzzlePosition.y));
		Vector3 vector = direction * d + muzzlePosition;
		if (ParticleEffectController.CanPlayEffectAt(vector) && ParticleEffectController.CheckVisibility(vector))
		{
			ParticleEmissionSystem.WaterSplashParticles(vector, Vector3.up, effect.WeaponImpactEffectConfiguration.SurfaceParameterSet.WaterExtraSplashEffect);
			ParticleEmissionSystem.WaterCircleParticles(vector, Vector3.up, effect.WeaponImpactEffectConfiguration.SurfaceParameterSet.WaterCircleEffect);
		}
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x0000757A File Offset: 0x0000577A
	private static Vector3 PositionRaster(Vector3 v)
	{
		return new Vector3((float)Mathf.RoundToInt(v[0]), (float)Mathf.RoundToInt(v[1]), (float)Mathf.RoundToInt(v[2]));
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x00037CDC File Offset: 0x00035EDC
	private static bool CanPlayEffectAt(Vector3 v)
	{
		if (ParticleEffectController._nextCleanup < Time.time)
		{
			ParticleEffectController._nextCleanup = Time.time + 30f;
			ParticleEffectController._effects.Clear();
		}
		Vector3 key = ParticleEffectController.PositionRaster(v);
		float num;
		if (!ParticleEffectController._effects.TryGetValue(key, out num) || num < Time.time)
		{
			ParticleEffectController._effects[key] = Time.time + 1f;
			return true;
		}
		return false;
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x00037D50 File Offset: 0x00035F50
	public static void ProjectileWaterRipplesEffect(ParticleConfigurationType effectType, Vector3 hitPosition)
	{
		if (ParticleEffectController.Exists && GameState.Current.Map != null)
		{
			ParticleConfigurationPerWeapon particleConfigurationPerWeapon = ParticleEffectController.Instance._allConfigurations[effectType];
			if (particleConfigurationPerWeapon != null)
			{
				ParticleEmissionSystem.WaterSplashParticles(hitPosition, Vector3.up, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.WaterExtraSplashEffect);
				ParticleEmissionSystem.WaterCircleParticles(hitPosition, Vector3.up, particleConfigurationPerWeapon.WeaponImpactEffectConfiguration.SurfaceParameterSet.WaterCircleEffect);
			}
		}
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x00037DD4 File Offset: 0x00035FD4
	private static bool CheckVisibility(Vector3 hitPoint)
	{
		return true;
	}

	// Token: 0x040008A7 RID: 2215
	[SerializeField]
	private ParticleEffectController.ParticleConfiguration[] _allWeaponData;

	// Token: 0x040008A8 RID: 2216
	[SerializeField]
	private ParticleEmitter _pickupParticleEmitter;

	// Token: 0x040008A9 RID: 2217
	[SerializeField]
	private HeatWave _heatWavePrefab;

	// Token: 0x040008AA RID: 2218
	[SerializeField]
	private ParticleEmitter _heatWave;

	// Token: 0x040008AB RID: 2219
	[SerializeField]
	private ParticleSystem _jumpEffect;

	// Token: 0x040008AC RID: 2220
	private Dictionary<ParticleConfigurationType, ParticleConfigurationPerWeapon> _allConfigurations;

	// Token: 0x040008AD RID: 2221
	private static Dictionary<Vector3, float> _effects = new Dictionary<Vector3, float>();

	// Token: 0x040008AE RID: 2222
	private static float _nextCleanup;

	// Token: 0x040008AF RID: 2223
	private ExplosionController _explosionParticleSystem;

	// Token: 0x02000140 RID: 320
	[Serializable]
	private class ParticleConfiguration
	{
		// Token: 0x0600089B RID: 2203 RVA: 0x000075AB File Offset: 0x000057AB
		public ParticleConfiguration(string name, ParticleConfigurationType type, ParticleConfigurationPerWeapon configuration)
		{
			this.Name = name;
			this.Type = type;
			this.Configuration = configuration;
		}

		// Token: 0x040008B1 RID: 2225
		[HideInInspector]
		public string Name = "Effect";

		// Token: 0x040008B2 RID: 2226
		public ParticleConfigurationType Type;

		// Token: 0x040008B3 RID: 2227
		public ParticleConfigurationPerWeapon Configuration;
	}
}
