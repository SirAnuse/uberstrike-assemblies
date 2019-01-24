using System;
using UberStrike.Core.Types;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000243 RID: 579
	[Serializable]
	public class UberStrikeItemQuickView : BaseUberStrikeItemView
	{
		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x0000AA7D File Offset: 0x00008C7D
		public override UberstrikeItemType ItemType
		{
			get
			{
				return UberstrikeItemType.QuickUse;
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000FD3 RID: 4051 RVA: 0x0000AA80 File Offset: 0x00008C80
		// (set) Token: 0x06000FD4 RID: 4052 RVA: 0x0000AA88 File Offset: 0x00008C88
		public int UsesPerLife { get; set; }

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000FD5 RID: 4053 RVA: 0x0000AA91 File Offset: 0x00008C91
		// (set) Token: 0x06000FD6 RID: 4054 RVA: 0x0000AA99 File Offset: 0x00008C99
		public int UsesPerRound { get; set; }

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000FD7 RID: 4055 RVA: 0x0000AAA2 File Offset: 0x00008CA2
		// (set) Token: 0x06000FD8 RID: 4056 RVA: 0x0000AAAA File Offset: 0x00008CAA
		public int UsesPerGame { get; set; }

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000FD9 RID: 4057 RVA: 0x0000AAB3 File Offset: 0x00008CB3
		// (set) Token: 0x06000FDA RID: 4058 RVA: 0x0000AABB File Offset: 0x00008CBB
		public int CoolDownTime { get; set; }

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000FDB RID: 4059 RVA: 0x0000AAC4 File Offset: 0x00008CC4
		// (set) Token: 0x06000FDC RID: 4060 RVA: 0x0000AACC File Offset: 0x00008CCC
		public int WarmUpTime { get; set; }

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000FDD RID: 4061 RVA: 0x0000AAD5 File Offset: 0x00008CD5
		// (set) Token: 0x06000FDE RID: 4062 RVA: 0x0000AADD File Offset: 0x00008CDD
		public int MaxOwnableAmount { get; set; }

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000FDF RID: 4063 RVA: 0x0000AAE6 File Offset: 0x00008CE6
		// (set) Token: 0x06000FE0 RID: 4064 RVA: 0x0000AAEE File Offset: 0x00008CEE
		public QuickItemLogic BehaviourType { get; set; }
	}
}
