using System;
using UnityEngine;

// Token: 0x02000217 RID: 535
internal class PlayerPrepareState : IState
{
	// Token: 0x06000EBD RID: 3773 RVA: 0x000021A8 File Offset: 0x000003A8
	public PlayerPrepareState(StateMachine<PlayerStateId> stateMachine)
	{
	}

	// Token: 0x06000EBE RID: 3774 RVA: 0x000631A4 File Offset: 0x000613A4
	public void OnEnter()
	{
		GameState.Current.Player.InitializePlayer();
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = false;
		Singleton<QuickItemController>.Instance.IsEnabled = false;
		GameState.Current.Player.EnableWeaponControl = false;
		Screen.lockCursor = true;
		LevelCamera.SetMode(LevelCamera.CameraMode.FirstPerson, null);
		global::EventHandler.Global.Fire(new GameEvents.PlayerIngame());
		AutoMonoBehaviour<UnityRuntime>.Instance.OnFixedUpdate += GameState.Current.Player.MoveController.UpdatePlayerMovement;
	}

	// Token: 0x06000EBF RID: 3775 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x0000A959 File Offset: 0x00008B59
	public void OnExit()
	{
		AutoMonoBehaviour<UnityRuntime>.Instance.OnFixedUpdate -= GameState.Current.Player.MoveController.UpdatePlayerMovement;
	}

	// Token: 0x06000EC1 RID: 3777 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnUpdate()
	{
	}
}
