using System;
using System.Text;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F3 RID: 499
	public class UberstrikeItemGearView : UberstrikeItemView
	{
		// Token: 0x06000D4B RID: 3403 RVA: 0x00009574 File Offset: 0x00007774
		public UberstrikeItemGearView()
		{
		}

		// Token: 0x06000D4C RID: 3404 RVA: 0x0000959E File Offset: 0x0000779E
		public UberstrikeItemGearView(ItemView item, int levelRequired, UberstrikeGearConfigView config) : base(item, levelRequired)
		{
			this.Config = config;
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x000095AF File Offset: 0x000077AF
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x000095B7 File Offset: 0x000077B7
		public UberstrikeGearConfigView Config { get; set; }

		// Token: 0x06000D4F RID: 3407 RVA: 0x00010FCC File Offset: 0x0000F1CC
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeGearView: ");
			stringBuilder.Append(base.ToString());
			stringBuilder.Append(this.Config);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
