using System;
using UnityEngine;

// Token: 0x020001F3 RID: 499
public interface IShopItemGUI
{
	// Token: 0x17000365 RID: 869
	// (get) Token: 0x06000E19 RID: 3609
	IUnityItem Item { get; }

	// Token: 0x06000E1A RID: 3610
	void Draw(Rect rect, bool selected);
}
