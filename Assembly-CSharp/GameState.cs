using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x0200038A RID: 906
public class GameState
{
	// Token: 0x06001A56 RID: 6742 RVA: 0x0008A344 File Offset: 0x00088544
	private GameState()
	{
		this.MatchState.OnChanged += delegate(GameStateId el)
		{
			GameData.Instance.GameState.Value = el;
		};
		this.PlayerState.OnChanged += delegate(PlayerStateId el)
		{
			GameData.Instance.PlayerState.Value = el;
		};
		this.PlayerData = new PlayerData();
		this.Reset();
		AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate += delegate()
		{
			if (this.IsInGame)
			{
				if (this.IsLocalAvatarLoaded)
				{
					this.PlayerData.SendUpdates();
				}
				this.RemotePlayerStates.Update();
			}
			this.MatchState.Update();
			this.PlayerState.Update();
		};
	}

	// Token: 0x170005CE RID: 1486
	// (get) Token: 0x06001A58 RID: 6744 RVA: 0x0001173E File Offset: 0x0000F93E
	public LocalPlayer Player
	{
		get
		{
			if (this.player == null && PrefabManager.Instance != null)
			{
				this.player = PrefabManager.Instance.InstantiateLocalPlayer();
			}
			return this.player;
		}
	}

	// Token: 0x170005CF RID: 1487
	// (get) Token: 0x06001A59 RID: 6745 RVA: 0x00011777 File Offset: 0x0000F977
	// (set) Token: 0x06001A5A RID: 6746 RVA: 0x0001177F File Offset: 0x0000F97F
	public PlayerData PlayerData { get; private set; }

	// Token: 0x170005D0 RID: 1488
	// (get) Token: 0x06001A5B RID: 6747 RVA: 0x00011788 File Offset: 0x0000F988
	// (set) Token: 0x06001A5C RID: 6748 RVA: 0x00011790 File Offset: 0x0000F990
	public MapConfiguration Map { get; set; }

	// Token: 0x170005D1 RID: 1489
	// (get) Token: 0x06001A5D RID: 6749 RVA: 0x00011799 File Offset: 0x0000F999
	// (set) Token: 0x06001A5E RID: 6750 RVA: 0x000117A1 File Offset: 0x0000F9A1
	public GameRoomData RoomData { get; set; }

	// Token: 0x170005D2 RID: 1490
	// (get) Token: 0x06001A5F RID: 6751 RVA: 0x000117AA File Offset: 0x0000F9AA
	// (set) Token: 0x06001A60 RID: 6752 RVA: 0x000117B2 File Offset: 0x0000F9B2
	public int RoundsPlayed { get; set; }

	// Token: 0x170005D3 RID: 1491
	// (get) Token: 0x06001A61 RID: 6753 RVA: 0x000117BB File Offset: 0x0000F9BB
	// (set) Token: 0x06001A62 RID: 6754 RVA: 0x000117C3 File Offset: 0x0000F9C3
	public int ScoreRed { get; private set; }

	// Token: 0x170005D4 RID: 1492
	// (get) Token: 0x06001A63 RID: 6755 RVA: 0x000117CC File Offset: 0x0000F9CC
	// (set) Token: 0x06001A64 RID: 6756 RVA: 0x000117D4 File Offset: 0x0000F9D4
	public int ScoreBlue { get; private set; }

	// Token: 0x170005D5 RID: 1493
	// (get) Token: 0x06001A65 RID: 6757 RVA: 0x000117DD File Offset: 0x0000F9DD
	// (set) Token: 0x06001A66 RID: 6758 RVA: 0x000117E5 File Offset: 0x0000F9E5
	public int BlueTeamPlayerCount { get; private set; }

	// Token: 0x170005D6 RID: 1494
	// (get) Token: 0x06001A67 RID: 6759 RVA: 0x000117EE File Offset: 0x0000F9EE
	// (set) Token: 0x06001A68 RID: 6760 RVA: 0x000117F6 File Offset: 0x0000F9F6
	public int RedTeamPlayerCount { get; private set; }

	// Token: 0x170005D7 RID: 1495
	// (get) Token: 0x06001A69 RID: 6761 RVA: 0x000117FF File Offset: 0x0000F9FF
	// (set) Token: 0x06001A6A RID: 6762 RVA: 0x00011807 File Offset: 0x0000FA07
	public int PlayerCountReadyForNextRound { get; private set; }

