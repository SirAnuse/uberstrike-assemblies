using System;
using ExitGames.Client.Photon;
using UberStrike.Core.Models;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

namespace UberStrike.Realtime.Client
{
	// Token: 0x0200031A RID: 794
	public abstract class BasePeer : IDisposable
	{
		// Token: 0x0600122C RID: 4652 RVA: 0x0001E348 File Offset: 0x0001C548
		protected BasePeer(int syncFrequency, bool monitorTraffic)
		{
			this.listener = new PhotonPeerListener();
			this.Peer = new PhotonPeer(this.listener, ConnectionProtocol.Udp);
			this.SyncFrequency = (float)syncFrequency / 1000f;
			this.Monitor = new TrafficMonitor(monitorTraffic);
			this.IsEnabled = true;
			if (monitorTraffic)
			{
				this.listener.OnError += delegate(string error)
				{
					this.Monitor.AddEvent(error);
				};
				this.listener.OnConnect += delegate()
				{
					this.Monitor.AddEvent("Connected");
				};
				this.listener.OnDisconnect += delegate(StatusCode s)
				{
					this.Monitor.AddEvent("Disconnected");
				};
				this.listener.EventDispatcher += this.Monitor.OnEvent;
			}
			this.listener.OnConnect += this.OnConnected;
			this.listener.OnDisconnect += this.OnDisconnected;
			this.listener.OnError += this.OnError;
			UnityRuntime.Instance.OnUpdate += this.SendDispatch;
			this.StartFallbackSendAckThread();
			UnityRuntime.Instance.OnShutdown += this.StopFallbackSendAckThread;
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x0600122D RID: 4653 RVA: 0x0000BA10 File Offset: 0x00009C10
		// (set) Token: 0x0600122E RID: 4654 RVA: 0x0000BA18 File Offset: 0x00009C18
		public TrafficMonitor Monitor { get; private set; }

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x0600122F RID: 4655 RVA: 0x0000BA21 File Offset: 0x00009C21
		// (set) Token: 0x06001230 RID: 4656 RVA: 0x0000BA29 File Offset: 0x00009C29
		public PhotonPeer Peer { get; private set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06001231 RID: 4657 RVA: 0x0000BA32 File Offset: 0x00009C32
		// (set) Token: 0x06001232 RID: 4658 RVA: 0x0000BA3A File Offset: 0x00009C3A
		public bool IsEnabled { get; private set; }

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x0000BA43 File Offset: 0x00009C43
		// (set) Token: 0x06001234 RID: 4660 RVA: 0x0000BA4B File Offset: 0x00009C4B
		public float SyncFrequency { get; private set; }

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x0000BA54 File Offset: 0x00009C54
		public int ServerTimeTicks
		{
			get
			{
				return this.Peer.ServerTimeInMilliSeconds & int.MaxValue;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06001236 RID: 4662 RVA: 0x0000BA67 File Offset: 0x00009C67
		public bool IsConnected
		{
			get
			{
				return this.Peer.PeerState == PeerStateValue.Connected;
			}
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x0000BA77 File Offset: 0x00009C77
		public void Dispose()
		{
			if (this.IsEnabled)
			{
				this.Disconnect();
				this.IsEnabled = false;
				this.listener.ClearEvents();
				UnityRuntime.Instance.OnUpdate -= this.SendDispatch;
			}
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x0001E47C File Offset: 0x0001C67C
		public void Connect(string endpointAddress)
		{
			if (this.Monitor.IsEnabled)
			{
				this.Monitor.AddEvent("Connect " + endpointAddress);
			}
			string ipAddress = new ConnectionAddress(endpointAddress).IpAddress;
			if (CrossdomainPolicy.HasValidPolicy(ipAddress))
			{
				this.ConnectToServer(endpointAddress);
			}
			else
			{
				UnityRuntime.Instance.StartCoroutine(CrossdomainPolicy.CheckPolicyRoutine(ipAddress, delegate
				{
					if (CrossdomainPolicy.HasValidPolicy(ipAddress))
					{
						this.ConnectToServer(endpointAddress);
					}
					else
					{
						this.OnConnectionFail(endpointAddress);
					}
				}));
			}
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x0000BAB2 File Offset: 0x00009CB2
		private void ConnectToServer(string endpointAddress)
		{
			if (!this.IsEnabled || !this.Peer.Connect(endpointAddress, ApiVersion.Current))
			{
				Debug.LogWarning("connection failed to " + endpointAddress);
				this.OnConnectionFail(endpointAddress);
			}
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x0000BAF1 File Offset: 0x00009CF1
		public void Disconnect()
		{
			if (this.Monitor.IsEnabled)
			{
				this.Monitor.AddEvent("Disconnect");
			}
			this.Peer.SendOutgoingCommands();
			this.Peer.Disconnect();
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x0000BB2A File Offset: 0x00009D2A
		private void SendDispatch()
		{
			if (this.Peer.PeerState != PeerStateValue.Disconnected)
			{
				this.Peer.Service();
			}
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x0000BB47 File Offset: 0x00009D47
		public void StartFallbackSendAckThread()
		{
			if (this.sendThreadShouldRun)
			{
				return;
			}
			this.sendThreadShouldRun = true;
			SupportClass.CallInBackground(new Func<bool>(this.FallbackSendAckThread));
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x0000BB6D File Offset: 0x00009D6D
		public void StopFallbackSendAckThread()
		{
			this.sendThreadShouldRun = false;
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x0000BB76 File Offset: 0x00009D76
		public bool FallbackSendAckThread()
		{
			if (this.sendThreadShouldRun && this.Peer != null)
			{
				this.Peer.SendAcksOnly();
			}
			return this.sendThreadShouldRun;
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x0001E528 File Offset: 0x0001C728
		protected void AddRoomLogic(IEventDispatcher evDispatcher, IOperationSender opSender)
		{
			if (this.Monitor.IsEnabled)
			{
				opSender.SendOperation += this.Monitor.SendOperation;
			}
			opSender.SendOperation += this.Peer.OpCustom;
			this.listener.EventDispatcher += evDispatcher.OnEvent;
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x0001E58C File Offset: 0x0001C78C
		protected void RemoveRoomLogic(IEventDispatcher evDispatcher, IOperationSender opSender)
		{
			if (this.Monitor.IsEnabled)
			{
				opSender.SendOperation -= this.Monitor.SendOperation;
			}
			opSender.SendOperation -= this.Peer.OpCustom;
			this.listener.EventDispatcher -= evDispatcher.OnEvent;
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x0000BBA0 File Offset: 0x00009DA0
		public override string ToString()
		{
			return this.Peer.PeerState.ToString();
		}

		// Token: 0x06001242 RID: 4674
		protected abstract void OnConnected();

		// Token: 0x06001243 RID: 4675
		protected abstract void OnDisconnected(StatusCode status);

		// Token: 0x06001244 RID: 4676
		protected abstract void OnError(string message);

		// Token: 0x06001245 RID: 4677 RVA: 0x00004074 File Offset: 0x00002274
		protected virtual void OnConnectionFail(string endpointAddress)
		{
		}

		// Token: 0x04000D13 RID: 3347
		private float nextUpdateTime;

		// Token: 0x04000D14 RID: 3348
		private PhotonPeerListener listener;

		// Token: 0x04000D15 RID: 3349
		private bool sendThreadShouldRun;
	}
}
