using System;
using UberStrike.Core.Models;

// Token: 0x02000406 RID: 1030
public class GameDataRuleComparer : GameDataBaseComparer
{
	// Token: 0x06001D72 RID: 7538 RVA: 0x00092998 File Offset: 0x00090B98
	protected override int OnCompare(GameRoomData a, GameRoomData b)
	{
		int num = (int)((short)a.GameMode - (short)b.GameMode);
		return (num != 0) ? ((!GameDataComparer.SortAscending) ? (-num) : num) : GameDataNameComparer.StaticCompare(a, b);
	}
}
