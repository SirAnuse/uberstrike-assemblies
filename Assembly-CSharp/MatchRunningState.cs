using System;
using UnityEngine;

// Token: 0x02000208 RID: 520
internal class MatchRunningState : IState
{
	// Token: 0x06000E6A RID: 3690 RVA: 0x000021A8 File Offset: 0x000003A8
	public MatchRunningState(StateMachine<GameStateId> stateMachine)
	{
	}

	// Token: 0x06000E6B RID: 3691 RVA: 0x0006232C File Offset: 0x0006052C
	public void OnEnter()
	{
		Singleton<ProjectileManager>.Instance.Clear();
		AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.Fight, 0UL, 1f, 1f);
		if (GameState.Current.Players.ContainsKey(PlayerDataManager.Cmid) && !GameState.Current.PlayerData.IsSpectator)
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.Playing);
		}
		else
		{
			GameState.Current.PlayerState.SetState(PlayerStateId.Spectating);
		}
		global::EventHandler.Global.AddListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
	}

	// Token: 0x06000E6C RID: 3692 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E6D RID: 3693 RVA: 0x0000A7C3 File Offset: 0x000089C3
	public void OnExit()
	{
		GameState.Current.PlayerState.PopAllStates();
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
	}

	// Token: 0x06000E6E RID: 3694 RVA: 0x0000A7EA File Offset: 0x000089EA
	public void OnUpdate()
	{
		GameStateHelper.UpdateMatchTime();
	}

	// Token: 0x06000E6F RID: 3695 RVA: 0x0000A7F1 File Offset: 0x000089F1
	private void OnPlayerRespawn(GameEvents.PlayerRespawn ev)
	{
		GameState.Current.RespawnLocalPlayerAt(ev.Position, Quaternion.Euler(0f, ev.Rotation, 0f));
		GameState.Current.PlayerState.SetState(PlayerStateId.Playing);
	}
}
