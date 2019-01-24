using System;
using System.Collections.Generic;
using Cmune.Core.Models;
using ExitGames.Client.Photon;
using UberStrike.Core.Models;
using UberStrike.Realtime.Client;
using UnityEngine;

// Token: 0x02000390 RID: 912
public class ServerLoadRequest : BaseGamePeer
{
	// Token: 0x06001AF1 RID: 6897 RVA: 0x00011EC4 File Offset: 0x000100C4
	private ServerLoadRequest(PhotonServer server, Action callback) : base(100, false)
	{
		this._callback = callback;
		this.Server = server;
	}

	// Token: 0x17000604 RID: 1540
	// (get) Token: 0x06001AF2 RID: 6898 RVA: 0x00011EDD File Offset: 0x000100DD
	// (set) Token: 0x06001AF3 RID: 6899 RVA: 0x00011EE5 File Offset: 0x000100E5
	public ServerLoadRequest.RequestStateType RequestState { get; private set; }

	// Token: 0x17000605 RID: 1541
	// (get) Token: 0x06001AF4 RID: 6900 RVA: 0x00011EEE File Offset: 0x000100EE
	// (set) Token: 0x06001AF5 RID: 6901 RVA: 0x00011EF6 File Offset: 0x000100F6
	public PhotonServer Server { get; private set; }

	// Token: 0x06001AF6 RID: 6902 RVA: 0x0008BD84 File Offset: 0x00089F84
	public static ServerLoadRequest Run(PhotonServer server, Action callback)
	{
		ServerLoadRequest serverLoadRequest = new ServerLoadRequest(server, callback);
		serverLoadRequest.Run();
		return serverLoadRequest;
	}

	// Token: 0x06001AF7 RID: 6903 RVA: 0x0008BDA0 File Offset: 0x00089FA0
	public void Run()
	{
		if (base.Peer.PeerState == PeerStateValue.Disconnected)
		{
			this.RequestState = ServerLoadRequest.RequestStateType.Waiting;
			if (this.Server.Data.State == PhotonServerLoad.Status.NotReachable)
			{
				this.Server.Data.State = PhotonServerLoad.Status.None;
			}
			base.Connect(this.Server.ConnectionString);
		}
	}

	// Token: 0x06001AF8 RID: 6904 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnHeartbeatChallenge(string challengeHash)
	{
	}

	// Token: 0x06001AF9 RID: 6905 RVA: 0x00011EFF File Offset: 0x000100FF
	protected override void OnConnectionFail(string endpointAddress)
	{
		Debug.LogError(endpointAddress + " is down");
		this.RequestState = ServerLoadRequest.RequestStateType.Down;
		this.Server.Data.State = PhotonServerLoad.Status.NotReachable;
	}

	// Token: 0x06001AFA RID: 6906 RVA: 0x0008BDFC File Offset: 0x00089FFC
	protected override void OnServerLoadData(PhotonServerLoad data)
	{
		this.Server.Data = data;
		this.Server.Data.PlayersConnected = this.Server.Data.PeersConnected;
		this.Server.Data.Latency = base.Peer.RoundTripTime;
		this.Server.Data.State = PhotonServerLoad.Status.Alive;
		this.RequestState = ServerLoadRequest.RequestStateType.Running;
		base.Disconnect();
	}

	// Token: 0x06001AFB RID: 6907 RVA: 0x00011F29 File Offset: 0x00010129
	protected override void OnConnected()
	{
		base.Operations.SendGetServerLoad();
	}

	// Token: 0x06001AFC RID: 6908 RVA: 0x00011F36 File Offset: 0x00010136
	protected override void OnDisconnected(StatusCode status)
	{
		if (this.RequestState != ServerLoadRequest.RequestStateType.Running)
		{
			this.RequestState = ServerLoadRequest.RequestStateType.Down;
			this.Server.Data.State = PhotonServerLoad.Status.NotReachable;
		}
		this._callback();
	}

	// Token: 0x06001AFD RID: 6909 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnError(string message)
	{
	}

	// Token: 0x06001AFE RID: 6910 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnFullGameList(List<GameRoomData> gameList)
	{
	}

	// Token: 0x06001AFF RID: 6911 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnGameListUpdate(List<GameRoomData> updatedGames, List<int> removedGames)
	{
	}

	// Token: 0x06001B00 RID: 6912 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnGameListUpdateEnd()
	{
	}

	// Token: 0x06001B01 RID: 6913 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnGetGameInformation(GameRoomData room, List<GameActorInfo> players, int endTime)
	{
	}

	// Token: 0x06001B02 RID: 6914 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRoomEntered(GameRoomData game)
	{
	}

	// Token: 0x06001B03 RID: 6915 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRoomLeft()
	{
	}

	// Token: 0x06001B04 RID: 6916 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRoomEnterFailed(string server, int roomId, string message)
	{
	}

	// Token: 0x06001B05 RID: 6917 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRequestPasswordForRoom(string server, int roomId)
	{
	}

	// Token: 0x06001B06 RID: 6918 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnDisconnectAndDisablePhoton(string message)
	{
	}

	// Token: 0x04001825 RID: 6181
	private Action _callback;

	// Token: 0x02000391 RID: 913
	public enum RequestStateType
	{
		// Token: 0x04001829 RID: 6185
		None,
		// Token: 0x0400182A RID: 6186
		Waiting,
		// Token: 0x0400182B RID: 6187
		Running,
		// Token: 0x0400182C RID: 6188
		Down
	}
}
