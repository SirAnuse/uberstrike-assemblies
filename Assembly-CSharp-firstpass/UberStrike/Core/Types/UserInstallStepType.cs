using System;

namespace UberStrike.Core.Types
{
	// Token: 0x02000203 RID: 515
	public enum UserInstallStepType
	{
		// Token: 0x04000A69 RID: 2665
		InvalidWsCall,
		// Token: 0x04000A6A RID: 2666
		NoUnity,
		// Token: 0x04000A6B RID: 2667
		ClickDownload,
		// Token: 0x04000A6C RID: 2668
		UnityInstalled,
		// Token: 0x04000A6D RID: 2669
		FullGameLoaded,
		// Token: 0x04000A6E RID: 2670
		ClickCancel,
		// Token: 0x04000A6F RID: 2671
		UnityInitialized,
		// Token: 0x04000A70 RID: 2672
		AccountCreated,
		// Token: 0x04000A71 RID: 2673
		HasUnity
	}
}
