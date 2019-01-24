using System;
using System.Collections;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x02000344 RID: 836
internal class GUIHomePage : GUIPageBase
{
	// Token: 0x0600173A RID: 5946 RVA: 0x0007F870 File Offset: 0x0007DA70
	private void OnEnable()
	{
		Singleton<InboxManager>.Instance.UnreadMessageCount.Fire();
		Singleton<InboxManager>.Instance.FriendRequests.Fire();
		Singleton<InboxManager>.Instance.IncomingClanRequests.Fire();
		Singleton<ChatManager>.Instance.HasUnreadClanMessage.Fire();
		Singleton<ChatManager>.Instance.HasUnreadPrivateMessage.Fire();
	}

	// Token: 0x0600173B RID: 5947 RVA: 0x0007F8C8 File Offset: 0x0007DAC8
	private void Start()
	{
		this.quitButton.gameObject.SetActive(ApplicationDataManager.IsDesktop);
		Singleton<InboxManager>.Instance.UnreadMessageCount.AddEventAndFire(new Action<int>(this.HandlePendingInboxMessages), this);
		Singleton<InboxManager>.Instance.FriendRequests.AddEventAndFire(new Action<List<ContactRequestView>>(this.HandlePendingFriendRequests), this);
		Singleton<InboxManager>.Instance.IncomingClanRequests.AddEventAndFire(new Action<List<GroupInvitationView>>(this.HandlePendingClanRequests), this);
		Singleton<ChatManager>.Instance.HasUnreadClanMessage.AddEventAndFire(new Action<bool>(this.HandlePendingChatMessages), this);
		Singleton<ChatManager>.Instance.HasUnreadPrivateMessage.AddEventAndFire(new Action<bool>(this.HandlePendingChatMessages), this);
		this.playButton.OnClicked = delegate()
		{
			base.Dismiss(delegate
			{
				GameData.Instance.MainMenu.Value = MainMenuState.None;
				MenuPageManager.Instance.LoadPage(PageType.Play, false);
			});
		};
		this.shopButton.OnClicked = delegate()
		{
			base.Dismiss(delegate
			{
				GameData.Instance.MainMenu.Value = MainMenuState.None;
				MenuPageManager.Instance.LoadPage(PageType.Shop, false);
			});
		};
		this.profileButton.OnClicked = delegate()
		{
			base.Dismiss(delegate
			{
				GameData.Instance.MainMenu.Value = MainMenuState.None;
				MenuPageManager.Instance.LoadPage(PageType.Stats, false);
			});
		};
		this.clansButton.OnClicked = delegate()
		{
			base.Dismiss(delegate
			{
				GameData.Instance.MainMenu.Value = MainMenuState.None;
				MenuPageManager.Instance.LoadPage(PageType.Clans, false);
			});
		};
		this.chatButton.OnClicked = delegate()
		{
			base.Dismiss(delegate
			{
				GameData.Instance.MainMenu.Value = MainMenuState.None;
				MenuPageManager.Instance.LoadPage(PageType.Chat, false);
			});
		};
		this.inboxButton.OnClicked = delegate()
		{
			base.Dismiss(delegate
			{
				GameData.Instance.MainMenu.Value = MainMenuState.None;
				MenuPageManager.Instance.LoadPage(PageType.Inbox, false);
			});
		};
		this.quitButton.OnClicked = delegate()
		{
			PopupSystem.ShowMessage("Quit", "Are you sure?", PopupSystem.AlertType.OKCancel, delegate()
			{
				Application.Quit();
			}, "OK", null, "Cancel");
		};
	}

	// Token: 0x0600173C RID: 5948 RVA: 0x0007FA28 File Offset: 0x0007DC28
	private void HandlePendingInboxMessages(int unreadMessages)
	{
		this.FlashInbox(unreadMessages > 0 || Singleton<InboxManager>.Instance.FriendRequests.Value.Count > 0 || Singleton<InboxManager>.Instance.IncomingClanRequests.Value.Count > 0);
	}

	// Token: 0x0600173D RID: 5949 RVA: 0x0007FA78 File Offset: 0x0007DC78
	private void HandlePendingFriendRequests(List<ContactRequestView> friendRequests)
	{
		this.FlashInbox(friendRequests.Count > 0 || Singleton<InboxManager>.Instance.IncomingClanRequests.Value.Count > 0 || Singleton<InboxManager>.Instance.UnreadMessageCount > 0);
	}

	// Token: 0x0600173E RID: 5950 RVA: 0x0007FAC8 File Offset: 0x0007DCC8
	private void HandlePendingClanRequests(List<GroupInvitationView> clanRequests)
	{
		this.FlashInbox(clanRequests.Count > 0 || Singleton<InboxManager>.Instance.FriendRequests.Value.Count > 0 || Singleton<InboxManager>.Instance.UnreadMessageCount > 0);
	}

