using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000072 RID: 114
[AddComponentMenu("NGUI/UI/Atlas")]
public class UIAtlas : MonoBehaviour
{
	// Token: 0x17000067 RID: 103
	// (get) Token: 0x060002D1 RID: 721 RVA: 0x000041D0 File Offset: 0x000023D0
	// (set) Token: 0x060002D2 RID: 722 RVA: 0x00022874 File Offset: 0x00020A74
	public Material spriteMaterial
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.material : this.mReplacement.spriteMaterial;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.spriteMaterial = value;
			}
			else if (this.material == null)
			{
				this.mPMA = 0;
				this.material = value;
			}
			else
			{
				this.MarkAsDirty();
				this.mPMA = -1;
				this.material = value;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x060002D3 RID: 723 RVA: 0x000228E4 File Offset: 0x00020AE4
	public bool premultipliedAlpha
	{
		get
		{
			if (this.mReplacement != null)
			{
				return this.mReplacement.premultipliedAlpha;
			}
			if (this.mPMA == -1)
			{
				Material spriteMaterial = this.spriteMaterial;
				this.mPMA = ((!(spriteMaterial != null) || !(spriteMaterial.shader != null) || !spriteMaterial.shader.name.Contains("Premultiplied")) ? 0 : 1);
			}
			return this.mPMA == 1;
		}
	}

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x060002D4 RID: 724 RVA: 0x000041F9 File Offset: 0x000023F9
	// (set) Token: 0x060002D5 RID: 725 RVA: 0x00004222 File Offset: 0x00002422
	public List<UIAtlas.Sprite> spriteList
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.sprites : this.mReplacement.spriteList;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.spriteList = value;
			}
			else
			{
				this.sprites = value;
			}
		}
	}

	// Token: 0x1700006A RID: 106
	// (get) Token: 0x060002D6 RID: 726 RVA: 0x00022970 File Offset: 0x00020B70
	public Texture texture
	{
		get
		{
			return (!(this.mReplacement != null)) ? ((!(this.material != null)) ? null : this.material.mainTexture) : this.mReplacement.texture;
		}
	}

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x060002D7 RID: 727 RVA: 0x0000424D File Offset: 0x0000244D
	// (set) Token: 0x060002D8 RID: 728 RVA: 0x000229C0 File Offset: 0x00020BC0
	public UIAtlas.Coordinates coordinates
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mCoordinates : this.mReplacement.coordinates;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.coordinates = value;
			}
			else if (this.mCoordinates != value)
			{
				if (this.material == null || this.material.mainTexture == null)
				{
					Debug.LogError("Can't switch coordinates until the atlas material has a valid texture");
					return;
				}
				this.mCoordinates = value;
				Texture mainTexture = this.material.mainTexture;
				int i = 0;
				int count = this.sprites.Count;
				while (i < count)
				{
					UIAtlas.Sprite sprite = this.sprites[i];
					if (this.mCoordinates == UIAtlas.Coordinates.TexCoords)
					{
						sprite.outer = NGUIMath.ConvertToTexCoords(sprite.outer, mainTexture.width, mainTexture.height);
						sprite.inner = NGUIMath.ConvertToTexCoords(sprite.inner, mainTexture.width, mainTexture.height);
					}
					else
					{
						sprite.outer = NGUIMath.ConvertToPixels(sprite.outer, mainTexture.width, mainTexture.height, true);
						sprite.inner = NGUIMath.ConvertToPixels(sprite.inner, mainTexture.width, mainTexture.height, true);
					}
					i++;
				}
			}
		}
	}

	// Token: 0x1700006C RID: 108
	// (get) Token: 0x060002D9 RID: 729 RVA: 0x00004276 File Offset: 0x00002476
	// (set) Token: 0x060002DA RID: 730 RVA: 0x00022AF4 File Offset: 0x00020CF4
	public float pixelSize
	{
		get
		{
			return (!(this.mReplacement != null)) ? this.mPixelSize : this.mReplacement.pixelSize;
		}
		set
		{
			if (this.mReplacement != null)
			{
				this.mReplacement.pixelSize = value;
			}
			else
			{
				float num = Mathf.Clamp(value, 0.25f, 4f);
				if (this.mPixelSize != num)
				{
					this.mPixelSize = num;
					this.MarkAsDirty();
				}
			}
		}
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x060002DB RID: 731 RVA: 0x0000429F File Offset: 0x0000249F
	// (set) Token: 0x060002DC RID: 732 RVA: 0x00022B50 File Offset: 0x00020D50
	public UIAtlas replacement
	{
		get
		{
			return this.mReplacement;
		}
		set
		{
			UIAtlas uiatlas = value;
			if (uiatlas == this)
			{
				uiatlas = null;
			}
			if (this.mReplacement != uiatlas)
			{
				if (uiatlas != null && uiatlas.replacement == this)
				{
					uiatlas.replacement = null;
				}
				if (this.mReplacement != null)
				{
					this.MarkAsDirty();
				}
				this.mReplacement = uiatlas;
				this.MarkAsDirty();
			}
		}
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00022BC8 File Offset: 0x00020DC8
	public UIAtlas.Sprite GetSprite(string name)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.GetSprite(name);
		}
		if (!string.IsNullOrEmpty(name))
		{
			int i = 0;
			int count = this.sprites.Count;
			while (i < count)
			{
				UIAtlas.Sprite sprite = this.sprites[i];
				if (!string.IsNullOrEmpty(sprite.name) && name == sprite.name)
				{
					return sprite;
				}
				i++;
			}
		}
		return null;
	}

	// Token: 0x060002DE RID: 734 RVA: 0x000042A7 File Offset: 0x000024A7
	private static int CompareString(string a, string b)
	{
		return a.CompareTo(b);
	}

	// Token: 0x060002DF RID: 735 RVA: 0x00022C50 File Offset: 0x00020E50
	public BetterList<string> GetListOfSprites()
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.GetListOfSprites();
		}
		BetterList<string> betterList = new BetterList<string>();
		int i = 0;
		int count = this.sprites.Count;
		while (i < count)
		{
			UIAtlas.Sprite sprite = this.sprites[i];
			if (sprite != null && !string.IsNullOrEmpty(sprite.name))
			{
				betterList.Add(sprite.name);
			}
			i++;
		}
		return betterList;
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x00022CD0 File Offset: 0x00020ED0
	public BetterList<string> GetListOfSprites(string match)
	{
		if (this.mReplacement != null)
		{
			return this.mReplacement.GetListOfSprites(match);
		}
		if (string.IsNullOrEmpty(match))
		{
			return this.GetListOfSprites();
		}
		BetterList<string> betterList = new BetterList<string>();
		int i = 0;
		int count = this.sprites.Count;
		while (i < count)
		{
			UIAtlas.Sprite sprite = this.sprites[i];
			if (sprite != null && !string.IsNullOrEmpty(sprite.name) && string.Equals(match, sprite.name, StringComparison.OrdinalIgnoreCase))
			{
				betterList.Add(sprite.name);
				return betterList;
			}
			i++;
		}
		string[] array = match.Split(new char[]
		{
			' '
		}, StringSplitOptions.RemoveEmptyEntries);
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = array[j].ToLower();
		}
		int k = 0;
		int count2 = this.sprites.Count;
		while (k < count2)
		{
			UIAtlas.Sprite sprite2 = this.sprites[k];
			if (sprite2 != null && !string.IsNullOrEmpty(sprite2.name))
			{
				string text = sprite2.name.ToLower();
				int num = 0;
				for (int l = 0; l < array.Length; l++)
				{
					if (text.Contains(array[l]))
					{
						num++;
					}
				}
				if (num == array.Length)
				{
					betterList.Add(sprite2.name);
				}
			}
			k++;
		}
		return betterList;
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x00022E58 File Offset: 0x00021058
	private bool References(UIAtlas atlas)
	{
		return !(atlas == null) && (atlas == this || (this.mReplacement != null && this.mReplacement.References(atlas)));
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x000042B0 File Offset: 0x000024B0
	public static bool CheckIfRelated(UIAtlas a, UIAtlas b)
	{
		return !(a == null) && !(b == null) && (a == b || a.References(b) || b.References(a));
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x00022EA4 File Offset: 0x000210A4
	public void MarkAsDirty()
	{
		if (this.mReplacement != null)
		{
			this.mReplacement.MarkAsDirty();
		}
		UISprite[] array = NGUITools.FindActive<UISprite>();
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			UISprite uisprite = array[i];
			if (UIAtlas.CheckIfRelated(this, uisprite.atlas))
			{
				UIAtlas atlas = uisprite.atlas;
				uisprite.atlas = null;
				uisprite.atlas = atlas;
			}
			i++;
		}
		UIFont[] array2 = Resources.FindObjectsOfTypeAll(typeof(UIFont)) as UIFont[];
		int j = 0;
		int num2 = array2.Length;
		while (j < num2)
		{
			UIFont uifont = array2[j];
			if (UIAtlas.CheckIfRelated(this, uifont.atlas))
			{
				UIAtlas atlas2 = uifont.atlas;
				uifont.atlas = null;
				uifont.atlas = atlas2;
			}
			j++;
		}
		UILabel[] array3 = NGUITools.FindActive<UILabel>();
		int k = 0;
		int num3 = array3.Length;
		while (k < num3)
		{
			UILabel uilabel = array3[k];
			if (uilabel.font != null && UIAtlas.CheckIfRelated(this, uilabel.font.atlas))
			{
				UIFont font = uilabel.font;
				uilabel.font = null;
				uilabel.font = font;
			}
			k++;
		}
	}

	// Token: 0x04000282 RID: 642
	[SerializeField]
	[HideInInspector]
	private Material material;

	// Token: 0x04000283 RID: 643
	[HideInInspector]
	[SerializeField]
	private List<UIAtlas.Sprite> sprites = new List<UIAtlas.Sprite>();

	// Token: 0x04000284 RID: 644
	[SerializeField]
	[HideInInspector]
	private UIAtlas.Coordinates mCoordinates;

	// Token: 0x04000285 RID: 645
	[SerializeField]
	[HideInInspector]
	private float mPixelSize = 1f;

	// Token: 0x04000286 RID: 646
	[HideInInspector]
	[SerializeField]
	private UIAtlas mReplacement;

	// Token: 0x04000287 RID: 647
	private int mPMA = -1;

	// Token: 0x02000073 RID: 115
	[Serializable]
	public class Sprite
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00023048 File Offset: 0x00021248
		public bool hasPadding
		{
			get
			{
				return this.paddingLeft != 0f || this.paddingRight != 0f || this.paddingTop != 0f || this.paddingBottom != 0f;
			}
		}

		// Token: 0x04000288 RID: 648
		public string name = "Unity Bug";

		// Token: 0x04000289 RID: 649
		public Rect outer = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x0400028A RID: 650
		public Rect inner = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x0400028B RID: 651
		public bool rotated;

		// Token: 0x0400028C RID: 652
		public float paddingLeft;

		// Token: 0x0400028D RID: 653
		public float paddingRight;

		// Token: 0x0400028E RID: 654
		public float paddingTop;

		// Token: 0x0400028F RID: 655
		public float paddingBottom;
	}

	// Token: 0x02000074 RID: 116
	public enum Coordinates
	{
		// Token: 0x04000291 RID: 657
		Pixels,
		// Token: 0x04000292 RID: 658
		TexCoords
	}
}
