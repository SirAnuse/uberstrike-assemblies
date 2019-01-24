using System;
using UnityEngine;

// Token: 0x0200023A RID: 570
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/UnderWater")]
public class UnderWaterEffect : ImageEffectBase
{
	// Token: 0x170003A9 RID: 937
	// (set) Token: 0x06000FAF RID: 4015 RVA: 0x0000B150 File Offset: 0x00009350
	public float Weight
	{
		set
		{
			this.effectWeight = value;
		}
	}

	// Token: 0x06000FB0 RID: 4016 RVA: 0x00065568 File Offset: 0x00063768
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (Camera.main)
		{
			Camera.main.depthTextureMode |= DepthTextureMode.Depth;
		}
		float num = base.camera.farClipPlane - base.camera.nearClipPlane;
		float value = this.fadeDistance / num;
		float angle = Mathf.Cos(Time.time) * this.maxAngle;
		base.material.SetTexture("_RampTex", this.textureRamp);
		base.material.SetFloat("_FadeDistance", value);
		base.material.SetFloat("_EffectWeight", this.effectWeight);
		ImageEffects.RenderDistortion(base.material, source, destination, angle, this.center, this.radius);
	}

	// Token: 0x06000FB1 RID: 4017 RVA: 0x00003C87 File Offset: 0x00001E87
	public void Update()
	{
	}

	// Token: 0x04000DC0 RID: 3520
	public Texture textureRamp;

	// Token: 0x04000DC1 RID: 3521
	public float fadeDistance = 10f;

	// Token: 0x04000DC2 RID: 3522
	public Vector2 center = new Vector2(0.5f, 0.5f);

	// Token: 0x04000DC3 RID: 3523
	public Vector2 radius = new Vector2(0.5f, 0.5f);

	// Token: 0x04000DC4 RID: 3524
	public float maxAngle = 7f;

	// Token: 0x04000DC5 RID: 3525
	private float effectWeight;
}
