using System;
using System.Collections.Generic;
using System.IO;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Serialization;
using UberStrike.Core.ViewModel;
using UberStrike.DataCenter.Common.Entities;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x0200030A RID: 778
	public static class UserWebServiceClient
	{
		// Token: 0x060011EF RID: 4591 RVA: 0x0001DAF4 File Offset: 0x0001BCF4
		public static Coroutine ChangeMemberName(string authToken, string name, string locale, string machineId, Action<MemberOperationResult> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, name);
				StringProxy.Serialize(memoryStream, locale);
				StringProxy.Serialize(memoryStream, machineId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "ChangeMemberName", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(EnumProxy<MemberOperationResult>.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F0 RID: 4592 RVA: 0x0001DB8C File Offset: 0x0001BD8C
		public static Coroutine IsDuplicateMemberName(string username, Action<bool> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, username);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "IsDuplicateMemberName", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(BooleanProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F1 RID: 4593 RVA: 0x0001DC10 File Offset: 0x0001BE10
		public static Coroutine GenerateNonDuplicatedMemberNames(string username, Action<List<string>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, username);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GenerateNonDuplicatedMemberNames", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<string>.Deserialize(new MemoryStream(data), new ListProxy<string>.Deserializer<string>(StringProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F2 RID: 4594 RVA: 0x0001DC94 File Offset: 0x0001BE94
		public static Coroutine GetMemberWallet(string authToken, Action<MemberWalletView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetMemberWallet", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(MemberWalletViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x0001DD18 File Offset: 0x0001BF18
		public static Coroutine GetInventory(string authToken, Action<List<ItemInventoryView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetInventory", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<ItemInventoryView>.Deserialize(new MemoryStream(data), new ListProxy<ItemInventoryView>.Deserializer<ItemInventoryView>(ItemInventoryViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F4 RID: 4596 RVA: 0x0001DD9C File Offset: 0x0001BF9C
		public static Coroutine GetCurrencyDeposits(string authToken, int pageIndex, int elementPerPage, Action<CurrencyDepositsViewModel> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, pageIndex);
				Int32Proxy.Serialize(memoryStream, elementPerPage);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetCurrencyDeposits", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(CurrencyDepositsViewModelProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F5 RID: 4597 RVA: 0x0001DE2C File Offset: 0x0001C02C
		public static Coroutine GetItemTransactions(string authToken, int pageIndex, int elementPerPage, Action<ItemTransactionsViewModel> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, pageIndex);
				Int32Proxy.Serialize(memoryStream, elementPerPage);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetItemTransactions", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ItemTransactionsViewModelProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x0001DEBC File Offset: 0x0001C0BC
		public static Coroutine GetPointsDeposits(string authToken, int pageIndex, int elementPerPage, Action<PointDepositsViewModel> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, pageIndex);
				Int32Proxy.Serialize(memoryStream, elementPerPage);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetPointsDeposits", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(PointDepositsViewModelProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F7 RID: 4599 RVA: 0x0001DF4C File Offset: 0x0001C14C
		public static Coroutine GetLoadout(string authToken, Action<LoadoutView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetLoadout", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(LoadoutViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F8 RID: 4600 RVA: 0x0001DFD0 File Offset: 0x0001C1D0
		public static Coroutine SetLoadout(string authToken, LoadoutView loadoutView, Action<MemberOperationResult> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				LoadoutViewProxy.Serialize(memoryStream, loadoutView);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "SetLoadout", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(EnumProxy<MemberOperationResult>.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x0001E058 File Offset: 0x0001C258
		public static Coroutine GetMember(string authToken, Action<UberstrikeUserViewModel> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetMember", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(UberstrikeUserViewModelProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x0001E0DC File Offset: 0x0001C2DC
		public static Coroutine GetMemberSessionData(string authToken, Action<MemberSessionDataView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetMemberSessionData", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(MemberSessionDataViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x0001E160 File Offset: 0x0001C360
		public static Coroutine GetMemberListSessionData(List<string> authTokens, Action<List<MemberSessionDataView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				ListProxy<string>.Serialize(memoryStream, authTokens, new ListProxy<string>.Serializer<string>(StringProxy.Serialize));
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IUserWebServiceContract", "UserWebService", "GetMemberListSessionData", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<MemberSessionDataView>.Deserialize(new MemoryStream(data), new ListProxy<MemberSessionDataView>.Deserializer<MemberSessionDataView>(MemberSessionDataViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}
	}
}
