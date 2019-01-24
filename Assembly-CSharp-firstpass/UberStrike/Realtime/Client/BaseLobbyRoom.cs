using System;
using System.Collections.Generic;
using System.IO;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Serialization;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000322 RID: 802
	public abstract class BaseLobbyRoom : IEventDispatcher, IRoomLogic
	{
		// Token: 0x06001284 RID: 4740 RVA: 0x0000BD0F File Offset: 0x00009F0F
		protected BaseLobbyRoom()
		{
			this.Operations = new LobbyRoomOperations(0);
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06001285 RID: 4741 RVA: 0x0000BD23 File Offset: 0x00009F23
		IOperationSender IRoomLogic.Operations
		{
			get
			{
				return this.Operations;
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06001286 RID: 4742 RVA: 0x0000BD2B File Offset: 0x00009F2B
		// (set) Token: 0x06001287 RID: 4743 RVA: 0x0000BD33 File Offset: 0x00009F33
		public LobbyRoomOperations Operations { get; private set; }

		// Token: 0x06001288 RID: 4744 RVA: 0x0001F468 File Offset: 0x0001D668
		public void OnEvent(byte id, byte[] data)
		{
			switch (id)
			{
			case 5:
				this.PlayerHide(data);
				break;
			case 6:
				this.PlayerLeft(data);
				break;
			case 7:
				this.PlayerUpdate(data);
				break;
			case 8:
				this.UpdateContacts(data);
				break;
			case 9:
				this.FullPlayerListUpdate(data);
				break;
			case 10:
				this.PlayerJoined(data);
				break;
			case 11:
				this.ClanChatMessage(data);
				break;
			case 12:
				this.InGameChatMessage(data);
				break;
			case 13:
				this.LobbyChatMessage(data);
				break;
			case 14:
				this.PrivateChatMessage(data);
				break;
			case 15:
				this.UpdateInboxRequests(data);
				break;
			case 16:
				this.UpdateFriendsList(data);
				break;
			case 17:
				this.UpdateInboxMessages(data);
				break;
			case 18:
				this.UpdateClanMembers(data);
				break;
			case 19:
				this.UpdateClanData(data);
				break;
			case 20:
				this.UpdateActorsForModeration(data);
				break;
			case 21:
				this.ModerationCustomMessage(data);
				break;
			case 22:
				this.ModerationMutePlayer(data);
				break;
			case 23:
				this.ModerationKickGame(data);
				break;
			}
		}

		// Token: 0x06001289 RID: 4745
		protected abstract void OnPlayerHide(int cmid);

		// Token: 0x0600128A RID: 4746
		protected abstract void OnPlayerLeft(int cmid, bool refreshComm);

		// Token: 0x0600128B RID: 4747
		protected abstract void OnPlayerUpdate(CommActorInfo data);

		// Token: 0x0600128C RID: 4748
		protected abstract void OnUpdateContacts(List<CommActorInfo> updated, List<int> removed);

		// Token: 0x0600128D RID: 4749
		protected abstract void OnFullPlayerListUpdate(List<CommActorInfo> players);

		// Token: 0x0600128E RID: 4750
		protected abstract void OnPlayerJoined(CommActorInfo data);

		// Token: 0x0600128F RID: 4751
		protected abstract void OnClanChatMessage(int cmid, string name, string message);

		// Token: 0x06001290 RID: 4752
		protected abstract void OnInGameChatMessage(int cmid, string name, string message, MemberAccessLevel accessLevel, byte context);

		// Token: 0x06001291 RID: 4753
		protected abstract void OnLobbyChatMessage(int cmid, string name, string message);

		// Token: 0x06001292 RID: 4754
		protected abstract void OnPrivateChatMessage(int cmid, string name, string message);

		// Token: 0x06001293 RID: 4755
		protected abstract void OnUpdateInboxRequests();

		// Token: 0x06001294 RID: 4756
		protected abstract void OnUpdateFriendsList();

		// Token: 0x06001295 RID: 4757
		protected abstract void OnUpdateInboxMessages(int messageId);

		// Token: 0x06001296 RID: 4758
		protected abstract void OnUpdateClanMembers();

		// Token: 0x06001297 RID: 4759
		protected abstract void OnUpdateClanData();

		// Token: 0x06001298 RID: 4760
		protected abstract void OnUpdateActorsForModeration(List<CommActorInfo> allHackers);

		// Token: 0x06001299 RID: 4761
		protected abstract void OnModerationCustomMessage(string message);

		// Token: 0x0600129A RID: 4762
		protected abstract void OnModerationMutePlayer(bool isPlayerMuted);

		// Token: 0x0600129B RID: 4763
		protected abstract void OnModerationKickGame();

		// Token: 0x0600129C RID: 4764 RVA: 0x0001F5B4 File Offset: 0x0001D7B4
		private void PlayerHide(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				this.OnPlayerHide(cmid);
			}
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x0001F5F8 File Offset: 0x0001D7F8
		private void PlayerLeft(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				bool refreshComm = BooleanProxy.Deserialize(memoryStream);
				this.OnPlayerLeft(cmid, refreshComm);
			}
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x0001F644 File Offset: 0x0001D844
		private void PlayerUpdate(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				CommActorInfo data = CommActorInfoProxy.Deserialize(memoryStream);
				this.OnPlayerUpdate(data);
			}
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x0001F688 File Offset: 0x0001D888
		private void UpdateContacts(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<CommActorInfo> updated = ListProxy<CommActorInfo>.Deserialize(memoryStream, new ListProxy<CommActorInfo>.Deserializer<CommActorInfo>(CommActorInfoProxy.Deserialize));
				List<int> removed = ListProxy<int>.Deserialize(memoryStream, new ListProxy<int>.Deserializer<int>(Int32Proxy.Deserialize));
				this.OnUpdateContacts(updated, removed);
			}
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x0001F6EC File Offset: 0x0001D8EC
		private void FullPlayerListUpdate(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<CommActorInfo> players = ListProxy<CommActorInfo>.Deserialize(memoryStream, new ListProxy<CommActorInfo>.Deserializer<CommActorInfo>(CommActorInfoProxy.Deserialize));
				this.OnFullPlayerListUpdate(players);
			}
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x0001F73C File Offset: 0x0001D93C
		private void PlayerJoined(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				CommActorInfo data = CommActorInfoProxy.Deserialize(memoryStream);
				this.OnPlayerJoined(data);
			}
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x0001F780 File Offset: 0x0001D980
		private void ClanChatMessage(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				string name = StringProxy.Deserialize(memoryStream);
				string message = StringProxy.Deserialize(memoryStream);
				this.OnClanChatMessage(cmid, name, message);
			}
		}

		// Token: 0x060012A3 RID: 4771 RVA: 0x0001F7D4 File Offset: 0x0001D9D4
		private void InGameChatMessage(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				string name = StringProxy.Deserialize(memoryStream);
				string message = StringProxy.Deserialize(memoryStream);
				MemberAccessLevel accessLevel = EnumProxy<MemberAccessLevel>.Deserialize(memoryStream);
				byte context = ByteProxy.Deserialize(memoryStream);
				this.OnInGameChatMessage(cmid, name, message, accessLevel, context);
			}
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x0001F83C File Offset: 0x0001DA3C
		private void LobbyChatMessage(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				string name = StringProxy.Deserialize(memoryStream);
				string message = StringProxy.Deserialize(memoryStream);
				this.OnLobbyChatMessage(cmid, name, message);
			}
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x0001F890 File Offset: 0x0001DA90
		private void PrivateChatMessage(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int cmid = Int32Proxy.Deserialize(memoryStream);
				string name = StringProxy.Deserialize(memoryStream);
				string message = StringProxy.Deserialize(memoryStream);
				this.OnPrivateChatMessage(cmid, name, message);
			}
		}

		// Token: 0x060012A6 RID: 4774 RVA: 0x0001F8E4 File Offset: 0x0001DAE4
		private void UpdateInboxRequests(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnUpdateInboxRequests();
			}
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x0001F920 File Offset: 0x0001DB20
		private void UpdateFriendsList(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnUpdateFriendsList();
			}
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x0001F95C File Offset: 0x0001DB5C
		private void UpdateInboxMessages(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				int messageId = Int32Proxy.Deserialize(memoryStream);
				this.OnUpdateInboxMessages(messageId);
			}
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x0001F9A0 File Offset: 0x0001DBA0
		private void UpdateClanMembers(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnUpdateClanMembers();
			}
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x0001F9DC File Offset: 0x0001DBDC
		private void UpdateClanData(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnUpdateClanData();
			}
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x0001FA18 File Offset: 0x0001DC18
		private void UpdateActorsForModeration(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<CommActorInfo> allHackers = ListProxy<CommActorInfo>.Deserialize(memoryStream, new ListProxy<CommActorInfo>.Deserializer<CommActorInfo>(CommActorInfoProxy.Deserialize));
				this.OnUpdateActorsForModeration(allHackers);
			}
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x0001FA68 File Offset: 0x0001DC68
		private void ModerationCustomMessage(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				string message = StringProxy.Deserialize(memoryStream);
				this.OnModerationCustomMessage(message);
			}
		}

		// Token: 0x060012AD RID: 4781 RVA: 0x0001FAAC File Offset: 0x0001DCAC
		private void ModerationMutePlayer(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				bool isPlayerMuted = BooleanProxy.Deserialize(memoryStream);
				this.OnModerationMutePlayer(isPlayerMuted);
			}
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x0001FAF0 File Offset: 0x0001DCF0
		private void ModerationKickGame(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnModerationKickGame();
			}
		}
	}
}
