using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Realtime.UnitySdk;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x02000192 RID: 402
public class InboxManager : Singleton<InboxManager>
{
	// Token: 0x06000AFC RID: 2812 RVA: 0x0004716C File Offset: 0x0004536C
	private InboxManager()
	{
	}

	// Token: 0x170002EF RID: 751
	// (get) Token: 0x06000AFD RID: 2813 RVA: 0x00008CE0 File Offset: 0x00006EE0
	// (set) Token: 0x06000AFE RID: 2814 RVA: 0x00008CE8 File Offset: 0x00006EE8
	public bool IsInitialized { get; private set; }

	// Token: 0x170002F0 RID: 752
	// (get) Token: 0x06000AFF RID: 2815 RVA: 0x00008CF1 File Offset: 0x00006EF1
	public IList<InboxThread> AllThreads
	{
		get
		{
			return this._sortedAllThreads;
		}
	}

	// Token: 0x170002F1 RID: 753
	// (get) Token: 0x06000B00 RID: 2816 RVA: 0x00008CF9 File Offset: 0x00006EF9
	public int ThreadCount
	{
		get
		{
			return this._sortedAllThreads.Count;
		}
	}

	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x06000B01 RID: 2817 RVA: 0x00008D06 File Offset: 0x00006F06
	// (set) Token: 0x06000B02 RID: 2818 RVA: 0x00008D0E File Offset: 0x00006F0E
	public bool IsLoadingThreads { get; private set; }

	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x06000B03 RID: 2819 RVA: 0x00008D17 File Offset: 0x00006F17
	// (set) Token: 0x06000B04 RID: 2820 RVA: 0x00008D1F File Offset: 0x00006F1F
	public bool IsNoMoreThreads { get; private set; }

	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x06000B05 RID: 2821 RVA: 0x00008D28 File Offset: 0x00006F28
	// (set) Token: 0x06000B06 RID: 2822 RVA: 0x00008D30 File Offset: 0x00006F30
	public float NextInboxRefresh { get; private set; }

	// Token: 0x170002F5 RID: 757
	// (get) Token: 0x06000B07 RID: 2823 RVA: 0x00008D39 File Offset: 0x00006F39
	// (set) Token: 0x06000B08 RID: 2824 RVA: 0x00008D41 File Offset: 0x00006F41
	public float NextRequestRefresh { get; private set; }

	// Token: 0x06000B09 RID: 2825 RVA: 0x00008D4A File Offset: 0x00006F4A
	public void Initialize()
	{
		if (!this.IsInitialized)
		{
			this.IsInitialized = true;
			this.LoadNextPageThreads();
			this.RefreshAllRequests();
		}
	}

	// Token: 0x06000B0A RID: 2826 RVA: 0x000471CC File Offset: 0x000453CC
	public void SendPrivateMessage(int cmidId, string name, string rawMessage)
	{
		string text = TextUtilities.ShortenText(TextUtilities.Trim(rawMessage), 140, false);
		if (!string.IsNullOrEmpty(text))
		{
			if (!this._allThreads.ContainsKey(cmidId))
			{
				InboxThread inboxThread = new InboxThread(new MessageThreadView
				{
					HasNewMessages = false,
					ThreadName = name,
					LastMessagePreview = string.Empty,
					ThreadId = cmidId,
					LastUpdate = DateTime.Now,
					MessageCount = 0
				});
				this._allThreads.Add(inboxThread.ThreadId, inboxThread);
				this._sortedAllThreads.Add(inboxThread);
			}
			PrivateMessageWebServiceClient.SendMessage(PlayerDataManager.AuthToken, cmidId, text, delegate(PrivateMessageView pm)
			{
				this.OnPrivateMessageSent(cmidId, pm);
			}, delegate(Exception ex)
			{
			});
		}
	}

