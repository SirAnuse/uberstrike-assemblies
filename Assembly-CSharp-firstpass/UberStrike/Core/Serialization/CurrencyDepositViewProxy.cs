using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x0200025B RID: 603
	public static class CurrencyDepositViewProxy
	{
		// Token: 0x0600104D RID: 4173 RVA: 0x00013358 File Offset: 0x00011558
		public static void Serialize(Stream stream, CurrencyDepositView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.ApplicationId);
				if (instance.BundleId != null)
				{
					Stream bytes = memoryStream;
					int? bundleId = instance.BundleId;
					Int32Proxy.Serialize(bytes, (bundleId == null) ? 0 : bundleId.Value);
				}
				else
				{
					num |= 1;
				}
				if (instance.BundleName != null)
				{
					StringProxy.Serialize(memoryStream, instance.BundleName);
				}
				else
				{
					num |= 2;
				}
				DecimalProxy.Serialize(memoryStream, instance.Cash);
				EnumProxy<ChannelType>.Serialize(memoryStream, instance.ChannelId);
				Int32Proxy.Serialize(memoryStream, instance.Cmid);
				Int32Proxy.Serialize(memoryStream, instance.Credits);
				Int32Proxy.Serialize(memoryStream, instance.CreditsDepositId);
				if (instance.CurrencyLabel != null)
				{
					StringProxy.Serialize(memoryStream, instance.CurrencyLabel);
				}
				else
				{
					num |= 4;
				}
				DateTimeProxy.Serialize(memoryStream, instance.DepositDate);
				BooleanProxy.Serialize(memoryStream, instance.IsAdminAction);
				EnumProxy<PaymentProviderType>.Serialize(memoryStream, instance.PaymentProviderId);
				Int32Proxy.Serialize(memoryStream, instance.Points);
				if (instance.TransactionKey != null)
				{
					StringProxy.Serialize(memoryStream, instance.TransactionKey);
				}
				else
				{
					num |= 8;
				}
				DecimalProxy.Serialize(memoryStream, instance.UsdAmount);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x000134D0 File Offset: 0x000116D0
		public static CurrencyDepositView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			CurrencyDepositView currencyDepositView = new CurrencyDepositView();
			currencyDepositView.ApplicationId = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				currencyDepositView.BundleId = new int?(Int32Proxy.Deserialize(bytes));
			}
			if ((num & 2) != 0)
			{
				currencyDepositView.BundleName = StringProxy.Deserialize(bytes);
			}
			currencyDepositView.Cash = DecimalProxy.Deserialize(bytes);
			currencyDepositView.ChannelId = EnumProxy<ChannelType>.Deserialize(bytes);
			currencyDepositView.Cmid = Int32Proxy.Deserialize(bytes);
			currencyDepositView.Credits = Int32Proxy.Deserialize(bytes);
			currencyDepositView.CreditsDepositId = Int32Proxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				currencyDepositView.CurrencyLabel = StringProxy.Deserialize(bytes);
			}
			currencyDepositView.DepositDate = DateTimeProxy.Deserialize(bytes);
			currencyDepositView.IsAdminAction = BooleanProxy.Deserialize(bytes);
			currencyDepositView.PaymentProviderId = EnumProxy<PaymentProviderType>.Deserialize(bytes);
			currencyDepositView.Points = Int32Proxy.Deserialize(bytes);
			if ((num & 8) != 0)
			{
				currencyDepositView.TransactionKey = StringProxy.Deserialize(bytes);
			}
			currencyDepositView.UsdAmount = DecimalProxy.Deserialize(bytes);
			return currencyDepositView;
		}
	}
}
