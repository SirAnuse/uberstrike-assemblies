using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200002A RID: 42
	public enum EmailNotificationType
	{
		// Token: 0x04000118 RID: 280
		DeleteMember = 1,
		// Token: 0x04000119 RID: 281
		BanMemberPermanent,
		// Token: 0x0400011A RID: 282
		MergeMembers,
		// Token: 0x0400011B RID: 283
		ChangeMemberName = 8,
		// Token: 0x0400011C RID: 284
		ChangeMemberPassword,
		// Token: 0x0400011D RID: 285
		ChangeMemberEmail = 11,
		// Token: 0x0400011E RID: 286
		BanMemberTemporary,
		// Token: 0x0400011F RID: 287
		UnbanMember,
		// Token: 0x04000120 RID: 288
		BanMemberChatPermanent,
		// Token: 0x04000121 RID: 289
		BanMemberChatTemporary,
		// Token: 0x04000122 RID: 290
		UnbanMemberChat,
		// Token: 0x04000123 RID: 291
		ChangeClanTag,
		// Token: 0x04000124 RID: 292
		ChangeClanName,
		// Token: 0x04000125 RID: 293
		ChangeClanMotto
	}
}
