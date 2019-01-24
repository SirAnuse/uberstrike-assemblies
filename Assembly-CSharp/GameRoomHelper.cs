using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;

// Token: 0x020003D1 RID: 977
public static class GameRoomHelper
{
	// Token: 0x06001C92 RID: 7314 RVA: 0x0001301E File Offset: 0x0001121E
	public static bool HasLevelRestriction(GameRoomData room)
	{
		return room.LevelMin != 0 || room.LevelMax != 0;
	}

	// Token: 0x06001C93 RID: 7315 RVA: 0x0001303A File Offset: 0x0001123A
	public static bool IsLevelAllowed(int min, int max, int level)
	{
		return level >= min && (max == 0 || level <= max);
	}

	// Token: 0x06001C94 RID: 7316 RVA: 0x00013056 File Offset: 0x00011256
	public static bool IsLevelAllowed(GameRoomData room, int level)
	{
		return GameRoomHelper.IsLevelAllowed((int)room.LevelMin, (int)room.LevelMax, level);
	}

	// Token: 0x06001C95 RID: 7317 RVA: 0x000905E0 File Offset: 0x0008E7E0
	public static bool CanJoinGame(GameRoomData game)
	{
		bool flag = !game.IsFull && GameRoomHelper.IsLevelAllowed(game, PlayerDataManager.PlayerLevel);
		flag |= (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator);
		return flag & Singleton<MapManager>.Instance.HasMapWithId(game.MapID);
	}
}
