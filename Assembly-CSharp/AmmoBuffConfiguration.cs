using System;

// Token: 0x02000261 RID: 609
[Serializable]
public class AmmoBuffConfiguration : QuickItemConfiguration
{
	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x060010E9 RID: 4329 RVA: 0x0000BBAC File Offset: 0x00009DAC
	public bool IsNeedCharge
	{
		get
		{
			return base.WarmUpTime > 0;
		}
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x060010EA RID: 4330 RVA: 0x0000BBB7 File Offset: 0x00009DB7
	public bool IsOverTime
	{
		get
		{
			return this.IncreaseTimes > 0;
		}
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x060010EB RID: 4331 RVA: 0x0000BBC2 File Offset: 0x00009DC2
	public bool IsInstant
	{
		get
		{
			return !this.IsNeedCharge && !this.IsOverTime;
		}
	}

	// Token: 0x060010EC RID: 4332 RVA: 0x00067A9C File Offset: 0x00065C9C
	public string GetAmmoBonusDescription()
	{
		int num = (this.IncreaseTimes != 0) ? this.IncreaseTimes : 1;
		switch (this.AmmoIncrease)
		{
		case IncreaseStyle.Absolute:
			return (num * this.PointsGain).ToString();
		case IncreaseStyle.PercentFromStart:
			return string.Format("{0}% of the start ammo", this.PointsGain);
		case IncreaseStyle.PercentFromMax:
			return string.Format("{0}% of the max ammo", this.PointsGain);
		default:
			return "n/a";
		}
	}

	// Token: 0x04000E37 RID: 3639
	private const int MaxAmmo = 200;

	// Token: 0x04000E38 RID: 3640
	private const int StartAmmo = 100;

	// Token: 0x04000E39 RID: 3641
	[CustomProperty("AmmoIncrease")]
	public IncreaseStyle AmmoIncrease;

	// Token: 0x04000E3A RID: 3642
	public int IncreaseFrequency;

	// Token: 0x04000E3B RID: 3643
	public int IncreaseTimes;

	// Token: 0x04000E3C RID: 3644
	[CustomProperty("AmmoPoints")]
	public int PointsGain;

	// Token: 0x04000E3D RID: 3645
	[CustomProperty("RobotDestruction")]
	public int RobotLifeTimeMilliSeconds;

	// Token: 0x04000E3E RID: 3646
	[CustomProperty("ScrapsDestruction")]
	public int ScrapsLifeTimeMilliSeconds;
}
