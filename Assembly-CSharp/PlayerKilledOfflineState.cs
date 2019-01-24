using System;
using UnityEngine;

// Token: 0x02000211 RID: 529
internal class PlayerKilledOfflineState : IState
{
	// Token: 0x06000E97 RID: 3735 RVA: 0x000021A8 File Offset: 0x000003A8
	public PlayerKilledOfflineState(StateMachine<PlayerStateId> stateMachine)
	{
	}

	// Token: 0x06000E98 RID: 3736 RVA: 0x0000A97F File Offset: 0x00008B7F
	public void OnEnter()
	{
		Screen.lockCursor = false;
		Singleton<QuickItemController>.Instance.IsEnabled = false;
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = false;
		LevelCamera.SetMode(LevelCamera.CameraMode.Ragdoll, null);
	}

	// Token: 0x06000E99 RID: 3737 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E9A RID: 3738 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnExit()
	{
	}

	// Token: 0x06000E9B RID: 3739 RVA: 0x00062A68 File Offset: 0x00060C68
	public void OnUpdate()
	{
		if (Input.GetKeyDown(KeyCode.L) && !GameData.Instance.HUDChatIsTyping)
		{
			if (GamePageManager.IsCurrentPage(IngamePageType.None))
			{
				GamePageManager.Instance.LoadPage(IngamePageType.PausedWaiting);
			}
			else
			{
				GamePageManager.Instance.UnloadCurrentPage();
			}
		}
	}
}
