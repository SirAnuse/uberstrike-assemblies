using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000215 RID: 533
internal class PlayerPausedState : IState
{
	// Token: 0x06000EAD RID: 3757 RVA: 0x000021A8 File Offset: 0x000003A8
	public PlayerPausedState(StateMachine<PlayerStateId> stateMachine)
	{
	}

	// Token: 0x06000EAE RID: 3758 RVA: 0x00062C24 File Offset: 0x00060E24
	public void OnEnter()
	{
		Singleton<WeaponController>.Instance.StopInputHandler();
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = false;
		Screen.lockCursor = false;
		WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.Idle);
		GameState.Current.PlayerData.ResetKeys();
		GameState.Current.PlayerData.Set(PlayerStates.Shooting, false);
		GameState.Current.PlayerData.Set(PlayerStates.Paused, true);
		if (GameState.Current.IsLocalAvatarLoaded)
		{
			LevelCamera.SetMode(LevelCamera.CameraMode.Paused, null);
			GameState.Current.Player.Character.WeaponSimulator.UpdateWeaponSlot((int)GameState.Current.PlayerData.Player.CurrentWeaponSlot, true);
		}
		if (GameState.Current.IsMultiplayer)
		{
			Singleton<ChatManager>.Instance.SetGameSection(GameState.Current.RoomData.Server.ConnectionString, GameState.Current.RoomData.Number, GameState.Current.RoomData.MapID, GameState.Current.Players.Values);
		}
	}

	// Token: 0x06000EAF RID: 3759 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000EB0 RID: 3760 RVA: 0x0000A9FE File Offset: 0x00008BFE
	public void OnExit()
	{
		GameState.Current.PlayerData.Set(PlayerStates.Paused, false);
	}

	// Token: 0x06000EB1 RID: 3761 RVA: 0x00062D24 File Offset: 0x00060F24
	public void OnUpdate()
	{
		if (Input.GetKeyDown(KeyCode.L) && !GameData.Instance.HUDChatIsTyping)
		{
			if (GamePageManager.IsCurrentPage(IngamePageType.None))
			{
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
	}
}