	// Token: 0x170005D8 RID: 1496
	// (get) Token: 0x06001A6B RID: 6763 RVA: 0x0008A438 File Offset: 0x00088638
	public bool IsInGame
	{
		get
		{
			switch (this.MatchState.CurrentStateId)
			{
			case GameStateId.None:
			case GameStateId.PregameLoadout:
			case GameStateId.EndOfMatch:
				return false;
			}
			return true;
		}
	}

	// Token: 0x170005D9 RID: 1497
	// (get) Token: 0x06001A6C RID: 6764 RVA: 0x00011810 File Offset: 0x0000FA10
	public bool IsMatchRunning
	{
		get
		{
			return this.MatchState.CurrentStateId == GameStateId.MatchRunning;
		}
	}

	// Token: 0x170005DA RID: 1498
	// (get) Token: 0x06001A6D RID: 6765 RVA: 0x00011820 File Offset: 0x0000FA20
	public bool IsEndOfMatchState
	{
		get
		{
			return this.MatchState.CurrentStateId == GameStateId.EndOfMatch;
		}
	}

	// Token: 0x170005DB RID: 1499
	// (get) Token: 0x06001A6E RID: 6766 RVA: 0x00011830 File Offset: 0x0000FA30
	public bool IsInAnyGameState
	{
		get
		{
			return this.MatchState.CurrentStateId != GameStateId.None;
		}
	}

	// Token: 0x170005DC RID: 1500
	// (get) Token: 0x06001A6F RID: 6767 RVA: 0x00011843 File Offset: 0x0000FA43
	public bool IsPlayerPaused
	{
		get
		{
			return this.PlayerState.CurrentStateId == PlayerStateId.Paused;
		}
	}

	// Token: 0x170005DD RID: 1501
	// (get) Token: 0x06001A70 RID: 6768 RVA: 0x00011853 File Offset: 0x0000FA53
	public bool IsPlayerDead
	{
		get
		{
			return this.PlayerState.CurrentStateId == PlayerStateId.Killed || this.PlayerState.CurrentStateId == PlayerStateId.Spectating;
		}
	}

	// Token: 0x170005DE RID: 1502
	// (get) Token: 0x06001A71 RID: 6769 RVA: 0x00011877 File Offset: 0x0000FA77
	public bool IsPlaying
	{
		get
		{
			return this.PlayerState.CurrentStateId == PlayerStateId.Playing || this.PlayerState.CurrentStateId == PlayerStateId.Spectating;
		}
	}

	// Token: 0x170005DF RID: 1503
	// (get) Token: 0x06001A72 RID: 6770 RVA: 0x0001189B File Offset: 0x0000FA9B
	public bool IsWaitingForPlayers
	{
		get
		{
			return this.MatchState.CurrentStateId == GameStateId.WaitingForPlayers;
		}
	}

	// Token: 0x170005E0 RID: 1504
	// (get) Token: 0x06001A73 RID: 6771 RVA: 0x00011830 File Offset: 0x0000FA30
	public bool HasJoinedGame
	{
		get
		{
			return this.MatchState.CurrentStateId != GameStateId.None;
		}
	}

	// Token: 0x170005E1 RID: 1505
	// (get) Token: 0x06001A74 RID: 6772 RVA: 0x000118AB File Offset: 0x0000FAAB
	public bool IsLocalAvatarLoaded
	{
		get
		{
			return this.Avatars.ContainsKey(PlayerDataManager.Cmid);
		}
	}

	// Token: 0x06001A75 RID: 6773 RVA: 0x000118BD File Offset: 0x0000FABD
	public bool HasAvatarLoaded(int cmid)
	{
		return this.Avatars.ContainsKey(cmid);
	}

	// Token: 0x170005E2 RID: 1506
	// (get) Token: 0x06001A76 RID: 6774 RVA: 0x000118CB File Offset: 0x0000FACB
	public bool IsSinglePlayer
	{
		get
		{
			return !this.IsMultiplayer;
		}
	}

	// Token: 0x170005E3 RID: 1507
	// (get) Token: 0x06001A77 RID: 6775 RVA: 0x000118D6 File Offset: 0x0000FAD6
	public bool IsGameAboutToEnd
	{
		get
		{
			return this.GameTime >= (float)(this.RoomData.TimeLimit - 1);
		}
	}

