using System;
using UnityEngine;

// Token: 0x02000210 RID: 528
internal class PlayerAfterRoundState : IState
{
	// Token: 0x06000E92 RID: 3730 RVA: 0x000021A8 File Offset: 0x000003A8
	public PlayerAfterRoundState(StateMachine<PlayerStateId> stateMachine)
	{
	}

	// Token: 0x06000E93 RID: 3731 RVA: 0x0000A933 File Offset: 0x00008B33
	public void OnEnter()
	{
		AutoMonoBehaviour<UnityRuntime>.Instance.OnFixedUpdate += GameState.Current.Player.MoveController.UpdatePlayerMovement;
	}

	// Token: 0x06000E94 RID: 3732 RVA: 0x0000A959 File Offset: 0x00008B59
	public void OnExit()
	{
		AutoMonoBehaviour<UnityRuntime>.Instance.OnFixedUpdate -= GameState.Current.Player.MoveController.UpdatePlayerMovement;
	}

	// Token: 0x06000E95 RID: 3733 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E96 RID: 3734 RVA: 0x000629C4 File Offset: 0x00060BC4
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
}
