using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Realtime.Client;
using UnityEngine;

// Token: 0x02000379 RID: 889
public class LobbyRoom : BaseLobbyRoom
{
	// Token: 0x170005C0 RID: 1472
	// (get) Token: 0x06001925 RID: 6437 RVA: 0x00010C58 File Offset: 0x0000EE58
	public IEnumerable<CommActorInfo> Players
	{
		get
		{
			return this._actors.Values;
		}
	}

	// Token: 0x06001926 RID: 6438 RVA: 0x00010C65 File Offset: 0x0000EE65
	public bool HasPlayer(int cmid)
	{
		return this._actors.ContainsKey(cmid);
	}

	// Token: 0x06001927 RID: 6439 RVA: 0x00010C73 File Offset: 0x0000EE73
	public bool TryGetPlayer(int cmid, out CommActorInfo player)
	{
		return this._actors.TryGetValue(cmid, out player) && player != null;
	}

	// Token: 0x06001928 RID: 6440 RVA: 0x00086868 File Offset: 0x00084A68
	protected override void OnClanChatMessage(int cmid, string name, string message)
	{
		InstantMessage msg = new InstantMessage(cmid, name, message, MemberAccessLevel.Default, ChatContext.None);
		Singleton<ChatManager>.Instance.AddClanMessage(cmid, msg);
	}

	// Token: 0x06001929 RID: 6441 RVA: 0x0008688C File Offset: 0x00084A8C
	protected override void OnFullPlayerListUpdate(List<CommActorInfo> players)
	{
		this._actors.Clear();
		foreach (CommActorInfo commActorInfo in players)
		{
			this._actors[commActorInfo.Cmid] = commActorInfo;
		}
		Singleton<ChatManager>.Instance.RefreshAll(true);
	}

	// Token: 0x0600192A RID: 6442 RVA: 0x00086904 File Offset: 0x00084B04
	protected override void OnInGameChatMessage(int cmid, string name, string message, MemberAccessLevel accessLevel, byte context)
	{
		if (ChatManager.CanShowMessage((ChatContext)context))
		{
			GameData.Instance.OnHUDChatMessage.Fire(name, message, accessLevel);
		}
		Singleton<ChatManager>.Instance.InGameDialog.AddMessage(new InstantMessage(cmid, name, message, accessLevel, (ChatContext)context));
	}

	// Token: 0x0600192B RID: 6443 RVA: 0x0008694C File Offset: 0x00084B4C
	protected override void OnLobbyChatMessage(int cmid, string name, string message)
	{
		MemberAccessLevel level = MemberAccessLevel.Default;
		CommActorInfo commActorInfo;
		if (this._actors.TryGetValue(cmid, out commActorInfo))
		{
			level = commActorInfo.AccessLevel;
			if (!string.IsNullOrEmpty(name))
			{
				name = this.PrependClanTagToPlayerName(commActorInfo);
			}
		}
		InstantMessage msg = new InstantMessage(cmid, name, message, level, commActorInfo, ChatContext.None);
		Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(msg);
	}

