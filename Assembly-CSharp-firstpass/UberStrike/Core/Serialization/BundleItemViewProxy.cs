using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000250 RID: 592
	public static class BundleItemViewProxy
	{
		// Token: 0x06001037 RID: 4151 RVA: 0x000124F8 File Offset: 0x000106F8
		public static void Serialize(Stream stream, BundleItemView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Amount);
				Int32Proxy.Serialize(memoryStream, instance.BundleId);
				EnumProxy<BuyingDurationType>.Serialize(memoryStream, instance.Duration);
				Int32Proxy.Serialize(memoryStream, instance.ItemId);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x00012564 File Offset: 0x00010764
		public static BundleItemView Deserialize(Stream bytes)
		{
			return new BundleItemView
			{
				Amount = Int32Proxy.Deserialize(bytes),
				BundleId = Int32Proxy.Deserialize(bytes),
				Duration = EnumProxy<BuyingDurationType>.Deserialize(bytes),
				ItemId = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
