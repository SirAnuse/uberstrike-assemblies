using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Twirl")]
public class TwirlEffect : ImageEffectBase
{
	// Token: 0x0600146E RID: 5230 RVA: 0x0000CA9E File Offset: 0x0000AC9E
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		ImageEffects.RenderDistortion(base.material, source, destination, this.angle, this.center, this.radius);
	}

	// Token: 0x04000E7D RID: 3709
	public Vector2 radius = new Vector2(0.3f, 0.3f);

	// Token: 0x04000E7E RID: 3710
	public float angle = 50f;

	// Token: 0x04000E7F RID: 3711
	public Vector2 center = new Vector2(0.5f, 0.5f);
}
