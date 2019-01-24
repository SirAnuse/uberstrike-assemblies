using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public class ImageEffectBase : MonoBehaviour
{
	// Token: 0x06001452 RID: 5202 RVA: 0x0000C900 File Offset: 0x0000AB00
	protected virtual void Start()
	{
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
		if (!this.shader || !this.shader.isSupported)
		{
			base.enabled = false;
		}
	}

	// Token: 0x170003D1 RID: 977
	// (get) Token: 0x06001453 RID: 5203 RVA: 0x0000C93B File Offset: 0x0000AB3B
	protected Material material
	{
		get
		{
			if (this.m_Material == null)
			{
				this.m_Material = new Material(this.shader);
				this.m_Material.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.m_Material;
		}
	}

	// Token: 0x06001454 RID: 5204 RVA: 0x0000C972 File Offset: 0x0000AB72
	protected virtual void OnDisable()
	{
		if (this.m_Material)
		{
			UnityEngine.Object.DestroyImmediate(this.m_Material);
		}
	}

	// Token: 0x04000E57 RID: 3671
	public Shader shader;

	// Token: 0x04000E58 RID: 3672
	private Material m_Material;
}
