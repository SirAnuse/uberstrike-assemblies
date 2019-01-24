using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x020001C6 RID: 454
internal class ValuablePlayerListGUI
{
	// Token: 0x17000329 RID: 809
	// (get) Token: 0x06000C81 RID: 3201 RVA: 0x000096E4 File Offset: 0x000078E4
	// (set) Token: 0x06000C82 RID: 3202 RVA: 0x000096EC File Offset: 0x000078EC
	public bool Enabled { get; set; }

	// Token: 0x1700032A RID: 810
	// (get) Token: 0x06000C83 RID: 3203 RVA: 0x000096F5 File Offset: 0x000078F5
	// (set) Token: 0x06000C84 RID: 3204 RVA: 0x000096FD File Offset: 0x000078FD
	public Action<StatsSummary> OnSelectionChange { get; set; }

	// Token: 0x1700032B RID: 811
	// (get) Token: 0x06000C85 RID: 3205 RVA: 0x00009706 File Offset: 0x00007906
	public float Height
	{
		get
		{
			return 20f + this._playerListViewHeight + 2f;
		}
	}

	// Token: 0x06000C86 RID: 3206 RVA: 0x0000971A File Offset: 0x0000791A
	public void ClearSelection()
	{
		this._curSelectedPlayerIndex = -1;
	}

	// Token: 0x06000C87 RID: 3207 RVA: 0x0005441C File Offset: 0x0005261C
	public void Draw(Rect rect)
	{
		GUI.BeginGroup(rect, GUIContent.none, BlueStonez.window);
		Rect rect2 = new Rect(0f, 0f, rect.width, 20f);
		Rect rect3 = new Rect(0f, 20f, rect.width, rect.height - 20f - 1f);
		this.DrawRankingListHeader(rect2, this._columnWidthPercent);
		this.DrawRankingListContent(rect3, this._columnWidthPercent);
		GUI.EndGroup();
	}

	// Token: 0x06000C88 RID: 3208 RVA: 0x00009723 File Offset: 0x00007923
	public void SetSelection(int index)
	{
		this._curSelectedPlayerIndex = index;
		if (this.OnSelectionChange != null)
		{
			this.OnSelectionChange(GameState.Current.Statistics.Data.MostValuablePlayers[this._curSelectedPlayerIndex]);
		}
	}

	// Token: 0x06000C89 RID: 3209 RVA: 0x000544A0 File Offset: 0x000526A0
	private void DrawRankingListHeader(Rect rect, float[] columnWidthPercent)
	{
		GUI.BeginGroup(rect);
		float num = 0f;
		for (int i = 0; i < this._headingArray.Length; i++)
		{
			Rect position = new Rect(num, 0f, rect.width * columnWidthPercent[i], rect.height);
			GUI.Button(position, string.Empty, BlueStonez.box_grey50);
			GUI.Label(position, new GUIContent(this._headingArray[i]), BlueStonez.label_interparkmed_11pt);
			num += rect.width * columnWidthPercent[i];
		}
		GUI.EndGroup();
	}

	// Token: 0x06000C8A RID: 3210 RVA: 0x00054530 File Offset: 0x00052730
	private void DrawRankingListContent(Rect rect, float[] columnWidthPercent)
	{
		float num = rect.width;
		if (GameState.Current.Statistics.Data.MostValuablePlayers != null)
		{
			this._playerListViewHeight = (float)(GameState.Current.Statistics.Data.MostValuablePlayers.Count * 32);
			if (this._playerListViewHeight > rect.height)
			{
				num -= 20f;
			}
		}
		this._scroll = GUITools.BeginScrollView(rect, this._scroll, new Rect(0f, 0f, num, this._playerListViewHeight), false, false, true);
		float num2 = 0f;
		int num3 = 0;
		while (GameState.Current.Statistics.Data != null && num3 < GameState.Current.Statistics.Data.MostValuablePlayers.Count)
		{
			this.DrawStatsSummary(new Rect(0f, num2, num, 32f), num3, columnWidthPercent);
			num2 += 32f;
			num3++;
		}
		GUITools.EndScrollView();
	}

