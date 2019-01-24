using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x0200005F RID: 95
	[Serializable]
	public class MessageThreadView
	{
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000286 RID: 646 RVA: 0x000035E6 File Offset: 0x000017E6
		// (set) Token: 0x06000287 RID: 647 RVA: 0x000035EE File Offset: 0x000017EE
		public int ThreadId { get; set; }

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000288 RID: 648 RVA: 0x000035F7 File Offset: 0x000017F7
		// (set) Token: 0x06000289 RID: 649 RVA: 0x000035FF File Offset: 0x000017FF
		public string ThreadName { get; set; }

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00003608 File Offset: 0x00001808
		// (set) Token: 0x0600028B RID: 651 RVA: 0x00003610 File Offset: 0x00001810
		public bool HasNewMessages { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600028C RID: 652 RVA: 0x00003619 File Offset: 0x00001819
		// (set) Token: 0x0600028D RID: 653 RVA: 0x00003621 File Offset: 0x00001821
		public int MessageCount { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000362A File Offset: 0x0000182A
		// (set) Token: 0x0600028F RID: 655 RVA: 0x00003632 File Offset: 0x00001832
		public string LastMessagePreview { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000363B File Offset: 0x0000183B
		// (set) Token: 0x06000291 RID: 657 RVA: 0x00003643 File Offset: 0x00001843
		public DateTime LastUpdate { get; set; }
	}
}
