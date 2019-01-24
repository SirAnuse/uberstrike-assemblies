using System;

namespace UberStrike.Realtime.Client
{
	// Token: 0x0200032C RID: 812
	public enum IGameRoomOperationsType
	{
		// Token: 0x04000D72 RID: 3442
		JoinGame = 1,
		// Token: 0x04000D73 RID: 3443
		JoinAsSpectator,
		// Token: 0x04000D74 RID: 3444
		PowerUpRespawnTimes,
		// Token: 0x04000D75 RID: 3445
		PowerUpPicked,
		// Token: 0x04000D76 RID: 3446
		IncreaseHealthAndArmor,
		// Token: 0x04000D77 RID: 3447
		OpenDoor,
		// Token: 0x04000D78 RID: 3448
		SpawnPositions,
		// Token: 0x04000D79 RID: 3449
		RespawnRequest,
		// Token: 0x04000D7A RID: 3450
		DirectHitDamage,
		// Token: 0x04000D7B RID: 3451
		ExplosionDamage,
		// Token: 0x04000D7C RID: 3452
		DirectDamage,
		// Token: 0x04000D7D RID: 3453
		DirectDeath,
		// Token: 0x04000D7E RID: 3454
		Jump,
		// Token: 0x04000D7F RID: 3455
		UpdatePositionAndRotation,
		// Token: 0x04000D80 RID: 3456
		KickPlayer,
		// Token: 0x04000D81 RID: 3457
		IsFiring,
		// Token: 0x04000D82 RID: 3458
		IsReadyForNextMatch,
		// Token: 0x04000D83 RID: 3459
		IsPaused,
		// Token: 0x04000D84 RID: 3460
		IsInSniperMode,
		// Token: 0x04000D85 RID: 3461
		SingleBulletFire,
		// Token: 0x04000D86 RID: 3462
		SwitchWeapon,
		// Token: 0x04000D87 RID: 3463
		SwitchTeam,
		// Token: 0x04000D88 RID: 3464
		ChangeGear,
		// Token: 0x04000D89 RID: 3465
		EmitProjectile,
		// Token: 0x04000D8A RID: 3466
		EmitQuickItem,
		// Token: 0x04000D8B RID: 3467
		RemoveProjectile,
		// Token: 0x04000D8C RID: 3468
		HitFeedback,
		// Token: 0x04000D8D RID: 3469
		ActivateQuickItem,
		// Token: 0x04000D8E RID: 3470
		ChatMessage
	}
}
