using System;

namespace UberStrike.Core.Types
{
	// Token: 0x02000201 RID: 513
	[Flags]
	public enum GameModeFlag
	{
		// Token: 0x04000A60 RID: 2656
		None = 0,
		// Token: 0x04000A61 RID: 2657
		All = -1,
		// Token: 0x04000A62 RID: 2658
		DeathMatch = 1,
		// Token: 0x04000A63 RID: 2659
		TeamDeathMatch = 2,
		// Token: 0x04000A64 RID: 2660
		EliminationMode = 4
	}
}
