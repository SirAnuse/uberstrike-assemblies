using System;
using System.Text;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F2 RID: 498
	public class UberstrikeItemFunctionalView : UberstrikeItemView
	{
		// Token: 0x06000D46 RID: 3398 RVA: 0x00009574 File Offset: 0x00007774
		public UberstrikeItemFunctionalView()
		{
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0000957C File Offset: 0x0000777C
		public UberstrikeItemFunctionalView(ItemView item, int levelRequired, UberstrikeFunctionalConfigView config) : base(item, levelRequired)
		{
			this.Config = config;
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x0000958D File Offset: 0x0000778D
		// (set) Token: 0x06000D49 RID: 3401 RVA: 0x00009595 File Offset: 0x00007795
		public UberstrikeFunctionalConfigView Config { get; set; }

		// Token: 0x06000D4A RID: 3402 RVA: 0x00010F80 File Offset: 0x0000F180
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeFunctionalView: ");
			stringBuilder.Append(base.ToString());
			stringBuilder.Append(this.Config);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
