using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000018 RID: 24
	[Serializable]
	public enum MemberOperationResult
	{
		// Token: 0x04000099 RID: 153
		Ok,
		// Token: 0x0400009A RID: 154
		DuplicateEmail = 2,
		// Token: 0x0400009B RID: 155
		DuplicateName,
		// Token: 0x0400009C RID: 156
		DuplicateHandle,
		// Token: 0x0400009D RID: 157
		DuplicateEmailName,
		// Token: 0x0400009E RID: 158
		MemberNotFound,
		// Token: 0x0400009F RID: 159
		InvalidData = 9,
		// Token: 0x040000A0 RID: 160
		InvalidHandle,
		// Token: 0x040000A1 RID: 161
		InvalidEsns,
		// Token: 0x040000A2 RID: 162
		InvalidCmid,
		// Token: 0x040000A3 RID: 163
		InvalidName,
		// Token: 0x040000A4 RID: 164
		InvalidEmail,
		// Token: 0x040000A5 RID: 165
		InvalidPassword,
		// Token: 0x040000A6 RID: 166
		OffensiveName,
		// Token: 0x040000A7 RID: 167
		NameChangeNotInInventory,
		// Token: 0x040000A8 RID: 168
		AlreadyHasAnESNSAccountOfThisTypeAttached
	}
}
