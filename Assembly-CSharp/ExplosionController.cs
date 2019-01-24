using System;
using UnityEngine;

// Token: 0x0200013A RID: 314
public class ExplosionController
{
	// Token: 0x0600086F RID: 2159 RVA: 0x00036B1C File Offset: 0x00034D1C
	public void EmitBlast(Vector3 hitPoint, Vector3 hitNormal, ExplosionBaseParameters parameters)
	{
		Vector3 zero = Vector3.zero;
		if (parameters.ParticleEmitter != null)
		{
			for (int i = 0; i < parameters.ParticleCount; i++)
			{
				float size = UnityEngine.Random.Range(parameters.MinSize, parameters.MaxSize);
				float energy = UnityEngine.Random.Range(parameters.MinLifeTime, parameters.MaxLifeTime);
				parameters.ParticleEmitter.Emit(hitPoint, zero, size, energy, Color.red);
			}
		}
	}

	// Token: 0x06000870 RID: 2160 RVA: 0x00036B90 File Offset: 0x00034D90
	public void EmitDust(Vector3 hitPoint, Vector3 hitNormal, ExplosionDustParameters parameters)
	{
		Vector3 velocity = Vector3.zero;
		if (parameters.ParticleEmitter != null)
		{
			for (int i = 0; i < parameters.ParticleCount; i++)
			{
				velocity = UnityEngine.Random.insideUnitSphere * 0.2f;
				hitPoint += UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(parameters.MinStartPositionSize, parameters.MinStartPositionSize);
				float size = UnityEngine.Random.Range(parameters.MinSize, parameters.MaxSize);
				float energy = UnityEngine.Random.Range(parameters.MinLifeTime, parameters.MaxLifeTime);
				parameters.ParticleEmitter.Emit(hitPoint, velocity, size, energy, Color.red);
			}
		}
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x00036C38 File Offset: 0x00034E38
	public void EmitRing(Vector3 hitPoint, Vector3 hitNormal, ExplosionRingParameters parameters)
	{
		Vector3 zero = Vector3.zero;
		float startSize = parameters.StartSize;
		float energy = UnityEngine.Random.Range(parameters.MinLifeTime, parameters.MaxLifeTime);
		if (parameters.ParticleEmitter != null)
		{
			parameters.ParticleEmitter.Emit(hitPoint, zero, startSize, energy, Color.red);
		}
	}

	// Token: 0x06000872 RID: 2162 RVA: 0x00036C8C File Offset: 0x00034E8C
	public void EmitSmoke(Vector3 hitPoint, Vector3 hitNormal, ExplosionBaseParameters parameters)
	{
		Vector3 velocity = Vector3.zero;
		if (parameters.ParticleEmitter != null)
		{
			for (int i = 0; i < parameters.ParticleCount; i++)
			{
				float size = UnityEngine.Random.Range(parameters.MinSize, parameters.MaxSize);
				float energy = UnityEngine.Random.Range(parameters.MinLifeTime, parameters.MaxLifeTime);
				velocity = UnityEngine.Random.insideUnitSphere * 0.3f;
				parameters.ParticleEmitter.Emit(hitPoint, velocity, size, energy, Color.red);
			}
		}
	}

	// Token: 0x06000873 RID: 2163 RVA: 0x00036D10 File Offset: 0x00034F10
	public void EmitSpark(Vector3 hitPoint, Vector3 hitNormal, ExplosionSphericParameters parameters)
	{
		Vector3 velocity = Vector3.zero;
		if (parameters.ParticleEmitter != null)
		{
			for (int i = 0; i < parameters.ParticleCount; i++)
			{
				float size = UnityEngine.Random.Range(parameters.MinSize, parameters.MaxSize);
				float energy = UnityEngine.Random.Range(parameters.MinLifeTime, parameters.MaxLifeTime);
				velocity = UnityEngine.Random.insideUnitSphere * parameters.Speed;
				parameters.ParticleEmitter.Emit(hitPoint, velocity, size, energy, Color.red);
			}
		}
	}

	// Token: 0x06000874 RID: 2164 RVA: 0x00036D10 File Offset: 0x00034F10
	public void EmitTrail(Vector3 hitPoint, Vector3 hitNormal, ExplosionSphericParameters parameters)
	{
		Vector3 velocity = Vector3.zero;
		if (parameters.ParticleEmitter != null)
		{
			for (int i = 0; i < parameters.ParticleCount; i++)
			{
				float size = UnityEngine.Random.Range(parameters.MinSize, parameters.MaxSize);
				float energy = UnityEngine.Random.Range(parameters.MinLifeTime, parameters.MaxLifeTime);
				velocity = UnityEngine.Random.insideUnitSphere * parameters.Speed;
				parameters.ParticleEmitter.Emit(hitPoint, velocity, size, energy, Color.red);
			}
		}
	}
}
