using System;
using UnityEngine;

// Token: 0x02000207 RID: 519
internal class EndOfMatchState : IState
{
	// Token: 0x06000E62 RID: 3682 RVA: 0x000021A8 File Offset: 0x000003A8
	public EndOfMatchState(StateMachine<GameStateId> stateMachine)
	{
	}

	// Token: 0x06000E63 RID: 3683 RVA: 0x000621FC File Offset: 0x000603FC
	public void OnEnter()
	{
		AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.EndOfRound, 0UL, 1f, 1f);
		Singleton<QuickItemController>.Instance.Restriction.RenewGameUses();
		global::EventHandler.Global.AddListener<GameEvents.MatchCountdown>(new Action<GameEvents.MatchCountdown>(this.OnMatchCountdown));
		global::EventHandler.Global.AddListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
		GamePageManager.Instance.LoadPage(IngamePageType.EndOfMatch);
		global::EventHandler.Global.Fire(new GameEvents.MatchEnd());
		this.SpawnLocalAvatar();
	}

	// Token: 0x06000E64 RID: 3684 RVA: 0x00062280 File Offset: 0x00060480
	private void SpawnLocalAvatar()
	{
		if (GameState.Current.Avatar.Decorator)
		{
			GameState.Current.Player.SpawnPlayerAt(GameState.Current.Map.DefaultSpawnPoint.position, GameState.Current.Map.DefaultSpawnPoint.rotation);
			if (GameState.Current.Player.Character)
			{
				GameState.Current.PlayerData.Reset();
				GameState.Current.Player.Character.Reset();
			}
		}
		GameState.Current.PlayerState.SetState(PlayerStateId.Overview);
	}

	// Token: 0x06000E65 RID: 3685 RVA: 0x0000A729 File Offset: 0x00008929
	public void OnExit()
	{
		global::EventHandler.Global.RemoveListener<GameEvents.MatchCountdown>(new Action<GameEvents.MatchCountdown>(this.OnMatchCountdown));
		global::EventHandler.Global.RemoveListener<GameEvents.PlayerRespawn>(new Action<GameEvents.PlayerRespawn>(this.OnPlayerRespawn));
	}

	// Token: 0x06000E66 RID: 3686 RVA: 0x0000A757 File Offset: 0x00008957
	private void OnPlayerRespawn(GameEvents.PlayerRespawn ev)
	{
		GameState.Current.RespawnLocalPlayerAt(ev.Position, Quaternion.Euler(0f, ev.Rotation, 0f));
		GameState.Current.PlayerState.SetState(PlayerStateId.PrepareForMatch);
	}

	// Token: 0x06000E67 RID: 3687 RVA: 0x0000A78E File Offset: 0x0000898E
	private void OnMatchCountdown(GameEvents.MatchCountdown ev)
	{
		if (ev.Countdown <= 3 && ev.Countdown > 0)
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.CountdownTonal1, 0UL, 1f, 1f);
		}
	}

	// Token: 0x06000E68 RID: 3688 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnResume()
	{
	}

	// Token: 0x06000E69 RID: 3689 RVA: 0x00003C87 File Offset: 0x00001E87
	public void OnUpdate()
	{
	}
}
