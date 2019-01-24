using System;
using UnityEngine;

// Token: 0x0200035D RID: 861
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Motion Blur (Color Accumulation)")]
[ExecuteInEditMode]
public class MotionBlur : ImageEffectBase
{
	// Token: 0x0600145A RID: 5210 RVA: 0x0000C9B5 File Offset: 0x0000ABB5
	protected override void Start()
	{
		if (!SystemInfo.supportsRenderTextures)
		{
			base.enabled = false;
			return;
		}
		base.Start();
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x0000C9CF File Offset: 0x0000ABCF
	protected override void OnDisable()
	{
		base.OnDisable();
		UnityEngine.Object.DestroyImmediate(this.accumTexture);
	}

	// Token: 0x0600145C RID: 5212 RVA: 0x00024FE0 File Offset: 0x000231E0
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.accumTexture == null || this.accumTexture.width != source.width || this.accumTexture.height != source.height)
		{
			UnityEngine.Object.DestroyImmediate(this.accumTexture);
			this.accumTexture = new RenderTexture(source.width, source.height, 0);
			this.accumTexture.hideFlags = HideFlags.HideAndDontSave;
			Graphics.Blit(source, this.accumTexture);
		}
		if (this.extraBlur)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
			Graphics.Blit(this.accumTexture, temporary);
			Graphics.Blit(temporary, this.accumTexture);
			RenderTexture.ReleaseTemporary(temporary);
		}
		this.blurAmount = Mathf.Clamp(this.blurAmount, 0f, 0.92f);
		base.material.SetTexture("_MainTex", this.accumTexture);
		base.material.SetFloat("_AccumOrig", 1f - this.blurAmount);
		Graphics.Blit(source, this.accumTexture, base.material);
		Graphics.Blit(this.accumTexture, destination);
	}

	// Token: 0x04000E59 RID: 3673
	public float blurAmount = 0.8f;

	// Token: 0x04000E5A RID: 3674
	public bool extraBlur;

	// Token: 0x04000E5B RID: 3675
	private RenderTexture accumTexture;
}
