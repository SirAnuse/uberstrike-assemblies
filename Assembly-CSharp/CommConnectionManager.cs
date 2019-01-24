using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000376 RID: 886
public class CommConnectionManager : AutoMonoBehaviour<CommConnectionManager>
{
	// Token: 0x170005BC RID: 1468
	// (get) Token: 0x0600190B RID: 6411 RVA: 0x00010B52 File Offset: 0x0000ED52
	// (set) Token: 0x0600190C RID: 6412 RVA: 0x00010B5A File Offset: 0x0000ED5A
	public CommPeer Client { get; private set; }

	// Token: 0x0600190D RID: 6413 RVA: 0x00010B63 File Offset: 0x0000ED63
	private void Awake()
	{
		this.Client = new CommPeer();
		base.StartCoroutine(this.StartCheckingCommServerConnection());
		global::EventHandler.Global.AddListener<GlobalEvents.Login>(new Action<GlobalEvents.Login>(this.OnLoginEvent));
	}

	// Token: 0x0600190E RID: 6414 RVA: 0x00003C87 File Offset: 0x00001E87
	private void OnLoginEvent(GlobalEvents.Login ev)
	{
	}

	// Token: 0x0600190F RID: 6415 RVA: 0x000865FC File Offset: 0x000847FC
	private void Update()
	{
		if (this._pollFriendsOnlineStatus < Time.time)
		{
			this._pollFriendsOnlineStatus = Time.time + 30f;
			if (MenuPageManager.Instance != null && (MenuPageManager.Instance.IsCurrentPage(PageType.Chat) || MenuPageManager.Instance.IsCurrentPage(PageType.Clans)))
			{
				this.Client.Lobby.UpdateContacts();
			}
		}
	}

	// Token: 0x06001910 RID: 6416 RVA: 0x00010B93 File Offset: 0x0000ED93
	public void Reconnect()
	{
		this.Stop();
		this.Awake();
	}

	// Token: 0x06001911 RID: 6417 RVA: 0x0008666C File Offset: 0x0008486C
	private IEnumerator StartCheckingCommServerConnection()
	{
		for (;;)
		{
			yield return new WaitForSeconds(5f);
			if (this.Client.IsEnabled && !this.Client.IsConnected && Singleton<GameServerManager>.Instance.CommServer.IsValid && PlayerDataManager.IsPlayerLoggedIn)
			{
				this.Client.Connect(Singleton<GameServerManager>.Instance.CommServer.ConnectionString);
			}
		}
		yield break;
	}

	// Token: 0x06001912 RID: 6418 RVA: 0x00010BA1 File Offset: 0x0000EDA1
	public void Stop()
	{
		this.Client.Disconnect();
	}

	// Token: 0x06001913 RID: 6419 RVA: 0x00086688 File Offset: 0x00084888
	internal void DisableNetworkConnection(string message)
	{
		Debug.LogError("DisableNetworkConnection");
		if (GameState.Current.HasJoinedGame)
		{
			global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
		}
		AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Dispose();
		Singleton<GameStateController>.Instance.Client.Dispose();
		ApplicationDataManager.LockApplication(message);
	}

	// Token: 0x0400176A RID: 5994
	private float _pollFriendsOnlineStatus;
}
