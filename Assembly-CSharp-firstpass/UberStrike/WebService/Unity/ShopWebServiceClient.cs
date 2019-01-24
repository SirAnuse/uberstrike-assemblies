using System;
using System.Collections.Generic;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Serialization;
using UberStrike.Core.Types;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002F8 RID: 760
	public static class ShopWebServiceClient
	{
		// Token: 0x060011BC RID: 4540 RVA: 0x0001D1B4 File Offset: 0x0001B3B4
		public static Coroutine GetShop(Action<UberStrikeItemShopClientView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "GetShop", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(UberStrikeItemShopClientViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011BD RID: 4541 RVA: 0x0001D230 File Offset: 0x0001B430
		public static Coroutine BuyItem(int itemId, string authToken, UberStrikeCurrencyType currencyType, BuyingDurationType durationType, UberstrikeItemType itemType, BuyingLocationType marketLocation, BuyingRecommendationType recommendationType, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, itemId);
				StringProxy.Serialize(memoryStream, authToken);
				EnumProxy<UberStrikeCurrencyType>.Serialize(memoryStream, currencyType);
				EnumProxy<BuyingDurationType>.Serialize(memoryStream, durationType);
				EnumProxy<UberstrikeItemType>.Serialize(memoryStream, itemType);
				EnumProxy<BuyingLocationType>.Serialize(memoryStream, marketLocation);
				EnumProxy<BuyingRecommendationType>.Serialize(memoryStream, recommendationType);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "BuyItem", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011BE RID: 4542 RVA: 0x0001D2E0 File Offset: 0x0001B4E0
		public static Coroutine BuyPack(int itemId, string authToken, PackType packType, UberStrikeCurrencyType currencyType, UberstrikeItemType itemType, BuyingLocationType marketLocation, BuyingRecommendationType recommendationType, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, itemId);
				StringProxy.Serialize(memoryStream, authToken);
				EnumProxy<PackType>.Serialize(memoryStream, packType);
				EnumProxy<UberStrikeCurrencyType>.Serialize(memoryStream, currencyType);
				EnumProxy<UberstrikeItemType>.Serialize(memoryStream, itemType);
				EnumProxy<BuyingLocationType>.Serialize(memoryStream, marketLocation);
				EnumProxy<BuyingRecommendationType>.Serialize(memoryStream, recommendationType);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "BuyPack", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011BF RID: 4543 RVA: 0x0001D390 File Offset: 0x0001B590
		public static Coroutine GetBundles(ChannelType channel, Action<List<BundleView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<ChannelType>.Serialize(memoryStream, channel);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "GetBundles", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<BundleView>.Deserialize(new MemoryStream(data), new ListProxy<BundleView>.Deserializer<BundleView>(BundleViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C0 RID: 4544 RVA: 0x0001D414 File Offset: 0x0001B614
		public static Coroutine BuyBundle(string authToken, int bundleId, ChannelType channel, string hashedReceipt, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, bundleId);
				EnumProxy<ChannelType>.Serialize(memoryStream, channel);
				StringProxy.Serialize(memoryStream, hashedReceipt);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "BuyBundle", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C1 RID: 4545 RVA: 0x0001D4AC File Offset: 0x0001B6AC
		public static Coroutine BuyBundleSteam(int bundleId, string steamId, string authToken, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, bundleId);
				StringProxy.Serialize(memoryStream, steamId);
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "BuyBundleSteam", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C2 RID: 4546 RVA: 0x0001D53C File Offset: 0x0001B73C
		public static Coroutine FinishBuyBundleSteam(string orderId, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, orderId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "FinishBuyBundleSteam", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C3 RID: 4547 RVA: 0x0001D5C0 File Offset: 0x0001B7C0
		public static Coroutine VerifyReceipt(string hashedReceipt, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, hashedReceipt);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "VerifyReceipt", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C4 RID: 4548 RVA: 0x0001D644 File Offset: 0x0001B844
		public static Coroutine UseConsumableItem(string authToken, int itemId, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, itemId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "UseConsumableItem", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C5 RID: 4549 RVA: 0x0001D6CC File Offset: 0x0001B8CC
		public static Coroutine GetAllMysteryBoxs(Action<List<MysteryBoxUnityView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "GetAllMysteryBoxs_1", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<MysteryBoxUnityView>.Deserialize(new MemoryStream(data), new ListProxy<MysteryBoxUnityView>.Deserializer<MysteryBoxUnityView>(MysteryBoxUnityViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C6 RID: 4550 RVA: 0x0001D748 File Offset: 0x0001B948
		public static Coroutine GetAllMysteryBoxs(BundleCategoryType bundleCategoryType, Action<List<MysteryBoxUnityView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<BundleCategoryType>.Serialize(memoryStream, bundleCategoryType);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "GetAllMysteryBoxs_2", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<MysteryBoxUnityView>.Deserialize(new MemoryStream(data), new ListProxy<MysteryBoxUnityView>.Deserializer<MysteryBoxUnityView>(MysteryBoxUnityViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C7 RID: 4551 RVA: 0x0001D7CC File Offset: 0x0001B9CC
		public static Coroutine GetMysteryBox(int mysteryBoxId, Action<MysteryBoxUnityView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, mysteryBoxId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "GetMysteryBox", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(MysteryBoxUnityViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C8 RID: 4552 RVA: 0x0001D850 File Offset: 0x0001BA50
		public static Coroutine RollMysteryBox(string authToken, int mysteryBoxId, ChannelType channel, Action<List<MysteryBoxWonItemUnityView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, mysteryBoxId);
				EnumProxy<ChannelType>.Serialize(memoryStream, channel);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "RollMysteryBox", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<MysteryBoxWonItemUnityView>.Deserialize(new MemoryStream(data), new ListProxy<MysteryBoxWonItemUnityView>.Deserializer<MysteryBoxWonItemUnityView>(MysteryBoxWonItemUnityViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011C9 RID: 4553 RVA: 0x0001D8E0 File Offset: 0x0001BAE0
		public static Coroutine GetAllLuckyDraws(Action<List<LuckyDrawUnityView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "GetAllLuckyDraws_1", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<LuckyDrawUnityView>.Deserialize(new MemoryStream(data), new ListProxy<LuckyDrawUnityView>.Deserializer<LuckyDrawUnityView>(LuckyDrawUnityViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011CA RID: 4554 RVA: 0x0001D95C File Offset: 0x0001BB5C
		public static Coroutine GetAllLuckyDraws(BundleCategoryType bundleCategoryType, Action<List<LuckyDrawUnityView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				EnumProxy<BundleCategoryType>.Serialize(memoryStream, bundleCategoryType);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "GetAllLuckyDraws_2", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<LuckyDrawUnityView>.Deserialize(new MemoryStream(data), new ListProxy<LuckyDrawUnityView>.Deserializer<LuckyDrawUnityView>(LuckyDrawUnityViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011CB RID: 4555 RVA: 0x0001D9E0 File Offset: 0x0001BBE0
		public static Coroutine GetLuckyDraw(int luckyDrawId, Action<LuckyDrawUnityView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, luckyDrawId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "GetLuckyDraw", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(LuckyDrawUnityViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011CC RID: 4556 RVA: 0x0001DA64 File Offset: 0x0001BC64
		public static Coroutine RollLuckyDraw(string authToken, int luckDrawId, ChannelType channel, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, luckDrawId);
				EnumProxy<ChannelType>.Serialize(memoryStream, channel);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IShopWebServiceContract", "ShopWebService", "RollLuckyDraw", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}
	}
}
