using System;
using UnityEngine;

// Token: 0x0200020B RID: 523
internal class PrepareNextRoundState : IState
{
	// Token: 0x06000E7D RID: 3709 RVA: 0x000021A8 File Offset: 0x000003A8
	public PrepareNextRoundState(StateMachine<GameStateId> stateMachine)
	{
	}

	// Token: 0x06000E7E RID: 3710 RVA: 0x00062574 File Offset: 0x00060774
	public void OnEnter()
	{
		global::EventHandler.Global.AddListener<GameEvents.MatchCountdown>(new Action<GameEvents.MatchCountdown>(this.OnMatchStartCountdownEvent));
		global::EventHandler.Global.AddListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
		GameState.Current.PlayerState.SetState(PlayerStateId.PrepareForMatch);
		global::EventHandler.Global.Fire(new GameEvents.PlayerIngame());
	}

	// Token: 0x06000E7F RID: 3711 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E80 RID: 3712 RVA: 0x0000A8AC File Offset: 0x00008AAC
	public void OnExit()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.MatchCountdown>(new Action<GameEvents.MatchCountdown>(this.OnMatchStartCountdownEvent));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
	}

	// Token: 0x06000E81 RID: 3713 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnUpdate()
	{
	}

	// Token: 0x06000E82 RID: 3714 RVA: 0x0000A757 File Offset: 0x00008957
	private void OnPlayerRespawn(GameEvents.PlayerRespawn ev)
	{
		GameState.Current.RespawnLocalPlayerAt(ev.Position, Quaternion.Euler(0f, ev.Rotation, 0f));
		GameState.Current.PlayerState.SetState(PlayerStateId.PrepareForMatch);
	}

	// Token: 0x06000E83 RID: 3715 RVA: 0x000625CC File Offset: 0x000607CC
	private void OnMatchStartCountdownEvent(GameEvents.MatchCountdown ev)
	{
		switch (ev.Countdown)
		{
		case 1:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown1, 0UL, 1f, 1f);
			break;
		case 2:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown2, 0UL, 1f, 1f);
			break;
		case 3:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown3, 0UL, 1f, 1f);
			break;
		case 4:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown4, 0UL, 1f, 1f);
			break;
		case 5:
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.MatchEndingCountdown5, 0UL, 1f, 1f);
			break;
		}
	}
}
