using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000061 RID: 97
	public class MysteryBoxItemView
	{
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x000036F6 File Offset: 0x000018F6
		// (set) Token: 0x060002A9 RID: 681 RVA: 0x000036FE File Offset: 0x000018FE
		public int Id { get; set; }

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060002AA RID: 682 RVA: 0x00003707 File Offset: 0x00001907
		// (set) Token: 0x060002AB RID: 683 RVA: 0x0000370F File Offset: 0x0000190F
		public int ItemId { get; set; }

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00003718 File Offset: 0x00001918
		// (set) Token: 0x060002AD RID: 685 RVA: 0x00003720 File Offset: 0x00001920
		public string Name { get; set; }

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060002AE RID: 686 RVA: 0x00003729 File Offset: 0x00001929
		// (set) Token: 0x060002AF RID: 687 RVA: 0x00003731 File Offset: 0x00001931
		public int Amount { get; set; }

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x0000373A File Offset: 0x0000193A
		// (set) Token: 0x060002B1 RID: 689 RVA: 0x00003742 File Offset: 0x00001942
		public BuyingDurationType DurationType { get; set; }

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000374B File Offset: 0x0000194B
		// (set) Token: 0x060002B3 RID: 691 RVA: 0x00003753 File Offset: 0x00001953
		public int ItemWeight { get; set; }

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x0000375C File Offset: 0x0000195C
		// (set) Token: 0x060002B5 RID: 693 RVA: 0x00003764 File Offset: 0x00001964
		public int MysteryBoxId { get; set; }
	}
}
