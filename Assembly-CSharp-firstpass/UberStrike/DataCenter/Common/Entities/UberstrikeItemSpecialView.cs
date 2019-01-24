using System;
using System.Text;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F6 RID: 502
	public class UberstrikeItemSpecialView : UberstrikeItemView
	{
		// Token: 0x06000D74 RID: 3444 RVA: 0x00009574 File Offset: 0x00007774
		public UberstrikeItemSpecialView()
		{
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x000096DA File Offset: 0x000078DA
		public UberstrikeItemSpecialView(ItemView item, int levelRequired, UberstrikeSpecialConfigView config) : base(item, levelRequired)
		{
			this.Config = config;
		}

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x06000D76 RID: 3446 RVA: 0x000096EB File Offset: 0x000078EB
		// (set) Token: 0x06000D77 RID: 3447 RVA: 0x000096F3 File Offset: 0x000078F3
		public UberstrikeSpecialConfigView Config { get; set; }

		// Token: 0x06000D78 RID: 3448 RVA: 0x0001146C File Offset: 0x0000F66C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeSpecialView: ");
			stringBuilder.Append(base.ToString());
			stringBuilder.Append(this.Config);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
