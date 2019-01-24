using System;
using System.IO;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002B3 RID: 691
	public static class PlaySpanHashesViewModelProxy
	{
		// Token: 0x06001109 RID: 4361 RVA: 0x0001A7E8 File Offset: 0x000189E8
		public static void Serialize(Stream stream, PlaySpanHashesViewModel instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.Hashes != null)
				{
					DictionaryProxy<decimal, string>.Serialize(memoryStream, instance.Hashes, new DictionaryProxy<decimal, string>.Serializer<decimal>(DecimalProxy.Serialize), new DictionaryProxy<decimal, string>.Serializer<string>(StringProxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				if (instance.MerchTrans != null)
				{
					StringProxy.Serialize(memoryStream, instance.MerchTrans);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x0001A888 File Offset: 0x00018A88
		public static PlaySpanHashesViewModel Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			PlaySpanHashesViewModel playSpanHashesViewModel = new PlaySpanHashesViewModel();
			if ((num & 1) != 0)
			{
				playSpanHashesViewModel.Hashes = DictionaryProxy<decimal, string>.Deserialize(bytes, new DictionaryProxy<decimal, string>.Deserializer<decimal>(DecimalProxy.Deserialize), new DictionaryProxy<decimal, string>.Deserializer<string>(StringProxy.Deserialize));
			}
			if ((num & 2) != 0)
			{
				playSpanHashesViewModel.MerchTrans = StringProxy.Deserialize(bytes);
			}
			return playSpanHashesViewModel;
		}
	}
}
