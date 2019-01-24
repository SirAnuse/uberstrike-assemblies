using System;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001D7 RID: 471
	[Serializable]
	public class DailyPointsView
	{
		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x00008455 File Offset: 0x00006655
		// (set) Token: 0x06000B7A RID: 2938 RVA: 0x0000845D File Offset: 0x0000665D
		public int Current { get; set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x00008466 File Offset: 0x00006666
		// (set) Token: 0x06000B7C RID: 2940 RVA: 0x0000846E File Offset: 0x0000666E
		public int PointsTomorrow { get; set; }

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x00008477 File Offset: 0x00006677
		// (set) Token: 0x06000B7E RID: 2942 RVA: 0x0000847F File Offset: 0x0000667F
		public int PointsMax { get; set; }
	}
}
