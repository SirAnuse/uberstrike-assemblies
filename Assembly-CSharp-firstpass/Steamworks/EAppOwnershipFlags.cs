using System;

namespace Steamworks
{
	// Token: 0x02000182 RID: 386
	[Flags]
	public enum EAppOwnershipFlags
	{
		// Token: 0x0400082D RID: 2093
		k_EAppOwnershipFlags_None = 0,
		// Token: 0x0400082E RID: 2094
		k_EAppOwnershipFlags_OwnsLicense = 1,
		// Token: 0x0400082F RID: 2095
		k_EAppOwnershipFlags_FreeLicense = 2,
		// Token: 0x04000830 RID: 2096
		k_EAppOwnershipFlags_RegionRestricted = 4,
		// Token: 0x04000831 RID: 2097
		k_EAppOwnershipFlags_LowViolence = 8,
		// Token: 0x04000832 RID: 2098
		k_EAppOwnershipFlags_InvalidPlatform = 16,
		// Token: 0x04000833 RID: 2099
		k_EAppOwnershipFlags_SharedLicense = 32,
		// Token: 0x04000834 RID: 2100
		k_EAppOwnershipFlags_FreeWeekend = 64,
		// Token: 0x04000835 RID: 2101
		k_EAppOwnershipFlags_RetailLicense = 128,
		// Token: 0x04000836 RID: 2102
		k_EAppOwnershipFlags_LicenseLocked = 256,
		// Token: 0x04000837 RID: 2103
		k_EAppOwnershipFlags_LicensePending = 512,
		// Token: 0x04000838 RID: 2104
		k_EAppOwnershipFlags_LicenseExpired = 1024,
		// Token: 0x04000839 RID: 2105
		k_EAppOwnershipFlags_LicensePermanent = 2048,
		// Token: 0x0400083A RID: 2106
		k_EAppOwnershipFlags_LicenseRecurring = 4096,
		// Token: 0x0400083B RID: 2107
		k_EAppOwnershipFlags_LicenseCanceled = 8192
	}
}
