using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200004D RID: 77
	[Serializable]
	public class CurrencyDepositView
	{
		// Token: 0x06000121 RID: 289 RVA: 0x00002050 File Offset: 0x00000250
		public CurrencyDepositView()
		{
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000D760 File Offset: 0x0000B960
		public CurrencyDepositView(int creditsDepositId, DateTime depositDate, int credits, int points, decimal cash, string currencyLabel, int cmid, bool isAdminAction, PaymentProviderType paymentProviderId, string transactionKey, int applicationId, ChannelType channelId, decimal usdAmount, int? bundleId, string bundleName)
		{
			this.CreditsDepositId = creditsDepositId;
			this.DepositDate = depositDate;
			this.Credits = credits;
			this.Points = points;
			this.Cash = cash;
			this.CurrencyLabel = currencyLabel;
			this.Cmid = cmid;
			this.IsAdminAction = isAdminAction;
			this.PaymentProviderId = paymentProviderId;
			this.TransactionKey = transactionKey;
			this.ApplicationId = applicationId;
			this.ChannelId = channelId;
			this.UsdAmount = usdAmount;
			this.BundleId = bundleId;
			this.BundleName = bundleName;
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000123 RID: 291 RVA: 0x000029FC File Offset: 0x00000BFC
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00002A04 File Offset: 0x00000C04
		public int CreditsDepositId { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00002A0D File Offset: 0x00000C0D
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00002A15 File Offset: 0x00000C15
		public DateTime DepositDate { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00002A1E File Offset: 0x00000C1E
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00002A26 File Offset: 0x00000C26
		public int Credits { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00002A2F File Offset: 0x00000C2F
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00002A37 File Offset: 0x00000C37
		public int Points { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00002A40 File Offset: 0x00000C40
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00002A48 File Offset: 0x00000C48
		public decimal Cash { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00002A51 File Offset: 0x00000C51
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00002A59 File Offset: 0x00000C59
		public string CurrencyLabel { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00002A62 File Offset: 0x00000C62
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00002A6A File Offset: 0x00000C6A
		public int Cmid { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00002A73 File Offset: 0x00000C73
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00002A7B File Offset: 0x00000C7B
		public bool IsAdminAction { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00002A84 File Offset: 0x00000C84
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00002A8C File Offset: 0x00000C8C
		public PaymentProviderType PaymentProviderId { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00002A95 File Offset: 0x00000C95
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00002A9D File Offset: 0x00000C9D
		public string TransactionKey { get; set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00002AA6 File Offset: 0x00000CA6
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00002AAE File Offset: 0x00000CAE
		public int ApplicationId { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00002AB7 File Offset: 0x00000CB7
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00002ABF File Offset: 0x00000CBF
		public ChannelType ChannelId { get; set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00002AC8 File Offset: 0x00000CC8
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00002AD0 File Offset: 0x00000CD0
		public decimal UsdAmount { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00002AD9 File Offset: 0x00000CD9
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00002AE1 File Offset: 0x00000CE1
		public int? BundleId { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00002AEA File Offset: 0x00000CEA
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00002AF2 File Offset: 0x00000CF2
		public string BundleName { get; set; }
	}
}
