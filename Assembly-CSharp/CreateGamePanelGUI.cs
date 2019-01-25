using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Reflection.Emit;
using Cmune.DataCenter.Common.Entities;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using UberStrike.Realtime.UnitySdk;
using UnityEngine;

// Token: 0x020001CC RID: 460
public class CreateGamePanelGUI : MonoBehaviour, IPanelGui
{
	// Token: 0x06000CBB RID: 3259 RVA: 0x00009883 File Offset: 0x00007A83
	private void Awake()
	{
		this._gameName = string.Empty;
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x00055F30 File Offset: 0x00054130
	private void Start()
	{
		this._dmDescMsg = LocalizedStrings.DMModeDescriptionMsg;
		this._tdmDescMsg = LocalizedStrings.TDMModeDescriptionMsg;
		this._elmDescMsg = LocalizedStrings.ELMModeDescriptionMsg;
		this._modeSelection.Add(GameModeType.EliminationMode, new GUIContent(LocalizedStrings.TeamElimination));
		this._modeSelection.Add(GameModeType.TeamDeathMatch, new GUIContent(LocalizedStrings.TeamDeathMatch));
		this._modeSelection.Add(GameModeType.DeathMatch, new GUIContent(LocalizedStrings.DeathMatch));
		this._modeSelection.OnSelectionChange += delegate(GameModeType mode)
		{
		};
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x00055FC8 File Offset: 0x000541C8
	private void Update()
	{
		if ((this._windowRect.width != 960f && Screen.width >= 989) || (this._windowRect.width != 640f && Screen.width < 989))
		{
			this._animatingWidth = true;
		}
		if (this._animatingWidth)
		{
			if (Screen.width < 989)
			{
				this._sliderWidth = Mathf.Lerp(this._sliderWidth, 160f, Time.deltaTime * 8f);
				this._textFieldWidth = Mathf.Lerp(this._textFieldWidth, 150f, Time.deltaTime * 8f);
				this._windowRect.width = Mathf.Lerp(this._windowRect.width, 640f, Time.deltaTime * 8f);
				if (Mathf.Approximately(this._windowRect.width, 640f))
				{
					this._animatingWidth = false;
					this._sliderWidth = 160f;
					this._textFieldWidth = 150f;
					this._windowRect.width = 640f;
				}
			}
			else
			{
				this._sliderWidth = Mathf.Lerp(this._sliderWidth, 130f, Time.deltaTime * 8f);
				this._textFieldWidth = Mathf.Lerp(this._textFieldWidth, 115f, Time.deltaTime * 8f);
				this._windowRect.width = Mathf.Lerp(this._windowRect.width, 960f, Time.deltaTime * 8f);
				if (Mathf.Approximately(this._windowRect.width, 960f))
				{
					this._animatingWidth = false;
					this._sliderWidth = 130f;
					this._textFieldWidth = 115f;
					this._windowRect.width = 960f;
				}
			}
		}
		if (this._animatingIndex)
		{
			if (this._viewingLeft)
			{
				this._xOffset = Mathf.Lerp(this._xOffset, 0f, Time.deltaTime * 8f);
				if (Mathf.Abs(this._xOffset) < 2f)
				{
					this._xOffset = 0f;
					this._animatingIndex = false;
				}
			}
			else
			{
				this._xOffset = Mathf.Lerp(this._xOffset, 370f, Time.deltaTime * 8f);
				if (Mathf.Abs(370f - this._xOffset) < 2f)
				{
					this._xOffset = 370f;
					this._animatingIndex = false;
				}
			}
		}
		this._windowRect.x = ((float)Screen.width - this._windowRect.width) * 0.5f;
		this._windowRect.y = ((float)Screen.height - this._windowRect.height) * 0.5f + 25f;
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x000562A8 File Offset: 0x000544A8
	private void OnGUI()
	{
		GUI.skin = BlueStonez.Skin;
		GUI.depth = 3;
		GUI.BeginGroup(this._windowRect, GUIContent.none, BlueStonez.window);
		GUI.Label(new Rect(0f, 0f, this._windowRect.width, 56f), LocalizedStrings.CreateGameCaps, BlueStonez.tab_strip);
		Rect rect = new Rect(0f, 60f, this._windowRect.width, this._windowRect.height - 60f);
		if (Screen.width < 989)
		{
			this.DrawRestrictedPanel(rect);
		}
		else
		{
			this.DrawFullPanel(rect);
		}
		GUI.EndGroup();
		GuiManager.DrawTooltip();
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x00056364 File Offset: 0x00054564
	private void OnEnable()
	{
		this._windowRect.width = (float)((Screen.width >= 989) ? 960 : 640);
		this._windowRect.height = 420f;
		this._password = string.Empty;
		if (Screen.width < 989)
		{
			this._sliderWidth = 160f;
			this._windowRect.width = 640f;
			this._textFieldWidth = 150f;
		}
		else
		{
			this._sliderWidth = 130f;
			this._windowRect.width = 960f;
			this._textFieldWidth = 115f;
		}
	}

	// Token: 0x06000CC0 RID: 3264 RVA: 0x00009890 File Offset: 0x00007A90
	public void Show()
	{
		base.enabled = true;
		this._viewingLeft = true;
		this._gameName = PlayerDataManager.Name;
		if (this._gameName.Length > 18)
		{
			this._gameName = this._gameName.Remove(18);
		}
	}

	// Token: 0x06000CC1 RID: 3265 RVA: 0x000098D0 File Offset: 0x00007AD0
	public void Hide()
	{
		base.enabled = false;
	}

	// Token: 0x06000CC2 RID: 3266 RVA: 0x00056418 File Offset: 0x00054618
	private void SelectMap(UberstrikeMap map)
	{
		this._mapSelected = map;
		foreach (GameModeType gameModeType in this._modeSelection.Items)
		{
			if (this._mapSelected.IsGameModeSupported(gameModeType))
			{
				this._modeSelection.Select(gameModeType);
				break;
			}
		}
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x00056474 File Offset: 0x00054674
	private void DrawMapSelection(Rect rect)
	{
		float width = (Singleton<MapManager>.Instance.Count <= 8) ? rect.width : (rect.width - 18f);
		int num = 0;
		foreach (UberstrikeMap uberstrikeMap in Singleton<MapManager>.Instance.AllMaps)
		{
			if (uberstrikeMap.IsVisible)
			{
				num++;
			}
		}
		this._scroll = GUITools.BeginScrollView(rect, this._scroll, new Rect(0f, 0f, rect.width - 18f, (float)(10 + num * 35)), false, false, true);
		int num2 = 0;
		foreach (UberstrikeMap uberstrikeMap2 in Singleton<MapManager>.Instance.AllMaps)
		{
			if (uberstrikeMap2.IsVisible)
			{
				if (this._mapSelected == null)
				{
					this.SelectMap(uberstrikeMap2);
				}
				GUIContent content = new GUIContent(uberstrikeMap2.Name);
				if (GUI.Toggle(new Rect(0f, (float)(num2 * 35), width, 35f), uberstrikeMap2 == this._mapSelected, content, BlueStonez.tab_large_left) && this._mapSelected != uberstrikeMap2)
				{
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.CreateGame, 0UL, 1f, 1f);
					this.SelectMap(uberstrikeMap2);
				}
				num2++;
			}
		}
		GUITools.EndScrollView();
	}

	// Token: 0x06000CC4 RID: 3268 RVA: 0x00056628 File Offset: 0x00054828
	private void DrawGameModeSelection(Rect rect)
	{
		GUI.BeginGroup(rect);
		for (int i = 0; i < this._modeSelection.Items.Length; i++)
		{
			GUITools.PushGUIState();
			if (this._mapSelected != null && !this._mapSelected.IsGameModeSupported(this._modeSelection.Items[i]))
			{
				GUI.enabled = false;
			}
			if (GUI.Toggle(new Rect(0f, (float)(i * 20), rect.width, 20f), i == this._modeSelection.Index, this._modeSelection.GuiContent[i], BlueStonez.tab_medium) && this._modeSelection.Index != i)
			{
				this._modeSelection.SetIndex(i);
				if (GUI.changed)
				{
					GUI.changed = false;
					AutoMonoBehaviour<SfxManager>.Instance.Play2dAudioClip(GameAudio.CreateGame, 0UL, 1f, 1f);
				}
			}
			GUI.enabled = true;
			GUITools.PopGUIState();
		}
		GUI.EndGroup();
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x0005672C File Offset: 0x0005492C
	private void DrawGameDescription(Rect rect)
	{
		string text = string.Empty;
		switch (this._modeSelection.Current)
		{
		case GameModeType.DeathMatch:
			text = this._dmDescMsg;
			break;
		case GameModeType.TeamDeathMatch:
			text = this._tdmDescMsg;
			break;
		case GameModeType.EliminationMode:
			text = this._elmDescMsg;
			break;
		}
		GUI.BeginGroup(rect);
		if (this._mapSelected != null)
		{
			int num = 0;
			this._mapSelected.Icon.Draw(new Rect(0f, 6f, rect.width, rect.width * this._mapSelected.Icon.Aspect), false);
			num += 6 + Mathf.RoundToInt(rect.width * this._mapSelected.Icon.Aspect);
			GUI.Label(new Rect(6f, (float)num, rect.width - 12f, 20f), "Mission", BlueStonez.label_interparkbold_11pt_left);
			num += 20;
			GUI.Label(new Rect(6f, (float)num, rect.width - 12f, 60f), text, BlueStonez.label_itemdescription);
			num += 36;
			GUI.Label(new Rect(6f, (float)num, rect.width - 12f, 20f), "Location", BlueStonez.label_interparkbold_11pt_left);
			num += 20;
			GUI.Label(new Rect(6f, (float)num, rect.width - 12f, 100f), this._mapSelected.Description, BlueStonez.label_itemdescription);
		}
		else
		{
			GUI.Label(new Rect(6f, 100f, rect.width - 12f, 100f), "Please select a map", BlueStonez.label_interparkbold_16pt);
		}
		GUI.EndGroup();
	}

    // Token: 0x06000CC6 RID: 3270 RVA: 0x000568FC File Offset: 0x00054AFC
    private void DrawGameConfiguration(Rect rect)
    {
        if (this.IsModeSupported)
        {
            MapSettings mapSettings = this._mapSelected.View.Settings[this._modeSelection.Current];
            if (ApplicationDataManager.IsMobile)
            {
                mapSettings.PlayersMax = Mathf.Min(mapSettings.PlayersMax, 6);
            }
            GUI.BeginGroup(rect);
            GUI.Label(new Rect(6f, 0f, 100f, 25f), LocalizedStrings.GameName, BlueStonez.label_interparkbold_18pt_left);
            if (PlayerDataManager.AccessLevel >= MemberAccessLevel.Moderator)
            {
                GUI.SetNextControlName("GameName");
                this._gameName = GUI.TextField(new Rect(130f, 5f, this._textFieldWidth, 19f), this._gameName, 18, BlueStonez.textField);
                if (string.IsNullOrEmpty(this._gameName) && !GUI.GetNameOfFocusedControl().Equals("GameName"))
                {
                    GUI.color = new Color(1f, 1f, 1f, 0.3f);
                    GUI.Label(new Rect(128f, 12f, 200f, 19f), LocalizedStrings.EnterGameName, BlueStonez.label_interparkmed_11pt_left);
                    GUI.color = Color.white;
                }
                if (this._gameName.Length > 18)
                {
                    this._gameName = this._gameName.Remove(18);
                }
            }
            else
            {
                GUI.Label(new Rect(130f, 5f, this._textFieldWidth, 19f), this._gameName, BlueStonez.label);
            }
            GUI.Label(new Rect(130f + this._textFieldWidth + 16f, 5f, 100f, 19f), "(" + this._gameName.Length + "/18)", BlueStonez.label_interparkbold_11pt_left);
            GUI.Label(new Rect(6f, 25f, 100f, 25f), LocalizedStrings.Password, BlueStonez.label_interparkbold_18pt_left);
            GUI.SetNextControlName("GamePasswd");
            this._password = GUI.PasswordField(new Rect(130f, 28f, this._textFieldWidth, 19f), this._password, '*', 8);
            this._password = this._password.Trim(new char[]
            {
                '\n'
            });
            if (string.IsNullOrEmpty(this._password) && !GUI.GetNameOfFocusedControl().Equals("GamePasswd"))
            {
                GUI.color = new Color(1f, 1f, 1f, 0.3f);
                GUI.Label(new Rect(138f, 33f, 200f, 19f), "No password", BlueStonez.label_interparkmed_11pt_left);
                GUI.color = Color.white;
            }
            if (this._password.Length > 8)
            {
                this._password = this._password.Remove(8);
            }
            GUI.Label(new Rect(130f + this._textFieldWidth + 16f, 28f, 100f, 19f), "(" + this._password.Length + "/8)", BlueStonez.label_interparkbold_11pt_left);
            GUI.Label(new Rect(6f, 55f, 110f, 25f), LocalizedStrings.MaxPlayers, BlueStonez.label_interparkbold_18pt_left);
            GUI.Label(new Rect(130f, 60f, 33f, 15f), Mathf.RoundToInt((float)mapSettings.PlayersCurrent).ToString(), BlueStonez.label_dropdown);
            mapSettings.PlayersCurrent = ((!ApplicationDataManager.IsMobile) ? mapSettings.PlayersCurrent : Mathf.Clamp(mapSettings.PlayersCurrent, 0, 6));
            mapSettings.PlayersCurrent = (int)GUI.HorizontalSlider(new Rect(170f, 60f, this._sliderWidth, 15f), (float)mapSettings.PlayersCurrent, (float)mapSettings.PlayersMin, (float)mapSettings.PlayersMax);
            int num = Mathf.RoundToInt((float)(mapSettings.TimeCurrent / 60));
            GUI.Label(new Rect(6f, 83f, 100f, 25f), LocalizedStrings.TimeLimit, BlueStonez.label_interparkbold_18pt_left);
            GUI.Label(new Rect(130f, 83f, 33f, 15f), num.ToString(), BlueStonez.label_dropdown);
            mapSettings.TimeCurrent = 60 * (int)GUI.HorizontalSlider(new Rect(170f, 86f, this._sliderWidth, 15f), (float)num, (float)(mapSettings.TimeMin / 60), mapSettings.TimeMax / 60f);
            GUI.Label(new Rect(6f, 106f, 100f, 25f), LocalizedStrings.MaxKills, BlueStonez.label_interparkbold_18pt_left);
            GUI.Label(new Rect(130f, 106f, 33f, 15f), mapSettings.KillsCurrent.ToString(), BlueStonez.label_dropdown);
            mapSettings.KillsCurrent = (int)GUI.HorizontalSlider(new Rect(170f, 109f, this._sliderWidth, 15f), (float)mapSettings.KillsCurrent, (float)mapSettings.KillsMin, 200f);
            GUI.Label(new Rect(6f, 150f, 100f, 25f), "Min Level", BlueStonez.label_interparkbold_18pt_left);
            GUI.Label(new Rect(130f, 150f, 33f, 15f), (this._minLevelCurrent != 1) ? this._minLevelCurrent.ToString() : "All", BlueStonez.label_dropdown);
            int num2 = (int)GUI.HorizontalSlider(new Rect(170f, 153f, this._sliderWidth, 15f), (float)this._minLevelCurrent, 1f, 80f);
            if (num2 != this._minLevelCurrent)
            {
                this._minLevelCurrent = num2;
                this._maxLevelCurrent = Mathf.Clamp(this._maxLevelCurrent, this._minLevelCurrent, 80);
            }
            GUI.Label(new Rect(6f, 172f, 100f, 25f), "Max Level", BlueStonez.label_interparkbold_18pt_left);
            GUI.Label(new Rect(130f, 172f, 33f, 15f), (this._maxLevelCurrent != 80) ? this._maxLevelCurrent.ToString() : "All", BlueStonez.label_dropdown);
            int num3 = (int)GUI.HorizontalSlider(new Rect(170f, 175f, this._sliderWidth, 15f), (float)this._maxLevelCurrent, 1f, 80f);
            if (num3 != this._maxLevelCurrent)
            {
                this._maxLevelCurrent = num3;
                this._minLevelCurrent = Mathf.Clamp(this._minLevelCurrent, 1, this._maxLevelCurrent);
            }
            if (!GameRoomHelper.IsLevelAllowed(this._minLevelCurrent, this._maxLevelCurrent, PlayerDataManager.PlayerLevel) && this._minLevelCurrent > PlayerDataManager.PlayerLevel)
            {
                GUI.contentColor = Color.red;
                GUI.Label(new Rect(170f, 190f, this._sliderWidth, 25f), "MinLevel is too high for you!", BlueStonez.label_interparkbold_11pt);
                GUI.contentColor = Color.white;
            }
            else if (!GameRoomHelper.IsLevelAllowed(this._minLevelCurrent, this._maxLevelCurrent, PlayerDataManager.PlayerLevel) && this._maxLevelCurrent < PlayerDataManager.PlayerLevel)
            {
                GUI.contentColor = Color.red;
                GUI.Label(new Rect(170f, 190f, this._sliderWidth, 25f), "MaxLevel is too low for you!", BlueStonez.label_interparkbold_11pt);
                GUI.contentColor = Color.white;
            }

            var counter = 1;
            var flags = Enum.GetValues(typeof(GameFlags.GAME_FLAGS));
            for (int i = 1; i < (int)flags.GetValue(flags.Length - 1) + 1; i *= 2)
            {
                var gameFlag = (GameFlags.GAME_FLAGS)i;
                var gameFlagTitle = Regex.Replace(gameFlag.ToString(), @"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))", " $0");
                var y = 200 + (20 * Math.Ceiling(counter / 2f));
                var column = counter;
                while (column > 2)
                    column -= 2;
                var x = 8 + ((column - 1) * 165f);
                
                switch (gameFlag)
                {
                    case GameFlags.GAME_FLAGS.LowGravity:
                        bool flag1 = GUI.Toggle(new Rect(x, (float)y, 160f, 16f), _gameFlags.LowGravity, gameFlagTitle, BlueStonez.toggle);
                        if (_gameFlags.LowGravity != flag1)
                            _gameFlags.LowGravity = !_gameFlags.LowGravity;
                        break;
                    case GameFlags.GAME_FLAGS.NoArmor:
                        bool flag2 = GUI.Toggle(new Rect(x, (float)y, 160f, 16f), _gameFlags.NoArmor, gameFlagTitle, BlueStonez.toggle);
                        if (_gameFlags.NoArmor != flag2)
                            _gameFlags.NoArmor = !_gameFlags.NoArmor;
                        break;
                    case GameFlags.GAME_FLAGS.QuickSwitch:
                        bool flag3 = GUI.Toggle(new Rect(x, (float)y, 160f, 16f), _gameFlags.QuickSwitch, gameFlagTitle, BlueStonez.toggle);
                        if (_gameFlags.QuickSwitch != flag3)
                            _gameFlags.QuickSwitch = !_gameFlags.QuickSwitch;
                        break;
                    case GameFlags.GAME_FLAGS.MeleeOnly:
                        bool flag4 = GUI.Toggle(new Rect(x, (float)y, 160f, 16f), _gameFlags.MeleeOnly, gameFlagTitle, BlueStonez.toggle);
                        if (_gameFlags.MeleeOnly != flag4)
                            _gameFlags.MeleeOnly = !_gameFlags.MeleeOnly;
                        break;
                    case GameFlags.GAME_FLAGS.DefenseBonus:
                        bool flag5 = GUI.Toggle(new Rect(x, (float)y, 160f, 16f), _gameFlags.DefenseBonus, gameFlagTitle, BlueStonez.toggle);
                        if (_gameFlags.DefenseBonus != flag5)
                            _gameFlags.DefenseBonus = !_gameFlags.DefenseBonus;
                        break;
                }
                counter++;
            }

            GUI.EndGroup();
        }
        else
        {
            GUI.Label(rect, "Unsupported Game Mode!", BlueStonez.label_interparkbold_18pt);
        }
    }

	// Token: 0x1700032E RID: 814
	// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x000098D9 File Offset: 0x00007AD9
	private bool IsModeSupported
	{
		get
		{
			return this._mapSelected != null && this._mapSelected.IsGameModeSupported(this._modeSelection.Current);
		}
	}

	// Token: 0x06000CC9 RID: 3273 RVA: 0x00057114 File Offset: 0x00055314
	private void DrawFullPanel(Rect rect)
	{
		int num = 6;
		int num2 = (int)rect.height - 50;
		GUI.BeginGroup(rect);
		GUI.Box(new Rect(6f, 0f, rect.width - 12f, (float)num2), GUIContent.none, BlueStonez.window_standard_grey38);
		this.DrawMapSelection(new Rect((float)num, 0f, 200f, (float)num2));
		num += 206;
		this.DrawVerticalLine((float)(num - 3), 2f, (float)num2);
		this.DrawGameModeSelection(new Rect((float)num, 0f, 160f, (float)num2));
		num += 166;
		this.DrawVerticalLine((float)(num - 3), 2f, (float)num2);
		this.DrawGameDescription(new Rect((float)num, 0f, 255f, (float)num2));
		num += 261;
		this.DrawVerticalLine((float)(num - 3), 2f, (float)num2);
		this.DrawGameConfiguration(new Rect((float)num, 0f, 360f, (float)num2));
		if (GUITools.Button(new Rect(rect.width - 138f, rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.CancelCaps), BlueStonez.button))
		{
			PanelManager.Instance.ClosePanel(PanelType.CreateGame);
		}
		GUITools.PushGUIState();
		string tooltip = string.Empty;
		if (this._mapSelected == null)
		{
			tooltip = "No map selected";
		}
		else if (this._modeSelection == null)
		{
			tooltip = "No mode selected";
		}
		else if (!this.IsModeSupported)
		{
			tooltip = "Unsupported game mode: " + this._modeSelection.Current;
		}
		else if (!Singleton<GameServerController>.Instance.SelectedServer.IsValid)
		{
			tooltip = "Game server not valid: " + Singleton<GameServerController>.Instance.SelectedServer.ConnectionString;
		}
		else if (!LocalizationHelper.ValidateMemberName(this._gameName, ApplicationDataManager.CurrentLocale))
		{
			tooltip = "Game name not valid: " + this._gameName;
		}
		GUI.enabled = (this.IsModeSupported && Singleton<GameServerController>.Instance.SelectedServer.IsValid && LocalizationHelper.ValidateMemberName(this._gameName, ApplicationDataManager.CurrentLocale) && (string.IsNullOrEmpty(this._password) || this.ValidateGamePassword(this._password)));
		if (GUITools.Button(new Rect(rect.width - 138f - 125f, rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.CreateCaps, tooltip), BlueStonez.button_green))
		{
			PanelManager.Instance.ClosePanel(PanelType.CreateGame);
			this._gameName = TextUtilities.Trim(this._gameName);
			MapSettings mapSettings = this._mapSelected.View.Settings[this._modeSelection.Current];
			int timeMinutes = Mathf.RoundToInt((float)(mapSettings.TimeCurrent / 60)) * 60;
			string connectionString = Singleton<GameServerController>.Instance.SelectedServer.ConnectionString;
			Singleton<GameStateController>.Instance.CreateNetworkGame(connectionString, this._mapSelected.Id, this._modeSelection.Current, this._gameName, this._password, timeMinutes, mapSettings.KillsCurrent, mapSettings.PlayersCurrent, this._minLevelCurrent, this._maxLevelCurrent, (GameFlags.GAME_FLAGS)_gameFlags.ToInt());
		}
		GUITools.PopGUIState();
		GUI.EndGroup();
	}

	// Token: 0x06000CCA RID: 3274 RVA: 0x00057478 File Offset: 0x00055678
	private void DrawRestrictedPanel(Rect rect)
	{
		float num = 6f - this._xOffset;
		int num2 = (int)rect.height - 50;
		GUI.BeginGroup(rect);
		GUI.Box(new Rect(6f, 0f, rect.width - 12f, (float)num2), GUIContent.none, BlueStonez.window_standard_grey38);
		if (this._animatingIndex || this._viewingLeft)
		{
			this.DrawMapSelection(new Rect(num, 0f, 200f, (float)num2));
		}
		num += 206f;
		if (this._animatingIndex || this._viewingLeft)
		{
			this.DrawVerticalLine(num - 3f, 2f, 300f);
			this.DrawGameModeSelection(new Rect(num, 0f, 160f, (float)num2));
		}
		num += 166f;
		if (this._animatingIndex || this._viewingLeft)
		{
			this.DrawVerticalLine(num - 3f, 2f, 300f);
		}
		this.DrawGameDescription(new Rect(num, 0f, 255f, (float)num2));
		num += 261f;
		if (this._animatingIndex || !this._viewingLeft)
		{
			this.DrawVerticalLine(num - 3f, 2f, 300f);
		}
		this.DrawGameConfiguration(new Rect(num, 0f, 360f, (float)num2));
		if (GUITools.Button(new Rect(rect.width - 138f, rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.CancelCaps), BlueStonez.button))
		{
			PanelManager.Instance.ClosePanel(PanelType.CreateGame);
		}
		GUITools.PushGUIState();
		GUI.enabled = (!this._animatingIndex && !this._animatingWidth);
		string text = (!this._viewingLeft) ? "Back" : "Customize";
		if (GUITools.Button(new Rect(rect.width - 138f - 125f, rect.height - 40f, 120f, 32f), new GUIContent(text), BlueStonez.button))
		{
			this._animatingIndex = true;
			this._viewingLeft = !this._viewingLeft;
		}
		GUITools.PopGUIState();
		string tooltip = string.Empty;
		if (this._mapSelected == null)
		{
			tooltip = "No map selected";
		}
		else if (this._modeSelection == null)
		{
			tooltip = "No mode selected";
		}
		else if (!this.IsModeSupported)
		{
			tooltip = "Unsupported game mode: " + this._modeSelection.Current;
		}
		else if (!Singleton<GameServerController>.Instance.SelectedServer.IsValid)
		{
			tooltip = "Game server not valid: " + Singleton<GameServerController>.Instance.SelectedServer.ConnectionString;
		}
		else if (!LocalizationHelper.ValidateMemberName(this._gameName, ApplicationDataManager.CurrentLocale))
		{
			tooltip = "Game name not valid: " + this._gameName;
		}
		GUITools.PushGUIState();
		GUI.enabled = (this.IsModeSupported && Singleton<GameServerController>.Instance.SelectedServer.IsValid && LocalizationHelper.ValidateMemberName(this._gameName, ApplicationDataManager.CurrentLocale) && (string.IsNullOrEmpty(this._password) || this.ValidateGamePassword(this._password)));
		if (GUITools.Button(new Rect(rect.width - 138f - 250f, rect.height - 40f, 120f, 32f), new GUIContent(LocalizedStrings.CreateCaps, tooltip), BlueStonez.button_green))
		{
			PanelManager.Instance.ClosePanel(PanelType.CreateGame);
			MapSettings mapSettings = this._mapSelected.View.Settings[this._modeSelection.Current];
			string connectionString = Singleton<GameServerController>.Instance.SelectedServer.ConnectionString;
			Singleton<GameStateController>.Instance.CreateNetworkGame(connectionString, this._mapSelected.Id, this._modeSelection.Current, this._gameName, this._password, mapSettings.TimeCurrent, mapSettings.KillsCurrent, mapSettings.PlayersCurrent, this._minLevelCurrent, this._maxLevelCurrent, (GameFlags.GAME_FLAGS)_gameFlags.ToInt());
		}
		GUITools.PopGUIState();
		GUI.EndGroup();
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x000098FF File Offset: 0x00007AFF
	private void DrawVerticalLine(float x, float y, float height)
	{
		GUI.Label(new Rect(x, y, 1f, height), GUIContent.none, BlueStonez.vertical_line_grey95);
	}

	// Token: 0x06000CCC RID: 3276 RVA: 0x000578CC File Offset: 0x00055ACC
	private bool ValidateGamePassword(string psv)
	{
		bool result = false;
		if (!string.IsNullOrEmpty(psv) && psv.Length <= 8)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x1700032F RID: 815
	// (get) Token: 0x06000CCD RID: 3277 RVA: 0x00007D4D File Offset: 0x00005F4D
	public bool IsEnabled
	{
		get
		{
			return base.enabled;
		}
	}

	// Token: 0x04000C0C RID: 3084
	private const int LevelMax = 80;

	// Token: 0x04000C0D RID: 3085
	private const int LevelMin = 1;

	// Token: 0x04000C0E RID: 3086
	private const int OFFSET = 6;

	// Token: 0x04000C0F RID: 3087
	private const int BUTTON_HEIGHT = 50;

	// Token: 0x04000C10 RID: 3088
	private const int MAP_WIDTH = 200;

	// Token: 0x04000C11 RID: 3089
	private const int MODE_WIDTH = 160;

	// Token: 0x04000C12 RID: 3090
	private const int DESC_WIDTH = 255;

	// Token: 0x04000C13 RID: 3091
	private const int MODS_WIDTH = 360;

	// Token: 0x04000C14 RID: 3092
	private const int MIN_WIDTH = 640;

	// Token: 0x04000C15 RID: 3093
	private const int MAX_WIDTH = 960;

	// Token: 0x04000C16 RID: 3094
	private const int MIN_NAME_FIELD_WIDTH = 115;

	// Token: 0x04000C17 RID: 3095
	private const int MAX_NAME_FIELD_WIDTH = 150;

	// Token: 0x04000C18 RID: 3096
	private const int LEFT_X = 0;

	// Token: 0x04000C19 RID: 3097
	private const int RIGHT_X = 370;

	// Token: 0x04000C1A RID: 3098
	private int _minLevelCurrent = 1;

	// Token: 0x04000C1B RID: 3099
	private int _maxLevelCurrent = 80;

	// Token: 0x04000C1C RID: 3100
	private bool _animatingWidth;

	// Token: 0x04000C1D RID: 3101
	private bool _animatingIndex;

	// Token: 0x04000C1E RID: 3102
	private float _xOffset;

	// Token: 0x04000C1F RID: 3103
	private bool _viewingLeft = true;

	// Token: 0x04000C20 RID: 3104
	private GameFlags _gameFlags = new GameFlags();

	// Token: 0x04000C21 RID: 3105
	private UberstrikeMap _mapSelected;

	// Token: 0x04000C22 RID: 3106
	private SelectionGroup<GameModeType> _modeSelection = new SelectionGroup<GameModeType>();

	// Token: 0x04000C23 RID: 3107
	private Rect _windowRect;

	// Token: 0x04000C24 RID: 3108
	private Vector2 _scroll = Vector2.zero;

	// Token: 0x04000C25 RID: 3109
	private string _gameName = string.Empty;

	// Token: 0x04000C26 RID: 3110
	private string _password = string.Empty;

	// Token: 0x04000C27 RID: 3111
	private int _selectedGrid;

	// Token: 0x04000C28 RID: 3112
	private float _textFieldWidth = 170f;

	// Token: 0x04000C29 RID: 3113
	private float _sliderWidth = 130f;

	// Token: 0x04000C2A RID: 3114
	private string _dmDescMsg = string.Empty;

	// Token: 0x04000C2B RID: 3115
	private string _tdmDescMsg = string.Empty;

	// Token: 0x04000C2C RID: 3116
	private string _elmDescMsg = string.Empty;
}
