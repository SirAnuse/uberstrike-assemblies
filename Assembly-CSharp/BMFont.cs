using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000043 RID: 67
[Serializable]
public class BMFont
{
	// Token: 0x17000021 RID: 33
	// (get) Token: 0x06000156 RID: 342 RVA: 0x000031A2 File Offset: 0x000013A2
	public bool isValid
	{
		get
		{
			return this.mSaved.Count > 0;
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x06000157 RID: 343 RVA: 0x000031B2 File Offset: 0x000013B2
	// (set) Token: 0x06000158 RID: 344 RVA: 0x000031BA File Offset: 0x000013BA
	public int charSize
	{
		get
		{
			return this.mSize;
		}
		set
		{
			this.mSize = value;
		}
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x06000159 RID: 345 RVA: 0x000031C3 File Offset: 0x000013C3
	// (set) Token: 0x0600015A RID: 346 RVA: 0x000031CB File Offset: 0x000013CB
	public int baseOffset
	{
		get
		{
			return this.mBase;
		}
		set
		{
			this.mBase = value;
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x0600015B RID: 347 RVA: 0x000031D4 File Offset: 0x000013D4
	// (set) Token: 0x0600015C RID: 348 RVA: 0x000031DC File Offset: 0x000013DC
	public int texWidth
	{
		get
		{
			return this.mWidth;
		}
		set
		{
			this.mWidth = value;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x0600015D RID: 349 RVA: 0x000031E5 File Offset: 0x000013E5
	// (set) Token: 0x0600015E RID: 350 RVA: 0x000031ED File Offset: 0x000013ED
	public int texHeight
	{
		get
		{
			return this.mHeight;
		}
		set
		{
			this.mHeight = value;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x0600015F RID: 351 RVA: 0x000031F6 File Offset: 0x000013F6
	public int glyphCount
	{
		get
		{
			return (!this.isValid) ? 0 : this.mSaved.Count;
		}
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x06000160 RID: 352 RVA: 0x00003214 File Offset: 0x00001414
	// (set) Token: 0x06000161 RID: 353 RVA: 0x0000321C File Offset: 0x0000141C
	public string spriteName
	{
		get
		{
			return this.mSpriteName;
		}
		set
		{
			this.mSpriteName = value;
		}
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0001C904 File Offset: 0x0001AB04
	public BMGlyph GetGlyph(int index, bool createIfMissing)
	{
		BMGlyph bmglyph = null;
		if (this.mDict.Count == 0)
		{
			int i = 0;
			int count = this.mSaved.Count;
			while (i < count)
			{
				BMGlyph bmglyph2 = this.mSaved[i];
				this.mDict.Add(bmglyph2.index, bmglyph2);
				i++;
			}
		}
		if (!this.mDict.TryGetValue(index, out bmglyph) && createIfMissing)
		{
			bmglyph = new BMGlyph();
			bmglyph.index = index;
			this.mSaved.Add(bmglyph);
			this.mDict.Add(index, bmglyph);
		}
		return bmglyph;
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00003225 File Offset: 0x00001425
	public BMGlyph GetGlyph(int index)
	{
		return this.GetGlyph(index, false);
	}

	// Token: 0x06000164 RID: 356 RVA: 0x0000322F File Offset: 0x0000142F
	public void Clear()
	{
		this.mDict.Clear();
		this.mSaved.Clear();
	}

	// Token: 0x06000165 RID: 357 RVA: 0x0001C9A0 File Offset: 0x0001ABA0
	public void Trim(int xMin, int yMin, int xMax, int yMax)
	{
		if (this.isValid)
		{
			int i = 0;
			int count = this.mSaved.Count;
			while (i < count)
			{
				BMGlyph bmglyph = this.mSaved[i];
				if (bmglyph != null)
				{
					bmglyph.Trim(xMin, yMin, xMax, yMax);
				}
				i++;
			}
		}
	}

	// Token: 0x04000192 RID: 402
	[SerializeField]
	[HideInInspector]
	private int mSize;

	// Token: 0x04000193 RID: 403
	[HideInInspector]
	[SerializeField]
	private int mBase;

	// Token: 0x04000194 RID: 404
	[SerializeField]
	[HideInInspector]
	private int mWidth;

	// Token: 0x04000195 RID: 405
	[HideInInspector]
	[SerializeField]
	private int mHeight;

	// Token: 0x04000196 RID: 406
	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	// Token: 0x04000197 RID: 407
	[HideInInspector]
	[SerializeField]
	private List<BMGlyph> mSaved = new List<BMGlyph>();

	// Token: 0x04000198 RID: 408
	private Dictionary<int, BMGlyph> mDict = new Dictionary<int, BMGlyph>();
}
