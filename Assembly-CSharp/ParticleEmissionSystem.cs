using System;
using UnityEngine;

// Token: 0x0200013C RID: 316
public static class ParticleEmissionSystem
{
	// Token: 0x0600087C RID: 2172 RVA: 0x00036F30 File Offset: 0x00035130
	public static void TrailParticles(Vector3 emitPoint, Vector3 direction, TrailParticleConfiguration particleConfiguration, Vector3 muzzlePosition, float distance)
	{
		if (particleConfiguration.ParticleEmitter != null)
		{
			float num = 200f;
			Vector3 velocity = direction * num;
			float energy = distance / num * 0.9f;
			if (distance > 3f)
			{
				particleConfiguration.ParticleEmitter.Emit(muzzlePosition + direction * 3f, velocity, UnityEngine.Random.Range(particleConfiguration.ParticleMinSize, particleConfiguration.ParticleMaxSize), energy, particleConfiguration.ParticleColor);
			}
		}
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x00036FA8 File Offset: 0x000351A8
	public static void FireParticles(Vector3 hitPoint, Vector3 hitNormal, FireParticleConfiguration particleConfiguration)
	{
		if (particleConfiguration.ParticleEmitter != null)
		{
			Vector3 vector = Vector3.zero;
			Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hitNormal);
			Vector3 pos = Vector3.zero;
			for (int i = 0; i < particleConfiguration.ParticleCount; i++)
			{
				vector.x = 0f + UnityEngine.Random.Range(0f, 0.001f);
				vector.y = 2f + UnityEngine.Random.Range(0f, 0.4f);
				vector.z = 0f + UnityEngine.Random.Range(0f, 0.001f);
				vector = rotation * vector;
				pos = hitPoint;
				pos.x += UnityEngine.Random.Range(0f, 0.2f);
				pos.z += UnityEngine.Random.Range(0f, 0.4f) * -1f;
				particleConfiguration.ParticleEmitter.Emit(pos, vector, UnityEngine.Random.Range(particleConfiguration.ParticleMinSize, particleConfiguration.ParticleMaxSize), UnityEngine.Random.Range(particleConfiguration.ParticleMinLiveTime, particleConfiguration.ParticleMaxLiveTime), particleConfiguration.ParticleColor);
			}
		}
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x000370CC File Offset: 0x000352CC
	public static void WaterCircleParticles(Vector3 hitPoint, Vector3 hitNormal, FireParticleConfiguration particleConfiguration)
	{
		if (particleConfiguration.ParticleEmitter != null)
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < particleConfiguration.ParticleCount; i++)
			{
				zero.x = UnityEngine.Random.Range(0f, 0.3f);
				zero.z = UnityEngine.Random.Range(0f, 0.3f);
				particleConfiguration.ParticleEmitter.Emit(hitPoint, zero, UnityEngine.Random.Range(particleConfiguration.ParticleMinSize, particleConfiguration.ParticleMaxSize), UnityEngine.Random.Range(particleConfiguration.ParticleMinLiveTime, particleConfiguration.ParticleMaxLiveTime), particleConfiguration.ParticleColor);
			}
		}
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x00037168 File Offset: 0x00035368
	public static void WaterSplashParticles(Vector3 hitPoint, Vector3 hitNormal, FireParticleConfiguration particleConfiguration)
	{
		if (particleConfiguration.ParticleEmitter != null)
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < particleConfiguration.ParticleCount; i++)
			{
				zero.x = UnityEngine.Random.Range(0f, 0.3f);
				zero.y = 2f + UnityEngine.Random.Range(0f, 0.3f);
				zero.z = UnityEngine.Random.Range(0f, 0.3f);
				particleConfiguration.ParticleEmitter.Emit(hitPoint, zero, UnityEngine.Random.Range(particleConfiguration.ParticleMinSize, particleConfiguration.ParticleMaxSize), UnityEngine.Random.Range(particleConfiguration.ParticleMinLiveTime, particleConfiguration.ParticleMaxLiveTime), particleConfiguration.ParticleColor);
			}
		}
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x00037220 File Offset: 0x00035420
	public static void HitMaterialParticles(Vector3 hitPoint, Vector3 hitNormal, ParticleConfiguration particleConfiguration)
	{
		if (particleConfiguration.ParticleEmitter != null)
		{
			Vector3 vector = Vector3.zero;
			Quaternion rotation = default(Quaternion);
			rotation = Quaternion.FromToRotation(Vector3.back, hitNormal);
			for (int i = 0; i < particleConfiguration.ParticleCount; i++)
			{
				Vector2 vector2 = UnityEngine.Random.insideUnitCircle * UnityEngine.Random.Range(particleConfiguration.ParticleMinSpeed, particleConfiguration.ParticleMaxSpeed);
				vector.x = vector2.x;
				vector.y = vector2.y;
				vector.z = UnityEngine.Random.Range(particleConfiguration.ParticleMinZVelocity, particleConfiguration.ParticleMaxZVelocity) * -1f;
				vector = rotation * vector;
				particleConfiguration.ParticleEmitter.Emit(hitPoint, vector, UnityEngine.Random.Range(particleConfiguration.ParticleMinSize, particleConfiguration.ParticleMaxSize), UnityEngine.Random.Range(particleConfiguration.ParticleMinLiveTime, particleConfiguration.ParticleMaxLiveTime), particleConfiguration.ParticleColor);
			}
		}
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x00037304 File Offset: 0x00035504
	public static void HitMaterialRotatingParticles(Vector3 hitPoint, Vector3 hitNormal, ParticleConfiguration particleConfiguration)
	{
		if (particleConfiguration.ParticleEmitter != null)
		{
			Vector3 vector = Vector3.zero;
			Quaternion rotation = default(Quaternion);
			rotation = Quaternion.FromToRotation(Vector3.back, hitNormal);
			for (int i = 0; i < particleConfiguration.ParticleCount; i++)
			{
				Vector2 vector2 = UnityEngine.Random.insideUnitCircle * UnityEngine.Random.Range(particleConfiguration.ParticleMinSpeed, particleConfiguration.ParticleMaxSpeed);
				vector.x = vector2.x;
				vector.y = vector2.y;
				vector.z = UnityEngine.Random.Range(particleConfiguration.ParticleMinZVelocity, particleConfiguration.ParticleMaxZVelocity) * -1f;
				vector = rotation * vector;
				particleConfiguration.ParticleEmitter.Emit(hitPoint, vector, UnityEngine.Random.Range(particleConfiguration.ParticleMinSize, particleConfiguration.ParticleMaxSize), UnityEngine.Random.Range(particleConfiguration.ParticleMinLiveTime, particleConfiguration.ParticleMaxLiveTime), particleConfiguration.ParticleColor, UnityEngine.Random.Range(0f, 360f), 0f);
			}
		}
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x000373FC File Offset: 0x000355FC
	public static void HitMateriaHalfSphericParticles(Vector3 hitPoint, Vector3 hitNormal, ParticleConfiguration particleConfiguration)
	{
		if (particleConfiguration.ParticleEmitter != null)
		{
			Vector3 vector = Vector3.zero;
			Quaternion rotation = default(Quaternion);
			rotation = Quaternion.FromToRotation(Vector3.back, hitNormal);
			for (int i = 0; i < particleConfiguration.ParticleCount; i++)
			{
				vector = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(particleConfiguration.ParticleMinSpeed, particleConfiguration.ParticleMaxSpeed);
				if (vector.z > 0f)
				{
					vector.z *= -1f;
				}
				vector = rotation * vector;
				particleConfiguration.ParticleEmitter.Emit(hitPoint, vector, UnityEngine.Random.Range(particleConfiguration.ParticleMinSize, particleConfiguration.ParticleMaxSize), UnityEngine.Random.Range(particleConfiguration.ParticleMinLiveTime, particleConfiguration.ParticleMaxLiveTime), particleConfiguration.ParticleColor);
			}
		}
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x000374CC File Offset: 0x000356CC
	public static void HitMateriaFullSphericParticles(Vector3 hitPoint, Vector3 hitNormal, ParticleConfiguration particleConfiguration)
	{
		if (particleConfiguration.ParticleEmitter != null)
		{
			Vector3 velocity = Vector3.zero;
			for (int i = 0; i < particleConfiguration.ParticleCount; i++)
			{
				velocity = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(particleConfiguration.ParticleMinSpeed, particleConfiguration.ParticleMaxSpeed);
				particleConfiguration.ParticleEmitter.Emit(hitPoint, velocity, UnityEngine.Random.Range(particleConfiguration.ParticleMinSize, particleConfiguration.ParticleMaxSize), UnityEngine.Random.Range(particleConfiguration.ParticleMinLiveTime, particleConfiguration.ParticleMaxLiveTime), particleConfiguration.ParticleColor);
			}
		}
	}
}
