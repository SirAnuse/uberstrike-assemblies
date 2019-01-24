using System;
using System.Collections.Generic;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Serialization;
using UberStrike.Core.Types;
using UberStrike.DataCenter.Common.Entities;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002C5 RID: 709
	public static class ApplicationWebServiceClient
	{
		// Token: 0x06001138 RID: 4408 RVA: 0x0001B9C4 File Offset: 0x00019BC4
		public static Coroutine AuthenticateApplication(string clientVersion, ChannelType channel, string publicKey, Action<AuthenticateApplicationView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, clientVersion);
				EnumProxy<ChannelType>.Serialize(memoryStream, channel);
				StringProxy.Serialize(memoryStream, publicKey);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IApplicationWebServiceContract", "ApplicationWebService", "AuthenticateApplication", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(AuthenticateApplicationViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001139 RID: 4409 RVA: 0x0001BA54 File Offset: 0x00019C54
		public static Coroutine GetMaps(string clientVersion, DefinitionType clientType, Action<List<MapView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, clientVersion);
				EnumProxy<DefinitionType>.Serialize(memoryStream, clientType);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IApplicationWebServiceContract", "ApplicationWebService", "GetMaps", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<MapView>.Deserialize(new MemoryStream(data), new ListProxy<MapView>.Deserializer<MapView>(MapViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600113A RID: 4410 RVA: 0x0001BADC File Offset: 0x00019CDC
		public static Coroutine GetConfigurationData(string clientVersion, Action<ApplicationConfigurationView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, clientVersion);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IApplicationWebServiceContract", "ApplicationWebService", "GetConfigurationData", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ApplicationConfigurationViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600113B RID: 4411 RVA: 0x0001BB60 File Offset: 0x00019D60
		public static Coroutine SetMatchScore(string clientVersion, MatchStats scoringView, string serverAuthentication, Action callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, clientVersion);
				MatchStatsProxy.Serialize(memoryStream, scoringView);
				StringProxy.Serialize(memoryStream, serverAuthentication);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IApplicationWebServiceContract", "ApplicationWebService", "SetMatchScore", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback();
					}
				}, handler));
			}
			return result;
		}
	}
}
