using System;
using UnityEngine;

// Token: 0x020000E1 RID: 225
public class DebugPlayersInGame : IDebugPage
{
	// Token: 0x17000243 RID: 579
	// (get) Token: 0x060007C9 RID: 1993 RVA: 0x00006F3C File Offset: 0x0000513C
	public string Title
	{
		get
		{
			return "Players";
		}
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x0003591C File Offset: 0x00033B1C
	public void Draw()
	{
		if (Singleton<GameStateController>.Instance.Client.IsConnected)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Get Players of Game: ", new GUILayoutOption[]
			{
				GUILayout.Width(150f)
			});
			this.gameIdString = GUILayout.TextField(this.gameIdString, new GUILayoutOption[]
			{
				GUILayout.Width(50f)
			});
			if (!int.TryParse(this.gameIdString, out this.gameId))
			{
				this.gameIdString = "0";
			}
			GUI.enabled = (this.gameId > 0);
			GUILayout.Space(10f);
			if (GUILayout.Button("Inspect", new GUILayoutOption[]
			{
				GUILayout.Width(100f)
			}))
			{
				Singleton<GameStateController>.Instance.Client.InspectGame(this.gameId);
			}
			GUILayout.EndHorizontal();
		}
		else
		{
			GUILayout.Label("You're not connected to the game lobby", new GUILayoutOption[0]);
		}
	}

	// Token: 0x040006B0 RID: 1712
	private Vector2 scroll;

	// Token: 0x040006B1 RID: 1713
	private string gameIdString = "0";

	// Token: 0x040006B2 RID: 1714
	private int gameId;
}
