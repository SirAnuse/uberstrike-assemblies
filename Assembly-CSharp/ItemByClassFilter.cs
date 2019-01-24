using System;
using UberStrike.Core.Types;

// Token: 0x020001FA RID: 506
public class ItemByClassFilter : IShopItemFilter
{
	// Token: 0x06000E29 RID: 3625 RVA: 0x0000A53B File Offset: 0x0000873B
	public ItemByClassFilter(UberstrikeItemType itemType, UberstrikeItemClass itemClass)
	{
		this._itemType = itemType;
		this._itemClass = itemClass;
	}

	// Token: 0x06000E2A RID: 3626 RVA: 0x0000A551 File Offset: 0x00008751
	public bool CanPass(IUnityItem item)
	{
		return item.View.ItemType == this._itemType && item.View.ItemClass == this._itemClass;
	}

	// Token: 0x04000D1B RID: 3355
	private UberstrikeItemType _itemType;

	// Token: 0x04000D1C RID: 3356
	private UberstrikeItemClass _itemClass;
}
