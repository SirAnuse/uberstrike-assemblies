using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002AB RID: 683
	public static class UberStrikeItemFunctionalViewProxy
	{
		// Token: 0x060010F9 RID: 4345 RVA: 0x00019590 File Offset: 0x00017790
		public static void Serialize(Stream stream, UberStrikeItemFunctionalView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (instance.CustomProperties != null)
				{
					DictionaryProxy<string, string>.Serialize(memoryStream, instance.CustomProperties, new DictionaryProxy<string, string>.Serializer<string>(StringProxy.Serialize), new DictionaryProxy<string, string>.Serializer<string>(StringProxy.Serialize));
				}
				else
				{
					num |= 1;
				}
				if (instance.Description != null)
				{
					StringProxy.Serialize(memoryStream, instance.Description);
				}
				else
				{
					num |= 2;
				}
				Int32Proxy.Serialize(memoryStream, instance.ID);
				BooleanProxy.Serialize(memoryStream, instance.IsConsumable);
				EnumProxy<UberstrikeItemClass>.Serialize(memoryStream, instance.ItemClass);
				if (instance.ItemProperties != null)
				{
					DictionaryProxy<ItemPropertyType, int>.Serialize(memoryStream, instance.ItemProperties, new DictionaryProxy<ItemPropertyType, int>.Serializer<ItemPropertyType>(EnumProxy<ItemPropertyType>.Serialize), new DictionaryProxy<ItemPropertyType, int>.Serializer<int>(Int32Proxy.Serialize));
				}
				else
				{
					num |= 4;
				}
				Int32Proxy.Serialize(memoryStream, instance.LevelLock);
				Int32Proxy.Serialize(memoryStream, instance.MaxDurationDays);
				if (instance.Name != null)
				{
					StringProxy.Serialize(memoryStream, instance.Name);
				}
				else
				{
					num |= 8;
				}
				if (instance.PrefabName != null)
				{
					StringProxy.Serialize(memoryStream, instance.PrefabName);
				}
				else
				{
					num |= 16;
				}
				if (instance.Prices != null)
				{
					ListProxy<ItemPrice>.Serialize(memoryStream, instance.Prices, new ListProxy<ItemPrice>.Serializer<ItemPrice>(ItemPriceProxy.Serialize));
				}
				else
				{
					num |= 32;
				}
				EnumProxy<ItemShopHighlightType>.Serialize(memoryStream, instance.ShopHighlightType);
				Int32Proxy.Serialize(stream, ~num);
				memoryStream.WriteTo(stream);
			}
		}

		// Token: 0x060010FA RID: 4346 RVA: 0x00019728 File Offset: 0x00017928
		public static UberStrikeItemFunctionalView Deserialize(Stream bytes)
		{
            int num = Int32Proxy.Deserialize(bytes);
            
            UberStrikeItemFunctionalView uberStrikeItemFunctionalView = new UberStrikeItemFunctionalView();
			if ((num & 1) != 0)
			{
				uberStrikeItemFunctionalView.CustomProperties = DictionaryProxy<string, string>.Deserialize(bytes, new DictionaryProxy<string, string>.Deserializer<string>(StringProxy.Deserialize), new DictionaryProxy<string, string>.Deserializer<string>(StringProxy.Deserialize));
			}
			if ((num & 2) != 0)
			{
				uberStrikeItemFunctionalView.Description = StringProxy.Deserialize(bytes);
			}
			uberStrikeItemFunctionalView.ID = Int32Proxy.Deserialize(bytes);
			uberStrikeItemFunctionalView.IsConsumable = BooleanProxy.Deserialize(bytes);
			uberStrikeItemFunctionalView.ItemClass = EnumProxy<UberstrikeItemClass>.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				uberStrikeItemFunctionalView.ItemProperties = DictionaryProxy<ItemPropertyType, int>.Deserialize(bytes, new DictionaryProxy<ItemPropertyType, int>.Deserializer<ItemPropertyType>(EnumProxy<ItemPropertyType>.Deserialize), new DictionaryProxy<ItemPropertyType, int>.Deserializer<int>(Int32Proxy.Deserialize));
			}
			uberStrikeItemFunctionalView.LevelLock = Int32Proxy.Deserialize(bytes);
			uberStrikeItemFunctionalView.MaxDurationDays = Int32Proxy.Deserialize(bytes);
			if ((num & 8) != 0)
			{
				uberStrikeItemFunctionalView.Name = StringProxy.Deserialize(bytes);
			}
			if ((num & 16) != 0)
			{
				uberStrikeItemFunctionalView.PrefabName = StringProxy.Deserialize(bytes);
			}
			if ((num & 32) != 0)
			{
				uberStrikeItemFunctionalView.Prices = ListProxy<ItemPrice>.Deserialize(bytes, new ListProxy<ItemPrice>.Deserializer<ItemPrice>(ItemPriceProxy.Deserialize));
			}
			uberStrikeItemFunctionalView.ShopHighlightType = EnumProxy<ItemShopHighlightType>.Deserialize(bytes);
			return uberStrikeItemFunctionalView;
		}
	}
}