	// Token: 0x170005E4 RID: 1508
	// (get) Token: 0x06001A78 RID: 6776 RVA: 0x000118F1 File Offset: 0x0000FAF1
	public bool CanJoinRedTeam
	{
		get
		{
			return this.IsAccessAllowed || (!this.IsGameFull && this.RedTeamPlayerCount <= this.BlueTeamPlayerCount);
		}
	}

	// Token: 0x170005E5 RID: 1509
	// (get) Token: 0x06001A79 RID: 6777 RVA: 0x00011920 File Offset: 0x0000FB20
	public bool CanJoinBlueTeam
	{
		get
		{
			return this.IsAccessAllowed || (!this.IsGameFull && this.BlueTeamPlayerCount <= this.RedTeamPlayerCount);
		}
	}

	// Token: 0x170005E6 RID: 1510
	// (get) Token: 0x06001A7A RID: 6778 RVA: 0x0001194F File Offset: 0x0000FB4F
	public bool CanJoinGame
	{
		get
		{
			return this.IsAccessAllowed || !this.IsGameFull;
		}
	}

	// Token: 0x170005E7 RID: 1511
	// (get) Token: 0x06001A7B RID: 6779 RVA: 0x00011968 File Offset: 0x0000FB68
	public bool IsGameFull
	{
		get
		{
			return this.RoomData.ConnectedPlayers >= this.RoomData.PlayerLimit;
		}
	}

	// Token: 0x170005E8 RID: 1512
	// (get) Token: 0x06001A7C RID: 6780 RVA: 0x00011985 File Offset: 0x0000FB85
	public bool IsAccessAllowed
	{
		get
		{
			return PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator;
		}
	}

	// Token: 0x170005E9 RID: 1513
	// (get) Token: 0x06001A7D RID: 6781 RVA: 0x00011992 File Offset: 0x0000FB92
	public float GameTime
	{
		get
		{
			return Mathf.Max((float)((double)(Singleton<GameStateController>.Instance.Client.ServerTimeTicks - this.roundStartTime) / 1000.0), 0f);
		}
	}

	// Token: 0x170005EA RID: 1514
	// (get) Token: 0x06001A7E RID: 6782 RVA: 0x000119C0 File Offset: 0x0000FBC0
	public GameModeType GameMode
	{
		get
		{
			return this.RoomData.GameMode;
		}
	}

	// Token: 0x170005EB RID: 1515
	// (get) Token: 0x06001A7F RID: 6783 RVA: 0x000119CD File Offset: 0x0000FBCD
	public bool IsMultiplayer
	{
		get
		{
			return this.RoomData.GameMode != GameModeType.None;
		}
	}

	// Token: 0x170005EC RID: 1516
	// (get) Token: 0x06001A80 RID: 6784 RVA: 0x000119E0 File Offset: 0x0000FBE0
	public bool IsTeamGame
	{
		get
		{
			return this.GameMode == GameModeType.TeamDeathMatch || this.GameMode == GameModeType.EliminationMode;
		}
	}

	// Token: 0x06001A81 RID: 6785 RVA: 0x000119FA File Offset: 0x0000FBFA
	public void ResetRoundStartTime()
	{
		this.roundStartTime = Singleton<GameStateController>.Instance.Client.ServerTimeTicks;
	}

	// Token: 0x06001A82 RID: 6786 RVA: 0x0008A474 File Offset: 0x00088674
	public void Reset()
	{
		this.Actions.Clear();
		this.PlayerData.Reset();
		this.MatchState.Reset();
		this.PlayerState.Reset();
		this.RoomData = new GameRoomData
		{
			GameMode = GameModeType.None
		};
		foreach (CharacterConfig characterConfig in this.Avatars.Values)
		{
			characterConfig.Destroy();
		}
		this.RemotePlayerStates.Reset();
		this.Avatars.Clear();
		this.Players.Clear();
	}

	// Token: 0x06001A83 RID: 6787 RVA: 0x00011A11 File Offset: 0x0000FC11
	public bool TryGetPlayerAvatar(int cmid, out CharacterConfig character)
	{
		return this.Avatars.TryGetValue(cmid, out character) && character != null;
	}

