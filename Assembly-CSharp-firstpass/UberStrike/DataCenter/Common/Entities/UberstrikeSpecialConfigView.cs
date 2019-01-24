using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001FB RID: 507
	public class UberstrikeSpecialConfigView
	{
		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000D90 RID: 3472 RVA: 0x000097A1 File Offset: 0x000079A1
		// (set) Token: 0x06000D91 RID: 3473 RVA: 0x000097A9 File Offset: 0x000079A9
		public int LevelRequired { get; set; }

		// Token: 0x06000D92 RID: 3474 RVA: 0x00011624 File Offset: 0x0000F824
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeSpecialConfigView: ");
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
