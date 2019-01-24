using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000387 RID: 903
public class TryInShopRoom : IDisposable, IGameMode
{
	// Token: 0x06001A3E RID: 6718 RVA: 0x0008A1DC File Offset: 0x000883DC
	public TryInShopRoom()
	{
		GameState.Current.MatchState.RegisterState(GameStateId.MatchRunning, new OfflineMatchState(GameState.Current.MatchState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Playing, new PlayerPlayingState(GameState.Current.PlayerState));
		GameState.Current.PlayerState.RegisterState(PlayerStateId.Paused, new PlayerPausedState(GameState.Current.PlayerState));
		GameState.Current.Actions.DirectHitDamage = delegate(int targetCmid, ushort damage, BodyPart part, Vector3 force, byte slot, byte bullets)
		{
			GameState.Current.Player.MoveController.ApplyForce(force, CharacterMoveController.ForceType.Additive);
		};
		AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate += this.OnUpdate;
		GameStateHelper.EnterGameMode();
		GameActorInfo gameActorInfo = new GameActorInfo
		{
			Cmid = PlayerDataManager.Cmid,
			SkinColor = PlayerDataManager.SkinColor
		};
		GameState.Current.PlayerData.Player = gameActorInfo;
		GameState.Current.Players[gameActorInfo.Cmid] = gameActorInfo;
		GameState.Current.InstantiateAvatar(gameActorInfo);
		MenuPageManager.Instance.UnloadCurrentPage();
		GameState.Current.MatchState.SetState(GameStateId.MatchRunning);
	}

	// Token: 0x06001A3F RID: 6719 RVA: 0x0001166A File Offset: 0x0000F86A
	public void Dispose()
	{
		if (!this.isDisposed)
		{
			this.isDisposed = true;
			AutoMonoBehaviour<UnityRuntime>.Instance.OnUpdate -= this.OnUpdate;
			GameStateHelper.ExitGameMode();
		}
	}

	// Token: 0x06001A40 RID: 6720 RVA: 0x00011699 File Offset: 0x0000F899
	private void OnUpdate()
	{
		Singleton<QuickItemController>.Instance.Update();
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Singleton<GameStateController>.Instance.UnloadGameMode();
			MenuPageManager.Instance.LoadPage(PageType.Shop, false);
		}
	}

	// Token: 0x170005CD RID: 1485
	// (get) Token: 0x06001A41 RID: 6721 RVA: 0x0001162D File Offset: 0x0000F82D
	public GameMode Type
	{
		get
		{
			return GameMode.Training;
		}
	}

	// Token: 0x040017C6 RID: 6086
	private bool isDisposed;
}
