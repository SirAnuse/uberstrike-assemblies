using System;
using UberStrike.Core.Types;

// Token: 0x020001F9 RID: 505
public class ItemByTypeFilter : IShopItemFilter
{
	// Token: 0x06000E27 RID: 3623 RVA: 0x0000A517 File Offset: 0x00008717
	public ItemByTypeFilter(UberstrikeItemType itemType)
	{
		this._itemType = itemType;
	}

	// Token: 0x06000E28 RID: 3624 RVA: 0x0000A526 File Offset: 0x00008726
	public bool CanPass(IUnityItem item)
	{
		return item.View.ItemType == this._itemType;
	}

	// Token: 0x04000D1A RID: 3354
	private UberstrikeItemType _itemType;
}
