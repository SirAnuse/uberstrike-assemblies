﻿using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UnityEngine;

namespace UberStrike.Core.Serialization
{
	// Token: 0x020002B8 RID: 696
	public static class UberStrikeItemGearViewProxy
	{
		// Token: 0x06001113 RID: 4371 RVA: 0x0001AC04 File Offset: 0x00018E04
		public static void Serialize(Stream stream, UberStrikeItemGearView instance)
		{
			int num = 0;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, instance.ArmorPoints);
				Int32Proxy.Serialize(memoryStream, instance.ArmorWeight);
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

		// Token: 0x06001114 RID: 4372 RVA: 0x0001ADB4 File Offset: 0x00018FB4
		public static UberStrikeItemGearView Deserialize(Stream bytes)
		{
            int num = Int32Proxy.Deserialize(bytes);
			UberStrikeItemGearView uberStrikeItemGearView = new UberStrikeItemGearView();
			uberStrikeItemGearView.ArmorPoints = Int32Proxy.Deserialize(bytes);
			uberStrikeItemGearView.ArmorWeight = Int32Proxy.Deserialize(bytes);
			if ((num & 1) != 0)
			{
				uberStrikeItemGearView.CustomProperties = DictionaryProxy<string, string>.Deserialize(bytes, new DictionaryProxy<string, string>.Deserializer<string>(StringProxy.Deserialize), new DictionaryProxy<string, string>.Deserializer<string>(StringProxy.Deserialize));
			}
			if ((num & 2) != 0)
			{
				uberStrikeItemGearView.Description = StringProxy.Deserialize(bytes);
			}
			uberStrikeItemGearView.ID = Int32Proxy.Deserialize(bytes);
			uberStrikeItemGearView.IsConsumable = BooleanProxy.Deserialize(bytes);
			uberStrikeItemGearView.ItemClass = EnumProxy<UberstrikeItemClass>.Deserialize(bytes);
			if ((num & 4) != 0)
			{
				uberStrikeItemGearView.ItemProperties = DictionaryProxy<ItemPropertyType, int>.Deserialize(bytes, new DictionaryProxy<ItemPropertyType, int>.Deserializer<ItemPropertyType>(EnumProxy<ItemPropertyType>.Deserialize), new DictionaryProxy<ItemPropertyType, int>.Deserializer<int>(Int32Proxy.Deserialize));
			}
			uberStrikeItemGearView.LevelLock = Int32Proxy.Deserialize(bytes);
			uberStrikeItemGearView.MaxDurationDays = Int32Proxy.Deserialize(bytes);
			if ((num & 8) != 0)
			{
				uberStrikeItemGearView.Name = StringProxy.Deserialize(bytes);
			}
			if ((num & 16) != 0)
			{
				uberStrikeItemGearView.PrefabName = StringProxy.Deserialize(bytes);
			}
			if ((num & 32) != 0)
			{
				uberStrikeItemGearView.Prices = ListProxy<ItemPrice>.Deserialize(bytes, new ListProxy<ItemPrice>.Deserializer<ItemPrice>(ItemPriceProxy.Deserialize));
			}
			uberStrikeItemGearView.ShopHighlightType = EnumProxy<ItemShopHighlightType>.Deserialize(bytes);
			return uberStrikeItemGearView;
		}
	}
}
