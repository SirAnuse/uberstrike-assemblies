using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F1 RID: 497
	public class UberstrikeGearConfigView
	{
		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000D3F RID: 3391 RVA: 0x00009541 File Offset: 0x00007741
		// (set) Token: 0x06000D40 RID: 3392 RVA: 0x00009549 File Offset: 0x00007749
		public int ArmorPoints { get; set; }

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000D41 RID: 3393 RVA: 0x00009552 File Offset: 0x00007752
		// (set) Token: 0x06000D42 RID: 3394 RVA: 0x0000955A File Offset: 0x0000775A
		public int ArmorWeight { get; set; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000D43 RID: 3395 RVA: 0x00009563 File Offset: 0x00007763
		// (set) Token: 0x06000D44 RID: 3396 RVA: 0x0000956B File Offset: 0x0000776B
		public int LevelRequired { get; set; }

		// Token: 0x06000D45 RID: 3397 RVA: 0x00010F28 File Offset: 0x0000F128
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeGearConfigView: [ArmorPoints: ");
			stringBuilder.Append(this.ArmorPoints);
			stringBuilder.Append("][ArmorWeight: ");
			stringBuilder.Append(this.ArmorWeight);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