	// Token: 0x06001A84 RID: 6788 RVA: 0x00011A30 File Offset: 0x0000FC30
	public bool TryGetActorInfo(int cmid, out GameActorInfo player)
	{
		return this.Players.TryGetValue(cmid, out player) && player != null;
	}

	// Token: 0x06001A85 RID: 6789 RVA: 0x0008A534 File Offset: 0x00088734
	public void UnloadAvatar(int cmid)
	{
		CharacterConfig characterConfig;
		if (this.Avatars.TryGetValue(cmid, out characterConfig))
		{
			if (characterConfig)
			{
				characterConfig.Destroy();
			}
			this.Avatars.Remove(cmid);
		}
		this.Players.Remove(cmid);
	}

	// Token: 0x06001A86 RID: 6790 RVA: 0x0008A580 File Offset: 0x00088780
	public void EmitRemoteProjectile(int cmid, Vector3 origin, Vector3 direction, byte slot, int projectileID, bool explode)
	{
		CharacterConfig characterConfig;
		if (this.TryGetPlayerAvatar(cmid, out characterConfig))
		{
			if (characterConfig.Avatar.Decorator.AnimationController)
			{
				characterConfig.Avatar.Decorator.AnimationController.Shoot();
			}
			IProjectile projectile = characterConfig.WeaponSimulator.EmitProjectile(cmid, characterConfig.State.Player.PlayerId, origin, direction, (global::LoadoutSlotType)slot, projectileID, explode);
			if (projectile != null)
			{
				Singleton<ProjectileManager>.Instance.AddProjectile(projectile, projectileID);
			}
		}
	}

	// Token: 0x06001A87 RID: 6791 RVA: 0x0008A604 File Offset: 0x00088804
	public void UpdateTeamCounter()
	{
		int num = 0;
		this.BlueTeamPlayerCount = num;
		this.RedTeamPlayerCount = num;
		foreach (GameActorInfo gameActorInfo in this.Players.Values)
		{
			if (gameActorInfo.TeamID == TeamID.BLUE)
			{
				this.BlueTeamPlayerCount++;
			}
			else if (gameActorInfo.TeamID == TeamID.RED)
			{
				this.RedTeamPlayerCount++;
			}
		}
	}

	// Token: 0x06001A88 RID: 6792 RVA: 0x0008A6A8 File Offset: 0x000888A8
	public void SingleBulletFire(int cmid)
	{
		CharacterConfig characterConfig;
		if (this.TryGetPlayerAvatar(cmid, out characterConfig) && characterConfig.State.Player.IsAlive && !characterConfig.IsLocal)
		{
			if (characterConfig.Avatar.Decorator.AnimationController)
			{
				characterConfig.Avatar.Decorator.AnimationController.Shoot();
			}
			characterConfig.WeaponSimulator.Shoot(characterConfig.State);
		}
	}

	// Token: 0x06001A89 RID: 6793 RVA: 0x0008A724 File Offset: 0x00088924
	public void QuickItemEvent(int cmid, byte eventType, int robotLifeTime, int scrapsLifeTime, bool isInstant)
	{
		CharacterConfig characterConfig;
		if (this.TryGetPlayerAvatar(cmid, out characterConfig))
		{
			Singleton<QuickItemSfxController>.Instance.ShowThirdPersonEffect(characterConfig, (QuickItemLogic)eventType, robotLifeTime, scrapsLifeTime, isInstant);
		}
	}

	// Token: 0x06001A8A RID: 6794 RVA: 0x0008A724 File Offset: 0x00088924
	public void ActivateQuickItem(int cmid, QuickItemLogic logic, int robotLifeTime, int scrapsLifeTime, bool isInstant)
	{
		CharacterConfig characterConfig;
		if (this.TryGetPlayerAvatar(cmid, out characterConfig))
		{
			Singleton<QuickItemSfxController>.Instance.ShowThirdPersonEffect(characterConfig, logic, robotLifeTime, scrapsLifeTime, isInstant);
		}
	}

	// Token: 0x06001A8B RID: 6795 RVA: 0x0008A750 File Offset: 0x00088950
	public void UpdatePlayersReady()
	{
		this.PlayerCountReadyForNextRound = 0;
		foreach (GameActorInfo gameActorInfo in this.Players.Values)
		{
			if (gameActorInfo.IsReadyForGame)
			{
				this.PlayerCountReadyForNextRound++;
			}
		}
	}

