using System;

// Token: 0x02000209 RID: 521
internal class OfflineMatchState : IState
{
	// Token: 0x06000E70 RID: 3696 RVA: 0x000021A8 File Offset: 0x000003A8
	public OfflineMatchState(StateMachine<GameStateId> stateMachine)
	{
	}

	// Token: 0x06000E71 RID: 3697 RVA: 0x000623C8 File Offset: 0x000605C8
	public void OnEnter()
	{
		GamePageManager.Instance.UnloadCurrentPage();
		GameStateHelper.RespawnLocalPlayerAtRandom();
		GameState.Current.PlayerState.SetState(PlayerStateId.Playing);
		global::EventHandler.Global.Fire(new GameEvents.PlayerIngame());
		global::EventHandler.Global.AddListener<GameEvents.PlayerDied>(new Action<GameEvents.PlayerDied>(this.OnPlayerKilled));
	}

	// Token: 0x06000E72 RID: 3698 RVA: 0x0000A828 File Offset: 0x00008A28
	public void OnExit()
	{
		GamePageManager.Instance.UnloadCurrentPage();
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerDied>(new Action<GameEvents.PlayerDied>(this.OnPlayerKilled));
	}

	// Token: 0x06000E73 RID: 3699 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E74 RID: 3700 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnUpdate()
	{
	}

	// Token: 0x06000E75 RID: 3701 RVA: 0x0000A84A File Offset: 0x00008A4A
	private void OnPlayerKilled(GameEvents.PlayerDied ev)
	{
		GameState.Current.PlayerState.SetState(PlayerStateId.Killed);
	}
}
