using System;
using UnityEngine;

// Token: 0x02000212 RID: 530
internal class PlayerKilledSpectatorState : IState
{
	// Token: 0x06000E9C RID: 3740 RVA: 0x000021A8 File Offset: 0x000003A8
	public PlayerKilledSpectatorState(StateMachine<PlayerStateId> stateMachine, bool showInGameHelp = true)
	{
	}

	// Token: 0x06000E9D RID: 3741 RVA: 0x0000A97F File Offset: 0x00008B7F
	public void OnEnter()
	{
		Screen.lockCursor = false;
		Singleton<QuickItemController>.Instance.IsEnabled = false;
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = false;
		LevelCamera.SetMode(LevelCamera.CameraMode.Ragdoll, null);
	}

	// Token: 0x06000E9E RID: 3742 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E9F RID: 3743 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnExit()
	{
	}

	// Token: 0x06000EA0 RID: 3744 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnUpdate()
	{
	}
}
