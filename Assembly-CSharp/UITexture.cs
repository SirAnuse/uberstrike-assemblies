using System;
using UnityEngine;

// Token: 0x02000096 RID: 150
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Texture")]
public class UITexture : UIWidget
{
	// Token: 0x170000C2 RID: 194
	// (get) Token: 0x0600040A RID: 1034 RVA: 0x00004FED File Offset: 0x000031ED
	// (set) Token: 0x0600040B RID: 1035 RVA: 0x00004FF5 File Offset: 0x000031F5
	public Rect uvRect
	{
		get
		{
			return this.mRect;
		}
		set
		{
			if (this.mRect != value)
			{
				this.mRect = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x0600040C RID: 1036 RVA: 0x0002C998 File Offset: 0x0002AB98
	// (set) Token: 0x0600040D RID: 1037 RVA: 0x0002C9FC File Offset: 0x0002ABFC
	public Shader shader
	{
		get
		{
			if (this.mShader == null)
			{
				Material material = this.material;
				if (material != null)
				{
					this.mShader = material.shader;
				}
				if (this.mShader == null)
				{
					this.mShader = Shader.Find("Unlit/Texture");
				}
			}
			return this.mShader;
		}
		set
		{
			if (this.mShader != value)
			{
				this.mShader = value;
				Material material = this.material;
				if (material != null)
				{
					material.shader = value;
				}
				this.mPMA = -1;
			}
		}
	}

	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x0600040E RID: 1038 RVA: 0x00005015 File Offset: 0x00003215
	public bool hasDynamicMaterial
	{
		get
		{
			return this.mDynamicMat != null;
		}
	}

	// Token: 0x170000C5 RID: 197
	// (get) Token: 0x0600040F RID: 1039 RVA: 0x00004D4D File Offset: 0x00002F4D
	public override bool keepMaterial
	{
		get
		{
			return true;
		}
	}

	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x06000410 RID: 1040 RVA: 0x0002CA44 File Offset: 0x0002AC44
	// (set) Token: 0x06000411 RID: 1041 RVA: 0x0002CAF4 File Offset: 0x0002ACF4
	public override Material material
	{
		get
		{
			if (!this.mCreatingMat && this.mMat == null)
			{
				this.mCreatingMat = true;
				if (this.mainTexture != null)
				{
					if (this.mShader == null)
					{
						this.mShader = Shader.Find("Unlit/Texture");
					}
					this.mDynamicMat = new Material(this.mShader);
					this.mDynamicMat.hideFlags = HideFlags.DontSave;
					this.mDynamicMat.mainTexture = this.mainTexture;
					base.material = this.mDynamicMat;
					this.mPMA = 0;
				}
				this.mCreatingMat = false;
			}
			return this.mMat;
		}
		set
		{
			if (this.mDynamicMat != value && this.mDynamicMat != null)
			{
				NGUITools.Destroy(this.mDynamicMat);
				this.mDynamicMat = null;
			}
			base.material = value;
			this.mPMA = -1;
		}
	}

	// Token: 0x170000C7 RID: 199
	// (get) Token: 0x06000412 RID: 1042 RVA: 0x0002CB44 File Offset: 0x0002AD44
	public bool premultipliedAlpha
	{
		get
		{
			if (this.mPMA == -1)
			{
				Material material = this.material;
				this.mPMA = ((!(material != null) || !(material.shader != null) || !material.shader.name.Contains("Premultiplied")) ? 0 : 1);
			}
			return this.mPMA == 1;
		}
	}

	// Token: 0x170000C8 RID: 200
	// (get) Token: 0x06000413 RID: 1043 RVA: 0x00005023 File Offset: 0x00003223
	// (set) Token: 0x06000414 RID: 1044 RVA: 0x0002CBB4 File Offset: 0x0002ADB4
	public override Texture mainTexture
	{
		get
		{
			return (!(this.mTexture != null)) ? base.mainTexture : this.mTexture;
		}
		set
		{
			if (this.mPanel != null && this.mMat != null)
			{
				this.mPanel.RemoveWidget(this);
			}
			if (this.mMat == null)
			{
				this.mDynamicMat = new Material(this.shader);
				this.mDynamicMat.hideFlags = HideFlags.DontSave;
				this.mMat = this.mDynamicMat;
			}
			this.mPanel = null;
			this.mTex = value;
			this.mTexture = value;
			this.mMat.mainTexture = value;
			if (base.enabled)
			{
				base.CreatePanel();
			}
		}
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x00005047 File Offset: 0x00003247
	private void OnDestroy()
	{
		NGUITools.Destroy(this.mDynamicMat);
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0002CC5C File Offset: 0x0002AE5C
	public override void MakePixelPerfect()
	{
		Texture mainTexture = this.mainTexture;
		if (mainTexture != null)
		{
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = (float)mainTexture.width * this.uvRect.width;
			localScale.y = (float)mainTexture.height * this.uvRect.height;
			localScale.z = 1f;
			base.cachedTransform.localScale = localScale;
		}
		base.MakePixelPerfect();
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0002CCE0 File Offset: 0x0002AEE0
	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		Color color = base.color;
		color.a *= this.mPanel.alpha;
		Color32 item = (!this.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		verts.Add(new Vector3(1f, 0f, 0f));
		verts.Add(new Vector3(1f, -1f, 0f));
		verts.Add(new Vector3(0f, -1f, 0f));
		verts.Add(new Vector3(0f, 0f, 0f));
		uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMax));
		uvs.Add(new Vector2(this.mRect.xMax, this.mRect.yMin));
		uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMin));
		uvs.Add(new Vector2(this.mRect.xMin, this.mRect.yMax));
		cols.Add(item);
		cols.Add(item);
		cols.Add(item);
		cols.Add(item);
	}

	// Token: 0x040003A6 RID: 934
	[HideInInspector]
	[SerializeField]
	private Rect mRect = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x040003A7 RID: 935
	[HideInInspector]
	[SerializeField]
	private Shader mShader;

	// Token: 0x040003A8 RID: 936
	[SerializeField]
	[HideInInspector]
	private Texture mTexture;

	// Token: 0x040003A9 RID: 937
	private Material mDynamicMat;

	// Token: 0x040003AA RID: 938
	private bool mCreatingMat;

	// Token: 0x040003AB RID: 939
	private int mPMA = -1;
}
