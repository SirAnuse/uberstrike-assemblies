using System;

// Token: 0x0200020A RID: 522
internal class PregameLoadoutState : IState
{
	// Token: 0x06000E76 RID: 3702 RVA: 0x0000A85C File Offset: 0x00008A5C
	public PregameLoadoutState(StateMachine<GameStateId> stateMachine)
	{
		this.stateMachine = stateMachine;
	}

	// Token: 0x06000E77 RID: 3703 RVA: 0x0006241C File Offset: 0x0006061C
	public void OnEnter()
	{
		GamePageManager.Instance.LoadPage(IngamePageType.PreGame);
		Singleton<QuickItemController>.Instance.Restriction.RenewRoundUses();
		global::EventHandler.Global.AddListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
		this.SpawnLocalAvatar();
		if (GameState.Current.IsMultiplayer)
		{
			Singleton<ChatManager>.Instance.SetGameSection(GameState.Current.RoomData.Server.ConnectionString, GameState.Current.RoomData.Number, GameState.Current.RoomData.MapID, GameState.Current.Players.Values);
		}
	}

	// Token: 0x06000E78 RID: 3704 RVA: 0x0000A86B File Offset: 0x00008A6B
	public void OnExit()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
		GamePageManager.Instance.UnloadCurrentPage();
	}

	// Token: 0x06000E79 RID: 3705 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E7A RID: 3706 RVA: 0x000624BC File Offset: 0x000606BC
	private void SpawnLocalAvatar()
	{
		if (GameState.Current.Avatar.Decorator)
		{
			GameState.Current.Player.SpawnPlayerAt(GameState.Current.Map.DefaultSpawnPoint.position, GameState.Current.Map.DefaultSpawnPoint.rotation);
			GameState.Current.Avatar.Decorator.SetPosition(GameState.Current.Map.DefaultSpawnPoint.position, GameState.Current.Map.DefaultSpawnPoint.rotation);
			GameState.Current.Avatar.HideWeapons();
		}
		GameState.Current.PlayerState.SetState(PlayerStateId.Overview);
	}

	// Token: 0x06000E7B RID: 3707 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnUpdate()
	{
	}

	// Token: 0x06000E7C RID: 3708 RVA: 0x0000A88D File Offset: 0x00008A8D
	private void OnPlayerRespawn(GameEvents.PlayerRespawn ev)
	{
		this.stateMachine.SetState(GameStateId.MatchRunning);
		this.stateMachine.Events.Fire(ev);
	}

	// Token: 0x04000D31 RID: 3377
	private StateMachine<GameStateId> stateMachine;
}
