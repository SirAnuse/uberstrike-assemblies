using System;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class PhotonServerConfiguration : MonoBehaviour
{
	// Token: 0x170005F1 RID: 1521
	// (get) Token: 0x06001AAC RID: 6828 RVA: 0x00011B00 File Offset: 0x0000FD00
	public PhotonServerConfiguration.LocalRealtimeServer CustomGameServer
	{
		get
		{
			return this._localGameServer;
		}
	}

	// Token: 0x170005F2 RID: 1522
	// (get) Token: 0x06001AAD RID: 6829 RVA: 0x00011B08 File Offset: 0x0000FD08
	public PhotonServerConfiguration.LocalRealtimeServer CustomCommServer
	{
		get
		{
			return this._localCommServer;
		}
	}

	// Token: 0x06001AAE RID: 6830 RVA: 0x0008B4C8 File Offset: 0x000896C8
	private void Awake()
	{
		if (this.CustomGameServer.IsEnabled)
		{
			for (int i = 0; i < 20; i += 5)
			{
				Singleton<GameServerManager>.Instance.AddPhotonGameServer(new PhotonView
				{
					IP = this.CustomGameServer.Ip,
					Port = this.CustomGameServer.Port,
					Name = "CUSTOM GAME SERVER",
					PhotonId = UnityEngine.Random.Range(-1, -100),
					Region = RegionType.AsiaPacific,
					UsageType = PhotonUsageType.All,
					MinLatency = i
				});
			}
		}
		if (this._localCommServer.IsEnabled)
		{
			Singleton<GameServerManager>.Instance.CommServer = new PhotonServer(this._localCommServer.Address, PhotonUsageType.CommServer);
		}
	}

	// Token: 0x040017E8 RID: 6120
	[SerializeField]
	private PhotonServerConfiguration.LocalRealtimeServer _localGameServer = new PhotonServerConfiguration.LocalRealtimeServer
	{
		Ip = "127.0.0.1",
		Port = 5155
	};

	// Token: 0x040017E9 RID: 6121
	[SerializeField]
	private PhotonServerConfiguration.LocalRealtimeServer _localCommServer = new PhotonServerConfiguration.LocalRealtimeServer
	{
		Ip = "127.0.0.1",
		Port = 5055
	};

	// Token: 0x040017EA RID: 6122
	[SerializeField]
	private bool simEnabled;

	// Token: 0x040017EB RID: 6123
	private float incomingLag;

	// Token: 0x040017EC RID: 6124
	private float outgoingLag;

	// Token: 0x040017ED RID: 6125
	private float incomingLoss;

	// Token: 0x040017EE RID: 6126
	private float outgoingLoss;

	// Token: 0x0200038D RID: 909
	[Serializable]
	public class LocalRealtimeServer
	{
		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06001AB0 RID: 6832 RVA: 0x00011B23 File Offset: 0x0000FD23
		public string Address
		{
			get
			{
				return this.Ip + ":" + this.Port;
			}
		}

		// Token: 0x040017EF RID: 6127
		public string Ip = string.Empty;

		// Token: 0x040017F0 RID: 6128
		public int Port;

		// Token: 0x040017F1 RID: 6129
		public bool IsEnabled;
	}
}
