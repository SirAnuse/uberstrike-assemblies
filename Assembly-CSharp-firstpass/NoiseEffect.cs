using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Noise")]
[RequireComponent(typeof(Camera))]
public class NoiseEffect : MonoBehaviour
{
	// Token: 0x0600145E RID: 5214 RVA: 0x0002517C File Offset: 0x0002337C
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (this.shaderRGB == null || this.shaderYUV == null)
		{
			Debug.Log("Noise shaders are not set up! Disabling noise effect.");
			base.enabled = false;
		}
		else if (!this.shaderRGB.isSupported)
		{
			base.enabled = false;
		}
		else if (!this.shaderYUV.isSupported)
		{
			this.rgbFallback = true;
		}
	}

	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x0600145F RID: 5215 RVA: 0x00025208 File Offset: 0x00023408
	protected Material material
	{
		get
		{
			if (this.m_MaterialRGB == null)
			{
				this.m_MaterialRGB = new Material(this.shaderRGB);
				this.m_MaterialRGB.hideFlags = HideFlags.HideAndDontSave;
			}
			if (this.m_MaterialYUV == null && !this.rgbFallback)
			{
				this.m_MaterialYUV = new Material(this.shaderYUV);
				this.m_MaterialYUV.hideFlags = HideFlags.HideAndDontSave;
			}
			return (this.rgbFallback || this.monochrome) ? this.m_MaterialRGB : this.m_MaterialYUV;
		}
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x0000C9E2 File Offset: 0x0000ABE2
	protected void OnDisable()
	{
		if (this.m_MaterialRGB)
		{
			UnityEngine.Object.DestroyImmediate(this.m_MaterialRGB);
		}
		if (this.m_MaterialYUV)
		{
			UnityEngine.Object.DestroyImmediate(this.m_MaterialYUV);
		}
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x000252A8 File Offset: 0x000234A8
	private void SanitizeParameters()
	{
		this.grainIntensityMin = Mathf.Clamp(this.grainIntensityMin, 0f, 5f);
		this.grainIntensityMax = Mathf.Clamp(this.grainIntensityMax, 0f, 5f);
		this.scratchIntensityMin = Mathf.Clamp(this.scratchIntensityMin, 0f, 5f);
		this.scratchIntensityMax = Mathf.Clamp(this.scratchIntensityMax, 0f, 5f);
		this.scratchFPS = Mathf.Clamp(this.scratchFPS, 1f, 30f);
		this.scratchJitter = Mathf.Clamp(this.scratchJitter, 0f, 1f);
		this.grainSize = Mathf.Clamp(this.grainSize, 0.1f, 50f);
	}

	// Token: 0x06001462 RID: 5218 RVA: 0x00025374 File Offset: 0x00023574
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.SanitizeParameters();
		if (this.scratchTimeLeft <= 0f)
		{
			this.scratchTimeLeft = UnityEngine.Random.value * 2f / this.scratchFPS;
			this.scratchX = UnityEngine.Random.value;
			this.scratchY = UnityEngine.Random.value;
		}
		this.scratchTimeLeft -= Time.deltaTime;
		Material material = this.material;
		material.SetTexture("_GrainTex", this.grainTexture);
		material.SetTexture("_ScratchTex", this.scratchTexture);
		float num = 1f / this.grainSize;
		material.SetVector("_GrainOffsetScale", new Vector4(UnityEngine.Random.value, UnityEngine.Random.value, (float)Screen.width / (float)this.grainTexture.width * num, (float)Screen.height / (float)this.grainTexture.height * num));
		material.SetVector("_ScratchOffsetScale", new Vector4(this.scratchX + UnityEngine.Random.value * this.scratchJitter, this.scratchY + UnityEngine.Random.value * this.scratchJitter, (float)Screen.width / (float)this.scratchTexture.width, (float)Screen.height / (float)this.scratchTexture.height));
		material.SetVector("_Intensity", new Vector4(UnityEngine.Random.Range(this.grainIntensityMin, this.grainIntensityMax), UnityEngine.Random.Range(this.scratchIntensityMin, this.scratchIntensityMax), 0f, 0f));
		Graphics.Blit(source, destination, material);
	}

	// Token: 0x04000E5C RID: 3676
	public bool monochrome = true;

	// Token: 0x04000E5D RID: 3677
	private bool rgbFallback;

	// Token: 0x04000E5E RID: 3678
	public float grainIntensityMin = 0.1f;

	// Token: 0x04000E5F RID: 3679
	public float grainIntensityMax = 0.2f;

	// Token: 0x04000E60 RID: 3680
	public float grainSize = 2f;

	// Token: 0x04000E61 RID: 3681
	public float scratchIntensityMin = 0.05f;

	// Token: 0x04000E62 RID: 3682
	public float scratchIntensityMax = 0.25f;

	// Token: 0x04000E63 RID: 3683
	public float scratchFPS = 10f;

	// Token: 0x04000E64 RID: 3684
	public float scratchJitter = 0.01f;

	// Token: 0x04000E65 RID: 3685
	public Texture grainTexture;

	// Token: 0x04000E66 RID: 3686
	public Texture scratchTexture;

	// Token: 0x04000E67 RID: 3687
	public Shader shaderRGB;

	// Token: 0x04000E68 RID: 3688
	public Shader shaderYUV;

	// Token: 0x04000E69 RID: 3689
	private Material m_MaterialRGB;

	// Token: 0x04000E6A RID: 3690
	private Material m_MaterialYUV;

	// Token: 0x04000E6B RID: 3691
	private float scratchTimeLeft;

	// Token: 0x04000E6C RID: 3692
	private float scratchX;

	// Token: 0x04000E6D RID: 3693
	private float scratchY;
}
