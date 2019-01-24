using System;
using System.Collections.Generic;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000065 RID: 101
	[Serializable]
	public class PackageView
	{
		// Token: 0x060002FF RID: 767 RVA: 0x000039C0 File Offset: 0x00001BC0
		public PackageView()
		{
			this.Bonus = 0;
			this.Price = 0m;
			this.Items = new List<int>();
			this.Name = string.Empty;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000039F1 File Offset: 0x00001BF1
		public PackageView(int bonus, decimal price, List<int> items, string name)
		{
			this.Bonus = bonus;
			this.Price = price;
			this.Items = items;
			this.Name = name;
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000301 RID: 769 RVA: 0x00003A16 File Offset: 0x00001C16
		// (set) Token: 0x06000302 RID: 770 RVA: 0x00003A1E File Offset: 0x00001C1E
		public int Bonus { get; set; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000303 RID: 771 RVA: 0x00003A27 File Offset: 0x00001C27
		// (set) Token: 0x06000304 RID: 772 RVA: 0x00003A2F File Offset: 0x00001C2F
		public decimal Price { get; set; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000305 RID: 773 RVA: 0x00003A38 File Offset: 0x00001C38
		// (set) Token: 0x06000306 RID: 774 RVA: 0x00003A40 File Offset: 0x00001C40
		public List<int> Items { get; set; }

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000307 RID: 775 RVA: 0x00003A49 File Offset: 0x00001C49
		// (set) Token: 0x06000308 RID: 776 RVA: 0x00003A51 File Offset: 0x00001C51
		public string Name { get; set; }
	}
}
