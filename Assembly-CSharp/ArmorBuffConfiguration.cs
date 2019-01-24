using System;
using UnityEngine;

// Token: 0x02000264 RID: 612
[Serializable]
public class ArmorBuffConfiguration : QuickItemConfiguration
{
	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x060010FA RID: 4346 RVA: 0x0000BBAC File Offset: 0x00009DAC
	public bool IsNeedCharge
	{
		get
		{
			return base.WarmUpTime > 0;
		}
	}

	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x060010FB RID: 4347 RVA: 0x0000BC20 File Offset: 0x00009E20
	public bool IsOverTime
	{
		get
		{
			return this.IncreaseTimes > 0;
		}
	}

	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x060010FC RID: 4348 RVA: 0x0000BC2B File Offset: 0x00009E2B
	public bool IsInstant
	{
		get
		{
			return !this.IsNeedCharge && !this.IsOverTime;
		}
	}

	// Token: 0x060010FD RID: 4349 RVA: 0x00067F4C File Offset: 0x0006614C
	public string GetArmorBonusDescription()
	{
		int num = (this.IncreaseTimes != 0) ? this.IncreaseTimes : 1;
		switch (this.ArmorIncrease)
		{
		case IncreaseStyle.Absolute:
			return (num * this.PointsGain).ToString();
		case IncreaseStyle.PercentFromStart:
			return Mathf.RoundToInt((float)(100 * num * this.PointsGain) / 100f) + "AP";
		case IncreaseStyle.PercentFromMax:
			return Mathf.RoundToInt((float)(200 * num * this.PointsGain) / 100f) + "AP";
		default:
			return "n/a";
		}
	}

	// Token: 0x04000E44 RID: 3652
	private const int MaxArmor = 200;

	// Token: 0x04000E45 RID: 3653
	private const int StartArmor = 100;

	// Token: 0x04000E46 RID: 3654
	public IncreaseStyle ArmorIncrease;

	// Token: 0x04000E47 RID: 3655
	public int IncreaseFrequency;

	// Token: 0x04000E48 RID: 3656
	public int IncreaseTimes;

	// Token: 0x04000E49 RID: 3657
	[CustomProperty("ArmorPoints")]
	public int PointsGain;

	// Token: 0x04000E4A RID: 3658
	[CustomProperty("RobotDestruction")]
	public int RobotLifeTimeMilliSeconds;

	// Token: 0x04000E4B RID: 3659
	[CustomProperty("ScrapsDestruction")]
	public int ScrapsLifeTimeMilliSeconds;
}
