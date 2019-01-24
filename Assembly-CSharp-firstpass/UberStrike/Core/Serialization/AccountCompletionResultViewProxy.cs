using System;
using System.IO;
using UberStrike.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000299 RID: 665
	public static class AccountCompletionResultViewProxy
	{
		// Token: 0x060010D5 RID: 4309 RVA: 0x00017DB0 File Offset: 0x00015FB0
		public static void Serialize(Stream stream, AccountCompletionResultView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.ItemsAttributed != null)
				{
					DictionaryProxy<int, int>.Serialize(memoryStream, instance.ItemsAttributed, new DictionaryProxy<int, int>.Serializer<int>(Int32Proxy.Serialize), new DictionaryProxy<int, int>.Serializer<int>(Int32Proxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				if (instance.NonDuplicateNames != null)
				{
					ListProxy<string>.Serialize(memoryStream, instance.NonDuplicateNames, new ListProxy<string>.Serializer<string>(StringProxy.Serialize));
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.Result);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x00017E68 File Offset: 0x00016068
		public static AccountCompletionResultView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			AccountCompletionResultView accountCompletionResultView = new AccountCompletionResultView();
			if ((num & 1) != 0)
			{
				accountCompletionResultView.ItemsAttributed = DictionaryProxy<int, int>.Deserialize(bytes, new DictionaryProxy<int, int>.Deserializer<int>(Int32Proxy.Deserialize), new DictionaryProxy<int, int>.Deserializer<int>(Int32Proxy.Deserialize));
			}
			if ((num & 2) != 0)
			{
				accountCompletionResultView.NonDuplicateNames = ListProxy<string>.Deserialize(bytes, new ListProxy<string>.Deserializer<string>(StringProxy.Deserialize));
			}
			accountCompletionResultView.Result = Int32Proxy.Deserialize(bytes);
			return accountCompletionResultView;
		}
	}
}
