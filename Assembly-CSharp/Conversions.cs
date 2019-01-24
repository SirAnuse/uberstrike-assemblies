using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x020003CD RID: 973
public static class Conversions
{
	// Token: 0x06001C7A RID: 7290 RVA: 0x000900FC File Offset: 0x0008E2FC
	public static GameModeType GetGameModeType(this GameMode mode)
	{
		if (mode == GameMode.TeamDeathMatch)
		{
			return GameModeType.TeamDeathMatch;
		}
		if (mode == GameMode.DeathMatch)
		{
			return GameModeType.DeathMatch;
		}
		if (mode != GameMode.TeamElimination)
		{
			return GameModeType.None;
		}
		return GameModeType.EliminationMode;
	}

	// Token: 0x06001C7B RID: 7291 RVA: 0x00090130 File Offset: 0x0008E330
	public static GUIContent PriceTag(this ItemPrice price, bool printCurrency = false, string tooltip = "")
	{
		UberStrikeCurrencyType currency = price.Currency;
		if (currency == UberStrikeCurrencyType.Credits)
		{
			return new GUIContent(price.Price.ToString("N0") + ((!printCurrency) ? string.Empty : "Credits"), ShopIcons.IconCredits20x20, tooltip);
		}
		if (currency != UberStrikeCurrencyType.Points)
		{
			return new GUIContent("N/A");
		}
		return new GUIContent(price.Price.ToString("N0") + ((!printCurrency) ? string.Empty : "Points"), ShopIcons.IconPoints20x20, tooltip);
	}
}
