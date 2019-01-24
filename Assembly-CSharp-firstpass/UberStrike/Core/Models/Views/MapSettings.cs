using System;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000237 RID: 567
	[Serializable]
	public class MapSettings
	{
		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000F58 RID: 3928 RVA: 0x0000A6D9 File Offset: 0x000088D9
		// (set) Token: 0x06000F59 RID: 3929 RVA: 0x0000A6E1 File Offset: 0x000088E1
		public int KillsMin { get; set; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0000A6EA File Offset: 0x000088EA
		// (set) Token: 0x06000F5B RID: 3931 RVA: 0x0000A6F2 File Offset: 0x000088F2
		public int KillsMax { get; set; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000F5C RID: 3932 RVA: 0x0000A6FB File Offset: 0x000088FB
		// (set) Token: 0x06000F5D RID: 3933 RVA: 0x0000A703 File Offset: 0x00008903
		public int KillsCurrent { get; set; }

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000F5E RID: 3934 RVA: 0x0000A70C File Offset: 0x0000890C
		// (set) Token: 0x06000F5F RID: 3935 RVA: 0x0000A714 File Offset: 0x00008914
		public int PlayersMin { get; set; }

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000F60 RID: 3936 RVA: 0x0000A71D File Offset: 0x0000891D
		// (set) Token: 0x06000F61 RID: 3937 RVA: 0x0000A725 File Offset: 0x00008925
		public int PlayersMax { get; set; }

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000F62 RID: 3938 RVA: 0x0000A72E File Offset: 0x0000892E
		// (set) Token: 0x06000F63 RID: 3939 RVA: 0x0000A736 File Offset: 0x00008936
		public int PlayersCurrent { get; set; }

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000F64 RID: 3940 RVA: 0x0000A73F File Offset: 0x0000893F
		// (set) Token: 0x06000F65 RID: 3941 RVA: 0x0000A747 File Offset: 0x00008947
		public int TimeMin { get; set; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000F66 RID: 3942 RVA: 0x0000A750 File Offset: 0x00008950
		// (set) Token: 0x06000F67 RID: 3943 RVA: 0x0000A758 File Offset: 0x00008958
		public int TimeMax { get; set; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000F68 RID: 3944 RVA: 0x0000A761 File Offset: 0x00008961
		// (set) Token: 0x06000F69 RID: 3945 RVA: 0x0000A769 File Offset: 0x00008969
		public int TimeCurrent { get; set; }

        public bool QuickSwitching { get; set; }
	}
}
