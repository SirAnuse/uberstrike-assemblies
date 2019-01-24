using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000218 RID: 536
internal class PlayerSpectatingState : IState
{
	// Token: 0x06000EC2 RID: 3778 RVA: 0x0000AA84 File Offset: 0x00008C84
	public PlayerSpectatingState(StateMachine<PlayerStateId> stateMachine)
	{
		this.stateMachine = stateMachine;
	}

	// Token: 0x06000EC3 RID: 3779 RVA: 0x00063228 File Offset: 0x00061428
	public void OnEnter()
	{
		GamePageManager.Instance.UnloadCurrentPage();
		global::EventHandler.Global.AddListener<GameEvents.PlayerPause>(new Action<GameEvents.PlayerPause>(this.OnPlayerPaused));
		global::EventHandler.Global.AddListener<GameEvents.PlayerUnpause>(new Action<GameEvents.PlayerUnpause>(this.OnPlayerUnpaused));
		global::EventHandler.Global.AddListener<GameEvents.PlayerLeft>(new Action<GameEvents.PlayerLeft>(this.OnPlayerLeft));
		global::EventHandler.Global.AddListener<GameEvents.FollowPlayer>(new Action<GameEvents.FollowPlayer>(this.FollowNextPlayer));
		global::EventHandler.Global.AddListener<GlobalEvents.InputChanged>(new Action<GlobalEvents.InputChanged>(this.OnInputChanged));
		LevelCamera.SetMode(LevelCamera.CameraMode.FreeSpectator, null);
		this.EnterFreeMoveMode();
		GameState.Current.PlayerData.ResetKeys();
		this.OnPlayerUnpaused(null);
		global::EventHandler.Global.Fire(new GameEvents.PlayerSpectator());
	}

	// Token: 0x06000EC4 RID: 3780 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000EC5 RID: 3781 RVA: 0x000632E0 File Offset: 0x000614E0
	public void OnExit()
	{
		this.currentPlayerId = 0;
		LevelCamera.SetMode(LevelCamera.CameraMode.Disabled, null);
		GamePageManager.Instance.UnloadCurrentPage();
		global::EventHandler.Global.RemoveListener<GlobalEvents.InputChanged>(new Action<GlobalEvents.InputChanged>(this.OnInputChanged));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerPause>(new Action<GameEvents.PlayerPause>(this.OnPlayerPaused));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerUnpause>(new Action<GameEvents.PlayerUnpause>(this.OnPlayerUnpaused));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerLeft>(new Action<GameEvents.PlayerLeft>(this.OnPlayerLeft));
		global::EventHandler.Global.RemoveListener<GameEvents.FollowPlayer>(new Action<GameEvents.FollowPlayer>(this.FollowNextPlayer));
	}

