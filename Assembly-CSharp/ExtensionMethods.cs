using System;
using UberStrike.Core.Models;
using UberStrike.Core.Types;

// Token: 0x02000375 RID: 885
internal static class ExtensionMethods
{
	// Token: 0x06001908 RID: 6408 RVA: 0x00010B0C File Offset: 0x0000ED0C
	public static void Copy(this CommActorInfo original, CommActorInfo data)
	{
		original.ClanTag = data.ClanTag;
		original.CurrentRoom = data.CurrentRoom;
		original.ModerationFlag = data.ModerationFlag;
		original.ModInformation = data.ModInformation;
		original.PlayerName = data.PlayerName;
	}

	// Token: 0x06001909 RID: 6409 RVA: 0x000865C8 File Offset: 0x000847C8
	public static GameModeType GetGameMode(int id)
	{
		if (id == 100)
		{
			return GameModeType.TeamDeathMatch;
		}
		if (id == 101)
		{
			return GameModeType.DeathMatch;
		}
		if (id != 106)
		{
			return GameModeType.None;
		}
		return GameModeType.EliminationMode;
	}
}
