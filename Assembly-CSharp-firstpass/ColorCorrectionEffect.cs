using System;
using UnityEngine;

// Token: 0x02000356 RID: 854
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Color Correction (Ramp)")]
public class ColorCorrectionEffect : ImageEffectBase
{
	// Token: 0x06001438 RID: 5176 RVA: 0x0000C672 File Offset: 0x0000A872
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetTexture("_RampTex", this.textureRamp);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000E3C RID: 3644
	public Texture textureRamp;
}
