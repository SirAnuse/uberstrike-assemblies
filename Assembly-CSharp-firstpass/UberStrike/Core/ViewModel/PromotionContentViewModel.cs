using System;
using System.Collections.Generic;

namespace UberStrike.Core.ViewModel
{
	// Token: 0x0200023F RID: 575
	public class PromotionContentViewModel
	{
		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x0000A9C5 File Offset: 0x00008BC5
		// (set) Token: 0x06000FB9 RID: 4025 RVA: 0x0000A9CD File Offset: 0x00008BCD
		public int PromotionContentId { get; set; }

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000FBA RID: 4026 RVA: 0x0000A9D6 File Offset: 0x00008BD6
		// (set) Token: 0x06000FBB RID: 4027 RVA: 0x0000A9DE File Offset: 0x00008BDE
		public string Name { get; set; }

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000FBC RID: 4028 RVA: 0x0000A9E7 File Offset: 0x00008BE7
		// (set) Token: 0x06000FBD RID: 4029 RVA: 0x0000A9EF File Offset: 0x00008BEF
		public DateTime StartDate { get; set; }

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000FBE RID: 4030 RVA: 0x0000A9F8 File Offset: 0x00008BF8
		// (set) Token: 0x06000FBF RID: 4031 RVA: 0x0000AA00 File Offset: 0x00008C00
		public DateTime EndDate { get; set; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000FC0 RID: 4032 RVA: 0x0000AA09 File Offset: 0x00008C09
		// (set) Token: 0x06000FC1 RID: 4033 RVA: 0x0000AA11 File Offset: 0x00008C11
		public bool IsPermanent { get; set; }

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000FC2 RID: 4034 RVA: 0x0000AA1A File Offset: 0x00008C1A
		// (set) Token: 0x06000FC3 RID: 4035 RVA: 0x0000AA22 File Offset: 0x00008C22
		public List<PromotionContentElementViewModel> PromotionContentElements { get; set; }
	}
}
