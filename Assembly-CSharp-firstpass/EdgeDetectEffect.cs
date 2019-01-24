using System;
using UnityEngine;

// Token: 0x02000358 RID: 856
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Edge Detection (Color)")]
public class EdgeDetectEffect : ImageEffectBase
{
	// Token: 0x06001444 RID: 5188 RVA: 0x0000C7BB File Offset: 0x0000A9BB
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		base.material.SetFloat("_Treshold", this.threshold * this.threshold);
		Graphics.Blit(source, destination, base.material);
	}

	// Token: 0x04000E4A RID: 3658
	public float threshold = 0.2f;
}