	// Token: 0x0600173F RID: 5951 RVA: 0x0000FA90 File Offset: 0x0000DC90
	private void HandlePendingChatMessages(bool hasUnreadMessages)
	{
		this.FlashChat(Singleton<ChatManager>.Instance.HasUnreadClanMessage || Singleton<ChatManager>.Instance.HasUnreadPrivateMessage);
	}

	// Token: 0x06001740 RID: 5952 RVA: 0x0000FABE File Offset: 0x0000DCBE
	private void FlashInbox(bool bFlash)
	{
		this.FlashMenuIcon(this.inboxFlashTween, bFlash);
	}

	// Token: 0x06001741 RID: 5953 RVA: 0x0000FACD File Offset: 0x0000DCCD
	private void FlashChat(bool bFlash)
	{
		this.FlashMenuIcon(this.chatFlashTween, bFlash);
	}

	// Token: 0x06001742 RID: 5954 RVA: 0x0000FADC File Offset: 0x0000DCDC
	private void FlashMenuIcon(UITweener buttonTween, bool bFlash)
	{
		if (buttonTween == null)
		{
			return;
		}
		if (!bFlash)
		{
			buttonTween.Reset();
			buttonTween.gameObject.GetComponent<UISprite>().alpha = 1f;
		}
		buttonTween.enabled = bFlash;
	}

	// Token: 0x06001743 RID: 5955 RVA: 0x0007FB18 File Offset: 0x0007DD18
	protected override IEnumerator OnBringIn()
	{
		yield return base.StartCoroutine(base.AnimateAlpha(1f, this.bringInDuration, new UIEventReceiver[]
		{
			this.playButton
		}));
		yield return base.StartCoroutine(base.AnimateAlpha(1f, this.bringInDuration, new UIEventReceiver[]
		{
			this.shopButton
		}));
		yield return base.StartCoroutine(base.AnimateAlpha(1f, this.bringInDuration, new UIEventReceiver[]
		{
			this.chatButton
		}));
		if (ApplicationDataManager.IsDesktop)
		{
			yield return base.StartCoroutine(base.AnimateAlpha(1f, this.bringInDuration, new UIEventReceiver[]
			{
				this.quitButton
			}));
		}
		yield return base.StartCoroutine(base.AnimateAlpha(1f, this.bringInDuration, new UIEventReceiver[]
		{
			this.profileButton
		}));
		yield return base.StartCoroutine(base.AnimateAlpha(1f, this.bringInDuration, new UIEventReceiver[]
		{
			this.inboxButton
		}));
		yield return base.StartCoroutine(base.AnimateAlpha(1f, this.bringInDuration, new UIEventReceiver[]
		{
			this.clansButton
		}));
		yield break;
	}

	// Token: 0x06001744 RID: 5956 RVA: 0x0007FB34 File Offset: 0x0007DD34
	protected override IEnumerator OnDismiss()
	{
		float duration = this.dismissDuration;
		if (ApplicationDataManager.IsDesktop)
		{
			yield return base.StartCoroutine(base.AnimateAlpha(0f, duration, new UIEventReceiver[]
			{
				this.profileButton,
				this.clansButton,
				this.chatButton,
				this.inboxButton,
				this.shopButton,
				this.playButton,
				this.quitButton
			}));
		}
		else
		{
			yield return base.StartCoroutine(base.AnimateAlpha(0f, duration, new UIEventReceiver[]
			{
				this.profileButton,
				this.clansButton,
				this.chatButton,
				this.inboxButton,
				this.shopButton,
				this.playButton
			}));
		}
		yield break;
	}

	// Token: 0x04001623 RID: 5667
	[SerializeField]
	private UIEventReceiver playButton;

	// Token: 0x04001624 RID: 5668
	[SerializeField]
	private UIEventReceiver shopButton;

	// Token: 0x04001625 RID: 5669
	[SerializeField]
	private UIEventReceiver profileButton;

	// Token: 0x04001626 RID: 5670
	[SerializeField]
	private UIEventReceiver clansButton;

	// Token: 0x04001627 RID: 5671
	[SerializeField]
	private UIEventReceiver chatButton;

	// Token: 0x04001628 RID: 5672
	[SerializeField]
	private UIEventReceiver inboxButton;

	// Token: 0x04001629 RID: 5673
	[SerializeField]
	private UIEventReceiver quitButton;

	// Token: 0x0400162A RID: 5674
	[SerializeField]
	private UITweener inboxFlashTween;

	// Token: 0x0400162B RID: 5675
	[SerializeField]
	private UITweener chatFlashTween;
}