	// Token: 0x06000EC6 RID: 3782 RVA: 0x000629C4 File Offset: 0x00060BC4
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
		if (!GameData.Instance.HUDChatIsTyping && Input.GetKeyDown(KeyCode.Backspace))
		{
			global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
		}
	}

	// Token: 0x06000EC7 RID: 3783 RVA: 0x0000AA93 File Offset: 0x00008C93
	private void OnPlayerPaused(GameEvents.PlayerPause ev)
	{
		this.stateMachine.PushState(PlayerStateId.Paused);
	}

	// Token: 0x06000EC8 RID: 3784 RVA: 0x0000AAA1 File Offset: 0x00008CA1
	private void OnPlayerUnpaused(GameEvents.PlayerUnpause ev)
	{
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = true;
		Singleton<QuickItemController>.Instance.IsEnabled = false;
		GameState.Current.Player.EnableWeaponControl = false;
		Screen.lockCursor = true;
		global::EventHandler.Global.Fire(new GameEvents.PlayerIngame());
	}

	// Token: 0x06000EC9 RID: 3785 RVA: 0x0000AADE File Offset: 0x00008CDE
	private void OnPlayerLeft(GameEvents.PlayerLeft ev)
	{
		if (this.currentPlayerId == ev.Cmid)
		{
			this.EnterFreeMoveMode();
		}
	}

	// Token: 0x06000ECA RID: 3786 RVA: 0x00063374 File Offset: 0x00061574
	private void OnInputChanged(GlobalEvents.InputChanged ev)
	{
		if (AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled && !GameData.Instance.HUDChatIsTyping && Screen.lockCursor)
		{
			if (ev.Key == GameInputKey.PrimaryFire && ev.IsDown)
			{
				this.FollowPrevPlayer();
			}
			else if (ev.Key == GameInputKey.SecondaryFire && ev.IsDown)
			{
				this.FollowNextPlayer();
			}
			else if (ev.Key == GameInputKey.Jump && ev.IsDown)
			{
				this.EnterFreeMoveMode();
			}
		}
	}

	// Token: 0x06000ECB RID: 3787 RVA: 0x0000AAF7 File Offset: 0x00008CF7
	private void FollowNextPlayer(GameEvents.FollowPlayer ev)
	{
		this.FollowNextPlayer();
	}

	// Token: 0x06000ECC RID: 3788 RVA: 0x0006340C File Offset: 0x0006160C
	private void FollowNextPlayer()
	{
		try
		{
			if (GameState.Current.HasJoinedGame && GameState.Current.Players.Count > 0)
			{
				GameActorInfo[] array = GameState.Current.Players.ValueArray<int, GameActorInfo>();
				this._currentFollowIndex = (this._currentFollowIndex + 1) % array.Length;
				int currentFollowIndex = this._currentFollowIndex;
				while (array[this._currentFollowIndex].Cmid == PlayerDataManager.Cmid || !array[this._currentFollowIndex].IsAlive || !GameState.Current.HasAvatarLoaded(array[this._currentFollowIndex].Cmid))
				{
					this._currentFollowIndex = (this._currentFollowIndex + 1) % array.Length;
					if (this._currentFollowIndex == currentFollowIndex)
					{
						this.EnterFreeMoveMode();
						return;
					}
				}
				if (array[this._currentFollowIndex] != null)
				{
					this.ChangeTarget(array[this._currentFollowIndex].Cmid);
				}
				else
				{
					this.EnterFreeMoveMode();
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to follow next player: " + ex.Message);
		}
	}

	// Token: 0x06000ECD RID: 3789 RVA: 0x00063534 File Offset: 0x00061734
	private void FollowPrevPlayer()
	{
		try
		{
			if (GameState.Current.HasJoinedGame && GameState.Current.Players.Count > 0)
			{
				List<GameActorInfo> list = new List<GameActorInfo>(GameState.Current.Players.Values);
				this._currentFollowIndex = (this._currentFollowIndex + list.Count - 1) % list.Count;
				int currentFollowIndex = this._currentFollowIndex;
				while (list[this._currentFollowIndex].Cmid == PlayerDataManager.Cmid || !list[this._currentFollowIndex].IsAlive || !GameState.Current.HasAvatarLoaded(list[this._currentFollowIndex].Cmid))
				{
					this._currentFollowIndex = (this._currentFollowIndex + list.Count - 1) % list.Count;
					if (this._currentFollowIndex == currentFollowIndex)
					{
						this.EnterFreeMoveMode();
						return;
					}
				}
				if (list[this._currentFollowIndex] != null)
				{
					this.ChangeTarget(list[this._currentFollowIndex].Cmid);
				}
				else
				{
					this.EnterFreeMoveMode();
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Failed to follow prev player: " + ex.Message);
		}
	}

	// Token: 0x06000ECE RID: 3790 RVA: 0x00063698 File Offset: 0x00061898
	private void ChangeTarget(int cmid)
	{
		if (this.currentPlayerId != cmid)
		{
			CharacterConfig characterConfig;
			if (GameState.Current.TryGetPlayerAvatar(cmid, out characterConfig) && characterConfig.Avatar.Decorator)
			{
				this.currentPlayerId = cmid;
				LevelCamera.SetMode(LevelCamera.CameraMode.SmoothFollow, characterConfig.Avatar.Decorator.transform);
				if (!characterConfig.State.Player.IsAlive)
				{
					LevelCamera.SetPosition(characterConfig.transform.position);
				}
			}
			else
			{
				this.EnterFreeMoveMode();
			}
		}
	}

	// Token: 0x06000ECF RID: 3791 RVA: 0x0000AAFF File Offset: 0x00008CFF
	private void EnterFreeMoveMode()
	{
		if (LevelCamera.CurrentMode != LevelCamera.CameraMode.FreeSpectator)
		{
			this.currentPlayerId = 0;
			LevelCamera.SetMode(LevelCamera.CameraMode.FreeSpectator, null);
			Screen.lockCursor = true;
		}
	}

	// Token: 0x04000D3C RID: 3388
	private StateMachine<PlayerStateId> stateMachine;

	// Token: 0x04000D3D RID: 3389
	private int currentPlayerId;

	// Token: 0x04000D3E RID: 3390
	private int _currentFollowIndex;
}
