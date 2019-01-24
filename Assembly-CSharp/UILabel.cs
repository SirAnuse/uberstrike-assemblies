using System;
using UnityEngine;

// Token: 0x02000083 RID: 131
[AddComponentMenu("NGUI/UI/Label")]
[ExecuteInEditMode]
public class UILabel : UIWidget
{
	// Token: 0x17000091 RID: 145
	// (get) Token: 0x06000364 RID: 868 RVA: 0x00027560 File Offset: 0x00025760
	// (set) Token: 0x06000365 RID: 869 RVA: 0x000275F8 File Offset: 0x000257F8
	private bool hasChanged
	{
		get
		{
			return this.mShouldBeProcessed || this.mLastText != this.text || this.mLastWidth != this.mMaxLineWidth || this.mLastEncoding != this.mEncoding || this.mLastCount != this.mMaxLineCount || this.mLastPass != this.mPassword || this.mLastShow != this.mShowLastChar || this.mLastEffect != this.mEffectStyle;
		}
		set
		{
			if (value)
			{
				this.mChanged = true;
				this.mShouldBeProcessed = true;
			}
			else
			{
				this.mShouldBeProcessed = false;
				this.mLastText = this.text;
				this.mLastWidth = this.mMaxLineWidth;
				this.mLastEncoding = this.mEncoding;
				this.mLastCount = this.mMaxLineCount;
				this.mLastPass = this.mPassword;
				this.mLastShow = this.mShowLastChar;
				this.mLastEffect = this.mEffectStyle;
			}
		}
	}

