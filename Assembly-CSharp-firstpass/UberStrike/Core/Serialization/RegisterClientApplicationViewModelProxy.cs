using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002B7 RID: 695
	public static class RegisterClientApplicationViewModelProxy
	{
		// Token: 0x06001111 RID: 4369 RVA: 0x0001AB3C File Offset: 0x00018D3C
		public static void Serialize(Stream stream, RegisterClientApplicationViewModel instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.ItemsAttributed != null)
				{
					ListProxy<int>.Serialize(memoryStream, instance.ItemsAttributed, new ListProxy<int>.Serializer<int>(Int32Proxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				EnumProxy<ApplicationRegistrationResult>.Serialize(memoryStream, instance.Result);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x0001ABBC File Offset: 0x00018DBC
		public static RegisterClientApplicationViewModel Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			RegisterClientApplicationViewModel registerClientApplicationViewModel = new RegisterClientApplicationViewModel();
			if ((num & 1) != 0)
			{
				registerClientApplicationViewModel.ItemsAttributed = ListProxy<int>.Deserialize(bytes, new ListProxy<int>.Deserializer<int>(Int32Proxy.Deserialize));
			}
			registerClientApplicationViewModel.Result = EnumProxy<ApplicationRegistrationResult>.Deserialize(bytes);
			return registerClientApplicationViewModel;
		}
	}
}
