using System;
using System.Collections;
using System.Collections.Generic;
using Cmune.Core.Models;
using ExitGames.Client.Photon;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UberStrike.Realtime.Client;
using UnityEngine;

// Token: 0x0200037D RID: 893
public class GamePeer : BaseGamePeer
{
	// Token: 0x06001995 RID: 6549 RVA: 0x00011156 File Offset: 0x0000F356
	public GamePeer() : base(50, Application.isEditor)
	{
		base.Operations.SendGetGameListUpdates();
	}

	// Token: 0x14000012 RID: 18
	// (add) Token: 0x06001996 RID: 6550 RVA: 0x00011170 File Offset: 0x0000F370
	// (remove) Token: 0x06001997 RID: 6551 RVA: 0x00011189 File Offset: 0x0000F389
	public event Action<PhotonServerLoad> OnServerLoad;

	// Token: 0x170005C2 RID: 1474
	// (get) Token: 0x06001998 RID: 6552 RVA: 0x000111A2 File Offset: 0x0000F3A2
	public ushort Ping
	{
		get
		{
			return (ushort)Mathf.Clamp(base.Peer.RoundTripTime / 2, 0, 65535);
		}
	}

	// Token: 0x170005C3 RID: 1475
	// (get) Token: 0x06001999 RID: 6553 RVA: 0x000111BD File Offset: 0x0000F3BD
	// (set) Token: 0x0600199A RID: 6554 RVA: 0x000111C5 File Offset: 0x0000F3C5
	public bool IsConnectedToLobby { get; private set; }

	// Token: 0x170005C4 RID: 1476
	// (get) Token: 0x0600199B RID: 6555 RVA: 0x000111CE File Offset: 0x0000F3CE
	public bool IsInsideRoom
	{
		get
		{
			return base.IsConnected && this.lastRoomJoined != 0;
		}
	}

	// Token: 0x0600199C RID: 6556 RVA: 0x000111EA File Offset: 0x0000F3EA
	protected override void OnConnected()
	{
		Debug.Log("OnConnected");
		if (this.onConnectAction != null)
		{
			this.onConnectAction();
			this.onConnectAction = null;
		}
	}

	// Token: 0x0600199D RID: 6557 RVA: 0x00088154 File Offset: 0x00086354
	protected override void OnHeartbeatChallenge(string challengeHash)
	{
		string responseHash = Heartbeat.Instance.CheckHeartbeat(challengeHash);
		base.Operations.SendSendHeartbeatResponse(PlayerDataManager.AuthToken, responseHash);
	}

	// Token: 0x0600199E RID: 6558 RVA: 0x00088180 File Offset: 0x00086380
	protected override void OnDisconnected(StatusCode status)
	{
		Debug.LogWarning("#### OnDisconnected");
		this.OnRoomLeft();
		this.onConnectAction = null;
		if (base.IsEnabled && this.lastRoomJoined != 0)
		{
			PopupSystem.ClearAll();
			PopupSystem.ShowMessage("Server Disconnection", "You were disconnected from the game.\n Do you want to try to reconnect?", PopupSystem.AlertType.OKCancel, delegate()
			{
				this.ReconnectToCurrentGame();
			}, delegate()
			{
				this.lastRoomJoined = 0;
				Singleton<GameStateController>.Instance.LeaveGame(false);
			});
		}
	}

	// Token: 0x0600199F RID: 6559 RVA: 0x000881E8 File Offset: 0x000863E8
	protected override void OnError(string message)
	{
		Singleton<GameStateController>.Instance.UnloadGameMode();
		if (Singleton<SceneLoader>.Instance.CurrentScene != "Menu")
		{
			Singleton<SceneLoader>.Instance.LoadLevel("Menu", null);
		}
		PopupSystem.ClearAll();
		PopupSystem.ShowMessage("Server Disconnection", message, PopupSystem.AlertType.OK);
	}

	// Token: 0x060019A0 RID: 6560 RVA: 0x00011213 File Offset: 0x0000F413
	protected override void OnFullGameList(List<GameRoomData> gameList)
	{
		this.IsConnectedToLobby = true;
		Singleton<GameListManager>.Instance.SetGameList(gameList);
		if (PlayPageGUI.Instance)
		{
			PlayPageGUI.Instance.RefreshGameList();
		}
	}

	// Token: 0x060019A1 RID: 6561 RVA: 0x0008823C File Offset: 0x0008643C
	protected override void OnGameListUpdate(List<GameRoomData> updatedGames, List<int> removedGames)
	{
		this.IsConnectedToLobby = true;
		foreach (GameRoomData game in updatedGames)
		{
			Singleton<GameListManager>.Instance.AddGame(game);
		}
		foreach (int id in removedGames)
		{
			Singleton<GameListManager>.Instance.RemoveGame(id);
		}
		if (PlayPageGUI.Instance)
		{
			PlayPageGUI.Instance.RefreshGameList();
		}
	}

