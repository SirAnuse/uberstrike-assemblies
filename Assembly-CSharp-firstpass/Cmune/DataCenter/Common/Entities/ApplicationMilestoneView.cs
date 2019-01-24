using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000039 RID: 57
	public class ApplicationMilestoneView
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002060 File Offset: 0x00000260
		public ApplicationMilestoneView(int milestoneId, int applicationId, DateTime milestoneDate, string description)
		{
			this.MilestoneId = milestoneId;
			this.ApplicationId = applicationId;
			this.MilestoneDate = milestoneDate;
			this.Description = description;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002085 File Offset: 0x00000285
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000208D File Offset: 0x0000028D
		public int MilestoneId { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002096 File Offset: 0x00000296
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000209E File Offset: 0x0000029E
		public int ApplicationId { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020A7 File Offset: 0x000002A7
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020AF File Offset: 0x000002AF
		public DateTime MilestoneDate { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020B8 File Offset: 0x000002B8
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020C0 File Offset: 0x000002C0
		public string Description { get; private set; }
	}
}
