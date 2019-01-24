using System;

namespace Cmune.Core.Models
{
	// Token: 0x02000067 RID: 103
	[Serializable]
	public class PhotonServerLoad
	{
		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000314 RID: 788 RVA: 0x00003AD3 File Offset: 0x00001CD3
		// (set) Token: 0x06000315 RID: 789 RVA: 0x00003ADB File Offset: 0x00001CDB
		public int PeersConnected { get; set; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00003AE4 File Offset: 0x00001CE4
		// (set) Token: 0x06000317 RID: 791 RVA: 0x00003AEC File Offset: 0x00001CEC
		public int PlayersConnected { get; set; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000318 RID: 792 RVA: 0x00003AF5 File Offset: 0x00001CF5
		// (set) Token: 0x06000319 RID: 793 RVA: 0x00003AFD File Offset: 0x00001CFD
		public int RoomsCreated { get; set; }

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600031A RID: 794 RVA: 0x00003B06 File Offset: 0x00001D06
		// (set) Token: 0x0600031B RID: 795 RVA: 0x00003B0E File Offset: 0x00001D0E
		public float MaxPlayerCount { get; set; }

		// Token: 0x040002C6 RID: 710
		public int Latency;

		// Token: 0x040002C7 RID: 711
		public DateTime TimeStamp;

		// Token: 0x040002C8 RID: 712
		public PhotonServerLoad.Status State;

		// Token: 0x02000068 RID: 104
		public enum Status
		{
			// Token: 0x040002CE RID: 718
			None,
			// Token: 0x040002CF RID: 719
			Alive,
			// Token: 0x040002D0 RID: 720
			NotReachable
		}
	}
}
