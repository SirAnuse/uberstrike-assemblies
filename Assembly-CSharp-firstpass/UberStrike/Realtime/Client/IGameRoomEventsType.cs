using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x0200032E RID: 814
	public enum IGameRoomEventsType
	{
		// Token: 0x04000D9C RID: 3484
		PowerUpPicked = 12,
		// Token: 0x04000D9D RID: 3485
		SetPowerupState,
		// Token: 0x04000D9E RID: 3486
		ResetAllPowerups,
		// Token: 0x04000D9F RID: 3487
		DoorOpen,
		// Token: 0x04000DA0 RID: 3488
		DisconnectCountdown,
		// Token: 0x04000DA1 RID: 3489
		MatchStartCountdown,
		// Token: 0x04000DA2 RID: 3490
		MatchStart,
		// Token: 0x04000DA3 RID: 3491
		MatchEnd,
		// Token: 0x04000DA4 RID: 3492
		TeamWins,
		// Token: 0x04000DA5 RID: 3493
		WaitingForPlayers,
		// Token: 0x04000DA6 RID: 3494
		PrepareNextRound,
		// Token: 0x04000DA7 RID: 3495
		AllPlayers,
		// Token: 0x04000DA8 RID: 3496
		AllPlayerDeltas,
		// Token: 0x04000DA9 RID: 3497
		AllPlayerPositions,
		// Token: 0x04000DAA RID: 3498
		PlayerDelta,
		// Token: 0x04000DAB RID: 3499
		PlayerJumped,
		// Token: 0x04000DAC RID: 3500
		PlayerRespawnCountdown,
		// Token: 0x04000DAD RID: 3501
		PlayerRespawned,
		// Token: 0x04000DAE RID: 3502
		PlayerJoinedGame,
		// Token: 0x04000DAF RID: 3503
		JoinGameFailed,
		// Token: 0x04000DB0 RID: 3504
		PlayerLeftGame,
		// Token: 0x04000DB1 RID: 3505
		PlayerChangedTeam,
		// Token: 0x04000DB2 RID: 3506
		JoinedAsSpectator,
		// Token: 0x04000DB3 RID: 3507
		PlayersReadyUpdated,
		// Token: 0x04000DB4 RID: 3508
		DamageEvent,
		// Token: 0x04000DB5 RID: 3509
		PlayerKilled,
		// Token: 0x04000DB6 RID: 3510
		UpdateRoundScore,
		// Token: 0x04000DB7 RID: 3511
		KillsRemaining,
		// Token: 0x04000DB8 RID: 3512
		LevelUp,
		// Token: 0x04000DB9 RID: 3513
		KickPlayer,
		// Token: 0x04000DBA RID: 3514
		QuickItemEvent,
		// Token: 0x04000DBB RID: 3515
		SingleBulletFire,
		// Token: 0x04000DBC RID: 3516
		PlayerHit,
		// Token: 0x04000DBD RID: 3517
		RemoveProjectile,
		// Token: 0x04000DBE RID: 3518
		EmitProjectile,
		// Token: 0x04000DBF RID: 3519
		EmitQuickItem,
		// Token: 0x04000DC0 RID: 3520
		ActivateQuickItem,
		// Token: 0x04000DC1 RID: 3521
		ChatMessage
	}
}
