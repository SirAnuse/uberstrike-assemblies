using System;

namespace Steamworks
{
	// Token: 0x02000188 RID: 392
	[Flags]
	public enum EMarketingMessageFlags
	{
		// Token: 0x04000876 RID: 2166
		k_EMarketingMessageFlagsNone = 0,
		// Token: 0x04000877 RID: 2167
		k_EMarketingMessageFlagsHighPriority = 1,
		// Token: 0x04000878 RID: 2168
		k_EMarketingMessageFlagsPlatformWindows = 2,
		// Token: 0x04000879 RID: 2169
		k_EMarketingMessageFlagsPlatformMac = 4,
		// Token: 0x0400087A RID: 2170
		k_EMarketingMessageFlagsPlatformLinux = 8,
		// Token: 0x0400087B RID: 2171
		k_EMarketingMessageFlagsPlatformRestrictions = 14
	}
}
