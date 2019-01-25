using System;
using UberStrike.Core.Models.Views;
using UnityEngine;

public static class XpPointsUtil
{
	public static ApplicationConfigurationView Config { get; set; }

	public static void GetXpRangeForLevel(int level, out int minXp, out int maxXp)
	{
		level = Mathf.Clamp(level, 1, MaxPlayerLevel);
		minXp = 0;
		maxXp = 0;
		if (level < MaxPlayerLevel)
		{
			Config.XpRequiredPerLevel.TryGetValue(level, out minXp);
			Config.XpRequiredPerLevel.TryGetValue(level + 1, out maxXp);
		}
		else
		{
			Config.XpRequiredPerLevel.TryGetValue(MaxPlayerLevel, out minXp);
			maxXp = minXp + 1;
		}
	}

	public static string GetLevelDescription(int level)
	{
		if (level >= MaxPlayerLevel)
		{
			return "Uber Space";
		}
		return "Lvl " + level;
	}

	public static int GetLevelForXp(int xp)
	{
		for (int i = MaxPlayerLevel; i > 0; i--)
		{
			int num;
			if (Config.XpRequiredPerLevel.TryGetValue(i, out num) && xp >= num)
			{
				return i;
			}
		}
		Debug.LogError($"Level calculation based on player XP failed! XP: {xp}.");

        return 1;
	}

	public static int MaxPlayerLevel
	{
		get
		{
			return Config.MaxLevel;
		}
	}
}
