using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Types;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F4 RID: 500
	public class UberstrikeItemQuickUseView : UberstrikeItemView
	{
		// Token: 0x06000D50 RID: 3408 RVA: 0x00009574 File Offset: 0x00007774
		public UberstrikeItemQuickUseView()
		{
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x000095C0 File Offset: 0x000077C0
		public UberstrikeItemQuickUseView(ItemView item, int levelRequired) : base(item, levelRequired)
		{
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x000095CA File Offset: 0x000077CA
		public UberstrikeItemQuickUseView(ItemView item, int levelRequired, ItemQuickUseConfigView Config) : base(item, levelRequired)
		{
			this.Config = Config;
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000D53 RID: 3411 RVA: 0x000095DB File Offset: 0x000077DB
		// (set) Token: 0x06000D54 RID: 3412 RVA: 0x000095E3 File Offset: 0x000077E3
		public ItemQuickUseConfigView Config { get; set; }

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06000D55 RID: 3413 RVA: 0x000095EC File Offset: 0x000077EC
		// (set) Token: 0x06000D56 RID: 3414 RVA: 0x000095F4 File Offset: 0x000077F4
		public QuickItemLogic Logic { get; set; }
	}
}
