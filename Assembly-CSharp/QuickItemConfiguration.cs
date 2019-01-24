using System;
using UberStrike.Core.Models.Views;

// Token: 0x02000255 RID: 597
public class QuickItemConfiguration : UberStrikeItemQuickView
{
	// Token: 0x170003FD RID: 1021
	// (get) Token: 0x06001077 RID: 4215 RVA: 0x0000B83B File Offset: 0x00009A3B
	// (set) Token: 0x06001078 RID: 4216 RVA: 0x0000B843 File Offset: 0x00009A43
	public int AmountRemaining
	{
		get
		{
			return this._totalAmount;
		}
		set
		{
			this._totalAmount = value;
		}
	}

	// Token: 0x170003FE RID: 1022
	// (get) Token: 0x06001079 RID: 4217 RVA: 0x0000B84C File Offset: 0x00009A4C
	public int RechargeTime
	{
		get
		{
			return this._rechargeTime;
		}
	}

	// Token: 0x170003FF RID: 1023
	// (get) Token: 0x0600107A RID: 4218 RVA: 0x0000B854 File Offset: 0x00009A54
	public float SlowdownOnCharge
	{
		get
		{
			return this._slowdownOnCharge;
		}
	}

	// Token: 0x04000E09 RID: 3593
	[CustomProperty("Amount")]
	private int _totalAmount;

	// Token: 0x04000E0A RID: 3594
	[CustomProperty("RechargeTime")]
	private int _rechargeTime;

	// Token: 0x04000E0B RID: 3595
	[CustomProperty("SlowdownOnCharge")]
	private float _slowdownOnCharge = 2f;
}
