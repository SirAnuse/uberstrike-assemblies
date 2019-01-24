using System;
using System.Collections.Generic;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Serialization;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002F1 RID: 753
	public static class RelationshipWebServiceClient
	{
		// Token: 0x060011AA RID: 4522 RVA: 0x0001CE80 File Offset: 0x0001B080
		public static Coroutine SendContactRequest(string authToken, int receiverCmid, string message, Action callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, receiverCmid);
				StringProxy.Serialize(memoryStream, message);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IRelationshipWebServiceContract", "RelationshipWebService", "SendContactRequest", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback();
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x0001CF10 File Offset: 0x0001B110
		public static Coroutine GetContactRequests(string authToken, Action<List<ContactRequestView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IRelationshipWebServiceContract", "RelationshipWebService", "GetContactRequests", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<ContactRequestView>.Deserialize(new MemoryStream(data), new ListProxy<ContactRequestView>.Deserializer<ContactRequestView>(ContactRequestViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011AC RID: 4524 RVA: 0x0001CF94 File Offset: 0x0001B194
		public static Coroutine AcceptContactRequest(string authToken, int contactRequestId, Action<PublicProfileView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, contactRequestId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IRelationshipWebServiceContract", "RelationshipWebService", "AcceptContactRequest", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(PublicProfileViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011AD RID: 4525 RVA: 0x0001D01C File Offset: 0x0001B21C
		public static Coroutine DeclineContactRequest(string authToken, int contactRequestId, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, contactRequestId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IRelationshipWebServiceContract", "RelationshipWebService", "DeclineContactRequest", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x0001D0A4 File Offset: 0x0001B2A4
		public static Coroutine DeleteContact(string authToken, int contactCmid, Action<MemberOperationResult> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, contactCmid);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IRelationshipWebServiceContract", "RelationshipWebService", "DeleteContact", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(EnumProxy<MemberOperationResult>.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011AF RID: 4527 RVA: 0x0001D12C File Offset: 0x0001B32C
		public static Coroutine GetContactsByGroups(string authToken, bool populateFacebookIds, Action<List<ContactGroupView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				BooleanProxy.Serialize(memoryStream, populateFacebookIds);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IRelationshipWebServiceContract", "RelationshipWebService", "GetContactsByGroups", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<ContactGroupView>.Deserialize(new MemoryStream(data), new ListProxy<ContactGroupView>.Deserializer<ContactGroupView>(ContactGroupViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}
	}
}
