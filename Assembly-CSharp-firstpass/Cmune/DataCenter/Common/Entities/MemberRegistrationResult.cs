using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000017 RID: 23
	public enum MemberRegistrationResult
	{
		// Token: 0x04000088 RID: 136
		Ok,
		// Token: 0x04000089 RID: 137
		InvalidEmail,
		// Token: 0x0400008A RID: 138
		InvalidName,
		// Token: 0x0400008B RID: 139
		InvalidPassword,
		// Token: 0x0400008C RID: 140
		DuplicateEmail,
		// Token: 0x0400008D RID: 141
		DuplicateName,
		// Token: 0x0400008E RID: 142
		DuplicateEmailName,
		// Token: 0x0400008F RID: 143
		InvalidData,
		// Token: 0x04000090 RID: 144
		InvalidHandle,
		// Token: 0x04000091 RID: 145
		DuplicateHandle,
		// Token: 0x04000092 RID: 146
		InvalidEsns,
		// Token: 0x04000093 RID: 147
		MemberNotFound,
		// Token: 0x04000094 RID: 148
		OffensiveName,
		// Token: 0x04000095 RID: 149
		IsIpBanned,
		// Token: 0x04000096 RID: 150
		EmailAlreadyLinkedToActualEsns,
		// Token: 0x04000097 RID: 151
		Error_MemberNotCreated
	}
}
