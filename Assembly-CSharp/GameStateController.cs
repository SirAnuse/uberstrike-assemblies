using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020002B6 RID: 694
public class GameStateController : Singleton<GameStateController>
{
	// Token: 0x06001344 RID: 4932 RVA: 0x0000D18B File Offset: 0x0000B38B
	private GameStateController()
	{
		this.Client = new GamePeer();
	}

	// Token: 0x1700049C RID: 1180
	// (get) Token: 0x06001345 RID: 4933 RVA: 0x0000D19E File Offset: 0x0000B39E
	public GameMode CurrentGameMode
	{
		get
		{
			return (this.currentGameMode == null) ? GameMode.None : this.currentGameMode.Type;
		}
	}

	// Token: 0x1700049D RID: 1181
	// (get) Token: 0x06001346 RID: 4934 RVA: 0x0000D1BC File Offset: 0x0000B3BC
	// (set) Token: 0x06001347 RID: 4935 RVA: 0x0000D1C4 File Offset: 0x0000B3C4
	public GamePeer Client { get; private set; }

	// Token: 0x06001348 RID: 4936 RVA: 0x00070A08 File Offset: 0x0006EC08
	public void CreateNetworkGame(string server, int mapId, GameModeType mode, string name, string password, int timeMinutes, int killLimit, int playerLimit, int minLevel, int maxLevel, GameFlags.GAME_FLAGS flags)
	{
		GameRoomData data = new GameRoomData
		{
			Name = name,
			Server = new ConnectionAddress(server),
			MapID = mapId,
			TimeLimit = timeMinutes,
			PlayerLimit = playerLimit,
			GameMode = mode,
			GameFlags = (int)flags,
			KillLimit = killLimit,
			LevelMin = (byte)Mathf.Clamp(minLevel, 0, 255),
			LevelMax = (byte)Mathf.Clamp(maxLevel, 0, 255)
		};
		float time = Time.time;
		ProgressPopupDialog dialog = PopupSystem.ShowProgress("Authentication", "Connecting to Server", () => Mathf.Clamp(Time.time - time, 0f, 3f));
		dialog.SetCancelable(delegate
		{
			PopupSystem.HideMessage(dialog);
		});
		this.Client.CreateGame(data, password);
	}

	// Token: 0x06001349 RID: 4937 RVA: 0x00070AE0 File Offset: 0x0006ECE0
	public void JoinNetworkGame(GameRoomData data)
	{
		if (data.Server != null)
		{
			float time = Time.time;
			ProgressPopupDialog dialog = PopupSystem.ShowProgress("Authentication", "Connecting to Server", () => Mathf.Clamp(Time.time - time, 0f, 3f));
			dialog.SetCancelable(delegate
			{
				PopupSystem.HideMessage(dialog);
			});
			Singleton<ChatManager>.Instance.InGameDialog.Clear();
			this.Client.JoinGame(data.Server.ConnectionString, data.Number, string.Empty);
		}
		else
		{
			PopupSystem.ShowError("Game not found", "The game doesn't exist anymore.", PopupSystem.AlertType.OK);
		}
	}

	// Token: 0x0600134A RID: 4938 RVA: 0x00070B88 File Offset: 0x0006ED88
	public void JoinNetworkGame(GameRoom data)
	{
		if (data.Server != null)
		{
			float time = Time.time;
			ProgressPopupDialog dialog = PopupSystem.ShowProgress("Authentication", "Connecting to Server", () => Mathf.Clamp(Time.time - time, 0f, 3f));
			dialog.SetCancelable(delegate
			{
				PopupSystem.HideMessage(dialog);
			});
			Singleton<ChatManager>.Instance.InGameDialog.Clear();
			this.Client.JoinGame(data.Server.ConnectionString, data.Number, string.Empty);
		}
		else
		{
			PopupSystem.ShowError("Game not found", "The game doesn't exist anymore.", PopupSystem.AlertType.OK);
		}
	}

	// Token: 0x0600134B RID: 4939 RVA: 0x00070C30 File Offset: 0x0006EE30
	public void LeaveGame(bool warnBeforeLeaving = false)
	{
		if (warnBeforeLeaving && GameState.Current.IsMultiplayer && GameState.Current.IsMatchRunning)
		{
			PopupSystem.ShowMessage(LocalizedStrings.LeavingGame, LocalizedStrings.LeaveGameWarningMsg, PopupSystem.AlertType.OKCancel, new Action(this.BackToMenu), LocalizedStrings.LeaveCaps, null, LocalizedStrings.CancelCaps, PopupSystem.ActionType.Negative);
		}
		else
		{
			this.BackToMenu();
		}
	}

	// Token: 0x0600134C RID: 4940 RVA: 0x0000D1CD File Offset: 0x0000B3CD
	public void ResetClient()
	{
		this.Client.Dispose();
		this.Client = new GamePeer();
	}

	// Token: 0x0600134D RID: 4941 RVA: 0x0000D1E5 File Offset: 0x0000B3E5
	private void BackToMenu()
	{
		GamePageManager.Instance.UnloadCurrentPage();
		this.UnloadGameMode();
		if (Singleton<SceneLoader>.Instance.CurrentScene != "Menu")
		{
			Singleton<SceneLoader>.Instance.LoadLevel("Menu", null);
		}
	}

	// Token: 0x0600134E RID: 4942 RVA: 0x0000D220 File Offset: 0x0000B420
	public void UnloadGameMode()
	{
		this.SetGameMode(null);
	}

	// Token: 0x0600134F RID: 4943 RVA: 0x0000D229 File Offset: 0x0000B429
	public void SetGameMode(IGameMode mode)
	{
		if (this.currentGameMode != null)
		{
			this.Client.LeaveGame();
			this.currentGameMode.Dispose();
		}
		this.currentGameMode = mode;
	}

	// Token: 0x0400132D RID: 4909
	private IGameMode currentGameMode;
}
