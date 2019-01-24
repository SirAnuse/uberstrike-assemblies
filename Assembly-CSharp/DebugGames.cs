using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x020000DA RID: 218
public class DebugGames : IDebugPage
{
	// Token: 0x1700023D RID: 573
	// (get) Token: 0x060007B1 RID: 1969 RVA: 0x00006EC3 File Offset: 0x000050C3
	public string Title
	{
		get
		{
			return "Games";
		}
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x00034F28 File Offset: 0x00033128
	public void Draw()
	{
		if (Singleton<GameStateController>.Instance.Client.IsConnected)
		{
			if (Singleton<GameStateController>.Instance.Client.IsConnectedToLobby)
			{
				this.scroll = GUILayout.BeginScrollView(this.scroll, new GUILayoutOption[0]);
				foreach (GameRoomData gameRoomData in Singleton<GameListManager>.Instance.GameList)
				{
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					GUILayout.Label(string.Concat(new object[]
					{
						"[ID: ",
						gameRoomData.Number,
						"] [Name: ",
						gameRoomData.Name,
						"] [Players: ",
						gameRoomData.ConnectedPlayers,
						"/",
						gameRoomData.PlayerLimit,
						"] [Time: ",
						gameRoomData.TimeLimit,
						"]"
					}), new GUILayoutOption[0]);
					if (GUILayout.Button("Close", new GUILayoutOption[]
					{
						GUILayout.Width(200f)
					}))
					{
						Singleton<GameStateController>.Instance.Client.CloseGame(gameRoomData.Number);
					}
					GUILayout.EndHorizontal();
				}
				GUILayout.EndScrollView();
			}
			else
			{
				GUILayout.FlexibleSpace();
				GUILayout.Label("Reconnect to the game lobby", new GUILayoutOption[0]);
				if (GUILayout.Button(LocalizedStrings.Refresh, BlueStonez.buttondark_medium, new GUILayoutOption[0]))
				{
					Singleton<GameStateController>.Instance.Client.RefreshGameLobby();
				}
				GUILayout.FlexibleSpace();
			}
		}
		else
		{
			GUILayout.FlexibleSpace();
			GUILayout.Label("You're not connected to a game server", new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
		}
	}

	// Token: 0x040006AA RID: 1706
	private Vector2 scroll;
}
