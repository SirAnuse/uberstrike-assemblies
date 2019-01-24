using System;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x020001EE RID: 494
	[Serializable]
	public class ServerConnectionView
	{
		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000D29 RID: 3369 RVA: 0x0000946C File Offset: 0x0000766C
		// (set) Token: 0x06000D2A RID: 3370 RVA: 0x00009474 File Offset: 0x00007674
		public string ApiVersion { get; set; }

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x0000947D File Offset: 0x0000767D
		// (set) Token: 0x06000D2C RID: 3372 RVA: 0x00009485 File Offset: 0x00007685
		public int Cmid { get; set; }

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x0000948E File Offset: 0x0000768E
		// (set) Token: 0x06000D2E RID: 3374 RVA: 0x00009496 File Offset: 0x00007696
		public ChannelType Channel { get; set; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000D2F RID: 3375 RVA: 0x0000949F File Offset: 0x0000769F
		// (set) Token: 0x06000D30 RID: 3376 RVA: 0x000094A7 File Offset: 0x000076A7
		public MemberAccessLevel AccessLevel { get; set; }
	}
}
