using System;

namespace Steamworks
{
	// Token: 0x0200015D RID: 349
	[Flags]
	public enum EChatMemberStateChange
	{
		// Token: 0x040006D3 RID: 1747
		k_EChatMemberStateChangeEntered = 1,
		// Token: 0x040006D4 RID: 1748
		k_EChatMemberStateChangeLeft = 2,
		// Token: 0x040006D5 RID: 1749
		k_EChatMemberStateChangeDisconnected = 4,
		// Token: 0x040006D6 RID: 1750
		k_EChatMemberStateChangeKicked = 8,
		// Token: 0x040006D7 RID: 1751
		k_EChatMemberStateChangeBanned = 16
	}
}
