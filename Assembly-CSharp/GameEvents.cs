using System;
using UnityEngine;

// Token: 0x02000111 RID: 273
public static class GameEvents
{
	// Token: 0x02000112 RID: 274
	public class RespawnCountdown
	{
		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000813 RID: 2067 RVA: 0x000071AE File Offset: 0x000053AE
		// (set) Token: 0x06000814 RID: 2068 RVA: 0x000071B6 File Offset: 0x000053B6
		public int Countdown { get; set; }
	}

	// Token: 0x02000113 RID: 275
	public class MatchCountdown
	{
		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x000071BF File Offset: 0x000053BF
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x000071C7 File Offset: 0x000053C7
		public int Countdown { get; set; }
	}

	// Token: 0x02000114 RID: 276
	public class SpawnPosition
	{
		// Token: 0x1700025F RID: 607
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x000071D0 File Offset: 0x000053D0
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x000071D8 File Offset: 0x000053D8
		public Vector3 Position { get; set; }

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x000071E1 File Offset: 0x000053E1
		// (set) Token: 0x0600081C RID: 2076 RVA: 0x000071E9 File Offset: 0x000053E9
		public float Rotation { get; set; }
	}

	// Token: 0x02000115 RID: 277
	public class PlayerRespawn
	{
		// Token: 0x17000261 RID: 609
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x000071F2 File Offset: 0x000053F2
		// (set) Token: 0x0600081F RID: 2079 RVA: 0x000071FA File Offset: 0x000053FA
		public Vector3 Position { get; set; }

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x00007203 File Offset: 0x00005403
		// (set) Token: 0x06000821 RID: 2081 RVA: 0x0000720B File Offset: 0x0000540B
		public float Rotation { get; set; }
	}

	// Token: 0x02000116 RID: 278
	public class PlayerPause
	{
	}

	// Token: 0x02000117 RID: 279
	public class PlayerUnpause
	{
	}

	// Token: 0x02000118 RID: 280
	public class PlayerIngame
	{
	}

	// Token: 0x02000119 RID: 281
	public class PlayerZoomIn
	{
	}

	// Token: 0x0200011A RID: 282
	public class PlayerZoomOut
	{
	}

	// Token: 0x0200011B RID: 283
	public class PlayerLeft
	{
		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000828 RID: 2088 RVA: 0x00007214 File Offset: 0x00005414
		// (set) Token: 0x06000829 RID: 2089 RVA: 0x0000721C File Offset: 0x0000541C
		public int Cmid { get; set; }
	}

	// Token: 0x0200011C RID: 284
	public class PlayerDamage
	{
		// Token: 0x17000264 RID: 612
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x00007225 File Offset: 0x00005425
		// (set) Token: 0x0600082C RID: 2092 RVA: 0x0000722D File Offset: 0x0000542D
		public float Angle { get; set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x00007236 File Offset: 0x00005436
		// (set) Token: 0x0600082E RID: 2094 RVA: 0x0000723E File Offset: 0x0000543E
		public float DamageValue { get; set; }
	}

	// Token: 0x0200011D RID: 285
	public class WaitingForPlayers
	{
	}

	// Token: 0x0200011E RID: 286
	public class RoundRunning
	{
	}

	// Token: 0x0200011F RID: 287
	public class MatchEnd
	{
	}

	// Token: 0x02000120 RID: 288
	public class PlayerDied
	{
	}

	// Token: 0x02000121 RID: 289
	public class PlayerSpectator
	{
	}

	// Token: 0x02000122 RID: 290
	public class FollowPlayer
	{
	}

	// Token: 0x02000123 RID: 291
	public class ChatWindow
	{
		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000836 RID: 2102 RVA: 0x00007247 File Offset: 0x00005447
		// (set) Token: 0x06000837 RID: 2103 RVA: 0x0000724F File Offset: 0x0000544F
		public bool IsEnabled { get; set; }
	}

	// Token: 0x02000124 RID: 292
	public class PickupItemReset
	{
	}

	// Token: 0x02000125 RID: 293
	public class PickupItemChanged
	{
		// Token: 0x06000839 RID: 2105 RVA: 0x00007258 File Offset: 0x00005458
		public PickupItemChanged(int id, bool enable)
		{
			this.Enable = enable;
			this.Id = id;
		}

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600083A RID: 2106 RVA: 0x0000726E File Offset: 0x0000546E
		// (set) Token: 0x0600083B RID: 2107 RVA: 0x00007276 File Offset: 0x00005476
		public int Id { get; private set; }

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600083C RID: 2108 RVA: 0x0000727F File Offset: 0x0000547F
		// (set) Token: 0x0600083D RID: 2109 RVA: 0x00007287 File Offset: 0x00005487
		public bool Enable { get; private set; }
	}

	// Token: 0x02000126 RID: 294
	public class DoorOpened
	{
		// Token: 0x0600083E RID: 2110 RVA: 0x00007290 File Offset: 0x00005490
		public DoorOpened(int doorID)
		{
			this.DoorID = doorID;
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x0000729F File Offset: 0x0000549F
		// (set) Token: 0x06000840 RID: 2112 RVA: 0x000072A7 File Offset: 0x000054A7
		public int DoorID { get; private set; }
	}
}
