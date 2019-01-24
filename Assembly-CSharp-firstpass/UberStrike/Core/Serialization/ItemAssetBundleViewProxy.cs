using System;
using System.IO;
using UberStrike.Core.Models.Views;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002A7 RID: 679
	public static class ItemAssetBundleViewProxy
	{
		// Token: 0x060010F1 RID: 4337 RVA: 0x00019228 File Offset: 0x00017428
		public static void Serialize(Stream stream, ItemAssetBundleView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.Url != null)
				{
					StringProxy.Serialize(memoryStream, instance.Url);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x00019290 File Offset: 0x00017490
		public static ItemAssetBundleView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ItemAssetBundleView itemAssetBundleView = new ItemAssetBundleView();
			if ((num & 1) != 0)
			{
				itemAssetBundleView.Url = StringProxy.Deserialize(bytes);
			}
			return itemAssetBundleView;
		}
	}
}
