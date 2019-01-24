using System;
using System.Collections;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x020001C4 RID: 452
internal class ValuablePlayerDetailGUI
{
	// Token: 0x06000C73 RID: 3187 RVA: 0x000096A0 File Offset: 0x000078A0
	public ValuablePlayerDetailGUI()
	{
		this._achievementList = new List<AchievementType>();
	}

	// Token: 0x06000C74 RID: 3188 RVA: 0x00053E1C File Offset: 0x0005201C
	public void SetValuablePlayer(StatsSummary playerStats)
	{
		this._curPlayerStats = playerStats;
		this._curBadgeTitle = string.Empty;
		this._curBadgeText = string.Empty;
		this._achievementList.Clear();
		if (playerStats != null)
		{
			foreach (KeyValuePair<byte, ushort> keyValuePair in this._curPlayerStats.Achievements)
			{
				this._achievementList.Add((AchievementType)keyValuePair.Key);
			}
		}
		UnityRuntime.StartRoutine(this.StartBadgeShow());
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x000096BA File Offset: 0x000078BA
	public void StopBadgeShow()
	{
		Singleton<PreemptiveCoroutineManager>.Instance.IncrementId(new PreemptiveCoroutineManager.CoroutineFunction(this.StartBadgeShow));
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x00053EC0 File Offset: 0x000520C0
	public void Draw(Rect rect)
	{
		GUI.BeginGroup(rect, GUIContent.none, StormFront.GrayPanelBox);
		if (this._curBadge != null)
		{
			GUI.DrawTexture(new Rect((rect.width - 180f) / 2f, 10f, 180f, 125f), this._curBadge);
		}
		if (this._curPlayerStats != null)
		{
			GUI.BeginGroup(new Rect(0f, 140f, rect.width, rect.height - 140f));
			GUI.contentColor = ColorScheme.UberStrikeYellow;
			GUI.Label(new Rect(0f, 5f, rect.width, 20f), this._curBadgeTitle, BlueStonez.label_interparkbold_16pt);
			GUI.contentColor = Color.white;
			GUI.Label(new Rect(0f, 30f, rect.width, 20f), this._curBadgeText, BlueStonez.label_interparkbold_16pt);
			GUI.Label(new Rect(0f, 60f, rect.width, 20f), this._curPlayerStats.Name, BlueStonez.label_interparkbold_18pt);
			GUI.EndGroup();
		}
		GUI.EndGroup();
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x00053FF8 File Offset: 0x000521F8
	private IEnumerator StartBadgeShow()
	{
		int coroutineId = Singleton<PreemptiveCoroutineManager>.Instance.IncrementId(new PreemptiveCoroutineManager.CoroutineFunction(this.StartBadgeShow));
		if (this._achievementList.Count > 0 && this._curPlayerStats != null && this._curPlayerStats.Achievements.Count == this._achievementList.Count)
		{
			this._curAchievementIndex = 0;
			while (Singleton<PreemptiveCoroutineManager>.Instance.IsCurrent(new PreemptiveCoroutineManager.CoroutineFunction(this.StartBadgeShow), coroutineId))
			{
				AchievementType type = this._achievementList[this._curAchievementIndex];
				this.SetCurrentAchievementBadge(type, (int)this._curPlayerStats.Achievements[(byte)type], string.Empty);
				yield return new WaitForSeconds(2f);
				if (this._achievementList.Count > 0)
				{
					this._curAchievementIndex = ++this._curAchievementIndex % this._achievementList.Count;
				}
			}
			yield break;
		}
		if (this._curPlayerStats != null)
		{
			this.SetCurrentAchievementBadge(AchievementType.None, Mathf.RoundToInt((float)Math.Max(this._curPlayerStats.Kills, 0) / Math.Max((float)this._curPlayerStats.Deaths, 1f) * 10f), this._curPlayerStats.Name);
		}
		yield break;
	}

	// Token: 0x06000C78 RID: 3192 RVA: 0x00054014 File Offset: 0x00052214
	private string GetAchievementTitle(AchievementType type)
	{
		switch (type)
		{
		case AchievementType.MostValuable:
			return "MOST VALUABLE";
		case AchievementType.MostAggressive:
			return "MOST AGGRESSIVE";
		case AchievementType.SharpestShooter:
			return "SHARPEST SHOOTER";
		case AchievementType.TriggerHappy:
			return "TRIGGER HAPPY";
		case AchievementType.HardestHitter:
			return "HARDEST HITTER";
		case AchievementType.CostEffective:
			return "COST EFFECTIVE";
		default:
			return string.Empty;
		}
	}

	// Token: 0x06000C79 RID: 3193 RVA: 0x00054074 File Offset: 0x00052274
	private void SetCurrentAchievementBadge(AchievementType type, int value, string title = "")
	{
		this._curBadge = UberstrikeIconsHelper.GetAchievementBadgeTexture(type);
		this._curBadgeTitle = this.GetAchievementTitle(type);
		if (string.IsNullOrEmpty(this._curBadgeTitle))
		{
			this._curBadgeTitle = title;
		}
		switch (type)
		{
		case AchievementType.MostValuable:
			this._curBadgeText = string.Format("Best KDR: {0:N1}", (float)value / 10f);
			break;
		case AchievementType.MostAggressive:
			this._curBadgeText = string.Format("Total Kills: {0:N0}", value);
			break;
		case AchievementType.SharpestShooter:
			this._curBadgeText = string.Format("Critial Strikes: {0:N0}", value);
			break;
		case AchievementType.TriggerHappy:
			this._curBadgeText = string.Format("Kills in a row: {0:N0}", value);
			break;
		case AchievementType.HardestHitter:
			this._curBadgeText = string.Format("Damage Dealt: {0:N0}", value);
			break;
		case AchievementType.CostEffective:
			this._curBadgeText = string.Format("Accuracy: {0:N1}%", (float)value / 10f);
			break;
		default:
			this._curBadgeText = string.Format("KDR: {0:N1}", (float)value / 10f);
			break;
		}
	}

	// Token: 0x04000BC8 RID: 3016
	private StatsSummary _curPlayerStats;

	// Token: 0x04000BC9 RID: 3017
	private List<AchievementType> _achievementList;

	// Token: 0x04000BCA RID: 3018
	private Texture2D _curBadge;

	// Token: 0x04000BCB RID: 3019
	private string _curBadgeTitle;

	// Token: 0x04000BCC RID: 3020
	private string _curBadgeText;

	// Token: 0x04000BCD RID: 3021
	private int _curAchievementIndex = -1;
}
