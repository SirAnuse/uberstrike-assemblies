using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001ED RID: 493
	public class RankingView
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000D14 RID: 3348 RVA: 0x000093C2 File Offset: 0x000075C2
		// (set) Token: 0x06000D15 RID: 3349 RVA: 0x000093CA File Offset: 0x000075CA
		public int Cmid { get; set; }

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000D16 RID: 3350 RVA: 0x000093D3 File Offset: 0x000075D3
		// (set) Token: 0x06000D17 RID: 3351 RVA: 0x000093DB File Offset: 0x000075DB
		public long Rank { get; set; }

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000D18 RID: 3352 RVA: 0x000093E4 File Offset: 0x000075E4
		// (set) Token: 0x06000D19 RID: 3353 RVA: 0x000093EC File Offset: 0x000075EC
		public string ClanTag { get; set; }

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000D1A RID: 3354 RVA: 0x000093F5 File Offset: 0x000075F5
		// (set) Token: 0x06000D1B RID: 3355 RVA: 0x000093FD File Offset: 0x000075FD
		public string Name { get; set; }

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000D1C RID: 3356 RVA: 0x00009406 File Offset: 0x00007606
		// (set) Token: 0x06000D1D RID: 3357 RVA: 0x0000940E File Offset: 0x0000760E
		public int Xp { get; set; }

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000D1E RID: 3358 RVA: 0x00009417 File Offset: 0x00007617
		// (set) Token: 0x06000D1F RID: 3359 RVA: 0x0000941F File Offset: 0x0000761F
		public int Level { get; set; }

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000D20 RID: 3360 RVA: 0x00009428 File Offset: 0x00007628
		// (set) Token: 0x06000D21 RID: 3361 RVA: 0x00009430 File Offset: 0x00007630
		public int Kills { get; set; }

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000D22 RID: 3362 RVA: 0x00009439 File Offset: 0x00007639
		// (set) Token: 0x06000D23 RID: 3363 RVA: 0x00009441 File Offset: 0x00007641
		public int Deaths { get; set; }

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000D24 RID: 3364 RVA: 0x0000944A File Offset: 0x0000764A
		// (set) Token: 0x06000D25 RID: 3365 RVA: 0x00009452 File Offset: 0x00007652
		public decimal Kdr { get; set; }

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000D26 RID: 3366 RVA: 0x0000945B File Offset: 0x0000765B
		// (set) Token: 0x06000D27 RID: 3367 RVA: 0x00009463 File Offset: 0x00007663
		public string DebugInformation { get; set; }
	}
}
