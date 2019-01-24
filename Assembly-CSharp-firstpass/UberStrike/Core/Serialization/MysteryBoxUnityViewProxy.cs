using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;

namespace UberStrike.Core.Serialization
{
	// Token: 0x02000268 RID: 616
	public static class MysteryBoxUnityViewProxy
	{
		// Token: 0x06001067 RID: 4199 RVA: 0x000145EC File Offset: 0x000127EC
		public static void Serialize(Stream stream, MysteryBoxUnityView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<BundleCategoryType>.Serialize(memoryStream, instance.Category);
				Int32Proxy.Serialize(memoryStream, instance.CreditsAttributed);
				Int32Proxy.Serialize(memoryStream, instance.CreditsAttributedWeight);
				if (instance.Description != null)
				{
					StringProxy.Serialize(memoryStream, instance.Description);
				}
				else
				{
					num |= 1;
				}
				BooleanProxy.Serialize(memoryStream, instance.ExposeItemsToPlayers);
				if (instance.IconUrl != null)
				{
					StringProxy.Serialize(memoryStream, instance.IconUrl);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.Id);
				if (instance.ImageUrl != null)
				{
					StringProxy.Serialize(memoryStream, instance.ImageUrl);
				}
				else
				{
					num |= 4;
				}
				BooleanProxy.Serialize(memoryStream, instance.IsAvailableInShop);
				Int32Proxy.Serialize(memoryStream, instance.ItemsAttributed);
				if (instance.MysteryBoxItems != null)
				{
					ListProxy<BundleItemView>.Serialize(memoryStream, instance.MysteryBoxItems, new ListProxy<BundleItemView>.Serializer<BundleItemView>(BundleItemViewProxy.Serialize));
				}
				else
				{
					num |= 8;
				}
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 16;
				}
				Int32Proxy.Serialize(memoryStream, instance.PointsAttributed);
				Int32Proxy.Serialize(memoryStream, instance.PointsAttributedWeight);
				Int32Proxy.Serialize(memoryStream, instance.Price);
				EnumProxy<UberStrikeCurrencyType>.Serialize(memoryStream, instance.UberStrikeCurrencyType);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x00014770 File Offset: 0x00012970
		public static MysteryBoxUnityView Deserialize(Stream bytes)
		{
			int num = Int32Proxy.Deserialize(bytes);
			MysteryBoxUnityView mysteryBoxUnityView = new MysteryBoxUnityView();
			mysteryBoxUnityView.Category = EnumProxy<BundleCategoryType>.Deserialize(bytes);
			mysteryBoxUnityView.CreditsAttributed = Int32Proxy.Deserialize(bytes);
			mysteryBoxUnityView.CreditsAttributedWeight = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				mysteryBoxUnityView.Description = StringProxy.Deserialize(bytes);
			}
			mysteryBoxUnityView.ExposeItemsToPlayers = BooleanProxy.Deserialize(bytes);
			if ((num & 2) != 0)
			{
				mysteryBoxUnityView.IconUrl = StringProxy.Deserialize(bytes);
			}
			mysteryBoxUnityView.Id = Int32Proxy.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				mysteryBoxUnityView.ImageUrl = StringProxy.Deserialize(bytes);
			}
			mysteryBoxUnityView.IsAvailableInShop = BooleanProxy.Deserialize(bytes);
			mysteryBoxUnityView.ItemsAttributed = Int32Proxy.Deserialize(bytes);
			if ((num & 8) != 0)
			{
				mysteryBoxUnityView.MysteryBoxItems = ListProxy<BundleItemView>.Deserialize(bytes, new ListProxy<BundleItemView>.Deserializer<BundleItemView>(BundleItemViewProxy.Deserialize));
			}
			if ((num & 16) != 0)
			{
				mysteryBoxUnityView.Name = StringProxy.Deserialize(bytes);
			}
			mysteryBoxUnityView.PointsAttributed = Int32Proxy.Deserialize(bytes);
			mysteryBoxUnityView.PointsAttributedWeight = Int32Proxy.Deserialize(bytes);
			mysteryBoxUnityView.Price = Int32Proxy.Deserialize(bytes);
			mysteryBoxUnityView.UberStrikeCurrencyType = EnumProxy<UberStrikeCurrencyType>.Deserialize(bytes);
			return mysteryBoxUnityView;
		}
	}
}
