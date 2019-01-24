using System;
using UberStrike.Core.Models;

// Token: 0x02000407 RID: 1031
public class GameDataAccessComparer : GameDataBaseComparer
{
	// Token: 0x06001D74 RID: 7540 RVA: 0x000929DC File Offset: 0x00090BDC
	protected override int OnCompare(GameRoomData a, GameRoomData b)
	{
		int result = 0;
		if (GameDataComparer.SortAscending)
		{
			if (!a.IsPasswordProtected && !b.IsPasswordProtected)
			{
				result = 2;
			}
			else if (!a.IsPasswordProtected)
			{
				result = 1;
			}
			else if (!b.IsPasswordProtected)
			{
				result = -1;
			}
		}
		else if (a.IsPasswordProtected && b.IsPasswordProtected)
		{
			result = 2;
		}
		else if (a.IsPasswordProtected)
		{
			result = 1;
		}
		else if (b.IsPasswordProtected)
		{
			result = -1;
		}
		return result;
	}
}