	// Token: 0x0600192C RID: 6444 RVA: 0x000869A8 File Offset: 0x00084BA8
	private bool DoModChatCmd(string message)
	{
		string text = message.Substring(1);
		string[] array = (from Match m in Regex.Matches(text, "\\w+|\"[^\\r\\n]*\"")
		select m.Value).ToArray<string>();
		if (text == "h" || text == "help")
		{
			Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(new InstantMessage(0, "[MOD]", " Usage: /cmd user [duration]\nValid commands are [short | long]:\n\tm | mute\n\tg | ghost\n\tu | unmute\n\tk | kick\n\th | help", MemberAccessLevel.Admin, ChatContext.None));
			Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(new InstantMessage(0, "[MOD]", "Duration defaults to 12 hours if none is given, and applies to mute/ghost only. Use Copy Name menu item to get the name", MemberAccessLevel.Admin, ChatContext.None));
			return true;
		}
		if (array.Length < 2)
		{
			Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(new InstantMessage(0, "[MOD]", "Error! No player specified!", MemberAccessLevel.Admin, ChatContext.None));
			return false;
		}
		string text2 = array[0];
		string text3 = array[1];
		string value = "720";
		if (array.Length > 2)
		{
			value = array[2];
		}
		string name;
		if (text3[0] == '"')
		{
			string[] array2 = text3.Substring(1).Split(new char[]
			{
				'"'
			});
			name = array2[0];
			if (array2.Length > 2)
			{
				value = text.Split(new char[]
				{
					'"'
				})[2].Trim();
			}
		}
		else
		{
			name = array[1];
		}
		int durationInMinutes = Convert.ToInt32(value);
		int num;
		string text4;
		if (!this.FindPlayerByName(name, out num, out text4))
		{
			Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(new InstantMessage(0, "[MOD]", "Error! Player not found, or too many players matched that pattern!", MemberAccessLevel.Admin, ChatContext.None));
			return true;
		}
		string text5 = text2;
		switch (text5)
		{
		case "m":
		case "mute":
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationMutePlayer(durationInMinutes, num, true);
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationMutePlayer(durationInMinutes, num, false);
			Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(new InstantMessage(0, "[MOD]", string.Concat(new string[]
			{
				"User ",
				text4,
				" was muted for ",
				durationInMinutes.ToString(),
				" minutes!"
			}), MemberAccessLevel.Admin, ChatContext.None));
			break;
		case "g":
		case "ghost":
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationMutePlayer(durationInMinutes, num, false);
			Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(new InstantMessage(0, "[MOD]", string.Concat(new string[]
			{
				"User ",
				text4,
				" was ghosted for ",
				durationInMinutes.ToString(),
				" minutes!"
			}), MemberAccessLevel.Admin, ChatContext.None));
			break;
		case "u":
		case "unmute":
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationMutePlayer(0, num, false);
			Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(new InstantMessage(0, "[MOD]", "User " + text4 + " was unmuted!", MemberAccessLevel.Admin, ChatContext.None));
			break;
		case "k":
		case "kick":
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationBanPlayer(num);
			Singleton<ChatManager>.Instance.LobbyDialog.AddMessage(new InstantMessage(0, "[MOD]", "User " + text4 + " was kicked!", MemberAccessLevel.Admin, ChatContext.None));
			break;
		}
		return true;
	}

	// Token: 0x0600192D RID: 6445 RVA: 0x00086D98 File Offset: 0x00084F98
	private bool FindPlayerByName(string name, out int cmid, out string uname)
	{
		int num = 0;
		uname = string.Empty;
		cmid = 0;
		foreach (KeyValuePair<int, CommActorInfo> keyValuePair in this._actors)
		{
			if (!string.IsNullOrEmpty(keyValuePair.Value.PlayerName))
			{
				if (keyValuePair.Value.PlayerName.Contains(name))
				{
					if (num > 0)
					{
						return false;
					}
					num = keyValuePair.Value.Cmid;
					uname = keyValuePair.Value.PlayerName;
				}
			}
		}
		if (num == 0)
		{
			return false;
		}
		cmid = num;
		return true;
	}

	// Token: 0x0600192E RID: 6446 RVA: 0x00010C92 File Offset: 0x0000EE92
	protected override void OnModerationCustomMessage(string message)
	{
		PopupSystem.ShowMessage("Administrator Message", message, PopupSystem.AlertType.OK, delegate()
		{
		});
		global::EventHandler.Global.Fire(new GameEvents.PlayerPause());
	}

	// Token: 0x0600192F RID: 6447 RVA: 0x00010CCC File Offset: 0x0000EECC
	protected override void OnModerationKickGame()
	{
		Singleton<GameStateController>.Instance.LeaveGame(false);
		PopupSystem.ShowMessage("ADMIN MESSAGE", "You were kicked out of the game!", PopupSystem.AlertType.OK, delegate()
		{
		});
	}

	// Token: 0x06001930 RID: 6448 RVA: 0x00086E60 File Offset: 0x00085060
	protected override void OnModerationMutePlayer(bool isPlayerMuted)
	{
		this.IsPlayerMuted.Value = isPlayerMuted;
		if (isPlayerMuted)
		{
			PopupSystem.ShowMessage("ADMIN MESSAGE", "You have been muted!", PopupSystem.AlertType.OK, delegate()
			{
			});
		}
	}

	// Token: 0x06001931 RID: 6449 RVA: 0x00010D06 File Offset: 0x0000EF06
	protected override void OnPlayerHide(int cmid)
	{
		if (!PlayerDataManager.IsClanMember(cmid) && !PlayerDataManager.IsFriend(cmid) && !Singleton<ChatManager>.Instance.HasDialogWith(cmid))
		{
			this.OnPlayerLeft(cmid, true);
		}
	}

	// Token: 0x06001932 RID: 6450 RVA: 0x00086EAC File Offset: 0x000850AC
	protected override void OnPlayerJoined(CommActorInfo data)
	{
		this._actors.Clear();
		Debug.Log("OnPlayerJoined " + data.Cmid);
		this._actors[data.Cmid] = data;
		Singleton<ChatManager>.Instance.RefreshAll(true);
	}

