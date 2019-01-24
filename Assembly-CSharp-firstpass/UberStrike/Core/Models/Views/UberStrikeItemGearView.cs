using System;
using UberStrike.Core.Types;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000242 RID: 578
	[Serializable]
	public class UberStrikeItemGearView : BaseUberStrikeItemView
	{
		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000FCC RID: 4044 RVA: 0x0000AA58 File Offset: 0x00008C58
		public override UberstrikeItemType ItemType
		{
			get
			{
				return UberstrikeItemType.Gear;
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000FCD RID: 4045 RVA: 0x0000AA5B File Offset: 0x00008C5B
		// (set) Token: 0x06000FCE RID: 4046 RVA: 0x0000AA63 File Offset: 0x00008C63
		public int ArmorPoints { get; set; }

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000FCF RID: 4047 RVA: 0x0000AA6C File Offset: 0x00008C6C
		// (set) Token: 0x06000FD0 RID: 4048 RVA: 0x0000AA74 File Offset: 0x00008C74
		public int ArmorWeight { get; set; }
	}
}
