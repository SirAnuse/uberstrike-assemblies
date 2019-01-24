using System;
using System.Collections.Generic;

// Token: 0x0200040B RID: 1035
public class GameServerNameComparer : IComparer<PhotonServer>
{
	// Token: 0x06001D7F RID: 7551 RVA: 0x00013939 File Offset: 0x00011B39
	public int Compare(PhotonServer a, PhotonServer b)
	{
		return GameServerNameComparer.StaticCompare(a, b);
	}

	// Token: 0x06001D80 RID: 7552 RVA: 0x00013942 File Offset: 0x00011B42
	public static int StaticCompare(PhotonServer a, PhotonServer b)
	{
		return string.Compare(b.Name, a.Name);
	}
}
