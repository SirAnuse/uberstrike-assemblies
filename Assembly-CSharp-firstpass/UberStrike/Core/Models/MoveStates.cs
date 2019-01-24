using System;

namespace UberStrike.Core.Models
{
	// Token: 0x0200021D RID: 541
	[Flags]
	public enum MoveStates : byte
	{
		// Token: 0x04000B58 RID: 2904
		None = 0,
		// Token: 0x04000B59 RID: 2905
		Grounded = 1,
		// Token: 0x04000B5A RID: 2906
		Jumping = 2,
		// Token: 0x04000B5B RID: 2907
		Flying = 4,
		// Token: 0x04000B5C RID: 2908
		Ducked = 8,
		// Token: 0x04000B5D RID: 2909
		Wading = 16,
		// Token: 0x04000B5E RID: 2910
		Swimming = 32,
		// Token: 0x04000B5F RID: 2911
		Diving = 64,
		// Token: 0x04000B60 RID: 2912
		Landed = 128
	}
}
