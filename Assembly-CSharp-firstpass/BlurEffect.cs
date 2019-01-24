using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Blur")]
public class BlurEffect : MonoBehaviour
{
	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x06001431 RID: 5169 RVA: 0x0000C61D File Offset: 0x0000A81D
	protected Material material
	{
		get
		{
			if (BlurEffect.m_Material == null)
			{
				BlurEffect.m_Material = new Material(this.blurShader);
				BlurEffect.m_Material.hideFlags = HideFlags.DontSave;
			}
			return BlurEffect.m_Material;
		}
	}

	// Token: 0x06001432 RID: 5170 RVA: 0x0000C64F File Offset: 0x0000A84F
	protected void OnDisable()
	{
		if (BlurEffect.m_Material)
		{
			UnityEngine.Object.DestroyImmediate(BlurEffect.m_Material);
		}
	}

	// Token: 0x06001433 RID: 5171 RVA: 0x00024700 File Offset: 0x00022900
	protected void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (!this.blurShader || !this.material.shader.isSupported)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001434 RID: 5172 RVA: 0x0002474C File Offset: 0x0002294C
	public void FourTapCone(RenderTexture source, RenderTexture dest, int iteration)
	{
		float num = 0.5f + (float)iteration * this.blurSpread;
		Graphics.BlitMultiTap(source, dest, this.material, new Vector2[]
		{
			new Vector2(-num, -num),
			new Vector2(-num, num),
			new Vector2(num, num),
			new Vector2(num, -num)
		});
	}

	// Token: 0x06001435 RID: 5173 RVA: 0x000247CC File Offset: 0x000229CC
	private void DownSample4x(RenderTexture source, RenderTexture dest)
	{
		float num = 1f;
		Graphics.BlitMultiTap(source, dest, this.material, new Vector2[]
		{
			new Vector2(-num, -num),
			new Vector2(-num, num),
			new Vector2(num, num),
			new Vector2(num, -num)
		});
	}

	// Token: 0x06001436 RID: 5174 RVA: 0x00024844 File Offset: 0x00022A44
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
		RenderTexture temporary2 = RenderTexture.GetTemporary(source.width / 4, source.height / 4, 0);
		this.DownSample4x(source, temporary);
		bool flag = true;
		for (int i = 0; i < this.iterations; i++)
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
		if (flag)
		{
			Graphics.Blit(temporary, destination);
		}
		else
		{
			Graphics.Blit(temporary2, destination);
		}
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}

	// Token: 0x04000E38 RID: 3640
	public int iterations = 3;

	// Token: 0x04000E39 RID: 3641
	public float blurSpread = 0.6f;

	// Token: 0x04000E3A RID: 3642
	public Shader blurShader;

	// Token: 0x04000E3B RID: 3643
	private static Material m_Material;
}
