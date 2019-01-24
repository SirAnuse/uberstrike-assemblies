using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002B4 RID: 692
	public static class PointDepositsViewModelProxy
	{
		// Token: 0x0600110B RID: 4363 RVA: 0x0001A8E4 File Offset: 0x00018AE4
		public static void Serialize(Stream stream, PointDepositsViewModel instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.PointDeposits != null)
				{
					ListProxy<PointDepositView>.Serialize(memoryStream, instance.PointDeposits, new ListProxy<PointDepositView>.Serializer<PointDepositView>(PointDepositViewProxy.Serialize));
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

		// Token: 0x0600110C RID: 4364 RVA: 0x0001A964 File Offset: 0x00018B64
		public static PointDepositsViewModel Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			PointDepositsViewModel pointDepositsViewModel = new PointDepositsViewModel();
			if ((num & 1) != 0)
			{
				pointDepositsViewModel.PointDeposits = ListProxy<PointDepositView>.Deserialize(bytes, new ListProxy<PointDepositView>.Deserializer<PointDepositView>(PointDepositViewProxy.Deserialize));
			}
			pointDepositsViewModel.TotalCount = Int32Proxy.Deserialize(bytes);
			return pointDepositsViewModel;
		}
	}
}
