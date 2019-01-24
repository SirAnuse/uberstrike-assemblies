using System;
using UberStrike.Core.Models.Views;
using UnityEngine;

// Token: 0x020003DE RID: 990
public static class XpPointsUtil
{
	// Token: 0x1700065E RID: 1630
	// (get) Token: 0x06001CE8 RID: 7400 RVA: 0x000133D1 File Offset: 0x000115D1
	// (set) Token: 0x06001CE9 RID: 7401 RVA: 0x000133D8 File Offset: 0x000115D8
	public static ApplicationConfigurationView Config { get; set; }

	// Token: 0x06001CEA RID: 7402 RVA: 0x00091804 File Offset: 0x0008FA04
	public static void GetXpRangeForLevel(int level, out int minXp, out int maxXp)
	{
		level = Mathf.Clamp(level, 1, XpPointsUtil.MaxPlayerLevel);
		minXp = 0;
		maxXp = 0;
		if (level < XpPointsUtil.MaxPlayerLevel)
		{
			XpPointsUtil.Config.XpRequiredPerLevel.TryGetValue(level, out minXp);
			XpPointsUtil.Config.XpRequiredPerLevel.TryGetValue(level + 1, out maxXp);
		}
		else
		{
			XpPointsUtil.Config.XpRequiredPerLevel.TryGetValue(XpPointsUtil.MaxPlayerLevel, out minXp);
			maxXp = minXp + 1;
		}
	}

	// Token: 0x06001CEB RID: 7403 RVA: 0x000133E0 File Offset: 0x000115E0
	public static string GetLevelDescription(int level)
	{
		if (level >= XpPointsUtil.MaxPlayerLevel)
		{
			return "Uber Space";
		}
		return "Lvl " + level;
	}

	// Token: 0x06001CEC RID: 7404 RVA: 0x00091878 File Offset: 0x0008FA78
	public static int GetLevelForXp(int xp)
	{
		for (int i = XpPointsUtil.MaxPlayerLevel; i > 0; i--)
		{
			int num;
			if (XpPointsUtil.Config.XpRequiredPerLevel.TryGetValue(i, out num) && xp >= num)
			{
				return i;
			}
		}
		Debug.LogError("Level calculation based on player XP failed ! XP = " + xp);
		return 1;
	}

	// Token: 0x1700065F RID: 1631
	// (get) Token: 0x06001CED RID: 7405 RVA: 0x00013403 File Offset: 0x00011603
	public static int MaxPlayerLevel
	{
		get
		{
			return XpPointsUtil.Config.MaxLevel;
		}
	}
}
