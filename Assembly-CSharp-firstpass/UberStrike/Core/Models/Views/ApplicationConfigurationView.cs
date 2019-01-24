using System;
using System.Collections.Generic;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x0200022E RID: 558
	[Serializable]
	public class ApplicationConfigurationView
	{
		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x0000A2B4 File Offset: 0x000084B4
		// (set) Token: 0x06000ED4 RID: 3796 RVA: 0x0000A2BC File Offset: 0x000084BC
		public Dictionary<int, int> XpRequiredPerLevel { get; set; }

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x0000A2C5 File Offset: 0x000084C5
		// (set) Token: 0x06000ED6 RID: 3798 RVA: 0x0000A2CD File Offset: 0x000084CD
		public int MaxLevel { get; set; }

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x0000A2D6 File Offset: 0x000084D6
		// (set) Token: 0x06000ED8 RID: 3800 RVA: 0x0000A2DE File Offset: 0x000084DE
		public int MaxXp { get; set; }

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x0000A2E7 File Offset: 0x000084E7
		// (set) Token: 0x06000EDA RID: 3802 RVA: 0x0000A2EF File Offset: 0x000084EF
		public int XpKill { get; set; }

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000EDB RID: 3803 RVA: 0x0000A2F8 File Offset: 0x000084F8
		// (set) Token: 0x06000EDC RID: 3804 RVA: 0x0000A300 File Offset: 0x00008500
		public int XpSmackdown { get; set; }

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000EDD RID: 3805 RVA: 0x0000A309 File Offset: 0x00008509
		// (set) Token: 0x06000EDE RID: 3806 RVA: 0x0000A311 File Offset: 0x00008511
		public int XpHeadshot { get; set; }

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000EDF RID: 3807 RVA: 0x0000A31A File Offset: 0x0000851A
		// (set) Token: 0x06000EE0 RID: 3808 RVA: 0x0000A322 File Offset: 0x00008522
		public int XpNutshot { get; set; }

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000EE1 RID: 3809 RVA: 0x0000A32B File Offset: 0x0000852B
		// (set) Token: 0x06000EE2 RID: 3810 RVA: 0x0000A333 File Offset: 0x00008533
		public int XpPerMinuteLoser { get; set; }

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000EE3 RID: 3811 RVA: 0x0000A33C File Offset: 0x0000853C
		// (set) Token: 0x06000EE4 RID: 3812 RVA: 0x0000A344 File Offset: 0x00008544
		public int XpPerMinuteWinner { get; set; }

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000EE5 RID: 3813 RVA: 0x0000A34D File Offset: 0x0000854D
		// (set) Token: 0x06000EE6 RID: 3814 RVA: 0x0000A355 File Offset: 0x00008555
		public int XpBaseLoser { get; set; }

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x0000A35E File Offset: 0x0000855E
		// (set) Token: 0x06000EE8 RID: 3816 RVA: 0x0000A366 File Offset: 0x00008566
		public int XpBaseWinner { get; set; }

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06000EE9 RID: 3817 RVA: 0x0000A36F File Offset: 0x0000856F
		// (set) Token: 0x06000EEA RID: 3818 RVA: 0x0000A377 File Offset: 0x00008577
		public int PointsKill { get; set; }

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000EEB RID: 3819 RVA: 0x0000A380 File Offset: 0x00008580
		// (set) Token: 0x06000EEC RID: 3820 RVA: 0x0000A388 File Offset: 0x00008588
		public int PointsSmackdown { get; set; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000EED RID: 3821 RVA: 0x0000A391 File Offset: 0x00008591
		// (set) Token: 0x06000EEE RID: 3822 RVA: 0x0000A399 File Offset: 0x00008599
		public int PointsHeadshot { get; set; }

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000EEF RID: 3823 RVA: 0x0000A3A2 File Offset: 0x000085A2
		// (set) Token: 0x06000EF0 RID: 3824 RVA: 0x0000A3AA File Offset: 0x000085AA
		public int PointsNutshot { get; set; }

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000EF1 RID: 3825 RVA: 0x0000A3B3 File Offset: 0x000085B3
		// (set) Token: 0x06000EF2 RID: 3826 RVA: 0x0000A3BB File Offset: 0x000085BB
		public int PointsPerMinuteLoser { get; set; }

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x0000A3C4 File Offset: 0x000085C4
		// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x0000A3CC File Offset: 0x000085CC
		public int PointsPerMinuteWinner { get; set; }

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x0000A3D5 File Offset: 0x000085D5
		// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x0000A3DD File Offset: 0x000085DD
		public int PointsBaseLoser { get; set; }

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x0000A3E6 File Offset: 0x000085E6
		// (set) Token: 0x06000EF8 RID: 3832 RVA: 0x0000A3EE File Offset: 0x000085EE
		public int PointsBaseWinner { get; set; }
	}
}
