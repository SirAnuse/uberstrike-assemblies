using System;
using System.Collections.Generic;

// Token: 0x02000044 RID: 68
[Serializable]
public class BMGlyph
{
	// Token: 0x06000167 RID: 359 RVA: 0x0001C9F4 File Offset: 0x0001ABF4
	public int GetKerning(int previousChar)
	{
		if (this.kerning != null)
		{
			int i = 0;
			int count = this.kerning.Count;
			while (i < count)
			{
				if (this.kerning[i] == previousChar)
				{
					return this.kerning[i + 1];
				}
				i += 2;
			}
		}
		return 0;
	}

	// Token: 0x06000168 RID: 360 RVA: 0x0001CA4C File Offset: 0x0001AC4C
	public void SetKerning(int previousChar, int amount)
	{
		if (this.kerning == null)
		{
			this.kerning = new List<int>();
		}
		for (int i = 0; i < this.kerning.Count; i += 2)
		{
			if (this.kerning[i] == previousChar)
			{
				this.kerning[i + 1] = amount;
				return;
			}
		}
		this.kerning.Add(previousChar);
		this.kerning.Add(amount);
	}

	// Token: 0x06000169 RID: 361 RVA: 0x0001CAC8 File Offset: 0x0001ACC8
	public void Trim(int xMin, int yMin, int xMax, int yMax)
	{
		int num = this.x + this.width;
		int num2 = this.y + this.height;
		if (this.x < xMin)
		{
			int num3 = xMin - this.x;
			this.x += num3;
			this.width -= num3;
			this.offsetX += num3;
		}
		if (this.y < yMin)
		{
			int num4 = yMin - this.y;
			this.y += num4;
			this.height -= num4;
			this.offsetY += num4;
		}
		if (num > xMax)
		{
			this.width -= num - xMax;
		}
		if (num2 > yMax)
		{
			this.height -= num2 - yMax;
		}
	}

	// Token: 0x04000199 RID: 409
	public int index;

	// Token: 0x0400019A RID: 410
	public int x;

	// Token: 0x0400019B RID: 411
	public int y;

	// Token: 0x0400019C RID: 412
	public int width;

	// Token: 0x0400019D RID: 413
	public int height;

	// Token: 0x0400019E RID: 414
	public int offsetX;

	// Token: 0x0400019F RID: 415
	public int offsetY;

	// Token: 0x040001A0 RID: 416
	public int advance;

	// Token: 0x040001A1 RID: 417
	public int channel;

	// Token: 0x040001A2 RID: 418
	public List<int> kerning;
}
