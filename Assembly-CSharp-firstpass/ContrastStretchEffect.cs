using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
[AddComponentMenu("Image Effects/Contrast Stretch")]
[ExecuteInEditMode]
public class ContrastStretchEffect : MonoBehaviour
{
	// Token: 0x170003CA RID: 970
	// (get) Token: 0x0600143A RID: 5178 RVA: 0x0000C6CC File Offset: 0x0000A8CC
	protected Material materialLum
	{
		get
		{
			if (this.m_materialLum == null)
			{
				this.m_materialLum = new Material(this.shaderLum);
				this.m_materialLum.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_materialLum;
		}
	}

	// Token: 0x170003CB RID: 971
	// (get) Token: 0x0600143B RID: 5179 RVA: 0x0000C703 File Offset: 0x0000A903
	protected Material materialReduce
	{
		get
		{
			if (this.m_materialReduce == null)
			{
				this.m_materialReduce = new Material(this.shaderReduce);
				this.m_materialReduce.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_materialReduce;
		}
	}

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x0600143C RID: 5180 RVA: 0x0000C73A File Offset: 0x0000A93A
	protected Material materialAdapt
	{
		get
		{
			if (this.m_materialAdapt == null)
			{
				this.m_materialAdapt = new Material(this.shaderAdapt);
				this.m_materialAdapt.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_materialAdapt;
		}
	}

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x0600143D RID: 5181 RVA: 0x0000C771 File Offset: 0x0000A971
	protected Material materialApply
	{
		get
		{
			if (this.m_materialApply == null)
			{
				this.m_materialApply = new Material(this.shaderApply);
				this.m_materialApply.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_materialApply;
		}
	}

	// Token: 0x0600143E RID: 5182 RVA: 0x000248E8 File Offset: 0x00022AE8
	private void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (!this.shaderAdapt.isSupported || !this.shaderApply.isSupported || !this.shaderLum.isSupported || !this.shaderReduce.isSupported)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600143F RID: 5183 RVA: 0x00024950 File Offset: 0x00022B50
	private void OnEnable()
	{
		for (int i = 0; i < 2; i++)
		{
			if (!this.adaptRenderTex[i])
			{
				this.adaptRenderTex[i] = new RenderTexture(1, 1, 32);
				this.adaptRenderTex[i].hideFlags = HideFlags.HideAndDontSave;
			}
		}
	}

	// Token: 0x06001440 RID: 5184 RVA: 0x000249A4 File Offset: 0x00022BA4
	private void OnDisable()
	{
		for (int i = 0; i < 2; i++)
		{
			UnityEngine.Object.DestroyImmediate(this.adaptRenderTex[i]);
			this.adaptRenderTex[i] = null;
		}
		if (this.m_materialLum)
		{
			UnityEngine.Object.DestroyImmediate(this.m_materialLum);
		}
		if (this.m_materialReduce)
		{
			UnityEngine.Object.DestroyImmediate(this.m_materialReduce);
		}
		if (this.m_materialAdapt)
		{
			UnityEngine.Object.DestroyImmediate(this.m_materialAdapt);
		}
		if (this.m_materialApply)
		{
			UnityEngine.Object.DestroyImmediate(this.m_materialApply);
		}
	}

	// Token: 0x06001441 RID: 5185 RVA: 0x00024A48 File Offset: 0x00022C48
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		RenderTexture renderTexture = RenderTexture.GetTemporary(source.width / 1, source.height / 1);
		Graphics.Blit(source, renderTexture, this.materialLum);
		while (renderTexture.width > 1 || renderTexture.height > 1)
		{
			int num = renderTexture.width / 2;
			if (num < 1)
			{
				num = 1;
			}
			int num2 = renderTexture.height / 2;
			if (num2 < 1)
			{
				num2 = 1;
			}
			RenderTexture temporary = RenderTexture.GetTemporary(num, num2);
			Graphics.Blit(renderTexture, temporary, this.materialReduce);
			RenderTexture.ReleaseTemporary(renderTexture);
			renderTexture = temporary;
		}
		this.CalculateAdaptation(renderTexture);
		this.materialApply.SetTexture("_AdaptTex", this.adaptRenderTex[this.curAdaptIndex]);
		Graphics.Blit(source, destination, this.materialApply);
		RenderTexture.ReleaseTemporary(renderTexture);
	}

	// Token: 0x06001442 RID: 5186 RVA: 0x00024B18 File Offset: 0x00022D18
	private void CalculateAdaptation(Texture curTexture)
	{
		int num = this.curAdaptIndex;
		this.curAdaptIndex = (this.curAdaptIndex + 1) % 2;
		float num2 = 1f - Mathf.Pow(1f - this.adaptationSpeed, 30f * Time.deltaTime);
		num2 = Mathf.Clamp(num2, 0.01f, 1f);
		this.materialAdapt.SetTexture("_CurTex", curTexture);
		this.materialAdapt.SetVector("_AdaptParams", new Vector4(num2, this.limitMinimum, this.limitMaximum, 0f));
		Graphics.Blit(this.adaptRenderTex[num], this.adaptRenderTex[this.curAdaptIndex], this.materialAdapt);
	}

	// Token: 0x04000E3D RID: 3645
	public float adaptationSpeed = 0.02f;

	// Token: 0x04000E3E RID: 3646
	public float limitMinimum = 0.2f;

	// Token: 0x04000E3F RID: 3647
	public float limitMaximum = 0.6f;

	// Token: 0x04000E40 RID: 3648
	private RenderTexture[] adaptRenderTex = new RenderTexture[2];

	// Token: 0x04000E41 RID: 3649
	private int curAdaptIndex;

	// Token: 0x04000E42 RID: 3650
	public Shader shaderLum;

	// Token: 0x04000E43 RID: 3651
	private Material m_materialLum;

	// Token: 0x04000E44 RID: 3652
	public Shader shaderReduce;

	// Token: 0x04000E45 RID: 3653
	private Material m_materialReduce;

	// Token: 0x04000E46 RID: 3654
	public Shader shaderAdapt;

	// Token: 0x04000E47 RID: 3655
	private Material m_materialAdapt;

	// Token: 0x04000E48 RID: 3656
	public Shader shaderApply;

	// Token: 0x04000E49 RID: 3657
	private Material m_materialApply;
}
