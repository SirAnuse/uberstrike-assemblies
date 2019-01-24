using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Screen Space Ambient Occlusion")]
[ExecuteInEditMode]
public class SSAOEffect : MonoBehaviour
{
	// Token: 0x06001464 RID: 5220 RVA: 0x00025548 File Offset: 0x00023748
	private static Material CreateMaterial(Shader shader)
	{
		if (!shader)
		{
			return null;
		}
		return new Material(shader)
		{
			hideFlags = HideFlags.HideAndDontSave
		};
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x0000CA1A File Offset: 0x0000AC1A
	private static void DestroyMaterial(Material mat)
	{
		if (mat)
		{
			UnityEngine.Object.DestroyImmediate(mat);
			mat = null;
		}
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x0000CA30 File Offset: 0x0000AC30
	private void OnDisable()
	{
		SSAOEffect.DestroyMaterial(this.m_SSAOMaterial);
	}

	// Token: 0x06001467 RID: 5223 RVA: 0x00025574 File Offset: 0x00023774
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects || !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			this.m_Supported = false;
			base.enabled = false;
			return;
		}
		this.CreateMaterials();
		if (!this.m_SSAOMaterial || this.m_SSAOMaterial.passCount != 5)
		{
			this.m_Supported = false;
			base.enabled = false;
			return;
		}
		this.m_Supported = true;
	}

	// Token: 0x06001468 RID: 5224 RVA: 0x0000CA3D File Offset: 0x0000AC3D
	private void OnEnable()
	{
		base.camera.depthTextureMode |= DepthTextureMode.DepthNormals;
	}

	// Token: 0x06001469 RID: 5225 RVA: 0x000255E4 File Offset: 0x000237E4
	private void CreateMaterials()
	{
		if (!this.m_SSAOMaterial && this.m_SSAOShader.isSupported)
		{
			this.m_SSAOMaterial = SSAOEffect.CreateMaterial(this.m_SSAOShader);
			this.m_SSAOMaterial.SetTexture("_RandomTexture", this.m_RandomTexture);
		}
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x00025638 File Offset: 0x00023838
	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.m_Supported || !this.m_SSAOShader.isSupported)
		{
			base.enabled = false;
			return;
		}
		this.CreateMaterials();
		this.m_Downsampling = Mathf.Clamp(this.m_Downsampling, 1, 6);
		this.m_Radius = Mathf.Clamp(this.m_Radius, 0.05f, 1f);
		this.m_MinZ = Mathf.Clamp(this.m_MinZ, 1E-05f, 0.5f);
		this.m_OcclusionIntensity = Mathf.Clamp(this.m_OcclusionIntensity, 0.5f, 4f);
		this.m_OcclusionAttenuation = Mathf.Clamp(this.m_OcclusionAttenuation, 0.2f, 2f);
		this.m_Blur = Mathf.Clamp(this.m_Blur, 0, 4);
		RenderTexture renderTexture = RenderTexture.GetTemporary(source.width / this.m_Downsampling, source.height / this.m_Downsampling, 0);
		float fieldOfView = base.camera.fieldOfView;
		float farClipPlane = base.camera.farClipPlane;
		float num = Mathf.Tan(fieldOfView * 0.0174532924f * 0.5f) * farClipPlane;
		float x = num * base.camera.aspect;
		this.m_SSAOMaterial.SetVector("_FarCorner", new Vector3(x, num, farClipPlane));
		int num2;
		int num3;
		if (this.m_RandomTexture)
		{
			num2 = this.m_RandomTexture.width;
			num3 = this.m_RandomTexture.height;
		}
		else
		{
			num2 = 1;
			num3 = 1;
		}
		this.m_SSAOMaterial.SetVector("_NoiseScale", new Vector3((float)renderTexture.width / (float)num2, (float)renderTexture.height / (float)num3, 0f));
		this.m_SSAOMaterial.SetVector("_Params", new Vector4(this.m_Radius, this.m_MinZ, 1f / this.m_OcclusionAttenuation, this.m_OcclusionIntensity));
		bool flag = this.m_Blur > 0;
		Graphics.Blit((!flag) ? source : null, renderTexture, this.m_SSAOMaterial, (int)this.m_SampleCount);
		if (flag)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0);
			this.m_SSAOMaterial.SetVector("_TexelOffsetScale", new Vector4((float)this.m_Blur / (float)source.width, 0f, 0f, 0f));
			this.m_SSAOMaterial.SetTexture("_SSAO", renderTexture);
			Graphics.Blit(null, temporary, this.m_SSAOMaterial, 3);
			RenderTexture.ReleaseTemporary(renderTexture);
			RenderTexture temporary2 = RenderTexture.GetTemporary(source.width, source.height, 0);
			this.m_SSAOMaterial.SetVector("_TexelOffsetScale", new Vector4(0f, (float)this.m_Blur / (float)source.height, 0f, 0f));
			this.m_SSAOMaterial.SetTexture("_SSAO", temporary);
			Graphics.Blit(source, temporary2, this.m_SSAOMaterial, 3);
			RenderTexture.ReleaseTemporary(temporary);
			renderTexture = temporary2;
		}
		this.m_SSAOMaterial.SetTexture("_SSAO", renderTexture);
		Graphics.Blit(source, destination, this.m_SSAOMaterial, 4);
		RenderTexture.ReleaseTemporary(renderTexture);
	}

	// Token: 0x04000E6E RID: 3694
	public float m_Radius = 0.4f;

	// Token: 0x04000E6F RID: 3695
	public SSAOEffect.SSAOSamples m_SampleCount = SSAOEffect.SSAOSamples.Medium;

	// Token: 0x04000E70 RID: 3696
	public float m_OcclusionIntensity = 1.5f;

	// Token: 0x04000E71 RID: 3697
	public int m_Blur = 2;

	// Token: 0x04000E72 RID: 3698
	public int m_Downsampling = 2;

	// Token: 0x04000E73 RID: 3699
	public float m_OcclusionAttenuation = 1f;

	// Token: 0x04000E74 RID: 3700
	public float m_MinZ = 0.01f;

	// Token: 0x04000E75 RID: 3701
	public Shader m_SSAOShader;

	// Token: 0x04000E76 RID: 3702
	private Material m_SSAOMaterial;

	// Token: 0x04000E77 RID: 3703
	public Texture2D m_RandomTexture;

	// Token: 0x04000E78 RID: 3704
	private bool m_Supported;

	// Token: 0x02000360 RID: 864
	public enum SSAOSamples
	{
		// Token: 0x04000E7A RID: 3706
		Low,
		// Token: 0x04000E7B RID: 3707
		Medium,
		// Token: 0x04000E7C RID: 3708
		High
	}
}
