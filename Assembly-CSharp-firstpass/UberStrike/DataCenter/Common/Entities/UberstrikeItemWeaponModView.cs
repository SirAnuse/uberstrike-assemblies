using System;
using System.Text;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F8 RID: 504
	public class UberstrikeItemWeaponModView : UberstrikeItemView
	{
		// Token: 0x06000D7E RID: 3454 RVA: 0x00009574 File Offset: 0x00007774
		public UberstrikeItemWeaponModView()
		{
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x00009725 File Offset: 0x00007925
		public UberstrikeItemWeaponModView(ItemView item, int level, UberstrikeWeaponModConfigView config) : base(item, level)
		{
			this.Config = config;
		}

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000D80 RID: 3456 RVA: 0x00009736 File Offset: 0x00007936
		// (set) Token: 0x06000D81 RID: 3457 RVA: 0x0000973E File Offset: 0x0000793E
		public UberstrikeWeaponModConfigView Config { get; set; }

		// Token: 0x06000D82 RID: 3458 RVA: 0x00011510 File Offset: 0x0000F710
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeWeaponModView: ");
			stringBuilder.Append(base.ToString());
			stringBuilder.Append(this.Config);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
