using System;
using UberStrike.Core.Types;

namespace UberStrike.Core.Models
{
	// Token: 0x02000224 RID: 548
	[Serializable]
	public class GameRoomData : RoomData
	{
		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000E38 RID: 3640 RVA: 0x00009D3F File Offset: 0x00007F3F
		// (set) Token: 0x06000E39 RID: 3641 RVA: 0x00009D47 File Offset: 0x00007F47
		public int ConnectedPlayers { get; set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000E3A RID: 3642 RVA: 0x00009D50 File Offset: 0x00007F50
		// (set) Token: 0x06000E3B RID: 3643 RVA: 0x00009D58 File Offset: 0x00007F58
		public int PlayerLimit { get; set; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000E3C RID: 3644 RVA: 0x00009D61 File Offset: 0x00007F61
		// (set) Token: 0x06000E3D RID: 3645 RVA: 0x00009D69 File Offset: 0x00007F69
		public int TimeLimit { get; set; }

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000E3E RID: 3646 RVA: 0x00009D72 File Offset: 0x00007F72
		// (set) Token: 0x06000E3F RID: 3647 RVA: 0x00009D7A File Offset: 0x00007F7A
		public int KillLimit { get; set; }

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x00009D83 File Offset: 0x00007F83
		// (set) Token: 0x06000E41 RID: 3649 RVA: 0x00009D8B File Offset: 0x00007F8B
		public int GameFlags { get; set; }

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x00009D94 File Offset: 0x00007F94
		// (set) Token: 0x06000E43 RID: 3651 RVA: 0x00009D9C File Offset: 0x00007F9C
		public int MapID { get; set; }

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000E44 RID: 3652 RVA: 0x00009DA5 File Offset: 0x00007FA5
		// (set) Token: 0x06000E45 RID: 3653 RVA: 0x00009DAD File Offset: 0x00007FAD
		public byte LevelMin { get; set; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000E46 RID: 3654 RVA: 0x00009DB6 File Offset: 0x00007FB6
		// (set) Token: 0x06000E47 RID: 3655 RVA: 0x00009DBE File Offset: 0x00007FBE
		public byte LevelMax { get; set; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000E48 RID: 3656 RVA: 0x00009DC7 File Offset: 0x00007FC7
		// (set) Token: 0x06000E49 RID: 3657 RVA: 0x00009DCF File Offset: 0x00007FCF
		public GameModeType GameMode { get; set; }

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000E4A RID: 3658 RVA: 0x00009DD8 File Offset: 0x00007FD8
		// (set) Token: 0x06000E4B RID: 3659 RVA: 0x00009DE0 File Offset: 0x00007FE0
		public bool IsPermanentGame { get; set; }

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000E4C RID: 3660 RVA: 0x00009DE9 File Offset: 0x00007FE9
		public bool IsFull
		{
			get
			{
				return this.ConnectedPlayers >= this.PlayerLimit;
			}
		}
	}
}
