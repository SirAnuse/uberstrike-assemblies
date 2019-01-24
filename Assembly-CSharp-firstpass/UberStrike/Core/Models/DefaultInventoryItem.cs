using System;
using UberStrike.Core.Types;

namespace UberStrike.Core.Models
{
	// Token: 0x020001D8 RID: 472
	public class DefaultInventoryItem
	{
		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000B80 RID: 2944 RVA: 0x00008488 File Offset: 0x00006688
		// (set) Token: 0x06000B81 RID: 2945 RVA: 0x00008490 File Offset: 0x00006690
		public int ItemId { get; set; }

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000B82 RID: 2946 RVA: 0x00008499 File Offset: 0x00006699
		// (set) Token: 0x06000B83 RID: 2947 RVA: 0x000084A1 File Offset: 0x000066A1
		public int Duration { get; set; }

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000B84 RID: 2948 RVA: 0x000084AA File Offset: 0x000066AA
		// (set) Token: 0x06000B85 RID: 2949 RVA: 0x000084B2 File Offset: 0x000066B2
		public bool DisplayToPlayer { get; set; }

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x000084BB File Offset: 0x000066BB
		// (set) Token: 0x06000B87 RID: 2951 RVA: 0x000084C3 File Offset: 0x000066C3
		public bool EquipOnAccountCreation { get; set; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x000084CC File Offset: 0x000066CC
		// (set) Token: 0x06000B89 RID: 2953 RVA: 0x000084D4 File Offset: 0x000066D4
		public LoadoutSlotType LoadoutSlot { get; set; }
	}
}
