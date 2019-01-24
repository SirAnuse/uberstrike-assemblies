using System;
using System.Collections.Generic;
using Cmune.Core.Models;

// Token: 0x0200040D RID: 1037
public class GameServerPlayerCountComparer : IComparer<PhotonServer>
{
	// Token: 0x06001D85 RID: 7557 RVA: 0x0001395E File Offset: 0x00011B5E
	public int Compare(PhotonServer a, PhotonServer b)
	{
		return GameServerPlayerCountComparer.StaticCompare(a, b);
	}

	// Token: 0x06001D86 RID: 7558 RVA: 0x00092C44 File Offset: 0x00090E44
	public static int StaticCompare(PhotonServer a, PhotonServer b)
	{
		int num = 1;
		if (a.Data.PlayersConnected == b.Data.PlayersConnected)
		{
			return string.Compare(b.Name, a.Name);
		}
		return (((a.Data.State != PhotonServerLoad.Status.Alive) ? 1000 : a.Data.PlayersConnected) <= ((b.Data.State != PhotonServerLoad.Status.Alive) ? 1000 : b.Data.PlayersConnected)) ? (num * -1) : num;
	}
}
