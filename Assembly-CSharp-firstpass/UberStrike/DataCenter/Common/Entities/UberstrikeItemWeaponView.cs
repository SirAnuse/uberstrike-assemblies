using System;
using System.Text;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F9 RID: 505
	public class UberstrikeItemWeaponView : UberstrikeItemView
	{
		// Token: 0x06000D83 RID: 3459 RVA: 0x00009574 File Offset: 0x00007774
		public UberstrikeItemWeaponView()
		{
		}

		// Token: 0x06000D84 RID: 3460 RVA: 0x00009747 File Offset: 0x00007947
		public UberstrikeItemWeaponView(ItemView item, int levelRequired, UberstrikeWeaponConfigView config) : base(item, levelRequired)
		{
			this.Config = config;
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000D85 RID: 3461 RVA: 0x00009758 File Offset: 0x00007958
		// (set) Token: 0x06000D86 RID: 3462 RVA: 0x00009760 File Offset: 0x00007960
		public UberstrikeWeaponConfigView Config { get; set; }

		// Token: 0x06000D87 RID: 3463 RVA: 0x0001155C File Offset: 0x0000F75C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeWeaponView: ");
			stringBuilder.Append(base.ToString());
			stringBuilder.Append(this.Config);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
