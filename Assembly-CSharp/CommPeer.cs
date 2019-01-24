using System;
using ExitGames.Client.Photon;
using UberStrike.Core.Models;
using UberStrike.Core.ViewModel;
using UberStrike.Realtime.Client;
using UnityEngine;

// Token: 0x02000378 RID: 888
public class CommPeer : BaseCommPeer
{
	// Token: 0x0600191A RID: 6426 RVA: 0x00010BBF File Offset: 0x0000EDBF
	public CommPeer() : base(100, Application.isEditor)
	{
		this.Lobby = new LobbyRoom();
		base.AddRoomLogic(this.Lobby, this.Lobby.Operations);
	}

	// Token: 0x170005BF RID: 1471
	// (get) Token: 0x0600191B RID: 6427 RVA: 0x00010BF0 File Offset: 0x0000EDF0
	// (set) Token: 0x0600191C RID: 6428 RVA: 0x00010BF8 File Offset: 0x0000EDF8
	public LobbyRoom Lobby { get; private set; }

	// Token: 0x0600191D RID: 6429 RVA: 0x00010C01 File Offset: 0x0000EE01
	protected override void OnConnected()
	{
		if (PlayerDataManager.IsPlayerLoggedIn)
		{
			base.Operations.SendAuthenticationRequest(PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
			Singleton<ChatManager>.Instance.UpdateFriendSection();
		}
	}

	// Token: 0x0600191E RID: 6430 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnDisconnected(StatusCode status)
	{
	}

	// Token: 0x0600191F RID: 6431 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnError(string message)
	{
	}

	// Token: 0x06001920 RID: 6432 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnLoadData(ServerConnectionView data)
	{
	}

	// Token: 0x06001921 RID: 6433 RVA: 0x000867A4 File Offset: 0x000849A4
	protected override void OnLobbyEntered()
	{
		this.Lobby.SendContactList();
		if (GameState.Current.RoomData != null && GameState.Current.RoomData.Server != null)
		{
			this.Lobby.UpdatePlayerRoom(new GameRoom
			{
				Server = new ConnectionAddress(GameState.Current.RoomData.Server.ConnectionString),
				Number = GameState.Current.RoomData.Number,
				MapId = GameState.Current.RoomData.MapID
			});
		}
	}

	// Token: 0x06001922 RID: 6434 RVA: 0x00010C2C File Offset: 0x0000EE2C
	protected override void OnDisconnectAndDisablePhoton(string message)
	{
		AutoMonoBehaviour<CommConnectionManager>.Instance.DisableNetworkConnection(message);
	}

	// Token: 0x06001923 RID: 6435 RVA: 0x0008683C File Offset: 0x00084A3C
	protected override void OnHeartbeatChallenge(string challengeHash)
	{
		string responseHash = Heartbeat.Instance.CheckHeartbeat(challengeHash);
		base.Operations.SendSendHeartbeatResponse(PlayerDataManager.AuthToken, responseHash);
	}
}
