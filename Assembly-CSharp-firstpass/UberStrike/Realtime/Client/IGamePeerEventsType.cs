using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x0200032D RID: 813
	public enum IGamePeerEventsType
	{
		// Token: 0x04000D90 RID: 3472
		HeartbeatChallenge = 1,
		// Token: 0x04000D91 RID: 3473
		RoomEntered,
		// Token: 0x04000D92 RID: 3474
		RoomEnterFailed,
		// Token: 0x04000D93 RID: 3475
		RequestPasswordForRoom,
		// Token: 0x04000D94 RID: 3476
		RoomLeft,
		// Token: 0x04000D95 RID: 3477
		FullGameList,
		// Token: 0x04000D96 RID: 3478
		GameListUpdate,
		// Token: 0x04000D97 RID: 3479
		GameListUpdateEnd,
		// Token: 0x04000D98 RID: 3480
		GetGameInformation,
		// Token: 0x04000D99 RID: 3481
		ServerLoadData,
		// Token: 0x04000D9A RID: 3482
		DisconnectAndDisablePhoton
	}
}
