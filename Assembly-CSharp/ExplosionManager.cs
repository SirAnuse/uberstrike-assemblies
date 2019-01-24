using System;
using UnityEngine;

// Token: 0x02000243 RID: 579
public class ExplosionManager : Singleton<ExplosionManager>
{
	// Token: 0x06000FFF RID: 4095 RVA: 0x0000B3F1 File Offset: 0x000095F1
	private ExplosionManager()
	{
	}

	// Token: 0x170003CA RID: 970
	// (get) Token: 0x06001000 RID: 4096 RVA: 0x0000B3F9 File Offset: 0x000095F9
	// (set) Token: 0x06001001 RID: 4097 RVA: 0x0000B401 File Offset: 0x00009601
	public HeatWave HeatWavePrefab { get; set; }

	// Token: 0x06001002 RID: 4098 RVA: 0x00065A48 File Offset: 0x00063C48
	public void PlayExplosionSound(Vector3 point, AudioClip clip)
	{
		if (GameState.Current.Map != null && GameState.Current.Map.HasWaterPlane && GameState.Current.Map.WaterPlaneHeight > point.y)
		{
			if (UnityEngine.Random.Range(0, 2) == 0)
			{
				clip = GameAudio.UnderwaterExplosion1;
			}
			else
			{
				clip = GameAudio.UnderwaterExplosion2;
			}
		}
		if (clip != null)
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play3dAudioClip(clip, point, 1f);
		}
	}

	// Token: 0x06001003 RID: 4099 RVA: 0x00065AD8 File Offset: 0x00063CD8
	public void ShowExplosionEffect(Vector3 point, Vector3 normal, string tag, ParticleConfigurationType effectType)
	{
		switch (tag)
		{
		case "Wood":
			ParticleEffectController.ShowExplosionEffect(effectType, SurfaceEffectType.WoodEffect, point, normal);
			return;
		case "Stone":
			ParticleEffectController.ShowExplosionEffect(effectType, SurfaceEffectType.StoneEffect, point, normal);
			return;
		case "Metal":
			ParticleEffectController.ShowExplosionEffect(effectType, SurfaceEffectType.MetalEffect, point, normal);
			return;
		case "Sand":
			ParticleEffectController.ShowExplosionEffect(effectType, SurfaceEffectType.SandEffect, point, normal);
			return;
		case "Grass":
			ParticleEffectController.ShowExplosionEffect(effectType, SurfaceEffectType.GrassEffect, point, normal);
			return;
		case "Avatar":
			ParticleEffectController.ShowExplosionEffect(effectType, SurfaceEffectType.Splat, point, normal);
			return;
		case "Water":
			ParticleEffectController.ShowExplosionEffect(effectType, SurfaceEffectType.WaterEffect, point, normal);
			return;
		}
		ParticleEffectController.ShowExplosionEffect(effectType, SurfaceEffectType.Default, point, normal);
	}
}
