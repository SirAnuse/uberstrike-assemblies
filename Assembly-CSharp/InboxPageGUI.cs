using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x0200019D RID: 413
public class InboxPageGUI : MonoBehaviour
{
	// Token: 0x06000B53 RID: 2899 RVA: 0x00008F56 File Offset: 0x00007156
	private void Start()
	{
		this._tabContents = new GUIContent[]
		{
			new GUIContent(LocalizedStrings.MessagesCaps),
			new GUIContent(LocalizedStrings.RequestsCaps)
		};
	}

	// Token: 0x06000B54 RID: 2900 RVA: 0x00047CE8 File Offset: 0x00045EE8
	private void OnGUI()
	{
		GUI.depth = 11;
		GUI.skin = BlueStonez.Skin;
		Rect position = new Rect(0f, (float)GlobalUIRibbon.Instance.Height(), (float)Screen.width, (float)(Screen.height - GlobalUIRibbon.Instance.Height()));
		this._threadWidth = (int)position.width / 4;
		GUI.BeginGroup(position, BlueStonez.window_standard_grey38);
		GUI.enabled = (PlayerDataManager.IsPlayerLoggedIn && this.IsNoPanelOpen());
		this.DrawInbox(new Rect(0f, 0f, position.width, position.height));
		GUI.enabled = true;
		GUI.EndGroup();
	}

	// Token: 0x06000B55 RID: 2901 RVA: 0x00047D98 File Offset: 0x00045F98
	private void DrawInbox(Rect rect)
	{
		this.DoTitle(new Rect(1f, 0f, rect.width - 2f, 72f));
		int selectedTab = this._selectedTab;
		if (selectedTab != 0)
		{
			if (selectedTab == 1)
			{
				float num = Mathf.Max(Singleton<InboxManager>.Instance.NextRequestRefresh - Time.time, 0f);
				GUITools.PushGUIState();
				GUI.enabled &= (num == 0f);
				if (GUITools.Button(new Rect(rect.width - 131f, 80f, 123f, 24f), new GUIContent(string.Format(LocalizedStrings.Refresh + " {0}", (num <= 0f) ? string.Empty : ("(" + num.ToString("N0") + ")"))), BlueStonez.buttondark_medium))
				{
					Singleton<InboxManager>.Instance.RefreshAllRequests();
				}
				GUITools.PopGUIState();
				this.DoRequests(new Rect(0f, 112f, rect.width, rect.height - 112f));
			}
		}
		else
		{
			this.DoToolbarMessage(new Rect(1f, 72f, rect.width - 2f, 40f));
			this.DoThreads(new Rect(1f, 112f, (float)this._threadWidth, rect.height - 112f));
			this.DoMessages(new Rect((float)this._threadWidth, 110f, rect.width - (float)this._threadWidth, rect.height - 112f));
		}
	}

