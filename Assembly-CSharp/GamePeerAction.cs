using System;
using System.Collections.Generic;
using Cmune.Core.Models;
using ExitGames.Client.Photon;
using UberStrike.Core.Models;
using UberStrike.Realtime.Client;

// Token: 0x02000388 RID: 904
public class GamePeerAction : BaseGamePeer
{
	// Token: 0x06001A43 RID: 6723 RVA: 0x000116DF File Offset: 0x0000F8DF
	private GamePeerAction() : base(100, false)
	{
	}

	// Token: 0x06001A44 RID: 6724 RVA: 0x0008A2FC File Offset: 0x000884FC
	public static void KickPlayer(string connection, int cmid)
	{
		GamePeerAction peer = new GamePeerAction();
		peer.Connect(connection);
		peer._onConnect = delegate()
		{
			peer.Operations.SendKickPlayer(cmid, PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
		};
	}

	// Token: 0x06001A45 RID: 6725 RVA: 0x000116EA File Offset: 0x0000F8EA
	protected override void OnConnected()
	{
		if (this._onConnect != null)
		{
			this._onConnect();
		}
		base.Disconnect();
	}

	// Token: 0x06001A46 RID: 6726 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnHeartbeatChallenge(string challengeHash)
	{
	}

	// Token: 0x06001A47 RID: 6727 RVA: 0x00011708 File Offset: 0x0000F908
	protected override void OnDisconnected(StatusCode status)
	{
		this.Dispose();
	}

	// Token: 0x06001A48 RID: 6728 RVA: 0x00011708 File Offset: 0x0000F908
	protected override void OnConnectionFail(string endpointAddress)
	{
		this.Dispose();
	}

	// Token: 0x06001A49 RID: 6729 RVA: 0x00011708 File Offset: 0x0000F908
	protected override void OnError(string message)
	{
		this.Dispose();
	}

	// Token: 0x06001A4A RID: 6730 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnServerLoadData(PhotonServerLoad data)
	{
	}

	// Token: 0x06001A4B RID: 6731 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnFullGameList(List<GameRoomData> gameList)
	{
	}

	// Token: 0x06001A4C RID: 6732 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnGameListUpdate(List<GameRoomData> updatedGames, List<int> removedGames)
	{
	}

	// Token: 0x06001A4D RID: 6733 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnGameListUpdateEnd()
	{
	}

	// Token: 0x06001A4E RID: 6734 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnGetGameInformation(GameRoomData room, List<GameActorInfo> players, int endTime)
	{
	}

	// Token: 0x06001A4F RID: 6735 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRoomEntered(GameRoomData game)
	{
	}

	// Token: 0x06001A50 RID: 6736 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRoomLeft()
	{
	}

	// Token: 0x06001A51 RID: 6737 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRoomEnterFailed(string server, int roomId, string message)
	{
	}

	// Token: 0x06001A52 RID: 6738 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnRequestPasswordForRoom(string server, int roomId)
	{
	}

	// Token: 0x06001A53 RID: 6739 RVA: 0x00003C87 File Offset: 0x00001E87
	protected override void OnDisconnectAndDisablePhoton(string message)
	{
	}

	// Token: 0x040017C8 RID: 6088
	private Action _onConnect;
}
