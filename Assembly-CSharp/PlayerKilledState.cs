using System;
using UnityEngine;

// Token: 0x02000213 RID: 531
internal class PlayerKilledState : IState
{
	// Token: 0x06000EA1 RID: 3745 RVA: 0x0000A9A4 File Offset: 0x00008BA4
	public PlayerKilledState(StateMachine<PlayerStateId> stateMachine)
	{
		this.stateMachine = stateMachine;
	}

	// Token: 0x06000EA2 RID: 3746 RVA: 0x00062AB8 File Offset: 0x00060CB8
	public void OnEnter()
	{
		Screen.lockCursor = false;
		Singleton<QuickItemController>.Instance.IsEnabled = false;
		AutoMonoBehaviour<InputManager>.Instance.IsInputEnabled = false;
		LevelCamera.SetMode(LevelCamera.CameraMode.Ragdoll, null);
		this.stateMachine.Events.AddListener<GameEvents.RespawnCountdown>(new Action<GameEvents.RespawnCountdown>(this.OnRespawnCountdown));
		global::EventHandler.Global.AddListener<GameEvents.PlayerUnpause>(new Action<GameEvents.PlayerUnpause>(this.OnUnpause));
	}

	// Token: 0x06000EA3 RID: 3747 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000EA4 RID: 3748 RVA: 0x0000A9B3 File Offset: 0x00008BB3
	public void OnExit()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerUnpause>(new Action<GameEvents.PlayerUnpause>(this.OnUnpause));
		this.stateMachine.Events.RemoveListener<GameEvents.RespawnCountdown>(new Action<GameEvents.RespawnCountdown>(this.OnRespawnCountdown));
	}

	// Token: 0x06000EA5 RID: 3749 RVA: 0x00062B1C File Offset: 0x00060D1C
	public void OnUpdate()
	{
		GameStateHelper.UpdateMatchTime();
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

	// Token: 0x06000EA6 RID: 3750 RVA: 0x00003C87 File Offset: 0x00001E87
	private void OnUnpause(GameEvents.PlayerUnpause ev)
	{
	}

	// Token: 0x06000EA7 RID: 3751 RVA: 0x0000A9E7 File Offset: 0x00008BE7
	private void OnRespawnCountdown(GameEvents.RespawnCountdown ev)
	{
		GameData.Instance.OnRespawnCountdown.Fire(ev.Countdown);
	}

	// Token: 0x04000D38 RID: 3384
	private const int DisconnectionTimeout = 120;

	// Token: 0x04000D39 RID: 3385
	private const int DisconnectionTimeoutAdmin = 1200;

	// Token: 0x04000D3A RID: 3386
	private StateMachine<PlayerStateId> stateMachine;
}
