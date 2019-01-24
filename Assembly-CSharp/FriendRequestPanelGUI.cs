using System;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x020001CD RID: 461
public class FriendRequestPanelGUI : PanelGuiBase
{
	// Token: 0x06000CD0 RID: 3280 RVA: 0x000578F8 File Offset: 0x00055AF8
	private void OnGUI()
	{
		if (Mathf.Abs(this._keyboardOffset - this._targetKeyboardOffset) > 2f)
		{
			this._keyboardOffset = Mathf.Lerp(this._keyboardOffset, this._targetKeyboardOffset, Time.deltaTime * 4f);
		}
		else
		{
			this._keyboardOffset = this._targetKeyboardOffset;
		}
		if (!this._showComposeMessage)
		{
			return;
		}
		GUI.depth = 3;
		GUI.skin = BlueStonez.Skin;
		Rect rect = new Rect((float)((Screen.width - 480) / 2), (float)((Screen.height - 320) / 2) - this._keyboardOffset, 480f, 300f);
		GUI.Box(rect, GUIContent.none, BlueStonez.window);
		this.DoCompose(rect);
		if (this._showReceiverDropdownList)
		{
			this.DoReceiverDropdownList(rect);
		}
		this._rcvDropdownHeight = Mathf.Lerp(this._rcvDropdownHeight, (float)((!this._showReceiverDropdownList) ? 0 : 146), Time.deltaTime * 9f);
		if (!this._showReceiverDropdownList && Mathf.Approximately(this._rcvDropdownHeight, 0f))
		{
			this._rcvDropdownHeight = 0f;
		}
		GUI.enabled = true;
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x00003C87 File Offset: 0x00001E87
	private void HideKeyboard()
	{
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x00057A34 File Offset: 0x00055C34
	private void DoCompose(Rect rect)
	{
		Rect position = new Rect(rect.x + (rect.width - 480f) / 2f, rect.y + (rect.height - 300f) / 2f, 480f, 290f);
		GUI.BeginGroup(position, BlueStonez.window);
		int num = 35;
		int num2 = 120;
		int num3 = 320;
		int num4 = 70;
		int num5 = 100;
		GUI.Label(new Rect(0f, 0f, position.width, 0f), LocalizedStrings.FriendRequestCaps, BlueStonez.tab_strip);
		GUI.Box(new Rect(12f, 55f, position.width - 24f, position.height - 101f), GUIContent.none, BlueStonez.window_standard_grey38);
		GUI.Label(new Rect((float)num, (float)num4, 75f, 20f), LocalizedStrings.To, BlueStonez.label_interparkbold_18pt_right);
		GUI.Label(new Rect((float)num, (float)num5, 75f, 20f), LocalizedStrings.Message, BlueStonez.label_interparkbold_18pt_right);
		bool enabled = GUI.enabled;
		GUI.enabled = (enabled && !this._useFixedReceiver);
		GUI.SetNextControlName("Message Receiver");
		this._msgReceiver = GUI.TextField(new Rect((float)num2, (float)num4, (float)num3, 24f), this._msgReceiver, BlueStonez.textField);
		if (string.IsNullOrEmpty(this._msgReceiver) && !GUI.GetNameOfFocusedControl().Equals("Message Receiver"))
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			GUI.Label(new Rect((float)num2, (float)num4, (float)num3, 24f), " " + LocalizedStrings.StartTypingTheNameOfAFriend, BlueStonez.label_interparkbold_11pt_left);
			GUI.color = Color.white;
		}
		GUI.enabled = (enabled && !this._showReceiverDropdownList);
		GUI.SetNextControlName("Message Content");
		this._msgContent = GUI.TextArea(new Rect((float)num2, (float)num5, (float)num3, 108f), this._msgContent, 140, BlueStonez.textArea);
		GUI.color = new Color(1f, 1f, 1f, 0.5f);
		GUI.Label(new Rect((float)num2, (float)(num5 + 110), (float)num3, 24f), (140 - this._msgContent.Length).ToString(), BlueStonez.label_interparkbold_11pt_right);
		GUI.color = Color.white;
		GUI.enabled = (enabled && !this._showReceiverDropdownList && this._msgRcvCmid != 0 && !string.IsNullOrEmpty(this._msgContent));
		if (GUITools.Button(new Rect(position.width - 95f - 100f, position.height - 44f, 90f, 32f), new GUIContent(LocalizedStrings.SendCaps), BlueStonez.button_green))
		{
			Singleton<CommsManager>.Instance.SendFriendRequest(this._msgRcvCmid, this._msgContent);
			this._msgContent = string.Empty;
			this._msgReceiver = string.Empty;
			this._msgRcvCmid = 0;
			this.HideKeyboard();
			this.Hide();
		}
		GUI.enabled = enabled;
		if (GUITools.Button(new Rect(position.width - 100f, position.height - 44f, 90f, 32f), new GUIContent(LocalizedStrings.DiscardCaps), BlueStonez.button))
		{
			this.HideKeyboard();
			this.Hide();
		}
		if (!this._showReceiverDropdownList && GUI.GetNameOfFocusedControl().Equals("Message Receiver"))
		{
			this._showReceiverDropdownList = true;
			this._lastMsgRcvName = this._msgReceiver;
			this._msgReceiver = string.Empty;
		}
		GUI.EndGroup();
		if (this._showReceiverDropdownList)
		{
			this.DoReceiverDropdownList(rect);
		}
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x00057E28 File Offset: 0x00056028
	private void DoReceiverDropdownList(Rect rect)
	{
		Rect position = new Rect(rect.x + 120f, rect.y + 94f, 320f, this._rcvDropdownHeight);
		GUI.BeginGroup(position, BlueStonez.window);
		if (Singleton<PlayerDataManager>.Instance.FriendsCount > 0)
		{
			int num = 0;
			this._friendDropdownScroll = GUITools.BeginScrollView(new Rect(0f, 0f, position.width, position.height), this._friendDropdownScroll, new Rect(0f, 0f, this._rcvDropdownWidth, (float)(this._receiverCount * 24)), false, false, true);
			foreach (PublicProfileView publicProfileView in Singleton<PlayerDataManager>.Instance.MergedFriends)
			{
				if (this._msgReceiver.Length <= 0 || publicProfileView.Name.ToLower().Contains(this._msgReceiver.ToLower()))
				{
					Rect position2 = new Rect(0f, (float)(num * 24), position.width, 24f);
					if (GUI.enabled && position2.Contains(Event.current.mousePosition) && GUI.Button(position2, GUIContent.none, BlueStonez.box_grey50))
					{
						this._msgRcvCmid = publicProfileView.Cmid;
						this._msgReceiver = publicProfileView.Name;
						this._showReceiverDropdownList = false;
						GUI.FocusControl("Message Content");
					}
					GUI.Label(new Rect(8f, (float)(num * 24 + 4), position.width, position.height), publicProfileView.Name, BlueStonez.label_interparkmed_11pt_left);
					num++;
				}
			}
			this._receiverCount = num;
			if ((float)(this._receiverCount * 24) > position.height)
			{
				this._rcvDropdownWidth = position.width - 22f;
			}
			else
			{
				this._rcvDropdownWidth = position.width - 8f;
			}
			GUITools.EndScrollView();
		}
		else
		{
			GUI.Label(new Rect(0f, 0f, position.width, position.height), LocalizedStrings.YouHaveNoFriends, BlueStonez.label_interparkmed_11pt);
		}
		GUI.EndGroup();
		if (Event.current.type == EventType.MouseDown && !position.Contains(Event.current.mousePosition))
		{
			this._showReceiverDropdownList = false;
			if (this._msgRcvCmid == 0)
			{
				this._msgReceiver = this._lastMsgRcvName;
			}
		}
	}

	// Token: 0x06000CD4 RID: 3284 RVA: 0x000580D0 File Offset: 0x000562D0
	public override void Show()
	{
		base.Show();
		this._msgRcvCmid = 0;
		this._msgContent = string.Empty;
		this._msgReceiver = string.Empty;
		this._showComposeMessage = true;
		this._showReceiverDropdownList = false;
		this._useFixedReceiver = false;
		GUI.FocusControl("Message Receiver");
	}

	// Token: 0x06000CD5 RID: 3285 RVA: 0x0000991D File Offset: 0x00007B1D
	public override void Hide()
	{
		base.Hide();
		this._showComposeMessage = false;
		this._showReceiverDropdownList = false;
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x00009933 File Offset: 0x00007B33
	public void SelectReceiver(int cmid, string name)
	{
		this._useFixedReceiver = true;
		this._msgRcvCmid = cmid;
		this._msgReceiver = name;
		GUI.FocusControl("Message Content");
	}

	// Token: 0x04000C2E RID: 3118
	private const string FocusReceiver = "Message Receiver";

	// Token: 0x04000C2F RID: 3119
	private const string FocusContent = "Message Content";

	// Token: 0x04000C30 RID: 3120
	private bool _useFixedReceiver;

	// Token: 0x04000C31 RID: 3121
	private bool _showComposeMessage;

	// Token: 0x04000C32 RID: 3122
	private bool _showReceiverDropdownList;

	// Token: 0x04000C33 RID: 3123
	private string _msgReceiver;

	// Token: 0x04000C34 RID: 3124
	private string _msgContent;

	// Token: 0x04000C35 RID: 3125
	private string _lastMsgRcvName;

	// Token: 0x04000C36 RID: 3126
	private int _msgRcvCmid;

	// Token: 0x04000C37 RID: 3127
	private int _receiverCount;

	// Token: 0x04000C38 RID: 3128
	private float _rcvDropdownWidth;

	// Token: 0x04000C39 RID: 3129
	private float _rcvDropdownHeight;

	// Token: 0x04000C3A RID: 3130
	private Vector2 _friendDropdownScroll;

	// Token: 0x04000C3B RID: 3131
	private float _keyboardOffset;

	// Token: 0x04000C3C RID: 3132
	private float _targetKeyboardOffset;
}
