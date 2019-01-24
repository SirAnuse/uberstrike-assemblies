using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001D9 RID: 473
	public class EsnsBasicStatisticView
	{
		// Token: 0x06000B8A RID: 2954 RVA: 0x000084DD File Offset: 0x000066DD
		public EsnsBasicStatisticView(string name, int xp, int level, int cmid)
		{
			this.Name = name;
			this.XP = xp;
			this.Level = level;
			this.Cmid = cmid;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x00008502 File Offset: 0x00006702
		public EsnsBasicStatisticView()
		{
			this.Name = string.Empty;
			this.XP = 0;
			this.Level = 0;
			this.Cmid = 0;
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0000852A File Offset: 0x0000672A
		// (set) Token: 0x06000B8D RID: 2957 RVA: 0x00008532 File Offset: 0x00006732
		public string Name { get; protected set; }

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x0000853B File Offset: 0x0000673B
		// (set) Token: 0x06000B8F RID: 2959 RVA: 0x00008543 File Offset: 0x00006743
		public int SocialRank { get; protected set; }

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x0000854C File Offset: 0x0000674C
		// (set) Token: 0x06000B91 RID: 2961 RVA: 0x00008554 File Offset: 0x00006754
		public int XP { get; protected set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0000855D File Offset: 0x0000675D
		// (set) Token: 0x06000B93 RID: 2963 RVA: 0x00008565 File Offset: 0x00006765
		public int Level { get; protected set; }

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x0000856E File Offset: 0x0000676E
		// (set) Token: 0x06000B95 RID: 2965 RVA: 0x00008576 File Offset: 0x00006776
		public int Cmid { get; protected set; }
	}
}
