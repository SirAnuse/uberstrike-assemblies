using System;

namespace Steamworks
{
	// Token: 0x02000183 RID: 387
	[Flags]
	public enum EAppType
	{
		// Token: 0x0400083D RID: 2109
		k_EAppType_Invalid = 0,
		// Token: 0x0400083E RID: 2110
		k_EAppType_Game = 1,
		// Token: 0x0400083F RID: 2111
		k_EAppType_Application = 2,
		// Token: 0x04000840 RID: 2112
		k_EAppType_Tool = 4,
		// Token: 0x04000841 RID: 2113
		k_EAppType_Demo = 8,
		// Token: 0x04000842 RID: 2114
		k_EAppType_Media_DEPRECATED = 16,
		// Token: 0x04000843 RID: 2115
		k_EAppType_DLC = 32,
		// Token: 0x04000844 RID: 2116
		k_EAppType_Guide = 64,
		// Token: 0x04000845 RID: 2117
		k_EAppType_Driver = 128,
		// Token: 0x04000846 RID: 2118
		k_EAppType_Config = 256,
		// Token: 0x04000847 RID: 2119
		k_EAppType_Film = 512,
		// Token: 0x04000848 RID: 2120
		k_EAppType_TVSeries = 1024,
		// Token: 0x04000849 RID: 2121
		k_EAppType_Video = 2048,
		// Token: 0x0400084A RID: 2122
		k_EAppType_Plugin = 4096,
		// Token: 0x0400084B RID: 2123
		k_EAppType_Music = 8192,
		// Token: 0x0400084C RID: 2124
		k_EAppType_Shortcut = 1073741824,
		// Token: 0x0400084D RID: 2125
		k_EAppType_DepotOnly = -2147483647
	}
}
