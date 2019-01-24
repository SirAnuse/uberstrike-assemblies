using System;
using UnityEngine;

// Token: 0x02000214 RID: 532
internal class PlayerOverviewState : IState
{
	// Token: 0x06000EA8 RID: 3752 RVA: 0x000021A8 File Offset: 0x000003A8
	public PlayerOverviewState(StateMachine<PlayerStateId> stateMachine)
	{
	}

	// Token: 0x06000EA9 RID: 3753 RVA: 0x00062B70 File Offset: 0x00060D70
	public void OnEnter()
	{
		Singleton<QuickItemController>.Instance.IsEnabled = false;
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = false;
		Screen.lockCursor = false;
		WeaponFeedbackManager.SetBobMode(LevelCamera.BobMode.Idle);
		if (Singleton<WeaponController>.Instance.CurrentWeapon)
		{
			Singleton<WeaponController>.Instance.CurrentWeapon.StopSound();
		}
		GameState.Current.Player.EnableWeaponControl = false;
		LevelCamera.SetMode(LevelCamera.CameraMode.OrbitAround, null);
		if (GameState.Current.Player.Character != null)
		{
			GameState.Current.Player.Character.WeaponSimulator.UpdateWeaponSlot((int)GameState.Current.PlayerData.Player.CurrentWeaponSlot, true);
		}
	}

	// Token: 0x06000EAA RID: 3754 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000EAB RID: 3755 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnExit()
	{
	}

	// Token: 0x06000EAC RID: 3756 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnUpdate()
	{
	}
}
