using System;
using UberStrike.Core.Models;

// Token: 0x02000405 RID: 1029
public class GameDataTimeComparer : GameDataBaseComparer
{
	// Token: 0x06001D70 RID: 7536 RVA: 0x00092968 File Offset: 0x00090B68
	protected override int OnCompare(GameRoomData a, GameRoomData b)
	{
		int num = a.TimeLimit - b.TimeLimit;
		return (!GameDataComparer.SortAscending) ? (-num) : num;
	}
}
