using System;
using System.IO;
using UberStrike.Core.Serialization;
using UberStrike.Core.ViewModel;

namespace UberStrike.Realtime.Client
{
	// Token: 0x02000321 RID: 801
	public abstract class BaseCommPeer : BasePeer, IEventDispatcher
	{
		// Token: 0x06001278 RID: 4728 RVA: 0x0000BCDB File Offset: 0x00009EDB
		protected BaseCommPeer(int syncFrequency, bool monitorTraffic = false) : base(syncFrequency, monitorTraffic)
		{
			this.Operations = new CommPeerOperations(1);
			base.AddRoomLogic(this, this.Operations);
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06001279 RID: 4729 RVA: 0x0000BCFE File Offset: 0x00009EFE
		// (set) Token: 0x0600127A RID: 4730 RVA: 0x0000BD06 File Offset: 0x00009F06
		public CommPeerOperations Operations { get; private set; }

		// Token: 0x0600127B RID: 4731 RVA: 0x0001F304 File Offset: 0x0001D504
		public void OnEvent(byte id, byte[] data)
		{
			switch (id)
			{
			case 1:
				this.HeartbeatChallenge(data);
				break;
			case 2:
				this.LoadData(data);
				break;
			case 3:
				this.LobbyEntered(data);
				break;
			case 4:
				this.DisconnectAndDisablePhoton(data);
				break;
			}
		}

		// Token: 0x0600127C RID: 4732
		protected abstract void OnHeartbeatChallenge(string challengeHash);

		// Token: 0x0600127D RID: 4733
		protected abstract void OnLoadData(ServerConnectionView data);

		// Token: 0x0600127E RID: 4734
		protected abstract void OnLobbyEntered();

		// Token: 0x0600127F RID: 4735
		protected abstract void OnDisconnectAndDisablePhoton(string message);

		// Token: 0x06001280 RID: 4736 RVA: 0x0001F360 File Offset: 0x0001D560
		private void HeartbeatChallenge(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				string challengeHash = StringProxy.Deserialize(memoryStream);
				this.OnHeartbeatChallenge(challengeHash);
			}
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x0001F3A4 File Offset: 0x0001D5A4
		private void LoadData(byte[] _bytes)
		{
			using (MemoryStream memoryStream = new MemoryStream(_bytes))
			{
				ServerConnectionView data = ServerConnectionViewProxy.Deserialize(memoryStream);
				this.OnLoadData(data);
			}
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x0001F3E8 File Offset: 0x0001D5E8
		private void LobbyEntered(byte[] _bytes)
		{
			using (new MemoryStream(_bytes))
			{
				this.OnLobbyEntered();
			}
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x0001F424 File Offset: 0x0001D624
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
