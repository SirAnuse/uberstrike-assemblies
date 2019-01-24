using System;

// Token: 0x0200046D RID: 1133
public class ZoomInfo
{
	// Token: 0x06002070 RID: 8304 RVA: 0x0009B0AC File Offset: 0x000992AC
	public ZoomInfo(float defaultMultiplier, float minMultiplier, float maxMultiplier)
	{
		if (minMultiplier > 0f)
		{
			this.MinMultiplier = minMultiplier;
		}
		if (maxMultiplier > 0f)
		{
			this.MaxMultiplier = maxMultiplier;
		}
		if (defaultMultiplier > 0f)
		{
			this.DefaultMultiplier = defaultMultiplier;
			this.CurrentMultiplier = this.DefaultMultiplier;
		}
	}

	// Token: 0x17000709 RID: 1801
	// (get) Token: 0x06002071 RID: 8305 RVA: 0x000154E0 File Offset: 0x000136E0
	// (set) Token: 0x06002072 RID: 8306 RVA: 0x000154E8 File Offset: 0x000136E8
	public float MinMultiplier
	{
		get
		{
			return this._minMultiplier;
		}
		private set
		{
			this._minMultiplier = value;
		}
	}

	// Token: 0x1700070A RID: 1802
	// (get) Token: 0x06002073 RID: 8307 RVA: 0x000154F1 File Offset: 0x000136F1
	// (set) Token: 0x06002074 RID: 8308 RVA: 0x000154F9 File Offset: 0x000136F9
	public float MaxMultiplier
	{
		get
		{
			return this._maxMultiplier;
		}
		private set
		{
			this._maxMultiplier = value;
		}
	}

	// Token: 0x1700070B RID: 1803
	// (get) Token: 0x06002075 RID: 8309 RVA: 0x00015502 File Offset: 0x00013702
	// (set) Token: 0x06002076 RID: 8310 RVA: 0x0001550A File Offset: 0x0001370A
	public float DefaultMultiplier
	{
		get
		{
			return this._defaultMultiplier;
		}
		private set
		{
			this._defaultMultiplier = value;
		}
	}

	// Token: 0x04001B6C RID: 7020
	private float _defaultMultiplier = 1f;

	// Token: 0x04001B6D RID: 7021
	private float _minMultiplier = 1f;

	// Token: 0x04001B6E RID: 7022
	private float _maxMultiplier = 1f;

	// Token: 0x04001B6F RID: 7023
	public float CurrentMultiplier;
}
