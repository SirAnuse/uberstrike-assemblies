using System;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000235 RID: 565
	[Serializable]
	public class ItemPrice
	{
		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x0000A646 File Offset: 0x00008846
		// (set) Token: 0x06000F46 RID: 3910 RVA: 0x0000A64E File Offset: 0x0000884E
		public int Price { get; set; }

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x0000A657 File Offset: 0x00008857
		// (set) Token: 0x06000F48 RID: 3912 RVA: 0x0000A65F File Offset: 0x0000885F
		public UberStrikeCurrencyType Currency { get; set; }

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x0000A668 File Offset: 0x00008868
		// (set) Token: 0x06000F4A RID: 3914 RVA: 0x0000A670 File Offset: 0x00008870
		public int Discount { get; set; }

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000F4B RID: 3915 RVA: 0x0000A679 File Offset: 0x00008879
		// (set) Token: 0x06000F4C RID: 3916 RVA: 0x0000A681 File Offset: 0x00008881
		public int Amount { get; set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x0000A68A File Offset: 0x0000888A
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x0000A692 File Offset: 0x00008892
		public PackType PackType { get; set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x0000A69B File Offset: 0x0000889B
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x0000A6A3 File Offset: 0x000088A3
		public BuyingDurationType Duration { get; set; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000F51 RID: 3921 RVA: 0x0000A6AC File Offset: 0x000088AC
		public bool IsConsumable
		{
			get
			{
				return this.Amount > 0;
			}
		}
	}
}
