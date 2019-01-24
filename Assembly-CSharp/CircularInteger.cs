using System;

// Token: 0x020003C1 RID: 961
public class CircularInteger
{
	// Token: 0x06001C1C RID: 7196 RVA: 0x00012A87 File Offset: 0x00010C87
	public CircularInteger(int lowerBound, int upperBound)
	{
		this.SetRange(lowerBound, upperBound);
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x00012A97 File Offset: 0x00010C97
	public void SetRange(int lowerBound, int upperBound)
	{
		if (lowerBound >= upperBound)
		{
			throw new Exception("CircularInteger ctor failed because lowerBound greater than upperBound");
		}
		this._current = 0;
		this._lower = lowerBound;
		this._length = upperBound - lowerBound + 1;
	}

	// Token: 0x06001C1E RID: 7198 RVA: 0x00012AC4 File Offset: 0x00010CC4
	public void Reset()
	{
		this._current = 0;
	}

	// Token: 0x1700063E RID: 1598
	// (get) Token: 0x06001C1F RID: 7199 RVA: 0x00012ACD File Offset: 0x00010CCD
	// (set) Token: 0x06001C20 RID: 7200 RVA: 0x00012ADC File Offset: 0x00010CDC
	public int Current
	{
		get
		{
			return this._current + this._lower;
		}
		set
		{
			if (value >= this._lower + this._length && value < this._lower)
			{
				throw new Exception("CircularInteger: Assigned value not in range!");
			}
			this._current = value - this._lower;
		}
	}

	// Token: 0x1700063F RID: 1599
	// (get) Token: 0x06001C21 RID: 7201 RVA: 0x00012B16 File Offset: 0x00010D16
	public int Next
	{
		get
		{
			this._current = (this._current + 1) % this._length;
			return this.Current;
		}
	}

	// Token: 0x17000640 RID: 1600
	// (get) Token: 0x06001C22 RID: 7202 RVA: 0x00012B33 File Offset: 0x00010D33
	public int Prev
	{
		get
		{
			this._current = (this._current + this._length - 1) % this._length;
			return this.Current;
		}
	}

	// Token: 0x17000641 RID: 1601
	// (get) Token: 0x06001C23 RID: 7203 RVA: 0x00012B57 File Offset: 0x00010D57
	public int First
	{
		get
		{
			this._current = 0;
			return this.Current;
		}
	}

	// Token: 0x17000642 RID: 1602
	// (get) Token: 0x06001C24 RID: 7204 RVA: 0x00012B66 File Offset: 0x00010D66
	public int Last
	{
		get
		{
			this._current = this._length - 1;
			return this.Current;
		}
	}

	// Token: 0x17000643 RID: 1603
	// (get) Token: 0x06001C25 RID: 7205 RVA: 0x00012B7C File Offset: 0x00010D7C
	public int Range
	{
		get
		{
			return this._length;
		}
	}

	// Token: 0x0400190E RID: 6414
	private int _lower;

	// Token: 0x0400190F RID: 6415
	private int _length;

	// Token: 0x04001910 RID: 6416
	private int _current;
}
