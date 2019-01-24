using System;
using System.Collections.Generic;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Serialization;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002E3 RID: 739
	public static class FacebookWebServiceClient
	{
		// Token: 0x06001189 RID: 4489 RVA: 0x0001C890 File Offset: 0x0001AA90
		public static Coroutine ClaimFacebookGift(string authToken, string facebookRequestObjectId, Action<ClaimFacebookGiftView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, facebookRequestObjectId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IFacebookWebServiceContract", "FacebookWebService", "ClaimFacebookGift", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ClaimFacebookGiftViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600118A RID: 4490 RVA: 0x0001C918 File Offset: 0x0001AB18
		public static Coroutine AttachFacebookAccountToCmuneAccount(string authToken, string facebookId, Action<MemberOperationResult> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, facebookId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IFacebookWebServiceContract", "FacebookWebService", "AttachFacebookAccountToCmuneAccount", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(EnumProxy<MemberOperationResult>.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600118B RID: 4491 RVA: 0x0001C9A0 File Offset: 0x0001ABA0
		public static Coroutine CheckFacebookSession(string cmuneAuthToken, string facebookIDString, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, cmuneAuthToken);
				StringProxy.Serialize(memoryStream, facebookIDString);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IFacebookWebServiceContract", "FacebookWebService", "CheckFacebookSession", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600118C RID: 4492 RVA: 0x0001CA28 File Offset: 0x0001AC28
		public static Coroutine GetFacebookFriendsList(List<string> facebookIds, Action<List<PublicProfileView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ListProxy<string>.Serialize(memoryStream, facebookIds, new ListProxy<string>.Serializer<string>(StringProxy.Serialize));
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IFacebookWebServiceContract", "FacebookWebService", "GetFacebookFriendsList", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<PublicProfileView>.Deserialize(new MemoryStream(data), new ListProxy<PublicProfileView>.Deserializer<PublicProfileView>(PublicProfileViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}
	}
}