	// Token: 0x06001A8C RID: 6796 RVA: 0x0008A7C8 File Offset: 0x000889C8
	public void UpdateTeamScore(int blueScore, int redScore)
	{
		this.ScoreRed = redScore;
		this.ScoreBlue = blueScore;
		GameState.Current.PlayerData.BlueTeamScore.Value = blueScore;
		GameState.Current.PlayerData.RedTeamScore.Value = redScore;
		int num = this.RoomData.KillLimit - Math.Max(redScore, blueScore);
		GameState.Current.PlayerData.RemainingKills.Value = num;
		if (this.MatchState.CurrentStateId == GameStateId.MatchRunning)
		{
			this.LeadStatus.PlayKillsLeftAudio(num);
		}
		TeamID teamID = this.PlayerData.Player.TeamID;
		if (teamID != TeamID.BLUE)
		{
			if (teamID == TeamID.RED)
			{
				this.LeadStatus.UpdateLeadStatus(redScore, blueScore, num > 0 && this.MatchState.CurrentStateId == GameStateId.MatchRunning);
			}
		}
		else
		{
			this.LeadStatus.UpdateLeadStatus(blueScore, redScore, num > 0 && this.MatchState.CurrentStateId == GameStateId.MatchRunning);
		}
	}

	// Token: 0x06001A8D RID: 6797 RVA: 0x0008A8CC File Offset: 0x00088ACC
	private void UpdateDeathmatchScore()
	{
		int num = 0;
		foreach (GameActorInfo gameActorInfo in this.Players.Values)
		{
			if (gameActorInfo.Cmid != PlayerDataManager.Cmid && num < (int)gameActorInfo.Kills)
			{
				num = (int)gameActorInfo.Kills;
			}
		}
	}

	// Token: 0x06001A8E RID: 6798 RVA: 0x0008A94C File Offset: 0x00088B4C
	public void PlayerKilled(int shooter, int target, UberstrikeItemClass weaponClass, BodyPart bodyPart, Vector3 direction)
	{
		CharacterConfig characterConfig;
		if (this.Avatars.TryGetValue(target, out characterConfig) && !characterConfig.IsDead)
		{
			this.Avatars[target].SetDead(direction, BodyPart.Body, target, weaponClass);
			GameActorInfo valueOrDefault = this.Players.GetValueOrDefault(shooter, null);
			GameActorInfo valueOrDefault2 = this.Players.GetValueOrDefault(target, null);
			if (valueOrDefault2 == null)
			{
				Debug.LogError("Kill target is null " + target);
			}
			GameData.Instance.OnPlayerKilled.Fire(valueOrDefault, valueOrDefault2, weaponClass, bodyPart);
			if (target == PlayerDataManager.Cmid)
			{
				global::EventHandler.Global.Fire(new GameEvents.PlayerDied());
			}
		}
	}

	// Token: 0x06001A8F RID: 6799 RVA: 0x0008A9F4 File Offset: 0x00088BF4
	public void PlayerDamaged(DamageEvent damageEvent)
	{
		if (this.Player != null)
		{
			foreach (KeyValuePair<byte, byte> keyValuePair in damageEvent.Damage)
			{
				global::EventHandler.Global.Fire(new GameEvents.PlayerDamage
				{
					Angle = Conversion.Byte2Angle(keyValuePair.Key),
					DamageValue = (float)keyValuePair.Value
				});
				if ((damageEvent.DamageEffectFlag & 1) != 0)
				{
					this.Player.DamageFactor = damageEvent.DamgeEffectValue;
				}
			}
		}
	}

	// Token: 0x06001A90 RID: 6800 RVA: 0x0008AAA8 File Offset: 0x00088CA8
	public void StartMatch(int roundNumber, int endTime)
	{
		this.roundStartTime = endTime - this.RoomData.TimeLimit * 1000;
		this.LeadStatus.Reset();
		Singleton<GameStateController>.Instance.Client.Peer.FetchServerTimestamp();
		CheatDetection.SyncSystemTime();
		LevelCamera.ResetFeedback();
		GameState.Current.PlayerData.RemainingKills.Value = this.RoomData.KillLimit;
		GameState.Current.PlayerData.RemainingTime.Value = 0;
	}

