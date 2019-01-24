using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x02000182 RID: 386
public class GameChatPageGUI : PageGUI
{
	// Token: 0x06000A98 RID: 2712 RVA: 0x000089A2 File Offset: 0x00006BA2
	private void Awake()
	{
		this._playerMenu = new PopupMenu();
		base.IsOnGUIEnabled = true;
	}

	// Token: 0x06000A99 RID: 2713 RVA: 0x00043970 File Offset: 0x00041B70
	private void Start()
	{
		this._playerMenu.AddMenuItem("Add Friend", new Action<CommUser>(this.MenuCmdAddFriend), new Func<CommUser, bool>(this.MenuChkAddFriend));
		this._playerMenu.AddMenuItem("Unfriend", new Action<CommUser>(this.MenuCmdRemoveFriend), new Func<CommUser, bool>(this.MenuChkRemoveFriend));
		this._playerMenu.AddMenuItem(LocalizedStrings.InviteToClan, new Action<CommUser>(this.MenuCmdInviteClan), new Func<CommUser, bool>(this.MenuChkInviteClan));
		this._playerMenu.AddMenuItem(LocalizedStrings.Report + " Cheater", new Action<CommUser>(this.MenuCmdReportPlayer), new Func<CommUser, bool>(this.MenuChkReportPlayer));
		if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
		{
			this._playerMenu.AddMenuItem("- - - - - - - - - - - - -", null, (CommUser A_0) => true);
			this._playerMenu.AddMenuItem("Copy Data", new Action<CommUser>(this.MenuCmdCopyData), (CommUser A_0) => true);
			this._playerMenu.AddMenuItem("Moderate Player", new Action<CommUser>(this.MenuCmdModeratePlayer), (CommUser A_0) => true);
		}
	}

	// Token: 0x06000A9A RID: 2714 RVA: 0x00043AD4 File Offset: 0x00041CD4
	private void MenuCmdCopyData(CommUser user)
	{
		if (user != null)
		{
			TextEditor textEditor = new TextEditor();
			textEditor.content = new GUIContent(string.Concat(new object[]
			{
				"<Cmid:",
				user.Cmid,
				"> <Name:",
				user.Name,
				">"
			}));
			textEditor.SelectAll();
			textEditor.Copy();
		}
	}

	// Token: 0x06000A9B RID: 2715 RVA: 0x00043644 File Offset: 0x00041844
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

	// Token: 0x06000A9C RID: 2716 RVA: 0x00043B40 File Offset: 0x00041D40
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

	// Token: 0x06000A9D RID: 2717 RVA: 0x00043BB0 File Offset: 0x00041DB0
	private void OnGUI()
	{
		if (base.IsOnGUIEnabled)
		{
			GUI.skin = BlueStonez.Skin;
			GUI.depth = 9;
			this._mainRect = new Rect(0f, (float)GlobalUIRibbon.Instance.Height(), (float)Screen.width, (float)(Screen.height - GlobalUIRibbon.Instance.Height()));
			this.DrawGUI(this._mainRect);
		}
	}