	// Token: 0x06000C8B RID: 3211 RVA: 0x00054630 File Offset: 0x00052830
	private void DrawStatsSummary(Rect rect, int rank, float[] columnWidthPercent)
	{
		StatsSummary statsSummary = GameState.Current.Statistics.Data.MostValuablePlayers[rank];
		Color contentColor = Color.white;
		if (statsSummary.Cmid != PlayerDataManager.Cmid)
		{
			if (statsSummary.Team == TeamID.BLUE)
			{
				contentColor = ColorScheme.UberStrikeBlue;
			}
			else if (statsSummary.Team == TeamID.RED)
			{
				contentColor = ColorScheme.UberStrikeRed;
			}
		}
		if (this._curSelectedPlayerIndex == rank)
		{
			GUI.Label(rect, GUIContent.none, StormFront.GrayPanelBox);
		}
		else
		{
			GUI.color = new Color(1f, 1f, 1f, 0.5f);
		}
		GUI.BeginGroup(rect);
		float num = 0f;
		Vector2 vector = BlueStonez.label_interparkbold_18pt_left.CalcSize(new GUIContent(statsSummary.Name));
		GUI.contentColor = contentColor;
		this.DrawAchivements(new Rect(num + 16f + vector.x, 0f, rect.width * columnWidthPercent[0] - num - 16f - vector.x, 32f), statsSummary.Achievements);
		GUI.Label(new Rect(num + 10f, 0f, rect.width * columnWidthPercent[0], 32f), statsSummary.Name, BlueStonez.label_interparkbold_18pt_left);
		num += rect.width * columnWidthPercent[0];
		GUI.Label(new Rect(num, 0f, rect.width * columnWidthPercent[1], 32f), statsSummary.Kills.ToString(), BlueStonez.label_interparkbold_18pt);
		num += rect.width * columnWidthPercent[1];
		GUI.Label(new Rect(num, 0f, rect.width * columnWidthPercent[2], 32f), statsSummary.Deaths.ToString(), BlueStonez.label_interparkbold_18pt);
		num += rect.width * columnWidthPercent[2];
		GUI.Label(new Rect(num, 0f, rect.width * columnWidthPercent[3], 32f), statsSummary.Level.ToString(), BlueStonez.label_interparkbold_18pt);
		GUI.color = Color.white;
		GUI.contentColor = Color.white;
		GUI.EndGroup();
		if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition) && this._curSelectedPlayerIndex != rank)
		{
			this.SetSelection(rank);
		}
	}

	// Token: 0x06000C8C RID: 3212 RVA: 0x0005488C File Offset: 0x00052A8C
	private void DrawAchivements(Rect rect, Dictionary<byte, ushort> achievements)
	{
		GUI.BeginGroup(rect);
		float num = 0f;
		foreach (KeyValuePair<byte, ushort> keyValuePair in achievements)
		{
			AchievementType key = (AchievementType)keyValuePair.Key;
			Texture2D achievementBadgeTexture = UberstrikeIconsHelper.GetAchievementBadgeTexture(key);
			float num2 = (rect.height - 2f) / (float)achievementBadgeTexture.height;
			GUI.DrawTexture(new Rect(num, 1f, (float)achievementBadgeTexture.width * num2, rect.height - 2f), achievementBadgeTexture);
			num += (float)achievementBadgeTexture.width * num2;
		}
		GUI.EndGroup();
	}

	// Token: 0x04000BD3 RID: 3027
	private const float HEADER_HEIGHT = 20f;

	// Token: 0x04000BD4 RID: 3028
	private readonly float[] _columnWidthPercent = new float[]
	{
		0.7f,
		0.1f,
		0.1f,
		0.1f
	};

	// Token: 0x04000BD5 RID: 3029
	private readonly string[] _headingArray = new string[]
	{
		"NAME",
		"KILL",
		"DEATHS",
		"LEVEL"
	};

	// Token: 0x04000BD6 RID: 3030
	private Vector2 _scroll;

	// Token: 0x04000BD7 RID: 3031
	private int _curSelectedPlayerIndex = -1;

	// Token: 0x04000BD8 RID: 3032
	private float _playerListViewHeight;
}
