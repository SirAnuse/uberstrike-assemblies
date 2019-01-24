using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class EndOfMatchStats
{
	// Token: 0x06001C35 RID: 7221 RVA: 0x0008F8B8 File Offset: 0x0008DAB8
	public EndOfMatchStats()
	{
		this.Data = new EndOfMatchData
		{
			MostValuablePlayers = new List<StatsSummary>(),
			PlayerStatsBestPerLife = new StatsCollection(),
			PlayerStatsTotal = new StatsCollection()
		};
	}

	// Token: 0x17000644 RID: 1604
	// (get) Token: 0x06001C36 RID: 7222 RVA: 0x00012BDC File Offset: 0x00010DDC
	// (set) Token: 0x06001C37 RID: 7223 RVA: 0x00012BE4 File Offset: 0x00010DE4
	public string PlayTimeXp { get; private set; }

	// Token: 0x17000645 RID: 1605
	// (get) Token: 0x06001C38 RID: 7224 RVA: 0x00012BED File Offset: 0x00010DED
	// (set) Token: 0x06001C39 RID: 7225 RVA: 0x00012BF5 File Offset: 0x00010DF5
	public string PlayTimePts { get; private set; }

	// Token: 0x17000646 RID: 1606
	// (get) Token: 0x06001C3A RID: 7226 RVA: 0x00012BFE File Offset: 0x00010DFE
	// (set) Token: 0x06001C3B RID: 7227 RVA: 0x00012C06 File Offset: 0x00010E06
	public string SkillBonusXp { get; private set; }

	// Token: 0x17000647 RID: 1607
	// (get) Token: 0x06001C3C RID: 7228 RVA: 0x00012C0F File Offset: 0x00010E0F
	// (set) Token: 0x06001C3D RID: 7229 RVA: 0x00012C17 File Offset: 0x00010E17
	public string SkillBonusPts { get; private set; }

	// Token: 0x17000648 RID: 1608
	// (get) Token: 0x06001C3E RID: 7230 RVA: 0x00012C20 File Offset: 0x00010E20
	// (set) Token: 0x06001C3F RID: 7231 RVA: 0x00012C28 File Offset: 0x00010E28
	public string BoostXp { get; private set; }

	// Token: 0x17000649 RID: 1609
	// (get) Token: 0x06001C40 RID: 7232 RVA: 0x00012C31 File Offset: 0x00010E31
	// (set) Token: 0x06001C41 RID: 7233 RVA: 0x00012C39 File Offset: 0x00010E39
	public string BoostPts { get; private set; }

	// Token: 0x1700064A RID: 1610
	// (get) Token: 0x06001C42 RID: 7234 RVA: 0x00012C42 File Offset: 0x00010E42
	// (set) Token: 0x06001C43 RID: 7235 RVA: 0x00012C4A File Offset: 0x00010E4A
	public string TotalXp { get; private set; }

	// Token: 0x1700064B RID: 1611
	// (get) Token: 0x06001C44 RID: 7236 RVA: 0x00012C53 File Offset: 0x00010E53
	// (set) Token: 0x06001C45 RID: 7237 RVA: 0x00012C5B File Offset: 0x00010E5B
	public string TotalPts { get; private set; }

	// Token: 0x1700064C RID: 1612
	// (get) Token: 0x06001C46 RID: 7238 RVA: 0x00012C64 File Offset: 0x00010E64
	// (set) Token: 0x06001C47 RID: 7239 RVA: 0x00012C6C File Offset: 0x00010E6C
	public string PlayTime { get; private set; }

	// Token: 0x1700064D RID: 1613
	// (get) Token: 0x06001C48 RID: 7240 RVA: 0x00012C75 File Offset: 0x00010E75
	// (set) Token: 0x06001C49 RID: 7241 RVA: 0x00012C7D File Offset: 0x00010E7D
	public string Kills { get; private set; }

	// Token: 0x1700064E RID: 1614
	// (get) Token: 0x06001C4A RID: 7242 RVA: 0x00012C86 File Offset: 0x00010E86
	// (set) Token: 0x06001C4B RID: 7243 RVA: 0x00012C8E File Offset: 0x00010E8E
	public string Nutshots { get; private set; }

	// Token: 0x1700064F RID: 1615
	// (get) Token: 0x06001C4C RID: 7244 RVA: 0x00012C97 File Offset: 0x00010E97
	// (set) Token: 0x06001C4D RID: 7245 RVA: 0x00012C9F File Offset: 0x00010E9F
	public string Headshots { get; private set; }

	// Token: 0x17000650 RID: 1616
	// (get) Token: 0x06001C4E RID: 7246 RVA: 0x00012CA8 File Offset: 0x00010EA8
	// (set) Token: 0x06001C4F RID: 7247 RVA: 0x00012CB0 File Offset: 0x00010EB0
	public string Smackdowns { get; private set; }

	// Token: 0x17000651 RID: 1617
	// (get) Token: 0x06001C50 RID: 7248 RVA: 0x00012CB9 File Offset: 0x00010EB9
	// (set) Token: 0x06001C51 RID: 7249 RVA: 0x00012CC1 File Offset: 0x00010EC1
	public string Deaths { get; private set; }

	// Token: 0x17000652 RID: 1618
	// (get) Token: 0x06001C52 RID: 7250 RVA: 0x00012CCA File Offset: 0x00010ECA
	// (set) Token: 0x06001C53 RID: 7251 RVA: 0x00012CD2 File Offset: 0x00010ED2
	public string KDR { get; private set; }

	// Token: 0x17000653 RID: 1619
	// (get) Token: 0x06001C54 RID: 7252 RVA: 0x00012CDB File Offset: 0x00010EDB
	// (set) Token: 0x06001C55 RID: 7253 RVA: 0x00012CE3 File Offset: 0x00010EE3
	public string Suicides { get; private set; }

	// Token: 0x17000654 RID: 1620
	// (get) Token: 0x06001C56 RID: 7254 RVA: 0x00012CEC File Offset: 0x00010EEC
	// (set) Token: 0x06001C57 RID: 7255 RVA: 0x00012CF4 File Offset: 0x00010EF4
	public int GainedXp { get; private set; }

	// Token: 0x17000655 RID: 1621
	// (get) Token: 0x06001C58 RID: 7256 RVA: 0x00012CFD File Offset: 0x00010EFD
	// (set) Token: 0x06001C59 RID: 7257 RVA: 0x00012D05 File Offset: 0x00010F05
	public int GainedPts { get; private set; }

	// Token: 0x17000656 RID: 1622
	// (get) Token: 0x06001C5A RID: 7258 RVA: 0x00012D0E File Offset: 0x00010F0E
	// (set) Token: 0x06001C5B RID: 7259 RVA: 0x00012D16 File Offset: 0x00010F16
	public EndOfMatchData Data { get; private set; }

	// Token: 0x06001C5C RID: 7260 RVA: 0x0008F8FC File Offset: 0x0008DAFC
	public void Update(EndOfMatchData data)
	{
		this.Data = data;
		this.Data.TimeInGameMinutes++;
		if (this.Data.TimeInGameMinutes < 60)
		{
			this.PlayTime = "Less than 1 min";
		}
		else
		{
			this.PlayTime = string.Format("{0} min", Mathf.CeilToInt((float)(this.Data.TimeInGameMinutes / 60)));
		}
		this.Kills = string.Format("{0}", Mathf.Max(0, this.Data.PlayerStatsTotal.GetKills()));
		this.Headshots = string.Format("{0}", Mathf.Max(0, this.Data.PlayerStatsTotal.Headshots));
		this.Smackdowns = string.Format("{0}", Mathf.Max(0, this.Data.PlayerStatsTotal.MeleeKills));
		this.Nutshots = string.Format("{0}", Mathf.Max(0, this.Data.PlayerStatsTotal.Nutshots));
		this.Deaths = this.Data.PlayerStatsTotal.Deaths.ToString();
		this.Suicides = (-this.Data.PlayerStatsTotal.Suicides).ToString();
		this.KDR = this.GetKdr(this.Data.PlayerStatsTotal).ToString("N1");
		this.CalculateXp();
		this.CalculatePoints();
		this.Data.PlayerStatsTotal.Xp = this.GainedXp;
		this.Data.PlayerStatsTotal.Points = this.GainedPts;
		GameState.Current.UpdatePlayerStatistics(this.Data.PlayerStatsTotal, this.Data.PlayerStatsBestPerLife);
	}

	// Token: 0x06001C5D RID: 7261 RVA: 0x00012D1F File Offset: 0x00010F1F
	public float GetKdr(StatsCollection stats)
	{
		return (float)Mathf.Max(stats.GetKills(), 0) / Mathf.Max((float)stats.Deaths, 1f);
	}

	// Token: 0x06001C5E RID: 7262 RVA: 0x0008FAD4 File Offset: 0x0008DCD4
	private void CalculateXp()
	{
		if (this.Data.PlayerStatsTotal.GetDamageDealt() > 0)
		{
			int num = (!this.Data.HasWonMatch) ? XpPointsUtil.Config.XpBaseLoser : XpPointsUtil.Config.XpBaseWinner;
			int num2 = (!this.Data.HasWonMatch) ? XpPointsUtil.Config.XpPerMinuteLoser : XpPointsUtil.Config.XpPerMinuteWinner;
			int num3 = Mathf.Max(0, this.Data.PlayerStatsTotal.GetKills()) * XpPointsUtil.Config.XpKill + Mathf.Max(0, this.Data.PlayerStatsTotal.Nutshots) * XpPointsUtil.Config.XpNutshot + Mathf.Max(0, this.Data.PlayerStatsTotal.Headshots) * XpPointsUtil.Config.XpHeadshot + Mathf.Max(0, this.Data.PlayerStatsTotal.MeleeKills) * XpPointsUtil.Config.XpSmackdown;
			int num4 = Mathf.CeilToInt((float)(this.Data.TimeInGameMinutes / 60 * num2));
			int num5 = Mathf.CeilToInt((float)(this.Data.TimeInGameMinutes / 60 * num2) * this.CalculateBoost(ItemPropertyType.XpBoost));
			this.GainedXp = num + num3 + num4 + num5;
			this.PlayTimeXp = num4.ToString();
			this.SkillBonusXp = num3.ToString();
			this.BoostXp = num5.ToString();
			this.TotalXp = this.GainedXp.ToString();
		}
		else
		{
			this.GainedXp = 0;
			string text = "0";
			this.TotalXp = text;
			text = text;
			this.BoostXp = text;
			text = text;
			this.SkillBonusXp = text;
			this.PlayTimeXp = text;
		}
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x0008FC90 File Offset: 0x0008DE90
	private void CalculatePoints()
	{
		int num = (!this.Data.HasWonMatch) ? XpPointsUtil.Config.PointsBaseLoser : XpPointsUtil.Config.PointsBaseWinner;
		int num2 = (!this.Data.HasWonMatch) ? XpPointsUtil.Config.PointsPerMinuteLoser : XpPointsUtil.Config.PointsPerMinuteWinner;
		int num3 = Mathf.Max(0, this.Data.PlayerStatsTotal.GetKills()) * XpPointsUtil.Config.PointsKill + Mathf.Max(0, this.Data.PlayerStatsTotal.Nutshots) * XpPointsUtil.Config.PointsNutshot + Mathf.Max(0, this.Data.PlayerStatsTotal.Headshots) * XpPointsUtil.Config.PointsHeadshot + Mathf.Max(0, this.Data.PlayerStatsTotal.MeleeKills) * XpPointsUtil.Config.PointsSmackdown;
		int num4 = Mathf.CeilToInt((float)(this.Data.TimeInGameMinutes / 60 * num2));
		int num5 = Mathf.CeilToInt((float)(this.Data.TimeInGameMinutes / 60 * num2) * this.CalculateBoost(ItemPropertyType.PointsBoost));
		this.GainedPts = num + num3 + num4 + num5;
		this.PlayTimePts = num4.ToString();
		this.SkillBonusPts = num3.ToString();
		this.BoostPts = num5.ToString();
		this.TotalPts = this.GainedPts.ToString();
	}

	// Token: 0x06001C60 RID: 7264 RVA: 0x0008FDFC File Offset: 0x0008DFFC
	private float CalculateBoost(ItemPropertyType propType)
	{
		float num = 0f;
		foreach (InventoryItem inventoryItem in Singleton<InventoryManager>.Instance.InventoryItems)
		{
			if (inventoryItem.IsValid)
			{
				Dictionary<ItemPropertyType, int> itemProperties = inventoryItem.Item.View.ItemProperties;
				if (itemProperties != null && itemProperties.ContainsKey(propType))
				{
					num = Mathf.Max(num, (float)inventoryItem.Item.View.ItemProperties[propType] / 100f);
				}
			}
		}
		return num;
	}
}
