using System;
using UnityEngine;

// Token: 0x0200002A RID: 42
[AddComponentMenu("NGUI/UI/Image Button")]
[ExecuteInEditMode]
public class UIImageButton : MonoBehaviour
{
	// Token: 0x1700000F RID: 15
	// (get) Token: 0x060000D9 RID: 217 RVA: 0x000160E4 File Offset: 0x000142E4
	// (set) Token: 0x060000DA RID: 218 RVA: 0x00019A28 File Offset: 0x00017C28
	public bool isEnabled
	{
		get
		{
			Collider collider = base.collider;
			return collider && collider.enabled;
		}
		set
		{
			Collider collider = base.collider;
			if (!collider)
			{
				return;
			}
			if (collider.enabled != value)
			{
				collider.enabled = value;
				this.UpdateImage();
			}
		}
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00002D4F File Offset: 0x00000F4F
	private void Awake()
	{
		if (this.target == null)
		{
			this.target = base.GetComponentInChildren<UISprite>();
		}
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00002D6E File Offset: 0x00000F6E
	private void OnEnable()
	{
		this.UpdateImage();
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00019A64 File Offset: 0x00017C64
	private void UpdateImage()
	{
		if (this.target != null)
		{
			if (this.isEnabled)
			{
				this.target.spriteName = ((!UICamera.IsHighlighted(base.gameObject)) ? this.normalSprite : this.hoverSprite);
			}
			else
			{
				this.target.spriteName = this.disabledSprite;
			}
			this.target.MakePixelPerfect();
		}
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00019ADC File Offset: 0x00017CDC
	private void OnHover(bool isOver)
	{
		if (this.isEnabled && this.target != null)
		{
			this.target.spriteName = ((!isOver) ? this.normalSprite : this.hoverSprite);
			this.target.MakePixelPerfect();
		}
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00019B34 File Offset: 0x00017D34
	private void OnPress(bool pressed)
	{
		if (pressed)
		{
			this.target.spriteName = this.pressedSprite;
			this.target.MakePixelPerfect();
			if (this.OnPressed != null)
			{
				this.OnPressed();
			}
		}
		else
		{
			this.UpdateImage();
			if (this.OnRelease != null)
			{
				this.OnRelease();
			}
		}
	}

	// Token: 0x0400010A RID: 266
	public UISprite target;

	// Token: 0x0400010B RID: 267
	public string normalSprite;

	// Token: 0x0400010C RID: 268
	public string hoverSprite;

	// Token: 0x0400010D RID: 269
	public string pressedSprite;

	// Token: 0x0400010E RID: 270
	public string disabledSprite;

	// Token: 0x0400010F RID: 271
	public Action OnPressed;

	// Token: 0x04000110 RID: 272
	public Action OnRelease;
}
