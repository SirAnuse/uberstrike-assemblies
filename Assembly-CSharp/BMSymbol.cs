using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
[Serializable]
public class BMSymbol
{
	// Token: 0x17000028 RID: 40
	// (get) Token: 0x0600016B RID: 363 RVA: 0x00003247 File Offset: 0x00001447
	public int length
	{
		get
		{
			if (this.mLength == 0)
			{
				this.mLength = this.sequence.Length;
			}
			return this.mLength;
		}
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x0600016C RID: 364 RVA: 0x0000326B File Offset: 0x0000146B
	public int offsetX
	{
		get
		{
			return this.mOffsetX;
		}
	}

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x0600016D RID: 365 RVA: 0x00003273 File Offset: 0x00001473
	public int offsetY
	{
		get
		{
			return this.mOffsetY;
		}
	}

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x0600016E RID: 366 RVA: 0x0000327B File Offset: 0x0000147B
	public int width
	{
		get
		{
			return this.mWidth;
		}
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x0600016F RID: 367 RVA: 0x00003283 File Offset: 0x00001483
	public int height
	{
		get
		{
			return this.mHeight;
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x06000170 RID: 368 RVA: 0x0000328B File Offset: 0x0000148B
	public int advance
	{
		get
		{
			return this.mAdvance;
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x06000171 RID: 369 RVA: 0x00003293 File Offset: 0x00001493
	public Rect uvRect
	{
		get
		{
			return this.mUV;
		}
	}

	// Token: 0x06000172 RID: 370 RVA: 0x0000329B File Offset: 0x0000149B
	public void MarkAsDirty()
	{
		this.mIsValid = false;
	}

	// Token: 0x06000173 RID: 371 RVA: 0x0001CBA0 File Offset: 0x0001ADA0
	public bool Validate(UIAtlas atlas)
	{
		if (atlas == null)
		{
			return false;
		}
		if (!this.mIsValid)
		{
			if (string.IsNullOrEmpty(this.spriteName))
			{
				return false;
			}
			this.mSprite = ((!(atlas != null)) ? null : atlas.GetSprite(this.spriteName));
			if (this.mSprite != null)
			{
				Texture texture = atlas.texture;
				if (texture == null)
				{
					this.mSprite = null;
				}
				else
				{
					Rect rect = this.mSprite.outer;
					this.mUV = rect;
					if (atlas.coordinates == UIAtlas.Coordinates.Pixels)
					{
						this.mUV = NGUIMath.ConvertToTexCoords(this.mUV, texture.width, texture.height);
					}
					else
					{
						rect = NGUIMath.ConvertToPixels(rect, texture.width, texture.height, true);
					}
					this.mOffsetX = Mathf.RoundToInt(this.mSprite.paddingLeft * rect.width);
					this.mOffsetY = Mathf.RoundToInt(this.mSprite.paddingTop * rect.width);
					this.mWidth = Mathf.RoundToInt(rect.width);
					this.mHeight = Mathf.RoundToInt(rect.height);
					this.mAdvance = Mathf.RoundToInt(rect.width + (this.mSprite.paddingRight + this.mSprite.paddingLeft) * rect.width);
					this.mIsValid = true;
				}
			}
		}
		return this.mSprite != null;
	}

	// Token: 0x040001A3 RID: 419
	public string sequence;

	// Token: 0x040001A4 RID: 420
	public string spriteName;

	// Token: 0x040001A5 RID: 421
	private UIAtlas.Sprite mSprite;

	// Token: 0x040001A6 RID: 422
	private bool mIsValid;

	// Token: 0x040001A7 RID: 423
	private int mLength;

	// Token: 0x040001A8 RID: 424
	private int mOffsetX;

	// Token: 0x040001A9 RID: 425
	private int mOffsetY;

	// Token: 0x040001AA RID: 426
	private int mWidth;

	// Token: 0x040001AB RID: 427
	private int mHeight;

	// Token: 0x040001AC RID: 428
	private int mAdvance;

	// Token: 0x040001AD RID: 429
	private Rect mUV;
}
