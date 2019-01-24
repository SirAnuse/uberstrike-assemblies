using System;
using Cmune.DataCenter.Common.Entities;

namespace Cmune.Core.Models.Views
{
	// Token: 0x02000069 RID: 105
	[Serializable]
	public class PhotonView
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00003B17 File Offset: 0x00001D17
		// (set) Token: 0x0600031E RID: 798 RVA: 0x00003B1F File Offset: 0x00001D1F
		public int PhotonId { get; set; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00003B28 File Offset: 0x00001D28
		// (set) Token: 0x06000320 RID: 800 RVA: 0x00003B30 File Offset: 0x00001D30
		public string IP { get; set; }

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000321 RID: 801 RVA: 0x00003B39 File Offset: 0x00001D39
		// (set) Token: 0x06000322 RID: 802 RVA: 0x00003B41 File Offset: 0x00001D41
		public string Name { get; set; }

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000323 RID: 803 RVA: 0x00003B4A File Offset: 0x00001D4A
		// (set) Token: 0x06000324 RID: 804 RVA: 0x00003B52 File Offset: 0x00001D52
		public RegionType Region { get; set; }

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000325 RID: 805 RVA: 0x00003B5B File Offset: 0x00001D5B
		// (set) Token: 0x06000326 RID: 806 RVA: 0x00003B63 File Offset: 0x00001D63
		public int Port { get; set; }

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00003B6C File Offset: 0x00001D6C
		// (set) Token: 0x06000328 RID: 808 RVA: 0x00003B74 File Offset: 0x00001D74
		public PhotonUsageType UsageType { get; set; }

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00003B7D File Offset: 0x00001D7D
		// (set) Token: 0x0600032A RID: 810 RVA: 0x00003B85 File Offset: 0x00001D85
		public int MinLatency { get; set; }
	}
}
