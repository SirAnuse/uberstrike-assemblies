using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x020001C2 RID: 450
public class TrainingPageGUI : MonoBehaviour
{
	// Token: 0x06000C6F RID: 3183 RVA: 0x00053AB8 File Offset: 0x00051CB8
	private void OnGUI()
	{
		GUI.depth = 11;
		GUI.skin = BlueStonez.Skin;
		GUI.BeginGroup(new Rect((float)(Screen.width - 700) * 0.5f, (float)(Screen.height - GlobalUIRibbon.Instance.Height() - 480) * 0.5f, 700f, 480f), string.Empty, BlueStonez.window);
		GUI.Label(new Rect(10f, 20f, 670f, 48f), LocalizedStrings.ExploreMaps, BlueStonez.label_interparkbold_48pt);
		GUI.Label(new Rect(30f, 50f, 640f, 120f), LocalizedStrings.TrainingModeDesc, BlueStonez.label_interparkbold_13pt);
		GUI.Box(new Rect(12f, 160f, 670f, 20f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect(16f, 160f, 120f, 20f), LocalizedStrings.ChooseAMap, BlueStonez.label_interparkbold_18pt_left);
		int num = 280;
		GUI.Box(new Rect(12f, 179f, 670f, (float)num), string.Empty, BlueStonez.window);
		int num2 = 0;
		if (Singleton<MapManager>.Instance.Count > 0)
		{
			num2 = (Singleton<MapManager>.Instance.Count - 1) / 4 + 1;
		}
		this._mapScroll = GUITools.BeginScrollView(new Rect(0f, 179f, 682f, (float)num), this._mapScroll, new Rect(0f, 0f, 655f, (float)(10 + 80 * num2)), false, false, true);
		Vector2 v = new Vector2(163f, 80f);
		int num3 = 0;
		foreach (UberstrikeMap uberstrikeMap in Singleton<MapManager>.Instance.AllMaps)
		{
			if (uberstrikeMap.IsVisible)
			{
				Color white = Color.white;
				int num4 = num3 / 4;
				int num5 = num3 % 4;
				Rect rect = new Rect(13f + (float)num5 * v.Width(), (float)num4 * v.y + 4f, v.x, v.y);
				if (GUI.Button(rect, string.Empty, BlueStonez.gray_background) && !GUITools.IsScrolling && !Singleton<SceneLoader>.Instance.IsLoading && uberstrikeMap != null)
				{
					Singleton<MapManager>.Instance.LoadMap(uberstrikeMap, delegate
					{
						Singleton<GameStateController>.Instance.SetGameMode(new TrainingRoom());
						GameState.Current.Actions.JoinTeam(TeamID.NONE);
					});
				}
				GUI.BeginGroup(rect);
				uberstrikeMap.Icon.Draw(rect.CenterHorizontally(2f, 100f, 64f), false);
				Vector2 vector = BlueStonez.label_interparkbold_11pt.CalcSize(new GUIContent(uberstrikeMap.Name));
				GUI.contentColor = white;
				GUI.Label(rect.CenterHorizontally(rect.height - vector.y, vector.x, vector.y), uberstrikeMap.Name, BlueStonez.label_interparkbold_11pt);
				GUI.contentColor = Color.white;
				GUI.EndGroup();
				num3++;
			}
		}
		GUITools.EndScrollView();
		GUI.EndGroup();
		GUI.enabled = true;
	}

	// Token: 0x04000BC3 RID: 3011
	private const int PageWidth = 700;

	// Token: 0x04000BC4 RID: 3012
	private const int PageHeight = 480;

	// Token: 0x04000BC5 RID: 3013
	private const int MapsPerRow = 4;

	// Token: 0x04000BC6 RID: 3014
	private Vector2 _mapScroll;
}
