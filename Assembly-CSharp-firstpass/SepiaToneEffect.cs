using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
[AddComponentMenu("Image Effects/Sepia Tone")]
[ExecuteInEditMode]
public class SepiaToneEffect : ImageEffectBase
{
	// Token: 0x0600146C RID: 5228 RVA: 0x0000CA52 File Offset: 0x0000AC52
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
