using System;

namespace Cmune.DataCenter.Common.Entities
{
	// Token: 0x02000042 RID: 66
	[Serializable]
	public class ClaimFacebookGiftView
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00002050 File Offset: 0x00000250
		public ClaimFacebookGiftView()
		{
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00002668 File Offset: 0x00000868
		public ClaimFacebookGiftView(ClaimFacebookGiftResult _claimResult, int? _itemId)
		{
			this.ClaimResult = _claimResult;
			this.ItemId = _itemId;
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0000267E File Offset: 0x0000087E
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00002686 File Offset: 0x00000886
		public ClaimFacebookGiftResult ClaimResult { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x0000268F File Offset: 0x0000088F
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00002697 File Offset: 0x00000897
		public int? ItemId { get; set; }
	}
}
