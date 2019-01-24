using System;
using UberStrike.Core.Models;

// Token: 0x02000408 RID: 1032
public class GameDataNameComparer : GameDataBaseComparer
{
	// Token: 0x06001D76 RID: 7542 RVA: 0x000138E7 File Offset: 0x00011AE7
	protected override int OnCompare(GameRoomData a, GameRoomData b)
	{
		return GameDataNameComparer.StaticCompare(a, b);
	}

	// Token: 0x06001D77 RID: 7543 RVA: 0x000138F0 File Offset: 0x00011AF0
	public static int StaticCompare(GameRoomData a, GameRoomData b)
	{
		return (!GameDataComparer.SortAscending) ? string.Compare(a.Name, b.Name) : string.Compare(b.Name, a.Name);
	}
}
