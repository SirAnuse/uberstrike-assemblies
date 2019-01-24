using System;
using System.Collections.Generic;
using System.Text;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000176 RID: 374
public class ChatManager : Singleton<ChatManager>
{
	// Token: 0x060009FC RID: 2556 RVA: 0x0003F2FC File Offset: 0x0003D4FC
	private ChatManager()
	{
		this._otherUsers = new List<CommUser>();
		this._friendUsers = new List<CommUser>();
		this._lobbyUsers = new List<CommUser>();
		this._clanUsers = new Dictionary<int, CommUser>();
		this._naughtyUsers = new Dictionary<int, CommUser>();
		this._ingameUsers = new List<CommUser>();
		this._lastgameUsers = new List<CommUser>();
		this._allTimePlayers = new Dictionary<int, CommUser>();
		this._dialogsByCmid = new Dictionary<int, ChatDialog>();
		this._mutedCmids = new HashSet<int>();
		this.ClanDialog = new ChatDialog(LocalizedStrings.ChatInClan);
		this.LobbyDialog = new ChatDialog(LocalizedStrings.ChatInLobby);
		this.ModerationDialog = new ChatDialog(LocalizedStrings.Moderate);
		this.InGameDialog = new ChatDialog(string.Empty);
		this.InGameDialog.CanShow = new ChatDialog.CanShowMessage(ChatManager.CanShowMessage);
		this._commPanes = new ChatGroupPanel[5];
		this._commPanes[0] = new ChatGroupPanel();
		this._commPanes[1] = new ChatGroupPanel();
		this._commPanes[2] = new ChatGroupPanel();
		this._commPanes[3] = new ChatGroupPanel();
		this._commPanes[4] = new ChatGroupPanel();
		this._tabAreas = new HashSet<TabArea>
		{
			TabArea.Lobby,
			TabArea.Private
		};
		this._commPanes[0].AddGroup(UserGroups.None, LocalizedStrings.Lobby, this.LobbyUsers);
		this._commPanes[1].AddGroup(UserGroups.Friend, LocalizedStrings.Friends, this.FriendUsers);
		this._commPanes[1].AddGroup(UserGroups.Other, LocalizedStrings.Others, this.OtherUsers);
		this._commPanes[2].AddGroup(UserGroups.None, LocalizedStrings.Clan, this.ClanUsers);
		this._commPanes[3].AddGroup(UserGroups.None, LocalizedStrings.Game, this.GameUsers);
		this._commPanes[3].AddGroup(UserGroups.Other, "History", this.GameHistoryUsers);
		this._commPanes[4].AddGroup(UserGroups.None, "Naughty List", this.NaughtyUsers);
		global::EventHandler.Global.AddListener<GlobalEvents.Login>(new Action<GlobalEvents.Login>(this.OnLoginEvent));
	}

	// Token: 0x170002C9 RID: 713
	// (get) Token: 0x060009FD RID: 2557 RVA: 0x0000840D File Offset: 0x0000660D
	public int TotalContacts
	{
		get
		{
			return this._friendUsers.Count + this._otherUsers.Count + this._clanUsers.Count;
		}
	}

	// Token: 0x170002CA RID: 714
	// (get) Token: 0x060009FE RID: 2558 RVA: 0x00008432 File Offset: 0x00006632
	// (set) Token: 0x060009FF RID: 2559 RVA: 0x0000843A File Offset: 0x0000663A
	public ChatDialog ClanDialog { get; private set; }

	// Token: 0x170002CB RID: 715
	// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00008443 File Offset: 0x00006643
	// (set) Token: 0x06000A01 RID: 2561 RVA: 0x0000844B File Offset: 0x0000664B
	public ChatDialog LobbyDialog { get; private set; }

	// Token: 0x170002CC RID: 716
	// (get) Token: 0x06000A02 RID: 2562 RVA: 0x00008454 File Offset: 0x00006654
	// (set) Token: 0x06000A03 RID: 2563 RVA: 0x0000845C File Offset: 0x0000665C
	public ChatDialog InGameDialog { get; private set; }

