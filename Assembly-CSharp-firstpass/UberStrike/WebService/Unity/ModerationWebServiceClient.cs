using System;
using System.IO;
using UberStrike.Core.Serialization;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002E8 RID: 744
	public static class ModerationWebServiceClient
	{
		// Token: 0x06001195 RID: 4501 RVA: 0x0001CAB8 File Offset: 0x0001ACB8
		public static Coroutine BanPermanently(string authToken, int targetCmid, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, targetCmid);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IModerationWebServiceContract", "ModerationWebService", "BanPermanently", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}
	}
}
