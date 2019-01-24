using System;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x020001DB RID: 475
public class SendMessagePanelGUI : PanelGuiBase
{
	// Token: 0x06000D5A RID: 3418 RVA: 0x0005D064 File Offset: 0x0005B264
	private void OnGUI()
	{
		if (!this._showComposeMessage)
		{
			return;
		}
		GUI.depth = 3;
		GUI.skin = BlueStonez.Skin;
		Rect rect = new Rect((float)((Screen.width - 480) / 2), (float)((Screen.height - 300) / 2), 480f, 300f);
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

	// Token: 0x06000D5B RID: 3419 RVA: 0x0005D148 File Offset: 0x0005B348
	private void DoCompose(Rect rect)
	{
		Rect position = new Rect(rect.x + (rect.width - 480f) / 2f, rect.y + (rect.height - 300f) / 2f, 480f, 290f);
		GUI.BeginGroup(position, BlueStonez.window);
		int num = 35;
		int num2 = 120;
		int num3 = 320;
		int num4 = 70;
		int num5 = 100;
		GUI.Label(new Rect(0f, 0f, position.width, 0f), LocalizedStrings.NewMessage, BlueStonez.tab_strip);
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
			Singleton<InboxManager>.Instance.SendPrivateMessage(this._msgRcvCmid, this._msgReceiver, this._msgContent);
			this._msgContent = string.Empty;
			this._msgReceiver = string.Empty;
			this._msgRcvCmid = 0;
			this.Hide();
		}
		GUI.enabled = enabled;
		if (GUITools.Button(new Rect(position.width - 100f, position.height - 44f, 90f, 32f), new GUIContent(LocalizedStrings.DiscardCaps), BlueStonez.button))
		{
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

	// Token: 0x06000D5C RID: 3420 RVA: 0x0005D534 File Offset: 0x0005B734
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

	// Token: 0x06000D5D RID: 3421 RVA: 0x0005D7DC File Offset: 0x0005B9DC
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

	// Token: 0x06000D5E RID: 3422 RVA: 0x00009E41 File Offset: 0x00008041
	public override void Hide()
	{
		base.Hide();
		this._showComposeMessage = false;
		this._showReceiverDropdownList = false;
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x00009E57 File Offset: 0x00008057
	public void SelectReceiver(int cmid, string name)
	{
		this._useFixedReceiver = true;
		this._msgRcvCmid = cmid;
		this._msgReceiver = name;
		GUI.FocusControl("Message Content");
	}

	// Token: 0x04000CA8 RID: 3240
	private const string FocusReceiver = "Message Receiver";

	// Token: 0x04000CA9 RID: 3241
	private const string FocusContent = "Message Content";

	// Token: 0x04000CAA RID: 3242
	private bool _useFixedReceiver;

	// Token: 0x04000CAB RID: 3243
	private bool _showComposeMessage;

	// Token: 0x04000CAC RID: 3244
	private bool _showReceiverDropdownList;

	// Token: 0x04000CAD RID: 3245
	private string _msgReceiver;

	// Token: 0x04000CAE RID: 3246
	private string _msgContent;

	// Token: 0x04000CAF RID: 3247
	private string _lastMsgRcvName;

	// Token: 0x04000CB0 RID: 3248
	private int _msgRcvCmid;

	// Token: 0x04000CB1 RID: 3249
	private int _receiverCount;

	// Token: 0x04000CB2 RID: 3250
	private float _rcvDropdownWidth;

	// Token: 0x04000CB3 RID: 3251
	private float _rcvDropdownHeight;

	// Token: 0x04000CB4 RID: 3252
	private Vector2 _friendDropdownScroll;
}
