using System;
using UnityEngine;

// Token: 0x0200013B RID: 315
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Mobile Bloom")]
public class MobileBloom : MonoBehaviour
{
	// Token: 0x06000876 RID: 2166 RVA: 0x0000742B File Offset: 0x0000562B
	private void OnEnable()
	{
		this.FindShaders();
		this.CheckSupport();
		this.CreateMaterials();
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x00007440 File Offset: 0x00005640
	private void FindShaders()
	{
		if (!this.bloomShader)
		{
			this.bloomShader = Shader.Find("Cross Platform Shaders/Mobile Bloom");
		}
	}

	// Token: 0x06000878 RID: 2168 RVA: 0x00007462 File Offset: 0x00005662
	private void CreateMaterials()
	{
		if (!this.apply)
		{
			this.apply = new Material(this.bloomShader);
			this.apply.hideFlags = HideFlags.DontSave;
		}
	}

	// Token: 0x06000879 RID: 2169 RVA: 0x00036D94 File Offset: 0x00034F94
	private bool CheckSupport()
	{
		if (!SystemInfo.supportsImageEffects || !SystemInfo.supportsRenderTextures || !this.bloomShader.isSupported)
		{
			base.enabled = false;
			return false;
		}
		this.rtFormat = ((!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.RGB565)) ? RenderTextureFormat.Default : RenderTextureFormat.RGB565);
		return true;
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x00007491 File Offset: 0x00005691
	private void OnDisable()
	{
		if (this.apply)
		{
			UnityEngine.Object.DestroyImmediate(this.apply);
			this.apply = null;
		}
	}

	// Token: 0x0600087B RID: 2171 RVA: 0x00036DE8 File Offset: 0x00034FE8
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.agonyTint = Mathf.Clamp01(this.agonyTint - Time.deltaTime * 1.25f);
		this.intensityBoost = Mathf.Clamp01(this.intensityBoost - Time.deltaTime * 0.75f);
		RenderTexture temporary = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0, this.rtFormat);
		RenderTexture temporary2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0, this.rtFormat);
		this.apply.SetColor("_ColorMix", this.colorMix);
		this.apply.SetVector("_Parameter", new Vector4(this.colorMixBlend * 0.25f, 0f, 0f, 1f - this.intensity - (this.agonyTint + this.intensityBoost)));
		Graphics.Blit(source, temporary, this.apply, (this.agonyTint >= 0.5f) ? 5 : 1);
		Graphics.Blit(temporary, temporary2, this.apply, 2);
		Graphics.Blit(temporary2, temporary, this.apply, 3);
		this.apply.SetTexture("_Bloom", temporary);
		Graphics.Blit(source, destination, this.apply, 4);
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}

	// Token: 0x04000898 RID: 2200
	public float intensity = 0.5f;

	// Token: 0x04000899 RID: 2201
	public Color colorMix = Color.white;

	// Token: 0x0400089A RID: 2202
	public float colorMixBlend = 0.25f;

	// Token: 0x0400089B RID: 2203
	public float agonyTint;

	// Token: 0x0400089C RID: 2204
	public float intensityBoost;

	// Token: 0x0400089D RID: 2205
	private Shader bloomShader = new Shader();

	// Token: 0x0400089E RID: 2206
	private Material apply;

	// Token: 0x0400089F RID: 2207
	private RenderTextureFormat rtFormat = RenderTextureFormat.Default;
}