	// Token: 0x060019A2 RID: 6562 RVA: 0x00011240 File Offset: 0x0000F440
	protected override void OnGameListUpdateEnd()
	{
		this.IsConnectedToLobby = false;
		Singleton<GameListManager>.Instance.Clear();
		if (PlayPageGUI.Instance)
		{
			PlayPageGUI.Instance.RefreshGameList();
		}
	}

	// Token: 0x060019A3 RID: 6563 RVA: 0x00088300 File Offset: 0x00086500
	protected override void OnRequestPasswordForRoom(string server, int roomId)
	{
		PopupSystem.ClearAll();
		PopupSystem.Show(new PasswordPopupDialog("Secured Area", "Please enter the password below:", delegate(string password)
		{
			this.JoinGame(server, roomId, password);
		}, delegate()
		{
			Singleton<GameStateController>.Instance.LeaveGame(false);
		}));
	}

	// Token: 0x060019A4 RID: 6564 RVA: 0x0001126C File Offset: 0x0000F46C
	protected override void OnRoomEnterFailed(string server, int roomId, string message)
	{
		PopupSystem.ClearAll();
		PopupSystem.ShowMessage("Failed to join game", message, PopupSystem.AlertType.OK, delegate()
		{
			Singleton<GameStateController>.Instance.LeaveGame(false);
		});
	}

	// Token: 0x060019A5 RID: 6565 RVA: 0x0008836C File Offset: 0x0008656C
	protected override void OnRoomEntered(GameRoomData data)
	{
		Debug.Log("OnRoomJoined " + this.lastRoomJoined);
		GameState.Current.Reset();
		PopupSystem.ClearAll();
		this.lastRoomJoined = data.Number;
		GameState.Current.ResetRoundStartTime();
		base.Peer.FetchServerTimestamp();
		switch (data.GameMode)
		{
		case GameModeType.DeathMatch:
		{
			DeathMatchRoom gameMode = new DeathMatchRoom(data, this);
			Singleton<GameStateController>.Instance.SetGameMode(gameMode);
			this.currentRoom = gameMode;
			break;
		}
		case GameModeType.TeamDeathMatch:
		{
			TeamDeathMatchRoom gameMode2 = new TeamDeathMatchRoom(data, this);
			Singleton<GameStateController>.Instance.SetGameMode(gameMode2);
			this.currentRoom = gameMode2;
			break;
		}
		case GameModeType.EliminationMode:
		{
			TeamEliminationRoom gameMode3 = new TeamEliminationRoom(data, this);
			Singleton<GameStateController>.Instance.SetGameMode(gameMode3);
			this.currentRoom = gameMode3;
			break;
		}
		default:
			throw new NotImplementedException("GameMode not supported: " + data.GameMode);
		}
		base.AddRoomLogic(this.currentRoom, this.currentRoom.Operations);
		UberstrikeMap mapWithId = Singleton<MapManager>.Instance.GetMapWithId(data.MapID);
		if (mapWithId != null)
		{
			Singleton<MapManager>.Instance.LoadMap(mapWithId, delegate
			{
				GameStateHelper.EnterGameMode();
				GameState.Current.MatchState.SetState(GameStateId.PregameLoadout);
				foreach (GameActorInfo gameActorInfo in GameState.Current.Players.Values)
				{
					if (!gameActorInfo.IsSpectator)
					{
						GameState.Current.InstantiateAvatar(gameActorInfo);
					}
				}
				this.currentRoom.Operations.SendPowerUpRespawnTimes(PickupItem.GetRespawnDurations());
				List<Vector3> positions;
				List<byte> rotations;
				Singleton<SpawnPointManager>.Instance.GetAllSpawnPoints(data.GameMode, TeamID.NONE, out positions, out rotations);
				this.currentRoom.Operations.SendSpawnPositions(TeamID.NONE, positions, rotations);
				Singleton<SpawnPointManager>.Instance.GetAllSpawnPoints(data.GameMode, TeamID.RED, out positions, out rotations);
				this.currentRoom.Operations.SendSpawnPositions(TeamID.RED, positions, rotations);
				Singleton<SpawnPointManager>.Instance.GetAllSpawnPoints(data.GameMode, TeamID.BLUE, out positions, out rotations);
				this.currentRoom.Operations.SendSpawnPositions(TeamID.BLUE, positions, rotations);
				global::AvatarBuilder.UpdateLocalAvatar(Singleton<LoadoutManager>.Instance.Loadout.GetAvatarGear());
				GameState.Current.RoomData = data;
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdatePlayerRoom(new GameRoom
				{
					Server = new ConnectionAddress(data.Server.ConnectionString),
					Number = data.Number,
					MapId = data.MapID
				});
			});
		}
		else
		{
			Debug.LogError("Map not found");
		}
	}

	// Token: 0x060019A6 RID: 6566 RVA: 0x000884F4 File Offset: 0x000866F4
	protected override void OnRoomLeft()
	{
		Debug.Log("OnRoomLeft " + (this.currentRoom != null));
		if (this.currentRoom != null)
		{
			base.RemoveRoomLogic(this.currentRoom, this.currentRoom.Operations);
			this.currentRoom = null;
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendResetPlayerRoom();
		}
	}

