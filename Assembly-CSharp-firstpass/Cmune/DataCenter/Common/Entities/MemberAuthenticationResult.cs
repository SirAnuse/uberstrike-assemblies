using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000016 RID: 22
	public enum MemberAuthenticationResult
	{
		// Token: 0x0400007C RID: 124
		Ok,
		// Token: 0x0400007D RID: 125
		InvalidData,
		// Token: 0x0400007E RID: 126
		InvalidName,
		// Token: 0x0400007F RID: 127
		InvalidEmail,
		// Token: 0x04000080 RID: 128
		InvalidPassword,
		// Token: 0x04000081 RID: 129
		IsBanned,
		// Token: 0x04000082 RID: 130
		InvalidHandle,
		// Token: 0x04000083 RID: 131
		InvalidEsns,
		// Token: 0x04000084 RID: 132
		InvalidCookie,
		// Token: 0x04000085 RID: 133
		IsIpBanned,
		// Token: 0x04000086 RID: 134
		UnknownError
	}
}