	// Token: 0x06000B0B RID: 2827 RVA: 0x000472C4 File Offset: 0x000454C4
	public void UpdateNewMessageCount()
	{
		this._sortedAllThreads.Sort((InboxThread t1, InboxThread t2) => t2.LastMessageDateTime.CompareTo(t1.LastMessageDateTime));
		this.UnreadMessageCount.Value = this._sortedAllThreads.Reduce((InboxThread el, int acc) => (!el.HasUnreadMessage) ? acc : (acc + 1), 0);
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x00047330 File Offset: 0x00045530
	public void RemoveFriend(int friendCmid)
	{
		Singleton<PlayerDataManager>.Instance.RemoveFriend(friendCmid);
		RelationshipWebServiceClient.DeleteContact(PlayerDataManager.AuthToken, friendCmid, delegate(MemberOperationResult ev)
		{
			if (ev == MemberOperationResult.Ok)
			{
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdateFriendsList(friendCmid);
				Singleton<CommsManager>.Instance.UpdateCommunicator();
			}
			else
			{
				Debug.LogError("DeleteContact failed with: " + ev);
			}
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x06000B0D RID: 2829 RVA: 0x00047394 File Offset: 0x00045594
	public void AcceptContactRequest(int requestId)
	{
		this.FriendRequests.Value.RemoveAll((ContactRequestView r) => r.RequestId == requestId);
		this.FriendRequests.Fire();
		RelationshipWebServiceClient.AcceptContactRequest(PlayerDataManager.AuthToken, requestId, delegate(PublicProfileView view)
		{
			if (view != null)
			{
				Singleton<PlayerDataManager>.Instance.AddFriend(view);
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdateFriendsList(view.Cmid);
				Singleton<CommsManager>.Instance.UpdateCommunicator();
			}
			else
			{
				PopupSystem.ShowMessage(LocalizedStrings.Clan, "Failed accepting friend request", PopupSystem.AlertType.OK);
			}
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x06000B0E RID: 2830 RVA: 0x00047424 File Offset: 0x00045624
	public void DeclineContactRequest(int requestId)
	{
		this.FriendRequests.Value.RemoveAll((ContactRequestView r) => r.RequestId == requestId);
		this.FriendRequests.Fire();
		RelationshipWebServiceClient.DeclineContactRequest(PlayerDataManager.AuthToken, requestId, delegate(bool ev)
		{
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x06000B0F RID: 2831 RVA: 0x000474B4 File Offset: 0x000456B4
	public void AcceptClanRequest(int clanInvitationId)
	{
		this.IncomingClanRequests.Value.RemoveAll((GroupInvitationView r) => r.GroupInvitationId == clanInvitationId);
		this.IncomingClanRequests.Fire();
		ClanWebServiceClient.AcceptClanInvitation(clanInvitationId, PlayerDataManager.AuthToken, delegate(ClanRequestAcceptView ev)
		{
			if (ev != null && ev.ActionResult == 0)
			{
				PopupSystem.ShowMessage(LocalizedStrings.Clan, LocalizedStrings.JoinClanSuccessMsg, PopupSystem.AlertType.OKCancel, delegate()
				{
					MenuPageManager.Instance.LoadPage(PageType.Clans, false);
				}, "Go to Clans", null, "Not now", PopupSystem.ActionType.Positive);
				Singleton<ClanDataManager>.Instance.SetClanData(ev.ClanView);
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.SendUpdateClanMembers();
			}
			else
			{
				PopupSystem.ShowMessage(LocalizedStrings.Clan, LocalizedStrings.JoinClanErrorMsg, PopupSystem.AlertType.OK);
			}
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x06000B10 RID: 2832 RVA: 0x00047544 File Offset: 0x00045744
	public void DeclineClanRequest(int requestId)
	{
		this.IncomingClanRequests.Value.RemoveAll((GroupInvitationView r) => r.GroupInvitationId == requestId);
		this.IncomingClanRequests.Fire();
		ClanWebServiceClient.DeclineClanInvitation(requestId, PlayerDataManager.AuthToken, delegate(ClanRequestDeclineView ev)
		{
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x06000B11 RID: 2833 RVA: 0x000475D4 File Offset: 0x000457D4
	internal void LoadNextPageThreads()
	{
		if (!this.IsNoMoreThreads || this.NextInboxRefresh - Time.time < 0f)
		{
			this.IsLoadingThreads = true;
			this.NextInboxRefresh = Time.time + 30f;
			PrivateMessageWebServiceClient.GetAllMessageThreadsForUser(PlayerDataManager.AuthToken, this._curThreadsPageIndex, new Action<List<MessageThreadView>>(this.OnFinishLoadingNextPageThreads), delegate(Exception ex)
			{
			});
		}
	}

	// Token: 0x06000B12 RID: 2834 RVA: 0x00008D6A File Offset: 0x00006F6A
	private void OnFinishLoadingNextPageThreads(List<MessageThreadView> listView)
	{
		this.IsLoadingThreads = false;
		if (listView.Count > 0)
		{
			this._curThreadsPageIndex++;
			this.OnGetThreads(listView);
			this.IsNoMoreThreads = false;
		}
		else
		{
			this.IsNoMoreThreads = true;
		}
	}

	// Token: 0x06000B13 RID: 2835 RVA: 0x00047654 File Offset: 0x00045854
	internal void LoadMessagesForThread(InboxThread inboxThread, int pageIndex)
	{
		inboxThread.IsLoading = true;
		PrivateMessageWebServiceClient.GetThreadMessages(PlayerDataManager.AuthToken, inboxThread.ThreadId, pageIndex, delegate(List<PrivateMessageView> list)
		{
			inboxThread.IsLoading = false;
			this.OnGetMessages(inboxThread.ThreadId, list);
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x06000B14 RID: 2836 RVA: 0x000476C4 File Offset: 0x000458C4
	private void OnGetThreads(List<MessageThreadView> threadView)
	{
		foreach (MessageThreadView messageThreadView in threadView)
		{
			InboxThread inboxThread;
			if (this._allThreads.TryGetValue(messageThreadView.ThreadId, out inboxThread))
			{
				inboxThread.UpdateThread(messageThreadView);
			}
			else
			{
				inboxThread = new InboxThread(messageThreadView);
				this._allThreads.Add(inboxThread.ThreadId, inboxThread);
				this._sortedAllThreads.Add(inboxThread);
			}
		}
		this.UpdateNewMessageCount();
	}

	// Token: 0x06000B15 RID: 2837 RVA: 0x00047764 File Offset: 0x00045964
	private void OnGetMessages(int threadId, List<PrivateMessageView> messages)
	{
		InboxThread inboxThread;
		if (this._allThreads.TryGetValue(threadId, out inboxThread))
		{
			inboxThread.AddMessages(messages);
		}
		else
		{
			Debug.LogError("Getting messages of non existing thread " + threadId);
		}
	}

	// Token: 0x06000B16 RID: 2838 RVA: 0x000477A8 File Offset: 0x000459A8
	private void OnPrivateMessageSent(int threadId, PrivateMessageView privateMessage)
	{
		if (privateMessage != null)
		{
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdateInboxMessages(privateMessage.ToCmid, privateMessage.PrivateMessageId);
			privateMessage.IsRead = true;
			this.AddMessageToThread(threadId, privateMessage);
		}
		else
		{
			Debug.LogError("PrivateMessage sending failed");
			PopupSystem.ShowMessage(LocalizedStrings.Error, LocalizedStrings.YourMessageHasNotBeenSent);
		}
	}

	// Token: 0x06000B17 RID: 2839 RVA: 0x00008DA7 File Offset: 0x00006FA7
	private void AddMessage(PrivateMessageView privateMessage)
	{
		if (privateMessage != null)
		{
			this.AddMessageToThread(privateMessage.FromCmid, privateMessage);
		}
		else
		{
			Debug.LogError("AddMessage called with NULL message");
		}
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x00047810 File Offset: 0x00045A10
	private void AddMessageToThread(int threadId, PrivateMessageView privateMessage)
	{
		InboxThread inboxThread;
		if (!this._allThreads.TryGetValue(threadId, out inboxThread))
		{
			inboxThread = new InboxThread(new MessageThreadView
			{
				ThreadName = privateMessage.FromName,
				ThreadId = threadId
			});
			this._allThreads.Add(inboxThread.ThreadId, inboxThread);
			this._sortedAllThreads.Add(inboxThread);
		}
		inboxThread.AddMessage(privateMessage);
		this.UpdateNewMessageCount();
	}

	// Token: 0x06000B19 RID: 2841 RVA: 0x0004787C File Offset: 0x00045A7C
	internal void MarkThreadAsRead(int threadId)
	{
		PrivateMessageWebServiceClient.MarkThreadAsRead(PlayerDataManager.AuthToken, threadId, delegate
		{
		}, delegate(Exception ex)
		{
		});
		this.UpdateNewMessageCount();
	}

	// Token: 0x06000B1A RID: 2842 RVA: 0x000478D8 File Offset: 0x00045AD8
	internal void DeleteThread(int threadId)
	{
		PrivateMessageWebServiceClient.DeleteThread(PlayerDataManager.AuthToken, threadId, delegate
		{
			this.OnDeleteThread(threadId);
		}, delegate(Exception ex)
		{
		});
	}

	// Token: 0x06000B1B RID: 2843 RVA: 0x00047934 File Offset: 0x00045B34
	private void OnDeleteThread(int threadId)
	{
		this._allThreads.Remove(threadId);
		this._sortedAllThreads.RemoveAll((InboxThread t) => t.ThreadId == threadId);
		this.UpdateNewMessageCount();
	}

	// Token: 0x06000B1C RID: 2844 RVA: 0x00008DCB File Offset: 0x00006FCB
	internal void GetMessageWithId(int messageId)
	{
		PrivateMessageWebServiceClient.GetMessageWithIdForCmid(PlayerDataManager.AuthToken, messageId, new Action<PrivateMessageView>(this.AddMessage), delegate(Exception ex)
		{
		});
	}

	// Token: 0x06000B1D RID: 2845 RVA: 0x00047980 File Offset: 0x00045B80
	internal void RefreshAllRequests()
	{
		this.NextRequestRefresh = Time.time + 30f;
		RelationshipWebServiceClient.GetContactRequests(PlayerDataManager.AuthToken, new Action<List<ContactRequestView>>(this.OnGetContactRequests), delegate(Exception ex)
		{
		});
		ClanWebServiceClient.GetAllGroupInvitations(PlayerDataManager.AuthToken, new Action<List<GroupInvitationView>>(this.OnGetAllGroupInvitations), delegate(Exception ex)
		{
		});
		if (Singleton<PlayerDataManager>.Instance.RankInClan != GroupPosition.Member)
		{
			ClanWebServiceClient.GetPendingGroupInvitations(PlayerDataManager.ClanID, PlayerDataManager.AuthToken, new Action<List<GroupInvitationView>>(this.OnGetPendingGroupInvitations), delegate(Exception ex)
			{
			});
		}
	}

	// Token: 0x06000B1E RID: 2846 RVA: 0x00047A50 File Offset: 0x00045C50
	private void OnGetContactRequests(List<ContactRequestView> requests)
	{
		this.FriendRequests.Value = requests;
		this.FriendRequests.Fire();
		if (this.FriendRequests.Value.Count > 0)
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.NewRequest, 0UL, 1f, 1f);
		}
	}

	// Token: 0x06000B1F RID: 2847 RVA: 0x00047AA8 File Offset: 0x00045CA8
	private void OnGetAllGroupInvitations(List<GroupInvitationView> requests)
	{
		this.IncomingClanRequests.Value = requests;
		this.IncomingClanRequests.Fire();
		if (this.IncomingClanRequests.Value.Count > 0)
		{
			AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.NewRequest, 0UL, 1f, 1f);
		}
	}

	// Token: 0x06000B20 RID: 2848 RVA: 0x00008E02 File Offset: 0x00007002
	private void OnGetPendingGroupInvitations(List<GroupInvitationView> requests)
	{
		this._outgoingClanRequests = requests;
	}

	// Token: 0x04000A87 RID: 2695
	public Property<int> UnreadMessageCount = new Property<int>(0);

	// Token: 0x04000A88 RID: 2696
	public Property<List<ContactRequestView>> FriendRequests = new Property<List<ContactRequestView>>(new List<ContactRequestView>());

	// Token: 0x04000A89 RID: 2697
	public Property<List<GroupInvitationView>> IncomingClanRequests = new Property<List<GroupInvitationView>>(new List<GroupInvitationView>());

	// Token: 0x04000A8A RID: 2698
	private Dictionary<int, InboxThread> _allThreads = new Dictionary<int, InboxThread>();

	// Token: 0x04000A8B RID: 2699
	private List<InboxThread> _sortedAllThreads = new List<InboxThread>();

	// Token: 0x04000A8C RID: 2700
	private int _curThreadsPageIndex;

	// Token: 0x04000A8D RID: 2701
	public List<GroupInvitationView> _outgoingClanRequests = new List<GroupInvitationView>();
}
