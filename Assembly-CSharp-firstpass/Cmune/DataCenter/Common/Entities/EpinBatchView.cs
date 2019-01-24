using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200004E RID: 78
	public class EpinBatchView
	{
		// Token: 0x06000141 RID: 321 RVA: 0x0000D7E8 File Offset: 0x0000B9E8
		public EpinBatchView(int batchId, int applicationId, PaymentProviderType epinProvider, int amount, int creditAmount, DateTime batchDate, bool isAdmin, bool isRetired, List<EpinView> epins)
		{
			this.BatchId = batchId;
			this.ApplicationId = applicationId;
			this.EpinProvider = epinProvider;
			this.Amount = amount;
			this.CreditAmount = creditAmount;
			this.BatchDate = batchDate;
			this.IsAdmin = isAdmin;
			this.Epins = epins;
			this.IsRetired = isRetired;
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00002AFB File Offset: 0x00000CFB
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00002B03 File Offset: 0x00000D03
		public int BatchId { get; private set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000144 RID: 324 RVA: 0x00002B0C File Offset: 0x00000D0C
		// (set) Token: 0x06000145 RID: 325 RVA: 0x00002B14 File Offset: 0x00000D14
		public int ApplicationId { get; private set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00002B1D File Offset: 0x00000D1D
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00002B25 File Offset: 0x00000D25
		public PaymentProviderType EpinProvider { get; private set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00002B2E File Offset: 0x00000D2E
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00002B36 File Offset: 0x00000D36
		public int Amount { get; private set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00002B3F File Offset: 0x00000D3F
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00002B47 File Offset: 0x00000D47
		public int CreditAmount { get; private set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00002B50 File Offset: 0x00000D50
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00002B58 File Offset: 0x00000D58
		public DateTime BatchDate { get; private set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00002B61 File Offset: 0x00000D61
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00002B69 File Offset: 0x00000D69
		public bool IsAdmin { get; private set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000150 RID: 336 RVA: 0x00002B72 File Offset: 0x00000D72
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00002B7A File Offset: 0x00000D7A
		public bool IsRetired { get; private set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00002B83 File Offset: 0x00000D83
		// (set) Token: 0x06000153 RID: 339 RVA: 0x00002B8B File Offset: 0x00000D8B
		public List<EpinView> Epins { get; private set; }
	}
}
