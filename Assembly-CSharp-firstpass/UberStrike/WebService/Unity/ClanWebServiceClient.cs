using System;
using System.Collections.Generic;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Serialization;
using UnityEngine;

namespace UberStrike.WebService.Unity
{
	// Token: 0x020002D2 RID: 722
	public static class ClanWebServiceClient
	{
		// Token: 0x06001159 RID: 4441 RVA: 0x0001C010 File Offset: 0x0001A210
		public static Coroutine GetOwnClan(string authToken, int groupId, Action<ClanView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, groupId);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "GetOwnClan", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ClanViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600115A RID: 4442 RVA: 0x0001C098 File Offset: 0x0001A298
		public static Coroutine UpdateMemberPosition(MemberPositionUpdateView updateMemberPositionData, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				MemberPositionUpdateViewProxy.Serialize(memoryStream, updateMemberPositionData);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "UpdateMemberPosition", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x0001C11C File Offset: 0x0001A31C
		public static Coroutine InviteMemberToJoinAGroup(int clanId, string authToken, int inviteeCmid, string message, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, clanId);
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, inviteeCmid);
				StringProxy.Serialize(memoryStream, message);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "InviteMemberToJoinAGroup", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x0001C1B4 File Offset: 0x0001A3B4
		public static Coroutine AcceptClanInvitation(int clanInvitationId, string authToken, Action<ClanRequestAcceptView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, clanInvitationId);
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "AcceptClanInvitation", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ClanRequestAcceptViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600115D RID: 4445 RVA: 0x0001C23C File Offset: 0x0001A43C
		public static Coroutine DeclineClanInvitation(int clanInvitationId, string authToken, Action<ClanRequestDeclineView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, clanInvitationId);
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "DeclineClanInvitation", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ClanRequestDeclineViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600115E RID: 4446 RVA: 0x0001C2C4 File Offset: 0x0001A4C4
		public static Coroutine KickMemberFromClan(int groupId, string authToken, int cmidToKick, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, groupId);
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, cmidToKick);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "KickMemberFromClan", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x0600115F RID: 4447 RVA: 0x0001C354 File Offset: 0x0001A554
		public static Coroutine DisbandGroup(int groupId, string authToken, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, groupId);
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "DisbandGroup", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001160 RID: 4448 RVA: 0x0001C3DC File Offset: 0x0001A5DC
		public static Coroutine LeaveAClan(int groupId, string authToken, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, groupId);
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "LeaveAClan", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001161 RID: 4449 RVA: 0x0001C464 File Offset: 0x0001A664
		public static Coroutine GetMyClanId(string authToken, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "GetMyClanId", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x0001C4E8 File Offset: 0x0001A6E8
		public static Coroutine CancelInvitation(int groupInvitationId, string authToken, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, groupInvitationId);
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "CancelInvitation", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x0001C570 File Offset: 0x0001A770
		public static Coroutine GetAllGroupInvitations(string authToken, Action<List<GroupInvitationView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "GetAllGroupInvitations", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<GroupInvitationView>.Deserialize(new MemoryStream(data), new ListProxy<GroupInvitationView>.Deserializer<GroupInvitationView>(GroupInvitationViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x0001C5F4 File Offset: 0x0001A7F4
		public static Coroutine GetPendingGroupInvitations(int groupId, string authToken, Action<List<GroupInvitationView>> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, groupId);
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "GetPendingGroupInvitations", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ListProxy<GroupInvitationView>.Deserialize(new MemoryStream(data), new ListProxy<GroupInvitationView>.Deserializer<GroupInvitationView>(GroupInvitationViewProxy.Deserialize)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001165 RID: 4453 RVA: 0x0001C67C File Offset: 0x0001A87C
		public static Coroutine CreateClan(GroupCreationView createClanData, Action<ClanCreationReturnView> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				GroupCreationViewProxy.Serialize(memoryStream, createClanData);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "CreateClan", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(ClanCreationReturnViewProxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001166 RID: 4454 RVA: 0x0001C700 File Offset: 0x0001A900
		public static Coroutine TransferOwnership(int groupId, string authToken, int newLeaderCmid, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Int32Proxy.Serialize(memoryStream, groupId);
				StringProxy.Serialize(memoryStream, authToken);
				Int32Proxy.Serialize(memoryStream, newLeaderCmid);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "TransferOwnership", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001167 RID: 4455 RVA: 0x0001C790 File Offset: 0x0001A990
		public static Coroutine CanOwnAClan(string authToken, Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StringProxy.Serialize(memoryStream, authToken);
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "CanOwnAClan", memoryStream.ToArray(), delegate(byte[] data)
				{
					if (callback != null)
					{
						callback(Int32Proxy.Deserialize(new MemoryStream(data)));
					}
				}, handler));
			}
			return result;
		}

		// Token: 0x06001168 RID: 4456 RVA: 0x0001C814 File Offset: 0x0001AA14
		public static Coroutine test(Action<int> callback, Action<Exception> handler)
		{
			Coroutine result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				result = MonoInstance.Mono.StartCoroutine(SoapClient.MakeRequest("IClanWebServiceContract", "ClanWebService", "test", memoryStream.ToArray(), delegate(byte[] data)
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
