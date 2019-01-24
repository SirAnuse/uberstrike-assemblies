using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000057 RID: 87
	public class LuckyDrawSetView
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000312B File Offset: 0x0000132B
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00003133 File Offset: 0x00001333
		public int Id { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0000313C File Offset: 0x0000133C
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00003144 File Offset: 0x00001344
		public int SetWeight { get; set; }

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000314D File Offset: 0x0000134D
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00003155 File Offset: 0x00001355
		public int CreditsAttributed { get; set; }

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000315E File Offset: 0x0000135E
		// (set) Token: 0x0600020B RID: 523 RVA: 0x00003166 File Offset: 0x00001366
		public int PointsAttributed { get; set; }

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x0600020C RID: 524 RVA: 0x0000316F File Offset: 0x0000136F
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00003177 File Offset: 0x00001377
		public string ImageUrl { get; set; }

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00003180 File Offset: 0x00001380
		// (set) Token: 0x0600020F RID: 527 RVA: 0x00003188 File Offset: 0x00001388
		public bool ExposeItemsToPlayers { get; set; }

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00003191 File Offset: 0x00001391
		// (set) Token: 0x06000211 RID: 529 RVA: 0x00003199 File Offset: 0x00001399
		public int LuckyDrawId { get; set; }

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000212 RID: 530 RVA: 0x000031A2 File Offset: 0x000013A2
		// (set) Token: 0x06000213 RID: 531 RVA: 0x000031AA File Offset: 0x000013AA
		public List<LuckyDrawSetItemView> LuckyDrawSetItems { get; set; }
	}
}