	// Token: 0x06000B56 RID: 2902 RVA: 0x00047F58 File Offset: 0x00046158
	private void DoTitle(Rect rect)
	{
		GUI.BeginGroup(rect, BlueStonez.tab_strip_large);
		int num = UnityGUI.Toolbar(new Rect(1f, 32f, 508f, 40f), this._selectedTab, this._tabContents, this._tabContents.Length, BlueStonez.tab_large);
		if (GUI.changed)
		{
			GUI.changed = false;
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.ButtonClick, 0UL, 1f, 1f);
		}
		if (num != this._selectedTab)
		{
			GUIUtility.keyboardControl = 0;
			this._selectedTab = num;
		}
		if (Singleton<InboxManager>.Instance.UnreadMessageCount > 0)
		{
			GUI.DrawTexture(new Rect(133f, 32f, 20f, 20f), this._newMessage);
		}
		if (Singleton<InboxManager>.Instance.IncomingClanRequests.Value.Count > 0 || Singleton<InboxManager>.Instance.FriendRequests.Value.Count > 0)
		{
			GUI.DrawTexture(new Rect(311f, 32f, 20f, 20f), this._newMessage);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000B57 RID: 2903 RVA: 0x00048084 File Offset: 0x00046284
	private void DoToolbarMessage(Rect rect)
	{
		GUI.BeginGroup(rect);
		GUI.Label(new Rect(8f, 8f, 206f, 24f), string.Format(LocalizedStrings.YouHaveNNewMessages, Singleton<InboxManager>.Instance.UnreadMessageCount), BlueStonez.label_interparkbold_16pt_left);
		if (this._selectedTab == 0)
		{
			Rect position = new Rect(rect.width - 368f, 8f, 140f, 24f);
			GUI.SetNextControlName("SearchMessage");
			this._searchMessage = GUI.TextField(position, this._searchMessage, BlueStonez.textField);
			if (string.IsNullOrEmpty(this._searchMessage) && GUI.GetNameOfFocusedControl() != "SearchMessage")
			{
				GUI.color = new Color(1f, 1f, 1f, 0.3f);
				GUI.Label(position, " " + LocalizedStrings.SearchMessages, BlueStonez.label_interparkbold_11pt_left);
				GUI.color = Color.white;
			}
		}
		if (GUITools.Button(new Rect(rect.width - 224f, 8f, 106f, 24f), new GUIContent(LocalizedStrings.NewMessage), BlueStonez.buttondark_medium))
		{
			PanelManager.Instance.OpenPanel(PanelType.SendMessage);
		}
		float num = Mathf.Max(Singleton<InboxManager>.Instance.NextInboxRefresh - Time.time, 0f);
		GUITools.PushGUIState();
		GUI.enabled &= (num == 0f);
		if (GUITools.Button(new Rect(rect.width - 114f, 8f, 106f, 24f), new GUIContent(string.Format(LocalizedStrings.CheckMail + " {0}", (num <= 0f) ? string.Empty : ("(" + num.ToString("N0") + ")"))), BlueStonez.buttondark_medium))
		{
			Singleton<InboxManager>.Instance.LoadNextPageThreads();
		}
		GUITools.PopGUIState();
		GUI.EndGroup();
	}

	// Token: 0x06000B58 RID: 2904 RVA: 0x00008F7E File Offset: 0x0000717E
	private bool IsNoPanelOpen()
	{
		return !PanelManager.IsAnyPanelOpen;
	}

	// Token: 0x06000B59 RID: 2905 RVA: 0x0004828C File Offset: 0x0004648C
	private void DoThreads(Rect rect)
	{
		rect = new Rect(rect.x + 8f, rect.y, rect.width - 8f, rect.height - 8f);
		GUI.Box(rect, GUIContent.none, BlueStonez.window);
		if (Singleton<InboxManager>.Instance.ThreadCount > 0)
		{
			Vector2 threadScroll = GUITools.BeginScrollView(rect, this._threadScroll, new Rect(0f, 0f, (float)this._threadViewWidth, (float)this._threadViewHeight), false, false, true);
			bool flag = threadScroll.y > this._threadScroll.y;
			this._threadScroll = threadScroll;
			int num = 0;
			for (int i = 0; i < Singleton<InboxManager>.Instance.ThreadCount; i++)
			{
				InboxThread inboxThread = Singleton<InboxManager>.Instance.AllThreads[i];
				if (string.IsNullOrEmpty(this._searchMessage) || inboxThread.Contains(this._searchMessage))
				{
					num = inboxThread.DrawThread(num, this._threadViewWidth);
					GUI.Label(new Rect(4f, (float)num, (float)this._threadViewWidth, 1f), GUIContent.none, BlueStonez.horizontal_line_grey95);
				}
			}
			if (Singleton<InboxManager>.Instance.IsLoadingThreads)
			{
				GUI.Label(new Rect(0f, (float)num, rect.width, 30f), "Loading threads...", BlueStonez.label_interparkmed_11pt);
				num += 30;
			}
			else
			{
				if (Singleton<InboxManager>.Instance.IsNoMoreThreads)
				{
					GUI.contentColor = Color.gray;
					GUI.Label(new Rect(0f, (float)num, rect.width, 30f), "No more threads", BlueStonez.label_interparkmed_11pt);
					GUI.contentColor = Color.white;
				}
				num += 30;
				float num2 = Mathf.Max((float)num - rect.height, 0f);
				if (flag && this._threadScroll.y >= num2)
				{
					Singleton<InboxManager>.Instance.LoadNextPageThreads();
				}
			}
			this._threadViewHeight = num;
			this._threadViewWidth = (int)(((float)this._threadViewHeight <= rect.height) ? (rect.width - 8f) : (rect.width - 22f));
			GUITools.EndScrollView();
		}
		else if (Singleton<InboxManager>.Instance.IsLoadingThreads)
		{
			GUI.Label(rect, "Loading threads...", BlueStonez.label_interparkbold_13pt);
		}
		else
		{
			GUI.Label(rect, LocalizedStrings.Empty, BlueStonez.label_interparkmed_11pt);
		}
	}

	// Token: 0x06000B5A RID: 2906 RVA: 0x00048508 File Offset: 0x00046708
	private void DoMessages(Rect rect)
	{
		InboxThread inboxThread = InboxThread.Current;
		bool flag = inboxThread != null && inboxThread.IsAdmin;
		Rect position = new Rect(rect.x + 8f, rect.y + 2f, rect.width - 16f, rect.height - 8f);
		GUI.Box(position, GUIContent.none, BlueStonez.box_grey50);
		string text = LocalizedStrings.NoConversationSelected;
		if (inboxThread != null)
		{
			text = string.Format(LocalizedStrings.BetweenYouAndN, inboxThread.Name);
			if (GUI.Button(new Rect(position.x + 10f, position.y + 10f, 150f, 20f), "Delete Conversation", BlueStonez.buttondark_medium))
			{
				InboxThread.Current = null;
				Singleton<InboxManager>.Instance.DeleteThread(inboxThread.ThreadId);
			}
		}
		GUI.contentColor = new Color(1f, 1f, 1f, 0.75f);
		GUI.Label(new Rect(position.x + 10f, position.y, position.width - 20f, 40f), text, BlueStonez.label_interparkmed_11pt_right);
		GUI.contentColor = Color.white;
		GUI.Label(new Rect(position.x + 4f, position.y + 40f, position.width - 8f, 1f), GUIContent.none, BlueStonez.horizontal_line_grey95);
		int num = 8;
		Rect position2 = new Rect(position.x + 8f, position.y + 48f, position.width - 8f, position.height - (float)((!flag) ? 90 : 49));
		if (InboxThread.Current != null)
		{
			inboxThread.Scroll = GUITools.BeginScrollView(position2, inboxThread.Scroll, new Rect(0f, 0f, (float)this._messageViewWidth, (float)this._messageViewHeight), false, false, true);
			num = inboxThread.DrawMessageList(num, this._messageViewWidth, position2.height, inboxThread.Scroll.y);
			if ((float)num > position2.height)
			{
				this._messageViewHeight = num;
				this._messageViewWidth = (int)(position2.width - 22f);
			}
			else
			{
				this._messageViewHeight = (int)position2.height;
				this._messageViewWidth = (int)position2.width - 8;
			}
			GUITools.EndScrollView();
		}
		else
		{
			GUI.Label(position2, "Select a message thread", BlueStonez.label_interparkbold_13pt);
		}
		if (!flag)
		{
			GUITools.PushGUIState();
			GUI.enabled &= (InboxThread.Current != null);
			GUI.Box(new Rect(rect.x + 8f, rect.y + rect.height - 51f, rect.width - 16f, 45f), GUIContent.none, BlueStonez.window_standard_grey38);
			this.DoReply(new Rect(rect.x, rect.y + rect.height - 51f, rect.width, 45f));
			GUITools.PopGUIState();
		}
	}

	// Token: 0x06000B5B RID: 2907 RVA: 0x00048838 File Offset: 0x00046A38
	private void DoReply(Rect rect)
	{
		Rect position = new Rect(rect.x + (rect.width - 420f) / 2f, rect.y + 12f, 420f, rect.height);
		GUI.BeginGroup(position);
		GUI.SetNextControlName("Reply Edit");
		this._replyMessage = GUI.TextField(new Rect(0f, 0f, position.width - 64f, 24f), this._replyMessage, 140, BlueStonez.textField);
		this._replyMessage = this._replyMessage.Trim(new char[]
		{
			'\n'
		});
		if (GUI.GetNameOfFocusedControl().Equals("Reply Edit") && !string.IsNullOrEmpty(this._replyMessage) && Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return)
		{
			this.SendMessage();
		}
		GUITools.PushGUIState();
		GUI.enabled &= !string.IsNullOrEmpty(this._replyMessage);
		if (GUITools.Button(new Rect(position.width - 64f, 0f, 64f, 24f), new GUIContent(LocalizedStrings.Reply), BlueStonez.buttondark_medium))
		{
			this.SendMessage();
		}
		GUITools.PopGUIState();
		GUI.EndGroup();
	}

	// Token: 0x06000B5C RID: 2908 RVA: 0x0004899C File Offset: 0x00046B9C
	private void SendMessage()
	{
		if (InboxThread.Current != null)
		{
			Singleton<InboxManager>.Instance.SendPrivateMessage(InboxThread.Current.ThreadId, InboxThread.Current.Name, this._replyMessage);
			this._replyMessage = string.Empty;
			GUIUtility.keyboardControl = 0;
		}
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x000489E8 File Offset: 0x00046BE8
	private void DoRequests(Rect rect)
	{
		Rect position = new Rect(rect.x + 8f, rect.y, rect.width - 16f, rect.height - 8f);
		GUI.BeginGroup(position, BlueStonez.window);
		int num = 5;
		this._requestHeight = 180 + Singleton<InboxManager>.Instance.FriendRequests.Value.Count * 60 + Singleton<InboxManager>.Instance.IncomingClanRequests.Value.Count * 60 + Singleton<InboxManager>.Instance._outgoingClanRequests.Count * 60;
		this._requestWidth = (int)position.width - (((float)this._requestHeight <= position.height) ? 8 : 22);
		this._requestScroll = GUITools.BeginScrollView(new Rect(0f, (float)num, position.width, position.height), this._requestScroll, new Rect(0f, 0f, (float)this._requestWidth, (float)this._requestHeight), false, false, true);
		GUI.Box(new Rect(4f, 0f, (float)this._requestWidth, 50f), GUIContent.none, BlueStonez.box_grey38);
		GUI.Label(new Rect(14f, 0f, (float)(this._requestWidth - 10), 50f), string.Format(LocalizedStrings.FriendRequestsYouHaveNPendingRequests, Singleton<InboxManager>.Instance.FriendRequests.Value.Count.ToString(), (Singleton<InboxManager>.Instance.FriendRequests.Value.Count == 1) ? string.Empty : "s"), BlueStonez.label_interparkmed_18pt_left);
		num += 50;
		for (int i = 0; i < Singleton<InboxManager>.Instance.FriendRequests.Value.Count; i++)
		{
			this.DrawFriendRequestView(Singleton<InboxManager>.Instance.FriendRequests.Value[i], (float)num, this._requestWidth);
			GUI.Label(new Rect(25f, (float)(num + Mathf.RoundToInt(9f)), 32f, 32f), (i + 1).ToString(), BlueStonez.label_interparkbold_32pt);
			num += 60;
		}
		GUI.Box(new Rect(4f, (float)num, (float)this._requestWidth, 50f), GUIContent.none, BlueStonez.box_grey38);
		GUI.Label(new Rect(14f, (float)num, (float)(this._requestWidth - 10), 50f), string.Format("Clan Requests - You have {0} incoming invite{1}", Singleton<InboxManager>.Instance.IncomingClanRequests.Value.Count, (Singleton<InboxManager>.Instance.IncomingClanRequests.Value.Count == 1) ? string.Empty : "s"), BlueStonez.label_interparkmed_18pt_left);
		num += 55;
		for (int j = 0; j < Singleton<InboxManager>.Instance.IncomingClanRequests.Value.Count; j++)
		{
			this.DrawIncomingClanInvitation(Singleton<InboxManager>.Instance.IncomingClanRequests.Value[j], num, this._requestWidth);
			GUI.Label(new Rect(25f, (float)(num + Mathf.RoundToInt(9f)), 32f, 32f), (j + 1).ToString(), BlueStonez.label_interparkbold_32pt);
			num += 60;
		}
		GUI.Box(new Rect(4f, (float)num, (float)this._requestWidth, 50f), GUIContent.none, BlueStonez.box_grey38);
		GUI.Label(new Rect(14f, (float)num, (float)(this._requestWidth - 10), 50f), string.Format("Clan Requests - You have {0} outgoing invite{1}", Singleton<InboxManager>.Instance._outgoingClanRequests.Count, (Singleton<InboxManager>.Instance._outgoingClanRequests.Count == 1) ? string.Empty : "s"), BlueStonez.label_interparkmed_18pt_left);
		num += 55;
		for (int k = 0; k < Singleton<InboxManager>.Instance._outgoingClanRequests.Count; k++)
		{
			this.DrawOutgoingClanInvitation(Singleton<InboxManager>.Instance._outgoingClanRequests[k], num, this._requestWidth);
			GUI.Label(new Rect(25f, (float)(num + Mathf.RoundToInt(9f)), 32f, 32f), (k + 1).ToString(), BlueStonez.label_interparkbold_32pt);
			num += 60;
		}
		GUITools.EndScrollView();
		GUI.EndGroup();
	}

	// Token: 0x06000B5E RID: 2910 RVA: 0x00048E64 File Offset: 0x00047064
	public void DrawFriendRequestView(ContactRequestView request, float y, int width)
	{
		Rect position = new Rect(4f, y + 4f, (float)(width - 1), 50f);
		GUI.BeginGroup(position);
		Rect position2 = new Rect(0f, 0f, position.width, position.height - 1f);
		if (GUI.enabled && position2.Contains(Event.current.mousePosition))
		{
			GUI.Box(position2, GUIContent.none, BlueStonez.box_grey50);
		}
		GUI.Label(new Rect(80f, 5f, position.width - 250f, 20f), string.Format("{0}: {1}", LocalizedStrings.FriendRequest, request.InitiatorName), BlueStonez.label_interparkbold_13pt_left);
		GUI.Label(new Rect(80f, 30f, position.width - 250f, 20f), "> " + request.InitiatorMessage, BlueStonez.label_interparkmed_11pt_left);
		if (GUITools.Button(new Rect(position.width - 120f - 18f, 5f, 60f, 20f), new GUIContent(LocalizedStrings.Accept), BlueStonez.buttondark_medium))
		{
			Singleton<InboxManager>.Instance.AcceptContactRequest(request.RequestId);
		}
		if (GUITools.Button(new Rect(position.width - 50f - 18f, 5f, 60f, 20f), new GUIContent(LocalizedStrings.Ignore), BlueStonez.buttondark_medium))
		{
			Singleton<InboxManager>.Instance.DeclineContactRequest(request.RequestId);
		}
		GUI.EndGroup();
		GUI.Label(new Rect(4f, y + 50f + 8f, (float)width, 1f), GUIContent.none, BlueStonez.horizontal_line_grey95);
	}

	// Token: 0x06000B5F RID: 2911 RVA: 0x00049038 File Offset: 0x00047238
	private void DrawIncomingClanInvitation(GroupInvitationView view, int y, int width)
	{
		Rect position = new Rect(4f, (float)(y + 4), (float)(width - 1), 50f);
		GUI.BeginGroup(position);
		Rect position2 = new Rect(0f, 0f, position.width, position.height - 1f);
		if (GUI.enabled && position2.Contains(Event.current.mousePosition))
		{
			GUI.Box(position2, GUIContent.none, BlueStonez.box_grey50);
		}
		GUI.Label(new Rect(80f, 5f, position.width - 250f, 20f), string.Format("{0}: {1}", LocalizedStrings.ClanInvite, view.GroupName), BlueStonez.label_interparkbold_13pt_left);
		GUI.Label(new Rect(80f, 30f, position.width - 250f, 20f), "> " + view.Message, BlueStonez.label_interparkmed_11pt_left);
		if (GUITools.Button(new Rect(position.width - 120f - 18f, 5f, 60f, 20f), new GUIContent(LocalizedStrings.Accept), BlueStonez.buttondark_medium))
		{
			if (PlayerDataManager.IsPlayerInClan)
			{
				PopupSystem.ShowMessage(LocalizedStrings.Error, LocalizedStrings.YouAlreadyInClanMsg, PopupSystem.AlertType.OK);
			}
			else
			{
				int requestId = view.GroupInvitationId;
				PopupSystem.ShowMessage(LocalizedStrings.Accept, "Do you want to accept this clan invitation?", PopupSystem.AlertType.OKCancel, delegate()
				{
					Singleton<InboxManager>.Instance.AcceptClanRequest(requestId);
				}, "Join", null, LocalizedStrings.Cancel, PopupSystem.ActionType.Positive);
			}
		}
		if (GUITools.Button(new Rect(position.width - 50f - 18f, 5f, 60f, 20f), new GUIContent(LocalizedStrings.Ignore), BlueStonez.buttondark_medium))
		{
			Singleton<InboxManager>.Instance.DeclineClanRequest(view.GroupInvitationId);
		}
		GUI.EndGroup();
		GUI.Label(new Rect(4f, (float)(y + 50 + 8), (float)width, 1f), GUIContent.none, BlueStonez.horizontal_line_grey95);
	}

	// Token: 0x06000B60 RID: 2912 RVA: 0x0004924C File Offset: 0x0004744C
	private void DrawOutgoingClanInvitation(GroupInvitationView view, int y, int width)
	{
		Rect position = new Rect(4f, (float)(y + 4), (float)(width - 1), 50f);
		GUI.BeginGroup(position);
		Rect position2 = new Rect(0f, 0f, position.width, position.height - 1f);
		if (GUI.enabled && position2.Contains(Event.current.mousePosition))
		{
			GUI.Box(position2, GUIContent.none, BlueStonez.box_grey50);
		}
		GUI.Label(new Rect(80f, 5f, position.width - 250f, 20f), string.Format("You invited: {0}", view.InviteeName), BlueStonez.label_interparkbold_13pt_left);
		GUI.Label(new Rect(80f, 30f, position.width - 250f, 20f), "> " + view.Message, BlueStonez.label_interparkmed_11pt_left);
		if (GUITools.Button(new Rect(position.width - 140f, 5f, 120f, 20f), new GUIContent(LocalizedStrings.CancelInvite), BlueStonez.buttondark_medium))
		{
			int groupInvitationId = view.GroupInvitationId;
			if (Singleton<InboxManager>.Instance._outgoingClanRequests.Remove(view))
			{
				ClanWebServiceClient.CancelInvitation(groupInvitationId, PlayerDataManager.AuthToken, null, delegate(Exception ex)
				{
				});
			}
		}
		GUI.EndGroup();
		GUI.Label(new Rect(4f, (float)(y + 50 + 8), (float)width, 1f), GUIContent.none, BlueStonez.horizontal_line_grey95);
	}

	// Token: 0x04000AB7 RID: 2743
	private const int PanelHeight = 50;

	// Token: 0x04000AB8 RID: 2744
	private const int TAB_MESSAGE = 0;

	// Token: 0x04000AB9 RID: 2745
	private const int TAB_REQUEST = 1;

	// Token: 0x04000ABA RID: 2746
	[SerializeField]
	private Texture2D _newMessage;

	// Token: 0x04000ABB RID: 2747
	private int _threadWidth;

	// Token: 0x04000ABC RID: 2748
	private int _selectedTab;

	// Token: 0x04000ABD RID: 2749
	private GUIContent[] _tabContents;

	// Token: 0x04000ABE RID: 2750
	private int _threadViewWidth;

	// Token: 0x04000ABF RID: 2751
	private int _threadViewHeight;

	// Token: 0x04000AC0 RID: 2752
	private Vector2 _threadScroll;

	// Token: 0x04000AC1 RID: 2753
	private Vector2 _requestScroll;

	// Token: 0x04000AC2 RID: 2754
	private int _messageViewWidth;

	// Token: 0x04000AC3 RID: 2755
	private int _messageViewHeight;

	// Token: 0x04000AC4 RID: 2756
	private string _replyMessage = string.Empty;

	// Token: 0x04000AC5 RID: 2757
	private string _searchMessage = string.Empty;

	// Token: 0x04000AC6 RID: 2758
	private int _requestWidth;

	// Token: 0x04000AC7 RID: 2759
	private int _requestHeight;
}
