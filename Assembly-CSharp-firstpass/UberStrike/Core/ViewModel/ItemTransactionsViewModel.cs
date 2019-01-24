using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x02000236 RID: 566
	[Serializable]
	public class ItemTransactionsViewModel
	{
		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x0000A6B7 File Offset: 0x000088B7
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x0000A6BF File Offset: 0x000088BF
		public List<ItemTransactionView> ItemTransactions { get; set; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x0000A6C8 File Offset: 0x000088C8
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x0000A6D0 File Offset: 0x000088D0
		public int TotalCount { get; set; }
	}
}
