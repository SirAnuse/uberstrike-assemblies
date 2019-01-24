using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002B6 RID: 694
	public static class CurrencyDepositsViewModelProxy
	{
		// Token: 0x0600110F RID: 4367 RVA: 0x0001AA74 File Offset: 0x00018C74
		public static void Serialize(Stream stream, CurrencyDepositsViewModel instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.CurrencyDeposits != null)
				{
					ListProxy<CurrencyDepositView>.Serialize(memoryStream, instance.CurrencyDeposits, new ListProxy<CurrencyDepositView>.Serializer<CurrencyDepositView>(CurrencyDepositViewProxy.Serialize));
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

		// Token: 0x06001110 RID: 4368 RVA: 0x0001AAF4 File Offset: 0x00018CF4
		public static CurrencyDepositsViewModel Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			CurrencyDepositsViewModel currencyDepositsViewModel = new CurrencyDepositsViewModel();
			if ((num & 1) != 0)
			{
				currencyDepositsViewModel.CurrencyDeposits = ListProxy<CurrencyDepositView>.Deserialize(bytes, new ListProxy<CurrencyDepositView>.Deserializer<CurrencyDepositView>(CurrencyDepositViewProxy.Deserialize));
			}
			currencyDepositsViewModel.TotalCount = Int32Proxy.Deserialize(bytes);
			return currencyDepositsViewModel;
		}
	}
}
