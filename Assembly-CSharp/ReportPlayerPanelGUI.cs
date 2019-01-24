using System;
using System.Collections.Generic;
using System.Text;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x020001D9 RID: 473
public class ReportPlayerPanelGUI : PanelGuiBase
{
	// Token: 0x06000D4C RID: 3404 RVA: 0x00003C87 File Offset: 0x00001E87
	private void Awake()
	{
	}

	// Token: 0x06000D4D RID: 3405 RVA: 0x0005C554 File Offset: 0x0005A754
	private void Start()
	{
		this._isDropdownActive = false;
		this._abuse = LocalizedStrings.SelectType;
		Array values = Enum.GetValues(typeof(MemberReportType));
		this._reportTypeTexts = new string[values.Length];
		int num = 0;
		foreach (object obj in values)
		{
			MemberReportType memberReportType = (MemberReportType)((int)obj);
			this._reportTypeTexts[num++] = Enum.GetName(typeof(MemberReportType), memberReportType);
		}
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x00009DF5 File Offset: 0x00007FF5
	private void OnEnable()
	{
		GUI.FocusControl("ReportDetail");
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x0005C604 File Offset: 0x0005A804
	private void OnGUI()
	{
		this._rect = new Rect((float)(Screen.width - 570) * 0.5f, (float)(Screen.height - 345) * 0.5f, 570f, 345f);
		GUI.BeginGroup(this._rect, GUIContent.none, BlueStonez.window_standard_grey38);
		this.DrawReportPanel();
		GUI.EndGroup();
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x00009E01 File Offset: 0x00008001
	public override void Show()
	{
		base.Show();
		this._commUsersCount = 0;
		this._commUsers = Singleton<ChatManager>.Instance.GetCommUsersToReport();
	}

	// Token: 0x06000D51 RID: 3409 RVA: 0x00009E20 File Offset: 0x00008020
	public override void Hide()
	{
		base.Hide();
		this._commUsers = null;
		this._selectedAbusion = -1;
		this._abuse = LocalizedStrings.SelectType;
	}

	// Token: 0x06000D52 RID: 3410 RVA: 0x0005C66C File Offset: 0x0005A86C
	public static void ReportInboxPlayer(PrivateMessageView msg, string messageSender)
	{
		int reportedCmid = msg.FromCmid;
		string reason = msg.ContentText;
		if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.IsConnected)
		{
			PopupSystem.ShowMessage(LocalizedStrings.ReportPlayerCaps, string.Format(LocalizedStrings.ReportPlayerWarningMsg, messageSender), PopupSystem.AlertType.OKCancel, delegate()
			{
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendPlayersReported(new List<int>
				{
					reportedCmid
				}, 0, reason, Singleton<ChatManager>.Instance.GetAllChatMessagesForPlayerReport());
			}, LocalizedStrings.Report, null, LocalizedStrings.Cancel, PopupSystem.ActionType.Negative);
		}
		else
		{
			PopupSystem.ShowMessage(LocalizedStrings.Error, LocalizedStrings.ReportPlayerErrorMsg, PopupSystem.AlertType.OK, null);
		}
	}

	// Token: 0x06000D53 RID: 3411 RVA: 0x0005C6F0 File Offset: 0x0005A8F0
	private void DrawReportPanel()
	{
		GUI.depth = 3;
		GUI.skin = BlueStonez.Skin;
		GUI.Label(new Rect(0f, 0f, this._rect.width, 56f), LocalizedStrings.ReportPlayerCaps, BlueStonez.tab_strip);
		GUI.color = Color.red;
		GUI.Label(new Rect(16f, this._rect.height - 40f, 300f, 30f), LocalizedStrings.ReportPlayerInfoMsg, BlueStonez.label_interparkbold_11pt_left_wrap);
		GUI.color = Color.white;
		Rect position = new Rect(17f, 55f, this._rect.width - 34f, this._rect.height - 100f);
		GUI.BeginGroup(position, string.Empty, BlueStonez.window_standard_grey38);
		GUI.Label(new Rect(16f, 20f, 100f, 18f), LocalizedStrings.ReportType, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(16f, 50f, 100f, 18f), LocalizedStrings.PlayerNames, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(16f, 80f, 100f, 18f), LocalizedStrings.Details, BlueStonez.label_interparkbold_18pt_left);
		GUI.enabled = !this._isDropdownActive;
		GUI.SetNextControlName("ReportDetail");
		this._reason = GUI.TextArea(new Rect(16f, 110f, 290f, 120f), this._reason);
		GUI.Label(new Rect(125f, 50f, 180f, 22f), this._selectedPlayers, BlueStonez.textField);
		if (string.IsNullOrEmpty(this._selectedPlayers))
		{
			GUI.color = Color.gray;
			GUI.Label(new Rect(130f, 52f, 180f, 22f), "(" + LocalizedStrings.NoPlayerSelected + ")");
			GUI.color = Color.white;
		}
		GUI.enabled = true;
		int num = this.DoDropDownList(new Rect(125f, 20f, 183f, 22f), new Rect(135f, 50f, 194f, 84f), this._reportTypeTexts, ref this._abuse, false);
		if (num != -1)
		{
			this._selectedAbusion = num;
			this._abuse = this._reportTypeTexts[num];
		}
		GUI.SetNextControlName("SearchUser");
		this._searchPattern = GUI.TextField(new Rect(325f, 20f, 196f, 22f), this._searchPattern);
		if (string.IsNullOrEmpty(this._searchPattern) && GUI.GetNameOfFocusedControl() != "SearchUser")
		{
			GUI.color = Color.gray;
			GUI.Label(new Rect(333f, 22f, 196f, 22f), LocalizedStrings.SelectAPlayer);
			GUI.color = Color.white;
		}
		int num2 = 0;
		GUI.Label(new Rect(325f, 50f, 175f, 178f), GUIContent.none, BlueStonez.box_grey50);
		this._scrollUsers = GUITools.BeginScrollView(new Rect(325f, 50f, 195f, 178f), this._scrollUsers, new Rect(0f, 0f, 150f, (float)Mathf.Max(this._commUsersCount * 20, 178)), false, true, true);
		if (this._commUsers != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string value = this._searchPattern.ToLowerInvariant();
			foreach (CommUser commUser in this._commUsers)
			{
				bool flag = this._reportedCmids.Contains(commUser.Cmid);
				if (flag)
				{
					stringBuilder.Append(commUser.Name).Append(", ");
				}
				if (commUser.Name.ToLowerInvariant().Contains(value))
				{
					bool flag2 = GUI.Toggle(new Rect(2f, (float)(2 + num2 * 20), 171f, 20f), flag, commUser.Name, BlueStonez.dropdown_listItem);
					if (flag2 != flag)
					{
						this._reportedCmids.Clear();
						if (!flag)
						{
							this._reportedCmids.Add(commUser.Cmid);
						}
					}
					num2++;
				}
			}
			this._commUsersCount = num2;
			this._selectedPlayers = stringBuilder.ToString();
		}
		GUITools.EndScrollView();
		if (this._commUsersCount == 0)
		{
			GUI.Label(new Rect(325f, 50f, 175f, 178f), LocalizedStrings.NoPlayersToReport, BlueStonez.label_interparkmed_11pt);
		}
		else if (num2 == 0)
		{
			GUI.Label(new Rect(325f, 50f, 175f, 178f), LocalizedStrings.NoMatchFound, BlueStonez.label_interparkmed_11pt);
		}
		GUI.EndGroup();
		if (GUITools.Button(new Rect(this._rect.width - 125f, this._rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.CancelCaps), BlueStonez.button))
		{
			PanelManager.Instance.ClosePanel(PanelType.ReportPlayer);
			this._commUsers = null;
			this._reportedCmids.Clear();
			this._selectedPlayers = string.Empty;
			this._reason = string.Empty;
			this._selectedAbusion = -1;
		}
		GUI.enabled = (this._selectedAbusion >= 0 && !string.IsNullOrEmpty(this._selectedPlayers) && !string.IsNullOrEmpty(this._reason));
		if (GUITools.Button(new Rect(this._rect.width - 125f - 125f, this._rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.SendCaps), BlueStonez.button_red))
		{
			if (AutoMonoBehaviour<CommConnectionManager>.Instance.Client.IsConnected)
			{
				PopupSystem.ShowMessage(LocalizedStrings.ReportPlayerCaps, string.Format(LocalizedStrings.ReportPlayerWarningMsg, this._selectedPlayers), PopupSystem.AlertType.OKCancel, new Action(this.ConfirmAbuseReport), LocalizedStrings.Report, null, LocalizedStrings.Cancel, PopupSystem.ActionType.Negative);
			}
			else
			{
				PopupSystem.ShowMessage(LocalizedStrings.Error, LocalizedStrings.ReportPlayerErrorMsg, PopupSystem.AlertType.OK, null);
			}
		}
	}

	// Token: 0x06000D54 RID: 3412 RVA: 0x0005CD70 File Offset: 0x0005AF70
	private void ConfirmAbuseReport()
	{
		AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendPlayersReported(this._reportedCmids, 0, this._reason, Singleton<ChatManager>.Instance.GetAllChatMessagesForPlayerReport());
		PanelManager.Instance.ClosePanel(PanelType.ReportPlayer);
		PopupSystem.ShowMessage(LocalizedStrings.ReportPlayerCaps, LocalizedStrings.ReportPlayerSuccessMsg, PopupSystem.AlertType.OK, null);
		this._reportedCmids.Clear();
		this._selectedPlayers = string.Empty;
		this._reason = string.Empty;
		this._selectedAbusion = -1;
	}

	// Token: 0x06000D55 RID: 3413 RVA: 0x000524D0 File Offset: 0x000506D0
	private void DrawGroupControl(Rect rect, string title, GUIStyle style)
	{
		GUI.BeginGroup(rect, string.Empty, BlueStonez.group_grey81);
		GUI.EndGroup();
		GUI.Label(new Rect(rect.x + 18f, rect.y - 8f, style.CalcSize(new GUIContent(title)).x + 10f, 16f), title, style);
	}

	// Token: 0x06000D56 RID: 3414 RVA: 0x0005CDF4 File Offset: 0x0005AFF4
	private int DoDropDownList(Rect position, Rect size, string[] items, ref string defaultText, bool canEdit)
	{
		int result = -1;
		Rect position2 = new Rect(position.x, position.y, position.width - position.height, position.height);
		Rect position3 = new Rect(position.x + position.width - position.height - 2f, position.y - 1f, position.height, position.height);
		bool enabled = GUI.enabled;
		GUI.enabled = (!this._isDropdownActive || this._currentActiveItems == items);
		if (canEdit)
		{
			defaultText = GUI.TextField(new Rect(position.x, position.y, position.width - position.height, position.height - 1f), defaultText, BlueStonez.textArea);
		}
		else
		{
			GUI.Label(position2, defaultText, BlueStonez.label_dropdown);
		}
		if (GUI.Button(position3, GUIContent.none, BlueStonez.dropdown_button))
		{
			this._isDropdownActive = !this._isDropdownActive;
			this._currentActiveItems = items;
		}
		if (this._isDropdownActive && this._currentActiveItems == items)
		{
			Rect position4 = new Rect(position.x, position.y + position.height - 1f, size.width - 16f, size.height);
			GUI.Box(position4, string.Empty, BlueStonez.window_standard_grey38);
			this._listScroll = GUITools.BeginScrollView(position4, this._listScroll, new Rect(0f, 0f, position4.width - 20f, (float)(items.Length * 20)), false, false, true);
			for (int i = 0; i < items.Length; i++)
			{
				if (GUI.Button(new Rect(2f, (float)(i * 20 + 2), position4.width - 4f, 20f), items[i], BlueStonez.dropdown_listItem))
				{
					this._isDropdownActive = false;
					result = i;
				}
			}
			GUITools.EndScrollView();
		}
		GUI.enabled = enabled;
		return result;
	}

	// Token: 0x04000C98 RID: 3224
	private Rect _rect;

	// Token: 0x04000C99 RID: 3225
	private bool _isDropdownActive;

	// Token: 0x04000C9A RID: 3226
	private Vector2 _listScroll;

	// Token: 0x04000C9B RID: 3227
	private string[] _reportTypeTexts;

	// Token: 0x04000C9C RID: 3228
	private int _selectedAbusion = -1;

	// Token: 0x04000C9D RID: 3229
	private string _reason = string.Empty;

	// Token: 0x04000C9E RID: 3230
	private string _abuse = string.Empty;

	// Token: 0x04000C9F RID: 3231
	private string _selectedPlayers = string.Empty;

	// Token: 0x04000CA0 RID: 3232
	private string _searchPattern = string.Empty;

	// Token: 0x04000CA1 RID: 3233
	private Vector2 _scrollUsers;

	// Token: 0x04000CA2 RID: 3234
	private List<int> _reportedCmids = new List<int>();

	// Token: 0x04000CA3 RID: 3235
	private string[] _currentActiveItems;

	// Token: 0x04000CA4 RID: 3236
	private int _commUsersCount;

	// Token: 0x04000CA5 RID: 3237
	private List<CommUser> _commUsers;
}
