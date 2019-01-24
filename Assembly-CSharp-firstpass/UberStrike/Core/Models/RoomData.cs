using System;

namespace UberStrike.Core.Models
{
	// Token: 0x02000227 RID: 551
	public class RoomData
	{
		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000E5E RID: 3678 RVA: 0x00009E73 File Offset: 0x00008073
		// (set) Token: 0x06000E5F RID: 3679 RVA: 0x00009E7B File Offset: 0x0000807B
		public string Guid { get; set; }

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000E60 RID: 3680 RVA: 0x00009E84 File Offset: 0x00008084
		// (set) Token: 0x06000E61 RID: 3681 RVA: 0x00009E8C File Offset: 0x0000808C
		public string Name { get; set; }

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000E62 RID: 3682 RVA: 0x00009E95 File Offset: 0x00008095
		// (set) Token: 0x06000E63 RID: 3683 RVA: 0x00009E9D File Offset: 0x0000809D
		public ConnectionAddress Server { get; set; }

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000E64 RID: 3684 RVA: 0x00009EA6 File Offset: 0x000080A6
		// (set) Token: 0x06000E65 RID: 3685 RVA: 0x00009EAE File Offset: 0x000080AE
		public int Number { get; set; }

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x00009EB7 File Offset: 0x000080B7
		// (set) Token: 0x06000E67 RID: 3687 RVA: 0x00009EBF File Offset: 0x000080BF
		public bool IsPasswordProtected { get; set; }
	}
}
