using System;
using UnityEngine;

// Token: 0x02000216 RID: 534
internal class PlayerPlayingState : IState
{
	// Token: 0x06000EB2 RID: 3762 RVA: 0x0000AA11 File Offset: 0x00008C11
	public PlayerPlayingState(StateMachine<PlayerStateId> stateMachine)
	{
		this.stateMachine = stateMachine;
	}

	// Token: 0x06000EB3 RID: 3763 RVA: 0x00062DB0 File Offset: 0x00060FB0
	public void OnEnter()
	{
		global::EventHandler.Global.AddListener<GameEvents.PlayerDamage>(new Action<GameEvents.PlayerDamage>(this.OnPlayerDamage));
		global::EventHandler.Global.AddListener<GameEvents.PlayerDied>(new Action<GameEvents.PlayerDied>(this.OnPlayerKilled));
		global::EventHandler.Global.AddListener<GameEvents.PlayerUnpause>(new Action<GameEvents.PlayerUnpause>(this.OnPlayerUnpaused));
		global::EventHandler.Global.AddListener<GameEvents.PlayerPause>(new Action<GameEvents.PlayerPause>(this.OnPlayerPaused));
		global::EventHandler.Global.AddListener<GameEvents.ChatWindow>(new Action<GameEvents.ChatWindow>(this.OnPlayerChatting));
		global::EventHandler.Global.AddListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
		AutoMonoBehaviour<UnityRuntime>.Instance.OnFixedUpdate += GameState.Current.Player.MoveController.UpdatePlayerMovement;
		this.OnPlayerRespawn(null);
		this.OnPlayerUnpaused(null);
	}

	// Token: 0x06000EB4 RID: 3764 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000EB5 RID: 3765 RVA: 0x00062E74 File Offset: 0x00061074
	public void OnExit()
	{
		Singleton<QuickItemController>.Instance.IsEnabled = false;
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerDied>(new Action<GameEvents.PlayerDied>(this.OnPlayerKilled));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerDamage>(new Action<GameEvents.PlayerDamage>(this.OnPlayerDamage));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerPause>(new Action<GameEvents.PlayerPause>(this.OnPlayerPaused));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerUnpause>(new Action<GameEvents.PlayerUnpause>(this.OnPlayerUnpaused));
		global::EventHandler.Global.RemoveListener<GameEvents.ChatWindow>(new Action<GameEvents.ChatWindow>(this.OnPlayerChatting));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
		AutoMonoBehaviour<UnityRuntime>.Instance.OnFixedUpdate -= GameState.Current.Player.MoveController.UpdatePlayerMovement;
	}

	// Token: 0x06000EB6 RID: 3766 RVA: 0x00062F34 File Offset: 0x00061134
	public void OnUpdate()
	{
		if (!Screen.lockCursor && !ApplicationDataManager.IsMobile)
		{
			global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
		}
		bool flag = (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Input.GetKey(KeyCode.Tab);
		if (Input.GetKeyDown(KeyCode.Escape) || flag)
		{
			global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
		}
		if (!GameData.Instance.HUDChatIsTyping)
		{
			if (Input.GetKeyDown(KeyCode.L))
			{
				if (GamePageManager.IsCurrentPage(IngamePageType.None))
				{
					global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
					if (GameState.Current.IsSinglePlayer)
					{
						GamePageManager.Instance.LoadPage(IngamePageType.PausedOffline);
					}
					else if (!GameState.Current.IsMatchRunning)
					{
						GamePageManager.Instance.LoadPage(IngamePageType.PausedWaiting);
					}
					else
					{
						GamePageManager.Instance.LoadPage(IngamePageType.Paused);
					}
				}
				else
				{
					GamePageManager.Instance.UnloadCurrentPage();
				}
			}
			else if (Input.GetKeyDown(KeyCode.Backspace))
			{
				global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
			}
		}
	}

	// Token: 0x06000EB7 RID: 3767 RVA: 0x0000AA20 File Offset: 0x00008C20
	private void OnPlayerRespawn(GameEvents.PlayerRespawn ev)
	{
		GameState.Current.Player.InitializePlayer();
	}

	// Token: 0x06000EB8 RID: 3768 RVA: 0x0000AA31 File Offset: 0x00008C31
	private void OnPlayerChatting(GameEvents.ChatWindow ev)
	{
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = (!ev.IsEnabled && this.stateMachine.CurrentStateId == PlayerStateId.Playing);
		GameState.Current.PlayerData.ResetKeys();
	}

	// Token: 0x06000EB9 RID: 3769 RVA: 0x0000AA68 File Offset: 0x00008C68
	private void OnPlayerPaused(GameEvents.PlayerPause ev)
	{
		this.stateMachine.PushState(PlayerStateId.Paused);
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x0006305C File Offset: 0x0006125C
	private void OnPlayerUnpaused(GameEvents.PlayerUnpause ev)
	{
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = true;
		Singleton<QuickItemController>.Instance.IsEnabled = true;
		GameState.Current.Player.EnableWeaponControl = true;
		Screen.lockCursor = true;
		LevelCamera.SetMode(LevelCamera.CameraMode.FirstPerson, null);
		if (!Singleton<WeaponController>.Instance.CheckWeapons(Singleton<LoadoutManager>.Instance.GetWeapons()))
		{
			GameState.Current.Player.InitializeWeapons();
		}
		global::EventHandler.Global.Fire(new GameEvents.PlayerIngame());
	}

	// Token: 0x06000EBB RID: 3771 RVA: 0x000630D4 File Offset: 0x000612D4
	private void OnPlayerDamage(GameEvents.PlayerDamage ev)
	{
		Singleton<DamageFeedbackHud>.Instance.AddDamageMark(Mathf.Clamp01(ev.DamageValue / 50f), ev.Angle);
		if (!GameState.Current.Player.MoveController.IsGrounded)
		{
			GameState.Current.Player.MoveController.ApplyForce(Quaternion.AngleAxis(-ev.Angle, Vector3.up) * Vector3.forward * ev.DamageValue * 10f, CharacterMoveController.ForceType.Additive);
		}
		if (GameState.Current.PlayerData.ArmorPoints > 0)
		{
			AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.LocalPlayerHitArmorRemaining, 0UL);
		}
		else
		{
			AutoMonoBehaviour<SfxManager>.Instance.PlayInGameAudioClip(GameAudio.LocalPlayerHitNoArmor, 0UL);
		}
	}

	// Token: 0x06000EBC RID: 3772 RVA: 0x0000AA76 File Offset: 0x00008C76
	private void OnPlayerKilled(GameEvents.PlayerDied ev)
	{
		this.stateMachine.SetState(PlayerStateId.Killed);
	}

	// Token: 0x04000D3B RID: 3387
	private StateMachine<PlayerStateId> stateMachine;
}