	// Token: 0x06001933 RID: 6451 RVA: 0x00086EFC File Offset: 0x000850FC
	protected override void OnPlayerLeft(int cmid, bool refreshComm)
	{
		CommActorInfo commActorInfo;
		if (this._actors.TryGetValue(cmid, out commActorInfo))
		{
			this._actors.Remove(cmid);
			commActorInfo.CurrentRoom = null;
		}
		Singleton<ChatManager>.Instance.RefreshAll(refreshComm);
	}

	// Token: 0x06001934 RID: 6452 RVA: 0x00010D36 File Offset: 0x0000EF36
	protected override void OnPlayerUpdate(CommActorInfo data)
	{
		this._actors[data.Cmid] = data;
		Singleton<ChatManager>.Instance.RefreshAll(false);
	}

	// Token: 0x06001935 RID: 6453 RVA: 0x00086F3C File Offset: 0x0008513C
	protected override void OnPrivateChatMessage(int cmid, string name, string message)
	{
		MemberAccessLevel level = MemberAccessLevel.Default;
		CommActorInfo commActorInfo;
		if (this._actors.TryGetValue(cmid, out commActorInfo))
		{
			level = commActorInfo.AccessLevel;
			if (!string.IsNullOrEmpty(name))
			{
				name = this.PrependClanTagToPlayerName(commActorInfo);
			}
		}
		InstantMessage msg = new InstantMessage(cmid, name, message, level, commActorInfo, ChatContext.None);
		Singleton<ChatManager>.Instance.AddNewPrivateMessage(cmid, msg);
	}

	// Token: 0x06001936 RID: 6454 RVA: 0x00010D55 File Offset: 0x0000EF55
	protected override void OnUpdateActorsForModeration(List<CommActorInfo> naughtyList)
	{
		Singleton<ChatManager>.Instance.SetNaughtyList(naughtyList);
		this.SendContactList();
	}

	// Token: 0x06001937 RID: 6455 RVA: 0x00010D68 File Offset: 0x0000EF68
	protected override void OnUpdateClanData()
	{
		Singleton<ClanDataManager>.Instance.CheckCompleteClanData();
	}

	// Token: 0x06001938 RID: 6456 RVA: 0x00010D74 File Offset: 0x0000EF74
	protected override void OnUpdateClanMembers()
	{
		Singleton<ClanDataManager>.Instance.RefreshClanData(true);
	}

	// Token: 0x06001939 RID: 6457 RVA: 0x00086F94 File Offset: 0x00085194
	protected override void OnUpdateContacts(List<CommActorInfo> updated, List<int> removed)
	{
		foreach (CommActorInfo commActorInfo in updated)
		{
			this._actors[commActorInfo.Cmid] = commActorInfo;
		}
		foreach (int cmid in removed)
		{
			this.OnPlayerLeft(cmid, false);
		}
		Singleton<ChatManager>.Instance.RefreshAll(true);
	}

	// Token: 0x0600193A RID: 6458 RVA: 0x00010D81 File Offset: 0x0000EF81
	protected override void OnUpdateFriendsList()
	{
		UnityRuntime.StartRoutine(Singleton<CommsManager>.Instance.GetContactsByGroups());
	}

	// Token: 0x0600193B RID: 6459 RVA: 0x00010D93 File Offset: 0x0000EF93
	protected override void OnUpdateInboxMessages(int messageId)
	{
		Singleton<InboxManager>.Instance.GetMessageWithId(messageId);
	}

	// Token: 0x0600193C RID: 6460 RVA: 0x00010DA0 File Offset: 0x0000EFA0
	protected override void OnUpdateInboxRequests()
	{
		Singleton<InboxManager>.Instance.RefreshAllRequests();
	}

