using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000036 RID: 54
	public enum ClaimFacebookGiftResult
	{
		// Token: 0x0400015F RID: 351
		ErrorUnknown,
		// Token: 0x04000160 RID: 352
		ErrorCouldNotFindRequest,
		// Token: 0x04000161 RID: 353
		ErrorRequestHasInvalidData,
		// Token: 0x04000162 RID: 354
		ErrorCouldNotDeleteRequest,
		// Token: 0x04000163 RID: 355
		ErrorCouldNotGenerateItemId,
		// Token: 0x04000164 RID: 356
		AlreadyOwnedPermanently,
		// Token: 0x04000165 RID: 357
		RentalTimeProlonged,
		// Token: 0x04000166 RID: 358
		NewItemAttributed,
		// Token: 0x04000167 RID: 359
		ErrorWhileSavingItemChanges,
		// Token: 0x04000168 RID: 360
		ErrorClaimerIsNotReceiver
	}
}
