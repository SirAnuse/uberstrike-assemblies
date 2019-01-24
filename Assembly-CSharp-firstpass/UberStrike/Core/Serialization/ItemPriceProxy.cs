using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002A8 RID: 680
	public static class ItemPriceProxy
	{
		// Token: 0x060010F3 RID: 4339 RVA: 0x000192C0 File Offset: 0x000174C0
		public static void Serialize(Stream stream, ItemPrice instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Amount);
				EnumProxy<UberStrikeCurrencyType>.Serialize(memoryStream, instance.Currency);
				Int32Proxy.Serialize(memoryStream, instance.Discount);
				EnumProxy<BuyingDurationType>.Serialize(memoryStream, instance.Duration);
				EnumProxy<PackType>.Serialize(memoryStream, instance.PackType);
				Int32Proxy.Serialize(memoryStream, instance.Price);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010F4 RID: 4340 RVA: 0x00019344 File Offset: 0x00017544
		public static ItemPrice Deserialize(Stream bytes)
		{
			return new ItemPrice
			{
				Amount = Int32Proxy.Deserialize(bytes),
				Currency = EnumProxy<UberStrikeCurrencyType>.Deserialize(bytes),
				Discount = Int32Proxy.Deserialize(bytes),
				Duration = EnumProxy<BuyingDurationType>.Deserialize(bytes),
				PackType = EnumProxy<PackType>.Deserialize(bytes),
				Price = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
