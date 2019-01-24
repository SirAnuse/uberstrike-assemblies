using System;
using UnityEngine;

// Token: 0x02000363 RID: 867
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Vortex")]
public class VortexEffect : ImageEffectBase
{
	// Token: 0x06001470 RID: 5232 RVA: 0x0000CAFC File Offset: 0x0000ACFC
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		ImageEffects.RenderDistortion(base.material, source, destination, this.angle, this.center, this.radius);
	}

	// Token: 0x04000E80 RID: 3712
	public Vector2 radius = new Vector2(0.4f, 0.4f);

	// Token: 0x04000E81 RID: 3713
	public float angle = 50f;

	// Token: 0x04000E82 RID: 3714
	public Vector2 center = new Vector2(0.5f, 0.5f);
}
