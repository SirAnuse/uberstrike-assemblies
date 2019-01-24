using System;

// Token: 0x02000206 RID: 518
internal class AfterRoundState : IState
{
	// Token: 0x06000E5D RID: 3677 RVA: 0x000021A8 File Offset: 0x000003A8
	public AfterRoundState(StateMachine<GameStateId> stateMachine)
	{
	}

	// Token: 0x06000E5E RID: 3678 RVA: 0x0000A717 File Offset: 0x00008917
	public void OnEnter()
	{
		GameState.Current.PlayerState.SetState(PlayerStateId.AfterRound);
	}

	// Token: 0x06000E5F RID: 3679 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E60 RID: 3680 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnExit()
	{
	}

	// Token: 0x06000E61 RID: 3681 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnUpdate()
	{
	}
}
