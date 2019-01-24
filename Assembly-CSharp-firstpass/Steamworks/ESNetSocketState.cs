using System;

namespace Steamworks
{
	// Token: 0x02000161 RID: 353
	public enum ESNetSocketState
	{
		// Token: 0x040006EA RID: 1770
		k_ESNetSocketStateInvalid,
		// Token: 0x040006EB RID: 1771
		k_ESNetSocketStateConnected,
		// Token: 0x040006EC RID: 1772
		k_ESNetSocketStateInitiated = 10,
		// Token: 0x040006ED RID: 1773
		k_ESNetSocketStateLocalCandidatesFound,
		// Token: 0x040006EE RID: 1774
		k_ESNetSocketStateReceivedRemoteCandidates,
		// Token: 0x040006EF RID: 1775
		k_ESNetSocketStateChallengeHandshake = 15,
		// Token: 0x040006F0 RID: 1776
		k_ESNetSocketStateDisconnecting = 21,
		// Token: 0x040006F1 RID: 1777
		k_ESNetSocketStateLocalDisconnect,
		// Token: 0x040006F2 RID: 1778
		k_ESNetSocketStateTimeoutDuringConnect,
		// Token: 0x040006F3 RID: 1779
		k_ESNetSocketStateRemoteEndDisconnected,
		// Token: 0x040006F4 RID: 1780
		k_ESNetSocketStateConnectionBroken
	}
}
