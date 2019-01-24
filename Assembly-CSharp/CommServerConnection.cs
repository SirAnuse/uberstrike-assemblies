using System;
using UnityEngine;

// Token: 0x02000399 RID: 921
public class CommServerConnection : MonoBehaviour
{
	// Token: 0x06001B44 RID: 6980 RVA: 0x0008C52C File Offset: 0x0008A72C
	private void Start()
	{
		AutoMonoBehaviour<RealtimeUnitTest>.Instance.Add(AutoMonoBehaviour<CommConnectionManager>.Instance.Client);
		AutoMonoBehaviour<RealtimeUnitTest>.Instance.Add(AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Operations);
		AutoMonoBehaviour<RealtimeUnitTest>.Instance.Add(AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby);
		AutoMonoBehaviour<RealtimeUnitTest>.Instance.Add(AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations);
	}

	// Token: 0x06001B45 RID: 6981 RVA: 0x0008C5A0 File Offset: 0x0008A7A0
	private void OnGUI()
	{
		CommPeer client = AutoMonoBehaviour<CommConnectionManager>.Instance.Client;
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
	}

	// Token: 0x0400184C RID: 6220
	public string connectionString = "192.168.0.116:5055";
}
