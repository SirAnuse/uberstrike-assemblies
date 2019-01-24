using System;
using UberStrike.Core.Models;

// Token: 0x02000404 RID: 1028
public class GameDataMapComparer : GameDataBaseComparer
{
	// Token: 0x06001D6E RID: 7534 RVA: 0x00092928 File Offset: 0x00090B28
	protected override int OnCompare(GameRoomData a, GameRoomData b)
	{
		int num = a.MapID - b.MapID;
		return (num != 0) ? ((!GameDataComparer.SortAscending) ? (-num) : num) : GameDataNameComparer.StaticCompare(a, b);
	}
}
