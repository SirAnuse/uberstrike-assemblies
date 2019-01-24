using System;
using UnityEngine;

// Token: 0x020000D8 RID: 216
public class DebugGameServerManager : IDebugPage
{
	// Token: 0x1700023B RID: 571
	// (get) Token: 0x060007AB RID: 1963 RVA: 0x00006EB5 File Offset: 0x000050B5
	public string Title
	{
		get
		{
			return "Requests";
		}
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x00034A5C File Offset: 0x00032C5C
	public void Draw()
	{
		foreach (ServerLoadRequest serverLoadRequest in Singleton<GameServerManager>.Instance.ServerRequests)
		{
			GUILayout.Label(string.Concat(new object[]
			{
				serverLoadRequest.Server.Name,
				" ",
				serverLoadRequest.Server.ConnectionString,
				", Latency: ",
				serverLoadRequest.Server.Latency,
				" - ",
				serverLoadRequest.Server.IsValid
			}), new GUILayoutOption[0]);
			GUILayout.Label(string.Concat(new object[]
			{
				"States: ",
				serverLoadRequest.RequestState,
				" ",
				serverLoadRequest.Server.Data.State,
				", PeerState: ",
				serverLoadRequest.Peer.PeerState
			}), new GUILayoutOption[0]);
			GUILayout.Space(10f);
		}
	}
}
