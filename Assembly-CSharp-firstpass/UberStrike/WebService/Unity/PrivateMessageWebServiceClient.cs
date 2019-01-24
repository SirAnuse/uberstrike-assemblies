using System;
using System.Collections.Generic;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Serialization;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002EA RID: 746
	public static class PrivateMessageWebServiceClient
	{
		// Token: 0x06001198 RID: 4504 RVA: 0x0001CB40 File Offset: 0x0001AD40
		public static Coroutine GetAllMessageThreadsForUser(string authToken, int pageNumber, Action<List<MessageThreadView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, pageNumber);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IPrivateMessageWebServiceContract", "PrivateMessageWebService", "GetAllMessageThreadsForUser", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<MessageThreadView>.Deserialize(new MemoryStream(data), new ListProxy<MessageThreadView>.Deserializer<MessageThreadView>(MessageThreadViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001199 RID: 4505 RVA: 0x0001CBC8 File Offset: 0x0001ADC8
		public static Coroutine GetThreadMessages(string authToken, int otherCmid, int pageNumber, Action<List<PrivateMessageView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, otherCmid);
				Int32Proxy.Serialize(memoryStream, pageNumber);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IPrivateMessageWebServiceContract", "PrivateMessageWebService", "GetThreadMessages", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<PrivateMessageView>.Deserialize(new MemoryStream(data), new ListProxy<PrivateMessageView>.Deserializer<PrivateMessageView>(PrivateMessageViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600119A RID: 4506 RVA: 0x0001CC58 File Offset: 0x0001AE58
		public static Coroutine SendMessage(string authToken, int receiverCmid, string content, Action<PrivateMessageView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, receiverCmid);
				StringProxy.Serialize(memoryStream, content);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IPrivateMessageWebServiceContract", "PrivateMessageWebService", "SendMessage", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(PrivateMessageViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600119B RID: 4507 RVA: 0x0001CCE8 File Offset: 0x0001AEE8
		public static Coroutine GetMessageWithIdForCmid(string authToken, int messageId, Action<PrivateMessageView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, messageId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IPrivateMessageWebServiceContract", "PrivateMessageWebService", "GetMessageWithIdForCmid", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(PrivateMessageViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x0001CD70 File Offset: 0x0001AF70
		public static Coroutine MarkThreadAsRead(string authToken, int otherCmid, Action callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, otherCmid);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IPrivateMessageWebServiceContract", "PrivateMessageWebService", "MarkThreadAsRead", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback();
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x0001CDF8 File Offset: 0x0001AFF8
		public static Coroutine DeleteThread(string authToken, int otherCmid, Action callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, otherCmid);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IPrivateMessageWebServiceContract", "PrivateMessageWebService", "DeleteThread", memoryStream.ToArray(), delegate(byte[] data)
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
