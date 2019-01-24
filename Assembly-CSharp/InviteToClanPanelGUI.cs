using System;
using Cmune.DataCenter.Common.Entities;
using UberStrike.WebService.Unity;
using UnityEngine;

// Token: 0x020001D1 RID: 465
public class InviteToClanPanelGUI : PanelGuiBase
{
	// Token: 0x06000CEC RID: 3308 RVA: 0x000099AD File Offset: 0x00007BAD
	private void OnGUI()
	{
		this.DrawInvitePlayerMessage(new Rect(0f, (float)GlobalUIRibbon.Instance.Height(), (float)Screen.width, (float)(Screen.height - GlobalUIRibbon.Instance.Height())));
	}

	// Token: 0x06000CED RID: 3309 RVA: 0x00058DD8 File Offset: 0x00056FD8
	private void DrawInvitePlayerMessage(Rect rect)
	{
		GUI.depth = 3;
		GUI.enabled = true;
		Rect position = new Rect(rect.x + (rect.width - 480f) / 2f, rect.y + (rect.height - 320f) / 2f, 480f, 320f);
		GUI.BeginGroup(position, BlueStonez.window);
		int num = 25;
		int num2 = 120;
		int num3 = 320;
		int num4 = 70;
		int num5 = 100;
		int num6 = 132;
		GUI.Label(new Rect(0f, 0f, position.width, 0f), LocalizedStrings.InvitePlayer, BlueStonez.tab_strip);
		GUI.Label(new Rect(12f, 55f, position.width - 24f, 208f), GUIContent.none, BlueStonez.window_standard_grey38);
		GUI.Label(new Rect((float)num, (float)num4, 400f, 20f), LocalizedStrings.UseThisFormToSendClanInvitations, BlueStonez.label_interparkbold_11pt);
		GUI.Label(new Rect((float)num, (float)num5, 90f, 20f), LocalizedStrings.PlayerCaps, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect((float)num, (float)num6, 90f, 20f), LocalizedStrings.MessageCaps, BlueStonez.label_interparkbold_18pt_right);
		GUI.SetNextControlName("Message Receiver");
		GUI.enabled = !this._fixReceiver;
		this._name = GUI.TextField(new Rect((float)num2, (float)num5, (float)num3, 24f), this._name, BlueStonez.textField);
		if (string.IsNullOrEmpty(this._name) && !GUI.GetNameOfFocusedControl().Equals("Message Receiver"))
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(new Rect((float)num2, (float)num5, (float)num3, 24f), " " + LocalizedStrings.StartTypingTheNameOfAFriend, BlueStonez.label_interparkbold_11pt_left);
			GUI.color = Color.white;
		}
		GUI.enabled = !this._showReceiverDropdownList;
		GUI.SetNextControlName("Description");
		this._message = GUI.TextArea(new Rect((float)num2, (float)num6, (float)num3, 108f), this._message, BlueStonez.textArea);
		this._message = this._message.Trim(new char[]
		{
			'\n',
			'\t'
		});
		GUI.enabled = (this._cmid != 0);
		if (GUITools.Button(new Rect(position.width - 155f - 155f, position.height - 44f, 150f, 32f), new GUIContent(LocalizedStrings.SendCaps), BlueStonez.button_green))
		{
			ClanWebServiceClient.InviteMemberToJoinAGroup(PlayerDataManager.ClanID, PlayerDataManager.AuthToken, this._cmid, this._message, delegate(int ev)
			{
			}, delegate(Exception ex)
			{
			});
			PanelManager.Instance.ClosePanel(PanelType.ClanRequest);
		}
		GUI.enabled = true;
		if (GUITools.Button(new Rect(position.width - 155f, position.height - 44f, 150f, 32f), new GUIContent(LocalizedStrings.CancelCaps), BlueStonez.button))
		{
			this._message = string.Empty;
			PanelManager.Instance.ClosePanel(PanelType.ClanRequest);
		}
		if (!this._fixReceiver)
		{
			if (!this._showReceiverDropdownList && GUI.GetNameOfFocusedControl().Equals("Message Receiver"))
			{
				this._cmid = 0;
				this._showReceiverDropdownList = true;
			}
			if (this._showReceiverDropdownList)
			{
				this.DoReceiverDropdownList(new Rect((float)num2, (float)(num5 + 24), (float)num3, this._receiverDropdownHeight));
			}
		}
		GUI.EndGroup();
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x000591B4 File Offset: 0x000573B4
	private void Update()
	{
		this._receiverDropdownHeight = Mathf.Lerp(this._receiverDropdownHeight, (float)((!this._showReceiverDropdownList) ? 0 : 146), Time.deltaTime * 9f);
		if (!this._showReceiverDropdownList && Mathf.Approximately(this._receiverDropdownHeight, 0f))
		{
			this._receiverDropdownHeight = 0f;
		}
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x00059220 File Offset: 0x00057420
	private void DoReceiverDropdownList(Rect rect)
	{
		GUI.BeginGroup(rect, BlueStonez.window);
		int num = -1;
		if (Singleton<PlayerDataManager>.Instance.FriendsCount > 0)
		{
			int num2 = 0;
			int num3 = 0;
			this._friendListScroll = GUITools.BeginScrollView(new Rect(0f, 0f, rect.width, rect.height), this._friendListScroll, new Rect(0f, 0f, rect.width - 20f, (float)(Singleton<PlayerDataManager>.Instance.FriendsCount * 24)), false, false, true);
			foreach (PublicProfileView publicProfileView in Singleton<PlayerDataManager>.Instance.MergedFriends)
			{
				if (this._name.Length <= 0 || publicProfileView.Name.ToLower().Contains(this._name.ToLower()))
				{
					if (num == -1)
					{
						num = num3;
					}
					bool flag = PlayerDataManager.IsClanMember(publicProfileView.Cmid);
					Rect position = new Rect(0f, (float)(num2 * 24), rect.width, 24f);
					if (GUI.enabled && position.Contains(Event.current.mousePosition) && GUI.Button(position, GUIContent.none, BlueStonez.box_grey50) && !flag)
					{
						this._cmid = publicProfileView.Cmid;
						this._name = publicProfileView.Name;
						this._showReceiverDropdownList = false;
						GUI.FocusControl("Description");
					}
					string text = (!string.IsNullOrEmpty(publicProfileView.GroupTag)) ? string.Format("[{0}] {1}", publicProfileView.GroupTag, publicProfileView.Name) : publicProfileView.Name;
					GUI.Label(new Rect(8f, (float)(num2 * 24 + 4), rect.width, rect.height), text, BlueStonez.label_interparkmed_11pt_left);
					if (flag)
					{
						GUI.contentColor = Color.gray;
						GUI.Label(new Rect(rect.width - 100f, (float)(num2 * 24 + 4), 100f, rect.height), LocalizedStrings.InMyClan, BlueStonez.label_interparkmed_11pt_left);
						GUI.contentColor = Color.white;
					}
					num2++;
				}
			}
			GUITools.EndScrollView();
		}
		else
		{
			GUI.Label(new Rect(0f, 0f, rect.width, rect.height), LocalizedStrings.YouHaveNoFriends, BlueStonez.label_interparkmed_11pt);
		}
		GUI.EndGroup();
		if (Event.current.type == EventType.MouseDown && !rect.Contains(Event.current.mousePosition))
		{
			GUI.FocusControl("Description");
			this._showReceiverDropdownList = false;
			PublicProfileView publicProfileView2;
			if (PlayerDataManager.TryGetFriend(this._cmid, out publicProfileView2))
			{
				this._name = publicProfileView2.Name;
			}
			else
			{
				this._name = string.Empty;
				this._cmid = 0;
			}
		}
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x000099E1 File Offset: 0x00007BE1
	public override void Show()
	{
		base.Show();
		this._message = string.Format(LocalizedStrings.HiYoureInvitedToJoinMyClanN, PlayerDataManager.ClanName);
	}

	// Token: 0x06000CF1 RID: 3313 RVA: 0x000099FE File Offset: 0x00007BFE
	public override void Hide()
	{
		base.Hide();
		this._name = string.Empty;
		this._fixReceiver = false;
		this._cmid = 0;
	}

	// Token: 0x06000CF2 RID: 3314 RVA: 0x00009A1F File Offset: 0x00007C1F
	public void SelectReceiver(int cmid, string name)
	{
		this._cmid = cmid;
		this._name = name;
		this._fixReceiver = (this._cmid != 0);
	}

	// Token: 0x04000C47 RID: 3143
	private bool _showReceiverDropdownList;

	// Token: 0x04000C48 RID: 3144
	private Vector2 _friendListScroll;

	// Token: 0x04000C49 RID: 3145
	private float _receiverDropdownHeight;

	// Token: 0x04000C4A RID: 3146
	private int _cmid;

	// Token: 0x04000C4B RID: 3147
	private string _message = string.Empty;

	// Token: 0x04000C4C RID: 3148
	private string _name = string.Empty;

	// Token: 0x04000C4D RID: 3149
	private bool _fixReceiver;
}
