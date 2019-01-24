using System;
using UberStrike.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x020001DF RID: 479
internal class DailyPointsPopupDialog : BaseEventPopup
{
	// Token: 0x06000D85 RID: 3461 RVA: 0x0005E75C File Offset: 0x0005C95C
	public DailyPointsPopupDialog(DailyPointsView dailypoints)
	{
		if (dailypoints != null)
		{
			this._points = dailypoints;
		}
		else
		{
			this._points = new DailyPointsView
			{
				Current = 700,
				PointsTomorrow = 800,
				PointsMax = 1000
			};
		}
		this.Width = 500;
		this.Height = 330;
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x0005E7C8 File Offset: 0x0005C9C8
	protected override void DrawGUI(Rect rect)
	{
		GUI.color = ColorScheme.HudTeamBlue;
		GUI.DrawTexture(new Rect(-50f, -20f, rect.width + 100f, 100f), HudTextures.WhiteBlur128);
		GUI.color = Color.white;
		GUITools.OutlineLabel(new Rect(0f, 10f, rect.width, 50f), "Daily Reward", BlueStonez.label_interparkbold_32pt, 1, Color.white, ColorScheme.GuiTeamBlue);
		int num = 230;
		GUI.DrawTexture(new Rect((rect.width - (float)num) / 2f, rect.height - (float)num - 25f, (float)num, (float)num), ShopIcons.Points48x48);
		GUI.color = ColorScheme.HudTeamBlue;
		GUI.DrawTexture(new Rect(-50f, 25f, rect.width + 100f, 120f), HudTextures.WhiteBlur128);
		GUI.color = Color.white;
		GUITools.OutlineLabel(new Rect(0f, 35f, rect.width, 100f), this._points.Current + " POINTS", BlueStonez.label_interparkbold_48pt, 1, Color.white, ColorScheme.GuiTeamBlue);
		GUITools.OutlineLabel(new Rect(0f, rect.height - 50f, rect.width, 50f), string.Format("Come back tomorrow for {0} points!", this.GetPointsForTomorrow()), BlueStonez.label_interparkbold_13pt, 1, new Color(0.9f, 0.9f, 0.9f), ColorScheme.GuiTeamBlue.SetAlpha(0.5f));
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x0000A020 File Offset: 0x00008220
	private int GetPointsForTomorrow()
	{
		return this._points.PointsTomorrow;
	}

	// Token: 0x04000CD5 RID: 3285
	private DailyPointsView _points;
}
