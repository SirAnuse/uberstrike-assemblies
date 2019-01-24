using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001F0 RID: 496
	public class UberstrikeFunctionalConfigView
	{
		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000D3B RID: 3387 RVA: 0x00009530 File Offset: 0x00007730
		// (set) Token: 0x06000D3C RID: 3388 RVA: 0x00009538 File Offset: 0x00007738
		public int LevelRequired { get; set; }

		// Token: 0x06000D3D RID: 3389 RVA: 0x00010EF4 File Offset: 0x0000F0F4
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeFunctionalConfigView: ");
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