	// Token: 0x17000092 RID: 146
	// (get) Token: 0x06000366 RID: 870 RVA: 0x000048BB File Offset: 0x00002ABB
	// (set) Token: 0x06000367 RID: 871 RVA: 0x0002767C File Offset: 0x0002587C
	public UIFont font
	{
		get
		{
			return this.mFont;
		}
		set
		{
			if (this.mFont != value)
			{
				this.mFont = value;
				this.material = ((!(this.mFont != null)) ? null : this.mFont.material);
				this.mChanged = true;
				this.hasChanged = true;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000093 RID: 147
	// (get) Token: 0x06000368 RID: 872 RVA: 0x000048C3 File Offset: 0x00002AC3
	// (set) Token: 0x06000369 RID: 873 RVA: 0x000276E0 File Offset: 0x000258E0
	public string text
	{
		get
		{
			return this.mText;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				if (!string.IsNullOrEmpty(this.mText))
				{
					this.mText = string.Empty;
				}
				this.hasChanged = true;
			}
			else if (this.mText != value)
			{
				this.mText = value;
				this.hasChanged = true;
				if (this.shrinkToFit)
				{
					this.MakePixelPerfect();
					this.ProcessText();
				}
			}
		}
	}

	// Token: 0x17000094 RID: 148
	// (get) Token: 0x0600036A RID: 874 RVA: 0x000048CB File Offset: 0x00002ACB
	// (set) Token: 0x0600036B RID: 875 RVA: 0x000048D3 File Offset: 0x00002AD3
	public bool supportEncoding
	{
		get
		{
			return this.mEncoding;
		}
		set
		{
			if (this.mEncoding != value)
			{
				this.mEncoding = value;
				this.hasChanged = true;
				if (value)
				{
					this.mPassword = false;
				}
			}
		}
	}

	// Token: 0x17000095 RID: 149
	// (get) Token: 0x0600036C RID: 876 RVA: 0x000048FC File Offset: 0x00002AFC
	// (set) Token: 0x0600036D RID: 877 RVA: 0x00004904 File Offset: 0x00002B04
	public UIFont.SymbolStyle symbolStyle
	{
		get
		{
			return this.mSymbols;
		}
		set
		{
			if (this.mSymbols != value)
			{
				this.mSymbols = value;
				this.hasChanged = true;
			}
		}
	}

	// Token: 0x17000096 RID: 150
	// (get) Token: 0x0600036E RID: 878 RVA: 0x00004920 File Offset: 0x00002B20
	// (set) Token: 0x0600036F RID: 879 RVA: 0x00004928 File Offset: 0x00002B28
	public int lineWidth
	{
		get
		{
			return this.mMaxLineWidth;
		}
		set
		{
			if (this.mMaxLineWidth != value)
			{
				this.mMaxLineWidth = value;
				this.hasChanged = true;
			}
		}
	}

	// Token: 0x17000097 RID: 151
	// (get) Token: 0x06000370 RID: 880 RVA: 0x00004944 File Offset: 0x00002B44
	// (set) Token: 0x06000371 RID: 881 RVA: 0x00004952 File Offset: 0x00002B52
	public bool multiLine
	{
		get
		{
			return this.mMaxLineCount != 1;
		}
		set
		{
			if (this.mMaxLineCount != 1 != value)
			{
				this.mMaxLineCount = ((!value) ? 1 : 0);
				this.hasChanged = true;
				if (value)
				{
					this.mPassword = false;
				}
			}
		}
	}

	// Token: 0x17000098 RID: 152
	// (get) Token: 0x06000372 RID: 882 RVA: 0x0000498D File Offset: 0x00002B8D
	// (set) Token: 0x06000373 RID: 883 RVA: 0x00004995 File Offset: 0x00002B95
	public int maxLineCount
	{
		get
		{
			return this.mMaxLineCount;
		}
		set
		{
			if (this.mMaxLineCount != value)
			{
				this.mMaxLineCount = Mathf.Max(value, 0);
				this.hasChanged = true;
				if (value == 1)
				{
					this.mPassword = false;
				}
			}
		}
	}

	// Token: 0x17000099 RID: 153
	// (get) Token: 0x06000374 RID: 884 RVA: 0x000049C5 File Offset: 0x00002BC5
	// (set) Token: 0x06000375 RID: 885 RVA: 0x000049CD File Offset: 0x00002BCD
	public bool password
	{
		get
		{
			return this.mPassword;
		}
		set
		{
			if (this.mPassword != value)
			{
				if (value)
				{
					this.mMaxLineCount = 1;
					this.mEncoding = false;
				}
				this.mPassword = value;
				this.hasChanged = true;
			}
		}
	}

	// Token: 0x1700009A RID: 154
	// (get) Token: 0x06000376 RID: 886 RVA: 0x000049FD File Offset: 0x00002BFD
	// (set) Token: 0x06000377 RID: 887 RVA: 0x00004A05 File Offset: 0x00002C05
	public bool showLastPasswordChar
	{
		get
		{
			return this.mShowLastChar;
		}
		set
		{
			if (this.mShowLastChar != value)
			{
				this.mShowLastChar = value;
				this.hasChanged = true;
			}
		}
	}

	// Token: 0x1700009B RID: 155
	// (get) Token: 0x06000378 RID: 888 RVA: 0x00004A21 File Offset: 0x00002C21
	// (set) Token: 0x06000379 RID: 889 RVA: 0x00004A29 File Offset: 0x00002C29
	public UILabel.Effect effectStyle
	{
		get
		{
			return this.mEffectStyle;
		}
		set
		{
			if (this.mEffectStyle != value)
			{
				this.mEffectStyle = value;
				this.hasChanged = true;
			}
		}
	}

	// Token: 0x1700009C RID: 156
	// (get) Token: 0x0600037A RID: 890 RVA: 0x00004A45 File Offset: 0x00002C45
	// (set) Token: 0x0600037B RID: 891 RVA: 0x00004A4D File Offset: 0x00002C4D
	public Color effectColor
	{
		get
		{
			return this.mEffectColor;
		}
		set
		{
			if (!this.mEffectColor.Equals(value))
			{
				this.mEffectColor = value;
				if (this.mEffectStyle != UILabel.Effect.None)
				{
					this.hasChanged = true;
				}
			}
		}
	}

	// Token: 0x1700009D RID: 157
	// (get) Token: 0x0600037C RID: 892 RVA: 0x00004A7E File Offset: 0x00002C7E
	// (set) Token: 0x0600037D RID: 893 RVA: 0x00004A86 File Offset: 0x00002C86
	public Vector2 effectDistance
	{
		get
		{
			return this.mEffectDistance;
		}
		set
		{
			if (this.mEffectDistance != value)
			{
				this.mEffectDistance = value;
				this.hasChanged = true;
			}
		}
	}

	// Token: 0x1700009E RID: 158
	// (get) Token: 0x0600037E RID: 894 RVA: 0x00004AA7 File Offset: 0x00002CA7
	// (set) Token: 0x0600037F RID: 895 RVA: 0x00004AAF File Offset: 0x00002CAF
	public bool shrinkToFit
	{
		get
		{
			return this.mShrinkToFit;
		}
		set
		{
			if (this.mShrinkToFit != value)
			{
				this.mShrinkToFit = value;
				this.hasChanged = true;
			}
		}
	}

	// Token: 0x1700009F RID: 159
	// (get) Token: 0x06000380 RID: 896 RVA: 0x00027758 File Offset: 0x00025958
	public string processedText
	{
		get
		{
			if (this.mLastScale != base.cachedTransform.localScale)
			{
				this.mLastScale = base.cachedTransform.localScale;
				this.mShouldBeProcessed = true;
			}
			if (this.hasChanged)
			{
				this.ProcessText();
			}
			return this.mProcessedText;
		}
	}

	// Token: 0x170000A0 RID: 160
	// (get) Token: 0x06000381 RID: 897 RVA: 0x000277B0 File Offset: 0x000259B0
	public override Material material
	{
		get
		{
			Material material = base.material;
			if (material == null)
			{
				material = ((!(this.mFont != null)) ? null : this.mFont.material);
				this.material = material;
			}
			return material;
		}
	}

	// Token: 0x170000A1 RID: 161
	// (get) Token: 0x06000382 RID: 898 RVA: 0x00004ACB File Offset: 0x00002CCB
	public override Vector2 relativeSize
	{
		get
		{
			if (this.mFont == null)
			{
				return Vector3.one;
			}
			if (this.hasChanged)
			{
				this.ProcessText();
			}
			return this.mSize;
		}
	}

	// Token: 0x06000383 RID: 899 RVA: 0x000277FC File Offset: 0x000259FC
	protected override void OnStart()
	{
		if (this.mLineWidth > 0f)
		{
			this.mMaxLineWidth = Mathf.RoundToInt(this.mLineWidth);
			this.mLineWidth = 0f;
		}
		if (!this.mMultiline)
		{
			this.mMaxLineCount = 1;
			this.mMultiline = true;
		}
		this.mPremultiply = (this.font != null && this.font.material != null && this.font.material.shader.name.Contains("Premultiplied"));
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00004B00 File Offset: 0x00002D00
	public override void MarkAsChanged()
	{
		this.hasChanged = true;
		base.MarkAsChanged();
	}

	// Token: 0x06000385 RID: 901 RVA: 0x000278A0 File Offset: 0x00025AA0
	private void ProcessText()
	{
		this.mChanged = true;
		this.hasChanged = false;
		this.mLastText = this.mText;
		float num = Mathf.Abs(base.cachedTransform.localScale.x);
		float num2 = (float)(this.mFont.size * this.mMaxLineCount);
		if (num > 0f)
		{
			do
			{
				if (this.mPassword)
				{
					this.mProcessedText = string.Empty;
					if (this.mShowLastChar)
					{
						int i = 0;
						int num3 = this.mText.Length - 1;
						while (i < num3)
						{
							this.mProcessedText += "*";
							i++;
						}
						if (this.mText.Length > 0)
						{
							this.mProcessedText += this.mText[this.mText.Length - 1];
						}
					}
					else
					{
						int j = 0;
						int length = this.mText.Length;
						while (j < length)
						{
							this.mProcessedText += "*";
							j++;
						}
					}
					this.mProcessedText = this.mFont.WrapText(this.mProcessedText, (float)this.mMaxLineWidth / num, this.mMaxLineCount, false, UIFont.SymbolStyle.None);
				}
				else if (this.mMaxLineWidth > 0)
				{
					this.mProcessedText = this.mFont.WrapText(this.mText, (float)this.mMaxLineWidth / num, (!this.mShrinkToFit) ? this.mMaxLineCount : 0, this.mEncoding, this.mSymbols);
				}
				else if (!this.mShrinkToFit && this.mMaxLineCount > 0)
				{
					this.mProcessedText = this.mFont.WrapText(this.mText, 100000f, this.mMaxLineCount, this.mEncoding, this.mSymbols);
				}
				else
				{
					this.mProcessedText = this.mText;
				}
				this.mSize = (string.IsNullOrEmpty(this.mProcessedText) ? Vector2.one : this.mFont.CalculatePrintedSize(this.mProcessedText, this.mEncoding, this.mSymbols));
				if (!this.mShrinkToFit)
				{
					goto IL_2F2;
				}
				if (this.mMaxLineCount <= 0 || this.mSize.y * num <= num2)
				{
					break;
				}
				num = Mathf.Round(num - 1f);
			}
			while (num > 1f);
			if (this.mMaxLineWidth > 0)
			{
				float num4 = (float)this.mMaxLineWidth / num;
				float a = (this.mSize.x * num <= num4) ? num : (num4 / this.mSize.x * num);
				num = Mathf.Min(a, num);
			}
			num = Mathf.Round(num);
			base.cachedTransform.localScale = new Vector3(num, num, 1f);
			IL_2F2:
			this.mSize.x = Mathf.Max(this.mSize.x, (num <= 0f) ? 1f : ((float)this.lineWidth / num));
		}
		else
		{
			this.mSize.x = 1f;
			num = (float)this.mFont.size;
			base.cachedTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
			this.mProcessedText = string.Empty;
		}
		this.mSize.y = Mathf.Max(this.mSize.y, 1f);
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00027C50 File Offset: 0x00025E50
	public void MakePositionPerfect()
	{
		float pixelSize = this.font.pixelSize;
		Vector3 localScale = base.cachedTransform.localScale;
		if (this.mFont.size == Mathf.RoundToInt(localScale.x / pixelSize) && this.mFont.size == Mathf.RoundToInt(localScale.y / pixelSize) && base.cachedTransform.localRotation == Quaternion.identity)
		{
			Vector2 vector = this.relativeSize * localScale.x;
			int num = Mathf.RoundToInt(vector.x / pixelSize);
			int num2 = Mathf.RoundToInt(vector.y / pixelSize);
			Vector3 localPosition = base.cachedTransform.localPosition;
			localPosition.x = (float)Mathf.FloorToInt(localPosition.x / pixelSize);
			localPosition.y = (float)Mathf.CeilToInt(localPosition.y / pixelSize);
			localPosition.z = (float)Mathf.RoundToInt(localPosition.z);
			if (num % 2 == 1 && (base.pivot == UIWidget.Pivot.Top || base.pivot == UIWidget.Pivot.Center || base.pivot == UIWidget.Pivot.Bottom))
			{
				localPosition.x += 0.5f;
			}
			if (num2 % 2 == 1 && (base.pivot == UIWidget.Pivot.Left || base.pivot == UIWidget.Pivot.Center || base.pivot == UIWidget.Pivot.Right))
			{
				localPosition.y -= 0.5f;
			}
			localPosition.x *= pixelSize;
			localPosition.y *= pixelSize;
			if (base.cachedTransform.localPosition != localPosition)
			{
				base.cachedTransform.localPosition = localPosition;
			}
		}
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00027E10 File Offset: 0x00026010
	public override void MakePixelPerfect()
	{
		if (this.mFont != null)
		{
			float pixelSize = this.font.pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = (float)this.mFont.size * pixelSize;
			localScale.y = localScale.x;
			localScale.z = 1f;
			Vector2 vector = this.relativeSize * localScale.x;
			int num = Mathf.RoundToInt(vector.x / pixelSize);
			int num2 = Mathf.RoundToInt(vector.y / pixelSize);
			Vector3 localPosition = base.cachedTransform.localPosition;
			localPosition.x = (float)(Mathf.CeilToInt(localPosition.x / pixelSize * 4f) >> 2);
			localPosition.y = (float)(Mathf.CeilToInt(localPosition.y / pixelSize * 4f) >> 2);
			localPosition.z = (float)Mathf.RoundToInt(localPosition.z);
			if (base.cachedTransform.localRotation == Quaternion.identity)
			{
				if (num % 2 == 1 && (base.pivot == UIWidget.Pivot.Top || base.pivot == UIWidget.Pivot.Center || base.pivot == UIWidget.Pivot.Bottom))
				{
					localPosition.x += 0.5f;
				}
				if (num2 % 2 == 1 && (base.pivot == UIWidget.Pivot.Left || base.pivot == UIWidget.Pivot.Center || base.pivot == UIWidget.Pivot.Right))
				{
					localPosition.y += 0.5f;
				}
			}
			localPosition.x *= pixelSize;
			localPosition.y *= pixelSize;
			base.cachedTransform.localPosition = localPosition;
			base.cachedTransform.localScale = localScale;
		}
		else
		{
			base.MakePixelPerfect();
		}
	}

	// Token: 0x06000388 RID: 904 RVA: 0x00027FE4 File Offset: 0x000261E4
	private void ApplyShadow(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, int start, int end, float x, float y)
	{
		Color color = this.mEffectColor;
		color.a *= base.alpha * this.mPanel.alpha;
		Color32 color2 = (!this.font.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color);
		for (int i = start; i < end; i++)
		{
			verts.Add(verts.buffer[i]);
			uvs.Add(uvs.buffer[i]);
			cols.Add(cols.buffer[i]);
			Vector3 vector = verts.buffer[i];
			vector.x += x;
			vector.y += y;
			verts.buffer[i] = vector;
			cols.buffer[i] = color2;
		}
	}

	// Token: 0x06000389 RID: 905 RVA: 0x000280EC File Offset: 0x000262EC
	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
		if (this.mFont == null)
		{
			return;
		}
		this.MakePositionPerfect();
		UIWidget.Pivot pivot = base.pivot;
		int start = verts.size;
		Color c = base.color;
		c.a *= this.mPanel.alpha;
		if (this.font.premultipliedAlpha)
		{
			c = NGUITools.ApplyPMA(c);
		}
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.BottomLeft)
		{
			this.mFont.Print(this.processedText, c, verts, uvs, cols, this.mEncoding, this.mSymbols, UIFont.Alignment.Left, 0, this.mPremultiply);
		}
		else if (pivot == UIWidget.Pivot.Right || pivot == UIWidget.Pivot.TopRight || pivot == UIWidget.Pivot.BottomRight)
		{
			this.mFont.Print(this.processedText, c, verts, uvs, cols, this.mEncoding, this.mSymbols, UIFont.Alignment.Right, Mathf.RoundToInt(this.relativeSize.x * (float)this.mFont.size), this.mPremultiply);
		}
		else
		{
			this.mFont.Print(this.processedText, c, verts, uvs, cols, this.mEncoding, this.mSymbols, UIFont.Alignment.Center, Mathf.RoundToInt(this.relativeSize.x * (float)this.mFont.size), this.mPremultiply);
		}
		if (this.effectStyle != UILabel.Effect.None)
		{
			int size = verts.size;
			float num = 1f / (float)this.mFont.size;
			float num2 = num * this.mEffectDistance.x;
			float num3 = num * this.mEffectDistance.y;
			this.ApplyShadow(verts, uvs, cols, start, size, num2, -num3);
			if (this.effectStyle == UILabel.Effect.Outline)
			{
				start = size;
				size = verts.size;
				this.ApplyShadow(verts, uvs, cols, start, size, -num2, num3);
				start = size;
				size = verts.size;
				this.ApplyShadow(verts, uvs, cols, start, size, num2, num3);
				start = size;
				size = verts.size;
				this.ApplyShadow(verts, uvs, cols, start, size, -num2, -num3);
			}
		}
	}

	// Token: 0x04000311 RID: 785
	[HideInInspector]
	[SerializeField]
	private UIFont mFont;

	// Token: 0x04000312 RID: 786
	[SerializeField]
	[HideInInspector]
	private string mText = string.Empty;

	// Token: 0x04000313 RID: 787
	[SerializeField]
	[HideInInspector]
	private int mMaxLineWidth;

	// Token: 0x04000314 RID: 788
	[SerializeField]
	[HideInInspector]
	private bool mEncoding = true;

	// Token: 0x04000315 RID: 789
	[SerializeField]
	[HideInInspector]
	private int mMaxLineCount;

	// Token: 0x04000316 RID: 790
	[HideInInspector]
	[SerializeField]
	private bool mPassword;

	// Token: 0x04000317 RID: 791
	[HideInInspector]
	[SerializeField]
	private bool mShowLastChar;

	// Token: 0x04000318 RID: 792
	[SerializeField]
	[HideInInspector]
	private UILabel.Effect mEffectStyle;

	// Token: 0x04000319 RID: 793
	[SerializeField]
	[HideInInspector]
	private Color mEffectColor = Color.black;

	// Token: 0x0400031A RID: 794
	[SerializeField]
	[HideInInspector]
	private UIFont.SymbolStyle mSymbols = UIFont.SymbolStyle.Uncolored;

	// Token: 0x0400031B RID: 795
	[HideInInspector]
	[SerializeField]
	private Vector2 mEffectDistance = Vector2.one;

	// Token: 0x0400031C RID: 796
	[SerializeField]
	[HideInInspector]
	private bool mShrinkToFit;

	// Token: 0x0400031D RID: 797
	[SerializeField]
	[HideInInspector]
	private float mLineWidth;

	// Token: 0x0400031E RID: 798
	[HideInInspector]
	[SerializeField]
	private bool mMultiline = true;

	// Token: 0x0400031F RID: 799
	private bool mShouldBeProcessed = true;

	// Token: 0x04000320 RID: 800
	private string mProcessedText;

	// Token: 0x04000321 RID: 801
	private Vector3 mLastScale = Vector3.one;

	// Token: 0x04000322 RID: 802
	private string mLastText = string.Empty;

	// Token: 0x04000323 RID: 803
	private int mLastWidth;

	// Token: 0x04000324 RID: 804
	private bool mLastEncoding = true;

	// Token: 0x04000325 RID: 805
	private int mLastCount;

	// Token: 0x04000326 RID: 806
	private bool mLastPass;

	// Token: 0x04000327 RID: 807
	private bool mLastShow;

	// Token: 0x04000328 RID: 808
	private UILabel.Effect mLastEffect;

	// Token: 0x04000329 RID: 809
	private Vector2 mSize = Vector2.zero;

	// Token: 0x0400032A RID: 810
	private bool mPremultiply;

	// Token: 0x02000084 RID: 132
	public enum Effect
	{
		// Token: 0x0400032C RID: 812
		None,
		// Token: 0x0400032D RID: 813
		Shadow,
		// Token: 0x0400032E RID: 814
		Outline
	}
}
