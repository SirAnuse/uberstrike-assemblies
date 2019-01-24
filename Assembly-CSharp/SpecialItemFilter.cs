using System;
using UberStrike.Core.Types;

// Token: 0x020001F8 RID: 504
public class SpecialItemFilter : IShopItemFilter
{
	// Token: 0x06000E26 RID: 3622 RVA: 0x0000A504 File Offset: 0x00008704
	public bool CanPass(IUnityItem item)
	{
		return item.View.ShopHighlightType != ItemShopHighlightType.None;
	}
}
