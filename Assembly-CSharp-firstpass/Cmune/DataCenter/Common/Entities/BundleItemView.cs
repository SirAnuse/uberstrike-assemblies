using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200003F RID: 63
	[Serializable]
	public class BundleItemView
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00002498 File Offset: 0x00000698
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000024A0 File Offset: 0x000006A0
		public int BundleId { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000086 RID: 134 RVA: 0x000024A9 File Offset: 0x000006A9
		// (set) Token: 0x06000087 RID: 135 RVA: 0x000024B1 File Offset: 0x000006B1
		public int ItemId { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000088 RID: 136 RVA: 0x000024BA File Offset: 0x000006BA
		// (set) Token: 0x06000089 RID: 137 RVA: 0x000024C2 File Offset: 0x000006C2
		public int Amount { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000024CB File Offset: 0x000006CB
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000024D3 File Offset: 0x000006D3
		public BuyingDurationType Duration { get; set; }
	}
}
