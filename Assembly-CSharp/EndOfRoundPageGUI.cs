using System;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x0200018F RID: 399
public class EndOfRoundPageGUI : PageGUI
{
	// Token: 0x06000AEA RID: 2794 RVA: 0x00046644 File Offset: 0x00044844
	public override void DrawGUI(Rect rect)
	{
		float height = Mathf.Min(this._playerListGui.Height, rect.height - 265f) - 2f;
		float num = Mathf.Min(this._playerListGui.Height, rect.height - 265f);
		GUI.BeginGroup(rect, GUIContent.none, BlueStonez.window_standard_grey38);
		this._playerListGui.Draw(new Rect(2f, 2f, rect.width - 4f, height));
		this.DrawDetails(new Rect(2f, 2f + num, rect.width - 4f, 265f));
		GUI.EndGroup();
	}

	// Token: 0x06000AEB RID: 2795 RVA: 0x00008C06 File Offset: 0x00006E06
	private void Awake()
	{
		this._playerListGui = new ValuablePlayerListGUI();
		this._playerDetailGui = new ValuablePlayerDetailGUI();
		this._playerListGui.OnSelectionChange = new Action<StatsSummary>(this.OnValuablePlayerListSelectionChange);
	}

	// Token: 0x06000AEC RID: 2796 RVA: 0x000466FC File Offset: 0x000448FC
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

	// Token: 0x06000AED RID: 2797 RVA: 0x00008C35 File Offset: 0x00006E35
	private void OnDisabled()
	{
		this._playerListGui.Enabled = false;
		this._playerListGui.ClearSelection();
		this._playerDetailGui.StopBadgeShow();
	}

	// Token: 0x06000AEE RID: 2798 RVA: 0x0004676C File Offset: 0x0004496C
	private void DrawDetails(Rect rect)
	{
		GUI.BeginGroup(rect);
		GUI.Label(new Rect(0f, 2f, rect.width, 20f), LocalizedStrings.RecommendedLoadoutCaps, BlueStonez.label_interparkbold_18pt);
		rect = new Rect(0f, 25f, rect.width, rect.height - 25f);
		GUI.BeginGroup(rect);
		this._playerDetailGui.Draw(new Rect(0f, 0f, 200f, rect.height));
		GUI.EndGroup();
		GUI.EndGroup();
	}

	// Token: 0x06000AEF RID: 2799 RVA: 0x00008C59 File Offset: 0x00006E59
	private void OnRecomListSelectionChange(IUnityItem item, RecommendType type)
	{
		this._playerListGui.ClearSelection();
		this._playerDetailGui.StopBadgeShow();
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x00008C71 File Offset: 0x00006E71
	private void OnValuablePlayerListSelectionChange(StatsSummary playerStats)
	{
		this._playerDetailGui.SetValuablePlayer(playerStats);
	}

	// Token: 0x04000A82 RID: 2690
	private const float WeaponRecommendHeight = 265f;

	// Token: 0x04000A83 RID: 2691
	private ValuablePlayerDetailGUI _playerDetailGui;

	// Token: 0x04000A84 RID: 2692
	private ValuablePlayerListGUI _playerListGui;
}
