using System;
using UnityEngine;

// Token: 0x0200035C RID: 860
[AddComponentMenu("")]
public class ImageEffects
{
	// Token: 0x06001456 RID: 5206 RVA: 0x00024F2C File Offset: 0x0002312C
	public static void RenderDistortion(Material material, RenderTexture source, RenderTexture destination, float angle, Vector2 center, Vector2 radius)
	{
		bool flag = source.texelSize.y < 0f;
		if (flag)
		{
			center.y = 1f - center.y;
			angle = -angle;
		}
		Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, angle), Vector3.one);
		material.SetMatrix("_RotationMatrix", matrix);
		material.SetVector("_CenterRadius", new Vector4(center.x, center.y, radius.x, radius.y));
		material.SetFloat("_Angle", angle * 0.0174532924f);
		Graphics.Blit(source, destination, material);
	}

	// Token: 0x06001457 RID: 5207 RVA: 0x0000C98F File Offset: 0x0000AB8F
	[Obsolete("Use Graphics.Blit(source,dest) instead")]
	public static void Blit(RenderTexture source, RenderTexture dest)
	{
		Graphics.Blit(source, dest);
	}

	// Token: 0x06001458 RID: 5208 RVA: 0x0000C998 File Offset: 0x0000AB98
	[Obsolete("Use Graphics.Blit(source, destination, material) instead")]
	public static void BlitWithMaterial(Material material, RenderTexture source, RenderTexture dest)
	{
		Graphics.Blit(source, dest, material);
	}
}
