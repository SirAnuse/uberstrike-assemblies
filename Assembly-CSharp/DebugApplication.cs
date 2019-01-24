using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.DataCenter.UnitySdk;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020000D7 RID: 215
public class DebugApplication : IDebugPage
{
	// Token: 0x1700023A RID: 570
	// (get) Token: 0x060007A8 RID: 1960 RVA: 0x00006EAE File Offset: 0x000050AE
	public string Title
	{
		get
		{
			return "App";
		}
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x0003488C File Offset: 0x00032A8C
	public void Draw()
	{
		GUILayout.Label("Channel: " + ApplicationDataManager.Channel, new GUILayoutOption[0]);
		GUILayout.Label("Version: 4.7.1", new GUILayoutOption[0]);
		GUILayout.Label("Source: " + Application.srcValue, new GUILayoutOption[0]);
		GUILayout.Label("WS API: " + UberStrike.DataCenter.UnitySdk.ApiVersion.Current, new GUILayoutOption[0]);
		GUILayout.Label("RT API: " + UberStrike.Realtime.UnitySdk.ApiVersion.Current, new GUILayoutOption[0]);
		if (PlayerDataManager.AccessLevel > MemberAccessLevel.Default)
		{
			GUILayout.Label("Member Name: " + PlayerDataManager.Name, new GUILayoutOption[0]);
			GUILayout.Label("Member Cmid: " + PlayerDataManager.Cmid, new GUILayoutOption[0]);
			GUILayout.Label("Member Access: " + PlayerDataManager.AccessLevel.ToString(), new GUILayoutOption[0]);
			GUILayout.Label("Member Tag: " + PlayerDataManager.ClanTag, new GUILayoutOption[0]);
			foreach (PhotonServer photonServer in Singleton<GameServerManager>.Instance.PhotonServerList)
			{
				GUILayout.Label(string.Concat(new object[]
				{
					"Game Server: ",
					photonServer.Name,
					" [",
					photonServer.MinLatency,
					"] ",
					photonServer.Data.PeersConnected,
					"/",
					photonServer.Data.PlayersConnected
				}), new GUILayoutOption[0]);
			}
		}
		GUILayout.Space(10f);
	}
}
