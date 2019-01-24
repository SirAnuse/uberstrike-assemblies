using System;
using System.Collections.Generic;
using UberStrike.Core.Models;

// Token: 0x02000403 RID: 1027
public abstract class GameDataBaseComparer : IComparer<GameRoomData>
{
	// Token: 0x06001D6B RID: 7531 RVA: 0x000928F0 File Offset: 0x00090AF0
	public int Compare(GameRoomData x, GameRoomData y)
	{
		int num = GameRoomHelper.CanJoinGame(y).CompareTo(GameRoomHelper.CanJoinGame(x));
		return (num != 0) ? num : this.OnCompare(x, y);
	}

	// Token: 0x06001D6C RID: 7532
	protected abstract int OnCompare(GameRoomData x, GameRoomData y);
}
