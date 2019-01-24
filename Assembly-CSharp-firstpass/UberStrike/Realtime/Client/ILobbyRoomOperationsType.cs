using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000324 RID: 804
	public enum ILobbyRoomOperationsType
	{
		// Token: 0x04000D28 RID: 3368
		FullPlayerListUpdate = 1,
		// Token: 0x04000D29 RID: 3369
		UpdatePlayerRoom,
		// Token: 0x04000D2A RID: 3370
		ResetPlayerRoom,
		// Token: 0x04000D2B RID: 3371
		UpdateFriendsList,
		// Token: 0x04000D2C RID: 3372
		UpdateClanData,
		// Token: 0x04000D2D RID: 3373
		UpdateInboxMessages,
		// Token: 0x04000D2E RID: 3374
		UpdateInboxRequests,
		// Token: 0x04000D2F RID: 3375
		UpdateClanMembers,
		// Token: 0x04000D30 RID: 3376
		GetPlayersWithMatchingName,
		// Token: 0x04000D31 RID: 3377
		ChatMessageToAll,
		// Token: 0x04000D32 RID: 3378
		ChatMessageToPlayer,
		// Token: 0x04000D33 RID: 3379
		ChatMessageToClan,
		// Token: 0x04000D34 RID: 3380
		ModerationMutePlayer,
		// Token: 0x04000D35 RID: 3381
		ModerationPermanentBan,
		// Token: 0x04000D36 RID: 3382
		ModerationBanPlayer,
		// Token: 0x04000D37 RID: 3383
		ModerationKickGame,
		// Token: 0x04000D38 RID: 3384
		ModerationUnbanPlayer,
		// Token: 0x04000D39 RID: 3385
		ModerationCustomMessage,
		// Token: 0x04000D3A RID: 3386
		SpeedhackDetection,
		// Token: 0x04000D3B RID: 3387
		SpeedhackDetectionNew,
		// Token: 0x04000D3C RID: 3388
		PlayersReported,
		// Token: 0x04000D3D RID: 3389
		UpdateNaughtyList,
		// Token: 0x04000D3E RID: 3390
		ClearModeratorFlags,
		// Token: 0x04000D3F RID: 3391
		SetContactList,
		// Token: 0x04000D40 RID: 3392
		UpdateAllActors,
		// Token: 0x04000D41 RID: 3393
		UpdateContacts
	}
}
