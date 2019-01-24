using System;
using UnityEngine;

// Token: 0x02000359 RID: 857
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Glow")]
public class GlowEffect : MonoBehaviour
{
	// Token: 0x170003CE RID: 974
	// (get) Token: 0x06001446 RID: 5190 RVA: 0x0000C7E7 File Offset: 0x0000A9E7
	protected Material compositeMaterial
	{
		get
		{
			if (this.m_CompositeMaterial == null)
			{
				this.m_CompositeMaterial = new Material(this.compositeShader);
				this.m_CompositeMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_CompositeMaterial;
		}
	}

	// Token: 0x170003CF RID: 975
	// (get) Token: 0x06001447 RID: 5191 RVA: 0x0000C81E File Offset: 0x0000AA1E
	protected Material blurMaterial
	{
		get
		{
			if (this.m_BlurMaterial == null)
			{
				this.m_BlurMaterial = new Material(this.blurShader);
				this.m_BlurMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_BlurMaterial;
		}
	}

	// Token: 0x170003D0 RID: 976
	// (get) Token: 0x06001448 RID: 5192 RVA: 0x0000C855 File Offset: 0x0000AA55
	protected Material downsampleMaterial
	{
		get
		{
			if (this.m_DownsampleMaterial == null)
			{
				this.m_DownsampleMaterial = new Material(this.downsampleShader);
				this.m_DownsampleMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_DownsampleMaterial;
		}
	}

	// Token: 0x06001449 RID: 5193 RVA: 0x00024C18 File Offset: 0x00022E18
	protected void OnDisable()
	{
		if (this.m_CompositeMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.m_CompositeMaterial);
		}
		if (this.m_BlurMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.m_BlurMaterial);
		}
		if (this.m_DownsampleMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.m_DownsampleMaterial);
		}
	}

	// Token: 0x0600144A RID: 5194 RVA: 0x00024C78 File Offset: 0x00022E78
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (this.downsampleShader == null)
		{
			Debug.Log("No downsample shader assigned! Disabling glow.");
			base.enabled = false;
		}
		else
		{
			if (!this.blurMaterial.shader.isSupported)
			{
				base.enabled = false;
			}
			if (!this.compositeMaterial.shader.isSupported)
			{
				base.enabled = false;
			}
			if (!this.downsampleMaterial.shader.isSupported)
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x0600144B RID: 5195 RVA: 0x00024D14 File Offset: 0x00022F14
	public void FourTapCone(RenderTexture source, RenderTexture dest, int iteration)
	{
		float num = 0.5f + (float)iteration * this.blurSpread;
		Graphics.BlitMultiTap(source, dest, this.blurMaterial, new Vector2[]
		{
			new Vector2(num, num),
			new Vector2(-num, num),
			new Vector2(num, -num),
			new Vector2(-num, -num)
		});
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x00024D94 File Offset: 0x00022F94
	private void DownSample4x(RenderTexture source, RenderTexture dest)
	{
		this.downsampleMaterial.color = new Color(this.glowTint.r, this.glowTint.g, this.glowTint.b, this.glowTint.a / 4f);
		Graphics.Blit(source, dest, this.downsampleMaterial);
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x00024DF0 File Offset: 0x00022FF0
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		this.glowIntensity = Mathf.Clamp(this.glowIntensity, 0f, 10f);
		this.blurIterations = Mathf.Clamp(this.blurIterations, 0, 30);
		this.blurSpread = Mathf.Clamp(this.blurSpread, 0.5f, 1f);
		RenderTexture temporary = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
		RenderTexture temporary2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
		this.DownSample4x(source, temporary);
		float num = Mathf.Clamp01((this.glowIntensity - 1f) / 4f);
		this.blurMaterial.color = new Color(1f, 1f, 1f, 0.25f + num);
		bool flag = true;
		for (int i = 0; i < this.blurIterations; i++)
		{
			if (flag)
			{
				this.FourTapCone(temporary, temporary2, i);
			}
			else
			{
				this.FourTapCone(temporary2, temporary, i);
			}
			flag = !flag;
		}
		Graphics.Blit(source, destination);
		if (flag)
		{
			this.BlitGlow(temporary, destination);
		}
		else
		{
			this.BlitGlow(temporary2, destination);
		}
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}

	// Token: 0x0600144E RID: 5198 RVA: 0x0000C88C File Offset: 0x0000AA8C
	public void BlitGlow(RenderTexture source, RenderTexture dest)
	{
		this.compositeMaterial.color = new Color(1f, 1f, 1f, Mathf.Clamp01(this.glowIntensity));
		Graphics.Blit(source, dest, this.compositeMaterial);
	}

	// Token: 0x04000E4B RID: 3659
	public float glowIntensity = 1.5f;

	// Token: 0x04000E4C RID: 3660
	public int blurIterations = 3;

	// Token: 0x04000E4D RID: 3661
	public float blurSpread = 0.7f;

	// Token: 0x04000E4E RID: 3662
	public Color glowTint = new Color(1f, 1f, 1f, 0f);

	// Token: 0x04000E4F RID: 3663
	public Shader compositeShader;

	// Token: 0x04000E50 RID: 3664
	private Material m_CompositeMaterial;

	// Token: 0x04000E51 RID: 3665
	public Shader blurShader;

	// Token: 0x04000E52 RID: 3666
	private Material m_BlurMaterial;

	// Token: 0x04000E53 RID: 3667
	public Shader downsampleShader;

	// Token: 0x04000E54 RID: 3668
	private Material m_DownsampleMaterial;
}