	// Token: 0x06000A9E RID: 2718 RVA: 0x00043C18 File Offset: 0x00041E18
	public override void DrawGUI(Rect rect)
	{
		GUI.BeginGroup(rect, BlueStonez.window);
		if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
		{
			GUIUtility.keyboardControl = 0;
		}
		Rect rect2 = new Rect(0f, 21f, 150f, rect.height - 21f);
		Rect rect3 = new Rect(149f, 0f, rect.width - 150f, 22f);
		Rect rect4 = new Rect(150f, 22f, rect.width - 150f, rect.height - 22f - 36f - this._keyboardOffset);
		Rect rect5 = new Rect(149f, rect.height - 37f, rect.width - 150f + 1f, 37f);
		GUITools.PushGUIState();
		GUI.enabled &= !PopupMenu.IsEnabled;
		ChatGroupPanel pane = Singleton<ChatManager>.Instance._commPanes[3];
		this.DoDialogFooter(rect5, pane, Singleton<ChatManager>.Instance.InGameDialog);
		this.DrawCommPane(rect2, pane);
		this.DoDialogHeader(rect3, Singleton<ChatManager>.Instance.InGameDialog);
		this.DoDialog(rect4, pane, Singleton<ChatManager>.Instance.InGameDialog);
		GUITools.PopGUIState();
		if (PopupMenu.Current != null)
		{
			PopupMenu.Current.Draw();
		}
		GUI.EndGroup();
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000A9F RID: 2719 RVA: 0x0000866A File Offset: 0x0000686A
	private bool IsMobileChannel(ChannelType channel)
	{
		return channel == ChannelType.Android || channel == ChannelType.IPad || channel == ChannelType.IPhone;
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x00043D90 File Offset: 0x00041F90
	public void DrawCommPane(Rect rect, ChatGroupPanel pane)
	{
		GUI.BeginGroup(rect);
		pane.WindowHeight = rect.height;
		float height = Mathf.Max(pane.WindowHeight, pane.ContentHeight);
		float num = 0f;
		pane.Scroll = GUITools.BeginScrollView(new Rect(0f, 0f, rect.width, pane.WindowHeight), pane.Scroll, new Rect(0f, 0f, rect.width - 17f, height), false, true, true);
		GUI.BeginGroup(new Rect(0f, 0f, rect.width, pane.WindowHeight + pane.Scroll.y));
		int num2 = 0;
		string value = pane.SearchText.ToLower();
		GUI.BeginGroup(new Rect(0f, num, rect.width - 17f, (float)(GameState.Current.Players.Count * 24)));
		foreach (GameActorInfo gameActorInfo in GameState.Current.Players.Values)
		{
			if (string.IsNullOrEmpty(value) || gameActorInfo.PlayerName.ToLower().Contains(value))
			{
				this.GroupDrawUser((float)(num2++ * 24), rect.width - 17f, gameActorInfo, true);
			}
		}
		GUI.EndGroup();
		num += 24f + (float)(GameState.Current.Players.Count * 24);
		GUI.EndGroup();
		GUITools.EndScrollView();
		pane.ContentHeight = num;
		GUI.EndGroup();
	}

	// Token: 0x06000AA1 RID: 2721 RVA: 0x00043F50 File Offset: 0x00042150
	private void DoDialog(Rect rect, ChatGroupPanel pane, ChatDialog dialog)
	{
		if (dialog == null)
		{
			return;
		}
		if (dialog.CheckSize(rect) && !Input.GetMouseButton(0))
		{
			this._dialogScroll.y = float.MaxValue;
		}
		GUI.BeginGroup(new Rect(rect.x, rect.y + Mathf.Clamp(rect.height - dialog._heightCache, 0f, rect.height), rect.width, rect.height));
		int num = 0;
		float num2 = 0f;
		this._dialogScroll = GUITools.BeginScrollView(new Rect(0f, 0f, dialog._frameSize.x, dialog._frameSize.y), this._dialogScroll, new Rect(0f, 0f, dialog._contentSize.x, dialog._contentSize.y), false, false, true);
		foreach (InstantMessage instantMessage in dialog._msgQueue)
		{
			if (dialog.CanShow == null || dialog.CanShow(instantMessage.Context))
			{
				if (num % 2 == 0)
				{
					GUI.Label(new Rect(0f, num2, dialog._contentSize.x - 1f, instantMessage.Height), GUIContent.none, BlueStonez.box_grey38);
				}
				if (GUI.Button(new Rect(0f, num2, dialog._contentSize.x - 1f, instantMessage.Height), GUIContent.none, BlueStonez.dropdown_list))
				{
					this._selectedCmid = instantMessage.Cmid;
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
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x00008683 File Offset: 0x00006883
	private void DoDialogHeader(Rect rect, ChatDialog d)
	{
		GUI.Label(rect, GUIContent.none, BlueStonez.window_standard_grey38);
		GUI.Label(rect, d.Title, BlueStonez.label_interparkbold_11pt);
	}

	// Token: 0x06000AA3 RID: 2723 RVA: 0x0004429C File Offset: 0x0004249C
	private void DoDialogFooter(Rect rect, ChatGroupPanel pane, ChatDialog dialog)
	{
		GUI.BeginGroup(rect, BlueStonez.window_standard_grey38);
		bool enabled = GUI.enabled;
		GUI.enabled &= (!AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.IsPlayerMuted && dialog != null);
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
		else
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
			if (string.IsNullOrEmpty(this._currentChatMessage) && GUI.GetNameOfFocusedControl() != "@CurrentChatMessage")
			{
				GUI.color = new Color(1f, 1f, 1f, 0.3f);
				GUI.Label(new Rect(10f, 6f, rect.width - 66f, rect.height - 12f), text, BlueStonez.label_interparkmed_10pt_left);
				GUI.color = Color.white;
			}
		}
		if ((GUITools.Button(new Rect(rect.width - 51f, 6f, 45f, rect.height - 12f), new GUIContent(LocalizedStrings.Send), BlueStonez.buttondark_small) || Event.current.keyCode == KeyCode.Return) && !AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.IsPlayerMuted && this._lastMessageSentTimer > 0.29f)
		{
			this.SendChatMessage();
			GUI.FocusControl("@CurrentChatMessage");
		}
		GUI.enabled = enabled;
		GUI.EndGroup();
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x000089B6 File Offset: 0x00006BB6
	private Texture2D GetIcon(GameActorInfo info)
	{
		if (info.IsSpectator)
		{
			return CommunicatorIcons.PresenceOnline;
		}
		if (!info.IsAlive)
		{
			return CommunicatorIcons.SkullCrossbonesIcon;
		}
		return CommunicatorIcons.PresencePlaying;
	}

	// Token: 0x06000AA5 RID: 2725 RVA: 0x00044520 File Offset: 0x00042720
	private void GroupDrawUser(float vOffset, float width, GameActorInfo user, bool allowSelfSelection = false)
	{
		int cmid = PlayerDataManager.Cmid;
		Rect rect = new Rect(3f, vOffset, width - 3f, 24f);
		if (this._selectedCmid == user.Cmid)
		{
			GUI.color = new Color(ColorScheme.UberStrikeBlue.r, ColorScheme.UberStrikeBlue.g, ColorScheme.UberStrikeBlue.b, 0.5f);
			GUI.Label(rect, GUIContent.none, BlueStonez.box_white);
			GUI.color = Color.white;
		}
		bool enabled = GUI.enabled;
		GUI.Label(new Rect(10f, vOffset + 3f, 16f, 16f), this.GetIcon(user), GUIStyle.none);
		GUI.Label(new Rect(23f, vOffset + 3f, 16f, 16f), UberstrikeIconsHelper.GetIconForChannel(user.Channel), GUIStyle.none);
		TeamID teamID = user.TeamID;
		if (teamID != TeamID.BLUE)
		{
			if (teamID != TeamID.RED)
			{
				GUI.color = Color.white;
			}
			else
			{
				GUI.color = ColorScheme.GuiTeamRed;
			}
		}
		else
		{
			GUI.color = ColorScheme.GuiTeamBlue;
		}
		GUI.Label(new Rect(44f, vOffset, width - 66f, 24f), user.PlayerName, BlueStonez.label_interparkmed_10pt_left);
		GUI.color = Color.white;
		if (user.Cmid != cmid && GUI.Button(new Rect(rect.width - 17f, vOffset + 1f, 18f, 18f), GUIContent.none, BlueStonez.button_context))
		{
			this._selectedCmid = user.Cmid;
			this._playerMenu.Show(Event.current.mousePosition, new CommUser(user));
		}
		GUI.Box(rect.Expand(0, -1), GUIContent.none, BlueStonez.dropdown_list);
		if (MouseInput.IsMouseClickIn(rect, 0))
		{
			if (this._selectedCmid != user.Cmid && (allowSelfSelection || user.Cmid != cmid))
			{
				this._selectedCmid = user.Cmid;
			}
		}
		else if (MouseInput.IsMouseClickIn(rect, 1))
		{
			this._playerMenu.Show(Event.current.mousePosition, new CommUser(user));
		}
		GUI.enabled = enabled;
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x0004477C File Offset: 0x0004297C
	private void SendChatMessage()
	{
		if (string.IsNullOrEmpty(this._currentChatMessage))
		{
			return;
		}
		this._dialogScroll.y = float.MaxValue;
		this._currentChatMessage = TextUtilities.ShortenText(TextUtilities.Trim(this._currentChatMessage), 140, false);
		GameState.Current.SendChatMessage(this._currentChatMessage, ChatContext.Player);
		this._lastMessageSentTimer = 0f;
		this._currentChatMessage = string.Empty;
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x000447F0 File Offset: 0x000429F0
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
		else
		{
			result = ColorScheme.GetNameColorByAccessLevel(msg.AccessLevel);
		}
		return result;
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x00044848 File Offset: 0x00042A48
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

	// Token: 0x06000AA9 RID: 2729 RVA: 0x0004330C File Offset: 0x0004150C
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

	// Token: 0x06000AAA RID: 2730 RVA: 0x000433E4 File Offset: 0x000415E4
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

	// Token: 0x06000AAB RID: 2731 RVA: 0x000448A4 File Offset: 0x00042AA4
	private void MenuCmdReportPlayer(CommUser user)
	{
		if (user != null && Singleton<GameStateController>.Instance.Client.IsInsideRoom)
		{
			PopupSystem.ShowMessage(LocalizedStrings.ReportPlayerCaps, "Are you sure you want to report\n" + user.Name + "\nfor cheating?", PopupSystem.AlertType.OKCancel, delegate()
			{
				Singleton<GameStateController>.Instance.Client.Operations.SendReportPlayer(user.Cmid, PlayerDataManager.AuthToken);
			}, "Report", null, "Cancel", PopupSystem.ActionType.Negative);
		}
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x000089DF File Offset: 0x00006BDF
	private bool MenuChkReportPlayer(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && user.AccessLevel == MemberAccessLevel.Default;
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x00008A03 File Offset: 0x00006C03
	private bool MenuChkAddFriend(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && user.AccessLevel <= PlayerDataManager.AccessLevel && !PlayerDataManager.IsFriend(user.Cmid);
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x00008756 File Offset: 0x00006956
	private bool MenuChkRemoveFriend(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && PlayerDataManager.IsFriend(user.Cmid);
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x0004491C File Offset: 0x00042B1C
	private bool MenuChkInviteClan(CommUser user)
	{
		return user != null && user.Cmid != PlayerDataManager.Cmid && (user.AccessLevel <= PlayerDataManager.AccessLevel || PlayerDataManager.IsFriend(user.Cmid)) && PlayerDataManager.IsPlayerInClan && PlayerDataManager.CanInviteToClan && !PlayerDataManager.IsClanMember(user.Cmid);
	}

	// Token: 0x04000A4C RID: 2636
	private const float TitleHeight = 24f;

	// Token: 0x04000A4D RID: 2637
	private const int TAB_WIDTH = 150;

	// Token: 0x04000A4E RID: 2638
	private const int CHAT_USER_HEIGHT = 24;

	// Token: 0x04000A4F RID: 2639
	private Rect _mainRect;

	// Token: 0x04000A50 RID: 2640
	private Vector2 _dialogScroll;

	// Token: 0x04000A51 RID: 2641
	private float _spammingNotificationTime;

	// Token: 0x04000A52 RID: 2642
	private float _nextNaughtyListUpdate;

	// Token: 0x04000A53 RID: 2643
	private int _selectedCmid;

	// Token: 0x04000A54 RID: 2644
	private float _yPosition;

	// Token: 0x04000A55 RID: 2645
	private float _lastMessageSentTimer = 0.3f;

	// Token: 0x04000A56 RID: 2646
	private string _currentChatMessage = string.Empty;

	// Token: 0x04000A57 RID: 2647
	private PopupMenu _playerMenu;

	// Token: 0x04000A58 RID: 2648
	private float _keyboardOffset;
}
