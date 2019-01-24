using System;
using UnityEngine;

// Token: 0x0200036C RID: 876
[ExecuteInEditMode]
public class WaterBase : MonoBehaviour
{
	// Token: 0x06001499 RID: 5273 RVA: 0x00026F60 File Offset: 0x00025160
	public void UpdateShader()
	{
		if (this.waterQuality > WaterQuality.Medium)
		{
			this.sharedMaterial.shader.maximumLOD = 501;
		}
		else if (this.waterQuality > WaterQuality.Low)
		{
			this.sharedMaterial.shader.maximumLOD = 301;
		}
		else
		{
			this.sharedMaterial.shader.maximumLOD = 201;
		}
		if (!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			this.edgeBlend = false;
		}
		if (this.edgeBlend)
		{
			Shader.EnableKeyword("WATER_EDGEBLEND_ON");
			Shader.DisableKeyword("WATER_EDGEBLEND_OFF");
			if (Camera.main)
			{
				Camera.main.depthTextureMode |= DepthTextureMode.Depth;
			}
		}
		else
		{
			Shader.EnableKeyword("WATER_EDGEBLEND_OFF");
			Shader.DisableKeyword("WATER_EDGEBLEND_ON");
		}
	}

	// Token: 0x0600149A RID: 5274 RVA: 0x0000CD2D File Offset: 0x0000AF2D
	public void WaterTileBeingRendered(Transform tr, Camera currentCam)
	{
		if (currentCam && this.edgeBlend)
		{
			currentCam.depthTextureMode |= DepthTextureMode.Depth;
		}
	}

	// Token: 0x0600149B RID: 5275 RVA: 0x0000CD53 File Offset: 0x0000AF53
	public void Update()
	{
		if (this.sharedMaterial)
		{
			this.UpdateShader();
		}
	}

	// Token: 0x04000EA7 RID: 3751
	public Material sharedMaterial;

	// Token: 0x04000EA8 RID: 3752
	public WaterQuality waterQuality = WaterQuality.High;

	// Token: 0x04000EA9 RID: 3753
	public bool edgeBlend = true;
}
