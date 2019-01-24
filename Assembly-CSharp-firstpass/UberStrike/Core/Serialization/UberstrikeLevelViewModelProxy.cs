using System;
using System.IO;
using UberStrike.Core.Models.Views;
using UberStrike.Core.ViewModel;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002B9 RID: 697
	public static class UberstrikeLevelViewModelProxy
	{
		// Token: 0x06001115 RID: 4373 RVA: 0x0001AEE8 File Offset: 0x000190E8
		public static void Serialize(Stream stream, UberstrikeLevelViewModel instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.Maps != null)
				{
					ListProxy<MapView>.Serialize(memoryStream, instance.Maps, new ListProxy<MapView>.Serializer<MapView>(MapViewProxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x0001AF5C File Offset: 0x0001915C
		public static UberstrikeLevelViewModel Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			UberstrikeLevelViewModel uberstrikeLevelViewModel = new UberstrikeLevelViewModel();
			if ((num & 1) != 0)
			{
				uberstrikeLevelViewModel.Maps = ListProxy<MapView>.Deserialize(bytes, new ListProxy<MapView>.Deserializer<MapView>(MapViewProxy.Deserialize));
			}
			return uberstrikeLevelViewModel;
		}
	}
}
