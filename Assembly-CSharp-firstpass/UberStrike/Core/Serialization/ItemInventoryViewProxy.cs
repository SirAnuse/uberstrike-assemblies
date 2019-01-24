using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200025E RID: 606
	public static class ItemInventoryViewProxy
	{
		// Token: 0x06001053 RID: 4179 RVA: 0x000139A0 File Offset: 0x00011BA0
		public static void Serialize(Stream stream, ItemInventoryView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.AmountRemaining);
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				if (instance.ExpirationDate != null)
				{
					Stream bytes = memoryStream;
					DateTime? expirationDate = instance.ExpirationDate;
					DateTimeProxy.Serialize(bytes, (expirationDate == null) ? default(DateTime) : expirationDate.Value);
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.ItemId);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x00013A58 File Offset: 0x00011C58
		public static ItemInventoryView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ItemInventoryView itemInventoryView = new ItemInventoryView();
			itemInventoryView.AmountRemaining = Int32Proxy.Deserialize(bytes);
			itemInventoryView.Cmid = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				itemInventoryView.ExpirationDate = new DateTime?(DateTimeProxy.Deserialize(bytes));
			}
			itemInventoryView.ItemId = Int32Proxy.Deserialize(bytes);
			return itemInventoryView;
		}
	}
}
