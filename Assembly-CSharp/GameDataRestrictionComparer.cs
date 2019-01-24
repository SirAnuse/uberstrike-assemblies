using System;
using System.Collections.Generic;
using UberStrike.Core.Models;

// Token: 0x0200040A RID: 1034
public class GameDataRestrictionComparer : GameDataBaseComparer
{
	// Token: 0x06001D7A RID: 7546 RVA: 0x00013923 File Offset: 0x00011B23
	public GameDataRestrictionComparer(int playerLevel, IComparer<GameRoomData> baseComparer)
	{
		this._playerLevel = playerLevel;
		this._baseComparer = baseComparer;
	}

	// Token: 0x06001D7B RID: 7547 RVA: 0x00092AB4 File Offset: 0x00090CB4
	protected override int OnCompare(GameRoomData x, GameRoomData y)
	{
		if (GameRoomHelper.HasLevelRestriction(x) || GameRoomHelper.HasLevelRestriction(y))
		{
			return (this._playerLevel >= 5) ? this.VeteranLevelsUp(x, y) : this.NoobLevelsUp(x, y);
		}
		return this._baseComparer.Compare(x, y);
	}

	// Token: 0x06001D7C RID: 7548 RVA: 0x00092B08 File Offset: 0x00090D08
	private int NoobLevelsUp(GameRoomData x, GameRoomData y)
	{
		return (int)(((x.LevelMin >= 5 || x.LevelMin == 0) ? x.LevelMin : (x.LevelMin - 100)) - ((y.LevelMin >= 5 || y.LevelMin == 0) ? y.LevelMin : (y.LevelMin - 100)));
	}

	// Token: 0x06001D7D RID: 7549 RVA: 0x00092B6C File Offset: 0x00090D6C
	private int VeteranLevelsUp(GameRoomData x, GameRoomData y)
	{
		return (int)(((x.LevelMin >= 5) ? x.LevelMin : (x.LevelMin + 100)) - ((y.LevelMin >= 5) ? y.LevelMin : (y.LevelMin + 100)));
	}

	// Token: 0x040019D0 RID: 6608
	private int _playerLevel;

	// Token: 0x040019D1 RID: 6609
	private IComparer<GameRoomData> _baseComparer;
}
