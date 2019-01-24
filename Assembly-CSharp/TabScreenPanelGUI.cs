using System;
using System.Collections.Generic;
using UberStrike.Core.Models;
using UberStrike.Core.Types;
using UnityEngine;

// Token: 0x02000167 RID: 359
public class TabScreenPanelGUI : MonoBehaviour
{
	// Token: 0x170002AB RID: 683
	// (get) Token: 0x0600098D RID: 2445 RVA: 0x00007FB4 File Offset: 0x000061B4
	// (set) Token: 0x0600098E RID: 2446 RVA: 0x00007FBB File Offset: 0x000061BB
	public static bool Enabled
	{
		get
		{
			return TabScreenPanelGUI._isEnabled;
		}
		set
		{
			if (TabScreenPanelGUI._isEnabled != value)
			{
				TabScreenPanelGUI._isEnabled = value;
			}
		}
	}

	// Token: 0x170002AC RID: 684
	// (get) Token: 0x0600098F RID: 2447 RVA: 0x00007FCE File Offset: 0x000061CE
	// (set) Token: 0x06000990 RID: 2448 RVA: 0x00007FD5 File Offset: 0x000061D5
	public static bool ForceShow { get; set; }

	// Token: 0x06000991 RID: 2449 RVA: 0x00007FDD File Offset: 0x000061DD
	public static void SetPlayerListAll(List<GameActorInfo> players)
	{
		TabScreenPanelGUI._allPlayers = players;
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x00007FE5 File Offset: 0x000061E5
	public static void SetPlayerListRed(List<GameActorInfo> redPlayers)
	{
		TabScreenPanelGUI._redTeam = redPlayers;
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x00007FED File Offset: 0x000061ED
	public static void SetPlayerListBlue(List<GameActorInfo> bluePlayers)
	{
		TabScreenPanelGUI._blueTeam = bluePlayers;
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x00007FF5 File Offset: 0x000061F5
	public static void SetGameName(string name)
	{
		TabScreenPanelGUI._gameName = name;
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x00007FFD File Offset: 0x000061FD
	public static void SetServerName(string name)
	{
		TabScreenPanelGUI._serverName = name;
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x0003C190 File Offset: 0x0003A390
	private void Awake()
	{
		TabScreenPanelGUI.ForceShow = false;
		this._rect = default(Rect);
		this._panelSize.x = 700f;
		this._panelSize.y = 400f;
		TabScreenPanelGUI._allPlayers = new List<GameActorInfo>(0);
		TabScreenPanelGUI._redTeam = new List<GameActorInfo>(0);
		TabScreenPanelGUI._blueTeam = new List<GameActorInfo>(0);
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x0003C1F4 File Offset: 0x0003A3F4
	private void Update()
	{
		this._panelSize.x = (float)(Screen.width * 7 / 8);
		this._panelSize.y = (float)(Screen.height * 8 / 9);
		this._rect.x = ((float)Screen.width - this._panelSize.x) * 0.5f;
		this._rect.y = ((float)Screen.height - this._panelSize.y) * 0.5f;
		this._rect.width = this._panelSize.x;
		this._rect.height = this._panelSize.y;
		bool flag = (AutoMonoBehaviour<InputManager>.Instance.IsDown(GameInputKey.Tabscreen) || TabScreenPanelGUI.ForceShow) && GameState.Current.IsMultiplayer;
		if (TabScreenPanelGUI.Enabled != flag)
		{
			TabScreenPanelGUI.Enabled = flag;
			if (flag)
			{
				TabScreenPanelGUI.SortPlayersByRank(GameState.Current.Players.Values);
			}
		}
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x00008005 File Offset: 0x00006205
	private void OnGUI()
	{
		if (TabScreenPanelGUI.Enabled)
		{
			GUI.FocusControl(string.Empty);
			GUI.depth = 10;
			this.DrawTabScreen();
		}
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x0003C2F8 File Offset: 0x0003A4F8
	private void DrawTabScreen()
	{
		GUI.skin = BlueStonez.Skin;
		GUI.BeginGroup(this._rect, GUIContent.none, BlueStonez.label_interparkmed_11pt);
		this.DoTitle(new Rect(0f, 0f, this._panelSize.x, 50f));
		bool flag = false;
		int num = (!flag) ? 60 : 174;
		GameModeType gameMode = GameState.Current.GameMode;
		if (gameMode != GameModeType.TeamDeathMatch && gameMode != GameModeType.EliminationMode)
		{
			this._scrollPos = this.DoAllStats(new Rect(0f, 46f, this._panelSize.x, this._panelSize.y - (float)num), this._scrollPos, TabScreenPanelGUI._allPlayers);
		}
		else
		{
			this.DoTeamStats(new Rect(0f, 46f, this._panelSize.x, this._panelSize.y - (float)num));
		}
		GUI.EndGroup();
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x0003C3F8 File Offset: 0x0003A5F8
	private void DoTitle(Rect position)
	{
		GUI.BeginGroup(position, GUIContent.none, BlueStonez.box_overlay);
		GUI.Label(new Rect(10f, 2f, position.width - 230f, 30f), LocalizedStrings.Game + ": ", BlueStonez.label_interparkbold_18pt_left);
		GUI.contentColor = ColorScheme.UberStrikeYellow;
		GUI.Label(new Rect(65f, 2f, position.width - 280f, 30f), TabScreenPanelGUI._gameName, BlueStonez.label_interparkbold_18pt_left);
		GUI.contentColor = Color.white;
		GUI.Label(new Rect(10f, position.height - 32f, position.width - 230f, 30f), "Server: " + TabScreenPanelGUI._serverName, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(position.width - 230f, 2f, 230f, 30f), this.MapName, BlueStonez.label_interparkbold_18pt_left);
		GUI.Label(new Rect(position.width - 230f, position.height - 32f, 220f, 30f), this.ModeName, BlueStonez.label_interparkbold_18pt_left);
		GUI.EndGroup();
	}

	// Token: 0x170002AD RID: 685
	// (get) Token: 0x0600099B RID: 2459 RVA: 0x00008028 File Offset: 0x00006228
	private string MapName
	{
		get
		{
			return LocalizedStrings.Map + ": " + Singleton<MapManager>.Instance.GetMapName(GameState.Current.Map.SceneName);
		}
	}

	// Token: 0x170002AE RID: 686
	// (get) Token: 0x0600099C RID: 2460 RVA: 0x00008052 File Offset: 0x00006252
	private string ModeName
	{
		get
		{
			return LocalizedStrings.Mode + ": " + GameStateHelper.GetModeName(GameState.Current.GameMode);
		}
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x0003C544 File Offset: 0x0003A744
	private void DoTeamStats(Rect position)
	{
		Rect position2 = new Rect(position.x, position.y, position.width * 0.5f, position.height);
		Rect position3 = new Rect(position.x + position2.width, position2.y, position2.width, position2.height);
		this._blueScrollPos = this.DoTeam(position2, TeamID.BLUE, this._blueScrollPos, TabScreenPanelGUI._blueTeam);
		this._redScrollPos = this.DoTeam(position3, TeamID.RED, this._redScrollPos, TabScreenPanelGUI._redTeam);
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x0003C5D8 File Offset: 0x0003A7D8
	private Vector2 DoTeam(Rect position, TeamID teamID, Vector2 scroll, List<GameActorInfo> players)
	{
		GUI.BeginGroup(position);
		Color contentColor = GUI.contentColor;
		GUI.BeginGroup(new Rect(0f, 0f, position.width, 60f), GUIContent.none, BlueStonez.box_overlay);
		GUI.color = ((teamID != TeamID.BLUE) ? ColorScheme.HudTeamRed : ColorScheme.HudTeamBlue);
		if (teamID == TeamID.RED)
		{
			GUI.Label(new Rect(10f, 6f, 200f, 32f), teamID.ToString(), BlueStonez.label_interparkbold_32pt_left);
			GUI.Label(new Rect(10f, 34f, 200f, 18f), string.Format(LocalizedStrings.NPlayers, players.Count), BlueStonez.label_interparkbold_18pt_left);
			GUI.Label(new Rect(position.width - 215f, 8f, 200f, 48f), GameState.Current.ScoreRed.ToString(), BlueStonez.label_interparkbold_48pt_right);
		}
		else
		{
			GUI.Label(new Rect(15f, 8f, 200f, 48f), GameState.Current.ScoreBlue.ToString(), BlueStonez.label_interparkbold_48pt_left);
			GUI.Label(new Rect(position.width - 210f, 6f, 200f, 32f), teamID.ToString(), BlueStonez.label_interparkbold_32pt_right);
			GUI.Label(new Rect(position.width - 210f, 34f, 200f, 18f), string.Format(LocalizedStrings.NPlayers, players.Count), BlueStonez.label_interparkbold_18pt_right);
		}
		GUI.EndGroup();
		GUI.color = contentColor;
		scroll = this.DoAllStats(new Rect(0f, 56f, position.width, position.height - 56f), scroll, players);
		GUI.EndGroup();
		return scroll;
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x0003C7D4 File Offset: 0x0003A9D4
	private Vector2 DoAllStats(Rect position, Vector2 scroll, List<GameActorInfo> players)
	{
		int num = 8;
		int num2 = 25;
		int num3 = 25;
		int num4 = 30;
		int num5 = 32;
		int num6 = (position.width <= 540f) ? 0 : 150;
		int num7 = (position.width <= 420f) ? 0 : 50;
		int num8 = (position.width <= 450f) ? 0 : 30;
		int num9 = (position.width <= 490f) ? 0 : 40;
		int num10 = 30;
		int num11 = 50;
		int num12 = Mathf.Clamp(Mathf.RoundToInt(position.width - 30f - (float)num - (float)num2 - (float)num3 - (float)num4 - (float)num5 - (float)num6 - (float)num10 - (float)num11 - (float)num7 - (float)num8 - (float)num9), 110, 300);
		GUI.BeginGroup(position, GUIContent.none, BlueStonez.box_overlay);
		int num13 = 10 + num + num2;
		GUI.Label(new Rect((float)num13, 10f, (float)num12, 18f), LocalizedStrings.Name, BlueStonez.label_interparkmed_18pt_left);
		num13 += num12;
		GUI.Label(new Rect((float)num13, 15f, (float)num4, 18f), LocalizedStrings.Kills, BlueStonez.label_interparkmed_11pt_left);
		num13 += num4;
		if (num7 > 0)
		{
			GUI.Label(new Rect((float)num13, 15f, (float)num7, 18f), LocalizedStrings.Deaths, BlueStonez.label_interparkmed_11pt_left);
			num13 += num7;
		}
		if (num8 > 0)
		{
			GUI.Label(new Rect((float)num13, 15f, (float)num8, 18f), LocalizedStrings.KDR, BlueStonez.label_interparkmed_11pt_left);
			num13 += num8;
		}
		GUI.Label(new Rect((float)num13, 10f, (float)num10, 18f), GUIContent.none, BlueStonez.label_interparkbold_16pt_left);
		num13 += num10;
		GUI.Label(new Rect((float)num13, 15f, (float)(num3 + 10), 18f), LocalizedStrings.Level, BlueStonez.label_interparkmed_11pt_left);
		num13 += num3;
		GUI.Label(new Rect((float)num13, 10f, (float)(num5 + num6), 18f), GUIContent.none, BlueStonez.label_interparkbold_16pt_left);
		num13 += num5 + num6;
		GUI.Label(new Rect(position.width - (float)num11, 10f, (float)num11, 18f), LocalizedStrings.Ping, BlueStonez.label_interparkmed_18pt_left);
		GUI.Label(new Rect(10f, 32f, position.width - 20f, 1f), GUIContent.none, BlueStonez.horizontal_line_grey95);
		scroll = GUITools.BeginScrollView(new Rect(10f, 36f, position.width - 20f, position.height - 45f), scroll, new Rect(0f, 0f, position.width - 40f, (float)(players.Count * 36)), false, false, true);
		int num14 = 0;
		List<string> list = new List<string>();
		foreach (GameActorInfo gameActorInfo in players)
		{
			num13 = num;
			GUI.BeginGroup(new Rect(0f, (float)(num14 * 36), position.width, 36f));
			if (gameActorInfo.Cmid == PlayerDataManager.Cmid)
			{
				GUI.color = new Color(1f, 1f, 1f, 0.3f);
				GUI.Box(new Rect(0f, 0f, position.width - 21f, 36f), GUIContent.none, BlueStonez.box_white_rounded);
				GUI.color = Color.white;
			}
			GUI.DrawTexture(new Rect((float)num13, 10f, 16f, 16f), UberstrikeIconsHelper.GetIconForChannel(gameActorInfo.Channel));
			num13 += num2;
			Color contentColor = GUI.contentColor;
			GUI.color = Color.white;
			if (!GameState.Current.HasAvatarLoaded(gameActorInfo.Cmid))
			{
				GUI.color = Color.gray;
			}
			else if (gameActorInfo.TeamID == TeamID.BLUE)
			{
				GUI.color = ColorScheme.HudTeamBlue;
			}
			else if (gameActorInfo.TeamID == TeamID.RED)
			{
				GUI.color = ColorScheme.HudTeamRed;
			}
			string text = (!string.IsNullOrEmpty(gameActorInfo.ClanTag)) ? ("[" + gameActorInfo.ClanTag + "] " + gameActorInfo.PlayerName) : gameActorInfo.PlayerName;
			GUI.Label(new Rect((float)num13, 0f, (float)num12, 36f), text, BlueStonez.label_interparkbold_11pt_left_wrap);
			GUI.color = contentColor;
			num13 += num12;
			GUI.Label(new Rect((float)num13, 0f, (float)num4, 36f), gameActorInfo.Kills.ToString(), BlueStonez.label_interparkbold_11pt_left);
			num13 += num4;
			if (num7 > 0)
			{
				GUI.Label(new Rect((float)num13, 0f, (float)num7, 36f), gameActorInfo.Deaths.ToString("N0"), BlueStonez.label_interparkbold_11pt_left);
				num13 += num7;
			}
			if (num8 > 0)
			{
				GUI.Label(new Rect((float)num13, 0f, (float)num8, 36f), this.GetKDR(gameActorInfo).ToString("N1"), BlueStonez.label_interparkbold_11pt_left);
				num13 += num8;
			}
			if (!gameActorInfo.IsAlive)
			{
				GUI.Label(new Rect((float)num13, 6f, 25f, 25f), CommunicatorIcons.SkullCrossbonesIcon, BlueStonez.label_interparkbold_11pt_right);
			}
			num13 += num10;
			GUI.Label(new Rect((float)(num13 + 5), 0f, (float)num3, 36f), gameActorInfo.Level.ToString(), BlueStonez.label_interparkbold_11pt_left);
			num13 += num3 + 5;
			IUnityItem itemInShop = Singleton<ItemManager>.Instance.GetItemInShop(gameActorInfo.CurrentWeaponID);
			if (itemInShop != null)
			{
				list.Add(itemInShop.View.PrefabName);
				itemInShop.DrawIcon(new Rect((float)num13, 2f, 32f, 32f));
				num13 += num5;
				if (num6 > 0)
				{
					GUI.Label(new Rect((float)(num13 + 10), 0f, (float)num6, 36f), itemInShop.Name, BlueStonez.label_interparkbold_11pt_left);
					num13 += num6;
				}
			}
			else
			{
				num13 += num5;
			}
			GUI.Label(new Rect(position.width - 40f - (float)num11, 0f, (float)num11, 36f), gameActorInfo.Ping.ToString(), BlueStonez.label_interparkbold_11pt_right);
			GUI.EndGroup();
			num14++;
		}
		GUITools.EndScrollView();
		GUI.EndGroup();
		return scroll;
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x00008072 File Offset: 0x00006272
	private float GetKDR(GameActorInfo player)
	{
		return ((player.Kills <= 0) ? 1f : ((float)player.Kills)) / ((player.Deaths <= 0) ? 1f : ((float)player.Deaths));
	}

	// Token: 0x040009B7 RID: 2487
	private Rect _rect;

	// Token: 0x040009B8 RID: 2488
	private Vector2 _panelSize;

	// Token: 0x040009B9 RID: 2489
	private Vector2 _scrollPos;

	// Token: 0x040009BA RID: 2490
	private Vector2 _redScrollPos;

	// Token: 0x040009BB RID: 2491
	private Vector2 _blueScrollPos;

	// Token: 0x040009BC RID: 2492
	private static string _gameName = string.Empty;

	// Token: 0x040009BD RID: 2493
	private static string _serverName = string.Empty;

	// Token: 0x040009BE RID: 2494
	private static List<GameActorInfo> _redTeam;

	// Token: 0x040009BF RID: 2495
	private static List<GameActorInfo> _blueTeam;

	// Token: 0x040009C0 RID: 2496
	private static List<GameActorInfo> _allPlayers;

	// Token: 0x040009C1 RID: 2497
	private static bool _isEnabled = false;

	// Token: 0x040009C2 RID: 2498
	public static Action<IEnumerable<GameActorInfo>> SortPlayersByRank = delegate(IEnumerable<GameActorInfo> A_0)
	{
	};
}
