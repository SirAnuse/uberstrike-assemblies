using System;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020000E3 RID: 227
public class DebugServerState : IDebugPage
{
	// Token: 0x17000245 RID: 581
	// (get) Token: 0x060007CF RID: 1999 RVA: 0x00006F5D File Offset: 0x0000515D
	public string Title
	{
		get
		{
			return "Network";
		}
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x00035B5C File Offset: 0x00033D5C
	public void Draw()
	{
		GUILayout.Space(10f);
		GUILayout.Label(string.Format("GAME: {0}", Singleton<GameStateController>.Instance.Client.Peer.ServerAddress), new GUILayoutOption[0]);
		GUILayout.Label("  PeerState: " + Singleton<GameStateController>.Instance.Client.Peer.PeerState, new GUILayoutOption[0]);
		GUILayout.Label("  InRoom: " + Singleton<GameStateController>.Instance.Client.IsInsideRoom, new GUILayoutOption[0]);
		GUILayout.Label("  Network Time: " + Singleton<GameStateController>.Instance.Client.Peer.ServerTimeInMilliSeconds, new GUILayoutOption[0]);
		GUILayout.Label("  KBytes IN: " + ConvertBytes.ToKiloBytes(Singleton<GameStateController>.Instance.Client.Peer.BytesIn).ToString("f2"), new GUILayoutOption[0]);
		GUILayout.Label("  KBytes OUT: " + ConvertBytes.ToKiloBytes(Singleton<GameStateController>.Instance.Client.Peer.BytesOut).ToString("f2"), new GUILayoutOption[0]);
		GUILayout.Space(10f);
		GUILayout.Label(string.Format("COMM: {0}", AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Peer.ServerAddress), new GUILayoutOption[0]);
		GUILayout.Label("  PeerState: " + AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Peer.PeerState, new GUILayoutOption[0]);
		GUILayout.Label("  Network Time: " + AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Peer.ServerTimeInMilliSeconds, new GUILayoutOption[0]);
		GUILayout.Label("  KBytes IN: " + ConvertBytes.ToKiloBytes(AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Peer.BytesIn).ToString("f2"), new GUILayoutOption[0]);
		GUILayout.Label("  KBytes OUT: " + ConvertBytes.ToKiloBytes(AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Peer.BytesOut).ToString("f2"), new GUILayoutOption[0]);
		GUILayout.Label("ALL SERVERS", new GUILayoutOption[0]);
		foreach (PhotonServer photonServer in Singleton<GameServerManager>.Instance.PhotonServerList)
		{
			GUILayout.Label(string.Concat(new object[]
			{
				"  ",
				photonServer.ConnectionString,
				" ",
				photonServer.Latency
			}), new GUILayoutOption[0]);
		}
	}
}
