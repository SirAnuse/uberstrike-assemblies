using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000060 RID: 96
	public class ModerationActionView
	{
		// Token: 0x06000292 RID: 658 RVA: 0x0000E4B0 File Offset: 0x0000C6B0
		public ModerationActionView(int moderationActionId, ModerationActionType actionType, int sourceCmid, string sourceName, int targetCmid, string targetName, DateTime actionDate, int applicationId, string reason, long sourceIp)
		{
			this.ModerationActionId = moderationActionId;
			this.ActionType = actionType;
			this.SourceCmid = sourceCmid;
			this.SourceName = sourceName;
			this.TargetCmid = targetCmid;
			this.TargetName = targetName;
			this.ActionDate = actionDate;
			this.ApplicationId = applicationId;
			this.Reason = reason;
			this.SourceIp = sourceIp;
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000293 RID: 659 RVA: 0x0000364C File Offset: 0x0000184C
		// (set) Token: 0x06000294 RID: 660 RVA: 0x00003654 File Offset: 0x00001854
		public int ModerationActionId { get; private set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000365D File Offset: 0x0000185D
		// (set) Token: 0x06000296 RID: 662 RVA: 0x00003665 File Offset: 0x00001865
		public ModerationActionType ActionType { get; private set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000366E File Offset: 0x0000186E
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00003676 File Offset: 0x00001876
		public int SourceCmid { get; private set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000367F File Offset: 0x0000187F
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00003687 File Offset: 0x00001887
		public string SourceName { get; private set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00003690 File Offset: 0x00001890
		// (set) Token: 0x0600029C RID: 668 RVA: 0x00003698 File Offset: 0x00001898
		public int TargetCmid { get; private set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600029D RID: 669 RVA: 0x000036A1 File Offset: 0x000018A1
		// (set) Token: 0x0600029E RID: 670 RVA: 0x000036A9 File Offset: 0x000018A9
		public string TargetName { get; private set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600029F RID: 671 RVA: 0x000036B2 File Offset: 0x000018B2
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x000036BA File Offset: 0x000018BA
		public DateTime ActionDate { get; private set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x000036C3 File Offset: 0x000018C3
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x000036CB File Offset: 0x000018CB
		public int ApplicationId { get; private set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x000036D4 File Offset: 0x000018D4
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x000036DC File Offset: 0x000018DC
		public string Reason { get; private set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x000036E5 File Offset: 0x000018E5
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x000036ED File Offset: 0x000018ED
		public long SourceIp { get; private set; }
	}
}
