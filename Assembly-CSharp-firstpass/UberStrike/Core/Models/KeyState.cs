using System;

namespace UberStrike.Core.Models
{
	// Token: 0x0200021F RID: 543
	[Flags]
	public enum KeyState : byte
	{
		// Token: 0x04000B6B RID: 2923
		Still = 0,
		// Token: 0x04000B6C RID: 2924
		Forward = 1,
		// Token: 0x04000B6D RID: 2925
		Backward = 2,
		// Token: 0x04000B6E RID: 2926
		Left = 4,
		// Token: 0x04000B6F RID: 2927
		Right = 8,
		// Token: 0x04000B70 RID: 2928
		Jump = 16,
		// Token: 0x04000B71 RID: 2929
		Crouch = 32,
		// Token: 0x04000B72 RID: 2930
		Vertical = 3,
		// Token: 0x04000B73 RID: 2931
		Horizontal = 12,
		// Token: 0x04000B74 RID: 2932
		Walking = 15
	}
}
