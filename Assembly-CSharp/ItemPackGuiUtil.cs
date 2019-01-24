using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;

// Token: 0x020001F5 RID: 501
public static class ItemPackGuiUtil
{
	// Token: 0x06000E21 RID: 3617 RVA: 0x00060FD8 File Offset: 0x0005F1D8
	public static BuyingDurationType GetDuration(IUnityItem item)
	{
		BuyingDurationType result = BuyingDurationType.None;
		if (item != null && item.View != null && item.View.Prices != null)
		{
			IEnumerator<ItemPrice> enumerator = item.View.Prices.GetEnumerator();
			if (enumerator.MoveNext())
			{
				result = enumerator.Current.Duration;
			}
		}
		return result;
	}

	// Token: 0x04000D18 RID: 3352
	public const int Columns = 6;

	// Token: 0x04000D19 RID: 3353
	public const int Rows = 2;
}
