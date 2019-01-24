using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x02000190 RID: 400
internal class PlayerStatsPageGUI : PageGUI
{
	// Token: 0x06000AF2 RID: 2802 RVA: 0x00008C7F File Offset: 0x00006E7F
	private void Awake()
	{
		this._playerDetailGui = new ValuablePlayerDetailGUI();
		this._playerListGui = new ValuablePlayerListGUI();
		this._playerListGui.OnSelectionChange = new Action<StatsSummary>(this.OnValuablePlayerListSelectionChange);
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x00046804 File Offset: 0x00044A04
	public override void DrawGUI(Rect rect)
	{
		float height = Mathf.Min(this._playerListGui.Height, rect.height - 402f) - 2f;
		float num = Mathf.Min(this._playerListGui.Height, rect.height - 402f);
		GUI.BeginGroup(rect, GUIContent.none, BlueStonez.window_standard_grey38);
		this._playerListGui.Draw(new Rect(2f, 2f, rect.width - 4f, height));
		this._playerDetailGui.Draw(new Rect(2f, num + 2f, 200f, 200f));
		this.DrawStats(new Rect(202f, num + 2f, rect.width - 200f - 4f, 200f));
		this.DrawRewards(new Rect(2f, num + 202f, rect.width - 4f, 200f));
		GUI.EndGroup();
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x00046910 File Offset: 0x00044B10
	private void DrawStats(Rect rect)
	{
		GUI.Button(new Rect(rect.x, rect.y, rect.width, 40f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect(rect.x + 10f, rect.y + 2f, rect.width, 40f), "MY STATUS", BlueStonez.label_interparkbold_18pt_left);
		float width = rect.width;
		float num = 32f;
		GUI.BeginGroup(new Rect(rect.x, rect.y + 40f, rect.width, rect.height - 40f), GUIContent.none, BlueStonez.window);
		GUI.Label(new Rect(5f, num * 0f, width + 1f, num), new GUIContent(LocalizedStrings.PlayTime, UberstrikeIcons.Time20x20), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, num * 0f, width - 5f, num), GameState.Current.Statistics.PlayTime, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, num * 1f, width + 1f, num), new GUIContent(LocalizedStrings.Kills, ShopIcons.Stats1Kills20x20), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, num * 1f, width - 5f, num), GameState.Current.Statistics.Kills, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, num * 2f, width + 1f, num), new GUIContent(LocalizedStrings.Headshot, ShopIcons.Stats3Headshots20x20), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, num * 2f, width - 5f, num), GameState.Current.Statistics.Headshots, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, num * 3f, width + 1f, num), new GUIContent(LocalizedStrings.Nutshot, ShopIcons.Stats4Nutshots20x20), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, num * 3f, width - 5f, num), GameState.Current.Statistics.Nutshots, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, num * 4f, width + 1f, num), new GUIContent(LocalizedStrings.Smackdown, ShopIcons.Stats2Smackdowns20x20), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, num * 4f, width - 5f, num), GameState.Current.Statistics.Smackdowns, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, num * 5f, width + 1f, num), new GUIContent(LocalizedStrings.DeathsCaps, ShopIcons.Stats6Deaths20x20), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, num * 5f, width - 5f, num), GameState.Current.Statistics.Deaths, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, num * 6f, width + 1f, num), new GUIContent(LocalizedStrings.KDR, ShopIcons.Stats7Kdr20x20), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, num * 6f, width - 5f, num), GameState.Current.Statistics.KDR, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, num * 7f, width + 1f, num), new GUIContent(LocalizedStrings.SuicideXP, ShopIcons.Stats8Suicides20x20), BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, num * 7f, width - 5f, num), GameState.Current.Statistics.Suicides, BlueStonez.label_interparkbold_18pt_right);
		GUI.EndGroup();
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x00046CF8 File Offset: 0x00044EF8
	private void DrawRewards(Rect rect)
	{
		GUI.Button(new Rect(rect.x, rect.y, rect.width, 40f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect(rect.x + 10f, rect.y + 2f, rect.width, 40f), "MY REWARDS", BlueStonez.label_interparkbold_18pt_left);
		float height = rect.height - 40f;
		GUI.BeginGroup(new Rect(rect.x, rect.y + 40f, rect.width, height), GUIContent.none, BlueStonez.window);
		GUI.Label(new Rect(5f, 0f, rect.width, 32f), LocalizedStrings.PlayTime, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, 0f, rect.width - 100f, 32f), new GUIContent(GameState.Current.Statistics.PlayTimeXp, UberstrikeIcons.IconXP20x20), BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(0f, 0f, rect.width, 32f), new GUIContent(GameState.Current.Statistics.PlayTimePts, ShopIcons.IconPoints20x20), BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, 32f, rect.width, 32f), LocalizedStrings.SkillBonus, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, 32f, rect.width - 100f, 32f), new GUIContent(GameState.Current.Statistics.SkillBonusXp, UberstrikeIcons.IconXP20x20), BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(0f, 32f, rect.width, 32f), new GUIContent(GameState.Current.Statistics.SkillBonusPts, ShopIcons.IconPoints20x20), BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, 64f, rect.width, 32f), LocalizedStrings.Boost, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, 64f, rect.width - 100f, 32f), new GUIContent(GameState.Current.Statistics.BoostXp, UberstrikeIcons.IconXP20x20), BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(0f, 64f, rect.width, 32f), new GUIContent(GameState.Current.Statistics.BoostPts, ShopIcons.IconPoints20x20), BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(5f, 96f, rect.width, 32f), LocalizedStrings.TOTAL, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, 96f, rect.width - 100f, 32f), new GUIContent(GameState.Current.Statistics.TotalXp, UberstrikeIcons.IconXP20x20), BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect(0f, 96f, rect.width, 32f), new GUIContent(GameState.Current.Statistics.TotalPts, ShopIcons.IconPoints20x20), BlueStonez.label_interparkbold_18pt_right);
		GUI.EndGroup();
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x00008CAE File Offset: 0x00006EAE
	private void OnValuablePlayerListSelectionChange(StatsSummary playerStats)
	{
		this._playerDetailGui.SetValuablePlayer(playerStats);
	}

	// Token: 0x06000AF7 RID: 2807 RVA: 0x00047064 File Offset: 0x00045264
	private void OnEnable()
	{
		if (GameState.Current.Statistics.Data.MostValuablePlayers != null && GameState.Current.Statistics.Data.MostValuablePlayers.Count > 0)
		{
			this._playerListGui.SetSelection(0);
		}
		else
		{
			this._playerDetailGui.SetValuablePlayer(null);
		}
		this._playerListGui.Enabled = true;
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x00008CBC File Offset: 0x00006EBC
	private void OnDisabled()
	{
		this._playerListGui.Enabled = false;
		this._playerListGui.ClearSelection();
		this._playerDetailGui.StopBadgeShow();
	}

	// Token: 0x04000A85 RID: 2693
	private ValuablePlayerListGUI _playerListGui;

	// Token: 0x04000A86 RID: 2694
	private ValuablePlayerDetailGUI _playerDetailGui;
}
