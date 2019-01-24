using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200005B RID: 91
	[Serializable]
	public class MemberReportView
	{
		// Token: 0x06000247 RID: 583 RVA: 0x00002050 File Offset: 0x00000250
		public MemberReportView()
		{
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000335F File Offset: 0x0000155F
		public MemberReportView(int sourceCmid, int targetCmid, MemberReportType reportType, string reason, string context, int applicationID, string ip)
		{
			this.SourceCmid = sourceCmid;
			this.TargetCmid = targetCmid;
			this.ReportType = reportType;
			this.Reason = reason;
			this.Context = context;
			this.ApplicationId = applicationID;
			this.IP = ip;
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000249 RID: 585 RVA: 0x0000339C File Offset: 0x0000159C
		// (set) Token: 0x0600024A RID: 586 RVA: 0x000033A4 File Offset: 0x000015A4
		public int SourceCmid { get; set; }

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600024B RID: 587 RVA: 0x000033AD File Offset: 0x000015AD
		// (set) Token: 0x0600024C RID: 588 RVA: 0x000033B5 File Offset: 0x000015B5
		public int TargetCmid { get; set; }

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600024D RID: 589 RVA: 0x000033BE File Offset: 0x000015BE
		// (set) Token: 0x0600024E RID: 590 RVA: 0x000033C6 File Offset: 0x000015C6
		public MemberReportType ReportType { get; set; }

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600024F RID: 591 RVA: 0x000033CF File Offset: 0x000015CF
		// (set) Token: 0x06000250 RID: 592 RVA: 0x000033D7 File Offset: 0x000015D7
		public string Reason { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000251 RID: 593 RVA: 0x000033E0 File Offset: 0x000015E0
		// (set) Token: 0x06000252 RID: 594 RVA: 0x000033E8 File Offset: 0x000015E8
		public string Context { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000253 RID: 595 RVA: 0x000033F1 File Offset: 0x000015F1
		// (set) Token: 0x06000254 RID: 596 RVA: 0x000033F9 File Offset: 0x000015F9
		public int ApplicationId { get; set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000255 RID: 597 RVA: 0x00003402 File Offset: 0x00001602
		// (set) Token: 0x06000256 RID: 598 RVA: 0x0000340A File Offset: 0x0000160A
		public string IP { get; set; }

		// Token: 0x06000257 RID: 599 RVA: 0x0000E190 File Offset: 0x0000C390
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"[Member report: [Source CMID: ",
				this.SourceCmid,
				"][Target CMID: ",
				this.TargetCmid,
				"][Type: ",
				this.ReportType,
				"][Reason: ",
				this.Reason,
				"][Context: ",
				this.Context,
				"][Application ID: ",
				this.ApplicationId,
				"][IP: ",
				this.IP,
				"]]"
			});
		}
	}
}
