using System;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x02000231 RID: 561
	[Serializable]
	public class ClanInvitationAnswerViewModel
	{
		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x0000A57A File Offset: 0x0000877A
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x0000A582 File Offset: 0x00008782
		public int ReturnValue { get; set; }

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x0000A58B File Offset: 0x0000878B
		// (set) Token: 0x06000F2C RID: 3884 RVA: 0x0000A593 File Offset: 0x00008793
		public int GroupInvitationId { get; set; }

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000F2D RID: 3885 RVA: 0x0000A59C File Offset: 0x0000879C
		// (set) Token: 0x06000F2E RID: 3886 RVA: 0x0000A5A4 File Offset: 0x000087A4
		public bool IsInvitationAccepted { get; set; }
	}
}