	// Token: 0x06001A91 RID: 6801 RVA: 0x0008AB2C File Offset: 0x00088D2C
	public void UpdatePlayerStatistics(StatsCollection totalStats, StatsCollection bestPerLife)
	{
		int playerLevel = PlayerDataManager.PlayerLevel;
		if (playerLevel > 0 && playerLevel < XpPointsUtil.Config.MaxLevel)
		{
			Singleton<PlayerDataManager>.Instance.UpdatePlayerStats(totalStats, bestPerLife);
			if (PlayerDataManager.PlayerLevel != playerLevel)
			{
				PopupSystem.Show(new LevelUpPopup(PlayerDataManager.PlayerLevel, playerLevel, null));
			}
			GlobalUIRibbon.Instance.AddXPEvent(totalStats.Xp);
		}
		if (totalStats.Points > 0)
		{
			PlayerDataManager.Points += totalStats.Points;
			GlobalUIRibbon.Instance.AddPointsEvent(totalStats.Points);
		}
	}

	// Token: 0x06001A92 RID: 6802 RVA: 0x0008ABBC File Offset: 0x00088DBC
	public AchievementType GetPlayersFirstAchievement(EndOfMatchData endOfMatchData)
	{
		AchievementType result = AchievementType.None;
		StatsSummary statsSummary = endOfMatchData.MostValuablePlayers.Find((StatsSummary p) => p.Cmid == PlayerDataManager.Cmid);
		if (statsSummary != null)
		{
			List<AchievementType> list = new List<AchievementType>();
			foreach (KeyValuePair<byte, ushort> keyValuePair in statsSummary.Achievements)
			{
				list.Add((AchievementType)keyValuePair.Key);
			}
			if (list.Count > 0)
			{
				result = list[0];
			}
		}
		return result;
	}

	// Token: 0x06001A93 RID: 6803 RVA: 0x0008AC6C File Offset: 0x00088E6C
	public void EmitRemoteQuickItem(Vector3 origin, Vector3 direction, int itemId, byte playerNumber, int projectileID)
	{
		IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(itemId);
		if (itemInShop != null)
		{
			if (itemInShop.Prefab)
			{
				IGrenadeProjectile grenadeProjectile = itemInShop.Prefab.GetComponent<QuickItem>() as IGrenadeProjectile;
				try
				{
					IGrenadeProjectile grenadeProjectile2 = grenadeProjectile.Throw(origin, direction);
					if (playerNumber == this.PlayerData.Player.PlayerId)
					{
						grenadeProjectile2.SetLayer(UberstrikeLayer.LocalProjectile);
					}
					else
					{
						grenadeProjectile2.SetLayer(UberstrikeLayer.RemoteProjectile);
					}
					Singleton<ProjectileManager>.Instance.AddProjectile(grenadeProjectile2, projectileID);
				}
				catch (Exception exception)
				{
					Debug.LogWarning(string.Concat(new object[]
					{
						"OnEmitQuickItem failed because Item is not a projectile: ",
						itemId,
						"/",
						playerNumber,
						"/",
						projectileID
					}));
					Debug.LogException(exception);
				}
			}
		}
		else
		{
			Debug.LogError(string.Concat(new object[]
			{
				"OnEmitQuickItem failed because item not found: ",
				itemId,
				"/",
				playerNumber,
				"/",
				projectileID
			}));
		}
	}

