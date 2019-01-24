using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002B5 RID: 693
	public static class ItemTransactionsViewModelProxy
	{
		// Token: 0x0600110D RID: 4365 RVA: 0x0001A9AC File Offset: 0x00018BAC
		public static void Serialize(Stream stream, ItemTransactionsViewModel instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.ItemTransactions != null)
				{
					ListProxy<ItemTransactionView>.Serialize(memoryStream, instance.ItemTransactions, new ListProxy<ItemTransactionView>.Serializer<ItemTransactionView>(ItemTransactionViewProxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(memoryStream, instance.TotalCount);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x0001AA2C File Offset: 0x00018C2C
		public static ItemTransactionsViewModel Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			ItemTransactionsViewModel itemTransactionsViewModel = new ItemTransactionsViewModel();
			if ((num & 1) != 0)
			{
				itemTransactionsViewModel.ItemTransactions = ListProxy<ItemTransactionView>.Deserialize(bytes, new ListProxy<ItemTransactionView>.Deserializer<ItemTransactionView>(ItemTransactionViewProxy.Deserialize));
			}
			itemTransactionsViewModel.TotalCount = Int32Proxy.Deserialize(bytes);
			return itemTransactionsViewModel;
		}
	}
}
