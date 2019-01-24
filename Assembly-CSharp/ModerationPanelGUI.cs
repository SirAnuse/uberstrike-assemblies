using System;
using System.Collections.Generic;
using Cmune.DataCenter.Common.Entities;
using UnityEngine;

// Token: 0x020001D4 RID: 468
public class ModerationPanelGUI : PanelGuiBase
{
	// Token: 0x06000D0A RID: 3338 RVA: 0x00009B4E File Offset: 0x00007D4E
	private void Awake()
	{
		this._moderations = new List<ModerationPanelGUI.Moderation>();
		global::EventHandler.Global.AddListener<GlobalEvents.Login>(delegate(GlobalEvents.Login ev)
		{
			this.InitModerations(ev.AccessLevel);
		});
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x00059BB8 File Offset: 0x00057DB8
	private void OnGUI()
	{
		this._rect = new Rect((float)(GUITools.ScreenHalfWidth - 320), (float)(GUITools.ScreenHalfHeight - 202), 640f, 404f);
		GUI.BeginGroup(this._rect, GUIContent.none, BlueStonez.window_standard_grey38);
		this.DrawModerationPanel();
		GUI.EndGroup();
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x00009B71 File Offset: 0x00007D71
	public override void Show()
	{
		base.Show();
		this._moderationSelection = ModerationPanelGUI.Actions.NONE;
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x00009B80 File Offset: 0x00007D80
	public override void Hide()
	{
		base.Hide();
		this._moderationSelection = ModerationPanelGUI.Actions.NONE;
		this._filterText = string.Empty;
	}

	// Token: 0x06000D0E RID: 3342 RVA: 0x00009B9A File Offset: 0x00007D9A
	public void SetSelectedUser(CommUser user)
	{
		if (user != null)
		{
			this._selectedCommUser = user;
			this._filterText = user.Name;
		}
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x00059C14 File Offset: 0x00057E14
	private void InitModerations(MemberAccessLevel level)
	{
		if (level >= MemberAccessLevel.Moderator)
		{
			ModerationPanelGUI.Moderation item = new ModerationPanelGUI.Moderation(MemberAccessLevel.Moderator, ModerationPanelGUI.Actions.UNMUTE_PLAYER, "Unmute Player", "Player is un-muted and un-ghosted immediately", "Unmute player", new Action<ModerationPanelGUI.Moderation, Rect>(this.DrawModeration));
			this._moderations.Add(item);
			ModerationPanelGUI.Moderation item2 = new ModerationPanelGUI.Moderation(MemberAccessLevel.Moderator, ModerationPanelGUI.Actions.GHOST_PLAYER, "Ghost Player", "Chat messages from player only appear in their own chat window, but not the windows of other players.", "Ghost player", new Action<ModerationPanelGUI.Moderation, Rect>(this.DrawModeration), new GUIContent[]
			{
				new GUIContent("1 min"),
				new GUIContent("5 min"),
				new GUIContent("30 min"),
				new GUIContent("6 hrs")
			});
			this._moderations.Add(item2);
			ModerationPanelGUI.Moderation item3 = new ModerationPanelGUI.Moderation(MemberAccessLevel.Moderator, ModerationPanelGUI.Actions.MUTE_PLAYER, "Mute Player", "Chat messages from player do not appear in anyones chat window.", "Mute player", new Action<ModerationPanelGUI.Moderation, Rect>(this.DrawModeration), new GUIContent[]
			{
				new GUIContent("1 min"),
				new GUIContent("5 min"),
				new GUIContent("30 min"),
				new GUIContent("6 hrs")
			});
			this._moderations.Add(item3);
			ModerationPanelGUI.Moderation item4 = new ModerationPanelGUI.Moderation(MemberAccessLevel.Moderator, ModerationPanelGUI.Actions.KICK_FROM_GAME, "Kick from Game", "Player is removed from the game he is currently in and dumped on the home screen.", "Kick player from game", new Action<ModerationPanelGUI.Moderation, Rect>(this.DrawModeration));
			this._moderations.Add(item4);
			ModerationPanelGUI.Moderation item5 = new ModerationPanelGUI.Moderation(MemberAccessLevel.SeniorQA, ModerationPanelGUI.Actions.KICK_FROM_APP, "Kick from Application", "Player is disconnected from all realtime connections for the current session.", "Kick player from application", new Action<ModerationPanelGUI.Moderation, Rect>(this.DrawModeration));
			this._moderations.Add(item5);
		}
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x00059D8C File Offset: 0x00057F8C
	private void DrawModerationPanel()
	{
		GUI.skin = BlueStonez.Skin;
		GUI.depth = 3;
		GUI.Label(new Rect(0f, 0f, this._rect.width, 56f), "MODERATION DASHBOARD", BlueStonez.tab_strip);
		this.DoModerationDashboard(new Rect(10f, 55f, this._rect.width - 20f, this._rect.height - 55f - 52f));
		GUI.enabled = (this._nextUpdate < Time.time);
		if (!GameState.Current.IsMultiplayer && GUITools.Button(new Rect(10f, this._rect.height - 10f - 32f, 150f, 32f), new GUIContent((this._nextUpdate >= Time.time) ? string.Format("Next Update ({0:N0})", this._nextUpdate - Time.time) : "GET ALL PLAYERS"), BlueStonez.buttondark_medium))
		{
			ChatPageGUI.IsCompleteLobbyLoaded = true;
			this._selectedCommUser = null;
			this._filterText = string.Empty;
			this._nextUpdate = Time.time + 10f;
			AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendUpdateAllActors();
		}
		GUI.enabled = (this._selectedCommUser != null && this._moderationSelection != ModerationPanelGUI.Actions.NONE);
		if (GUITools.Button(new Rect(this._rect.width - 120f - 140f, this._rect.height - 10f - 32f, 140f, 32f), new GUIContent("APPLY ACTION!"), (!GUI.enabled) ? BlueStonez.button : BlueStonez.button_red))
		{
			this.ApplyModeration();
		}
		GUI.enabled = true;
		if (GUITools.Button(new Rect(this._rect.width - 10f - 100f, this._rect.height - 10f - 32f, 100f, 32f), new GUIContent("CLOSE"), BlueStonez.button))
		{
			PanelManager.Instance.ClosePanel(PanelType.Moderation);
		}
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x00059FE4 File Offset: 0x000581E4
	private void DoModerationDashboard(Rect position)
	{
		GUI.BeginGroup(position, GUIContent.none, BlueStonez.window_standard_grey38);
		float num = 200f;
		this.DoPlayerModeration(new Rect(20f + num, 10f, position.width - 30f - num, position.height - 20f));
		this.DoPlayerSelection(new Rect(10f, 10f, num, position.height - 20f));
		GUI.EndGroup();
	}

	// Token: 0x06000D12 RID: 3346 RVA: 0x0005A064 File Offset: 0x00058264
	private void DoPlayerSelection(Rect position)
	{
		GUI.BeginGroup(position);
		GUI.Label(new Rect(0f, 0f, position.width, 18f), "SELECT PLAYER", BlueStonez.label_interparkbold_18pt_left);
		bool flag = !string.IsNullOrEmpty(this._filterText);
		GUI.SetNextControlName("Filter");
		this._filterText = GUI.TextField(new Rect(0f, 26f, (!flag) ? position.width : (position.width - 26f), 24f), this._filterText, 20, BlueStonez.textField);
		if (!flag && GUI.GetNameOfFocusedControl() != "Filter")
		{
			GUI.color = new Color(1f, 1f, 1f, 0.3f);
			if (GUI.Button(new Rect(7f, 32f, position.width, 24f), "Enter player name", BlueStonez.label_interparkmed_11pt_left))
			{
				GUI.FocusControl("Filter");
			}
			GUI.color = Color.white;
		}
		if (flag && GUI.Button(new Rect(position.width - 24f, 26f, 24f, 24f), "x", BlueStonez.panelquad_button))
		{
			this._filterText = string.Empty;
			GUIUtility.keyboardControl = 0;
		}
		string text = string.Format("PLAYERS ONLINE ({0})", this._playerCount);
		GUI.Label(new Rect(0f, 52f, position.width, 25f), GUIContent.none, BlueStonez.box_grey50);
		GUI.Label(new Rect(10f, 52f, position.width, 25f), text, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(0f, 76f, position.width, position.height - 76f), GUIContent.none, BlueStonez.box_grey50);
		this._playerScroll = GUITools.BeginScrollView(new Rect(0f, 77f, position.width, position.height - 78f), this._playerScroll, new Rect(0f, 0f, position.width - 20f, (float)(this._playerCount * 20)), false, false, true);
		int num = 0;
		string value = this._filterText.ToLower();
		ICollection<CommUser> collection;
		if (GameState.Current.IsMultiplayer)
		{
			ICollection<CommUser> gameUsers = Singleton<ChatManager>.Instance.GameUsers;
			collection = gameUsers;
		}
		else
		{
			collection = Singleton<ChatManager>.Instance.LobbyUsers;
		}
		ICollection<CommUser> collection2 = collection;
		foreach (CommUser commUser in collection2)
		{
			if (string.IsNullOrEmpty(value) || commUser.Name.ToLower().Contains(value))
			{
				if ((num & 1) == 0)
				{
					GUI.Label(new Rect(1f, (float)(num * 20), position.width - 2f, 20f), GUIContent.none, BlueStonez.box_grey38);
				}
				if (this._selectedCommUser != null && this._selectedCommUser.Cmid == commUser.Cmid)
				{
					GUI.color = new Color(ColorScheme.UberStrikeBlue.r, ColorScheme.UberStrikeBlue.g, ColorScheme.UberStrikeBlue.b, 0.5f);
					GUI.Label(new Rect(1f, (float)(num * 20), position.width - 2f, 20f), GUIContent.none, BlueStonez.box_white);
					GUI.color = Color.white;
				}
				if (GUI.Button(new Rect(10f, (float)(num * 20), position.width, 20f), string.Concat(new object[]
				{
					"{",
					commUser.Cmid,
					"} ",
					commUser.Name
				}), BlueStonez.label_interparkmed_10pt_left))
				{
					this._selectedCommUser = commUser;
				}
				GUI.color = Color.white;
				num++;
			}
		}
		this._playerCount = num;
		GUITools.EndScrollView();
		GUI.EndGroup();
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x0005A4C4 File Offset: 0x000586C4
	private void DoPlayerModeration(Rect position)
	{
		int num = this._moderations.Count * 100;
		GUI.BeginGroup(position);
		GUI.Label(new Rect(0f, 0f, position.width, position.height), GUIContent.none, BlueStonez.box_grey50);
		this._moderationScroll = GUITools.BeginScrollView(new Rect(0f, 0f, position.width, position.height), this._moderationScroll, new Rect(0f, 1f, position.width - 20f, (float)num), false, false, true);
		int i = 0;
		int num2 = 0;
		while (i < this._moderations.Count)
		{
			this._moderations[i].Draw(this._moderations[i], new Rect(10f, (float)(num2++ * 100), 360f, 100f));
			i++;
		}
		GUITools.EndScrollView();
		GUI.EndGroup();
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x0005A5C8 File Offset: 0x000587C8
	private void DrawModeration(ModerationPanelGUI.Moderation moderation, Rect position)
	{
		GUI.BeginGroup(position);
		GUI.Label(new Rect(21f, 0f, position.width, 30f), moderation.Title, BlueStonez.label_interparkbold_13pt);
		GUI.Label(new Rect(0f, 30f, 356f, 40f), moderation.Content, BlueStonez.label_itemdescription);
		GUI.Label(new Rect(0f, 0f, position.width, 1f), GUIContent.none, BlueStonez.horizontal_line_grey95);
		bool flag = GUI.Toggle(new Rect(0f, 7f, position.width, 16f), moderation.Selected, GUIContent.none, BlueStonez.radiobutton);
		if (flag && !moderation.Selected)
		{
			moderation.Selected = true;
			this.SelectModeration(moderation.ID);
			switch (moderation.SubSelectionIndex)
			{
			case 0:
				this._banDurationIndex = 1;
				break;
			case 1:
				this._banDurationIndex = 5;
				break;
			case 2:
				this._banDurationIndex = 30;
				break;
			case 3:
				this._banDurationIndex = 360;
				break;
			default:
				this._banDurationIndex = 1;
				break;
			}
			GUIUtility.keyboardControl = 0;
		}
		if (moderation.SubSelection != null)
		{
			GUI.enabled = moderation.Selected;
			GUI.changed = false;
			if (moderation.Selected)
			{
				moderation.SubSelectionIndex = UnityGUI.Toolbar(new Rect(0f, position.height - 25f, position.width, 20f), moderation.SubSelectionIndex, moderation.SubSelection, moderation.SubSelection.Length, BlueStonez.panelquad_toggle);
			}
			else
			{
				UnityGUI.Toolbar(new Rect(0f, position.height - 25f, position.width, 20f), -1, moderation.SubSelection, moderation.SubSelection.Length, BlueStonez.panelquad_toggle);
			}
			if (GUI.changed)
			{
				switch (moderation.SubSelectionIndex)
				{
				case 0:
					this._banDurationIndex = 1;
					break;
				case 1:
					this._banDurationIndex = 5;
					break;
				case 2:
					this._banDurationIndex = 30;
					break;
				case 3:
					this._banDurationIndex = 360;
					break;
				default:
					this._banDurationIndex = 1;
					break;
				}
			}
			GUI.enabled = true;
		}
		GUI.EndGroup();
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x0005A840 File Offset: 0x00058A40
	private void SelectModeration(ModerationPanelGUI.Actions id)
	{
		this._moderationSelection = id;
		for (int i = 0; i < this._moderations.Count; i++)
		{
			if (id != this._moderations[i].ID)
			{
				this._moderations[i].Selected = false;
			}
		}
	}

	// Token: 0x06000D16 RID: 3350 RVA: 0x0005A89C File Offset: 0x00058A9C
	private void ApplyModeration()
	{
		if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator && this._moderations.Exists((ModerationPanelGUI.Moderation m) => m.ID == this._moderationSelection))
		{
			switch (this._moderationSelection)
			{
			case ModerationPanelGUI.Actions.UNMUTE_PLAYER:
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationMutePlayer(0, this._selectedCommUser.Cmid, false);
				PopupSystem.ShowMessage("Action Executed", string.Format("The Player '{0}' was unmuted.", this._selectedCommUser.Name));
				break;
			case ModerationPanelGUI.Actions.GHOST_PLAYER:
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationMutePlayer(this._banDurationIndex, this._selectedCommUser.Cmid, false);
				PopupSystem.ShowMessage("Action Executed", string.Format("The Player '{0}' was ghosted for {1} minutes.", this._selectedCommUser.Name, this._banDurationIndex));
				break;
			case ModerationPanelGUI.Actions.MUTE_PLAYER:
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationMutePlayer(this._banDurationIndex, this._selectedCommUser.Cmid, true);
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationMutePlayer(this._banDurationIndex, this._selectedCommUser.Cmid, false);
				PopupSystem.ShowMessage("Action Executed", string.Format("The Player '{0}' was muted for {1} minutes.", this._selectedCommUser.Name, this._banDurationIndex));
				break;
			case ModerationPanelGUI.Actions.KICK_FROM_GAME:
				if (this._selectedCommUser.CurrentGame != null && this._selectedCommUser.CurrentGame.Server != null)
				{
					GamePeerAction.KickPlayer(this._selectedCommUser.CurrentGame.Server.ConnectionString, this._selectedCommUser.Cmid);
					PopupSystem.ShowMessage("Action Executed", string.Format("The Player '{0}' was kicked out of his current game!", this._selectedCommUser.Name));
				}
				else
				{
					PopupSystem.ShowMessage("Warning", string.Format("The Player '{0}' is currently not in a game!", this._selectedCommUser.Name));
				}
				break;
			case ModerationPanelGUI.Actions.KICK_FROM_APP:
				AutoMonoBehaviour<CommConnectionManager>.Instance.Client.Lobby.Operations.SendModerationBanPlayer(this._selectedCommUser.Cmid);
				PopupSystem.ShowMessage("Action Executed", string.Format("The Player '{0}' was disconnected from all servers!", this._selectedCommUser.Name));
				break;
			}
			this._moderationSelection = ModerationPanelGUI.Actions.NONE;
			foreach (ModerationPanelGUI.Moderation moderation in this._moderations)
			{
				moderation.Selected = false;
			}
		}
	}

	// Token: 0x04000C5E RID: 3166
	private float _nextUpdate;

	// Token: 0x04000C5F RID: 3167
	private CommUser _selectedCommUser;

	// Token: 0x04000C60 RID: 3168
	private Vector2 _playerScroll = Vector2.zero;

	// Token: 0x04000C61 RID: 3169
	private Vector2 _moderationScroll = Vector2.zero;

	// Token: 0x04000C62 RID: 3170
	private Rect _rect;

	// Token: 0x04000C63 RID: 3171
	private List<ModerationPanelGUI.Moderation> _moderations;

	// Token: 0x04000C64 RID: 3172
	private string _filterText = string.Empty;

	// Token: 0x04000C65 RID: 3173
	private int _banDurationIndex = 1;

	// Token: 0x04000C66 RID: 3174
	private ModerationPanelGUI.Actions _moderationSelection;

	// Token: 0x04000C67 RID: 3175
	private int _playerCount;

	// Token: 0x020001D5 RID: 469
	private enum Actions
	{
		// Token: 0x04000C69 RID: 3177
		NONE,
		// Token: 0x04000C6A RID: 3178
		UNMUTE_PLAYER,
		// Token: 0x04000C6B RID: 3179
		GHOST_PLAYER,
		// Token: 0x04000C6C RID: 3180
		MUTE_PLAYER,
		// Token: 0x04000C6D RID: 3181
		KICK_FROM_GAME = 5,
		// Token: 0x04000C6E RID: 3182
		KICK_FROM_APP
	}

	// Token: 0x020001D6 RID: 470
	private class Moderation
	{
		// Token: 0x06000D19 RID: 3353 RVA: 0x00009BD3 File Offset: 0x00007DD3
		public Moderation(MemberAccessLevel level, ModerationPanelGUI.Actions id, string title, string context, string option, Action<ModerationPanelGUI.Moderation, Rect> draw) : this(level, id, title, context, option, draw, null)
		{
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x00009BE5 File Offset: 0x00007DE5
		public Moderation(MemberAccessLevel level, ModerationPanelGUI.Actions id, string title, string context, string option, Action<ModerationPanelGUI.Moderation, Rect> draw, GUIContent[] subselection)
		{
			this.Level = level;
			this.ID = id;
			this.Title = title;
			this.Content = context;
			this.Draw = draw;
			this.SubSelection = subselection;
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x00009C1A File Offset: 0x00007E1A
		// (set) Token: 0x06000D1C RID: 3356 RVA: 0x00009C22 File Offset: 0x00007E22
		public MemberAccessLevel Level { get; private set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x00009C2B File Offset: 0x00007E2B
		// (set) Token: 0x06000D1E RID: 3358 RVA: 0x00009C33 File Offset: 0x00007E33
		public ModerationPanelGUI.Actions ID { get; private set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x06000D1F RID: 3359 RVA: 0x00009C3C File Offset: 0x00007E3C
		// (set) Token: 0x06000D20 RID: 3360 RVA: 0x00009C44 File Offset: 0x00007E44
		public string Title { get; private set; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000D21 RID: 3361 RVA: 0x00009C4D File Offset: 0x00007E4D
		// (set) Token: 0x06000D22 RID: 3362 RVA: 0x00009C55 File Offset: 0x00007E55
		public string Content { get; private set; }

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000D23 RID: 3363 RVA: 0x00009C5E File Offset: 0x00007E5E
		// (set) Token: 0x06000D24 RID: 3364 RVA: 0x00009C66 File Offset: 0x00007E66
		public string Option { get; private set; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x00009C6F File Offset: 0x00007E6F
		// (set) Token: 0x06000D26 RID: 3366 RVA: 0x00009C77 File Offset: 0x00007E77
		public Action<ModerationPanelGUI.Moderation, Rect> Draw { get; private set; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000D27 RID: 3367 RVA: 0x00009C80 File Offset: 0x00007E80
		// (set) Token: 0x06000D28 RID: 3368 RVA: 0x00009C88 File Offset: 0x00007E88
		public GUIContent[] SubSelection { get; private set; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000D29 RID: 3369 RVA: 0x00009C91 File Offset: 0x00007E91
		// (set) Token: 0x06000D2A RID: 3370 RVA: 0x00009C99 File Offset: 0x00007E99
		public int SubSelectionIndex { get; set; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000D2B RID: 3371 RVA: 0x00009CA2 File Offset: 0x00007EA2
		// (set) Token: 0x06000D2C RID: 3372 RVA: 0x00009CAA File Offset: 0x00007EAA
		public bool Selected { get; set; }
	}
}
