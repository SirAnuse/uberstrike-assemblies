using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000005 RID: 5
	public enum BuyItemResult
	{
		// Token: 0x0400000F RID: 15
		OK,
		// Token: 0x04000010 RID: 16
		DisableInShop,
		// Token: 0x04000011 RID: 17
		DisableForRent = 3,
		// Token: 0x04000012 RID: 18
		DisableForPermanent,
		// Token: 0x04000013 RID: 19
		DurationDisabled,
		// Token: 0x04000014 RID: 20
		PackDisabled,
		// Token: 0x04000015 RID: 21
		IsNotForSale,
		// Token: 0x04000016 RID: 22
		NotEnoughCurrency,
		// Token: 0x04000017 RID: 23
		InvalidMember,
		// Token: 0x04000018 RID: 24
		InvalidExpirationDate,
		// Token: 0x04000019 RID: 25
		AlreadyInInventory,
		// Token: 0x0400001A RID: 26
		InvalidAmount,
		// Token: 0x0400001B RID: 27
		NoStockRemaining,
		// Token: 0x0400001C RID: 28
		InvalidData,
		// Token: 0x0400001D RID: 29
		TooManyUsage,
		// Token: 0x0400001E RID: 30
		InvalidLevel = 100,
		// Token: 0x0400001F RID: 31
		ItemNotFound = 404
	}
}