	// Token: 0x060019A7 RID: 6567 RVA: 0x0001129C File Offset: 0x0000F49C
	protected override void OnServerLoadData(PhotonServerLoad data)
	{
		if (this.OnServerLoad != null)
		{
			this.OnServerLoad(data);
		}
	}

	// Token: 0x060019A8 RID: 6568 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnGetGameInformation(GameRoomData room, List<GameActorInfo> players, int endTime)
	{
	}

	// Token: 0x060019A9 RID: 6569 RVA: 0x00010C2C File Offset: 0x0000EE2C
	protected override void OnDisconnectAndDisablePhoton(string message)
	{
		AutoMonoBehaviour<CommConnectionManager>.Instance.DisableNetworkConnection(message);
	}

	// Token: 0x060019AA RID: 6570 RVA: 0x000112B5 File Offset: 0x0000F4B5
	public new void Disconnect()
	{
		Debug.Log("Disconnect");
		if (base.IsConnected)
		{
			this.lastRoomJoined = 0;
			base.Disconnect();
		}
	}

	// Token: 0x060019AB RID: 6571 RVA: 0x000112D9 File Offset: 0x0000F4D9
	internal void CloseGame(int gameId)
	{
		if (base.IsConnected)
		{
			base.Operations.SendCloseRoom(gameId, PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
		}
		else
		{
			Debug.Log("You are currently not connected to the game server");
		}
	}

	// Token: 0x060019AC RID: 6572 RVA: 0x0001130B File Offset: 0x0000F50B
	internal void InspectGame(int gameId)
	{
		Debug.Log("InspectGame operation is not implemented");
	}

	// Token: 0x060019AD RID: 6573 RVA: 0x00088564 File Offset: 0x00086764
	public void CreateGame(GameRoomData data, string password)
	{
		if (base.IsConnected)
		{
			base.Operations.SendCreateRoom(data, password, "4.7.1", PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
		}
		else
		{
			this.onConnectAction = delegate()
			{
				this.Operations.SendCreateRoom(data, password, "4.7.1", PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
			};
			base.Connect(data.Server.ConnectionString);
		}
	}

	// Token: 0x060019AE RID: 6574 RVA: 0x000885EC File Offset: 0x000867EC
	public void JoinGame(string server, int roomId, string password = "")
	{
		Debug.Log(string.Concat(new object[]
		{
			"JoinGame ",
			server,
			":",
			roomId,
			"[current:",
			base.Peer.ServerAddress,
			"]"
		}));
		if (base.IsConnected)
		{
			base.Operations.SendEnterRoom(roomId, password, "4.7.1", PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
		}
		else
		{
			this.onConnectAction = delegate()
			{
				this.Operations.SendEnterRoom(roomId, password, "4.7.1", PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
			};
			base.Connect(server);
		}
	}

	// Token: 0x060019AF RID: 6575 RVA: 0x00011317 File Offset: 0x0000F517
	public void LeaveGame()
	{
		base.Operations.SendLeaveRoom();
		this.OnRoomLeft();
	}

	// Token: 0x060019B0 RID: 6576 RVA: 0x0001132A File Offset: 0x0000F52A
	public void RefreshGameLobby()
	{
		if (base.IsConnected)
		{
			base.Operations.SendGetGameListUpdates();
		}
	}

	// Token: 0x060019B1 RID: 6577 RVA: 0x00011342 File Offset: 0x0000F542
	public void EnterGameLobby(string serverAddress)
	{
		this.IsConnectedToLobby = true;
		if (base.IsConnected)
		{
			base.Operations.SendGetGameListUpdates();
		}
		else
		{
			this.onConnectAction = delegate()
			{
				base.Operations.SendGetGameListUpdates();
			};
			base.Connect(serverAddress);
		}
	}

	// Token: 0x060019B2 RID: 6578 RVA: 0x000886B4 File Offset: 0x000868B4
	private void ReconnectToCurrentGame()
	{
		if (this.lastRoomJoined != 0)
		{
			Singleton<GameStateController>.Instance.UnloadGameMode();
			this.JoinGame(base.Peer.ServerAddress, this.lastRoomJoined, string.Empty);
		}
		else
		{
			Singleton<GameStateController>.Instance.LeaveGame(false);
		}
	}

	// Token: 0x060019B3 RID: 6579 RVA: 0x00088704 File Offset: 0x00086904
	private IEnumerator StartReconnectionInSeconds(string server, int roomId, int seconds)
	{
		yield return new WaitForSeconds((float)seconds);
		if (roomId != 0)
		{
			this.JoinGame(server, roomId, string.Empty);
		}
		else
		{
			Debug.LogError("Failed to reconnect because GameRoom is null!");
		}
		yield break;
	}

	// Token: 0x040017A1 RID: 6049
	private Action onConnectAction;

	// Token: 0x040017A2 RID: 6050
	private int lastRoomJoined;

	// Token: 0x040017A3 RID: 6051
	private BaseGameRoom currentRoom;
}
