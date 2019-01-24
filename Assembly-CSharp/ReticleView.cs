using System;
using System.Collections.Generic;
using AnimationOrTween;
using UnityEngine;

// Token: 0x0200033F RID: 831
public class ReticleView : MonoBehaviour
{
	// Token: 0x06001723 RID: 5923 RVA: 0x0000F915 File Offset: 0x0000DB15
	private void Awake()
	{
		this.sprites = new List<UISprite>(base.gameObject.GetComponentsInChildren<UISprite>());
		this.tweens = new List<UITweener>(base.GetComponentsInChildren<UITweener>());
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x0000F93E File Offset: 0x0000DB3E
	public void Shoot()
	{
		this.tweens.ForEach(delegate(UITweener el)
		{
			if (el.direction == Direction.Reverse)
			{
				el.Toggle();
			}
			else
			{
				el.Play(true);
			}
		});
	}

	// Token: 0x06001725 RID: 5925 RVA: 0x0007F6C0 File Offset: 0x0007D8C0
	public void SetColor(Color color)
	{
		this.sprites.ForEach(delegate(UISprite el)
		{
			if (el)
			{
				el.color = color;
			}
		});
	}

	// Token: 0x04001615 RID: 5653
	private List<UISprite> sprites = new List<UISprite>();

	// Token: 0x04001616 RID: 5654
	private List<UITweener> tweens = new List<UITweener>();
}
