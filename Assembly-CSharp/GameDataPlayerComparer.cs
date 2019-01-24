using System;
using UberStrike.Core.Models;

// Token: 0x02000409 RID: 1033
public class GameDataPlayerComparer : GameDataBaseComparer
{
	// Token: 0x06001D79 RID: 7545 RVA: 0x00092A74 File Offset: 0x00090C74
	protected override int OnCompare(GameRoomData a, GameRoomData b)
	{
		int num = a.ConnectedPlayers - b.ConnectedPlayers;
		return (num != 0) ? ((!GameDataComparer.SortAscending) ? (-num) : num) : GameDataNameComparer.StaticCompare(a, b);
	}
}
