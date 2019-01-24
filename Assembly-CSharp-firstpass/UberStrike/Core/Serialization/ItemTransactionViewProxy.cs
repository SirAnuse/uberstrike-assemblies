using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200025F RID: 607
	public static class ItemTransactionViewProxy
	{
		// Token: 0x06001055 RID: 4181 RVA: 0x00013AB0 File Offset: 0x00011CB0
		public static void Serialize(Stream stream, ItemTransactionView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				Int32Proxy.Serialize(memoryStream, instance.Credits);
				EnumProxy<BuyingDurationType>.Serialize(memoryStream, instance.Duration);
				BooleanProxy.Serialize(memoryStream, instance.IsAdminAction);
				Int32Proxy.Serialize(memoryStream, instance.ItemId);
				Int32Proxy.Serialize(memoryStream, instance.Points);
				DateTimeProxy.Serialize(memoryStream, instance.WithdrawalDate);
				Int32Proxy.Serialize(memoryStream, instance.WithdrawalId);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x00013B4C File Offset: 0x00011D4C
		public static ItemTransactionView Deserialize(Stream bytes)
		{
			return new ItemTransactionView
			{
				Cmid = Int32Proxy.Deserialize(bytes),
				Credits = Int32Proxy.Deserialize(bytes),
				Duration = EnumProxy<BuyingDurationType>.Deserialize(bytes),
				IsAdminAction = BooleanProxy.Deserialize(bytes),
				ItemId = Int32Proxy.Deserialize(bytes),
				Points = Int32Proxy.Deserialize(bytes),
				WithdrawalDate = DateTimeProxy.Deserialize(bytes),
				WithdrawalId = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
