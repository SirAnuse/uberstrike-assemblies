using System;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200020C RID: 524
internal class WaitingForPlayersState : IState
{
	// Token: 0x06000E84 RID: 3716 RVA: 0x000021A8 File Offset: 0x000003A8
	public WaitingForPlayersState(StateMachine<GameStateId> stateMachine)
	{
	}

	// Token: 0x06000E85 RID: 3717 RVA: 0x000626A4 File Offset: 0x000608A4
	public void OnEnter()
	{
		GamePageManager.Instance.UnloadCurrentPage();
		if (GameState.Current.Players.ContainsKey(PlayerDataManager.Cmid))
		{
			GameStateHelper.RespawnLocalPlayerAtRandom();
			GameState.Current.PlayerState.SetState(PlayerStateId.Playing);
		}
		else
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.Spectating);
		}
		global::EventHandler.Global.Fire(new GameEvents.PlayerIngame());
		global::EventHandler.Global.AddListener<GameEvents.PlayerDied>(new Action<GameEvents.PlayerDied>(this.OnPlayerKilled));
		global::EventHandler.Global.AddListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
	}

	// Token: 0x06000E86 RID: 3718 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E87 RID: 3719 RVA: 0x0000A8DA File Offset: 0x00008ADA
	public void OnExit()
	{
		GamePageManager.Instance.UnloadCurrentPage();
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerDied>(new Action<GameEvents.PlayerDied>(this.OnPlayerKilled));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
	}

	// Token: 0x06000E88 RID: 3720 RVA: 0x0006273C File Offset: 0x0006093C
	public void OnUpdate()
	{
		string v = string.Empty;
		if (GameState.Current.GameMode == GameModeType.DeathMatch)
		{
			v = "Get as many kills as you can before the time runs out";
		}
		else
		{
			v = "Get as many kills for your team as you can\nbefore the time runs out";
		}
		GameData.Instance.OnNotificationFull.Fire(LocalizedStrings.WaitingForOtherPlayers, v, 0f);
	}

	// Token: 0x06000E89 RID: 3721 RVA: 0x0000A7F1 File Offset: 0x000089F1
	private void OnPlayerRespawn(GameEvents.PlayerRespawn ev)
	{
		GameState.Current.RespawnLocalPlayerAt(ev.Position, Quaternion.Euler(0f, ev.Rotation, 0f));
		GameState.Current.PlayerState.SetState(PlayerStateId.Playing);
	}

	// Token: 0x06000E8A RID: 3722 RVA: 0x0000A84A File Offset: 0x00008A4A
	private void OnPlayerKilled(GameEvents.PlayerDied ev)
	{
		GameState.Current.PlayerState.SetState(PlayerStateId.Killed);
	}
}