	// Token: 0x170002CD RID: 717
	// (get) Token: 0x06000A04 RID: 2564 RVA: 0x00008465 File Offset: 0x00006665
	// (set) Token: 0x06000A05 RID: 2565 RVA: 0x0000846D File Offset: 0x0000666D
	public ChatDialog ModerationDialog { get; private set; }

	// Token: 0x170002CE RID: 718
	// (get) Token: 0x06000A06 RID: 2566 RVA: 0x00008476 File Offset: 0x00006676
	public ICollection<CommUser> OtherUsers
	{
		get
		{
			return this._otherUsers;
		}
	}

	// Token: 0x170002CF RID: 719
	// (get) Token: 0x06000A07 RID: 2567 RVA: 0x0000847E File Offset: 0x0000667E
	public ICollection<CommUser> FriendUsers
	{
		get
		{
			return this._friendUsers;
		}
	}

	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06000A08 RID: 2568 RVA: 0x00008486 File Offset: 0x00006686
	public ICollection<CommUser> LobbyUsers
	{
		get
		{
			return this._lobbyUsers;
		}
	}

	// Token: 0x170002D1 RID: 721
	// (get) Token: 0x06000A09 RID: 2569 RVA: 0x0000848E File Offset: 0x0000668E
	public ICollection<CommUser> ClanUsers
	{
		get
		{
			return this._clanUsers.Values;
		}
	}

	// Token: 0x170002D2 RID: 722
	// (get) Token: 0x06000A0A RID: 2570 RVA: 0x0000849B File Offset: 0x0000669B
	public ICollection<CommUser> NaughtyUsers
	{
		get
		{
			return this._naughtyUsers.Values;
		}
	}

	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06000A0B RID: 2571 RVA: 0x000084A8 File Offset: 0x000066A8
	public ICollection<CommUser> GameUsers
	{
		get
		{
			return this._ingameUsers;
		}
	}

	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06000A0C RID: 2572 RVA: 0x000084B0 File Offset: 0x000066B0
	public ICollection<CommUser> GameHistoryUsers
	{
		get
		{
			return this._lastgameUsers;
		}
	}

	// Token: 0x06000A0D RID: 2573 RVA: 0x000084B8 File Offset: 0x000066B8
	protected override void OnDispose()
	{
		global::EventHandler.Global.RemoveListener<GlobalEvents.Login>(new Action<GlobalEvents.Login>(this.OnLoginEvent));
	}

