using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x0200039A RID: 922
public class GameServerConnection : MonoBehaviour
{
	// Token: 0x06001B47 RID: 6983 RVA: 0x00012121 File Offset: 0x00010321
	private void Start()
	{
		AutoMonoBehaviour<RealtimeUnitTest>.Instance.Add(Singleton<GameStateController>.Instance.Client);
		AutoMonoBehaviour<RealtimeUnitTest>.Instance.Add(Singleton<GameStateController>.Instance.Client.Operations);
	}

	// Token: 0x06001B48 RID: 6984 RVA: 0x0008C650 File Offset: 0x0008A850
	private void OnGUI()
	{
		GamePeer client = Singleton<GameStateController>.Instance.Client;
		if (GUI.Button(new Rect(100f, 10f, 200f, 20f), (!client.IsConnected) ? "Connect" : "Disconnect"))
		{
			if (client.IsConnected)
			{
				client.Disconnect();
			}
			else
			{
				client.Connect(this.connectionString);
			}
		}
		GUI.Label(new Rect(100f, 30f, 200f, 20f), "Status: " + client.Peer.PeerState);
		if (client.IsConnected)
		{
			if (GUI.Button(new Rect(100f, 60f, 200f, 20f), "Enter"))
			{
				client.Operations.SendCreateRoom(new GameRoomData
				{
					GameMode = GameModeType.DeathMatch,
					TimeLimit = 10,
					PlayerLimit = 10,
					KillLimit = 10
				}, string.Empty, "4.7.1", PlayerDataManager.AuthToken, PlayerDataManager.MagicHash);
			}
			if (GUI.Button(new Rect(100f, 80f, 200f, 20f), "Leave"))
			{
				client.Operations.SendLeaveRoom();
			}
		}
	}

	// Token: 0x0400184D RID: 6221
	public string connectionString = "192.168.0.116:5155";
}
