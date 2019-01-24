using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200001E RID: 30
	public enum MemberAccessLevel
	{
		// Token: 0x040000C2 RID: 194
		Default,
		// Token: 0x040000C3 RID: 195
		QA = 3,
		// Token: 0x040000C4 RID: 196
		Moderator,
		// Token: 0x040000C5 RID: 197
		SeniorQA = 6,
		// Token: 0x040000C6 RID: 198
		SeniorModerator,
		// Token: 0x040000C7 RID: 199
		Admin = 10
	}
}
