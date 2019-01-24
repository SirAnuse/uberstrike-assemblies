using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000053 RID: 83
	[Serializable]
	public class ItemTransactionView
	{
		// Token: 0x06000197 RID: 407 RVA: 0x00002050 File Offset: 0x00000250
		public ItemTransactionView()
		{
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0000DC6C File Offset: 0x0000BE6C
		public ItemTransactionView(int withdrawalId, DateTime withdrawalDate, int points, int credits, int cmid, bool isAdminAction, int itemId, BuyingDurationType duration)
		{
			this.WithdrawalId = withdrawalId;
			this.WithdrawalDate = withdrawalDate;
			this.Points = points;
			this.Credits = credits;
			this.Cmid = cmid;
			this.IsAdminAction = isAdminAction;
			this.ItemId = itemId;
			this.Duration = duration;
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00002DBC File Offset: 0x00000FBC
		// (set) Token: 0x0600019A RID: 410 RVA: 0x00002DC4 File Offset: 0x00000FC4
		public int WithdrawalId { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00002DCD File Offset: 0x00000FCD
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00002DD5 File Offset: 0x00000FD5
		public DateTime WithdrawalDate { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00002DDE File Offset: 0x00000FDE
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00002DE6 File Offset: 0x00000FE6
		public int Points { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00002DEF File Offset: 0x00000FEF
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00002DF7 File Offset: 0x00000FF7
		public int Credits { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00002E00 File Offset: 0x00001000
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x00002E08 File Offset: 0x00001008
		public int Cmid { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00002E11 File Offset: 0x00001011
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x00002E19 File Offset: 0x00001019
		public bool IsAdminAction { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00002E22 File Offset: 0x00001022
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00002E2A File Offset: 0x0000102A
		public int ItemId { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00002E33 File Offset: 0x00001033
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x00002E3B File Offset: 0x0000103B
		public BuyingDurationType Duration { get; set; }
	}
}
