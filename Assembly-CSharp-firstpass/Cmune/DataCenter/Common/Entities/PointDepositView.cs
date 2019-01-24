using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200006A RID: 106
	[Serializable]
	public class PointDepositView
	{
		// Token: 0x0600032B RID: 811 RVA: 0x00002050 File Offset: 0x00000250
		public PointDepositView()
		{
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00003B8E File Offset: 0x00001D8E
		public PointDepositView(int pointDepositId, DateTime depositDate, int points, int cmid, bool isAdminAction, PointsDepositType despositType)
		{
			this.PointDepositId = pointDepositId;
			this.DepositDate = depositDate;
			this.Points = points;
			this.Cmid = cmid;
			this.IsAdminAction = isAdminAction;
			this.DepositType = despositType;
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00003BC3 File Offset: 0x00001DC3
		// (set) Token: 0x0600032E RID: 814 RVA: 0x00003BCB File Offset: 0x00001DCB
		public int PointDepositId { get; set; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00003BD4 File Offset: 0x00001DD4
		// (set) Token: 0x06000330 RID: 816 RVA: 0x00003BDC File Offset: 0x00001DDC
		public DateTime DepositDate { get; set; }

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00003BE5 File Offset: 0x00001DE5
		// (set) Token: 0x06000332 RID: 818 RVA: 0x00003BED File Offset: 0x00001DED
		public int Points { get; set; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00003BF6 File Offset: 0x00001DF6
		// (set) Token: 0x06000334 RID: 820 RVA: 0x00003BFE File Offset: 0x00001DFE
		public int Cmid { get; set; }

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00003C07 File Offset: 0x00001E07
		// (set) Token: 0x06000336 RID: 822 RVA: 0x00003C0F File Offset: 0x00001E0F
		public bool IsAdminAction { get; set; }

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00003C18 File Offset: 0x00001E18
		// (set) Token: 0x06000338 RID: 824 RVA: 0x00003C20 File Offset: 0x00001E20
		public PointsDepositType DepositType { get; set; }
	}
}
