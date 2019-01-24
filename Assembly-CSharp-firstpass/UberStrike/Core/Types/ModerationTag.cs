using System;

namespace UberStrike.Core.Types
{
	// Token: 0x02000211 RID: 529
	[Flags]
	public enum ModerationTag
	{
		// Token: 0x04000B06 RID: 2822
		None = 0,
		// Token: 0x04000B07 RID: 2823
		Muted = 1,
		// Token: 0x04000B08 RID: 2824
		Ghosted = 2,
		// Token: 0x04000B09 RID: 2825
		Banned = 4,
		// Token: 0x04000B0A RID: 2826
		Speedhacking = 8,
		// Token: 0x04000B0B RID: 2827
		Spamming = 16,
		// Token: 0x04000B0C RID: 2828
		Language = 32,
		// Token: 0x04000B0D RID: 2829
		Name = 64
	}
}
