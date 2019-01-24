using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x0200032B RID: 811
	public enum IGamePeerOperationsType
	{
		// Token: 0x04000D62 RID: 3426
		SendHeartbeatResponse = 1,
		// Token: 0x04000D63 RID: 3427
		GetServerLoad,
		// Token: 0x04000D64 RID: 3428
		GetGameInformation,
		// Token: 0x04000D65 RID: 3429
		GetGameListUpdates,
		// Token: 0x04000D66 RID: 3430
		EnterRoom,
		// Token: 0x04000D67 RID: 3431
		CreateRoom,
		// Token: 0x04000D68 RID: 3432
		LeaveRoom,
		// Token: 0x04000D69 RID: 3433
		CloseRoom,
		// Token: 0x04000D6A RID: 3434
		InspectRoom,
		// Token: 0x04000D6B RID: 3435
		ReportPlayer,
		// Token: 0x04000D6C RID: 3436
		KickPlayer,
		// Token: 0x04000D6D RID: 3437
		UpdateLoadout,
		// Token: 0x04000D6E RID: 3438
		UpdatePing,
		// Token: 0x04000D6F RID: 3439
		UpdateKeyState,
		// Token: 0x04000D70 RID: 3440
		RefreshBackendData
	}
}
