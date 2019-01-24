using System;
using System.Collections;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class TrainingRoom : IDisposable, IGameMode
{
	// Token: 0x06001A2F RID: 6703 RVA: 0x00089B88 File Offset: 0x00087D88
	public TrainingRoom()
	{
		GameState.Current.MatchState.RegisterState(GameStateId.PregameLoadout, new PregameLoadoutState(GameState.Current.MatchState));
		GameState.Current.MatchState.RegisterState(GameStateId.MatchRunning, new OfflineMatchState(GameState.Current.MatchState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Playing, new PlayerPlayingState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Killed, new PlayerKilledOfflineState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Paused, new PlayerPausedState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Overview, new PlayerOverviewState(GameState.Current.PlayerState));
		GameState.Current.Actions.KillPlayer = delegate()
		{
			if (GameState.Current.IsInGame)
			{
				GameState.Current.PlayerKilled(0, PlayerDataManager.Cmid, (UberstrikeItemClass)0, (BodyPart)0, Vector3.zero);
			}
		};
		GameState.Current.Actions.ExplosionHitDamage = delegate(int targetCmid, ushort damage, Vector3 force, byte slot, byte distance)
		{
			GameStateHelper.PlayerHit(targetCmid, damage, BodyPart.Body, force);
			if (GameState.Current.PlayerData.Health <= 0)
			{
				GameState.Current.PlayerData.Set(PlayerStates.Dead, true);
				GameState.Current.PlayerKilled(targetCmid, targetCmid, Singleton<WeaponController>.Instance.GetCurrentWeapon().View.ItemClass, BodyPart.Body, force);
			}
		};
		GameState.Current.Actions.JoinTeam = delegate(TeamID team)
		{
			GameActorInfo gameActorInfo = new GameActorInfo
			{
				Cmid = PlayerDataManager.Cmid,
				SkinColor = PlayerDataManager.SkinColor
			};
			GameState.Current.PlayerData.Player = gameActorInfo;
			GameState.Current.Players[gameActorInfo.Cmid] = gameActorInfo;
			GameState.Current.InstantiateAvatar(gameActorInfo);
			GameState.Current.MatchState.SetState(GameStateId.MatchRunning);
			UnityRuntime.StartRoutine(this.ShowTrainingGameMessages());
		};
		TabScreenPanelGUI.SortPlayersByRank = new Action<IEnumerable<GameActorInfo>>(GameStateHelper.SortDeathMatchPlayers);
		AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate += this.OnUpdate;
		GameStateHelper.EnterGameMode();
		GameState.Current.MatchState.SetState(GameStateId.PregameLoadout);
	}

	// Token: 0x06001A30 RID: 6704 RVA: 0x00089D04 File Offset: 0x00087F04
	private IEnumerator ShowTrainingGameMessages()
	{
		if (!ApplicationDataManager.IsMobile)
		{
			float duration = 2f;
			GameData.Instance.OnNotificationFull.Fire(string.Empty, LocalizedStrings.TrainingTutorialMsg01, duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, LocalizedStrings.MessageQuickItemsTry, duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, LocalizedStrings.TrainingTutorialMsg03, duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, LocalizedStrings.TrainingTutorialMsg04, duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, string.Format(LocalizedStrings.TrainingTutorialMsg05, new object[]
			{
				AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Forward),
				AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Left),
				AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Backward),
				AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Right)
			}), duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, string.Format(LocalizedStrings.TrainingTutorialMsg06, AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.PrimaryFire)), duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, string.Format(LocalizedStrings.TrainingTutorialMsg07, AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.NextWeapon), AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.PrevWeapon)), duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, string.Format(LocalizedStrings.TrainingTutorialMsg08, new object[]
			{
				AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.WeaponMelee),
				AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Weapon1),
				AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Weapon2),
				AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Weapon3)
			}), duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, string.Format(LocalizedStrings.TrainingTutorialMsg09, AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Crouch)), duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, string.Format(LocalizedStrings.TrainingTutorialMsg10, AutoMonoBehaviour<InputManager>.Instance.InputChannelForSlot(GameInputKey.Fullscreen)), duration);
			yield return new WaitForSeconds(duration);
			GameData.Instance.OnNotificationFull.Fire(string.Empty, LocalizedStrings.TrainingTutorialMsg11, duration);
			yield return new WaitForSeconds(duration);
		}
		yield break;
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x000115ED File Offset: 0x0000F7ED
	public void Dispose()
	{
		if (!this.isDisposed)
		{
			this.isDisposed = true;
			AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate -= this.OnUpdate;
			GameStateHelper.ExitGameMode();
		}
	}

	// Token: 0x06001A32 RID: 6706 RVA: 0x00010E0C File Offset: 0x0000F00C
	private void OnUpdate()
	{
		Singleton<QuickItemController>.Instance.Update();
	}

	// Token: 0x170005C9 RID: 1481
	// (get) Token: 0x06001A33 RID: 6707 RVA: 0x0001161C File Offset: 0x0000F81C
	public GameStateId CurrentState
	{
		get
		{
			return GameState.Current.MatchState.CurrentStateId;
		}
	}

	// Token: 0x170005CA RID: 1482
	// (get) Token: 0x06001A34 RID: 6708 RVA: 0x0001162D File Offset: 0x0000F82D
	public GameMode Type
	{
		get
		{
			return GameMode.Training;
		}
	}

	// Token: 0x040017C0 RID: 6080
	private bool isDisposed;
}
