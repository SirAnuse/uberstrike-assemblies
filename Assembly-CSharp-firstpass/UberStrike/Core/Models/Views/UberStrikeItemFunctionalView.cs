using System;
using UberStrike.Core.Types;

namespace UberStrike.Core.Models.Views
{
	// Token: 0x02000241 RID: 577
	[Serializable]
	public class UberStrikeItemFunctionalView : BaseUberStrikeItemView
	{
		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x0000AA55 File Offset: 0x00008C55
		public override UberstrikeItemType ItemType
		{
			get
			{
				return UberstrikeItemType.Functional;
			}
		}
	}
}
