using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200001F RID: 31
	public class GroupOperationResult
	{
		// Token: 0x040000C8 RID: 200
		public const int Ok = 0;

		// Token: 0x040000C9 RID: 201
		public const int InvalidName = 1;

		// Token: 0x040000CA RID: 202
		public const int AlreadyMemberOfAGroup = 2;

		// Token: 0x040000CB RID: 203
		public const int DuplicateName = 3;

		// Token: 0x040000CC RID: 204
		public const int InvalidTag = 4;

		// Token: 0x040000CD RID: 205
		public const int MemberNotFound = 5;

		// Token: 0x040000CE RID: 206
		public const int GroupNotFound = 6;

		// Token: 0x040000CF RID: 207
		public const int GroupFull = 7;

		// Token: 0x040000D0 RID: 208
		public const int InvalidMotto = 8;

		// Token: 0x040000D1 RID: 209
		public const int InvalidDescription = 9;

		// Token: 0x040000D2 RID: 210
		public const int DuplicateTag = 10;

		// Token: 0x040000D3 RID: 211
		public const int OffensiveName = 13;

		// Token: 0x040000D4 RID: 212
		public const int OffensiveTag = 14;

		// Token: 0x040000D5 RID: 213
		public const int OffensiveMotto = 15;

		// Token: 0x040000D6 RID: 214
		public const int OffensiveDescription = 16;

		// Token: 0x040000D7 RID: 215
		public const int IsNotOwner = 17;

		// Token: 0x040000D8 RID: 216
		public const int NotEnoughRight = 18;

		// Token: 0x040000D9 RID: 217
		public const int IsOwner = 19;

		// Token: 0x040000DA RID: 218
		public const int RequestNotFound = 20;

		// Token: 0x040000DB RID: 219
		public const int ExistingMemberRequest = 21;

		// Token: 0x040000DC RID: 220
		public const int InvitationNotFound = 23;

		// Token: 0x040000DD RID: 221
		public const int AlreadyInvited = 24;
	}
}
