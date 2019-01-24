using System;

namespace Steamworks
{
	// Token: 0x02000164 RID: 356
	[Flags]
	public enum ERemoteStoragePlatform
	{
		// Token: 0x040006FD RID: 1789
		k_ERemoteStoragePlatformNone = 0,
		// Token: 0x040006FE RID: 1790
		k_ERemoteStoragePlatformWindows = 1,
		// Token: 0x040006FF RID: 1791
		k_ERemoteStoragePlatformOSX = 2,
		// Token: 0x04000700 RID: 1792
		k_ERemoteStoragePlatformPS3 = 4,
		// Token: 0x04000701 RID: 1793
		k_ERemoteStoragePlatformLinux = 8,
		// Token: 0x04000702 RID: 1794
		k_ERemoteStoragePlatformReserved2 = 16,
		// Token: 0x04000703 RID: 1795
		k_ERemoteStoragePlatformAll = -1
	}
}
