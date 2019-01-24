using System;
using UnityEngine;

// Token: 0x0200026B RID: 619
[Serializable]
public class HealthBuffConfiguration : QuickItemConfiguration
{
	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x0600113F RID: 4415 RVA: 0x0000BBAC File Offset: 0x00009DAC
	public bool IsHealNeedCharge
	{
		get
		{
			return base.WarmUpTime > 0;
		}
	}

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06001140 RID: 4416 RVA: 0x0000BFCA File Offset: 0x0000A1CA
	public bool IsHealOverTime
	{
		get
		{
			return this.IncreaseTimes > 0;
		}
	}

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x06001141 RID: 4417 RVA: 0x0000BFD5 File Offset: 0x0000A1D5
	public bool IsHealInstant
	{
		get
		{
			return !this.IsHealNeedCharge && !this.IsHealOverTime;
		}
	}

	// Token: 0x06001142 RID: 4418 RVA: 0x00068C48 File Offset: 0x00066E48
	public string GetHealthBonusDescription()
	{
		int num = (this.IncreaseTimes != 0) ? this.IncreaseTimes : 1;
		switch (this.HealthIncrease)
		{
		case IncreaseStyle.Absolute:
			return (num * this.PointsGain).ToString() + "HP";
		case IncreaseStyle.PercentFromStart:
			return Mathf.RoundToInt((float)(100 * num * this.PointsGain) / 100f) + "HP";
		case IncreaseStyle.PercentFromMax:
			return Mathf.RoundToInt((float)(200 * num * this.PointsGain) / 100f) + "HP";
		default:
			return "n/a";
		}
	}

	// Token: 0x04000E68 RID: 3688
	private const int MaxHealth = 200;

	// Token: 0x04000E69 RID: 3689
	private const int StartHealth = 100;

	// Token: 0x04000E6A RID: 3690
	[CustomProperty("IncreaseStyle")]
	public IncreaseStyle HealthIncrease;

	// Token: 0x04000E6B RID: 3691
	[CustomProperty("Frequency")]
	public int IncreaseFrequency;

	// Token: 0x04000E6C RID: 3692
	[CustomProperty("Times")]
	public int IncreaseTimes;

	// Token: 0x04000E6D RID: 3693
	[CustomProperty("HealthPoints")]
	public int PointsGain;

	// Token: 0x04000E6E RID: 3694
	[CustomProperty("RobotDestruction")]
	public int RobotLifeTimeMilliSeconds;

	// Token: 0x04000E6F RID: 3695
	[CustomProperty("ScrapsDestruction")]
	public int ScrapsLifeTimeMilliSeconds;
}
