using System;
using System.Text;

namespace UberStrike.DataCenter.Common.Entities
{
	// Token: 0x020001FD RID: 509
	public class UberstrikeWeaponModConfigView
	{
		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x000098B1 File Offset: 0x00007AB1
		// (set) Token: 0x06000DB6 RID: 3510 RVA: 0x000098B9 File Offset: 0x00007AB9
		public int LevelRequired { get; set; }

		// Token: 0x06000DB7 RID: 3511 RVA: 0x0001185C File Offset: 0x0000FA5C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[UberstrikeWeaponModConfigView: ");
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
