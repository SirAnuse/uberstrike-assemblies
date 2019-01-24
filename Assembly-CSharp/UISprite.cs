﻿using System;
using UnityEngine;

// Token: 0x0200008D RID: 141
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Sprite")]
public class UISprite : UIWidget
{
	// Token: 0x170000AF RID: 175
	// (get) Token: 0x060003CD RID: 973 RVA: 0x00004D7C File Offset: 0x00002F7C
	// (set) Token: 0x060003CE RID: 974 RVA: 0x00004D84 File Offset: 0x00002F84
	public virtual UISprite.Type type
	{
		get
		{
			return this.mType;
		}
		set
		{
			if (this.mType != value)
			{
				this.mType = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170000B0 RID: 176
	// (get) Token: 0x060003CF RID: 975 RVA: 0x00004D9F File Offset: 0x00002F9F
	// (set) Token: 0x060003D0 RID: 976 RVA: 0x00029978 File Offset: 0x00027B78
	public UIAtlas atlas
	{
		get
		{
			return this.mAtlas;
		}
		set
		{
			if (this.mAtlas != value)
			{
				this.mAtlas = value;
				this.mSpriteSet = false;
				this.mSprite = null;
				this.material = ((!(this.mAtlas != null)) ? null : this.mAtlas.spriteMaterial);
				if (string.IsNullOrEmpty(this.mSpriteName) && this.mAtlas != null && this.mAtlas.spriteList.Count > 0)
				{
					this.SetAtlasSprite(this.mAtlas.spriteList[0]);
					this.mSpriteName = this.mSprite.name;
				}
				if (!string.IsNullOrEmpty(this.mSpriteName))
				{
					string spriteName = this.mSpriteName;
					this.mSpriteName = string.Empty;
					this.spriteName = spriteName;
					this.mChanged = true;
					this.UpdateUVs(true);
				}
			}
		}
	}

	// Token: 0x170000B1 RID: 177
	// (get) Token: 0x060003D1 RID: 977 RVA: 0x00004DA7 File Offset: 0x00002FA7
	// (set) Token: 0x060003D2 RID: 978 RVA: 0x00029A6C File Offset: 0x00027C6C
	public string spriteName
	{
		get
		{
			return this.mSpriteName;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				if (string.IsNullOrEmpty(this.mSpriteName))
				{
					return;
				}
				this.mSpriteName = string.Empty;
				this.mSprite = null;
				this.mChanged = true;
				this.mSpriteSet = false;
			}
			else if (this.mSpriteName != value)
			{
				this.mSpriteName = value;
				this.mSprite = null;
				this.mChanged = true;
				this.mSpriteSet = false;
				if (this.isValid)
				{
					this.UpdateUVs(true);
				}
			}
		}
	}

	// Token: 0x170000B2 RID: 178
	// (get) Token: 0x060003D3 RID: 979 RVA: 0x00004DAF File Offset: 0x00002FAF
	public bool isValid
	{
		get
		{
			return this.GetAtlasSprite() != null;
		}
	}

	// Token: 0x170000B3 RID: 179
	// (get) Token: 0x060003D4 RID: 980 RVA: 0x00029AFC File Offset: 0x00027CFC
	public override Material material
	{
		get
		{
			Material material = base.material;
			if (material == null)
			{
				material = ((!(this.mAtlas != null)) ? null : this.mAtlas.spriteMaterial);
				this.mSprite = null;
				this.material = material;
				if (material != null)
				{
					this.UpdateUVs(true);
				}
			}
			return material;
		}
	}

	// Token: 0x170000B4 RID: 180
	// (get) Token: 0x060003D5 RID: 981 RVA: 0x00004DBD File Offset: 0x00002FBD
	public Rect innerUV
	{
		get
		{
			this.UpdateUVs(false);
			return this.mInnerUV;
		}
	}

	// Token: 0x170000B5 RID: 181
	// (get) Token: 0x060003D6 RID: 982 RVA: 0x00004DCC File Offset: 0x00002FCC
	public Rect outerUV
	{
		get
		{
			this.UpdateUVs(false);
			return this.mOuterUV;
		}
	}

	// Token: 0x170000B6 RID: 182
	// (get) Token: 0x060003D7 RID: 983 RVA: 0x00004DDB File Offset: 0x00002FDB
	// (set) Token: 0x060003D8 RID: 984 RVA: 0x00004DE3 File Offset: 0x00002FE3
	public bool fillCenter
	{
		get
		{
			return this.mFillCenter;
		}
		set
		{
			if (this.mFillCenter != value)
			{
				this.mFillCenter = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170000B7 RID: 183
	// (get) Token: 0x060003D9 RID: 985 RVA: 0x00004DFE File Offset: 0x00002FFE
	// (set) Token: 0x060003DA RID: 986 RVA: 0x00004E06 File Offset: 0x00003006
	public UISprite.FillDirection fillDirection
	{
		get
		{
			return this.mFillDirection;
		}
		set
		{
			if (this.mFillDirection != value)
			{
				this.mFillDirection = value;
				this.mChanged = true;
			}
		}
	}

	// Token: 0x170000B8 RID: 184
	// (get) Token: 0x060003DB RID: 987 RVA: 0x00004E22 File Offset: 0x00003022
	// (set) Token: 0x060003DC RID: 988 RVA: 0x00029B64 File Offset: 0x00027D64
	public float fillAmount
	{
		get
		{
			return this.mFillAmount;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mFillAmount != num)
			{
				this.mFillAmount = num;
				this.mChanged = true;
			}
		}
	}

	// Token: 0x170000B9 RID: 185
	// (get) Token: 0x060003DD RID: 989 RVA: 0x00004E2A File Offset: 0x0000302A
	// (set) Token: 0x060003DE RID: 990 RVA: 0x00004E32 File Offset: 0x00003032
	public bool invert
	{
		get
		{
			return this.mInvert;
		}
		set
		{
			if (this.mInvert != value)
			{
				this.mInvert = value;
				this.mChanged = true;
			}
		}
	}

	// Token: 0x170000BA RID: 186
	// (get) Token: 0x060003DF RID: 991 RVA: 0x00029B94 File Offset: 0x00027D94
	public override Vector4 relativePadding
	{
		get
		{
			if (this.isValid && this.type == UISprite.Type.Simple)
			{
				return new Vector4(this.mSprite.paddingLeft, this.mSprite.paddingTop, this.mSprite.paddingRight, this.mSprite.paddingBottom);
			}
			return base.relativePadding;
		}
	}

	// Token: 0x170000BB RID: 187
	// (get) Token: 0x060003E0 RID: 992 RVA: 0x00029BF0 File Offset: 0x00027DF0
	public override Vector4 border
	{
		get
		{
			if (this.type != UISprite.Type.Sliced)
			{
				return base.border;
			}
			UIAtlas.Sprite atlasSprite = this.GetAtlasSprite();
			if (atlasSprite == null)
			{
				return Vector2.zero;
			}
			Rect rect = atlasSprite.outer;
			Rect rect2 = atlasSprite.inner;
			Texture mainTexture = this.mainTexture;
			if (this.atlas.coordinates == UIAtlas.Coordinates.TexCoords && mainTexture != null)
			{
				rect = NGUIMath.ConvertToPixels(rect, mainTexture.width, mainTexture.height, true);
				rect2 = NGUIMath.ConvertToPixels(rect2, mainTexture.width, mainTexture.height, true);
			}
			return new Vector4(rect2.xMin - rect.xMin, rect2.yMin - rect.yMin, rect.xMax - rect2.xMax, rect.yMax - rect2.yMax) * this.atlas.pixelSize;
		}
	}

	// Token: 0x170000BC RID: 188
	// (get) Token: 0x060003E1 RID: 993 RVA: 0x00004E4E File Offset: 0x0000304E
	public override bool pixelPerfectAfterResize
	{
		get
		{
			return this.type == UISprite.Type.Sliced;
		}
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x00029CD4 File Offset: 0x00027ED4
	public UIAtlas.Sprite GetAtlasSprite()
	{
		if (!this.mSpriteSet)
		{
			this.mSprite = null;
		}
		if (this.mSprite == null && this.mAtlas != null)
		{
			if (!string.IsNullOrEmpty(this.mSpriteName))
			{
				UIAtlas.Sprite sprite = this.mAtlas.GetSprite(this.mSpriteName);
				if (sprite == null)
				{
					return null;
				}
				this.SetAtlasSprite(sprite);
			}
			if (this.mSprite == null && this.mAtlas.spriteList.Count > 0)
			{
				UIAtlas.Sprite sprite2 = this.mAtlas.spriteList[0];
				if (sprite2 == null)
				{
					return null;
				}
				this.SetAtlasSprite(sprite2);
				if (this.mSprite == null)
				{
					Debug.LogError(this.mAtlas.name + " seems to have a null sprite!");
					return null;
				}
				this.mSpriteName = this.mSprite.name;
			}
			if (this.mSprite != null)
			{
				this.material = this.mAtlas.spriteMaterial;
				this.UpdateUVs(true);
			}
		}
		return this.mSprite;
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00029DE4 File Offset: 0x00027FE4
	protected void SetAtlasSprite(UIAtlas.Sprite sp)
	{
		this.mChanged = true;
		this.mSpriteSet = true;
		if (sp != null)
		{
			this.mSprite = sp;
			this.mSpriteName = this.mSprite.name;
		}
		else
		{
			this.mSpriteName = ((this.mSprite == null) ? string.Empty : this.mSprite.name);
			this.mSprite = sp;
		}
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x00029E50 File Offset: 0x00028050
	public virtual void UpdateUVs(bool force)
	{
		if ((this.type == UISprite.Type.Sliced || this.type == UISprite.Type.Tiled) && base.cachedTransform.localScale != this.mScale)
		{
			this.mScale = base.cachedTransform.localScale;
			this.mChanged = true;
		}
		if (this.isValid && force)
		{
			Texture mainTexture = this.mainTexture;
			if (mainTexture != null)
			{
				this.mInner = this.mSprite.inner;
				this.mOuter = this.mSprite.outer;
				this.mInnerUV = this.mInner;
				this.mOuterUV = this.mOuter;
				if (this.atlas.coordinates == UIAtlas.Coordinates.Pixels)
				{
					this.mOuterUV = NGUIMath.ConvertToTexCoords(this.mOuterUV, mainTexture.width, mainTexture.height);
					this.mInnerUV = NGUIMath.ConvertToTexCoords(this.mInnerUV, mainTexture.width, mainTexture.height);
				}
			}
		}
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x00029F50 File Offset: 0x00028150
	public override void MakePixelPerfect()
	{
		if (!this.isValid)
		{
			return;
		}
		this.UpdateUVs(false);
		UISprite.Type type = this.type;
		if (type == UISprite.Type.Sliced)
		{
			Vector3 localPosition = base.cachedTransform.localPosition;
			localPosition.x = (float)Mathf.RoundToInt(localPosition.x);
			localPosition.y = (float)Mathf.RoundToInt(localPosition.y);
			localPosition.z = (float)Mathf.RoundToInt(localPosition.z);
			base.cachedTransform.localPosition = localPosition;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = (float)(Mathf.RoundToInt(localScale.x * 0.5f) << 1);
			localScale.y = (float)(Mathf.RoundToInt(localScale.y * 0.5f) << 1);
			localScale.z = 1f;
			base.cachedTransform.localScale = localScale;
		}
		else if (type == UISprite.Type.Tiled)
		{
			Vector3 localPosition2 = base.cachedTransform.localPosition;
			localPosition2.x = (float)Mathf.RoundToInt(localPosition2.x);
			localPosition2.y = (float)Mathf.RoundToInt(localPosition2.y);
			localPosition2.z = (float)Mathf.RoundToInt(localPosition2.z);
			base.cachedTransform.localPosition = localPosition2;
			Vector3 localScale2 = base.cachedTransform.localScale;
			localScale2.x = (float)Mathf.RoundToInt(localScale2.x);
			localScale2.y = (float)Mathf.RoundToInt(localScale2.y);
			localScale2.z = 1f;
			base.cachedTransform.localScale = localScale2;
		}
		else
		{
			Texture mainTexture = this.mainTexture;
			Vector3 localScale3 = base.cachedTransform.localScale;
			if (mainTexture != null)
			{
				Rect rect = NGUIMath.ConvertToPixels(this.outerUV, mainTexture.width, mainTexture.height, true);
				float pixelSize = this.atlas.pixelSize;
				localScale3.x = (float)Mathf.RoundToInt(rect.width * pixelSize) * Mathf.Sign(localScale3.x);
				localScale3.y = (float)Mathf.RoundToInt(rect.height * pixelSize) * Mathf.Sign(localScale3.y);
				localScale3.z = 1f;
				base.cachedTransform.localScale = localScale3;
			}
			int num = Mathf.RoundToInt(Mathf.Abs(localScale3.x) * (1f + this.mSprite.paddingLeft + this.mSprite.paddingRight));
			int num2 = Mathf.RoundToInt(Mathf.Abs(localScale3.y) * (1f + this.mSprite.paddingTop + this.mSprite.paddingBottom));
			Vector3 localPosition3 = base.cachedTransform.localPosition;
			localPosition3.x = (float)(Mathf.CeilToInt(localPosition3.x * 4f) >> 2);
			localPosition3.y = (float)(Mathf.CeilToInt(localPosition3.y * 4f) >> 2);
			localPosition3.z = (float)Mathf.RoundToInt(localPosition3.z);
			if (num % 2 == 1 && (base.pivot == UIWidget.Pivot.Top || base.pivot == UIWidget.Pivot.Center || base.pivot == UIWidget.Pivot.Bottom))
			{
				localPosition3.x += 0.5f;
			}
			if (num2 % 2 == 1 && (base.pivot == UIWidget.Pivot.Left || base.pivot == UIWidget.Pivot.Center || base.pivot == UIWidget.Pivot.Right))
			{
				localPosition3.y += 0.5f;
			}
			base.cachedTransform.localPosition = localPosition3;
		}
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x00004E59 File Offset: 0x00003059
	protected override void OnStart()
	{
		if (this.mAtlas != null)
		{
			this.UpdateUVs(true);
		}
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0002A2D8 File Offset: 0x000284D8
	public override void Update()
	{
		base.Update();
		if (this.mChanged || !this.mSpriteSet)
		{
			this.mSpriteSet = true;
			this.mSprite = null;
			this.mChanged = true;
			this.UpdateUVs(true);
		}
		else
		{
			this.UpdateUVs(false);
		}
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x0002A32C File Offset: 0x0002852C
	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		switch (this.type)
		{
		case UISprite.Type.Simple:
			this.SimpleFill(verts, uvs, cols);
			break;
		case UISprite.Type.Sliced:
			this.SlicedFill(verts, uvs, cols);
			break;
		case UISprite.Type.Tiled:
			this.TiledFill(verts, uvs, cols);
			break;
		case UISprite.Type.Filled:
			this.FilledFill(verts, uvs, cols);
			break;
		}
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x0002A394 File Offset: 0x00028594
	protected void SimpleFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		Vector2 item = new Vector2(this.mOuterUV.xMin, this.mOuterUV.yMin);
		Vector2 item2 = new Vector2(this.mOuterUV.xMax, this.mOuterUV.yMax);
		verts.Add(new Vector3(1f, 0f, 0f));
		verts.Add(new Vector3(1f, -1f, 0f));
		verts.Add(new Vector3(0f, -1f, 0f));
		verts.Add(new Vector3(0f, 0f, 0f));
		uvs.Add(item2);
		uvs.Add(new Vector2(item2.x, item.y));
		uvs.Add(item);
		uvs.Add(new Vector2(item.x, item2.y));
		Color color = base.color;
		color.a *= this.mPanel.alpha;
		Color32 item3 = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		cols.Add(item3);
		cols.Add(item3);
		cols.Add(item3);
		cols.Add(item3);
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x0002A4E4 File Offset: 0x000286E4
	protected void SlicedFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		if (this.mOuterUV == this.mInnerUV)
		{
			this.SimpleFill(verts, uvs, cols);
			return;
		}
		Vector2[] array = new Vector2[4];
		Vector2[] array2 = new Vector2[4];
		Texture mainTexture = this.mainTexture;
		array[0] = Vector2.zero;
		array[1] = Vector2.zero;
		array[2] = new Vector2(1f, -1f);
		array[3] = new Vector2(1f, -1f);
		if (mainTexture != null)
		{
			float pixelSize = this.atlas.pixelSize;
			float num = (this.mInnerUV.xMin - this.mOuterUV.xMin) * pixelSize;
			float num2 = (this.mOuterUV.xMax - this.mInnerUV.xMax) * pixelSize;
			float num3 = (this.mInnerUV.yMax - this.mOuterUV.yMax) * pixelSize;
			float num4 = (this.mOuterUV.yMin - this.mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(0f, localScale.x);
			localScale.y = Mathf.Max(0f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)mainTexture.width, localScale.y / (float)mainTexture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			UIWidget.Pivot pivot = base.pivot;
			if (pivot == UIWidget.Pivot.Right || pivot == UIWidget.Pivot.TopRight || pivot == UIWidget.Pivot.BottomRight)
			{
				array[0].x = Mathf.Min(0f, 1f - (vector3.x + vector2.x));
				array[1].x = array[0].x + vector2.x;
				array[2].x = array[0].x + Mathf.Max(vector2.x, 1f - vector3.x);
				array[3].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 1f);
			}
			else
			{
				array[1].x = vector2.x;
				array[2].x = Mathf.Max(vector2.x, 1f - vector3.x);
				array[3].x = Mathf.Max(vector2.x + vector3.x, 1f);
			}
			if (pivot == UIWidget.Pivot.Bottom || pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.BottomRight)
			{
				array[0].y = Mathf.Max(0f, -1f - (vector3.y + vector2.y));
				array[1].y = array[0].y + vector2.y;
				array[2].y = array[0].y + Mathf.Min(vector2.y, -1f - vector3.y);
				array[3].y = array[0].y + Mathf.Min(vector2.y + vector3.y, -1f);
			}
			else
			{
				array[1].y = vector2.y;
				array[2].y = Mathf.Min(vector2.y, -1f - vector3.y);
				array[3].y = Mathf.Min(vector2.y + vector3.y, -1f);
			}
			array2[0] = new Vector2(this.mOuterUV.xMin, this.mOuterUV.yMax);
			array2[1] = new Vector2(this.mInnerUV.xMin, this.mInnerUV.yMax);
			array2[2] = new Vector2(this.mInnerUV.xMax, this.mInnerUV.yMin);
			array2[3] = new Vector2(this.mOuterUV.xMax, this.mOuterUV.yMin);
		}
		else
		{
			for (int i = 0; i < 4; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= this.mPanel.alpha;
		Color32 item = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		for (int j = 0; j < 3; j++)
		{
			int num5 = j + 1;
			for (int k = 0; k < 3; k++)
			{
				if (this.mFillCenter || j != 1 || k != 1)
				{
					int num6 = k + 1;
					verts.Add(new Vector3(array[num5].x, array[k].y, 0f));
					verts.Add(new Vector3(array[num5].x, array[num6].y, 0f));
					verts.Add(new Vector3(array[j].x, array[num6].y, 0f));
					verts.Add(new Vector3(array[j].x, array[k].y, 0f));
					uvs.Add(new Vector2(array2[num5].x, array2[k].y));
					uvs.Add(new Vector2(array2[num5].x, array2[num6].y));
					uvs.Add(new Vector2(array2[j].x, array2[num6].y));
					uvs.Add(new Vector2(array2[j].x, array2[k].y));
					cols.Add(item);
					cols.Add(item);
					cols.Add(item);
					cols.Add(item);
				}
			}
		}
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x0002ABB8 File Offset: 0x00028DB8
	protected bool AdjustRadial(Vector2[] xy, Vector2[] uv, float fill, bool invert)
	{
		if (fill < 0.001f)
		{
			return false;
		}
		if (!invert && fill > 0.999f)
		{
			return true;
		}
		float num = Mathf.Clamp01(fill);
		if (!invert)
		{
			num = 1f - num;
		}
		num *= 1.57079637f;
		float num2 = Mathf.Sin(num);
		float num3 = Mathf.Cos(num);
		if (num2 > num3)
		{
			num3 *= 1f / num2;
			num2 = 1f;
			if (!invert)
			{
				xy[0].y = Mathf.Lerp(xy[2].y, xy[0].y, num3);
				xy[3].y = xy[0].y;
				uv[0].y = Mathf.Lerp(uv[2].y, uv[0].y, num3);
				uv[3].y = uv[0].y;
			}
		}
		else if (num3 > num2)
		{
			num2 *= 1f / num3;
			num3 = 1f;
			if (invert)
			{
				xy[0].x = Mathf.Lerp(xy[2].x, xy[0].x, num2);
				xy[1].x = xy[0].x;
				uv[0].x = Mathf.Lerp(uv[2].x, uv[0].x, num2);
				uv[1].x = uv[0].x;
			}
		}
		else
		{
			num2 = 1f;
			num3 = 1f;
		}
		if (invert)
		{
			xy[1].y = Mathf.Lerp(xy[2].y, xy[0].y, num3);
			uv[1].y = Mathf.Lerp(uv[2].y, uv[0].y, num3);
		}
		else
		{
			xy[3].x = Mathf.Lerp(xy[2].x, xy[0].x, num2);
			uv[3].x = Mathf.Lerp(uv[2].x, uv[0].x, num2);
		}
		return true;
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0002AE24 File Offset: 0x00029024
	protected void Rotate(Vector2[] v, int offset)
	{
		for (int i = 0; i < offset; i++)
		{
			Vector2 vector = new Vector2(v[3].x, v[3].y);
			v[3].x = v[2].y;
			v[3].y = v[2].x;
			v[2].x = v[1].y;
			v[2].y = v[1].x;
			v[1].x = v[0].y;
			v[1].y = v[0].x;
			v[0].x = vector.y;
			v[0].y = vector.x;
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0002AF18 File Offset: 0x00029118
	protected void FilledFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		float x = 0f;
		float y = 0f;
		float num = 1f;
		float num2 = -1f;
		float num3 = this.mOuterUV.xMin;
		float num4 = this.mOuterUV.yMin;
		float num5 = this.mOuterUV.xMax;
		float num6 = this.mOuterUV.yMax;
		if (this.mFillDirection == UISprite.FillDirection.Horizontal || this.mFillDirection == UISprite.FillDirection.Vertical)
		{
			float num7 = (num5 - num3) * this.mFillAmount;
			float num8 = (num6 - num4) * this.mFillAmount;
			if (this.fillDirection == UISprite.FillDirection.Horizontal)
			{
				if (this.mInvert)
				{
					x = 1f - this.mFillAmount;
					num3 = num5 - num7;
				}
				else
				{
					num *= this.mFillAmount;
					num5 = num3 + num7;
				}
			}
			else if (this.fillDirection == UISprite.FillDirection.Vertical)
			{
				if (this.mInvert)
				{
					num2 *= this.mFillAmount;
					num4 = num6 - num8;
				}
				else
				{
					y = -(1f - this.mFillAmount);
					num6 = num4 + num8;
				}
			}
		}
		Vector2[] array = new Vector2[4];
		Vector2[] array2 = new Vector2[4];
		array[0] = new Vector2(num, y);
		array[1] = new Vector2(num, num2);
		array[2] = new Vector2(x, num2);
		array[3] = new Vector2(x, y);
		array2[0] = new Vector2(num5, num6);
		array2[1] = new Vector2(num5, num4);
		array2[2] = new Vector2(num3, num4);
		array2[3] = new Vector2(num3, num6);
		Color color = base.color;
		color.a *= this.mPanel.alpha;
		Color32 item = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		if (this.fillDirection == UISprite.FillDirection.Radial90)
		{
			if (!this.AdjustRadial(array, array2, this.mFillAmount, this.mInvert))
			{
				return;
			}
		}
		else
		{
			if (this.fillDirection == UISprite.FillDirection.Radial180)
			{
				Vector2[] array3 = new Vector2[4];
				Vector2[] array4 = new Vector2[4];
				for (int i = 0; i < 2; i++)
				{
					array3[0] = new Vector2(0f, 0f);
					array3[1] = new Vector2(0f, 1f);
					array3[2] = new Vector2(1f, 1f);
					array3[3] = new Vector2(1f, 0f);
					array4[0] = new Vector2(0f, 0f);
					array4[1] = new Vector2(0f, 1f);
					array4[2] = new Vector2(1f, 1f);
					array4[3] = new Vector2(1f, 0f);
					if (this.mInvert)
					{
						if (i > 0)
						{
							this.Rotate(array3, i);
							this.Rotate(array4, i);
						}
					}
					else if (i < 1)
					{
						this.Rotate(array3, 1 - i);
						this.Rotate(array4, 1 - i);
					}
					float num9;
					float num10;
					if (i == 1)
					{
						num9 = ((!this.mInvert) ? 1f : 0.5f);
						num10 = ((!this.mInvert) ? 0.5f : 1f);
					}
					else
					{
						num9 = ((!this.mInvert) ? 0.5f : 1f);
						num10 = ((!this.mInvert) ? 1f : 0.5f);
					}
					array3[1].y = Mathf.Lerp(num9, num10, array3[1].y);
					array3[2].y = Mathf.Lerp(num9, num10, array3[2].y);
					array4[1].y = Mathf.Lerp(num9, num10, array4[1].y);
					array4[2].y = Mathf.Lerp(num9, num10, array4[2].y);
					float fill = this.mFillAmount * 2f - (float)i;
					bool flag = i % 2 == 1;
					if (this.AdjustRadial(array3, array4, fill, !flag))
					{
						if (this.mInvert)
						{
							flag = !flag;
						}
						if (flag)
						{
							for (int j = 0; j < 4; j++)
							{
								num9 = Mathf.Lerp(array[0].x, array[2].x, array3[j].x);
								num10 = Mathf.Lerp(array[0].y, array[2].y, array3[j].y);
								float x2 = Mathf.Lerp(array2[0].x, array2[2].x, array4[j].x);
								float y2 = Mathf.Lerp(array2[0].y, array2[2].y, array4[j].y);
								verts.Add(new Vector3(num9, num10, 0f));
								uvs.Add(new Vector2(x2, y2));
								cols.Add(item);
							}
						}
						else
						{
							for (int k = 3; k > -1; k--)
							{
								num9 = Mathf.Lerp(array[0].x, array[2].x, array3[k].x);
								num10 = Mathf.Lerp(array[0].y, array[2].y, array3[k].y);
								float x3 = Mathf.Lerp(array2[0].x, array2[2].x, array4[k].x);
								float y3 = Mathf.Lerp(array2[0].y, array2[2].y, array4[k].y);
								verts.Add(new Vector3(num9, num10, 0f));
								uvs.Add(new Vector2(x3, y3));
								cols.Add(item);
							}
						}
					}
				}
				return;
			}
			if (this.fillDirection == UISprite.FillDirection.Radial360)
			{
				float[] array5 = new float[]
				{
					0.5f,
					1f,
					0f,
					0.5f,
					0.5f,
					1f,
					0.5f,
					1f,
					0f,
					0.5f,
					0.5f,
					1f,
					0f,
					0.5f,
					0f,
					0.5f
				};
				Vector2[] array6 = new Vector2[4];
				Vector2[] array7 = new Vector2[4];
				for (int l = 0; l < 4; l++)
				{
					array6[0] = new Vector2(0f, 0f);
					array6[1] = new Vector2(0f, 1f);
					array6[2] = new Vector2(1f, 1f);
					array6[3] = new Vector2(1f, 0f);
					array7[0] = new Vector2(0f, 0f);
					array7[1] = new Vector2(0f, 1f);
					array7[2] = new Vector2(1f, 1f);
					array7[3] = new Vector2(1f, 0f);
					if (this.mInvert)
					{
						if (l > 0)
						{
							this.Rotate(array6, l);
							this.Rotate(array7, l);
						}
					}
					else if (l < 3)
					{
						this.Rotate(array6, 3 - l);
						this.Rotate(array7, 3 - l);
					}
					for (int m = 0; m < 4; m++)
					{
						int num11 = (!this.mInvert) ? (l * 4) : ((3 - l) * 4);
						float from = array5[num11];
						float to = array5[num11 + 1];
						float from2 = array5[num11 + 2];
						float to2 = array5[num11 + 3];
						array6[m].x = Mathf.Lerp(from, to, array6[m].x);
						array6[m].y = Mathf.Lerp(from2, to2, array6[m].y);
						array7[m].x = Mathf.Lerp(from, to, array7[m].x);
						array7[m].y = Mathf.Lerp(from2, to2, array7[m].y);
					}
					float fill2 = this.mFillAmount * 4f - (float)l;
					bool flag2 = l % 2 == 1;
					if (this.AdjustRadial(array6, array7, fill2, !flag2))
					{
						if (this.mInvert)
						{
							flag2 = !flag2;
						}
						if (flag2)
						{
							for (int n = 0; n < 4; n++)
							{
								float x4 = Mathf.Lerp(array[0].x, array[2].x, array6[n].x);
								float y4 = Mathf.Lerp(array[0].y, array[2].y, array6[n].y);
								float x5 = Mathf.Lerp(array2[0].x, array2[2].x, array7[n].x);
								float y5 = Mathf.Lerp(array2[0].y, array2[2].y, array7[n].y);
								verts.Add(new Vector3(x4, y4, 0f));
								uvs.Add(new Vector2(x5, y5));
								cols.Add(item);
							}
						}
						else
						{
							for (int num12 = 3; num12 > -1; num12--)
							{
								float x6 = Mathf.Lerp(array[0].x, array[2].x, array6[num12].x);
								float y6 = Mathf.Lerp(array[0].y, array[2].y, array6[num12].y);
								float x7 = Mathf.Lerp(array2[0].x, array2[2].x, array7[num12].x);
								float y7 = Mathf.Lerp(array2[0].y, array2[2].y, array7[num12].y);
								verts.Add(new Vector3(x6, y6, 0f));
								uvs.Add(new Vector2(x7, y7));
								cols.Add(item);
							}
						}
					}
				}
				return;
			}
		}
		for (int num13 = 0; num13 < 4; num13++)
		{
			verts.Add(array[num13]);
			uvs.Add(array2[num13]);
			cols.Add(item);
		}
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0002BAF4 File Offset: 0x00029CF4
	protected void TiledFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		Texture mainTexture = this.material.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		Rect rect = this.mInner;
		if (this.atlas.coordinates == UIAtlas.Coordinates.TexCoords)
		{
			rect = NGUIMath.ConvertToPixels(rect, mainTexture.width, mainTexture.height, true);
		}
		Vector2 vector = base.cachedTransform.localScale;
		float pixelSize = this.atlas.pixelSize;
		float num = Mathf.Abs(rect.width / vector.x) * pixelSize;
		float num2 = Mathf.Abs(rect.height / vector.y) * pixelSize;
		if (num < 0.01f || num2 < 0.01f)
		{
			Debug.LogWarning("The tiled sprite (" + NGUITools.GetHierarchy(base.gameObject) + ") is too small.\nConsider using a bigger one.");
			num = 0.01f;
			num2 = 0.01f;
		}
		Vector2 vector2 = new Vector2(rect.xMin / (float)mainTexture.width, rect.yMin / (float)mainTexture.height);
		Vector2 vector3 = new Vector2(rect.xMax / (float)mainTexture.width, rect.yMax / (float)mainTexture.height);
		Vector2 vector4 = vector3;
		Color color = base.color;
		color.a *= this.mPanel.alpha;
		Color32 item = (!this.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		for (float num3 = 0f; num3 < 1f; num3 += num2)
		{
			float num4 = 0f;
			vector4.x = vector3.x;
			float num5 = num3 + num2;
			if (num5 > 1f)
			{
				vector4.y = vector2.y + (vector3.y - vector2.y) * (1f - num3) / (num5 - num3);
				num5 = 1f;
			}
			while (num4 < 1f)
			{
				float num6 = num4 + num;
				if (num6 > 1f)
				{
					vector4.x = vector2.x + (vector3.x - vector2.x) * (1f - num4) / (num6 - num4);
					num6 = 1f;
				}
				verts.Add(new Vector3(num6, -num3, 0f));
				verts.Add(new Vector3(num6, -num5, 0f));
				verts.Add(new Vector3(num4, -num5, 0f));
				verts.Add(new Vector3(num4, -num3, 0f));
				uvs.Add(new Vector2(vector4.x, 1f - vector2.y));
				uvs.Add(new Vector2(vector4.x, 1f - vector4.y));
				uvs.Add(new Vector2(vector2.x, 1f - vector4.y));
				uvs.Add(new Vector2(vector2.x, 1f - vector2.y));
				cols.Add(item);
				cols.Add(item);
				cols.Add(item);
				cols.Add(item);
				num4 += num;
			}
		}
	}

	// Token: 0x04000363 RID: 867
	[SerializeField]
	[HideInInspector]
	private UIAtlas mAtlas;

	// Token: 0x04000364 RID: 868
	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	// Token: 0x04000365 RID: 869
	[HideInInspector]
	[SerializeField]
	private bool mFillCenter = true;

	// Token: 0x04000366 RID: 870
	[HideInInspector]
	[SerializeField]
	private UISprite.Type mType;

	// Token: 0x04000367 RID: 871
	[SerializeField]
	[HideInInspector]
	private UISprite.FillDirection mFillDirection = UISprite.FillDirection.Radial360;

	// Token: 0x04000368 RID: 872
	[SerializeField]
	[HideInInspector]
	private float mFillAmount = 1f;

	// Token: 0x04000369 RID: 873
	[HideInInspector]
	[SerializeField]
	private bool mInvert;

	// Token: 0x0400036A RID: 874
	protected UIAtlas.Sprite mSprite;

	// Token: 0x0400036B RID: 875
	protected Rect mInner;

	// Token: 0x0400036C RID: 876
	protected Rect mInnerUV;

	// Token: 0x0400036D RID: 877
	protected Rect mOuter;

	// Token: 0x0400036E RID: 878
	protected Rect mOuterUV;

	// Token: 0x0400036F RID: 879
	protected Vector3 mScale = Vector3.one;

	// Token: 0x04000370 RID: 880
	private bool mSpriteSet;

	// Token: 0x0200008E RID: 142
	public enum Type
	{
		// Token: 0x04000372 RID: 882
		Simple,
		// Token: 0x04000373 RID: 883
		Sliced,
		// Token: 0x04000374 RID: 884
		Tiled,
		// Token: 0x04000375 RID: 885
		Filled
	}

	// Token: 0x0200008F RID: 143
	public enum FillDirection
	{
		// Token: 0x04000377 RID: 887
		Horizontal,
		// Token: 0x04000378 RID: 888
		Vertical,
		// Token: 0x04000379 RID: 889
		Radial90,
		// Token: 0x0400037A RID: 890
		Radial180,
		// Token: 0x0400037B RID: 891
		Radial360
	}
}
