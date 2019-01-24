using System;

namespace UberStrike.Core.Models
{
	// Token: 0x0200021E RID: 542
	[Flags]
	public enum PlayerStates : byte
	{
		// Token: 0x04000B62 RID: 2914
		None = 0,
		// Token: 0x04000B63 RID: 2915
		Spectator = 1,
		// Token: 0x04000B64 RID: 2916
		Dead = 2,
		// Token: 0x04000B65 RID: 2917
		Paused = 4,
		// Token: 0x04000B66 RID: 2918
		Sniping = 8,
		// Token: 0x04000B67 RID: 2919
		Shooting = 16,
		// Token: 0x04000B68 RID: 2920
		Ready = 32,
		// Token: 0x04000B69 RID: 2921
		Offline = 64
	}
}
