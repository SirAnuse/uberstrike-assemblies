using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x02000232 RID: 562
	[Serializable]
	public class CurrencyDepositsViewModel
	{
		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x0000A5AD File Offset: 0x000087AD
		// (set) Token: 0x06000F31 RID: 3889 RVA: 0x0000A5B5 File Offset: 0x000087B5
		public List<CurrencyDepositView> CurrencyDeposits { get; set; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000F32 RID: 3890 RVA: 0x0000A5BE File Offset: 0x000087BE
		// (set) Token: 0x06000F33 RID: 3891 RVA: 0x0000A5C6 File Offset: 0x000087C6
		public int TotalCount { get; set; }
	}
}
