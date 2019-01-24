using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020000E5 RID: 229
public class DebugSpawnPoints : IDebugPage
{
	// Token: 0x17000247 RID: 583
	// (get) Token: 0x060007D5 RID: 2005 RVA: 0x00006F6B File Offset: 0x0000516B
	public string Title
	{
		get
		{
			return "Spawn";
		}
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x0003602C File Offset: 0x0003422C
	public void Draw()
	{
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		foreach (object obj in Enum.GetValues(typeof(GameModeType)))
		{
			GameModeType gameModeType = (GameModeType)((int)obj);
			if (GUILayout.Button(gameModeType.ToString(), new GUILayoutOption[0]))
			{
				this.gameMode = gameModeType;
			}
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.scroll1 = GUILayout.BeginScrollView(this.scroll1, new GUILayoutOption[0]);
		GUILayout.Label(TeamID.NONE.ToString(), new GUILayoutOption[0]);
		for (int i = 0; i < Singleton<SpawnPointManager>.Instance.GetSpawnPointCount(this.gameMode, TeamID.NONE); i++)
		{
			Vector3 vector;
			Quaternion quaternion;
			Singleton<SpawnPointManager>.Instance.GetSpawnPointAt(i, this.gameMode, TeamID.NONE, out vector, out quaternion);
			GUILayout.Label(i + ": " + vector, new GUILayoutOption[0]);
		}
		GUILayout.EndScrollView();
		this.scroll2 = GUILayout.BeginScrollView(this.scroll2, new GUILayoutOption[0]);
		GUILayout.Label(TeamID.BLUE.ToString(), new GUILayoutOption[0]);
		for (int j = 0; j < Singleton<SpawnPointManager>.Instance.GetSpawnPointCount(this.gameMode, TeamID.BLUE); j++)
		{
			Vector3 vector;
			Quaternion quaternion;
			Singleton<SpawnPointManager>.Instance.GetSpawnPointAt(j, this.gameMode, TeamID.BLUE, out vector, out quaternion);
			GUILayout.Label(j + ": " + vector, new GUILayoutOption[0]);
		}
		GUILayout.EndScrollView();
		this.scroll3 = GUILayout.BeginScrollView(this.scroll3, new GUILayoutOption[0]);
		GUILayout.Label(TeamID.RED.ToString(), new GUILayoutOption[0]);
		for (int k = 0; k < Singleton<SpawnPointManager>.Instance.GetSpawnPointCount(this.gameMode, TeamID.RED); k++)
		{
			Vector3 vector;
			Quaternion quaternion;
			Singleton<SpawnPointManager>.Instance.GetSpawnPointAt(k, this.gameMode, TeamID.RED, out vector, out quaternion);
			GUILayout.Label(k + ": " + vector, new GUILayoutOption[0]);
		}
		GUILayout.EndScrollView();
		GUILayout.EndHorizontal();
	}

	// Token: 0x040006B8 RID: 1720
	private Vector2 scroll1;

	// Token: 0x040006B9 RID: 1721
	private Vector2 scroll2;

	// Token: 0x040006BA RID: 1722
	private Vector2 scroll3;

	// Token: 0x040006BB RID: 1723
	private GameModeType gameMode;
}
