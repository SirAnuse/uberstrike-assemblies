using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000052 RID: 82
	[Serializable]
	public class ItemInventoryView
	{
		// Token: 0x0600018B RID: 395 RVA: 0x00002050 File Offset: 0x00000250
		public ItemInventoryView()
		{
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00002D48 File Offset: 0x00000F48
		public ItemInventoryView(int itemId, DateTime? expirationDate, int amountRemaining)
		{
			this.ItemId = itemId;
			this.ExpirationDate = expirationDate;
			this.AmountRemaining = amountRemaining;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00002D65 File Offset: 0x00000F65
		public ItemInventoryView(int itemId, DateTime? expirationDate, int amountRemaining, int cmid) : this(itemId, expirationDate, amountRemaining)
		{
			this.Cmid = cmid;
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00002D78 File Offset: 0x00000F78
		// (set) Token: 0x0600018F RID: 399 RVA: 0x00002D80 File Offset: 0x00000F80
		public int Cmid { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000190 RID: 400 RVA: 0x00002D89 File Offset: 0x00000F89
		// (set) Token: 0x06000191 RID: 401 RVA: 0x00002D91 File Offset: 0x00000F91
		public int ItemId { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000192 RID: 402 RVA: 0x00002D9A File Offset: 0x00000F9A
		// (set) Token: 0x06000193 RID: 403 RVA: 0x00002DA2 File Offset: 0x00000FA2
		public DateTime? ExpirationDate { get; set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00002DAB File Offset: 0x00000FAB
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00002DB3 File Offset: 0x00000FB3
		public int AmountRemaining { get; set; }

		// Token: 0x06000196 RID: 406 RVA: 0x0000DBBC File Offset: 0x0000BDBC
		public override string ToString()
		{
			string text = "[LiveInventoryView: ";
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Item Id: ",
				this.ItemId,
				"]"
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Expiration date: ",
				this.ExpirationDate,
				"]"
			});
			text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[Amount remaining:",
				this.AmountRemaining,
				"]"
			});
			return text + "]";
		}
	}
}
