using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cmune.DataCenter.Common.Entities;
using ExitGames.Client.Photon;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x0200017E RID: 382
public class ChatPageGUI : PageGUI
{
	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000A3C RID: 2620 RVA: 0x0000860B File Offset: 0x0000680B
	// (set) Token: 0x06000A3D RID: 2621 RVA: 0x00008612 File Offset: 0x00006812
	public static TabArea SelectedTab { get; set; }

	// Token: 0x06000A3E RID: 2622 RVA: 0x0000861A File Offset: 0x0000681A
	private void Awake()
	{
		this._playerMenu = new PopupMenu();
		base.IsOnGUIEnabled = true;
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x00040A18 File Offset: 0x0003EC18
	private void Start()
	{
		this.label_notification = new GUIStyle(BlueStonez.label_interparkbold_18pt);
		this._playerMenu.AddMenuItem(LocalizedStrings.JoinGame, new Action<CommUser>(this.MenuCmdJoinGame), new Func<CommUser, bool>(this.MenuChkJoinGame));
		this._playerMenu.AddMenuItem("Add Friend", new Action<CommUser>(this.MenuCmdAddFriend), new Func<CommUser, bool>(this.MenuChkAddFriend));
		this._playerMenu.AddMenuItem(LocalizedStrings.PrivateChat, new Action<CommUser>(this.MenuCmdChat), new Func<CommUser, bool>(this.MenuChkChat));
		this._playerMenu.AddMenuItem(LocalizedStrings.SendMessage, new Action<CommUser>(this.MenuCmdSendMessage), new Func<CommUser, bool>(this.MenuChkSendMessage));
		this._playerMenu.AddMenuItem(LocalizedStrings.InviteToClan, new Action<CommUser>(this.MenuCmdInviteClan), new Func<CommUser, bool>(this.MenuChkInviteClan));
		this._playerMenu.AddMenuItem(new Func<CommUser, string>(this.MenuCaptionMute), new Action<CommUser>(this.MenuCmdMute), new Func<CommUser, bool>(this.MenuChkMute));
		this._playerMenu.AddMenuItem("Unfriend", new Action<CommUser>(this.MenuCmdRemoveFriend), new Func<CommUser, bool>(this.MenuChkRemoveFriend));
		if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
		{
			this._playerMenu.AddMenuItem("- - - - - - - - - - - - -", null, (CommUser A_0) => true);
			this._playerMenu.AddMenuItem("Copy Data", new Action<CommUser>(this.MenuCmdCopyData), (CommUser A_0) => true);
			this._playerMenu.AddMenuCopyItem("Copy Message", new Action<CommUser, InstantMessage>(this.MenuCmdCopyMsg), (CommUser A_0) => true);
			this._playerMenu.AddMenuCopyItem("Copy Name", new Action<CommUser, InstantMessage>(this.MenuCmdCopyPlayerName), (CommUser A_0) => true);
			this._playerMenu.AddMenuItem("Moderate Player", new Action<CommUser>(this.MenuCmdModeratePlayer), (CommUser A_0) => true);
		}
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x0000862E File Offset: 0x0000682E
	private void OnEnable()
	{
		if (this._nextFullLobbyUpdate < Time.time)
		{
			this._nextFullLobbyUpdate = Time.time + 20f;
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendFullPlayerListUpdate();
		}
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x00040C74 File Offset: 0x0003EE74
	private void Update()
	{
		if (this._lastMessageSentTimer < 0.3f)
		{
			this._lastMessageSentTimer += Time.deltaTime;
		}
		if (this._yPosition < 0f)
		{
			this._yPosition = Mathf.Lerp(this._yPosition, 0.1f, Time.deltaTime * 8f);
		}
		else
		{
			this._yPosition = 0f;
		}
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x00040CE4 File Offset: 0x0003EEE4
	private void OnGUI()
	{
		if (base.IsOnGUIEnabled)
		{
			GUI.skin = BlueStonez.Skin;
			GUI.depth = 9;
			this._mainRect = new Rect(0f, (float)GlobalUIRibbon.Instance.Height(), (float)Screen.width, (float)(Screen.height - GlobalUIRibbon.Instance.Height()));
			this.DrawGUI(this._mainRect);
			if (PopupMenu.Current != null)
			{
				PopupMenu.Current.Draw();
			}
		}
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x00040D60 File Offset: 0x0003EF60
	public override void DrawGUI(Rect rect)
	{
		GUI.BeginGroup(rect, BlueStonez.window);
		if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.IsConnected)
		{
			this.DoTabs(new Rect(10f, 0f, 300f, 30f));
			if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
			{
				GUIUtility.keyboardControl = 0;
			}
			Rect rect2 = new Rect(0f, 21f, 300f, rect.height - 21f);
			Rect rect3 = new Rect(299f, 0f, rect.width - 300f, 22f);
			Rect rect4 = new Rect(300f, 22f, rect.width - 300f, rect.height - 22f - 36f - this._keyboardOffset);
			Rect rect5 = new Rect(299f, rect.height - 37f, rect.width - 300f + 1f, 37f);
			ChatGroupPanel pane = Singleton<ChatManager>.Instance._commPanes[(int)ChatPageGUI.SelectedTab];
			GUITools.PushGUIState();
			GUI.enabled &= !PopupMenu.IsEnabled;
			switch (ChatPageGUI.SelectedTab)
			{
			case TabArea.Lobby:
				this.DoDialogFooter(rect5, pane, Singleton<ChatManager>.Instance.LobbyDialog);
				this.DoLobbyCommPane(rect2, pane);
				this.DoDialogHeader(rect3, Singleton<ChatManager>.Instance.LobbyDialog);
				this.DoDialog(rect4, pane, Singleton<ChatManager>.Instance.LobbyDialog);
				break;
			case TabArea.Private:
				this.DoDialogFooter(rect5, pane, Singleton<ChatManager>.Instance.SelectedDialog);
				this.DrawCommPane(rect2, pane);
				this.DoPrivateDialogHeader(rect3, Singleton<ChatManager>.Instance.SelectedDialog);
				this.DoDialog(rect4, pane, Singleton<ChatManager>.Instance.SelectedDialog);
				break;
			case TabArea.Clan:
				this.DoDialogFooter(rect5, pane, Singleton<ChatManager>.Instance.ClanDialog);
				this.DrawCommPane(rect2, pane);
				this.DoDialogHeader(rect3, Singleton<ChatManager>.Instance.ClanDialog);
				this.DoDialog(rect4, pane, Singleton<ChatManager>.Instance.ClanDialog);
				break;
			case TabArea.InGame:
				this.DoDialogFooter(rect5, pane, Singleton<ChatManager>.Instance.InGameDialog);
				this.DrawCommPane(rect2, pane);
				this.DoDialogHeader(rect3, Singleton<ChatManager>.Instance.InGameDialog);
				this.DoDialog(rect4, pane, Singleton<ChatManager>.Instance.InGameDialog);
				break;
			case TabArea.Moderation:
				this.DoModeratorPaneFooter(rect5, pane);
				this.DrawModeratorCommPane(rect2, pane);
				this.DoDialogHeader(rect3, Singleton<ChatManager>.Instance.ModerationDialog);
				this.DoModeratorDialog(rect4, pane);
				break;
			}
			GUITools.PopGUIState();
		}
		else
		{
			GUI.color = Color.gray;
			PeerStateValue peerState = AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Peer.PeerState;
			if (peerState != PeerStateValue.Connecting)
			{
				GUI.Label(new Rect(0f, rect.height / 2f, rect.width, 20f), LocalizedStrings.ServerIsNotReachable, BlueStonez.label_interparkbold_11pt);
			}
			else
			{
				GUI.Label(new Rect(0f, rect.height / 2f, rect.width, 20f), LocalizedStrings.ConnectingToServer, BlueStonez.label_interparkbold_11pt);
			}
			GUI.color = Color.white;
		}
		GUI.EndGroup();
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x0000866A File Offset: 0x0000686A
	private bool IsMobileChannel(ChannelType channel)
	{
		return channel == ChannelType.Android || channel == ChannelType.IPad || channel == ChannelType.IPhone;
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x000410D0 File Offset: 0x0003F2D0
	private int DoModeratorControlPanel(Rect rect, ChatGroupPanel pane)
	{
		if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
		{
			int num = 0;
			bool flag = PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator;
			bool flag2 = flag && ChatPageGUI.IsCompleteLobbyLoaded;
			rect = new Rect(rect.x, rect.yMax - 36f - (float)((!flag2) ? ((!flag) ? 0 : 30) : 60) - 1f, rect.width, (float)(37 + ((!flag2) ? ((!flag) ? 0 : 30) : 60)));
			GUI.BeginGroup(rect, GUIContent.none, BlueStonez.window_standard_grey38);
			if (flag)
			{
				GUI.enabled = (this._nextNaughtyListUpdate < Time.time);
				if (GUITools.Button(new Rect(6f, rect.height - 61f, (rect.width - 12f) * 0.5f, 26f), new GUIContent((this._nextNaughtyListUpdate >= Time.time) ? string.Format("Next Update ({0:N0})", this._nextNaughtyListUpdate - Time.time) : "Update Naughty List"), BlueStonez.buttondark_medium))
				{
					this._nextNaughtyListUpdate = Time.time + 10f;
					AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdateNaughtyList();
				}
				GUI.enabled = true;
				GUI.enabled = (this._nextNaughtyListUpdate < Time.time);
				if (GUITools.Button(new Rect(6f + (rect.width - 12f) * 0.5f, rect.height - 61f, (rect.width - 12f) * 0.5f, 26f), new GUIContent((this._nextNaughtyListUpdate >= Time.time) ? string.Format("Next Update ({0:N0})", this._nextNaughtyListUpdate - Time.time) : "Unban Next 50"), BlueStonez.buttondark_medium))
				{
					List<CommUser> list = new List<CommUser>(Singleton<ChatManager>.Instance.NaughtyUsers);
					int num2 = 0;
					foreach (CommUser commUser in list)
					{
						if (commUser.Name.StartsWith("Banned:"))
						{
							AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendClearModeratorFlags(commUser.Cmid);
							Singleton<ChatManager>.Instance.SelectedCmid = 0;
							Singleton<ChatManager>.Instance._naughtyUsers.Remove(commUser.Cmid);
							if (++num2 > 50)
							{
								break;
							}
						}
					}
				}
				GUI.enabled = true;
				num += ((!ChatPageGUI.IsCompleteLobbyLoaded) ? 30 : 60);
			}
			bool flag3 = !string.IsNullOrEmpty(pane.SearchText);
			GUI.SetNextControlName("@ModSearch");
			GUI.changed = false;
			pane.SearchText = GUI.TextField(new Rect(6f, rect.height - 30f, rect.width - (float)((!flag3) ? 12 : 37), 24f), pane.SearchText, 20, BlueStonez.textField);
			if (!flag3 && GUI.GetNameOfFocusedControl() != "@ModSearch")
			{
				GUI.color = new Color(1f, 1f, 1f, 0.3f);
				GUI.Label(new Rect(12f, rect.height - 30f, rect.width - 20f, 24f), LocalizedStrings.Search, BlueStonez.label_interparkmed_10pt_left);
				GUI.color = Color.white;
			}
			if (flag3 && GUITools.Button(new Rect(rect.width - 28f, rect.height - 30f, 22f, 22f), new GUIContent("x"), BlueStonez.panelquad_button))
			{
				pane.SearchText = string.Empty;
				GUIUtility.keyboardControl = 0;
			}
			GUI.EndGroup();
			num += 36;
			return num;
		}
		return 0;
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x00041504 File Offset: 0x0003F704
	public void DrawCommPane(Rect rect, ChatGroupPanel pane)
	{
		GUI.BeginGroup(rect);
		pane.WindowHeight = rect.height;
		float height = Mathf.Max(pane.WindowHeight, pane.ContentHeight);
		float num = 0f;
		pane.Scroll = GUITools.BeginScrollView(new Rect(0f, 0f, rect.width, pane.WindowHeight), pane.Scroll, new Rect(0f, 0f, rect.width - 17f, height), false, true, true);
		GUI.BeginGroup(new Rect(0f, 0f, rect.width, pane.WindowHeight + pane.Scroll.y));
		foreach (ChatGroup group in pane.Groups)
		{
			num += this.DrawPlayerGroup(group, num, rect.width - 17f, pane.SearchText.Trim().ToLower(), false);
		}
		GUI.EndGroup();
		GUITools.EndScrollView();
		pane.ContentHeight = num;
		GUI.EndGroup();
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x0004163C File Offset: 0x0003F83C
	private void DoLobbyCommPane(Rect rect, ChatGroupPanel pane)
	{
		GUI.BeginGroup(rect);
		bool enabled = GUI.enabled;
		int num = this.DoLobbyControlPanel(new Rect(0f, 0f, rect.width, rect.height), pane);
		pane.WindowHeight = rect.height - (float)num;
		float height = Mathf.Max(pane.WindowHeight, pane.ContentHeight);
		float num2 = 0f;
		pane.Scroll = GUITools.BeginScrollView(new Rect(0f, 0f, rect.width, pane.WindowHeight), pane.Scroll, new Rect(0f, 0f, rect.width - 17f, height), false, true, true);
		GUI.BeginGroup(new Rect(0f, 0f, rect.width, pane.WindowHeight + pane.Scroll.y));
		foreach (ChatGroup group in pane.Groups)
		{
			num2 += this.DrawPlayerGroup(group, num2, rect.width - 17f, pane.SearchText.Trim().ToLower(), false);
		}
		GUI.EndGroup();
		GUITools.EndScrollView();
		pane.ContentHeight = num2;
		GUI.enabled = enabled;
		GUI.EndGroup();
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x000417B0 File Offset: 0x0003F9B0
	private void DrawModeratorCommPane(Rect rect, ChatGroupPanel pane)
	{
		GUI.BeginGroup(rect);
		int num = this.DoModeratorControlPanel(new Rect(0f, 0f, rect.width, rect.height), pane);
		pane.WindowHeight = rect.height - (float)num;
		float height = Mathf.Max(pane.WindowHeight, pane.ContentHeight);
		float num2 = 0f;
		pane.Scroll = GUITools.BeginScrollView(new Rect(0f, 0f, rect.width, pane.WindowHeight), pane.Scroll, new Rect(0f, 0f, rect.width - 17f, height), false, true, true);
		GUI.BeginGroup(new Rect(0f, 0f, rect.width, pane.WindowHeight + pane.Scroll.y));
		foreach (ChatGroup group in pane.Groups)
		{
			num2 += this.DrawPlayerGroup(group, num2, rect.width - 17f, pane.SearchText.Trim().ToLower(), true);
			if (num2 > pane.Scroll.y + pane.WindowHeight)
			{
				break;
			}
		}
		GUI.EndGroup();
		GUITools.EndScrollView();
		pane.ContentHeight = num2;
		GUI.EndGroup();
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x00041938 File Offset: 0x0003FB38
	private int DoLobbyControlPanel(Rect rect, ChatGroupPanel pane)
	{
		int num = 0;
		bool flag = PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator;
		bool flag2 = flag && ChatPageGUI.IsCompleteLobbyLoaded;
		rect = new Rect(rect.x, rect.yMax - 36f - (float)((!flag2) ? ((!flag) ? 0 : 30) : 60) - 1f, rect.width, (float)(37 + ((!flag2) ? ((!flag) ? 0 : 30) : 60)));
		GUI.BeginGroup(rect, GUIContent.none, BlueStonez.window_standard_grey38);
		if (flag)
		{
			GUI.enabled = (this._nextFullLobbyUpdate < Time.time);
			if (flag2 && GUITools.Button(new Rect(6f, 5f, rect.width - 12f, 26f), new GUIContent("Reset Lobby"), BlueStonez.buttondark_medium))
			{
				ChatPageGUI.IsCompleteLobbyLoaded = false;
				this._nextFullLobbyUpdate = Time.time + 10f;
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendUpdateResetLobby();
			}
			if (GUITools.Button(new Rect(6f, rect.height - 61f, rect.width - 12f, 26f), new GUIContent((this._nextFullLobbyUpdate >= Time.time) ? string.Format("Next Update ({0:N0})", this._nextFullLobbyUpdate - Time.time) : "Get All Players "), BlueStonez.buttondark_medium))
			{
				ChatPageGUI.IsCompleteLobbyLoaded = true;
				this._nextFullLobbyUpdate = Time.time + 10f;
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdateAllActors();
			}
			GUI.enabled = true;
			num += ((!ChatPageGUI.IsCompleteLobbyLoaded) ? 30 : 60);
		}
		bool flag3 = !string.IsNullOrEmpty(pane.SearchText);
		if (!flag3)
		{
			pane.SearchText = " ";
		}
		GUI.SetNextControlName("@LobbySearch");
		GUI.changed = false;
		pane.SearchText = GUI.TextField(new Rect(6f, rect.height - 30f, rect.width - (float)((!flag3) ? 12 : 37), 24f), pane.SearchText, 20, BlueStonez.textField);
		if (!flag3 && GUI.GetNameOfFocusedControl() != "@LobbySearch")
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(new Rect(12f, rect.height - 30f, rect.width - 20f, 24f), LocalizedStrings.Search, BlueStonez.label_interparkmed_10pt_left);
			GUI.color = Color.white;
		}
		if (flag3 && GUITools.Button(new Rect(rect.width - 28f, rect.height - 30f, 22f, 22f), new GUIContent("x"), BlueStonez.panelquad_button))
		{
			pane.SearchText = string.Empty;
			GUIUtility.keyboardControl = 0;
		}
		GUI.EndGroup();
		return num + 36;
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x00041C74 File Offset: 0x0003FE74
	public float DrawPlayerGroup(ChatGroup group, float vOffset, float width, string search, bool allowSelfSelection = false)
	{
		Rect position = new Rect(0f, vOffset, width, 24f);
		GUI.Label(position, GUIContent.none, BlueStonez.window_standard_grey38);
		if (group.Players != null)
		{
			GUI.Label(position, string.Concat(new object[]
			{
				group.Title,
				" (",
				group.Players.Count,
				")"
			}), BlueStonez.label_interparkbold_11pt);
		}
		vOffset += 24f;
		int num = 0;
		if (group.Players != null)
		{
			GUI.BeginGroup(new Rect(0f, vOffset, width, (float)(group.Players.Count * 24)));
			foreach (CommUser commUser in group.Players)
			{
				if (string.IsNullOrEmpty(search) || commUser.Name.ToLower().Contains(search))
				{
					this.GroupDrawUser((float)(num++ * 24), width, commUser, allowSelfSelection);
				}
			}
			GUI.EndGroup();
		}
		return 24f + (float)(group.Players.Count * 24);
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x00041DBC File Offset: 0x0003FFBC
	private void DoTabs(Rect rect)
	{
		float num = Mathf.Floor(rect.width / (float)Singleton<ChatManager>.Instance.TabCounter);
		bool flag = false;
		int num2 = 0;
		bool flag2 = GUI.Toggle(new Rect(rect.x + (float)num2 * num, rect.y, num, rect.height), ChatPageGUI.SelectedTab == TabArea.Lobby, LocalizedStrings.Lobby, BlueStonez.tab_medium);
		if (flag2 && ChatPageGUI.SelectedTab != TabArea.Lobby)
		{
			ChatPageGUI.SelectedTab = TabArea.Lobby;
			flag = true;
		}
		num2++;
		flag2 = GUI.Toggle(new Rect(rect.x + (float)num2 * num, rect.y, num, rect.height), ChatPageGUI.SelectedTab == TabArea.Private, LocalizedStrings.Private, BlueStonez.tab_medium);
		if (flag2 && ChatPageGUI.SelectedTab != TabArea.Private)
		{
			ChatPageGUI.SelectedTab = TabArea.Private;
			flag = true;
			Singleton<ChatManager>.Instance.HasUnreadPrivateMessage.Value = false;
		}
		if (Singleton<ChatManager>.Instance.HasUnreadPrivateMessage)
		{
			GUI.DrawTexture(new Rect(rect.x + (float)num2 * num, rect.y + 1f, 18f, 18f), CommunicatorIcons.NewInboxMessage);
		}
		num2++;
		if (Singleton<ChatManager>.Instance.ShowTab(TabArea.Clan))
		{
			flag2 = GUI.Toggle(new Rect(rect.x + (float)num2 * num, rect.y, num, rect.height), ChatPageGUI.SelectedTab == TabArea.Clan, LocalizedStrings.Clan, BlueStonez.tab_medium);
			if (flag2 && ChatPageGUI.SelectedTab != TabArea.Clan)
			{
				ChatPageGUI.SelectedTab = TabArea.Clan;
				flag = true;
				Singleton<ChatManager>.Instance.HasUnreadClanMessage.Value = false;
			}
			if (PlayerDataManager.IsPlayerInClan && Singleton<ChatManager>.Instance.HasUnreadClanMessage)
			{
				GUI.DrawTexture(new Rect(rect.x + (float)num2 * num, rect.y + 1f, 18f, 18f), CommunicatorIcons.NewInboxMessage);
			}
			num2++;
		}
		if (Singleton<ChatManager>.Instance.ShowTab(TabArea.InGame))
		{
			flag2 = GUI.Toggle(new Rect(rect.x + (float)num2 * num, rect.y, num, rect.height), ChatPageGUI.SelectedTab == TabArea.InGame, LocalizedStrings.Game, BlueStonez.tab_medium);
			if (flag2 && ChatPageGUI.SelectedTab != TabArea.InGame)
			{
				ChatPageGUI.SelectedTab = TabArea.InGame;
				this._currentChatMessage = string.Empty;
				flag = true;
			}
			num2++;
		}
		if (Singleton<ChatManager>.Instance.ShowTab(TabArea.Moderation))
		{
			flag2 = GUI.Toggle(new Rect(rect.x + (float)num2 * num, rect.y, num, rect.height), ChatPageGUI.SelectedTab == TabArea.Moderation, LocalizedStrings.Admin, BlueStonez.tab_medium);
			if (flag2 && ChatPageGUI.SelectedTab != TabArea.Moderation && PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
			{
				ChatPageGUI.SelectedTab = TabArea.Moderation;
				this._currentChatMessage = string.Empty;
				flag = true;
			}
			num2++;
		}
		if (flag)
		{
			this._currentChatMessage = string.Empty;
			PopupMenu.Hide();
			GUIUtility.keyboardControl = 0;
		}
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x000420B4 File Offset: 0x000402B4
	private void DoDialog(Rect rect, ChatGroupPanel pane, ChatDialog dialog)
	{
		if (dialog == null)
		{
			return;
		}
		dialog.CheckSize(rect);
		if (!Input.GetMouseButton(0))
		{
			if (this.autoScroll)
			{
				this._dialogScroll.y = float.MaxValue;
			}
		}
		else
		{
			this.autoScroll = false;
		}
		Rect position = new Rect(rect.x, rect.y + Mathf.Clamp(rect.height - dialog._heightCache, 0f, rect.height), rect.width, rect.height);
		GUI.BeginGroup(position);
		int num = 0;
		float num2 = 0f;
		this._dialogScroll = GUITools.BeginScrollView(new Rect(0f, 0f, dialog._frameSize.x, dialog._frameSize.y), this._dialogScroll, new Rect(0f, 0f, dialog._contentSize.x, dialog._contentSize.y), false, false, true);
		foreach (InstantMessage instantMessage in dialog._msgQueue)
		{
			if (!Singleton<ChatManager>.Instance.IsMuted(instantMessage.Cmid) && (dialog.CanShow == null || dialog.CanShow(instantMessage.Context)))
			{
				if (num % 2 == 0)
				{
					GUI.Label(new Rect(0f, num2, dialog._contentSize.x - 1f, instantMessage.Height), GUIContent.none, BlueStonez.box_grey38);
				}
				if (GUI.Button(new Rect(0f, num2, dialog._contentSize.x - 1f, instantMessage.Height), GUIContent.none, BlueStonez.dropdown_list))
				{
					this.SelectUser(instantMessage.Cmid);
					this.ScrollToUser(instantMessage.Cmid);
					if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
					{
						CommUser user = new CommUser(instantMessage.Actor);
						if (Event.current.button == 1)
						{
							this._playerMenu.msg = instantMessage;
							this._playerMenu.Show(GUIUtility.GUIToScreenPoint(Event.current.mousePosition), user);
						}
					}
				}
				if (string.IsNullOrEmpty(instantMessage.PlayerName))
				{
					GUI.color = new Color(0.6f, 0.6f, 0.6f);
					GUI.Label(new Rect(4f, num2, dialog._contentSize.x - 8f, 20f), instantMessage.Text, BlueStonez.label_interparkbold_11pt_left);
				}
				else
				{
					GUI.color = this.GetNameColor(instantMessage);
					GUI.Label(new Rect(4f, num2, dialog._contentSize.x - 8f, 20f), instantMessage.PlayerName + ":", BlueStonez.label_interparkbold_11pt_left);
					GUI.color = new Color(0.9f, 0.9f, 0.9f);
					GUI.Label(new Rect(4f, num2 + 20f, dialog._contentSize.x - 8f, instantMessage.Height - 20f), instantMessage.Text, BlueStonez.label_interparkmed_11pt_left);
				}
				GUI.color = new Color(1f, 1f, 1f, 0.5f);
				GUI.Label(new Rect(4f, num2, dialog._contentSize.x - 8f, 20f), instantMessage.TimeString, BlueStonez.label_interparkmed_10pt_right);
				GUI.color = Color.white;
				num2 += instantMessage.Height;
				num++;
			}
		}
		GUITools.EndScrollView();
		dialog._heightCache = num2;
		GUI.EndGroup();
		if (dialog.UserCmid > 0 && !AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.HasPlayer(dialog.UserCmid))
		{
			GUI.Label(rect, dialog.UserName + " is currently offline", this.label_notification);
		}
	}

	// Token: 0x06000A4D RID: 2637 RVA: 0x000424D0 File Offset: 0x000406D0
	private void DoModeratorDialog(Rect rect, ChatGroupPanel pane)
	{
		if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
		{
			GUI.BeginGroup(rect, GUIContent.none);
			CommUser commUser;
			if (Singleton<ChatManager>.Instance._naughtyUsers.TryGetValue(Singleton<ChatManager>.Instance.SelectedCmid, out commUser) && commUser != null)
			{
				GUI.TextField(new Rect(10f, 15f, rect.width, 20f), "Name: " + commUser.Name, BlueStonez.label_interparkbold_11pt_left);
				GUI.TextField(new Rect(10f, 37f, rect.width, 20f), "Cmid: " + commUser.Cmid, BlueStonez.label_interparkmed_11pt_left);
				float num = rect.width - 20f;
				GUI.BeginGroup(new Rect(10f, 80f, num, rect.height - 70f), GUIContent.none, BlueStonez.box_grey50);
				if (GUITools.Button(new Rect(5f, 5f, num - 10f, 20f), new GUIContent("Clear and Unban"), BlueStonez.buttondark_medium))
				{
					AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendClearModeratorFlags(commUser.Cmid);
					Singleton<ChatManager>.Instance.SelectedCmid = 0;
					Singleton<ChatManager>.Instance._naughtyUsers.Remove(commUser.Cmid);
				}
				int num2 = 40;
				if ((commUser.ModerationFlag & 4) != 0)
				{
					GUI.Label(new Rect(8f, (float)num2, num - 10f, 20f), "- BANNED", BlueStonez.label_interparkbold_11pt_left);
					num2 += 20;
				}
				if ((commUser.ModerationFlag & 2) != 0)
				{
					GUI.Label(new Rect(8f, (float)num2, num - 10f, 20f), "- Ghosted", BlueStonez.label_interparkmed_11pt_left);
					num2 += 20;
				}
				if ((commUser.ModerationFlag & 1) != 0)
				{
					GUI.Label(new Rect(8f, (float)num2, num - 10f, 20f), "- Muted", BlueStonez.label_interparkmed_11pt_left);
					num2 += 20;
				}
				if ((commUser.ModerationFlag & 8) != 0)
				{
					GUI.Label(new Rect(8f, (float)num2, num - 10f, 20f), "- Speed " + commUser.ModerationInfo, BlueStonez.label_interparkmed_11pt_left);
					num2 += 20;
				}
				if ((commUser.ModerationFlag & 16) != 0)
				{
					GUI.Label(new Rect(8f, (float)num2, num - 10f, 20f), "- Spamming", BlueStonez.label_interparkmed_11pt_left);
					num2 += 20;
				}
				if ((commUser.ModerationFlag & 32) != 0)
				{
					GUI.Label(new Rect(8f, (float)num2, num - 10f, 20f), "- CrudeLanguage", BlueStonez.label_interparkmed_11pt_left);
					num2 += 20;
				}
				GUI.Label(new Rect(8f, (float)(num2 + 20), num - 10f, 100f), commUser.ModerationInfo, BlueStonez.label_interparkmed_11pt_left);
				GUI.EndGroup();
			}
			else
			{
				GUI.Label(new Rect(0f, rect.height / 2f, rect.width, 20f), "No user selected", BlueStonez.label_interparkmed_11pt);
			}
			GUI.EndGroup();
		}
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x00008683 File Offset: 0x00006883
	private void DoDialogHeader(Rect rect, ChatDialog d)
	{
		GUI.Label(rect, GUIContent.none, BlueStonez.window_standard_grey38);
		GUI.Label(rect, d.Title, BlueStonez.label_interparkbold_11pt);
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x0004280C File Offset: 0x00040A0C
	private void DoPrivateDialogHeader(Rect rect, ChatDialog d)
	{
		GUI.Label(rect, GUIContent.none, BlueStonez.window_standard_grey38);
		if (d != null && d.UserCmid > 0)
		{
			GUI.Label(rect, d.Title, BlueStonez.label_interparkbold_11pt);
			if (GUITools.Button(new Rect(rect.x + rect.width - 20f, rect.y + 3f, 16f, 16f), new GUIContent("x"), BlueStonez.panelquad_button))
			{
				Singleton<ChatManager>.Instance.RemoveDialog(d);
			}
		}
		else
		{
			GUI.Label(rect, LocalizedStrings.PrivateChat, BlueStonez.label_interparkbold_11pt);
		}
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x000428B8 File Offset: 0x00040AB8
	private void DoModeratorPaneFooter(Rect rect, ChatGroupPanel pane)
	{
		GUI.BeginGroup(rect, BlueStonez.window_standard_grey38);
		CommUser commUser;
		if (Singleton<ChatManager>.Instance.SelectedCmid > 0 && Singleton<ChatManager>.Instance.TryGetLobbyCommUser(Singleton<ChatManager>.Instance.SelectedCmid, out commUser) && commUser != null)
		{
			if (GUITools.Button(new Rect(5f, 6f, rect.width - 10f, rect.height - 12f), new GUIContent("Moderate User"), BlueStonez.buttondark_medium))
			{
				ModerationPanelGUI moderationPanelGUI = PanelManager.Instance.OpenPanel(PanelType.Moderation) as ModerationPanelGUI;
				if (moderationPanelGUI)
				{
					moderationPanelGUI.SetSelectedUser(commUser);
				}
			}
		}
		else if (GUITools.Button(new Rect(5f, 6f, rect.width - 10f, rect.height - 12f), new GUIContent("Open Moderator"), BlueStonez.buttondark_medium))
		{
			PanelManager.Instance.OpenPanel(PanelType.Moderation);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000A51 RID: 2641 RVA: 0x000429C0 File Offset: 0x00040BC0
	private void DoDialogFooter(Rect rect, ChatGroupPanel pane, ChatDialog dialog)
	{
		GUI.BeginGroup(rect, BlueStonez.window_standard_grey38);
		bool enabled = GUI.enabled;
		GUI.enabled &= (!AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.IsPlayerMuted && dialog != null && dialog.CanChat);
		if (ChatPageGUI.SelectedTab == TabArea.InGame)
		{
			GUI.enabled &= (GameState.Current.HasJoinedGame && GameState.Current.IsInGame);
		}
		GUI.SetNextControlName("@CurrentChatMessage");
		this._currentChatMessage = GUI.TextField(new Rect(6f, 6f, rect.width - 60f, rect.height - 12f), this._currentChatMessage, 140, BlueStonez.textField);
		this._currentChatMessage = this._currentChatMessage.Trim(new char[]
		{
			'\n'
		});
		if (this._spammingNotificationTime > Time.time)
		{
			GUI.color = Color.red;
			GUI.Label(new Rect(15f, 6f, rect.width - 66f, rect.height - 12f), LocalizedStrings.DontSpamTheLobbyChat, BlueStonez.label_interparkmed_10pt_left);
			GUI.color = Color.white;
		}
		else if (string.IsNullOrEmpty(this._currentChatMessage) && GUI.GetNameOfFocusedControl() != "@CurrentChatMessage")
		{
			string text = string.Empty;
			if (dialog != null && dialog.UserCmid > 0)
			{
				if (dialog.CanChat)
				{
					text = LocalizedStrings.EnterAMessageHere;
				}
				else
				{
					text = dialog.UserName + LocalizedStrings.Offline;
				}
			}
			else
			{
				text = LocalizedStrings.EnterAMessageHere;
			}
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(new Rect(10f, 6f, rect.width - 66f, rect.height - 12f), text, BlueStonez.label_interparkmed_10pt_left);
			GUI.color = Color.white;
		}
		if ((GUITools.Button(new Rect(rect.width - 51f, 6f, 45f, rect.height - 12f), new GUIContent(LocalizedStrings.Send), BlueStonez.buttondark_small) || Event.current.keyCode == KeyCode.Return) && !AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.IsPlayerMuted && this._lastMessageSentTimer > 0.29f)
		{
			this.SendChatMessage();
			GUI.FocusControl("@CurrentChatMessage");
		}
		GUI.enabled = enabled;
		GUI.EndGroup();
	}

	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000A52 RID: 2642 RVA: 0x000086A6 File Offset: 0x000068A6
	public static bool IsChatActive
	{
		get
		{
			return GUI.GetNameOfFocusedControl() == "@CurrentChatMessage";
		}
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x00042C7C File Offset: 0x00040E7C
	private void GroupDrawUser(float vOffset, float width, CommUser user, bool allowSelfSelection = false)
	{
		int cmid = PlayerDataManager.Cmid;
		Rect rect = new Rect(3f, vOffset, width - 3f, 24f);
		if (Singleton<ChatManager>.Instance.SelectedCmid == user.Cmid)
		{
			GUI.color = new Color(ColorScheme.UberStrikeBlue.r, ColorScheme.UberStrikeBlue.g, ColorScheme.UberStrikeBlue.b, 0.5f);
			GUI.Label(rect, GUIContent.none, BlueStonez.box_white);
			GUI.color = Color.white;
		}
		bool enabled = GUI.enabled;
		GUI.Label(new Rect(10f, vOffset + 3f, 11.2f, 16f), ChatManager.GetPresenceIcon(user.PresenceIndex), GUIStyle.none);
		GUI.Label(new Rect(23f, vOffset + 3f, 16f, 16f), UberstrikeIconsHelper.GetIconForChannel(user.Channel), GUIStyle.none);
		if (user.Cmid == PlayerDataManager.Cmid)
		{
			GUI.color = ColorScheme.ChatNameCurrentUser;
		}
		else if (user.IsFriend || user.IsClanMember)
		{
			GUI.color = ColorScheme.ChatNameFriendsUser;
		}
		else if (user.IsFacebookFriend)
		{
			GUI.color = ColorScheme.ChatNameFacebookFriendUser;
		}
		else
		{
			GUI.color = ColorScheme.GetNameColorByAccessLevel(user.AccessLevel);
		}
		if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
		{
			GUI.Label(new Rect(44f, vOffset, width - 66f, 24f), string.Concat(new object[]
			{
				"{",
				user.Cmid,
				"} ",
				user.Name
			}), BlueStonez.label_interparkmed_10pt_left);
		}
		else
		{
			GUI.Label(new Rect(44f, vOffset, width - 66f, 24f), user.Name, BlueStonez.label_interparkmed_10pt_left);
		}
		GUI.color = Color.white;
		if (user.Cmid != cmid && GUI.Button(new Rect(rect.width - 17f, vOffset + 1f, 18f, 18f), GUIContent.none, BlueStonez.button_context))
		{
			this.SelectUser(user.Cmid);
			this._playerMenu.Show(GUIUtility.GUIToScreenPoint(Event.current.mousePosition), user);
		}
		GUI.Box(rect.Expand(0, -1), GUIContent.none, BlueStonez.dropdown_list);
		if (MouseInput.IsMouseClickIn(rect, 0))
		{
			if (Singleton<ChatManager>.Instance.SelectedCmid != user.Cmid)
			{
				if (allowSelfSelection || user.Cmid != cmid)
				{
					this.SelectUser(user.Cmid);
				}
				if (ChatPageGUI.SelectedTab == TabArea.Private)
				{
					Singleton<ChatManager>.Instance.CreatePrivateChat(user.Cmid);
				}
			}
			else if (MouseInput.IsDoubleClick() && user.Cmid != cmid && ChatPageGUI.SelectedTab != TabArea.Private)
			{
				Singleton<ChatManager>.Instance.CreatePrivateChat(user.Cmid);
				this.ScrollToUser(user.Cmid);
			}
		}
		else if (MouseInput.IsMouseClickIn(rect, 1))
		{
			this._playerMenu.Show(GUIUtility.GUIToScreenPoint(Event.current.mousePosition), user);
		}
		ChatDialog chatDialog;
		if (ChatPageGUI.SelectedTab == TabArea.Private && Singleton<ChatManager>.Instance._dialogsByCmid.TryGetValue(user.Cmid, out chatDialog) && chatDialog != null && chatDialog.HasUnreadMessage && chatDialog != Singleton<ChatManager>.Instance.SelectedDialog)
		{
			GUI.Label(new Rect(rect.width - 50f, vOffset, 25f, 25f), CommunicatorIcons.NewInboxMessage);
		}
		if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
		{
			int num = user.ModerationFlag & 12;
			if (num == 8)
			{
				GUI.Label(new Rect(width - 50f, vOffset + 3f, 20f, 20f), CommunicatorIcons.TagLightningBolt);
			}
		}
		GUI.enabled = enabled;
	}

	// Token: 0x06000A54 RID: 2644 RVA: 0x0004307C File Offset: 0x0004127C
	private void SelectUser(int cmid)
	{
		Singleton<ChatManager>.Instance.SelectedCmid = cmid;
		ChatDialog chatDialog;
		if (ChatPageGUI.SelectedTab == TabArea.Private && Singleton<ChatManager>.Instance._dialogsByCmid.TryGetValue(cmid, out chatDialog))
		{
			chatDialog.HasUnreadMessage = false;
			this._currentChatMessage = string.Empty;
			Singleton<ChatManager>.Instance.SelectedDialog = chatDialog;
			this._dialogScroll.y = float.MaxValue;
			this.autoScroll = true;
		}
	}

	// Token: 0x06000A55 RID: 2645 RVA: 0x000430EC File Offset: 0x000412EC
	private void ScrollToUser(int cmid)
	{
		ChatGroupPanel chatGroupPanel = Singleton<ChatManager>.Instance._commPanes[(int)ChatPageGUI.SelectedTab];
		chatGroupPanel.ScrollToUser(cmid);
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x00043114 File Offset: 0x00041314
	private void SendChatMessage()
	{
		if (string.IsNullOrEmpty(this._currentChatMessage))
		{
			return;
		}
		this._dialogScroll.y = float.MaxValue;
		this.autoScroll = true;
		this._currentChatMessage = TextUtilities.ShortenText(TextUtilities.Trim(this._currentChatMessage), 140, false);
		switch (ChatPageGUI.SelectedTab)
		{
		case TabArea.Lobby:
			if (!AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendLobbyChatMessage(this._currentChatMessage))
			{
				this._spammingNotificationTime = Time.time + 5f;
			}
			break;
		case TabArea.Private:
		{
			ChatDialog selectedDialog = Singleton<ChatManager>.Instance.SelectedDialog;
			if (selectedDialog != null)
			{
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendPrivateChatMessage(selectedDialog.UserCmid, selectedDialog.UserName, this._currentChatMessage);
			}
			break;
		}
		case TabArea.Clan:
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendClanChatMessage(this._currentChatMessage);
			break;
		case TabArea.InGame:
			GameState.Current.SendChatMessage(this._currentChatMessage, ChatContext.Player);
			break;
		}
		this._lastMessageSentTimer = 0f;
		this._currentChatMessage = string.Empty;
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x00043244 File Offset: 0x00041444
	private Color GetNameColor(InstantMessage msg)
	{
		Color result;
		if (msg.Cmid == PlayerDataManager.Cmid)
		{
			result = ColorScheme.ChatNameCurrentUser;
		}
		else if (msg.IsFriend || msg.IsClan)
		{
			result = ColorScheme.ChatNameFriendsUser;
		}
		else if (msg.IsFacebookFriend)
		{
			result = ColorScheme.ChatNameFacebookFriendUser;
		}
		else
		{
			result = ColorScheme.GetNameColorByAccessLevel(msg.AccessLevel);
		}
		return result;
	}

	// Token: 0x06000A58 RID: 2648 RVA: 0x000432B0 File Offset: 0x000414B0
	private void MenuCmdRemoveFriend(CommUser user)
	{
		if (user != null)
		{
			int friendCmid = user.Cmid;
			PopupSystem.ShowMessage(LocalizedStrings.RemoveFriendCaps, string.Format(LocalizedStrings.DoYouReallyWantToRemoveNFromYourFriendsList, user.Name), PopupSystem.AlertType.OKCancel, delegate()
			{
				Singleton<InboxManager>.Instance.RemoveFriend(friendCmid);
			}, LocalizedStrings.Remove, null, LocalizedStrings.Cancel, PopupSystem.ActionType.Negative);
		}
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x0004330C File Offset: 0x0004150C
	private void MenuCmdAddFriend(CommUser user)
	{
		if (user != null)
		{
			FriendRequestPanelGUI friendRequestPanelGUI = PanelManager.Instance.OpenPanel(PanelType.FriendRequest) as FriendRequestPanelGUI;
			if (friendRequestPanelGUI)
			{
				friendRequestPanelGUI.SelectReceiver(user.Cmid, user.Name);
			}
		}
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x000086B7 File Offset: 0x000068B7
	private string MenuCaptionMute(CommUser user)
	{
		if (user != null && Singleton<ChatManager>.Instance.IsMuted(user.Cmid))
		{
			return "Show Messages";
		}
		return "Hide Messages";
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x000086DF File Offset: 0x000068DF
	private bool MenuChkMute(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid;
	}

	// Token: 0x06000A5C RID: 2652 RVA: 0x00043350 File Offset: 0x00041550
	private void MenuCmdMute(CommUser user)
	{
		if (user != null)
		{
			if (Singleton<ChatManager>.Instance.IsMuted(user.Cmid))
			{
				Singleton<ChatManager>.Instance.ShowConversations(user.Cmid);
			}
			else
			{
				Singleton<ChatManager>.Instance.HideConversations(user.Cmid);
			}
		}
	}

	// Token: 0x06000A5D RID: 2653 RVA: 0x000086F9 File Offset: 0x000068F9
	private void MenuCmdChat(CommUser user)
	{
		if (user != null)
		{
			Singleton<ChatManager>.Instance.CreatePrivateChat(user.Cmid);
			this.ScrollToUser(user.Cmid);
		}
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x000433A0 File Offset: 0x000415A0
	private void MenuCmdSendMessage(CommUser user)
	{
		if (user != null)
		{
			SendMessagePanelGUI sendMessagePanelGUI = PanelManager.Instance.OpenPanel(PanelType.SendMessage) as SendMessagePanelGUI;
			if (sendMessagePanelGUI)
			{
				sendMessagePanelGUI.SelectReceiver(user.Cmid, user.Name);
			}
		}
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x0000871D File Offset: 0x0000691D
	private void MenuCmdJoinGame(CommUser user)
	{
		if (user != null && user.CurrentGame != null)
		{
			Singleton<GameStateController>.Instance.JoinNetworkGame(user.CurrentGame);
		}
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x000433E4 File Offset: 0x000415E4
	private void MenuCmdInviteClan(CommUser user)
	{
		if (user != null)
		{
			InviteToClanPanelGUI inviteToClanPanelGUI = PanelManager.Instance.OpenPanel(PanelType.ClanRequest) as InviteToClanPanelGUI;
			if (inviteToClanPanelGUI)
			{
				inviteToClanPanelGUI.SelectReceiver(user.Cmid, user.ShortName);
			}
		}
	}

	// Token: 0x06000A61 RID: 2657 RVA: 0x00043428 File Offset: 0x00041628
	private void MenuCmdCopyData(CommUser user)
	{
		if (user != null)
		{
			TextEditor textEditor = new TextEditor();
			textEditor.content = new GUIContent(string.Concat(new object[]
			{
				"<Cmid=",
				user.Cmid,
				"> <Name=",
				user.Name,
				">"
			}));
			textEditor.SelectAll();
			textEditor.Copy();
		}
	}

	// Token: 0x06000A62 RID: 2658 RVA: 0x00043494 File Offset: 0x00041694
	private void MenuCmdCopyMsg(CommUser user, InstantMessage msg)
	{
		if (msg != null)
		{
			TextEditor textEditor = new TextEditor();
			DateTime dateTime = msg.ArrivalTime.ToUniversalTime();
			textEditor.content = new GUIContent(string.Concat(new object[]
			{
				"LobbyMessage from <name=",
				msg.PlayerName,
				"> <cmid=",
				msg.Cmid,
				">: <",
				msg.Text,
				"> <",
				dateTime,
				">"
			}));
			textEditor.SelectAll();
			textEditor.Copy();
		}
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x00043530 File Offset: 0x00041730
	private void MenuCmdCopyPlayerName(CommUser user, InstantMessage msg)
	{
		Regex regex = new Regex("[^\"\\r\\n]*[\\[\\]][ ]");
		TextEditor textEditor = new TextEditor();
		if (msg != null)
		{
			if (Regex.IsMatch(msg.PlayerName, "[^\"\\r\\n]*[\\[\\]][ ]"))
			{
				string playerName = msg.PlayerName;
				string[] array = regex.Split(playerName);
				textEditor.content = new GUIContent("\"" + array[1] + "\"");
			}
			else
			{
				textEditor.content = new GUIContent("\"" + msg.PlayerName + "\"");
			}
		}
		else if (msg == null && user != null)
		{
			if (Regex.IsMatch(user.Name, "[^\"\\r\\n]*[\\[\\]][ ]"))
			{
				string name = user.Name;
				string[] array2 = regex.Split(name);
				textEditor.content = new GUIContent("\"" + array2[1] + "\"");
			}
			else
			{
				textEditor.content = new GUIContent("\"" + user.Name + "\"");
			}
		}
		textEditor.SelectAll();
		textEditor.Copy();
	}

	// Token: 0x06000A64 RID: 2660 RVA: 0x00043644 File Offset: 0x00041844
	private void MenuCmdModeratePlayer(CommUser user)
	{
		if (user != null)
		{
			ModerationPanelGUI moderationPanelGUI = PanelManager.Instance.OpenPanel(PanelType.Moderation) as ModerationPanelGUI;
			if (moderationPanelGUI)
			{
				moderationPanelGUI.SetSelectedUser(user);
			}
		}
	}

	// Token: 0x06000A65 RID: 2661 RVA: 0x00008740 File Offset: 0x00006940
	private bool MenuChkIsModerator(CommUser user)
	{
		return user != null && PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator;
	}

	// Token: 0x06000A66 RID: 2662 RVA: 0x0004367C File Offset: 0x0004187C
	private bool MenuChkAddFriend(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && user.AccessLevel <= PlayerDataManager.AccessLevel && !PlayerDataManager.IsFriend(user.Cmid) && !PlayerDataManager.IsFacebookFriend(user.Cmid);
	}

	// Token: 0x06000A67 RID: 2663 RVA: 0x00008756 File Offset: 0x00006956
	private bool MenuChkRemoveFriend(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && PlayerDataManager.IsFriend(user.Cmid);
	}

	// Token: 0x06000A68 RID: 2664 RVA: 0x0000877C File Offset: 0x0000697C
	private bool MenuChkChat(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && user.IsOnline;
	}

	// Token: 0x06000A69 RID: 2665 RVA: 0x0000879D File Offset: 0x0000699D
	private bool MenuChkSendMessage(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && !GameState.Current.HasJoinedGame;
	}

	// Token: 0x06000A6A RID: 2666 RVA: 0x000087C5 File Offset: 0x000069C5
	private bool MenuChkJoinGame(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && user.IsInGame;
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x000436D0 File Offset: 0x000418D0
	private bool MenuChkInviteClan(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && (user.AccessLevel <= PlayerDataManager.AccessLevel || PlayerDataManager.IsFriend(user.Cmid) || PlayerDataManager.IsFacebookFriend(user.Cmid)) && PlayerDataManager.IsPlayerInClan && PlayerDataManager.CanInviteToClan && !PlayerDataManager.IsClanMember(user.Cmid);
	}

	// Token: 0x04000A27 RID: 2599
	private const int SEARCH_HEIGHT = 36;

	// Token: 0x04000A28 RID: 2600
	private const float TitleHeight = 24f;

	// Token: 0x04000A29 RID: 2601
	private const int TAB_WIDTH = 300;

	// Token: 0x04000A2A RID: 2602
	private const int CHAT_USER_HEIGHT = 24;

	// Token: 0x04000A2B RID: 2603
	private GUIStyle label_notification;

	// Token: 0x04000A2C RID: 2604
	private Rect _mainRect;

	// Token: 0x04000A2D RID: 2605
	private Vector2 _dialogScroll;

	// Token: 0x04000A2E RID: 2606
	public static bool IsCompleteLobbyLoaded;

	// Token: 0x04000A2F RID: 2607
	private float _nextFullLobbyUpdate;

	// Token: 0x04000A30 RID: 2608
	private bool autoScroll;

	// Token: 0x04000A31 RID: 2609
	private float _spammingNotificationTime;

	// Token: 0x04000A32 RID: 2610
	private float _nextNaughtyListUpdate;

	// Token: 0x04000A33 RID: 2611
	private float _yPosition;

	// Token: 0x04000A34 RID: 2612
	private float _lastMessageSentTimer = 0.3f;

	// Token: 0x04000A35 RID: 2613
	private string _currentChatMessage = string.Empty;

	// Token: 0x04000A36 RID: 2614
	private PopupMenu _playerMenu;

	// Token: 0x04000A37 RID: 2615
	private float _keyboardOffset;
}
