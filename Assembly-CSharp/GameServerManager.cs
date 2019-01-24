using System;
using System.Collections;
using System.Collections.Generic;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UnityEngine;

// Token: 0x020002B3 RID: 691
public class GameServerManager : Singleton<GameServerManager>
{
	// Token: 0x06001322 RID: 4898 RVA: 0x0000D09B File Offset: 0x0000B29B
	private GameServerManager()
	{
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06001323 RID: 4899 RVA: 0x0000D0CF File Offset: 0x0000B2CF
	public int PhotonServerCount
	{
		get
		{
			return this._gameServers.Count;
		}
	}

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06001324 RID: 4900 RVA: 0x0000D0DC File Offset: 0x0000B2DC
	// (set) Token: 0x06001325 RID: 4901 RVA: 0x0000D0E4 File Offset: 0x0000B2E4
	public int AllPlayersCount { get; private set; }

	// Token: 0x17000495 RID: 1173
	// (get) Token: 0x06001326 RID: 4902 RVA: 0x0000D0ED File Offset: 0x0000B2ED
	// (set) Token: 0x06001327 RID: 4903 RVA: 0x0000D0F5 File Offset: 0x0000B2F5
	public int AllGamesCount { get; private set; }

	// Token: 0x17000496 RID: 1174
	// (get) Token: 0x06001328 RID: 4904 RVA: 0x0000D0FE File Offset: 0x0000B2FE
	public IEnumerable<PhotonServer> PhotonServerList
	{
		get
		{
			return this._sortedServers;
		}
	}

	// Token: 0x17000497 RID: 1175
	// (get) Token: 0x06001329 RID: 4905 RVA: 0x0000D106 File Offset: 0x0000B306
	public IEnumerable<ServerLoadRequest> ServerRequests
	{
		get
		{
			return this._loadRequests.Values;
		}
	}

	// Token: 0x0600132A RID: 4906 RVA: 0x0000D113 File Offset: 0x0000B313
	public void SortServers()
	{
		if (this._comparer != null)
		{
			this._sortedServers.Sort(this._comparer);
			if (this._reverseSorting)
			{
				this._sortedServers.Reverse();
			}
		}
	}

	// Token: 0x0600132B RID: 4907 RVA: 0x00070280 File Offset: 0x0006E480
	public PhotonServer GetBestServer()
	{
		PhotonServer bestServer = this.GetBestServer(ApplicationDataManager.IsMobile);
		if (ApplicationDataManager.IsMobile && bestServer == null)
		{
			bestServer = this.GetBestServer(false);
		}
		return bestServer;
	}

	// Token: 0x0600132C RID: 4908 RVA: 0x000702B4 File Offset: 0x0006E4B4
	private PhotonServer GetBestServer(bool doMobileFilter)
	{
		List<PhotonServer> list = new List<PhotonServer>(this._gameServers.Values);
		list.Sort((PhotonServer s, PhotonServer t) => s.Latency - t.Latency);
		PhotonServer photonServer = null;
		for (int i = 0; i < list.Count; i++)
		{
			PhotonServer photonServer2 = list[i];
			if (photonServer2.Latency != 0)
			{
				if (!doMobileFilter || photonServer2.UsageType == PhotonUsageType.Mobile)
				{
					if (photonServer == null && photonServer2.CheckLatency())
					{
						photonServer = photonServer2;
					}
					else if (photonServer2.CheckLatency() && photonServer2.Latency < 200 && photonServer.Data.PlayersConnected < photonServer2.Data.PlayersConnected)
					{
						photonServer = photonServer2;
					}
				}
			}
		}
		return photonServer;
	}

	// Token: 0x0600132D RID: 4909 RVA: 0x00070390 File Offset: 0x0006E590
	internal string GetServerName(GameRoomData room)
	{
		string result = string.Empty;
		if (room != null && room.Server != null)
		{
			foreach (PhotonServer photonServer in this._gameServers.Values)
			{
				if (photonServer.ConnectionString == room.Server.ConnectionString)
				{
					result = photonServer.Name;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x0600132E RID: 4910 RVA: 0x00070428 File Offset: 0x0006E628
	public void SortServers(IComparer<PhotonServer> comparer, bool reverse = false)
	{
		this._comparer = comparer;
		this._reverseSorting = reverse;
		List<PhotonServer> sortedServers = this._sortedServers;
		lock (sortedServers)
		{
			this._sortedServers.Clear();
			this._sortedServers.AddRange(this._gameServers.Values);
		}
		this.SortServers();
	}

	// Token: 0x0600132F RID: 4911 RVA: 0x0000D147 File Offset: 0x0000B347
	public void AddTestPhotonGameServer(int id, PhotonServer photonServer)
	{
		this._gameServers[id] = photonServer;
	}

	// Token: 0x06001330 RID: 4912 RVA: 0x00070494 File Offset: 0x0006E694
	public void AddPhotonGameServer(PhotonView view)
	{
		this._gameServers[view.PhotonId] = new PhotonServer(view);
		if (view.MinLatency > 0)
		{
			view.Name = string.Concat(new object[]
			{
				view.Name,
				" - ",
				view.MinLatency,
				"ms"
			});
		}
		this.SortServers();
	}

	// Token: 0x06001331 RID: 4913 RVA: 0x00070504 File Offset: 0x0006E704
	public void AddPhotonGameServers(List<PhotonView> servers)
	{
		foreach (PhotonView view in servers)
		{
			this.AddPhotonGameServer(view);
		}
	}

	// Token: 0x06001332 RID: 4914 RVA: 0x0007055C File Offset: 0x0006E75C
	public int GetServerLatency(string connection)
	{
		foreach (PhotonServer photonServer in this._gameServers.Values)
		{
			if (photonServer.ConnectionString == connection)
			{
				return photonServer.Latency;
			}
		}
		return 0;
	}

	// Token: 0x06001333 RID: 4915 RVA: 0x000705D4 File Offset: 0x0006E7D4
	public IEnumerator StartUpdatingServerLoads()
	{
		foreach (PhotonServer server in this._gameServers.Values)
		{
			ServerLoadRequest request;
			if (!this._loadRequests.TryGetValue(server.Id, out request))
			{
				request = ServerLoadRequest.Run(server, delegate()
				{
					this.UpdateGamesAndPlayerCount();
				});
				this._loadRequests.Add(server.Id, request);
			}
			if (request.RequestState != ServerLoadRequest.RequestStateType.Waiting)
			{
				request.Run();
			}
			yield return new WaitForSeconds(0.1f);
		}
		yield break;
	}

	// Token: 0x06001334 RID: 4916 RVA: 0x000705F0 File Offset: 0x0006E7F0
	public IEnumerator StartUpdatingLatency(Action<float> progressCallback)
	{
		yield return UnityRuntime.StartRoutine(this.StartUpdatingServerLoads());
		float minTimeout = Time.time + 4f;
		float maxTimeout = Time.time + 10f;
		int count = 0;
		while (count != this._loadRequests.Count)
		{
			yield return new WaitForSeconds(1f);
			count = 0;
			foreach (ServerLoadRequest r in this._loadRequests.Values)
			{
				if (r.RequestState != ServerLoadRequest.RequestStateType.Waiting)
				{
					count++;
				}
			}
			progressCallback((float)count / (float)this._loadRequests.Count);
			if ((count > 0 && Time.time > minTimeout) || Time.time > maxTimeout)
			{
				yield break;
			}
		}
		yield break;
	}

	// Token: 0x06001335 RID: 4917 RVA: 0x0007061C File Offset: 0x0006E81C
	private void UpdateGamesAndPlayerCount()
	{
		this.AllPlayersCount = 0;
		this.AllGamesCount = 0;
		foreach (PhotonServer photonServer in this._gameServers.Values)
		{
			this.AllPlayersCount += photonServer.Data.PlayersConnected;
			this.AllGamesCount += photonServer.Data.RoomsCreated;
		}
		this.SortServers();
	}

	// Token: 0x04001313 RID: 4883
	private const int ServerUpdateCycle = 30;

	// Token: 0x04001314 RID: 4884
	private Dictionary<int, PhotonServer> _gameServers = new Dictionary<int, PhotonServer>();

	// Token: 0x04001315 RID: 4885
	public PhotonServer CommServer = PhotonServer.Empty;

	// Token: 0x04001316 RID: 4886
	private List<PhotonServer> _sortedServers = new List<PhotonServer>();

	// Token: 0x04001317 RID: 4887
	private IComparer<PhotonServer> _comparer;

	// Token: 0x04001318 RID: 4888
	private bool _reverseSorting;

	// Token: 0x04001319 RID: 4889
	private Dictionary<int, ServerLoadRequest> _loadRequests = new Dictionary<int, ServerLoadRequest>();
}
