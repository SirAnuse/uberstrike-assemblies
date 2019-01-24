using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000326 RID: 806
	public enum ILobbyRoomEventsType
	{
		// Token: 0x04000D48 RID: 3400
		PlayerHide = 5,
		// Token: 0x04000D49 RID: 3401
		PlayerLeft,
		// Token: 0x04000D4A RID: 3402
		PlayerUpdate,
		// Token: 0x04000D4B RID: 3403
		UpdateContacts,
		// Token: 0x04000D4C RID: 3404
		FullPlayerListUpdate,
		// Token: 0x04000D4D RID: 3405
		PlayerJoined,
		// Token: 0x04000D4E RID: 3406
		ClanChatMessage,
		// Token: 0x04000D4F RID: 3407
		InGameChatMessage,
		// Token: 0x04000D50 RID: 3408
		LobbyChatMessage,
		// Token: 0x04000D51 RID: 3409
		PrivateChatMessage,
		// Token: 0x04000D52 RID: 3410
		UpdateInboxRequests,
		// Token: 0x04000D53 RID: 3411
		UpdateFriendsList,
		// Token: 0x04000D54 RID: 3412
		UpdateInboxMessages,
		// Token: 0x04000D55 RID: 3413
		UpdateClanMembers,
		// Token: 0x04000D56 RID: 3414
		UpdateClanData,
		// Token: 0x04000D57 RID: 3415
		UpdateActorsForModeration,
		// Token: 0x04000D58 RID: 3416
		ModerationCustomMessage,
		// Token: 0x04000D59 RID: 3417
		ModerationMutePlayer,
		// Token: 0x04000D5A RID: 3418
		ModerationKickGame
	}
}
