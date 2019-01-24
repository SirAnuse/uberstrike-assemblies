using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000064 RID: 100
	[Serializable]
	public class MysteryBoxWonItemUnityView
	{
		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x0000398D File Offset: 0x00001B8D
		// (set) Token: 0x060002FA RID: 762 RVA: 0x00003995 File Offset: 0x00001B95
		public int ItemIdWon { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000399E File Offset: 0x00001B9E
		// (set) Token: 0x060002FC RID: 764 RVA: 0x000039A6 File Offset: 0x00001BA6
		public int CreditWon { get; set; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060002FD RID: 765 RVA: 0x000039AF File Offset: 0x00001BAF
		// (set) Token: 0x060002FE RID: 766 RVA: 0x000039B7 File Offset: 0x00001BB7
		public int PointWon { get; set; }
	}
}
