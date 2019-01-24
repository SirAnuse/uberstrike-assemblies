using System;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Models
{
	// Token: 0x02000214 RID: 532
	[Synchronizable]
	[Serializable]
	public class CommActorInfo
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x000098D2 File Offset: 0x00007AD2
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x000098DA File Offset: 0x00007ADA
		public int Cmid { get; set; }

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x000098E3 File Offset: 0x00007AE3
		// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x000098EB File Offset: 0x00007AEB
		public string PlayerName { get; set; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x000098F4 File Offset: 0x00007AF4
		// (set) Token: 0x06000DC3 RID: 3523 RVA: 0x000098FC File Offset: 0x00007AFC
		public MemberAccessLevel AccessLevel { get; set; }

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x00009905 File Offset: 0x00007B05
		// (set) Token: 0x06000DC5 RID: 3525 RVA: 0x0000990D File Offset: 0x00007B0D
		public ChannelType Channel { get; set; }

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00009916 File Offset: 0x00007B16
		// (set) Token: 0x06000DC7 RID: 3527 RVA: 0x0000991E File Offset: 0x00007B1E
		public string ClanTag { get; set; }

		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00009927 File Offset: 0x00007B27
		// (set) Token: 0x06000DC9 RID: 3529 RVA: 0x0000992F File Offset: 0x00007B2F
		public GameRoom CurrentRoom { get; set; }

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00009938 File Offset: 0x00007B38
		// (set) Token: 0x06000DCB RID: 3531 RVA: 0x00009940 File Offset: 0x00007B40
		public byte ModerationFlag { get; set; }

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00009949 File Offset: 0x00007B49
		// (set) Token: 0x06000DCD RID: 3533 RVA: 0x00009951 File Offset: 0x00007B51
		public string ModInformation { get; set; }
	}
}
