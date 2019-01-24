using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.Client;
using UnityEngine;

// Token: 0x0200037B RID: 891
public class DeathMatchRoom : BaseGameRoom, IDisposable, IGameMode
{
	// Token: 0x0600195F RID: 6495 RVA: 0x000876C8 File Offset: 0x000858C8
	public DeathMatchRoom(GameRoomData gameData, GamePeer peer)
	{
		GameState.Current.MatchState.RegisterState(GameStateId.MatchRunning, new MatchRunningState(GameState.Current.MatchState));
		GameState.Current.MatchState.RegisterState(GameStateId.PregameLoadout, new PregameLoadoutState(GameState.Current.MatchState));
		GameState.Current.MatchState.RegisterState(GameStateId.PrepareNextRound, new PrepareNextRoundState(GameState.Current.MatchState));
		GameState.Current.MatchState.RegisterState(GameStateId.EndOfMatch, new EndOfMatchState(GameState.Current.MatchState));
		GameState.Current.MatchState.RegisterState(GameStateId.WaitingForPlayers, new WaitingForPlayersState(GameState.Current.MatchState));
		GameState.Current.MatchState.RegisterState(GameStateId.AfterRound, new AfterRoundState(GameState.Current.MatchState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Overview, new PlayerOverviewState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Playing, new PlayerPlayingState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.PrepareForMatch, new PlayerPrepareState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Killed, new PlayerKilledState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Paused, new PlayerPausedState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.AfterRound, new PlayerAfterRoundState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Spectating, new PlayerSpectatingState(GameState.Current.PlayerState));
		GameState.Current.PlayerData.SendJumpUpdate += base.Operations.SendJump;
		GameState.Current.PlayerData.SendMovementUpdate += base.Operations.SendUpdatePositionAndRotation;
		GameState.Current.RoomData = gameData;
		GameState.Current.Actions.IncreaseHealthAndArmor = delegate(int health, int armor)
		{
			base.Operations.SendIncreaseHealthAndArmor((byte)health, (byte)armor);
		};
		GameState.Current.Actions.RequestRespawn = new Action(base.Operations.SendRespawnRequest);
		GameState.Current.Actions.PickupPowerup = delegate(int pickupID, PickupItemType type, int value)
		{
			base.Operations.SendPowerUpPicked(pickupID, (byte)type, (byte)value);
		};
		GameState.Current.Actions.OpenDoor = new Action<int>(base.Operations.SendOpenDoor);
		GameState.Current.Actions.EmitQuickItem = new Action<Vector3, Vector3, int, byte, int>(base.Operations.SendEmitQuickItem);
		GameState.Current.Actions.EmitProjectile = delegate(Vector3 origin, Vector3 direction, global::LoadoutSlotType slot, int projectileID, bool explode)
		{
			base.Operations.SendEmitProjectile(origin, direction, (byte)slot, projectileID, explode);
		};
		GameState.Current.Actions.RemoveProjectile = new Action<int, bool>(base.Operations.SendRemoveProjectile);
		GameState.Current.Actions.SingleBulletFire = new Action(base.Operations.SendSingleBulletFire);
		GameState.Current.Actions.KillPlayer = delegate()
		{
			if (GameState.Current.IsInGame && GameState.Current.PlayerData.IsAlive)
			{
				base.Operations.SendDirectDeath();
			}
		};
		GameState.Current.Actions.DirectHitDamage = delegate(int targetCmid, ushort damage, BodyPart part, Vector3 force, byte slot, byte bullets)
		{
			base.Operations.SendDirectHitDamage(targetCmid, (byte)part, bullets);
			if (PlayerDataManager.Cmid == targetCmid)
			{
				GameStateHelper.PlayerHit(targetCmid, damage, part, force);
			}
		};
		GameState.Current.Actions.ExplosionHitDamage = delegate(int targetCmid, ushort damage, Vector3 force, byte slot, byte distance)
		{
			base.Operations.SendExplosionDamage(targetCmid, slot, distance, force);
			if (PlayerDataManager.Cmid == targetCmid)
			{
				GameStateHelper.PlayerHit(targetCmid, damage, BodyPart.Body, force);
			}
		};
		GameState.Current.Actions.PlayerHitFeeback = new Action<int, Vector3>(base.Operations.SendHitFeedback);
		GameState.Current.Actions.ActivateQuickItem = new Action<QuickItemLogic, int, int, bool>(base.Operations.SendActivateQuickItem);
		GameState.Current.Actions.JoinTeam = delegate(TeamID team)
		{
			base.Operations.SendJoinGame(team);
			GameState.Current.MatchState.PopAllStates();
		};
		GameState.Current.Actions.JoinAsSpectator = delegate()
		{
			base.Operations.SendJoinAsSpectator();
			GameState.Current.MatchState.PopAllStates();
		};
		GameState.Current.Actions.KickPlayer = new Action<int>(base.Operations.SendKickPlayer);
		GameState.Current.Actions.ChatMessage = new Action<string, byte>(base.Operations.SendChatMessage);
		GameState.Current.PlayerData.Actions.Clear();
		PlayerActions actions = GameState.Current.PlayerData.Actions;
		actions.UpdateKeyState = (Action<byte>)Delegate.Combine(actions.UpdateKeyState, new Action<byte>(peer.Operations.SendUpdateKeyState));
		PlayerActions actions2 = GameState.Current.PlayerData.Actions;
		actions2.SwitchWeapon = (Action<byte>)Delegate.Combine(actions2.SwitchWeapon, new Action<byte>(base.Operations.SendSwitchWeapon));
		PlayerActions actions3 = GameState.Current.PlayerData.Actions;
		actions3.UpdatePing = (Action<ushort>)Delegate.Combine(actions3.UpdatePing, new Action<ushort>(peer.Operations.SendUpdatePing));
		PlayerActions actions4 = GameState.Current.PlayerData.Actions;
		actions4.PausePlayer = (Action<bool>)Delegate.Combine(actions4.PausePlayer, new Action<bool>(base.Operations.SendIsPaused));
		PlayerActions actions5 = GameState.Current.PlayerData.Actions;
		actions5.SniperMode = (Action<bool>)Delegate.Combine(actions5.SniperMode, new Action<bool>(base.Operations.SendIsInSniperMode));
		PlayerActions actions6 = GameState.Current.PlayerData.Actions;
		actions6.AutomaticFire = (Action<bool>)Delegate.Combine(actions6.AutomaticFire, new Action<bool>(base.Operations.SendIsFiring));
		PlayerActions actions7 = GameState.Current.PlayerData.Actions;
		actions7.SetReadyForNextGame = (Action<bool>)Delegate.Combine(actions7.SetReadyForNextGame, new Action<bool>(base.Operations.SendIsReadyForNextMatch));
		TabScreenPanelGUI.SortPlayersByRank = new Action<IEnumerable<GameActorInfo>>(GameStateHelper.SortDeathMatchPlayers);
		Singleton<QuickItemController>.Instance.IsConsumptionEnabled = true;
		Singleton<QuickItemController>.Instance.Restriction.IsEnabled = true;
		Singleton<QuickItemController>.Instance.Restriction.RenewGameUses();
		AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate += this.OnUpdate;
	}

	// Token: 0x06001960 RID: 6496 RVA: 0x00087C8C File Offset: 0x00085E8C
	public void Dispose()
	{
		if (!this.isDisposed)
		{
			this.isDisposed = true;
			AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate -= this.OnUpdate;
			GameState.Current.PlayerData.SendJumpUpdate -= base.Operations.SendJump;
			GameState.Current.PlayerData.SendMovementUpdate -= base.Operations.SendUpdatePositionAndRotation;
			GameStateHelper.ExitGameMode();
		}
	}

	// Token: 0x06001961 RID: 6497 RVA: 0x00010E0C File Offset: 0x0000F00C
	private void OnUpdate()
	{
		Singleton<QuickItemController>.Instance.Update();
	}

	// Token: 0x06001962 RID: 6498 RVA: 0x00087D04 File Offset: 0x00085F04
	protected override void OnPlayerJoinedGame(GameActorInfo player, PlayerMovement position)
	{
		Debug.Log(string.Concat(new object[]
		{
			"OnPlayerJoinedGame ",
			player.PlayerName,
			" ",
			GameState.Current.MatchState.CurrentStateId
		}));
		GameState.Current.Players[player.Cmid] = player;
		if (player.Cmid == PlayerDataManager.Cmid)
		{
			GameState.Current.PlayerData.Player = player;
			GameState.Current.PlayerData.Team.Value = player.TeamID;
		}
		else
		{
			GameState.Current.RemotePlayerStates.AddCharacterInfo(player, position);
		}
		if (GameState.Current.MatchState.CurrentStateId != GameStateId.None && !player.IsSpectator)
		{
			GameState.Current.InstantiateAvatar(player);
		}
	}

	// Token: 0x06001963 RID: 6499 RVA: 0x00087DD8 File Offset: 0x00085FD8
	protected override void OnJoinGameFailed(string message)
	{
		Debug.LogError("OnJoinGameFailed " + message);
		PopupSystem.ClearAll();
		PopupSystem.ShowMessage("Join Game failed", message, PopupSystem.AlertType.OK, delegate()
		{
			GameState.Current.MatchState.SetState(GameStateId.PregameLoadout);
		});
	}

	// Token: 0x06001964 RID: 6500 RVA: 0x00010E18 File Offset: 0x0000F018
	protected override void OnJoinedAsSpectator()
	{
		GameState.Current.PlayerData.Set(PlayerStates.Spectator, true);
	}

	// Token: 0x06001965 RID: 6501 RVA: 0x00010E2B File Offset: 0x0000F02B
	protected override void OnPlayerLeftGame(int cmid)
	{
		GameState.Current.PlayerLeftGame(cmid);
	}

	// Token: 0x06001966 RID: 6502 RVA: 0x00087E28 File Offset: 0x00086028
	protected override void OnPrepareNextRound()
	{
		GameState.Current.MatchState.SetState(GameStateId.PrepareNextRound);
		if (GameState.Current.Players.ContainsKey(PlayerDataManager.Cmid))
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.PrepareForMatch);
			return;
		}
		GameState.Current.PlayerState.SetState(PlayerStateId.Spectating);
	}

	// Token: 0x06001967 RID: 6503 RVA: 0x00087E7C File Offset: 0x0008607C
	protected override void OnWaitingForPlayers()
	{
		GameState.Current.MatchState.SetState(GameStateId.WaitingForPlayers);
		if (GameState.Current.Players.ContainsKey(PlayerDataManager.Cmid))
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.Playing);
			return;
		}
		GameState.Current.PlayerState.SetState(PlayerStateId.Spectating);
	}

	// Token: 0x06001968 RID: 6504 RVA: 0x00010E38 File Offset: 0x0000F038
	protected override void OnMatchStartCountdown(byte countdown)
	{
		global::EventHandler.Global.Fire(new GameEvents.MatchCountdown
		{
			Countdown = (int)countdown
		});
	}

	// Token: 0x06001969 RID: 6505 RVA: 0x00010E50 File Offset: 0x0000F050
	protected override void OnMatchStart(int roundNumber, int endTime)
	{
		GameState.Current.StartMatch(roundNumber, endTime);
		GameState.Current.MatchState.SetState(GameStateId.MatchRunning);
	}

	// Token: 0x0600196A RID: 6506 RVA: 0x00010E6E File Offset: 0x0000F06E
	protected override void OnMatchEnd(EndOfMatchData data)
	{
		GameState.Current.Statistics.Update(data);
		GameState.Current.MatchState.SetState(GameStateId.EndOfMatch);
		GameState.Current.UpdatePlayersReady();
	}

	// Token: 0x0600196B RID: 6507 RVA: 0x00087ED0 File Offset: 0x000860D0
	protected override void OnTeamWins(TeamID team)
	{
		GameData.Instance.OnHUDChatClear.Fire();
		GameData.Instance.OnHUDStreamClear.Fire();
		GameState.Current.MatchState.SetState(GameStateId.AfterRound);
		PlayerLeadAudio.LeadState currentLead = GameState.Current.LeadStatus.CurrentLead;
		if (currentLead == PlayerLeadAudio.LeadState.Me)
		{
			GameData.Instance.OnNotification.Fire("YOU WIN");
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.YouWin, 1000UL, 1f, 1f);
			return;
		}
		if (currentLead != PlayerLeadAudio.LeadState.Others)
		{
			GameData.Instance.OnNotification.Fire("Draw");
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.Draw, 1000UL, 1f, 1f);
			return;
		}
		GameData.Instance.OnNotification.Fire("Game Over");
		AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.GameOver, 1000UL, 1f, 1f);
	}

	// Token: 0x0600196C RID: 6508 RVA: 0x00087FC0 File Offset: 0x000861C0
	protected override void OnAllPlayers(List<GameActorInfo> allPlayers, List<PlayerMovement> allPositions, ushort gameFrame)
	{
		int num = 0;
		while (num < allPlayers.Count && num < allPositions.Count)
		{
			this.OnPlayerJoinedGame(allPlayers[num], allPositions[num]);
			num++;
		}
	}

	// Token: 0x0600196D RID: 6509 RVA: 0x00010E9A File Offset: 0x0000F09A
	protected override void OnAllPlayerDeltas(List<GameActorInfoDelta> players)
	{
		GameState.Current.AllPlayerDeltas(players);
	}

	// Token: 0x0600196E RID: 6510 RVA: 0x00010EA7 File Offset: 0x0000F0A7
	protected override void OnAllPlayerPositions(List<PlayerMovement> allPositions, ushort gameFrame)
	{
		GameState.Current.AllPositionUpdate(allPositions, gameFrame);
	}

	// Token: 0x0600196F RID: 6511 RVA: 0x00010EB5 File Offset: 0x0000F0B5
	protected override void OnPlayerDelta(GameActorInfoDelta delta)
	{
		GameState.Current.PlayerDelta(delta);
	}

	// Token: 0x06001970 RID: 6512 RVA: 0x00087FFC File Offset: 0x000861FC
	protected override void OnPlayerJumped(int cmid, Vector3 position)
	{
		CharacterConfig characterConfig;
		if (GameState.Current.TryGetPlayerAvatar(cmid, out characterConfig))
		{
			characterConfig.OnJump();
		}
	}

	// Token: 0x06001971 RID: 6513 RVA: 0x00010EC2 File Offset: 0x0000F0C2
	protected override void OnPlayersReadyUpdated()
	{
		GameState.Current.UpdatePlayersReady();
	}

	// Token: 0x06001972 RID: 6514 RVA: 0x00010ECE File Offset: 0x0000F0CE
	protected override void OnPlayerRespawned(int cmid, Vector3 position, byte rotation)
	{
		GameState.Current.PlayerRespawned(cmid, position, rotation);
	}

	// Token: 0x06001973 RID: 6515 RVA: 0x00010EDD File Offset: 0x0000F0DD
	protected override void OnPlayerRespawnCountdown(byte countdown)
	{
		GameState.Current.PlayerState.Events.Fire(new GameEvents.RespawnCountdown
		{
			Countdown = (int)countdown
		});
	}

	// Token: 0x06001974 RID: 6516 RVA: 0x00010EFF File Offset: 0x0000F0FF
	protected override void OnPlayerKilled(int shooter, int target, byte weaponClass, ushort damage, byte bodyPart, Vector3 direction)
	{
		GameState.Current.PlayerKilled(shooter, target, (UberstrikeItemClass)weaponClass, (BodyPart)bodyPart, direction);
	}

	// Token: 0x06001975 RID: 6517 RVA: 0x00010F12 File Offset: 0x0000F112
	protected override void OnDamageEvent(DamageEvent damageEvent)
	{
		GameState.Current.PlayerDamaged(damageEvent);
	}

	// Token: 0x06001976 RID: 6518 RVA: 0x00010F1F File Offset: 0x0000F11F
	protected override void OnDoorOpen(int id)
	{
		global::EventHandler.Global.Fire(new GameEvents.DoorOpened(id));
	}

	// Token: 0x06001977 RID: 6519 RVA: 0x00010F31 File Offset: 0x0000F131
	protected override void OnResetAllPowerups()
	{
		global::EventHandler.Global.Fire(new GameEvents.PickupItemReset());
	}

	// Token: 0x06001978 RID: 6520 RVA: 0x00010F42 File Offset: 0x0000F142
	protected override void OnPowerUpPicked(int id, byte flag)
	{
		global::EventHandler.Global.Fire(new GameEvents.PickupItemChanged(id, flag == 0));
	}

	// Token: 0x06001979 RID: 6521 RVA: 0x00088020 File Offset: 0x00086220
	protected override void OnSetPowerupState(List<int> states)
	{
		int num = 0;
		while (states != null && num < states.Count)
		{
			global::EventHandler.Global.Fire(new GameEvents.PickupItemChanged(states[num], false));
			num++;
		}
	}

	// Token: 0x0600197A RID: 6522 RVA: 0x00010F58 File Offset: 0x0000F158
	protected override void OnEmitProjectile(int cmid, Vector3 origin, Vector3 direction, byte slot, int projectileID, bool explode)
	{
		GameState.Current.EmitRemoteProjectile(cmid, origin, direction, slot, projectileID, explode);
	}

	// Token: 0x0600197B RID: 6523 RVA: 0x00010F6D File Offset: 0x0000F16D
	protected override void OnRemoveProjectile(int projectileId, bool explode)
	{
		Singleton<ProjectileManager>.Instance.RemoveProjectile(projectileId, explode);
	}

	// Token: 0x0600197C RID: 6524 RVA: 0x00010F7B File Offset: 0x0000F17B
	protected override void OnEmitQuickItem(Vector3 origin, Vector3 direction, int itemId, byte playerNumber, int projectileID)
	{
		GameState.Current.EmitRemoteQuickItem(origin, direction, itemId, playerNumber, projectileID);
	}

	// Token: 0x0600197D RID: 6525 RVA: 0x00010F8E File Offset: 0x0000F18E
	protected override void OnKickPlayer(string message)
	{
		Singleton<GameStateController>.Instance.LeaveGame(false);
		PopupSystem.ShowMessage("Cheat Detection", message, PopupSystem.AlertType.OK, delegate()
		{
		});
	}

	// Token: 0x0600197E RID: 6526 RVA: 0x00010FC6 File Offset: 0x0000F1C6
	protected override void OnPlayerHit(Vector3 force)
	{
		GameState.Current.Player.MoveController.ApplyForce(force, CharacterMoveController.ForceType.Additive);
	}

	// Token: 0x0600197F RID: 6527 RVA: 0x00010FDE File Offset: 0x0000F1DE
	protected override void OnQuickItemEvent(int cmid, byte eventType, int robotLifeTime, int scrapsLifeTime, bool isInstant)
	{
		GameState.Current.QuickItemEvent(cmid, eventType, robotLifeTime, scrapsLifeTime, isInstant);
	}

	// Token: 0x06001980 RID: 6528 RVA: 0x00010FF1 File Offset: 0x0000F1F1
	protected override void OnSingleBulletFire(int cmid)
	{
		GameState.Current.SingleBulletFire(cmid);
	}

	// Token: 0x06001981 RID: 6529 RVA: 0x00010FFE File Offset: 0x0000F1FE
	protected override void OnActivateQuickItem(int cmid, QuickItemLogic logic, int robotLifeTime, int scrapsLifeTime, bool isInstant)
	{
		GameState.Current.ActivateQuickItem(cmid, logic, robotLifeTime, scrapsLifeTime, isInstant);
	}

	// Token: 0x06001982 RID: 6530 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnPlayerChangedTeam(int cmid, TeamID team)
	{
	}

	// Token: 0x06001983 RID: 6531 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnUpdateRoundScore(int round, short blue, short red)
	{
	}

	// Token: 0x06001984 RID: 6532 RVA: 0x00088058 File Offset: 0x00086258
	protected override void OnKillsRemaining(int killsRemaining, int leaderCmid)
	{
		int num = 0;
		foreach (GameActorInfo gameActorInfo in GameState.Current.Players.Values)
		{
			if (gameActorInfo.Cmid != PlayerDataManager.Cmid && num < (int)gameActorInfo.Kills)
			{
				num = (int)gameActorInfo.Kills;
			}
		}
		Debug.LogError(string.Format("OnKillsRemaining invoked: Kills remaining - {0}. Leader CmuneID - {1}.", killsRemaining, leaderCmid));
		GameState.Current.PlayerData.RemainingKills.Value = killsRemaining;
		GameState.Current.LeadStatus.PlayKillsLeftAudio(killsRemaining);
		Debug.LogError("Past PlayKillsLeftAudio.");
		GameState.Current.LeadStatus.UpdateLeadStatus((int)GameState.Current.PlayerData.Player.Kills, num, killsRemaining > 0 && GameState.Current.MatchState.CurrentStateId == GameStateId.MatchRunning);
	}

	// Token: 0x06001985 RID: 6533 RVA: 0x00011011 File Offset: 0x0000F211
	protected override void OnLevelUp(int newLevel)
	{
		Debug.LogError("TODO: trigger level up in the future");
	}

	// Token: 0x06001986 RID: 6534 RVA: 0x0001101D File Offset: 0x0000F21D
	protected override void OnChatMessage(int cmid, string name, string message, MemberAccessLevel accessLevel, byte context)
	{
		GameStateHelper.OnChatMessage(cmid, name, message, accessLevel, context);
	}

	// Token: 0x06001987 RID: 6535 RVA: 0x0001102B File Offset: 0x0000F22B
	protected override void OnDisconnectCountdown(byte countdown)
	{
		GameData.Instance.OnWarningNotification.Fire(LocalizedStrings.DisconnectionIn + " " + countdown);
	}

	// Token: 0x170005C1 RID: 1473
	// (get) Token: 0x06001988 RID: 6536 RVA: 0x00011051 File Offset: 0x0000F251
	public GameMode Type
	{
		get
		{
			return GameMode.DeathMatch;
		}
	}

	// Token: 0x0400179D RID: 6045
	private bool isDisposed;
}
