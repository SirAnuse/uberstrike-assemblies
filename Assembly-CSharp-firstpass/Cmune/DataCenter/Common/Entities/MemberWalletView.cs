using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200005E RID: 94
	[Serializable]
	public class MemberWalletView
	{
		// Token: 0x06000276 RID: 630 RVA: 0x00003537 File Offset: 0x00001737
		public MemberWalletView()
		{
			this.CreditsExpiration = DateTime.Today;
			this.PointsExpiration = DateTime.Today;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000E368 File Offset: 0x0000C568
		public MemberWalletView(int cmid, int? credits, int? points, DateTime? creditsExpiration, DateTime? pointsExpiration)
		{
			if (credits == null)
			{
				credits = new int?(0);
			}
			if (points == null)
			{
				points = new int?(0);
			}
			if (creditsExpiration == null)
			{
				creditsExpiration = new DateTime?(DateTime.MinValue);
			}
			if (pointsExpiration == null)
			{
				pointsExpiration = new DateTime?(DateTime.MinValue);
			}
			this.SetMemberWallet(cmid, credits.Value, points.Value, creditsExpiration.Value, pointsExpiration.Value);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00003555 File Offset: 0x00001755
		public MemberWalletView(int cmid, int credits, int points, DateTime creditsExpiration, DateTime pointsExpiration)
		{
			this.SetMemberWallet(cmid, credits, points, creditsExpiration, pointsExpiration);
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000279 RID: 633 RVA: 0x0000356A File Offset: 0x0000176A
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00003572 File Offset: 0x00001772
		public int Cmid { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x0600027B RID: 635 RVA: 0x0000357B File Offset: 0x0000177B
		// (set) Token: 0x0600027C RID: 636 RVA: 0x00003583 File Offset: 0x00001783
		public int Credits { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600027D RID: 637 RVA: 0x0000358C File Offset: 0x0000178C
		// (set) Token: 0x0600027E RID: 638 RVA: 0x00003594 File Offset: 0x00001794
		public int Points { get; set; }

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600027F RID: 639 RVA: 0x0000359D File Offset: 0x0000179D
		// (set) Token: 0x06000280 RID: 640 RVA: 0x000035A5 File Offset: 0x000017A5
		public DateTime CreditsExpiration { get; set; }

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000281 RID: 641 RVA: 0x000035AE File Offset: 0x000017AE
		// (set) Token: 0x06000282 RID: 642 RVA: 0x000035B6 File Offset: 0x000017B6
		public DateTime PointsExpiration { get; set; }

		// Token: 0x06000283 RID: 643 RVA: 0x000035BF File Offset: 0x000017BF
		private void SetMemberWallet(int cmid, int credits, int points, DateTime creditsExpiration, DateTime pointsExpiration)
		{
			this.Cmid = cmid;
			this.Credits = credits;
			this.Points = points;
			this.CreditsExpiration = creditsExpiration;
			this.PointsExpiration = pointsExpiration;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000E404 File Offset: 0x0000C604
		public override string ToString()
		{
			string text = "[Wallet: ";
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"[CMID:",
				this.Cmid,
				"][Credits:",
				this.Credits,
				"][Credits Expiration:",
				this.CreditsExpiration,
				"][Points:",
				this.Points,
				"][Points Expiration:",
				this.PointsExpiration,
				"]"
			});
			return text + "]";
		}
	}
}
