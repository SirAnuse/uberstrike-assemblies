using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x02000187 RID: 391
public class ClanPageGUI : MonoBehaviour
{
	// Token: 0x06000ACA RID: 2762 RVA: 0x00008AFF File Offset: 0x00006CFF
	private void Awake()
	{
		global::EventHandler.Global.AddListener<GlobalEvents.ClanCreated>(new Action<GlobalEvents.ClanCreated>(this.OnClanCreated));
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x00008B17 File Offset: 0x00006D17
	private void OnClanCreated(GlobalEvents.ClanCreated ev)
	{
		this.createAClan = false;
		this._newClanMotto = string.Empty;
		this._newClanName = string.Empty;
		this._newClanTag = string.Empty;
	}

	// Token: 0x06000ACC RID: 2764 RVA: 0x00044E90 File Offset: 0x00043090
	private void OnGUI()
	{
		GUI.depth = 11;
		GUI.skin = BlueStonez.Skin;
		Rect rect = new Rect(0f, (float)GlobalUIRibbon.Instance.Height(), (float)Screen.width, (float)(Screen.height - GlobalUIRibbon.Instance.Height()));
		GUI.BeginGroup(rect, BlueStonez.box_grey31);
		GUI.enabled = (PlayerDataManager.IsPlayerLoggedIn && this.IsNoPopupOpen() && !Singleton<ClanDataManager>.Instance.IsProcessingWebservice);
		if (PlayerDataManager.IsPlayerInClan)
		{
			float num = 73f;
			float num2 = 40f;
			float num3 = rect.height - num - num2;
			this.DrawClanRosterHeader(new Rect(0f, 0f, rect.width, num));
			this.DrawMembersView(new Rect(0f, num, rect.width, num3));
			this.DrawClanRosterFooter(new Rect(0f, num + num3, rect.width, num2));
		}
		else
		{
			GUI.Box(rect, GUIContent.none, BlueStonez.box_grey38);
			if (this.createAClan)
			{
				this.DrawCreateClanMessage(rect);
			}
			else
			{
				this.DrawNoClanMessage(rect);
			}
		}
		GuiManager.DrawTooltip();
		GUI.enabled = true;
		GUI.EndGroup();
	}

	// Token: 0x06000ACD RID: 2765 RVA: 0x00044FC8 File Offset: 0x000431C8
	private void DrawClanRosterHeader(Rect rect)
	{
		int num = (int)rect.width;
		GUI.BeginGroup(rect, BlueStonez.box_grey31);
		GUI.Label(new Rect(10f, 5f, rect.width - 20f, 18f), string.Format("{0}: {1}", LocalizedStrings.YourClan, PlayerDataManager.ClanName), BlueStonez.label_interparkbold_16pt_left);
		float num2 = Mathf.Max(Singleton<ClanDataManager>.Instance.NextClanRefresh - Time.time, 0f);
		GUITools.PushGUIState();
		GUI.enabled &= (num2 == 0f);
		if (GUITools.Button(new Rect(rect.width - 130f, 5f, 120f, 19f), new GUIContent(string.Format(LocalizedStrings.Refresh + " {0}", (num2 <= 0f) ? string.Empty : ("(" + num2.ToString("N0") + ")"))), BlueStonez.buttondark_medium))
		{
			Singleton<ClanDataManager>.Instance.RefreshClanData(false);
		}
		GUITools.PopGUIState();
		GUI.Label(new Rect(rect.width - 340f, 5f, 200f, 18f), string.Format(LocalizedStrings.NMembersNOnline, Singleton<PlayerDataManager>.Instance.ClanMembersCount, PlayerDataManager.ClanMembersLimit, this._onlineMemberCount), BlueStonez.label_interparkmed_11pt_right);
		GUI.BeginGroup(new Rect(0f, 25f, rect.width, 50f), BlueStonez.box_grey50);
		GUI.Label(new Rect(10f, 7f, rect.width / 2f, 16f), string.Format("Tag: {0}", PlayerDataManager.ClanTag), BlueStonez.label_interparkmed_11pt_left);
		GUI.Label(new Rect(10f, 28f, rect.width / 2f, 16f), string.Format(LocalizedStrings.MottoN, PlayerDataManager.ClanMotto), BlueStonez.label_interparkmed_11pt_left);
		GUI.Label(new Rect(rect.width / 2f, 7f, rect.width / 2f, 16f), string.Format(LocalizedStrings.CreatedN, PlayerDataManager.ClanFoundingDate.ToShortDateString()), BlueStonez.label_interparkmed_11pt_left);
		GUI.Label(new Rect(rect.width / 2f, 28f, rect.width / 2f, 16f), string.Format(LocalizedStrings.LeaderN, PlayerDataManager.ClanOwnerName), BlueStonez.label_interparkmed_11pt_left);
		GUI.EndGroup();
		if (Singleton<PlayerDataManager>.Instance.RankInClan != GroupPosition.Member)
		{
			num = (int)(rect.width - 10f - 120f);
			if (GUITools.Button(new Rect((float)num, 40f, 120f, 20f), new GUIContent(LocalizedStrings.InvitePlayer), BlueStonez.buttondark_medium))
			{
				PanelManager.Instance.OpenPanel(PanelType.ClanRequest);
			}
		}
		GUI.EndGroup();
	}

	// Token: 0x06000ACE RID: 2766 RVA: 0x000452D0 File Offset: 0x000434D0
	private void DrawMembersView(Rect rect)
	{
		GUI.BeginGroup(rect, BlueStonez.box_grey38);
		this.UpdateColumnWidth();
		int num = 0;
		GUI.Box(new Rect((float)num, 0f, 25f, 25f), string.Empty, BlueStonez.box_grey50);
		num = 24;
		GUI.Box(new Rect((float)num, 0f, 200f, 25f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect((float)(num + 5), 5f, 200f, 25f), LocalizedStrings.Player, BlueStonez.label_interparkmed_11pt_left);
		num = 223;
		GUI.Box(new Rect((float)num, 0f, 70f, 25f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect((float)(num + 5), 5f, 70f, 25f), LocalizedStrings.Position, BlueStonez.label_interparkmed_11pt_left);
		num = 292;
		GUI.Box(new Rect((float)num, 0f, 80f, 25f), string.Empty, BlueStonez.box_grey50);
		GUI.Label(new Rect((float)(num + 5), 5f, 80f, 25f), LocalizedStrings.JoinDate, BlueStonez.label_interparkmed_11pt_left);
		num = 371;
		GUI.Box(new Rect((float)num, 0f, (float)this._statusWidth, 25f), string.Empty, BlueStonez.box_grey50);
		int num2 = 0;
		int num3 = Singleton<PlayerDataManager>.Instance.ClanMembersCount * 50;
		this._clanMembersScrollView = GUITools.BeginScrollView(new Rect(0f, 25f, rect.width, rect.height - 25f), this._clanMembersScrollView, new Rect(0f, 0f, rect.width - 20f, (float)num3), false, false, true);
		this._onlineMemberCount = 0;
		foreach (ClanMemberView member in Singleton<PlayerDataManager>.Instance.ClanMembers)
		{
			this.DrawClanMembers(new Rect(0f, (float)(50 * num2++ - 1), rect.width - 20f, 50f), member);
		}
		GUITools.EndScrollView();
		GUI.EndGroup();
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x00045528 File Offset: 0x00043728
	private void DrawClanMembers(Rect rect, ClanMemberView member)
	{
		GUIStyle style = (!rect.Contains(Event.current.mousePosition)) ? BlueStonez.box_grey38 : BlueStonez.box_grey50;
		GUI.BeginGroup(rect, style);
		CommUser commUser;
		if (Singleton<ChatManager>.Instance.TryGetClanUsers(member.Cmid, out commUser))
		{
			GUI.DrawTexture(new Rect(5f, 12f, 14f, 20f), ChatManager.GetPresenceIcon(commUser.PresenceIndex));
		}
		int num = 28;
		GUI.Label(new Rect((float)num, 12f, 200f, 25f), member.Name, BlueStonez.label_interparkbold_13pt_left);
		num = 228;
		GUI.Label(new Rect((float)num, 20f, 70f, 25f), this.ConvertClanPosition(member.Position), BlueStonez.label_interparkmed_11pt_left);
		num = 298;
		GUI.Label(new Rect((float)num, 20f, 80f, 25f), member.JoiningDate.ToString("d"), BlueStonez.label_interparkmed_11pt_left);
		float num2 = rect.width - 20f;
		if (member.Cmid != PlayerDataManager.Cmid)
		{
			if (commUser != null && commUser.IsOnline)
			{
				this._onlineMemberCount++;
				if (GUITools.Button(new Rect(num2 - 120f, 4f, 100f, 20f), new GUIContent(LocalizedStrings.PrivateChat), BlueStonez.buttondark_medium))
				{
					MenuPageManager.Instance.LoadPage(PageType.Chat, false);
					Singleton<ChatManager>.Instance.CreatePrivateChat(member.Cmid);
				}
			}
			else
			{
				int days = DateTime.Now.Subtract(member.Lastlogin).Days;
				string text = string.Format(LocalizedStrings.LastOnlineN, (days <= 1) ? ((days != 0) ? LocalizedStrings.Yesterday : LocalizedStrings.Today) : (days.ToString() + " " + LocalizedStrings.DaysAgo));
				GUI.Label(new Rect(num2 - 120f, 4f, 100f, 25f), text, BlueStonez.label_interparkmed_11pt_left);
			}
			if (GUITools.Button(new Rect(num2 - 120f, 28f, 100f, 20f), new GUIContent(LocalizedStrings.SendMessage), BlueStonez.buttondark_medium))
			{
				SendMessagePanelGUI sendMessagePanelGUI = PanelManager.Instance.OpenPanel(PanelType.SendMessage) as SendMessagePanelGUI;
				if (sendMessagePanelGUI)
				{
					sendMessagePanelGUI.SelectReceiver(member.Cmid, member.Name);
				}
			}
		}
		if (this.HasHigherPermissionThan(member.Position))
		{
			if (GUITools.Button(new Rect(num2 - 10f, 14f, 20f, 20f), new GUIContent("x"), BlueStonez.buttondark_medium))
			{
				int removeFromClanCmid = member.Cmid;
				string text2 = string.Format(LocalizedStrings.RemoveNFromClanN, member.Name, PlayerDataManager.ClanName) + "\n\n" + LocalizedStrings.RemoveMemberWarningMsg;
				PopupSystem.ShowMessage(LocalizedStrings.RemoveMember, text2, PopupSystem.AlertType.OKCancel, delegate()
				{
					Singleton<ClanDataManager>.Instance.RemoveMemberFromClan(removeFromClanCmid);
				}, "OK", null, LocalizedStrings.Cancel, PopupSystem.ActionType.Negative);
			}
			num2 -= 160f;
		}
		num = 378;
		if (Singleton<PlayerDataManager>.Instance.RankInClan == GroupPosition.Leader && this.HasHigherPermissionThan(member.Position))
		{
			if (GUITools.Button(new Rect((float)num, 4f, 130f, 20f), new GUIContent(LocalizedStrings.TransferLeadership), BlueStonez.buttondark_medium))
			{
				int newLeader = member.Cmid;
				string text3 = string.Format(LocalizedStrings.TransferClanLeaderhsipToN, member.Name) + "\n\n" + LocalizedStrings.TransferClanWarningMsg;
				PopupSystem.ShowMessage(LocalizedStrings.TransferLeadership, text3, PopupSystem.AlertType.OKCancel, delegate()
				{
					Singleton<ClanDataManager>.Instance.TransferOwnershipTo(newLeader);
				}, LocalizedStrings.TransferCaps, null, LocalizedStrings.Cancel, PopupSystem.ActionType.Negative);
			}
			num2 -= 160f;
		}
		if (Singleton<PlayerDataManager>.Instance.RankInClan == GroupPosition.Leader && this.HasHigherPermissionThan(member.Position))
		{
			if (member.Position == GroupPosition.Member && GUITools.Button(new Rect((float)num, 28f, 130f, 20f), new GUIContent(LocalizedStrings.PromoteMember), BlueStonez.buttondark_medium))
			{
				int memberCmid = member.Cmid;
				PopupSystem.ShowMessage(LocalizedStrings.PromoteMember, string.Format(LocalizedStrings.ThisWillChangeNPositionToN, member.Name, LocalizedStrings.Officer), PopupSystem.AlertType.OKCancel, delegate()
				{
					Singleton<ClanDataManager>.Instance.UpdateMemberTo(memberCmid, GroupPosition.Officer);
				}, LocalizedStrings.PromoteCaps, null, LocalizedStrings.Cancel, PopupSystem.ActionType.Positive);
			}
			else if (member.Position == GroupPosition.Officer && GUITools.Button(new Rect((float)num, 28f, 130f, 20f), new GUIContent(LocalizedStrings.DemoteMember), BlueStonez.buttondark_medium))
			{
				int memberCmid = member.Cmid;
				PopupSystem.ShowMessage(LocalizedStrings.DemoteMember, string.Format(LocalizedStrings.ThisWillChangeNPositionToN, member.Name, LocalizedStrings.Member), PopupSystem.AlertType.OKCancel, delegate()
				{
					Singleton<ClanDataManager>.Instance.UpdateMemberTo(memberCmid, GroupPosition.Member);
				}, LocalizedStrings.DemoteCaps, null, LocalizedStrings.Cancel, PopupSystem.ActionType.Negative);
			}
			num2 -= 160f;
		}
		GUI.Label(new Rect(1f, rect.height - 2f, rect.width - 2f, 1f), string.Empty, BlueStonez.horizontal_line_grey95);
		GUI.EndGroup();
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x00045AA0 File Offset: 0x00043CA0
	private void DrawClanRosterFooter(Rect rect)
	{
		GUI.BeginGroup(rect, BlueStonez.box_grey31);
		if (Singleton<PlayerDataManager>.Instance.RankInClan == GroupPosition.Leader)
		{
			if (GUITools.Button(new Rect(rect.width - 110f, 10f, 100f, 20f), new GUIContent(LocalizedStrings.DisbandClan), BlueStonez.buttondark_medium))
			{
				string text = string.Format(LocalizedStrings.DisbandClanN, PlayerDataManager.ClanName) + "\n\n" + LocalizedStrings.DisbandClanWarningMsg;
				PopupSystem.ShowMessage(LocalizedStrings.DisbandClan, text, PopupSystem.AlertType.OKCancel, delegate()
				{
					Singleton<ClanDataManager>.Instance.DisbanClan();
				}, LocalizedStrings.DisbandCaps, null, LocalizedStrings.Cancel, PopupSystem.ActionType.Negative);
			}
		}
		else if (GUITools.Button(new Rect(rect.width - 110f, 10f, 100f, 20f), new GUIContent(LocalizedStrings.LeaveClan), BlueStonez.buttondark_medium))
		{
			string text2 = string.Format(LocalizedStrings.LeaveClanN, PlayerDataManager.ClanName) + "\n\n" + LocalizedStrings.LeaveClanWarningMsg;
			PopupSystem.ShowMessage(LocalizedStrings.LeaveClan, text2, PopupSystem.AlertType.OKCancel, delegate()
			{
				Singleton<ClanDataManager>.Instance.LeaveClan();
			}, LocalizedStrings.LeaveCaps, null, LocalizedStrings.Cancel, PopupSystem.ActionType.Negative);
		}
		GUI.EndGroup();
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x00045BF0 File Offset: 0x00043DF0
	private bool HasHigherPermissionThan(GroupPosition gp)
	{
		GroupPosition rankInClan = Singleton<PlayerDataManager>.Instance.RankInClan;
		if (rankInClan != GroupPosition.Leader)
		{
			return rankInClan == GroupPosition.Officer && gp == GroupPosition.Member;
		}
		return gp != GroupPosition.Leader;
	}

	// Token: 0x06000AD2 RID: 2770 RVA: 0x00045C28 File Offset: 0x00043E28
	private string ConvertClanPosition(GroupPosition gp)
	{
		string result = string.Empty;
		switch (gp)
		{
		case GroupPosition.Leader:
			result = LocalizedStrings.Leader;
			break;
		default:
			if (gp != GroupPosition.Officer)
			{
				result = LocalizedStrings.Unknown;
			}
			else
			{
				result = LocalizedStrings.Officer;
			}
			break;
		case GroupPosition.Member:
			result = LocalizedStrings.Member;
			break;
		}
		return result;
	}

	// Token: 0x06000AD3 RID: 2771 RVA: 0x00045C88 File Offset: 0x00043E88
	private void UpdateColumnWidth()
	{
		int width = Screen.width;
		int num = width - 25 - 70 - 80;
		this._statusWidth = num - 200 + 4;
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x00045CB8 File Offset: 0x00043EB8
	private void DrawNoClanMessage(Rect rect)
	{
		Rect position = new Rect((rect.width - 480f) / 2f, (rect.height - 240f) / 2f, 480f, 240f);
		GUI.BeginGroup(position, BlueStonez.window_standard_grey38);
		GUI.Label(new Rect(0f, 0f, position.width, 56f), LocalizedStrings.ClansCaps, BlueStonez.tab_strip);
		GUI.Box(new Rect(position.width / 2f - 82f, 60f, 48f, 48f), new GUIContent(this._level4Icon), BlueStonez.item_slot_large);
		if (Singleton<ClanDataManager>.Instance.HaveLevel)
		{
			GUI.Box(new Rect(position.width / 2f - 82f, 60f, 48f, 48f), new GUIContent(UberstrikeIcons.LevelMastered));
		}
		GUI.Box(new Rect(position.width / 2f - 24f, 60f, 48f, 48f), new GUIContent(this._licenseIcon), BlueStonez.item_slot_large);
		if (Singleton<ClanDataManager>.Instance.HaveLicense)
		{
			GUI.Box(new Rect(position.width / 2f - 24f, 60f, 48f, 48f), new GUIContent(UberstrikeIcons.LevelMastered));
		}
		GUI.Box(new Rect(position.width / 2f + 34f, 60f, 48f, 48f), new GUIContent(this._friendsIcon), BlueStonez.item_slot_large);
		if (Singleton<ClanDataManager>.Instance.HaveFriends)
		{
			GUI.Box(new Rect(position.width / 2f + 34f, 60f, 48f, 48f), new GUIContent(UberstrikeIcons.LevelMastered));
		}
		if (!Singleton<ClanDataManager>.Instance.HaveLevel || !Singleton<ClanDataManager>.Instance.HaveLicense || !Singleton<ClanDataManager>.Instance.HaveFriends)
		{
			bool enabled = GUI.enabled;
			GUI.Label(new Rect(position.width / 2f - 90f, 110f, 210f, 14f), LocalizedStrings.ToCreateAClanYouStillNeedTo, BlueStonez.label_interparkbold_11pt_left);
			GUI.enabled = (enabled && !Singleton<ClanDataManager>.Instance.HaveLevel);
			GUI.Label(new Rect(position.width / 2f - 90f, 124f, 200f, 14f), LocalizedStrings.ReachLevelFour + ((!Singleton<ClanDataManager>.Instance.HaveLevel) ? string.Empty : string.Format(" ({0})", LocalizedStrings.Done)), BlueStonez.label_interparkbold_11pt_left);
			GUI.enabled = (enabled && !Singleton<ClanDataManager>.Instance.HaveFriends);
			GUI.Label(new Rect(position.width / 2f - 90f, 138f, 200f, 14f), LocalizedStrings.HaveAtLeastOneFriend + ((!Singleton<ClanDataManager>.Instance.HaveFriends) ? string.Empty : string.Format(" ({0})", LocalizedStrings.Done)), BlueStonez.label_interparkbold_11pt_left);
			GUI.enabled = (enabled && !Singleton<ClanDataManager>.Instance.HaveLicense);
			GUI.Label(new Rect(position.width / 2f - 90f, 152f, 240f, 14f), LocalizedStrings.BuyAClanLicense + ((!Singleton<ClanDataManager>.Instance.HaveLicense) ? string.Empty : string.Format(" ({0})", LocalizedStrings.Done)), BlueStonez.label_interparkbold_11pt_left);
			GUI.enabled = enabled;
			if (!Singleton<ClanDataManager>.Instance.HaveLicense && GUITools.Button(new Rect((position.width - 200f) / 2f, 170f, 200f, 22f), new GUIContent(LocalizedStrings.BuyAClanLicense), BlueStonez.buttondark_medium))
			{
				IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(1234);
				if (itemInShop != null && itemInShop.View != null)
				{
					BuyPanelGUI buyPanelGUI = PanelManager.Instance.OpenPanel(PanelType.BuyItem) as BuyPanelGUI;
					if (buyPanelGUI)
					{
						buyPanelGUI.SetItem(itemInShop, BuyingLocationType.Shop, BuyingRecommendationType.None, false);
					}
				}
			}
		}
		else
		{
			GUI.Label(new Rect(0f, 140f, position.width, 14f), LocalizedStrings.CreateAClanAndInviteYourFriends, BlueStonez.label_interparkbold_11pt);
		}
		GUITools.PushGUIState();
		GUI.enabled &= (Singleton<ClanDataManager>.Instance.HaveLevel && Singleton<ClanDataManager>.Instance.HaveLicense && Singleton<ClanDataManager>.Instance.HaveFriends);
		if (GUITools.Button(new Rect((position.width - 200f) / 2f, 200f, 200f, 30f), new GUIContent(LocalizedStrings.CreateAClanCaps), BlueStonez.button_green))
		{
			this.createAClan = true;
		}
		GUITools.PopGUIState();
		GUI.EndGroup();
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x000461F0 File Offset: 0x000443F0
	private void DrawCreateClanMessage(Rect rect)
	{
		Rect position = new Rect((rect.width - 480f) / 2f, (rect.height - 360f) / 2f, 480f, 360f);
		GUI.BeginGroup(position, BlueStonez.window_standard_grey38);
		int num = 35;
		int num2 = 120;
		int num3 = 320;
		int num4 = 130;
		int num5 = 190;
		int num6 = 250;
		GUI.Label(new Rect(0f, 0f, position.width, 56f), LocalizedStrings.CreateAClan, BlueStonez.tab_strip);
		GUI.Label(new Rect(0f, 60f, position.width, 20f), LocalizedStrings.HereYouCanCreateYourOwnClan, BlueStonez.label_interparkbold_18pt);
		GUI.Label(new Rect(0f, 80f, position.width, 40f), LocalizedStrings.YouCantChangeYourClanInfoOnceCreated, BlueStonez.label_interparkmed_11pt);
		GUI.Label(new Rect((float)num, (float)num4, 100f, 20f), LocalizedStrings.Name, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect((float)num, (float)num5, 100f, 20f), LocalizedStrings.Tag, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect((float)num, (float)num6, 100f, 20f), LocalizedStrings.Motto, BlueStonez.label_interparkbold_18pt_left);
		this._newClanName = GUI.TextField(new Rect((float)num2, (float)num4, (float)num3, 24f), this._newClanName, BlueStonez.textField);
		this._newClanTag = GUI.TextField(new Rect((float)num2, (float)num5, (float)num3, 24f), this._newClanTag, BlueStonez.textField);
		this._newClanMotto = GUI.TextField(new Rect((float)num2, (float)num6, (float)num3, 24f), this._newClanMotto, BlueStonez.textField);
		GUI.Label(new Rect((float)num2, (float)(num4 + 25), 300f, 20f), LocalizedStrings.ThisIsTheOfficialNameOfYourClan, BlueStonez.label_interparkmed_10pt_left);
		GUI.Label(new Rect((float)num2, (float)(num5 + 25), 300f, 20f), LocalizedStrings.ThisTagGetsDisplayedNextToYourName, BlueStonez.label_interparkmed_10pt_left);
		GUI.Label(new Rect((float)num2, (float)(num6 + 25), 300f, 20f), LocalizedStrings.ThisIsYourOfficialClanMotto, BlueStonez.label_interparkmed_10pt_left);
		if (this._newClanName.Length > 25)
		{
			this._newClanName = this._newClanName.Remove(25);
		}
		if (this._newClanTag.Length > 5)
		{
			this._newClanTag = this._newClanTag.Remove(5);
		}
		if (this._newClanMotto.Length > 25)
		{
			this._newClanMotto = this._newClanMotto.Remove(25);
		}
		GUITools.PushGUIState();
		GUI.enabled &= (this._newClanName.Length >= 3 && this._newClanTag.Length >= 2 && this._newClanMotto.Length >= 3);
		if (GUITools.Button(new Rect(position.width - 110f - 110f, 310f, 100f, 30f), new GUIContent(LocalizedStrings.CreateCaps), BlueStonez.button_green))
		{
			Singleton<ClanDataManager>.Instance.CreateNewClan(this._newClanName, this._newClanMotto, this._newClanTag);
		}
		GUITools.PopGUIState();
		if (GUITools.Button(new Rect(position.width - 110f, 310f, 100f, 30f), new GUIContent(LocalizedStrings.CancelCaps), BlueStonez.button))
		{
			this.createAClan = false;
		}
		GUI.EndGroup();
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x00008B41 File Offset: 0x00006D41
	private void SortClanMembers()
	{
		if (Singleton<PlayerDataManager>.Instance.ClanMembers != null)
		{
			Singleton<PlayerDataManager>.Instance.ClanMembers.Sort(new ClanPageGUI.ClanSorter());
		}
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x00008B66 File Offset: 0x00006D66
	private bool IsNoPopupOpen()
	{
		return !PanelManager.IsAnyPanelOpen && !PopupSystem.IsAnyPopupOpen;
	}

	// Token: 0x04000A6E RID: 2670
	private const int _indicatorWidth = 25;

	// Token: 0x04000A6F RID: 2671
	private const int _positionWidth = 70;

	// Token: 0x04000A70 RID: 2672
	private const int _joinDateWidth = 80;

	// Token: 0x04000A71 RID: 2673
	private const int _nameWidth = 200;

	// Token: 0x04000A72 RID: 2674
	[SerializeField]
	private Texture2D _level4Icon;

	// Token: 0x04000A73 RID: 2675
	[SerializeField]
	private Texture2D _licenseIcon;

	// Token: 0x04000A74 RID: 2676
	[SerializeField]
	private Texture2D _friendsIcon;

	// Token: 0x04000A75 RID: 2677
	private bool createAClan;

	// Token: 0x04000A76 RID: 2678
	private int _onlineMemberCount;

	// Token: 0x04000A77 RID: 2679
	private int _statusWidth;

	// Token: 0x04000A78 RID: 2680
	private Vector2 _clanMembersScrollView;

	// Token: 0x04000A79 RID: 2681
	private string _newClanName = string.Empty;

	// Token: 0x04000A7A RID: 2682
	private string _newClanTag = string.Empty;

	// Token: 0x04000A7B RID: 2683
	private string _newClanMotto = string.Empty;

	// Token: 0x02000188 RID: 392
	private class ClanSorter : IComparer<ClanMemberView>
	{
		// Token: 0x06000ADB RID: 2779 RVA: 0x00008B95 File Offset: 0x00006D95
		public int Compare(ClanMemberView a, ClanMemberView b)
		{
			return ClanPageGUI.CompareClanFunctionList.CompareClanMembers(a, b);
		}
	}

	// Token: 0x02000189 RID: 393
	private static class CompareClanFunctionList
	{
		// Token: 0x06000ADC RID: 2780 RVA: 0x00046588 File Offset: 0x00044788
		public static int CompareClanMembers(ClanMemberView a, ClanMemberView b)
		{
			int num = ClanPageGUI.CompareClanFunctionList.ComparePosition(a, b);
			return (num == 0) ? ClanPageGUI.CompareClanFunctionList.CompareName(a, b) : num;
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x000465B0 File Offset: 0x000447B0
		public static int ComparePosition(ClanMemberView a, ClanMemberView b)
		{
			int num = 0;
			int num2 = 0;
			if (a.Position == GroupPosition.Leader)
			{
				num = 1;
			}
			else if (a.Position == GroupPosition.Officer)
			{
				num = 2;
			}
			else if (a.Position == GroupPosition.Member)
			{
				num = 3;
			}
			if (b.Position == GroupPosition.Leader)
			{
				num2 = 1;
			}
			else if (b.Position == GroupPosition.Officer)
			{
				num2 = 2;
			}
			else if (b.Position == GroupPosition.Member)
			{
				num2 = 3;
			}
			return (num != num2) ? ((num <= num2) ? -1 : 1) : 0;
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x00008B9E File Offset: 0x00006D9E
		public static int CompareName(ClanMemberView a, ClanMemberView b)
		{
			return string.Compare(a.Name, b.Name);
		}
	}
}
