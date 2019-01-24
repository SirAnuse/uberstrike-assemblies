using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000029 RID: 41
	public enum ModerationActionType
	{
		// Token: 0x0400010A RID: 266
		AccountPermanentBan,
		// Token: 0x0400010B RID: 267
		AccountTemporaryBan,
		// Token: 0x0400010C RID: 268
		ChatPermanentBan,
		// Token: 0x0400010D RID: 269
		ChatTemporaryBan,
		// Token: 0x0400010E RID: 270
		Warning,
		// Token: 0x0400010F RID: 271
		Note,
		// Token: 0x04000110 RID: 272
		AccountNameChange,
		// Token: 0x04000111 RID: 273
		InvalidNameChange,
		// Token: 0x04000112 RID: 274
		ItemExchange,
		// Token: 0x04000113 RID: 275
		Refund,
		// Token: 0x04000114 RID: 276
		RescueFromAccountStealing,
		// Token: 0x04000115 RID: 277
		IpBan,
		// Token: 0x04000116 RID: 278
		AccountEmailChange
	}
}
