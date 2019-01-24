using System;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Serialization;
using UberStrike.Core.ViewModel;
using UberStrike.DataCenter.Common.Entities;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002CA RID: 714
	public static class AuthenticationWebServiceClient
	{
		// Token: 0x06001144 RID: 4420 RVA: 0x0001BBF0 File Offset: 0x00019DF0
		public static Coroutine CreateUser(string emailAddress, string password, ChannelType channel, string locale, string machineId, Action<MemberRegistrationResult> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, emailAddress);
				StringProxy.Serialize(memoryStream, password);
				EnumProxy<ChannelType>.Serialize(memoryStream, channel);
				StringProxy.Serialize(memoryStream, locale);
				StringProxy.Serialize(memoryStream, machineId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IAuthenticationWebServiceContract", "AuthenticationWebService", "CreateUser", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(EnumProxy<MemberRegistrationResult>.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x0001BC90 File Offset: 0x00019E90
		public static Coroutine CompleteAccount(int cmid, string name, ChannelType channel, string locale, string machineId, Action<AccountCompletionResultView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				StringProxy.Serialize(memoryStream, name);
				EnumProxy<ChannelType>.Serialize(memoryStream, channel);
				StringProxy.Serialize(memoryStream, locale);
				StringProxy.Serialize(memoryStream, machineId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IAuthenticationWebServiceContract", "AuthenticationWebService", "CompleteAccount", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(AccountCompletionResultViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x0001BD30 File Offset: 0x00019F30
		public static Coroutine LoginMemberEmail(string email, string password, ChannelType channelType, string machineId, Action<MemberAuthenticationResultView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, email);
				StringProxy.Serialize(memoryStream, password);
				EnumProxy<ChannelType>.Serialize(memoryStream, channelType);
				StringProxy.Serialize(memoryStream, machineId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IAuthenticationWebServiceContract", "AuthenticationWebService", "LoginMemberEmail", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(MemberAuthenticationResultViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x0001BDC8 File Offset: 0x00019FC8
		public static Coroutine LoginMemberFacebookUnitySdk(string facebookPlayerAccessToken, ChannelType channelType, string machineId, Action<MemberAuthenticationResultView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, facebookPlayerAccessToken);
				EnumProxy<ChannelType>.Serialize(memoryStream, channelType);
				StringProxy.Serialize(memoryStream, machineId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IAuthenticationWebServiceContract", "AuthenticationWebService", "LoginMemberFacebookUnitySdk", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(MemberAuthenticationResultViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x0001BE58 File Offset: 0x0001A058
		public static Coroutine LoginSteam(string steamId, string authToken, string machineId, Action<MemberAuthenticationResultView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, steamId);
				StringProxy.Serialize(memoryStream, authToken);
				StringProxy.Serialize(memoryStream, machineId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IAuthenticationWebServiceContract", "AuthenticationWebService", "LoginSteam", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(MemberAuthenticationResultViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x0001BEE8 File Offset: 0x0001A0E8
		public static Coroutine LoginMemberPortal(int cmid, string hash, string machineId, Action<MemberAuthenticationResultView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, cmid);
				StringProxy.Serialize(memoryStream, hash);
				StringProxy.Serialize(memoryStream, machineId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IAuthenticationWebServiceContract", "AuthenticationWebService", "LoginMemberPortal", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(MemberAuthenticationResultViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x0001BF78 File Offset: 0x0001A178
		public static Coroutine LinkSteamMember(string email, string password, string steamId, string machineId, Action<MemberAuthenticationResultView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, email);
				StringProxy.Serialize(memoryStream, password);
				StringProxy.Serialize(memoryStream, steamId);
				StringProxy.Serialize(memoryStream, machineId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IAuthenticationWebServiceContract", "AuthenticationWebService", "LinkSteamMember", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(MemberAuthenticationResultViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}
	}
}