	// Token: 0x0600193D RID: 6461 RVA: 0x00087044 File Offset: 0x00085244
	public void SendContactList()
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (CommUser commUser in Singleton<ChatManager>.Instance.FriendUsers)
		{
			hashSet.Add(commUser.Cmid);
		}
		foreach (CommUser commUser2 in Singleton<ChatManager>.Instance.ClanUsers)
		{
			hashSet.Add(commUser2.Cmid);
		}
		foreach (CommUser commUser3 in Singleton<ChatManager>.Instance.OtherUsers)
		{
			hashSet.Add(commUser3.Cmid);
		}
		foreach (CommUser commUser4 in Singleton<ChatManager>.Instance.NaughtyUsers)
		{
			hashSet.Add(commUser4.Cmid);
		}
		if (hashSet.Count > 0)
		{
			base.Operations.SendSetContactList(hashSet.ToList<int>());
		}
	}

	// Token: 0x0600193E RID: 6462 RVA: 0x00010DAC File Offset: 0x0000EFAC
	public void UpdatePlayerRoom(GameRoom room)
	{
		base.Operations.SendUpdatePlayerRoom(room);
	}

	// Token: 0x0600193F RID: 6463 RVA: 0x000871CC File Offset: 0x000853CC
	public void SendUpdateClanMembers()
	{
		List<int> list = new List<int>();
		foreach (ClanMemberView clanMemberView in Singleton<PlayerDataManager>.Instance.ClanMembers)
		{
			if (clanMemberView.Cmid != PlayerDataManager.Cmid)
			{
				list.Add(clanMemberView.Cmid);
			}
		}
		list.RemoveAll((int id) => id == PlayerDataManager.Cmid);
		base.Operations.SendUpdateClanMembers(list);
	}

	// Token: 0x06001940 RID: 6464 RVA: 0x00010DBA File Offset: 0x0000EFBA
	public void UpdateContacts()
	{
		if (Singleton<ChatManager>.Instance.TotalContacts > 0)
		{
			base.Operations.SendUpdateContacts();
		}
	}

	// Token: 0x06001941 RID: 6465 RVA: 0x00010DD7 File Offset: 0x0000EFD7
	public void SendUpdateResetLobby()
	{
		this._actors.Clear();
		Singleton<ChatManager>.Instance.RefreshAll(false);
		base.Operations.SendFullPlayerListUpdate();
	}

	// Token: 0x06001942 RID: 6466 RVA: 0x00087278 File Offset: 0x00085478
	public void SendClanChatMessage(string message)
	{
		message = ChatMessageFilter.Cleanup(message);
		if (!string.IsNullOrEmpty(message))
		{
			List<int> list = new List<int>();
			foreach (CommUser commUser in Singleton<ChatManager>.Instance.ClanUsers)
			{
				if (commUser.Cmid != PlayerDataManager.Cmid)
				{
					list.Add(commUser.Cmid);
				}
			}
			this.OnClanChatMessage(PlayerDataManager.Cmid, PlayerDataManager.Name, message);
			base.Operations.SendChatMessageToClan(list, message);
		}
	}

	// Token: 0x06001943 RID: 6467 RVA: 0x00087320 File Offset: 0x00085520
	public bool SendLobbyChatMessage(string message)
	{
		message = ChatMessageFilter.Cleanup(message);
		if (string.IsNullOrEmpty(message))
		{
			return false;
		}
		if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator && message[0] == '/' && this.DoModChatCmd(message))
		{
			GUI.FocusControl("@CurrentChatMessage");
			return true;
		}
		if (ChatMessageFilter.IsSpamming(message))
		{
			return false;
		}
		this.OnLobbyChatMessage(PlayerDataManager.Cmid, PlayerDataManager.Name, message);
		base.Operations.SendChatMessageToAll(message);
		return true;
	}

	// Token: 0x06001944 RID: 6468 RVA: 0x000873A0 File Offset: 0x000855A0
	public void SendPrivateChatMessage(int receiverCmid, string receiverName, string message)
	{
		message = ChatMessageFilter.Cleanup(message);
		if (!string.IsNullOrEmpty(message))
		{
			Singleton<ChatManager>.Instance.AddNewPrivateMessage(receiverCmid, new InstantMessage(PlayerDataManager.Cmid, PlayerDataManager.Name, message, PlayerDataManager.AccessLevel, ChatContext.None));
			base.Operations.SendChatMessageToPlayer(receiverCmid, message);
		}
	}

	// Token: 0x06001945 RID: 6469 RVA: 0x000873F0 File Offset: 0x000855F0
	private string PrependClanTagToPlayerName(CommActorInfo actor)
	{
		if (!string.IsNullOrEmpty(actor.ClanTag))
		{
			return string.Concat(new string[]
			{
				"[" + actor.ClanTag + "] " + actor.PlayerName
			});
		}
		return actor.PlayerName;
	}

	// Token: 0x04001770 RID: 6000
	private Dictionary<int, CommActorInfo> _actors = new Dictionary<int, CommActorInfo>();

	// Token: 0x04001771 RID: 6001
	private CommActorInfo LocalPlayer;

	// Token: 0x04001772 RID: 6002
	public Property<bool> IsPlayerMuted = new Property<bool>(false);
}
