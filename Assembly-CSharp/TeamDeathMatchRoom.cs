using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.Client;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class TeamDeathMatchRoom : BaseGameRoom, IDisposable, IGameMode
{
	// Token: 0x060019C7 RID: 6599 RVA: 0x0008899C File Offset: 0x00086B9C
	public TeamDeathMatchRoom(GameRoomData gameData, GamePeer peer)
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
		GameState.Current.Actions.ChangeTeam = new Action(base.Operations.SendSwitchTeam);
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
		TabScreenPanelGUI.SortPlayersByRank = new Action<IEnumerable<GameActorInfo>>(GameStateHelper.SortTeamMatchPlayers);
		Singleton<QuickItemController>.Instance.IsConsumptionEnabled = true;
		Singleton<QuickItemController>.Instance.Restriction.IsEnabled = true;
		Singleton<QuickItemController>.Instance.Restriction.RenewGameUses();
		AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate += this.OnUpdate;
		global::EventHandler.Global.AddListener<GlobalEvents.InputChanged>(new Action<GlobalEvents.InputChanged>(this.OnInputChangeEvent));
	}

	// Token: 0x060019C8 RID: 6600 RVA: 0x00088F94 File Offset: 0x00087194
	public void Dispose()
	{
		if (!this.isDisposed)
		{
			this.isDisposed = true;
			AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate -= this.OnUpdate;
			GameState.Current.PlayerData.SendJumpUpdate -= base.Operations.SendJump;
			GameState.Current.PlayerData.SendMovementUpdate -= base.Operations.SendUpdatePositionAndRotation;
			global::EventHandler.Global.RemoveListener<GlobalEvents.InputChanged>(new Action<GlobalEvents.InputChanged>(this.OnInputChangeEvent));
			GameStateHelper.ExitGameMode();
		}
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x0001143A File Offset: 0x0000F63A
	private void OnInputChangeEvent(GlobalEvents.InputChanged ev)
	{
		if (ev.Key == GameInputKey.ChangeTeam && ev.IsDown && GameStateHelper.CanChangeTeam())
		{
			GameState.Current.Actions.ChangeTeam();
		}
	}

	// Token: 0x060019CA RID: 6602 RVA: 0x00010E0C File Offset: 0x0000F00C
	private void OnUpdate()
	{
		Singleton<QuickItemController>.Instance.Update();
	}

	// Token: 0x060019CB RID: 6603 RVA: 0x00089024 File Offset: 0x00087224
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
		GameState.Current.UpdateTeamCounter();
	}

	// Token: 0x060019CC RID: 6604 RVA: 0x00011472 File Offset: 0x0000F672
	protected override void OnJoinGameFailed(string message)
	{
		PopupSystem.ShowError("Join failed", message, PopupSystem.AlertType.OK);
	}

	// Token: 0x060019CD RID: 6605 RVA: 0x00010E18 File Offset: 0x0000F018
	protected override void OnJoinedAsSpectator()
	{
		GameState.Current.PlayerData.Set(PlayerStates.Spectator, true);
	}

	// Token: 0x060019CE RID: 6606 RVA: 0x00011481 File Offset: 0x0000F681
	protected override void OnPlayerLeftGame(int cmid)
	{
		GameState.Current.PlayerLeftGame(cmid);
		GameState.Current.UpdateTeamCounter();
	}

	// Token: 0x060019CF RID: 6607 RVA: 0x0008910C File Offset: 0x0008730C
	protected override void OnPrepareNextRound()
	{
		GameState.Current.MatchState.SetState(GameStateId.PrepareNextRound);
		if (GameState.Current.Players.ContainsKey(PlayerDataManager.Cmid))
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.PrepareForMatch);
		}
		else
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.Spectating);
		}
	}

	// Token: 0x060019D0 RID: 6608 RVA: 0x00089168 File Offset: 0x00087368
	protected override void OnWaitingForPlayers()
	{
		GameState.Current.MatchState.SetState(GameStateId.WaitingForPlayers);
		if (GameState.Current.Players.ContainsKey(PlayerDataManager.Cmid))
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.Playing);
		}
		else
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.Spectating);
		}
	}

	// Token: 0x060019D1 RID: 6609 RVA: 0x000891C4 File Offset: 0x000873C4
	protected override void OnMatchStartCountdown(byte countdown)
	{
		global::EventHandler.Global.Fire(new GameEvents.MatchCountdown
		{
			Countdown = (int)countdown
		});
	}

	// Token: 0x060019D2 RID: 6610 RVA: 0x00010E50 File Offset: 0x0000F050
	protected override void OnMatchStart(int roundNumber, int endTime)
	{
		GameState.Current.StartMatch(roundNumber, endTime);
		GameState.Current.MatchState.SetState(GameStateId.MatchRunning);
	}

	// Token: 0x060019D3 RID: 6611 RVA: 0x00010E6E File Offset: 0x0000F06E
	protected override void OnMatchEnd(EndOfMatchData data)
	{
		GameState.Current.Statistics.Update(data);
		GameState.Current.MatchState.SetState(GameStateId.EndOfMatch);
		GameState.Current.UpdatePlayersReady();
	}

	// Token: 0x060019D4 RID: 6612 RVA: 0x000891EC File Offset: 0x000873EC
	protected override void OnTeamWins(TeamID team)
	{
		GameData.Instance.OnHUDChatClear.Fire();
		GameData.Instance.OnHUDStreamClear.Fire();
		GameState.Current.MatchState.SetState(GameStateId.AfterRound);
		if (team != TeamID.BLUE)
		{
			if (team != TeamID.RED)
			{
				GameData.Instance.OnNotification.Fire("Draw!");
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.Draw, 0UL, 1f, 1f);
			}
			else
			{
				GameData.Instance.OnNotification.Fire("Red Team Wins");
				AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.RedWins, 0UL, 1f, 1f);
			}
		}
		else
		{
			GameData.Instance.OnNotification.Fire("Blue Team Wins");
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.BlueWins, 0UL, 1f, 1f);
		}
	}

	// Token: 0x060019D5 RID: 6613 RVA: 0x000892D8 File Offset: 0x000874D8
	protected override void OnAllPlayers(List<GameActorInfo> allPlayers, List<PlayerMovement> allPositions, ushort gameFrame)
	{
		int num = 0;
		while (num < allPlayers.Count && num < allPositions.Count)
		{
			this.OnPlayerJoinedGame(allPlayers[num], allPositions[num]);
			num++;
		}
	}

	// Token: 0x060019D6 RID: 6614 RVA: 0x00010E9A File Offset: 0x0000F09A
	protected override void OnAllPlayerDeltas(List<GameActorInfoDelta> players)
	{
		GameState.Current.AllPlayerDeltas(players);
	}

	// Token: 0x060019D7 RID: 6615 RVA: 0x00010EA7 File Offset: 0x0000F0A7
	protected override void OnAllPlayerPositions(List<PlayerMovement> allPositions, ushort gameFrame)
	{
		GameState.Current.AllPositionUpdate(allPositions, gameFrame);
	}

	// Token: 0x060019D8 RID: 6616 RVA: 0x00010EB5 File Offset: 0x0000F0B5
	protected override void OnPlayerDelta(GameActorInfoDelta delta)
	{
		GameState.Current.PlayerDelta(delta);
	}

	// Token: 0x060019D9 RID: 6617 RVA: 0x0008931C File Offset: 0x0008751C
	protected override void OnPlayerJumped(int cmid, Vector3 position)
	{
		CharacterConfig characterConfig;
		if (GameState.Current.TryGetPlayerAvatar(cmid, out characterConfig))
		{
			characterConfig.OnJump();
		}
	}

	// Token: 0x060019DA RID: 6618 RVA: 0x00010EC2 File Offset: 0x0000F0C2
	protected override void OnPlayersReadyUpdated()
	{
		GameState.Current.UpdatePlayersReady();
	}

	// Token: 0x060019DB RID: 6619 RVA: 0x00010ECE File Offset: 0x0000F0CE
	protected override void OnPlayerRespawned(int cmid, Vector3 position, byte rotation)
	{
		GameState.Current.PlayerRespawned(cmid, position, rotation);
	}

	// Token: 0x060019DC RID: 6620 RVA: 0x00089344 File Offset: 0x00087544
	protected override void OnPlayerRespawnCountdown(byte countdown)
	{
		GameState.Current.PlayerState.Events.Fire(new GameEvents.RespawnCountdown
		{
			Countdown = (int)countdown
		});
	}

	// Token: 0x060019DD RID: 6621 RVA: 0x00010EFF File Offset: 0x0000F0FF
	protected override void OnPlayerKilled(int shooter, int target, byte weaponClass, ushort damage, byte bodyPart, Vector3 direction)
	{
		GameState.Current.PlayerKilled(shooter, target, (UberstrikeItemClass)weaponClass, (BodyPart)bodyPart, direction);
	}

	// Token: 0x060019DE RID: 6622 RVA: 0x00010F12 File Offset: 0x0000F112
	protected override void OnDamageEvent(DamageEvent damageEvent)
	{
		GameState.Current.PlayerDamaged(damageEvent);
	}

	// Token: 0x060019DF RID: 6623 RVA: 0x00010F1F File Offset: 0x0000F11F
	protected override void OnDoorOpen(int id)
	{
		global::EventHandler.Global.Fire(new GameEvents.DoorOpened(id));
	}

	// Token: 0x060019E0 RID: 6624 RVA: 0x00010F31 File Offset: 0x0000F131
	protected override void OnResetAllPowerups()
	{
		global::EventHandler.Global.Fire(new GameEvents.PickupItemReset());
	}

	// Token: 0x060019E1 RID: 6625 RVA: 0x00011498 File Offset: 0x0000F698
	protected override void OnPowerUpPicked(int id, byte flag)
	{
		global::EventHandler.Global.Fire(new GameEvents.PickupItemChanged(id, flag == 0));
	}

	// Token: 0x060019E2 RID: 6626 RVA: 0x00089374 File Offset: 0x00087574
	protected override void OnSetPowerupState(List<int> states)
	{
		int num = 0;
		while (states != null && num < states.Count)
		{
			global::EventHandler.Global.Fire(new GameEvents.PickupItemChanged(states[num], false));
			num++;
		}
	}

	// Token: 0x060019E3 RID: 6627 RVA: 0x00010F58 File Offset: 0x0000F158
	protected override void OnEmitProjectile(int cmid, Vector3 origin, Vector3 direction, byte slot, int projectileID, bool explode)
	{
		GameState.Current.EmitRemoteProjectile(cmid, origin, direction, slot, projectileID, explode);
	}

	// Token: 0x060019E4 RID: 6628 RVA: 0x00010F6D File Offset: 0x0000F16D
	protected override void OnRemoveProjectile(int projectileId, bool explode)
	{
		Singleton<ProjectileManager>.Instance.RemoveProjectile(projectileId, explode);
	}

	// Token: 0x060019E5 RID: 6629 RVA: 0x00010F7B File Offset: 0x0000F17B
	protected override void OnEmitQuickItem(Vector3 origin, Vector3 direction, int itemId, byte playerNumber, int projectileID)
	{
		GameState.Current.EmitRemoteQuickItem(origin, direction, itemId, playerNumber, projectileID);
	}

	// Token: 0x060019E6 RID: 6630 RVA: 0x000114B7 File Offset: 0x0000F6B7
	protected override void OnKickPlayer(string message)
	{
		Singleton<GameStateController>.Instance.LeaveGame(false);
		PopupSystem.ShowMessage("Cheat Detection", message, PopupSystem.AlertType.OK, delegate()
		{
		});
	}

	// Token: 0x060019E7 RID: 6631 RVA: 0x00010FC6 File Offset: 0x0000F1C6
	protected override void OnPlayerHit(Vector3 force)
	{
		GameState.Current.Player.MoveController.ApplyForce(force, CharacterMoveController.ForceType.Additive);
	}

	// Token: 0x060019E8 RID: 6632 RVA: 0x00010FDE File Offset: 0x0000F1DE
	protected override void OnQuickItemEvent(int cmid, byte eventType, int robotLifeTime, int scrapsLifeTime, bool isInstant)
	{
		GameState.Current.QuickItemEvent(cmid, eventType, robotLifeTime, scrapsLifeTime, isInstant);
	}

	// Token: 0x060019E9 RID: 6633 RVA: 0x00010FF1 File Offset: 0x0000F1F1
	protected override void OnSingleBulletFire(int cmid)
	{
		GameState.Current.SingleBulletFire(cmid);
	}

	// Token: 0x060019EA RID: 6634 RVA: 0x00010FFE File Offset: 0x0000F1FE
	protected override void OnActivateQuickItem(int cmid, QuickItemLogic logic, int robotLifeTime, int scrapsLifeTime, bool isInstant)
	{
		GameState.Current.ActivateQuickItem(cmid, logic, robotLifeTime, scrapsLifeTime, isInstant);
	}

	// Token: 0x060019EB RID: 6635 RVA: 0x000114ED File Offset: 0x0000F6ED
	protected override void OnPlayerChangedTeam(int cmid, TeamID team)
	{
		GameStateHelper.OnPlayerChangeTeam(cmid, team);
	}

	// Token: 0x060019EC RID: 6636 RVA: 0x000114F6 File Offset: 0x0000F6F6
	protected override void OnUpdateRoundScore(int round, short blue, short red)
	{
		GameState.Current.UpdateTeamScore((int)blue, (int)red);
	}

	// Token: 0x060019ED RID: 6637 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnKillsRemaining(int killsRemaining, int leaderCmid)
	{
	}

	// Token: 0x060019EE RID: 6638 RVA: 0x00011011 File Offset: 0x0000F211
	protected override void OnLevelUp(int newLevel)
	{
		Debug.LogError("TODO: trigger level up in the future");
	}

	// Token: 0x060019EF RID: 6639 RVA: 0x0001101D File Offset: 0x0000F21D
	protected override void OnChatMessage(int cmid, string name, string message, MemberAccessLevel accessLevel, byte context)
	{
		GameStateHelper.OnChatMessage(cmid, name, message, accessLevel, context);
	}

	// Token: 0x060019F0 RID: 6640 RVA: 0x00011504 File Offset: 0x0000F704
	protected override void OnDisconnectCountdown(byte countdown)
	{
		GameData.Instance.OnWarningNotification.Fire(LocalizedStrings.DisconnectionIn + " " + countdown);
	}

	// Token: 0x170005C7 RID: 1479
	// (get) Token: 0x060019F1 RID: 6641 RVA: 0x0001152A File Offset: 0x0000F72A
	public GameMode Type
	{
		get
		{
			return GameMode.TeamDeathMatch;
		}
	}

	// Token: 0x040017BC RID: 6076
	private bool isDisposed;
}
