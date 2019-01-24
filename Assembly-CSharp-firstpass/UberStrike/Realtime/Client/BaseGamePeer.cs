using System;
using System.Collections.Generic;
using System.IO;
using Cmune.Core.Models;
using UberStrike.Core.Models;
using UberStrike.Core.Serialization;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000329 RID: 809
	public abstract class BaseGamePeer : BasePeer, IEventDispatcher
	{
		// Token: 0x060012E1 RID: 4833 RVA: 0x0000BDBE File Offset: 0x00009FBE
		protected BaseGamePeer(int syncFrequency, bool monitorTraffic = false) : base(syncFrequency, monitorTraffic)
		{
			this.Operations = new GamePeerOperations(1);
			base.AddRoomLogic(this, this.Operations);
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x060012E2 RID: 4834 RVA: 0x0000BDE1 File Offset: 0x00009FE1
		// (set) Token: 0x060012E3 RID: 4835 RVA: 0x0000BDE9 File Offset: 0x00009FE9
		public GamePeerOperations Operations { get; private set; }

		// Token: 0x060012E4 RID: 4836 RVA: 0x00021074 File Offset: 0x0001F274
		public void OnEvent(byte id, byte[] data)
		{
			switch (id)
			{
			case 1:
				this.HeartbeatChallenge(data);
				break;
			case 2:
				this.RoomEntered(data);
				break;
			case 3:
				this.RoomEnterFailed(data);
				break;
			case 4:
				this.RequestPasswordForRoom(data);
				break;
			case 5:
				this.RoomLeft(data);
				break;
			case 6:
				this.FullGameList(data);
				break;
			case 7:
				this.GameListUpdate(data);
				break;
			case 8:
				this.GameListUpdateEnd(data);
				break;
			case 9:
				this.GetGameInformation(data);
				break;
			case 10:
				this.ServerLoadData(data);
				break;
			case 11:
				this.DisconnectAndDisablePhoton(data);
				break;
			}
		}

		// Token: 0x060012E5 RID: 4837
		protected abstract void OnHeartbeatChallenge(string challengeHash);

		// Token: 0x060012E6 RID: 4838
		protected abstract void OnRoomEntered(GameRoomData game);

		// Token: 0x060012E7 RID: 4839
		protected abstract void OnRoomEnterFailed(string server, int roomId, string message);

		// Token: 0x060012E8 RID: 4840
		protected abstract void OnRequestPasswordForRoom(string server, int roomId);

		// Token: 0x060012E9 RID: 4841
		protected abstract void OnRoomLeft();

		// Token: 0x060012EA RID: 4842
		protected abstract void OnFullGameList(List<GameRoomData> gameList);

		// Token: 0x060012EB RID: 4843
		protected abstract void OnGameListUpdate(List<GameRoomData> updatedGames, List<int> removedGames);

		// Token: 0x060012EC RID: 4844
		protected abstract void OnGameListUpdateEnd();

		// Token: 0x060012ED RID: 4845
		protected abstract void OnGetGameInformation(GameRoomData room, List<GameActorInfo> players, int endTime);

		// Token: 0x060012EE RID: 4846
		protected abstract void OnServerLoadData(PhotonServerLoad data);

		// Token: 0x060012EF RID: 4847
		protected abstract void OnDisconnectAndDisablePhoton(string message);

		// Token: 0x060012F0 RID: 4848 RVA: 0x00021140 File Offset: 0x0001F340
		private void HeartbeatChallenge(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				string challengeHash = StringProxy.Deserialize(memoryStream);
				this.OnHeartbeatChallenge(challengeHash);
			}
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x00021184 File Offset: 0x0001F384
		private void RoomEntered(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				GameRoomData game = GameRoomDataProxy.Deserialize(memoryStream);
				this.OnRoomEntered(game);
			}
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x000211C8 File Offset: 0x0001F3C8
		private void RoomEnterFailed(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				string server = StringProxy.Deserialize(memoryStream);
				int roomId = Int32Proxy.Deserialize(memoryStream);
				string message = StringProxy.Deserialize(memoryStream);
				this.OnRoomEnterFailed(server, roomId, message);
			}
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x0002121C File Offset: 0x0001F41C
		private void RequestPasswordForRoom(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				string server = StringProxy.Deserialize(memoryStream);
				int roomId = Int32Proxy.Deserialize(memoryStream);
				this.OnRequestPasswordForRoom(server, roomId);
			}
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x00021268 File Offset: 0x0001F468
		private void RoomLeft(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnRoomLeft();
			}
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x000212A4 File Offset: 0x0001F4A4
		private void FullGameList(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<GameRoomData> gameList = ListProxy<GameRoomData>.Deserialize(memoryStream, new ListProxy<GameRoomData>.Deserializer<GameRoomData>(GameRoomDataProxy.Deserialize));
				this.OnFullGameList(gameList);
			}
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x000212F4 File Offset: 0x0001F4F4
		private void GameListUpdate(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				List<GameRoomData> updatedGames = ListProxy<GameRoomData>.Deserialize(memoryStream, new ListProxy<GameRoomData>.Deserializer<GameRoomData>(GameRoomDataProxy.Deserialize));
				List<int> removedGames = ListProxy<int>.Deserialize(memoryStream, new ListProxy<int>.Deserializer<int>(Int32Proxy.Deserialize));
				this.OnGameListUpdate(updatedGames, removedGames);
			}
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x00021358 File Offset: 0x0001F558
		private void GameListUpdateEnd(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnGameListUpdateEnd();
			}
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x00021394 File Offset: 0x0001F594
		private void GetGameInformation(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				GameRoomData room = GameRoomDataProxy.Deserialize(memoryStream);
				List<GameActorInfo> players = ListProxy<GameActorInfo>.Deserialize(memoryStream, new ListProxy<GameActorInfo>.Deserializer<GameActorInfo>(GameActorInfoProxy.Deserialize));
				int endTime = Int32Proxy.Deserialize(memoryStream);
				this.OnGetGameInformation(room, players, endTime);
			}
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x000213F4 File Offset: 0x0001F5F4
		private void ServerLoadData(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				PhotonServerLoad data = PhotonServerLoadProxy.Deserialize(memoryStream);
				this.OnServerLoadData(data);
			}
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x00021438 File Offset: 0x0001F638
		private void DisconnectAndDisablePhoton(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				string message = StringProxy.Deserialize(memoryStream);
				this.OnDisconnectAndDisablePhoton(message);
			}
		}
	}
}
