using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Grayscale")]
public class GrayscaleEffect : ImageEffectBase
{
	// Token: 0x06001450 RID: 5200 RVA: 0x0000C8C5 File Offset: 0x0000AAC5
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_RampTex", this.textureRamp);
		base.material.SetFloat("_RampOffset", this.rampOffset);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000E55 RID: 3669
	public Texture textureRamp;

	// Token: 0x04000E56 RID: 3670
	public float rampOffset;
}
