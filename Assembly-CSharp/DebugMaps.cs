using System;
using UnityEngine;

// Token: 0x020000DF RID: 223
public class DebugMaps : IDebugPage
{
	// Token: 0x17000241 RID: 577
	// (get) Token: 0x060007C3 RID: 1987 RVA: 0x00006F35 File Offset: 0x00005135
	public string Title
	{
		get
		{
			return "Maps";
		}
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x000355A0 File Offset: 0x000337A0
	public void Draw()
	{
		this.scroll = GUILayout.BeginScrollView(this.scroll, new GUILayoutOption[0]);
		foreach (UberstrikeMap uberstrikeMap in Singleton<MapManager>.Instance.AllMaps)
		{
			GUILayout.Label(string.Concat(new object[]
			{
				uberstrikeMap.Id,
				", Modes: ",
				uberstrikeMap.View.SupportedGameModes,
				", Item: ",
				uberstrikeMap.View.RecommendedItemId,
				", Scene: ",
				uberstrikeMap.SceneName
			}), new GUILayoutOption[0]);
		}
		GUILayout.EndScrollView();
	}

	// Token: 0x040006AE RID: 1710
	private Vector2 scroll;
}