	// Token: 0x06000A0E RID: 2574 RVA: 0x000084D0 File Offset: 0x000066D0
	private void OnLoginEvent(GlobalEvents.Login ev)
	{
		if (ev.AccessLevel >= MemberAccessLevel.Moderator)
		{
			this._tabAreas.Add(TabArea.Moderation);
		}
	}

	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06000A0F RID: 2575 RVA: 0x0003F51C File Offset: 0x0003D71C
	public int TabCounter
	{
		get
		{
			return this._tabAreas.Count + ((!this.ShowTab(TabArea.InGame)) ? 0 : 1) + ((!this.ShowTab(TabArea.Clan)) ? 0 : 1) + ((!this.ShowTab(TabArea.Moderation)) ? 0 : 1);
		}
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x000084EB File Offset: 0x000066EB
	public bool IsMuted(int cmid)
	{
		return this._mutedCmids.Contains(cmid);
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x0003F570 File Offset: 0x0003D770
	public void HideConversations(int cmid)
	{
		this._mutedCmids.Add(cmid);
		this.LobbyDialog.RecalulateBounds();
		ChatDialog chatDialog;
		if (this._dialogsByCmid.TryGetValue(cmid, out chatDialog))
		{
			chatDialog.RecalulateBounds();
		}
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x0003F5B0 File Offset: 0x0003D7B0
	public void ShowConversations(int cmid)
	{
		this._mutedCmids.Remove(cmid);
		this.LobbyDialog.RecalulateBounds();
		ChatDialog chatDialog;
		if (this._dialogsByCmid.TryGetValue(cmid, out chatDialog))
		{
			chatDialog.RecalulateBounds();
		}
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x0003F5F0 File Offset: 0x0003D7F0
	public bool ShowTab(TabArea tab)
	{
		switch (tab)
		{
		case TabArea.Clan:
			return PlayerDataManager.IsPlayerInClan;
		case TabArea.InGame:
			return GameState.Current.HasJoinedGame || Singleton<ChatManager>.Instance.GameHistoryUsers.Count > 0;
		case TabArea.Moderation:
			return PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator;
		default:
			return this._tabAreas.Contains(tab);
		}
	}

	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06000A14 RID: 2580 RVA: 0x000084F9 File Offset: 0x000066F9
	public static ChatContext CurrentChatContext
	{
		get
		{
			return (!GameState.Current.PlayerData.IsSpectator) ? ChatContext.Player : ChatContext.Spectator;
		}
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x0003F65C File Offset: 0x0003D85C
	public static bool CanShowMessage(ChatContext ctx)
	{
		if (GameState.Current.HasJoinedGame && GameState.Current.GameMode == GameModeType.EliminationMode && GameState.Current.IsInGame)
		{
			ChatContext chatContext = (!GameState.Current.PlayerData.IsSpectator) ? ChatContext.Player : ChatContext.Spectator;
			return ctx == chatContext;
		}
		return true;
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x00008516 File Offset: 0x00006716
	public bool HasDialogWith(int cmid)
	{
		return this._dialogsByCmid.ContainsKey(cmid);
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x0003F6BC File Offset: 0x0003D8BC
	public void UpdateClanSection()
	{
		Singleton<ChatManager>.Instance._clanUsers.Clear();
		foreach (ClanMemberView clanMemberView in Singleton<PlayerDataManager>.Instance.ClanMembers)
		{
			Singleton<ChatManager>.Instance._clanUsers[clanMemberView.Cmid] = new CommUser(clanMemberView);
		}
		this.RefreshAll(true);
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x0003F744 File Offset: 0x0003D944
	public void RefreshAll(bool forceRefresh = false)
	{
		if (forceRefresh || this._nextRefreshTime < Time.time)
		{
			this._nextRefreshTime = Time.time + 5f;
			this._lobbyUsers.Clear();
			foreach (CommActorInfo commActorInfo in AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Players)
			{
				if (commActorInfo.Cmid > 0)
				{
					CommUser item = new CommUser(commActorInfo)
					{
						IsClanMember = PlayerDataManager.IsClanMember(commActorInfo.Cmid),
						IsFriend = PlayerDataManager.IsFriend(commActorInfo.Cmid),
						IsFacebookFriend = PlayerDataManager.IsFacebookFriend(commActorInfo.Cmid),
						IsOnline = true
					};
					this._lobbyUsers.Add(item);
				}
			}
			this._lobbyUsers.Sort(new CommUserNameComparer());
			this._lobbyUsers.Sort(new CommUserFriendsComparer());
			foreach (CommUser commUser in Singleton<ChatManager>.Instance._lastgameUsers)
			{
				commUser.IsClanMember = PlayerDataManager.IsClanMember(commUser.Cmid);
				commUser.IsFriend = PlayerDataManager.IsFriend(commUser.Cmid);
				commUser.IsFacebookFriend = PlayerDataManager.IsFacebookFriend(commUser.Cmid);
				CommActorInfo actor;
				if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.TryGetPlayer(commUser.Cmid, out actor))
				{
					commUser.SetActor(actor);
				}
				else
				{
					commUser.SetActor(null);
				}
			}
			Singleton<ChatManager>.Instance._lastgameUsers.Sort(new CommUserPresenceComparer());
			foreach (CommUser commUser2 in Singleton<ChatManager>.Instance._friendUsers)
			{
				CommActorInfo actor;
				if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.TryGetPlayer(commUser2.Cmid, out actor))
				{
					commUser2.SetActor(actor);
				}
				else
				{
					commUser2.SetActor(null);
				}
			}
			Singleton<ChatManager>.Instance._friendUsers.Sort(new CommUserPresenceComparer());
			foreach (CommUser commUser3 in Singleton<ChatManager>.Instance._clanUsers.Values)
			{
				CommActorInfo actor;
				if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.TryGetPlayer(commUser3.Cmid, out actor))
				{
					commUser3.SetActor(actor);
				}
				else
				{
					commUser3.SetActor(null);
				}
			}
			foreach (CommUser commUser4 in Singleton<ChatManager>.Instance._otherUsers)
			{
				CommActorInfo actor;
				if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.TryGetPlayer(commUser4.Cmid, out actor))
				{
					commUser4.SetActor(actor);
				}
				else
				{
					commUser4.SetActor(null);
				}
			}
			Singleton<ChatManager>.Instance._otherUsers.Sort(new CommUserNameComparer());
			foreach (KeyValuePair<int, CommUser> keyValuePair in Singleton<ChatManager>.Instance._naughtyUsers)
			{
				CommActorInfo actor;
				if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.TryGetPlayer(keyValuePair.Key, out actor))
				{
					keyValuePair.Value.SetActor(actor);
				}
				else
				{
					keyValuePair.Value.SetActor(null);
				}
			}
		}
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x0003FB5C File Offset: 0x0003DD5C
	public void UpdateFriendSection()
	{
		List<CommUser> list = new List<CommUser>(Singleton<ChatManager>.Instance._friendUsers);
		Singleton<ChatManager>.Instance._friendUsers.Clear();
		foreach (PublicProfileView profile in Singleton<PlayerDataManager>.Instance.FriendList)
		{
			Singleton<ChatManager>.Instance._friendUsers.Add(new CommUser(profile));
		}
		foreach (PublicProfileView profile2 in Singleton<PlayerDataManager>.Instance.FacebookFriends)
		{
			Singleton<ChatManager>.Instance._friendUsers.Add(new CommUser(profile2));
		}
		CommUser f4;
		foreach (CommUser f3 in Singleton<ChatManager>.Instance._friendUsers)
		{
			f4 = f3;
			ChatDialog chatDialog;
			if (Singleton<ChatManager>.Instance._otherUsers.RemoveAll((CommUser u) => u.Cmid == f4.Cmid) > 0 && Singleton<ChatManager>.Instance._dialogsByCmid.TryGetValue(f4.Cmid, out chatDialog))
			{
				chatDialog.Group = UserGroups.Friend;
			}
		}
		CommUser f;
		foreach (CommUser f2 in list)
		{
			f = f2;
			ChatDialog chatDialog2;
			if (Singleton<ChatManager>.Instance._dialogsByCmid.TryGetValue(f.Cmid, out chatDialog2) && !Singleton<ChatManager>.Instance._friendUsers.Exists((CommUser u) => u.Cmid == f.Cmid) && !Singleton<ChatManager>.Instance._otherUsers.Exists((CommUser u) => u.Cmid == f.Cmid))
			{
				Singleton<ChatManager>.Instance._otherUsers.Add(f);
				chatDialog2.Group = UserGroups.Other;
			}
		}
		Singleton<ChatManager>.Instance.RefreshAll(false);
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x00008524 File Offset: 0x00006724
	public static Texture GetPresenceIcon(CommActorInfo user)
	{
		if (user != null)
		{
			return ChatManager.GetPresenceIcon((user.CurrentRoom == null) ? PresenceType.Online : PresenceType.InGame);
		}
		return ChatManager.GetPresenceIcon(PresenceType.Offline);
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x0003FDBC File Offset: 0x0003DFBC
	public static Texture GetPresenceIcon(PresenceType index)
	{
		switch (index)
		{
		case PresenceType.Offline:
			return CommunicatorIcons.PresenceOffline;
		case PresenceType.Online:
			return CommunicatorIcons.PresenceOnline;
		case PresenceType.InGame:
			return CommunicatorIcons.PresencePlaying;
		default:
			return CommunicatorIcons.PresenceOffline;
		}
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x0003FDFC File Offset: 0x0003DFFC
	public void SetGameSection(string server, int roomId, int mapId, IEnumerable<GameActorInfo> actors)
	{
		this._ingameUsers.Clear();
		this._lastgameUsers.Clear();
		this._lastgameUsers.AddRange(this._allTimePlayers.Values);
		GameActorInfo v;
		foreach (GameActorInfo v2 in actors)
		{
			v = v2;
			CommUser commUser = new CommUser(v);
			commUser.CurrentGame = new GameRoom
			{
				Server = new ConnectionAddress(server),
				Number = roomId,
				MapId = mapId
			};
			commUser.IsClanMember = PlayerDataManager.IsClanMember(commUser.Cmid);
			commUser.IsFriend = PlayerDataManager.IsFriend(commUser.Cmid);
			commUser.IsFacebookFriend = PlayerDataManager.IsFacebookFriend(commUser.Cmid);
			this._ingameUsers.Add(commUser);
			this._lastgameUsers.RemoveAll((CommUser p) => p.Cmid == v.Cmid);
			if (v.Cmid != PlayerDataManager.Cmid && !this._allTimePlayers.ContainsKey(v.Cmid))
			{
				CommUser commUser2 = new CommUser(v);
				commUser2.CurrentGame = new GameRoom
				{
					Server = new ConnectionAddress(server),
					Number = roomId,
					MapId = mapId
				};
				this._allTimePlayers[v.Cmid] = commUser2;
			}
		}
		this._ingameUsers.Sort(new CommUserNameComparer());
	}

	// Token: 0x06000A1D RID: 2589 RVA: 0x0003FFAC File Offset: 0x0003E1AC
	public List<CommUser> GetCommUsersToReport()
	{
		int capacity = this._ingameUsers.Count + this._lobbyUsers.Count + this._otherUsers.Count;
		Dictionary<int, CommUser> dictionary = new Dictionary<int, CommUser>(capacity);
		foreach (CommUser commUser in this._ingameUsers)
		{
			dictionary[commUser.Cmid] = commUser;
		}
		foreach (CommUser commUser2 in this._otherUsers)
		{
			dictionary[commUser2.Cmid] = commUser2;
		}
		foreach (CommUser commUser3 in this._lobbyUsers)
		{
			dictionary[commUser3.Cmid] = commUser3;
		}
		return new List<CommUser>(dictionary.Values);
	}

	// Token: 0x06000A1E RID: 2590 RVA: 0x0000854A File Offset: 0x0000674A
	public bool TryGetClanUsers(int cmid, out CommUser user)
	{
		return this._clanUsers.TryGetValue(cmid, out user) && user != null;
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x000400EC File Offset: 0x0003E2EC
	public bool TryGetGameUser(int cmid, out CommUser user)
	{
		user = null;
		foreach (CommUser commUser in this._ingameUsers)
		{
			if (commUser.Cmid == cmid)
			{
				user = commUser;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x0004015C File Offset: 0x0003E35C
	public bool TryGetLobbyCommUser(int cmid, out CommUser user)
	{
		user = this._lobbyUsers.Find((CommUser u) => u.Cmid == cmid);
		return user != null;
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x00040198 File Offset: 0x0003E398
	public bool TryGetFriend(int cmid, out CommUser user)
	{
		foreach (CommUser commUser in this._friendUsers)
		{
			if (commUser.Cmid == cmid)
			{
				user = commUser;
				return true;
			}
		}
		user = null;
		return false;
	}

	// Token: 0x06000A22 RID: 2594 RVA: 0x00040208 File Offset: 0x0003E408
	public void CreatePrivateChat(int cmid)
	{
		ChatDialog chatDialog = null;
		ChatDialog chatDialog2;
		if (this._dialogsByCmid.TryGetValue(cmid, out chatDialog2) && chatDialog2 != null)
		{
			chatDialog = chatDialog2;
		}
		else
		{
			CommActorInfo commActorInfo = null;
			if (PlayerDataManager.IsFriend(cmid) || PlayerDataManager.IsFacebookFriend(cmid))
			{
				CommUser commUser = this._friendUsers.Find((CommUser u) => u.Cmid == cmid);
				if (commUser != null)
				{
					chatDialog = new ChatDialog(commUser, UserGroups.Friend);
				}
			}
			else if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.TryGetPlayer(cmid, out commActorInfo))
			{
				CommUser commUser;
				ClanMemberView member;
				if (PlayerDataManager.TryGetClanMember(cmid, out member))
				{
					commUser = new CommUser(member);
					commUser.SetActor(commActorInfo);
				}
				else
				{
					commUser = new CommUser(commActorInfo);
				}
				this._otherUsers.Add(commUser);
				chatDialog = new ChatDialog(commUser, UserGroups.Other);
			}
			if (chatDialog != null)
			{
				this._dialogsByCmid.Add(cmid, chatDialog);
			}
		}
		if (chatDialog != null)
		{
			ChatPageGUI.SelectedTab = TabArea.Private;
			this.SelectedDialog = chatDialog;
			this.SelectedCmid = cmid;
		}
		else
		{
			Debug.LogError(string.Format("Player with cmuneID {0} not found in communicator!", cmid));
		}
	}

	// Token: 0x06000A23 RID: 2595 RVA: 0x0004035C File Offset: 0x0003E55C
	public string GetAllChatMessagesForPlayerReport()
	{
		StringBuilder stringBuilder = new StringBuilder();
		ICollection<InstantMessage> allMessages = Singleton<ChatManager>.Instance.InGameDialog.AllMessages;
		if (allMessages.Count > 0)
		{
			stringBuilder.AppendLine("In Game Chat:");
			foreach (InstantMessage instantMessage in allMessages)
			{
				stringBuilder.AppendLine(instantMessage.PlayerName + " : " + instantMessage.Text);
			}
			stringBuilder.AppendLine();
		}
		foreach (ChatDialog chatDialog in Singleton<ChatManager>.Instance._dialogsByCmid.Values)
		{
			allMessages = chatDialog.AllMessages;
			if (allMessages.Count > 0)
			{
				stringBuilder.AppendLine("Private Chat:");
				foreach (InstantMessage instantMessage2 in allMessages)
				{
					stringBuilder.AppendLine(instantMessage2.PlayerName + " : " + instantMessage2.Text);
				}
				stringBuilder.AppendLine();
			}
		}
		allMessages = Singleton<ChatManager>.Instance.ClanDialog.AllMessages;
		if (allMessages.Count > 0)
		{
			stringBuilder.AppendLine("Clan Chat:");
			foreach (InstantMessage instantMessage3 in allMessages)
			{
				stringBuilder.AppendLine(instantMessage3.PlayerName + " : " + instantMessage3.Text);
			}
			stringBuilder.AppendLine();
		}
		allMessages = Singleton<ChatManager>.Instance.LobbyDialog.AllMessages;
		if (allMessages.Count > 0)
		{
			stringBuilder.AppendLine("Lobby Chat:");
			foreach (InstantMessage instantMessage4 in allMessages)
			{
				stringBuilder.AppendLine(instantMessage4.PlayerName + " : " + instantMessage4.Text);
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x000405F0 File Offset: 0x0003E7F0
	public void UpdateLastgamePlayers()
	{
		Singleton<ChatManager>.Instance._lastgameUsers.Clear();
		foreach (CommUser commUser in Singleton<ChatManager>.Instance._allTimePlayers.Values)
		{
			commUser.IsClanMember = PlayerDataManager.IsClanMember(commUser.Cmid);
			commUser.IsFriend = PlayerDataManager.IsFriend(commUser.Cmid);
			commUser.IsFacebookFriend = PlayerDataManager.IsFacebookFriend(commUser.Cmid);
			CommActorInfo actor;
			if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.TryGetPlayer(commUser.Cmid, out actor))
			{
				commUser.SetActor(actor);
			}
			else
			{
				commUser.SetActor(null);
			}
			Singleton<ChatManager>.Instance._lastgameUsers.Add(commUser);
		}
		Singleton<ChatManager>.Instance._lastgameUsers.Sort(new CommUserPresenceComparer());
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x000406E8 File Offset: 0x0003E8E8
	public void SetNaughtyList(List<CommActorInfo> hackers)
	{
		foreach (CommActorInfo commActorInfo in hackers)
		{
			this._naughtyUsers[commActorInfo.Cmid] = new CommUser(commActorInfo);
		}
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x00040750 File Offset: 0x0003E950
	public void AddClanMessage(int cmid, InstantMessage msg)
	{
		this.ClanDialog.AddMessage(msg);
		if (cmid != PlayerDataManager.Cmid && ChatPageGUI.SelectedTab != TabArea.Clan)
		{
			this.HasUnreadClanMessage.Value = true;
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.NewMessage, 0UL, 1f, 1f);
		}
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x000407A8 File Offset: 0x0003E9A8
	public void AddNewPrivateMessage(int cmid, InstantMessage msg)
	{
		try
		{
			ChatDialog chatDialog;
			if (!this._dialogsByCmid.TryGetValue(cmid, out chatDialog) && !msg.IsNotification)
			{
				CommActorInfo user;
				if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.TryGetPlayer(cmid, out user))
				{
					CommUser commUser = new CommUser(user);
					chatDialog = this.AddNewDialog(commUser);
					if (!this._friendUsers.Exists((CommUser p) => p.Cmid == cmid))
					{
						this._otherUsers.Add(commUser);
					}
				}
				else
				{
					CommUser commUser2 = new CommUser(new CommActorInfo
					{
						Cmid = cmid,
						PlayerName = msg.PlayerName,
						Channel = ChannelType.WebPortal,
						AccessLevel = msg.AccessLevel
					});
					chatDialog = this.AddNewDialog(commUser2);
					if (!this._friendUsers.Exists((CommUser p) => p.Cmid == cmid))
					{
						this._otherUsers.Add(commUser2);
					}
				}
			}
			if (chatDialog != null)
			{
				chatDialog.AddMessage(msg);
				if (chatDialog != this.SelectedDialog)
				{
					chatDialog.HasUnreadMessage = true;
				}
				if (ChatPageGUI.SelectedTab != TabArea.Private)
				{
					this.HasUnreadPrivateMessage.Value = true;
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.NewMessage, 0UL, 1f, 1f);
				}
			}
		}
		catch
		{
			Debug.LogError(string.Format("AddNewPrivateMessage from cmid={0}", cmid));
			throw;
		}
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x00040950 File Offset: 0x0003EB50
	public ChatDialog AddNewDialog(CommUser user)
	{
		ChatDialog chatDialog = null;
		if (user != null && !this._dialogsByCmid.TryGetValue(user.Cmid, out chatDialog))
		{
			if (PlayerDataManager.IsFriend(user.Cmid) || PlayerDataManager.IsFacebookFriend(user.Cmid))
			{
				chatDialog = new ChatDialog(user, UserGroups.Friend);
			}
			else
			{
				chatDialog = new ChatDialog(user, UserGroups.Other);
			}
			this._dialogsByCmid.Add(user.Cmid, chatDialog);
		}
		return chatDialog;
	}

	// Token: 0x06000A29 RID: 2601 RVA: 0x000409C8 File Offset: 0x0003EBC8
	internal void RemoveDialog(ChatDialog d)
	{
		this._dialogsByCmid.Remove(d.UserCmid);
		this._otherUsers.RemoveAll((CommUser u) => u.Cmid == d.UserCmid);
		this.SelectedDialog = null;
	}

	// Token: 0x04000A0B RID: 2571
	private List<CommUser> _lobbyUsers;

	// Token: 0x04000A0C RID: 2572
	private List<CommUser> _otherUsers;

	// Token: 0x04000A0D RID: 2573
	private List<CommUser> _friendUsers;

	// Token: 0x04000A0E RID: 2574
	public Dictionary<int, CommUser> _naughtyUsers;

	// Token: 0x04000A0F RID: 2575
	private Dictionary<int, CommUser> _clanUsers;

	// Token: 0x04000A10 RID: 2576
	private List<CommUser> _ingameUsers;

	// Token: 0x04000A11 RID: 2577
	private List<CommUser> _lastgameUsers;

	// Token: 0x04000A12 RID: 2578
	private Dictionary<int, CommUser> _allTimePlayers;

	// Token: 0x04000A13 RID: 2579
	private HashSet<TabArea> _tabAreas;

	// Token: 0x04000A14 RID: 2580
	private float _nextRefreshTime;

	// Token: 0x04000A15 RID: 2581
	public int SelectedCmid;

	// Token: 0x04000A16 RID: 2582
	public ChatDialog SelectedDialog;

	// Token: 0x04000A17 RID: 2583
	public Property<bool> HasUnreadPrivateMessage = new Property<bool>(false);

	// Token: 0x04000A18 RID: 2584
	public Property<bool> HasUnreadClanMessage = new Property<bool>(false);

	// Token: 0x04000A19 RID: 2585
	public ChatGroupPanel[] _commPanes;

	// Token: 0x04000A1A RID: 2586
	public Dictionary<int, ChatDialog> _dialogsByCmid;

	// Token: 0x04000A1B RID: 2587
	public HashSet<int> _mutedCmids;
}