	// Token: 0x06001A94 RID: 6804 RVA: 0x0008ADA0 File Offset: 0x00088FA0
	public void PlayerLeftGame(int cmid)
	{
		try
		{
			global::EventHandler.Global.Fire(new GameEvents.PlayerLeft
			{
				Cmid = cmid
			});
			GameActorInfo gameActorInfo;
			if (this.Players.TryGetValue(cmid, out gameActorInfo))
			{
				GameData.Instance.OnHUDStreamMessage.Fire(gameActorInfo, LocalizedStrings.LeftTheGame, null);
				Debug.Log(string.Concat(new object[]
				{
					"<< OnPlayerLeftGame ",
					gameActorInfo.PlayerName,
					" ",
					this.MatchState.CurrentStateId
				}));
				if (gameActorInfo.Cmid == PlayerDataManager.Cmid)
				{
					this.Player.SetCurrentCharacterConfig(null);
				}
				else
				{
					this.RemotePlayerStates.RemoveCharacterInfo(gameActorInfo.PlayerId);
				}
			}
			this.UnloadAvatar(cmid);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		finally
		{
			Singleton<ChatManager>.Instance.SetGameSection(this.RoomData.Server.ConnectionString, this.RoomData.Number, this.RoomData.MapID, this.Players.Values);
		}
	}

	// Token: 0x06001A95 RID: 6805 RVA: 0x0008AECC File Offset: 0x000890CC
	public void AllPlayerDeltas(List<GameActorInfoDelta> players)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (GameActorInfoDelta gameActorInfoDelta in players)
		{
			try
			{
				if (gameActorInfoDelta.Changes.Count > 0)
				{
					this.PlayerDelta(gameActorInfoDelta);
					if (gameActorInfoDelta.Changes.ContainsKey(GameActorInfoDelta.Keys.TeamID))
					{
						flag = true;
					}
					if (gameActorInfoDelta.Changes.ContainsKey(GameActorInfoDelta.Keys.Kills))
					{
						flag2 = true;
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
		if (flag)
		{
			this.UpdateTeamCounter();
		}
		if (flag2 && this.GameMode == GameModeType.DeathMatch)
		{
			this.UpdateDeathmatchScore();
		}
	}

	// Token: 0x06001A96 RID: 6806 RVA: 0x00011A4F File Offset: 0x0000FC4F
	public void PlayerDelta(GameActorInfoDelta update)
	{
		if (update.Id == this.PlayerData.Player.PlayerId)
		{
			this.PlayerData.DeltaUpdate(update);
		}
		else
		{
			this.RemotePlayerStates.DeltaUpdate(update);
		}
	}

	// Token: 0x06001A97 RID: 6807 RVA: 0x0008AFA4 File Offset: 0x000891A4
	public void AllPositionUpdate(List<PlayerMovement> positions, ushort gameFrame)
	{
		foreach (PlayerMovement playerMovement in positions)
		{
			if (playerMovement.Number != this.PlayerData.Player.PlayerId)
			{
				this.RemotePlayerStates.PositionUpdate(playerMovement, gameFrame);
			}
		}
	}

	// Token: 0x06001A98 RID: 6808 RVA: 0x0008B01C File Offset: 0x0008921C
	public void RespawnLocalPlayerAt(Vector3 position, Quaternion rotation)
	{
		this.Player.SpawnPlayerAt(position, rotation);
		CharacterConfig characterConfig;
		GameActorInfo info;
		if (this.Avatars.TryGetValue(PlayerDataManager.Cmid, out characterConfig))
		{
			characterConfig.Reset();
		}
		else if (this.TryGetActorInfo(PlayerDataManager.Cmid, out info))
		{
			this.InstantiateAvatar(info);
		}
	}

	// Token: 0x06001A99 RID: 6809 RVA: 0x0008B074 File Offset: 0x00089274
	public void PlayerRespawned(int cmid, Vector3 position, byte rotation)
	{
		GameActorInfo gameActorInfo;
		if (this.TryGetActorInfo(cmid, out gameActorInfo))
		{
			if (gameActorInfo.Cmid == PlayerDataManager.Cmid && gameActorInfo.TeamID == TeamID.NONE && this.GameMode != GameModeType.DeathMatch)
			{
				Debug.LogWarning("PlayerRespawned failed, invalid team for gamemode");
				Singleton<GameStateController>.Instance.LeaveGame(false);
				return;
			}
			if (!this.Avatars.ContainsKey(cmid))
			{
				this.InstantiateAvatar(gameActorInfo);
			}
			CharacterConfig characterConfig;
			if (this.Avatars.TryGetValue(cmid, out characterConfig))
			{
				this.RemotePlayerStates.UpdatePositionHard(characterConfig.State.Player.PlayerId, position);
				characterConfig.Reset();
			}
			if (cmid == PlayerDataManager.Cmid)
			{
				global::EventHandler.Global.Fire(new GameEvents.PlayerRespawn
				{
					Position = position,
					Rotation = Conversion.Byte2Angle(rotation)
				});
			}
		}
		else
		{
			Debug.LogError(string.Format("PlayerRespawned failed {0} because not found in the list of players!", cmid));
		}
	}

	// Token: 0x06001A9A RID: 6810 RVA: 0x0008B164 File Offset: 0x00089364
	public void InstantiateAvatar(GameActorInfo info)
	{
		if (!this.Avatars.ContainsKey(info.Cmid))
		{
			if (info.Cmid == PlayerDataManager.Cmid)
			{
				CharacterConfig characterConfig = PrefabManager.Instance.InstantiateLocalCharacter();
				this.Avatars.Add(info.Cmid, characterConfig);
				this.ConfigureAvatar(info, characterConfig, true);
			}
			else
			{
				CharacterConfig characterConfig2 = PrefabManager.Instance.InstantiateRemoteCharacter();
				this.Avatars.Add(info.Cmid, characterConfig2);
				this.ConfigureAvatar(info, characterConfig2, false);
			}
		}
		else
		{
			Debug.LogError(string.Format("Failed call of InstantiateAvatar {0} because already existing!", info.Cmid));
		}
	}

	// Token: 0x06001A9B RID: 6811 RVA: 0x0008B208 File Offset: 0x00089408
	private void ConfigureAvatar(GameActorInfo info, CharacterConfig character, bool isLocal)
	{
		if (character != null && info != null)
		{
			if (isLocal)
			{
				this.Player.SetCurrentCharacterConfig(character);
				this.Player.MoveController.IsLowGravity = GameFlags.IsFlagSet(GameFlags.GAME_FLAGS.LowGravity, this.RoomData.GameFlags);
				character.Initialize(this.PlayerData, this.Avatar);
			}
			else
			{
				global::Avatar avatar = new global::Avatar(new Loadout(info.Gear, info.Weapons), false);
				avatar.SetDecorator(global::AvatarBuilder.CreateRemoteAvatar(avatar.Loadout.GetAvatarGear(), info.SkinColor));
				character.Initialize(this.RemotePlayerStates.GetState(info.PlayerId), avatar);
				GameData.Instance.OnHUDStreamMessage.Fire(info, LocalizedStrings.JoinedTheGame, null);
			}
			if (!info.IsAlive)
			{
				character.SetDead(Vector3.zero, BodyPart.Body, 0, UberstrikeItemClass.WeaponMachinegun);
			}
		}
		else
		{
			Debug.LogError(string.Format("OnAvatarLoaded failed because loaded Avatar is {0} and Info is {1}", character != null, info != null));
		}
	}

	// Token: 0x06001A9C RID: 6812 RVA: 0x0008B318 File Offset: 0x00089518
	public bool SendChatMessage(string message, ChatContext context)
	{
		message = ChatMessageFilter.Cleanup(message);
		if (!string.IsNullOrEmpty(message) && !ChatMessageFilter.IsSpamming(message))
		{
			GameStateHelper.OnChatMessage(PlayerDataManager.Cmid, PlayerDataManager.Name, message, PlayerDataManager.AccessLevel, (byte)ChatManager.CurrentChatContext);
			this.Actions.ChatMessage(message, (byte)ChatManager.CurrentChatContext);
			return true;
		}
		return false;
	}

	// Token: 0x040017CB RID: 6091
	public static readonly GameState Current = new GameState();

	// Token: 0x040017CC RID: 6092
	public readonly Dictionary<int, CharacterConfig> Avatars = new Dictionary<int, CharacterConfig>();

	// Token: 0x040017CD RID: 6093
	public readonly Dictionary<int, GameActorInfo> Players = new Dictionary<int, GameActorInfo>();

	// Token: 0x040017CE RID: 6094
	public readonly StateMachine<GameStateId> MatchState = new StateMachine<GameStateId>();

	// Token: 0x040017CF RID: 6095
	public readonly StateMachine<PlayerStateId> PlayerState = new StateMachine<PlayerStateId>();

	// Token: 0x040017D0 RID: 6096
	public readonly GameActions Actions = new GameActions();

	// Token: 0x040017D1 RID: 6097
	public readonly RemotePlayerInterpolator RemotePlayerStates = new RemotePlayerInterpolator();

	// Token: 0x040017D2 RID: 6098
	public readonly PlayerLeadAudio LeadStatus = new PlayerLeadAudio();

	// Token: 0x040017D3 RID: 6099
	public readonly global::Avatar Avatar = new global::Avatar(Loadout.Empty, true);

	// Token: 0x040017D4 RID: 6100
	public readonly EndOfMatchStats Statistics = new EndOfMatchStats();

	// Token: 0x040017D5 RID: 6101
	private LocalPlayer player;

	// Token: 0x040017D6 RID: 6102
	private int roundStartTime;
}
