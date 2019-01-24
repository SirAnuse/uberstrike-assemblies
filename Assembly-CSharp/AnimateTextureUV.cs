using System;
using UnityEngine;

// Token: 0x0200009A RID: 154
public class AnimateTextureUV : MonoBehaviour
{
	// Token: 0x06000426 RID: 1062 RVA: 0x0002D4E8 File Offset: 0x0002B6E8
	private void Update()
	{
		int num = Mathf.RoundToInt(Time.time * (float)this.framesPerSecond);
		num %= this.uvAnimationTileX * this.uvAnimationTileY;
		Vector2 scale = new Vector2(1f / (float)this.uvAnimationTileX, 1f / (float)this.uvAnimationTileY);
		int num2 = num % this.uvAnimationTileX;
		int num3 = num / this.uvAnimationTileX;
		Vector2 offset = new Vector2((float)num2 * scale.x, 1f - scale.y - (float)num3 * scale.y);
		if (base.renderer)
		{
			base.renderer.material.SetTextureOffset("_MainTex", offset);
			base.renderer.material.SetTextureScale("_MainTex", scale);
		}
	}

	// Token: 0x040003BD RID: 957
	public int uvAnimationTileX = 1;

	// Token: 0x040003BE RID: 958
	public int uvAnimationTileY = 1;

	// Token: 0x040003BF RID: 959
	public int framesPerSecond = 10;
}
