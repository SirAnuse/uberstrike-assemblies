using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200026D RID: 621
	public static class PointDepositViewProxy
	{
		// Token: 0x06001071 RID: 4209 RVA: 0x00014C20 File Offset: 0x00012E20
		public static void Serialize(Stream stream, PointDepositView instance)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				DateTimeProxy.Serialize(memoryStream, instance.DepositDate);
				EnumProxy<PointsDepositType>.Serialize(memoryStream, instance.DepositType);
				BooleanProxy.Serialize(memoryStream, instance.IsAdminAction);
				Int32Proxy.Serialize(memoryStream, instance.PointDepositId);
				Int32Proxy.Serialize(memoryStream, instance.Points);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x00014CA4 File Offset: 0x00012EA4
		public static PointDepositView Deserialize(Stream bytes)
		{
			return new PointDepositView
			{
				Cmid = Int32Proxy.Deserialize(bytes),
				DepositDate = DateTimeProxy.Deserialize(bytes),
				DepositType = EnumProxy<PointsDepositType>.Deserialize(bytes),
				IsAdminAction = BooleanProxy.Deserialize(bytes),
				PointDepositId = Int32Proxy.Deserialize(bytes),
				Points = Int32Proxy.Deserialize(bytes)
			};
		}
	}
}
