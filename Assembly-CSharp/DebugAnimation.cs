using System;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class DebugAnimation : IDebugPage
{
	// Token: 0x17000239 RID: 569
	// (get) Token: 0x060007A5 RID: 1957 RVA: 0x00006EA7 File Offset: 0x000050A7
	public string Title
	{
		get
		{
			return "Animation";
		}
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x000347BC File Offset: 0x000329BC
	public void Draw()
	{
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		foreach (CharacterConfig characterConfig in GameState.Current.Avatars.Values)
		{
			if (GUILayout.Button(characterConfig.name, new GUILayoutOption[0]))
			{
				this.config = characterConfig;
			}
		}
		GUILayout.EndHorizontal();
		if (this.config == null)
		{
			GUILayout.Label("Select a player", new GUILayoutOption[0]);
		}
		else if (this.config.Avatar == null)
		{
			GUILayout.Label("Missing Decorator", new GUILayoutOption[0]);
		}
	}

	// Token: 0x040006A8 RID: 1704
	private CharacterConfig config;
}
