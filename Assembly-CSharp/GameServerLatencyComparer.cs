using System;
using System.Collections.Generic;
using Cmune.Core.Models;

// Token: 0x0200040C RID: 1036
public class GameServerLatencyComparer : IComparer<PhotonServer>
{
	// Token: 0x06001D82 RID: 7554 RVA: 0x00013955 File Offset: 0x00011B55
	public int Compare(PhotonServer a, PhotonServer b)
	{
		return GameServerLatencyComparer.StaticCompare(a, b);
	}

	// Token: 0x06001D83 RID: 7555 RVA: 0x00092BBC File Offset: 0x00090DBC
	public static int StaticCompare(PhotonServer a, PhotonServer b)
	{
		int num = 1;
		int num2 = (a.Data.State != PhotonServerLoad.Status.Alive) ? 1000 : a.Latency;
		int num3 = (b.Data.State != PhotonServerLoad.Status.Alive) ? 1000 : b.Latency;
		if (a.Latency == b.Latency)
		{
			return string.Compare(b.Name, a.Name);
		}
		return (num2 <= num3) ? (num * -1) : num;
	}
}
